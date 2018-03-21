using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;
using System.Reflection;

namespace Aktywator
{
    public partial class MainForm : Form
    {
        public string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string date = Properties.Resources.BuildDate.Trim();

        private Bws bws;
        private List<Setting> bwsSettings;
        private Tournament tournament;
        internal static TeamNamesSettings teamNames;

        private Version BCSVersion;

        public static Version requiredBCSVersion;
        public static Version requiredFWVersion;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!MySQL.getConfigured()) (new MysqlSettings()).ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            status2.Text = "Wersja " + this.version;
            status3.Text = "Data: " + this.date;

            string detectedVersion = detectBCSVersion();
            if (detectedVersion != null)
            {
                lDetectedVersion.Text = detectedVersion;
                BCSVersion = new Version(detectedVersion);
            }
            else
            {
                lDetectedVersion.Text = "nie wykryto";
            }

            string filename;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                filename = args[1];
            else if (open.ShowDialog() == DialogResult.OK)
                filename = open.FileName;
            else
            {
                Close();
                return;
            }

            bws = new Bws(filename, this);
            bws.convert();

            labelFilename.Text = filename;
            labelFilename.ToolTipText = filename;
            this.shortenFilenameLabel();

            this.fillSectionSelector(bws.getSections());
            cbNamesSection.Items.Clear();
            foreach (object i in cbSettingsSection.Items)
            {
                cbNamesSection.Items.Add(i);
            }
            
            // cloning Setting List returned from Bws, because we're going to extend it for version tracking purposes
            this.bwsSettings = new List<Setting>(bws.initSettings());
            this.bwsSettings.Add(new Setting("BM2ShowPlayerNames", this.xShowPlayerNames, bws, new Version(2, 0, 0), new Version(1, 3, 1)));
            bindSettingChanges();
            bws.loadSettings();

            tournament = this.detectTeamyTournament();
            if (tournament != null)
            {
                updateTournamentInfo(tournament);
            }
            else
            {
                syncToolStrip.Visible = false;
                namesPanel.Visible = false;
            }

            this.WindowState = FormWindowState.Normal;
        }

        private void shortenFilenameLabel()
        {
            String originalLabel = (String)labelFilename.Text.Clone();
            int firstBackslash = originalLabel.IndexOf('\\') + 1;
            int lettersToCut = 5;
            while (Graphics.FromHwnd(IntPtr.Zero).MeasureString(labelFilename.Text, labelFilename.Font).Width > 400)
            {
                lettersToCut++;
                labelFilename.Text = originalLabel.Substring(0, firstBackslash) + "[...]"
                    + originalLabel.Substring(firstBackslash + lettersToCut);
            }
        }

        private Tournament detectTeamyTournament()
        {
            try
            {
                string name = bws.getMySQLDatabaseForSection();
                if (name != null)
                {
                    return new TeamyTournament(name);
                }
            }
            catch (Exception e) { }
            return null;
        }

        private void fillSectionSelector(string sections)
        {
            cbSettingsSection.SelectedIndex = 0;
            foreach (string section in sections.Split(',')) {
                cbSettingsSection.Items.Add(bws.sectorNumberToLetter(Int32.Parse(section.Trim())));
            }
        }

        private void bindSettingChanges()
        {
            foreach (Setting s in this.bwsSettings)
            {
                s.field.CheckedChanged += new EventHandler(setting_field_CheckedChanged);
                StringBuilder tBuilder = new StringBuilder();
                if (s.bcsV != null)
                {
                    tBuilder.Append("BCS >= ");
                    tBuilder.Append(s.bcsV);
                    tBuilder.Append(", ");
                }
                if (s.fwV != null)
                {
                    tBuilder.Append("firmware >= ");
                    tBuilder.Append(s.fwV);
                }
                String title = tBuilder.ToString().Trim().Trim(',');
                if (!("".Equals(title)))
                {
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(s.field, title);
                }
            }
        }

        void setting_field_CheckedChanged(object sender, EventArgs e)
        {
            requiredBCSVersion = null;
            requiredFWVersion = null;
            foreach (Setting s in this.bwsSettings)
            {
                if (s.field.Checked)
                {
                    if (requiredBCSVersion == null || requiredBCSVersion < s.bcsV)
                    {
                        requiredBCSVersion = s.bcsV;
                    }
                    if (requiredFWVersion == null || requiredFWVersion < s.fwV)
                    {
                        requiredFWVersion = s.fwV;
                    }
                }
            }
            lRequiredVersion.Text = (requiredBCSVersion != null) ? requiredBCSVersion.ToString() : "--";
            lRequiredFirmware.Text = (requiredFWVersion != null) ? requiredFWVersion.ToString() : "--";
            if (BCSVersion != null)
            {
                if (requiredBCSVersion > BCSVersion)
                {
                    lDetectedVersion.ForeColor = Color.Red;
                }
                else
                {
                    lDetectedVersion.ForeColor = Color.Green;
                }
            }
            else
            {
                lDetectedVersion.ForeColor = Color.Black;
            }
        }

        private string detectBCSVersion()
        {
            RegistryKey[] keys = 
            {
                Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall"),
                Registry.CurrentUser.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall"),
                Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall"),
                Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall")
            };
            foreach (RegistryKey key in keys)
            {
                if (key != null)
                {
                    foreach (var subKey in key.GetSubKeyNames())
                    {
                        RegistryKey appKey = key.OpenSubKey(subKey);
                        if (appKey != null)
                        {
                            foreach (var value in appKey.GetValueNames())
                            {
                                string keyValue = Convert.ToString(appKey.GetValue("Publisher"));
                                if (!keyValue.Equals("Bridge Systems BV", StringComparison.OrdinalIgnoreCase))
                                    continue;

                                string productName = Convert.ToString(appKey.GetValue("DisplayName"));
                                if (!productName.Equals("Bridgemate Control Software", StringComparison.OrdinalIgnoreCase)
                                    && !productName.Equals("Bridgemate Pro Control", StringComparison.OrdinalIgnoreCase))
                                    continue;

                                string appPath = Convert.ToString(appKey.GetValue("InstallLocation"));
                                if (appPath != null)
                                {
                                    Bws.setAppLocation(appPath);
                                }

                                string version = Convert.ToString(appKey.GetValue("DisplayVersion"));
                                return version;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void bLaunch_Click(object sender, EventArgs e)
        {
            if (trySave())
            {
                int max = 0;
                int.TryParse(bws.sql.selectOne("SELECT max(ID) FROM Clients;"), out max);
                try
                {
                    bws.sql.query("INSERT INTO Clients (ID,Computer) VALUES (" + (max + 1) + ",'" + Environment.MachineName + "');");
                }
                catch (OleDbException)
                {
                }
                string id = bws.sql.selectOne("SELECT ID FROM Clients WHERE Computer='" + Environment.MachineName + "';");
                if (id.Length == 0) id = "0";
                bws.sql.query("UPDATE Tables SET ComputerID=" + id);

                try
                {
                    bws.runBCS();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie znalazłem BCS (BMPro) :(", "Nie znaleziono BCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bws != null)
                bws.sql.close();
        }

        private void konwertujuzupelnijBrakiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bws.convert();
            MessageBox.Show("Zrobione! Ew. brakujące tabele i pola zostały dodane.", "Konwersja do BM2");
        }

        private void updateUstawieńWSerwerkuWTrakcieSesjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trySave())
            {
                bws.updateSettings();
                MessageBox.Show("Wykonano!", "Settings update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool trySave()
        {
            bool blad = false;
            if (xPINcode.Text.Length != 4) blad = true;
            else
                for (int i = 0; i < xPINcode.Text.Length; i++)
                    if ((xPINcode.Text[i] < '0') || (xPINcode.Text[i] > '9')) blad = true;
            if (blad)
            {
                MessageBox.Show("PIN musi składać się z 4 cyfr.", "Błędny PIN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                xPINcode.Focus();
                return false;
            }
            else
            {
                bws.saveSettings();
                return true;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            trySave(); 
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            bws.loadSettings();
        }

        private void xShowResults_CheckedChanged(object sender, EventArgs e)
        {
            if (xShowResults.Checked)
            {
                xRepeatResults.Enabled = true;
                xShowPercentage.Enabled = true;
                xResultsOverview.Enabled = true;
                xGroupSections.Enabled = true;
            }
            else
            {
                xRepeatResults.Enabled = false;
                xShowPercentage.Enabled = false;
                xShowPercentage.Checked = false;
                xResultsOverview.Enabled = false;
                xGroupSections.Enabled = false;
            }
            if (cbSettingsSection.Items.Count > 2)
            {
                bws.sectionGroupWarning();
            }
        }

        private void xMemberNumbers_CheckedChanged(object sender, EventArgs e)
        {
            if (xMemberNumbers.Checked)
            {
                xMemberNumbersNoBlankEntry.Enabled = true;
            }
            else
            {
                xMemberNumbersNoBlankEntry.Enabled = false;
            }
        }

        private void bMySQLTournament_Click(object sender, EventArgs e)
        {
            startLoading();
            try
            {
                ChooseTournament choose = new ChooseTournament();
                choose.ShowDialog();
                if (choose.chosenTournament != null)
                {
                    tournament = choose.chosenTournament;
                    updateTournamentInfo(tournament);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            stopLoading();
        }

        private void bRRBTournament_Click(object sender, EventArgs e)
        {
            startLoading();
            try
            {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Filter = "RRBrigde tournament files (*.rrt)|*.rrt";
                fDialog.RestoreDirectory = true;
                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    tournament = new RRBTournament(fDialog.FileName);
                    updateTournamentInfo(tournament);
                }
                bTeamsNamesSettings.Visible = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            stopLoading();
        }

        private void updateTournamentInfo(Tournament tournament)
        {
            if (tournament != null)
            {
                tournament.setup();

                lTournament.Text = tournament.getName();
                lType.Text = tournament.getTypeLabel();
                lSections.Text = tournament.getSectionsNum();
                lTables.Text = tournament.getTablesNum();
                if (tournament.GetType().Equals(typeof(TeamyTournament)))
                {
                    lSkok.Visible = true;
                    numTeamsTableOffset.Visible = true;
                    bTeamsNamesSettings.Visible = true;
                    teamNames = new TeamNamesSettings();
                    teamNames.initTournament((TeamyTournament)tournament, this);
                    bTeamsNamesSettings.Text = teamNames.getLabel();
                    cbNamesSection.Items.Remove("*");
                    string sectionForTournament = bws.detectTeamySection(tournament.getName());
                    if (sectionForTournament != null)
                    {
                        cbNamesSection.SelectedItem = sectionForTournament;
                    }
                    else
                    {
                        cbNamesSection.SelectedItem = cbNamesSection.Items[0];
                    }
                }
                else
                {
                    lSkok.Visible = false;
                    numTeamsTableOffset.Visible = false;
                    bTeamsNamesSettings.Visible = false;
                    cbNamesSection.SelectedIndex = 0;
                }
                syncToolStrip.Visible = true;
                namesPanel.Visible = true;
                tournament.clearCellLocks(namesGridView);
                tournament.displayNameList(namesGridView);
                tournament.clearCellLocks(namesGridView);
            }
            else
            {
                lSkok.Visible = false;
                numTeamsTableOffset.Visible = false;
            }
        }

        private void bSync_Click(object sender, EventArgs e)
        {
            try
            {
                bws.syncNames(tournament, true, cbNamesSection.SelectedItem.ToString(), namesGridView);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void bMysqlSettings_Click(object sender, EventArgs e)
        {
            (new MysqlSettings()).ShowDialog();
        }

        private void bTruncate_Click(object sender, EventArgs e)
        {
            try
            {
                bws.sql.query("UPDATE PlayerNumbers SET Name=NULL AND Updated=True WHERE 1=1");
                MessageBox.Show("Wykonano!", "Usuń nazwiska", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void bAutoSync_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                int interval;
                if ((!int.TryParse(eInterval.Text, out interval)) || (interval < 15))
                {
                    eInterval.Focus();
                    return;
                }
                timer.Interval = interval * 1000;
                eInterval.Enabled = false;
                bAutoSync.Text = "pracuje się...";
                bMysqlSettings.Enabled = false;
                toolStripSplitButton1.Enabled = false;
                timer.Enabled = true;
            }
            else
            {
                timer.Enabled = false;
                bAutoSync.Text = "Synchronizuj co:";
                eInterval.Enabled = true;
                bMysqlSettings.Enabled = true;
                toolStripSplitButton1.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bws.syncNames(tournament, false, cbNamesSection.SelectedItem.ToString(), namesGridView);
        }

        private void bForceSync_Click(object sender, EventArgs e)
        {
            bws.sql.query("UPDATE PlayerNumbers SET Updated=True");
            MessageBox.Show("Wykonano!", "Force sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bLoadHands_Click(object sender, EventArgs e)
        {
            if (openPBN.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    PBN pbn = new PBN(openPBN.FileName, bws.lowBoard(), bws.highBoard());
                    StringBuilder confirmMsg = new StringBuilder();
                    confirmMsg.Append("Wczytane zostaną rozkłady z następującego pliku:\n" + "");
                    if (pbn.title != null && !pbn.title.Equals(""))
                    {
                        confirmMsg.Append("\nNagłówek pliku: " + pbn.title);
                    }
                    confirmMsg.Append("\nPierwszy rozkład: ");
                    for (int i = 0; i < pbn.handRecords[bws.lowBoard()].north.Length; i++)
                    {
                        if ("".Equals(pbn.handRecords[bws.lowBoard()].north[i]))
                        {
                            confirmMsg.Append("renons, ");
                        }
                        else
                        {
                            confirmMsg.Append(pbn.handRecords[bws.lowBoard()].north[i]);
                            break;
                        }
                    }
                    if (MessageBox.Show(confirmMsg.ToString(), "Potwierdź rozkłady", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int count = bws.loadHandRecords(pbn);
                        MessageBox.Show("Wczytanych rozkładów: " + count, "Rozkłady wczytane!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Błąd wczytywania rozkładów", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bClearHands_Click(object sender, EventArgs e)
        {
            try
            {
                bws.clearHandRecords();
                MessageBox.Show("Wyczyszczono rozkłady", "Rozkłady wyczyszczone!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd czyszczenia rozkładów", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateSession_Click(object sender, EventArgs e)
        {
            if (trySave())
            {
                bws.updateSettings();
                MessageBox.Show("Wykonano!", "Settings update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            toolStripSplitButton1.ShowDropDown();
        }

        private void namesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > 0)
            {
                DataGridViewCell cell = namesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Tag = true;
                cell.Style.BackColor = Color.Yellow;
            }
        }

        public void namesTimer_Tick(object sender, EventArgs e)
        {
            tournament.displayNameList(namesGridView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tournament.clearCellLocks(namesGridView);
            tournament.displayNameList(namesGridView);
        }

        private void numNamesRefreshInterval_ValueChanged(object sender, EventArgs e)
        {
            namesTimer.Interval = Convert.ToInt32(numNamesRefreshInterval.Value) * 1000;
        }

        private void namesGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > 0)
            {
                DataGridViewCell cell = namesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = tournament.shortenNameToBWS(cell.Value.ToString());
            }
        }

        private void cbSettingsSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            bws.loadSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            namesTimer.Enabled = checkBox1.Checked;
            if (namesTimer.Enabled)
            {
                namesTimer_Tick(null, null);
            }
        }

        private void lGroupSectionsWarning_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opcja grupowania zapisów w sektorach (albo osobnego maksowania sektorów) nie może być zaktualizowana w trakcie trwania sesji!", "Ustawienia grupowania zapisów w sektorach", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void bTeamsNamesSettings_Click(object sender, EventArgs e)
        {
            teamNames.ShowDialog();
        }

        internal void startLoading()
        {
            tabControl1.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
        }

        internal void stopLoading()
        {
            tabControl1.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void gwSections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > 0 && gwSections.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
            {
                HandRecordPreview preview = new HandRecordPreview((HandRecord)gwSections.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag, gwSections.Rows[e.RowIndex].HeaderCell.Value + "-" + gwSections.Columns[e.ColumnIndex].HeaderCell.Value);
                preview.ShowDialog();
            }
        }

        private void gwSections_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.IsCurrentCellDirty)
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
