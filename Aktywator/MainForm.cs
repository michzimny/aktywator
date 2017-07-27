using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;

namespace Aktywator
{
    public partial class MainForm : Form
    {
        public string version = "1.0.7";
        public string date = "28.06.2017";

        private Bws bws;
        private List<Setting> bwsSettings;
        private Tournament tournament;

        private Version BCSVersion;

        public static Version requiredBCSVersion;
        public static Version requiredFWVersion;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (MySQL.getPass() == "") (new MysqlSettings()).ShowDialog();
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
            if (!bws.isBm2())
                if (MessageBox.Show("Ten BWS nie jest przygotowany dla BM2. Przekonwertować?", "Konwersja do BM2",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    bws.convert();

            labelFilename.Text = filename;
            // cloning Setting List returned from Bws, because we're going to extend it for version tracking purposes
            this.bwsSettings = new List<Setting>(bws.initSettings());
            this.bwsSettings.Add(new Setting("BM2ShowPlayerNames", this.xShowPlayerNames, bws, new Version(2, 0, 0), new Version(1, 3, 1)));
            bindSettingChanges();
            bws.loadSettings();
            this.WindowState = FormWindowState.Normal;
        }

        private void bindSettingChanges()
        {
            foreach (Setting s in this.bwsSettings)
            {
                s.field.CheckedChanged += new EventHandler(setting_field_CheckedChanged);
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
            }
            else
            {
                xRepeatResults.Enabled = false;
                xShowPercentage.Enabled = false;
                xResultsOverview.Enabled = false;
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

        private void bTournament_Click(object sender, EventArgs e)
        {
            try
            {
                ChooseTournament choose = new ChooseTournament();
                choose.ShowDialog();
                if (choose.chosenTournament != null)
                {
                    if ((tournament != null) && (tournament.mysql != null))
                        tournament.mysql.close();

                    tournament = choose.chosenTournament;
                    tournament.mysql.connect();

                    lTournament.Text = tournament.name;
                    lType.Text = tournament.type == 1 ? "Pary" : "Teamy";
                    lSections.Text = tournament.getSectionsNum();
                    lTables.Text = tournament.getTablesNum();
                    bSync.Enabled = true;
                    bAutoSync.Enabled = true;
                    eInterval.Enabled = true;
                    if (tournament.type == 2)
                    {
                        lSkok.Visible = true;
                        lNazwyTeamow.Visible = true;
                    }
                    else
                    {
                        lSkok.Visible = false;
                        lNazwyTeamow.Visible = false;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void bSync_Click(object sender, EventArgs e)
        {
            try
            {
                bws.syncNames(tournament, true, eOomRounds.Text);
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
                bws.sql.query("UPDATE PlayerNumbers SET Name='XXX' AND Updated=True WHERE 1=1");
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
                bTournament.Enabled = false;
                bMysqlSettings.Enabled = false;
                timer.Enabled = true;
            }
            else
            {
                timer.Enabled = false;
                bAutoSync.Text = "Synchronizuj cyklicznie";
                eInterval.Enabled = true;
                bTournament.Enabled = true;
                bMysqlSettings.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bws.syncNames(tournament, false, eOomRounds.Text);
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

        private void cblSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lWczytywane.Text = bws.getBoardRangeText(bws.getSelectedSections());
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

    }
}
