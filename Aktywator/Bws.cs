using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace Aktywator
{
    class Bws
    {
        private string _filename;
        public string filename
        {
            get { return _filename; }
        }

        public Sql sql;
        public List<Setting> settings;
        private MainForm main;
        public bool settingsChanged = false;
        private static string applicationPath = Common.ProgramFilesx86() + "\\Bridgemate Pro\\";

        class HandInfo
        {
            public List<string> record;
            public bool analysis = false;
        }

        class PairPosition
        {
            public int pairNo;
            public int table;
            public string position;
        }

        public Bws(string filename, MainForm main)
        {
            this._filename = filename;
            sql = new Sql(filename);
            this.main = main;
            string[] sections = this.getSections().Split(',');
            this.displaySectionBoardsInfo(sections);
        }

        private void displaySectionBoardsInfo(string[] sections)
        {
            main.gwSections.Columns.Add(new DataGridViewCheckBoxColumn { Frozen = true, Width = 20, DefaultCellStyle = { ForeColor = Color.White, Alignment = DataGridViewContentAlignment.MiddleCenter } });
            foreach (string section in sections)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 20;
                row.HeaderCell.Value = this.sectorNumberToLetter(Int16.Parse(section));
                main.gwSections.Rows.Add(row);
            }
            SortedDictionary<int, List<string>> boards = this.loadSectionBoards(sections);
            foreach (KeyValuePair<int, List<string>> boardList in boards) 
            {
                main.gwSections.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = boardList.Key.ToString(), Width = 22, DefaultCellStyle = { ForeColor = Color.White, Alignment = DataGridViewContentAlignment.MiddleCenter } });
                foreach (DataGridViewRow row in main.gwSections.Rows) 
                {
                    if (boardList.Value.Contains(row.HeaderCell.Value.ToString()))
                    {
                        row.Cells[row.Cells.Count - 1].Style.BackColor = Color.White;
                    }
                    else
                    {
                        row.Cells[row.Cells.Count - 1].Style.BackColor = Color.Gray;
                    }
                    row.Cells[row.Cells.Count - 1].ReadOnly = true;
                }
            }
            foreach (DataGridViewRow row in main.gwSections.Rows)
            {
                row.Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)row.Cells[0]).TrueValue = true;
                ((DataGridViewCheckBoxCell)row.Cells[0]).FalseValue = false;
            }
            this.displayHandRecordInfo(boards);
        }

        private SortedDictionary<int, List<string>> loadSectionBoards(string[] sections) {
            SortedDictionary<int, List<string>> boards = new SortedDictionary<int, List<string>>();
            foreach (string section in sections)
            {
                string sectionLetter = this.sectorNumberToLetter(Int16.Parse(section));                
                int lowBoard = this.lowBoard(section);
                int highBoard = this.highBoard(section);
                for (int board = lowBoard; board <= highBoard; board++)
                {
                    if (!boards.ContainsKey(board))
                    {
                        boards.Add(board, new List<string>());
                    }
                    boards[board].Add(sectionLetter);
                }
            }
            return boards;            
        }

        private void displayHandRecordInfo(SortedDictionary<int, List<string>> boards) 
        {
            Dictionary<int, Dictionary<string, HandInfo>> handInfo = this.loadHandRecordInfo();
            foreach (KeyValuePair<int, List<string>> board in boards)
            {
                if (handInfo.ContainsKey(board.Key))
                {
                    foreach (string section in board.Value)
                    {
                        this.setHandRecordInfo(board.Key, section, (board.Value.Contains(section) && handInfo[board.Key].ContainsKey(section)) ? handInfo[board.Key][section].record : null, handInfo[board.Key].ContainsKey(section) && handInfo[board.Key][section].analysis);
                    }
                }
                else
                {
                    this.setHandRecordInfo(board.Key);
                }
            }
        }

        private void setHandRecordInfo(int board, string section = null, List<string> layout = null, bool analysis = false)
        {
            foreach (DataGridViewColumn column in main.gwSections.Columns)
            {
                if (column.HeaderText.Equals(board.ToString()))
                {
                    foreach (DataGridViewRow row in main.gwSections.Rows)
                    {
                        if (row.HeaderCell.Value.Equals(section) || section == null)
                        {
                            if (row.Cells[column.Index].Style.BackColor != Color.Gray)
                            {
                                if (layout != null)
                                {
                                    row.Cells[column.Index].Style.BackColor = Color.LimeGreen;
                                    row.Cells[column.Index].Tag = new HandRecord(String.Join(" ", layout.ToArray()));
                                    row.Cells[column.Index].Value = analysis ? "A" : "";
                                    row.Cells[column.Index].ToolTipText = "Dwukliknij, by podejrzeć rozkład";
                                }
                                else
                                {
                                    row.Cells[column.Index].Style.BackColor = Color.Crimson;
                                    row.Cells[column.Index].Tag = null;
                                    row.Cells[column.Index].Value = "";
                                    row.Cells[column.Index].ToolTipText = "";
                                }
                            }
                        }
                    }
                }
            }
        }

        private Dictionary<int, Dictionary<string, HandInfo>> loadHandRecordInfo()
        {
            Dictionary<int, Dictionary<string, HandInfo>> info = new Dictionary<int, Dictionary<string, HandInfo>>();
            try
            {
                OleDbDataReader handData = sql.select("SELECT `Section`, Board, NorthSpades, NorthHearts, NorthDiamonds, NorthClubs, EastSpades, EastHearts, EastDiamonds, EastClubs, SouthSpades, SouthHearts, SouthDiamonds, SouthClubs, WestSpades, WestHearts, WestDiamonds, WestClubs FROM HandRecord");
                while (handData.Read())
                {
                    int boardNumber = Int16.Parse(handData[1].ToString());
                    if (!info.ContainsKey(boardNumber))
                    {
                        info.Add(boardNumber, new Dictionary<string, HandInfo>());
                    }
                    string section = this.sectorNumberToLetter(Int16.Parse(handData[0].ToString()));
                    info[boardNumber].Add(section, new HandInfo { record = new List<string>(), analysis = false });
                    for (int i = 0; i < 4; i++)
                    {
                        StringBuilder singleHand = new StringBuilder();
                        for (int j = 0; j < 4; j++)
                        {
                            singleHand.Append(handData[2 + i * 4 + j].ToString());
                            if (j != 3)
                            {
                                singleHand.Append('.');
                            }
                        }
                        info[boardNumber][section].record.Add(singleHand.ToString().Trim());
                    }
                }
                handData.Close();
            }
            catch (OleDbException)
            {
            }
            try
            {
                OleDbDataReader handData = sql.select("SELECT `Section`, Board FROM HandEvaluation");
                while (handData.Read())
                {
                    int boardNumber = Int16.Parse(handData[1].ToString());
                    string section = this.sectorNumberToLetter(Int16.Parse(handData[0].ToString()));
                    try
                    {
                        info[boardNumber][section].analysis = true;
                    }
                    catch (KeyNotFoundException)
                    {
                    }
                }
                handData.Close();
            }
            catch (OleDbException)
            {
            }
            return info;
        }

        internal int sectorLetterToNumber(string sector)
        {
            return sector.ToUpper()[0] - 'A' + 1;
        }

        internal string sectorNumberToLetter(int sector)
        {
            char character = (char)('A' - 1 + sector);
            return character.ToString();
        }

        public string[] getSelectedSections()
        {
            List<string> sections = new List<string>();
            foreach (DataGridViewRow row in main.gwSections.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    sections.Add(this.sectorLetterToNumber(row.HeaderCell.Value.ToString()).ToString());
                }
            }
            return sections.ToArray();
        }

        public List<Setting> initSettings()
        {
            settings = new List<Setting>();
            settings.Add(new Setting("ShowResults", main.xShowResults, this, new Version(2, 0, 0), new Version(1, 3, 1)));
            settings.Add(new Setting("RepeatResults", main.xRepeatResults, this, null, null));
            settings.Add(new Setting("ShowPercentage", main.xShowPercentage, this, null, null));
            settings.Add(new Setting("GroupSections", main.xGroupSections, this, new Version(2, 1, 10), new Version(1, 3, 1)));
            settings.Add(new Setting("ShowPairNumbers", main.xShowPairNumbers, this, null, null));
            settings.Add(new Setting("IntermediateResults", main.xIntermediateResults, this, null, new Version(1, 4, 1)));
            settings.Add(new Setting("ShowContract", main.xShowContract, this, null, null));
            settings.Add(new Setting("LeadCard", main.xLeadCard, this, null, null));
            settings.Add(new Setting("MemberNumbers", main.xMemberNumbers, this, null, null));
            settings.Add(new Setting("MemberNumbersNoBlankEntry", main.xMemberNumbersNoBlankEntry, this, null, null));
            settings.Add(new Setting("BoardOrderVerification", main.xBoardOrderVerification, this, null, null));
            settings.Add(new Setting("AutoShutDownBPC", main.xAutoShutDownBPC, this, new Version(1, 7, 15), null));
            settings.Add(new Setting("BM2ConfirmNP", main.xConfirmNP, this, new Version(2, 0, 0), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2RemainingBoards", main.xRemainingBoards, this, new Version(2, 0, 0), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2NextSeatings", main.xNextSeatings, this, new Version(2, 0, 0), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2ScoreRecap", main.xScoreRecap, this, new Version(2, 0, 0), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2AutoShowScoreRecap", main.xAutoShowScoreRecap, this, new Version(2, 5, 1), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2ScoreCorrection", main.xScoreCorrection, this, new Version(2, 0, 0), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2AutoBoardNumber", main.xAutoBoardNumber, this, new Version(2, 0, 0), new Version(2, 0, 1)));
            settings.Add(new Setting("BM2ResetFunctionKey", main.xResetFunctionKey, this, new Version(2, 0, 0), new Version(1, 0, 1)));
            settings.Add(new Setting("BM2ViewHandrecord", main.xViewHandrecord, this, new Version(2, 6, 1), new Version(1, 6, 1)));
            settings.Add(new Setting("BM2RecordBidding", main.xCollectBidding, this, new Version(2, 0, 0), new Version(1, 3, 1)));
            settings.Add(new Setting("BM2RecordPlay", main.xCollectPlay, this, new Version(2, 0, 0), new Version(1, 3, 1)));
            settings.Add(new Setting("BM2ValidateLeadCard", main.xCheckLeadCard, this, new Version(3, 2, 1), new Version(2, 2, 1)));
            return settings;
        }

        private string getSectionList(string table)
        {
            try
            {
                string s;
                OleDbDataReader d = sql.select("SELECT DISTINCT `Section` FROM " + table + " ORDER BY 1");
                d.Read();
                s = d[0].ToString();
                while (d.Read())
                {
                    s += "," + d[0].ToString();
                }
                return s;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string getSections()
        {
            return this.getSectionList("RoundData");
        }


        public string sectionsForHandRecords()
        {
            return this.getSectionList("HandRecord");
        }


        internal static void setAppLocation(string appPath)
        {
            applicationPath = appPath;
        }

        public void runBCS()
        {
            string app = applicationPath + "BMPro.exe";
            string param = "";
            param += " /f[" + filename + " ]";
            param += " /s";
            param += " /r";
            //param += " /m";
            param += " /t2";

            string sections = sectionsForHandRecords();
            if (sections != null)
                param += " /h:[" + sections + "]"; // upload rozkladow
            System.Diagnostics.Process.Start(app, param);
        }

        public void convert()
        {
            List<Setting> settings = new List<Setting>();
            settings.Add(new Setting("BM2ConfirmNP", "bit", "true"));
            settings.Add(new Setting("BM2RemainingBoards", "bit", "false"));
            settings.Add(new Setting("BM2NextSeatings", "bit", "true"));
            settings.Add(new Setting("BM2ScoreRecap", "bit", "false"));
            settings.Add(new Setting("BM2AutoShowScoreRecap", "bit", "false"));
            settings.Add(new Setting("BM2ScoreCorrection", "bit", "false"));
            settings.Add(new Setting("BM2AutoBoardNumber", "bit", "false"));
            settings.Add(new Setting("BM2ResultsOverview", "integer", "1"));
            settings.Add(new Setting("BM2ResetFunctionKey", "bit", "false"));
            settings.Add(new Setting("BM2ViewHandrecord", "bit", "false"));
            settings.Add(new Setting("BM2RecordBidding", "bit", "false"));
            settings.Add(new Setting("BM2RecordPlay", "bit", "false"));
            settings.Add(new Setting("BM2ValidateLeadCard", "bit", "false"));
            settings.Add(new Setting("BM2ShowPlayerNames", "integer", "0"));

            foreach (Setting s in settings)
            {
                s.createField(sql, false);
            }

            List<Setting> defaultSettings = new List<Setting>();
            defaultSettings.Add(new Setting("BM2PINcode", "text(4)", "'5431'"));
            defaultSettings.Add(new Setting("BM2Ranking", "integer", "0"));
            defaultSettings.Add(new Setting("BM2GameSummary", "bit", "false"));
            defaultSettings.Add(new Setting("BM2SummaryPoints", "integer", "0"));
            defaultSettings.Add(new Setting("BM2PairNumberEntry", "integer", "0"));
            defaultSettings.Add(new Setting("BM2ShowHands", "bit", "false"));
            defaultSettings.Add(new Setting("BM2NumberValidation", "integer", "0"));
            defaultSettings.Add(new Setting("BM2NameSource", "integer", "2"));
            defaultSettings.Add(new Setting("BM2EnterHandrecord", "bit", "false"));
            defaultSettings.Add(new Setting("BM2NumberEntryEachRound", "integer", "0"));
            defaultSettings.Add(new Setting("BM2NumberEntryPreloadValues", "integer", "0"));
            defaultSettings.Add(new Setting("Name", "text(18)", "''", "PlayerNumbers"));
            defaultSettings.Add(new Setting("Updated", "bit", "false", "PlayerNumbers"));
            defaultSettings.Add(new Setting("`Section`", "integer", "1"));

            foreach (Setting s in defaultSettings)
            {
                s.createField(sql);
            }

            this.convertSettingsPerSection();

            try
            {
                sql.query("ALTER TABLE Tables ADD COLUMN `Group` integer;");
            }
            catch (OleDbException)
            {
            } 
            
            try
            {
                sql.query("CREATE TABLE PlayerNames (ID integer, Name text(18));");
            }
            catch (OleDbException)
            {
            }

            try
            {
                sql.query("CREATE TABLE HandRecord (`Section` integer, `Board` integer, "
                    + "NorthSpades text(13),NorthHearts text(13),NorthDiamonds text(13),NorthClubs text(13),"
                    + "EastSpades text(13),EastHearts text(13),EastDiamonds text(13),EastClubs text(13),"
                    + "SouthSpades text(13),SouthHearts text(13),SouthDiamonds text(13),SouthClubs text(13),"
                    + "WestSpades text(13),WestHearts text(13),WestDiamonds text(13),WestClubs text(13)"
                    + ");");
            }
            catch (OleDbException)
            {
            }
            try
            {
                sql.query("CREATE TABLE HandEvaluation (`Section` integer, `Board` integer, "
                    + "NorthSpades integer,NorthHearts integer,NorthDiamonds integer,NorthClubs integer,NorthNotrump integer,"
                    + "EastSpades integer,EastHearts integer,EastDiamonds integer,EastClubs integer,EastNotrump integer,"
                    + "SouthSpades integer,SouthHearts integer,SouthDiamonds integer,SouthClubs integer,SouthNotrump integer,"
                    + "WestSpades integer,WestHearts integer,WestDiamonds integer,WestClubs integer,WestNotrump integer,"
                    + "NorthHcp integer,EastHcp integer,SouthHcp integer,WestHcp integer"
                    + ");");
            }
            catch (OleDbException)
            {
            }
            try
            {
                sql.query("CREATE TABLE PlayData ("
                    + "`ID` autoincrement, `Section` integer, `Table` integer, `Round` integer, `Board` integer,"
                    + "`Counter` integer, `Direction` text(2), `Card` text(10), `DateLog` datetime,"
                    + "`TimeLog` datetime, `Erased` bit"
                    + ");");
            }
            catch (OleDbException)
            {
            }
            try
            {
                sql.query("CREATE TABLE BiddingData ("
                    + "`ID` autoincrement, `Section` integer, `Table` integer, `Round` integer, `Board` integer,"
                    + "`Counter` integer, `Direction` text(2), `Bid` text(10), `DateLog` datetime,"
                    + "`TimeLog` datetime, `Erased` bit"
                    + ");");
            }
            catch (OleDbException)
            {
            }
        }

        private void convertSettingsPerSection()
        {
            string sectionString = this.getSections();
            string[] sections = sectionString.Split(',');
            OleDbDataReader defaultSettings = sql.select("SELECT * FROM `Settings`");
            if (defaultSettings.Read())
            {
                object[] values = new object[100];
                int columns = defaultSettings.GetValues(values);
                Dictionary<string, object> objects = new Dictionary<string, object>();
                for (int i = 0; i < columns; i++)
                {
                    objects.Add(defaultSettings.GetName(i), values[i]);
                }
                defaultSettings.Close();
                foreach (string section in sections)
                {
                    try
                    {
                        string sectionData = sql.selectOne("SELECT `Section` FROM `Settings` WHERE `Section` = " + section, true);
                    }
                    catch (OleDbRowMissingException e)
                    {
                        objects["Section"] = section;
                        sql.insert("Settings", objects);
                    }
                }
                sql.query("DELETE FROM `Settings` WHERE `Section` NOT IN (" + sectionString + ")");
            }
        }

        public void updateSettings()
        {
            sql.query("UPDATE Tables SET UpdateFromRound=997;");
        }

        public void loadSettings()
        {
            main.startLoading();
            if (settings == null)
            {
                main.stopLoading();
                return;
            }
            main.lFirstSectorSettings.Visible = false;
            string section = "*".Equals(main.cbSettingsSection.Text.Trim()) ? null : this.sectorLetterToNumber(main.cbSettingsSection.Text.Trim()).ToString();
            StringBuilder errors = new StringBuilder();
            foreach (Setting s in settings)
            {
                try
                {
                    s.load(section);
                }
                catch (OleDbException)
                {
                    if (errors.Length > 0) errors.Append(", ");
                    errors.Append(s.name);
                }
            }
            main.xShowContract.Checked = (Setting.load("ShowContract", this, errors, section) == "0");
            string playerNames = Setting.load("BM2ShowPlayerNames", this, errors, section);
            main.xShowPlayerNames.Checked = !("".Equals(playerNames) || "0".Equals(playerNames));
            main.xPINcode.Text = Setting.load("BM2PINcode", this, errors, section);
            int resultsOverview = 0;
            int.TryParse(Setting.load("BM2ResultsOverview", this, errors, section), out resultsOverview);
            main.xResultsOverview.SelectedIndex = resultsOverview;
            main.xGroupSections.Checked = this.getSectionGroupCount() <= 1;

            if (section == null && main.cbSettingsSection.Items.Count > 2)
            {
                main.lFirstSectorSettings.Visible = true;
                this.sectionGroupWarning();
            }

            if (errors.Length > 0)
            {
                MessageBox.Show("Nie można uzyskać dostępu do pól: \n" + errors.ToString() + ".\nPrawdopodobnie te pola nie istnieją.",
                    "Brakuje pól w tabeli Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            main.stopLoading();
        }

        public void sectionGroupWarning()
        {
            main.lGroupSectionsWarning.Visible = false;
            if (main.xShowResults.Checked)
            {
                main.lGroupSectionsWarning.Visible = true;
            }
        }

        private int getSectionGroupCount()
        {
            OleDbDataReader rows = sql.select("SELECT DISTINCT `Group` FROM Tables");
            int count = 0;
            while (rows.Read())
            {
                count++;
            }
            return count;
        }

        public void saveSettings()
        {
            string section = "*".Equals(main.cbSettingsSection.Text.Trim()) ? null : this.sectorLetterToNumber(main.cbSettingsSection.Text.Trim()).ToString();
            StringBuilder errors = new StringBuilder();
            foreach (Setting s in settings)
            {
                try
                {
                    s.save(section);
                }
                catch (OleDbException)
                {
                    if (errors.Length > 0) errors.Append(", ");
                    errors.Append(s.name);
                }
            }
            Setting.save("ShowContract", main.xShowContract.Checked ? "0" : "1", this, errors, section);
            Setting.save("BM2ShowPlayerNames", main.xShowPlayerNames.Checked ? "1" : "0", this, errors, section);
            Setting.save("BM2NameSource", "2", this, errors, section);
            Setting.save("BM2PINcode", "'" + main.xPINcode.Text + "'", this, errors, section);
            Setting.save("BM2ResultsOverview", main.xResultsOverview.SelectedIndex.ToString(), this, errors, section);
            if (main.xGroupSections.Checked)
            {
                sql.query("UPDATE Tables SET `Group` = 1;");
            }
            else
            {
                sql.query("UPDATE Tables SET `Group` = `Section`;"); 
            }

            this.loadSettings();
        }

        private int updateName(string section, string table, string direction, string name)
        {
            name = Common.bezOgonkow(name);
            if (name.Length > 18)
                name = name.Substring(0, 18);
            try
            {
                string actual = sql.selectOne("SELECT Name FROM PlayerNumbers WHERE `Section`=" + section + " AND `Table`=" + table
                    + " AND `Direction`='" + direction + "'", true);
                if (actual != name)
                {
                    sql.query("UPDATE PlayerNumbers SET Name='" + name + "', Updated=TRUE WHERE `Section`=" + section + " AND `Table`=" + table
                    + " AND `Direction`='" + direction + "'");
                    return 1;
                }
                else return 0;
            }
            catch (OleDbRowMissingException)
            {
                sql.query("INSERT INTO PlayerNumbers(`Section`, `Table`, Direction, Name, Updated) VALUES(" 
                    + section + ", " + table + ", '" + direction + "', '" + name + "', TRUE)");
                return 1;
            }
        }

        private int getBWSNumber(OleDbDataReader reader, int index)
        {
            switch (Type.GetTypeCode(reader.GetFieldType(index)))
            {
                case TypeCode.Int16:
                    return reader.GetInt16(index);
                case TypeCode.Int32:
                    return reader.GetInt32(index);
            }
            throw new InvalidCastException("Unable to read numeric value from BWS field");
        }

        public void syncNames(Tournament tournament, bool interactive, string section, DataGridView grid)
        {
            int count = 0, countNew = 0, SKOK_STOLOW = Convert.ToInt32(main.numTeamsTableOffset.Value);
            OleDbDataReader roundsReader = sql.select("SELECT `Section`, MIN(`Round`) FROM RoundData WHERE LowBoard > 0 GROUP BY `Section`;");
            Dictionary<int, int> firstRounds = new Dictionary<int, int>();
            while (roundsReader.Read())
            {
                firstRounds.Add(this.getBWSNumber(roundsReader, 0), this.getBWSNumber(roundsReader, 1));
            }
            roundsReader.Close();
            if (firstRounds.Count == 0)
            {
                MessageBox.Show("W BWSie nie ma danych rund!", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StringBuilder pairsQuery = new StringBuilder("SELECT `Section`, `Table`, NSPair, EWPair FROM RoundData WHERE (");
            List<string> roundQueries = new List<string>();
            foreach (KeyValuePair<int, int> firstRound in firstRounds)
            {
                StringBuilder roundQuery = new StringBuilder("(`Round` = ");
                roundQuery.Append(firstRound.Value);
                roundQuery.Append(" AND `Section` = ");
                roundQuery.Append(firstRound.Key);
                roundQuery.Append(")");
                roundQueries.Add(roundQuery.ToString());
            }
            pairsQuery.Append(String.Join(" OR ", roundQueries.ToArray()));
            pairsQuery.Append(")");
            if (tournament.type == Tournament.TYPE_TEAMY)
            {
                pairsQuery.Append(" AND `Table` <= ");
                pairsQuery.Append(SKOK_STOLOW);
            }
            pairsQuery.Append(";");

            OleDbDataReader d;
            d = sql.select(pairsQuery.ToString());

            Dictionary<int, List<int>> sectionPairs = new Dictionary<int, List<int>>();
            Dictionary<int, List<PairPosition>> pairs = new Dictionary<int, List<PairPosition>>();
            while (d.Read())
            {
                int sectionNumber = this.getBWSNumber(d, 0);
                int tableNumber = this.getBWSNumber(d, 1);
                int nsPairNumber = this.getBWSNumber(d, 2);
                int ewPairNumber = this.getBWSNumber(d, 3);
                if (!sectionPairs.ContainsKey(sectionNumber))
                {
                    sectionPairs.Add(sectionNumber, new List<int>());
                }
                sectionPairs[sectionNumber].Add(nsPairNumber);
                sectionPairs[sectionNumber].Add(ewPairNumber);
                if (!pairs.ContainsKey(sectionNumber))
                {
                    pairs.Add(sectionNumber, new List<PairPosition>());
                }
                pairs[sectionNumber].Add(new PairPosition { pairNo = nsPairNumber, position = "NS", table = tableNumber });
                pairs[sectionNumber].Add(new PairPosition { pairNo = ewPairNumber, position = "EW", table = tableNumber });
            }
            d.Close();

            Dictionary<int, List<String>> names = tournament.getBWSNames(grid);

            Dictionary<int, List<int>> usedSections = new Dictionary<int, List<int>>();
            List<int> extraPairs = new List<int>();
            foreach (KeyValuePair<int, List<String>> pair in names)
            {
                bool foundInBWS = false;
                foreach (KeyValuePair<int, List<int>> pairsInSection in sectionPairs)
                {
                    if (pairsInSection.Value.Contains(pair.Key))
                    {
                        if (!usedSections.ContainsKey(pairsInSection.Key))
                        {
                            usedSections.Add(pairsInSection.Key, new List<int>());
                        }
                        usedSections[pairsInSection.Key].Add(pair.Key);
                        foundInBWS = true;
                    }
                }
                if (!foundInBWS) {
                    extraPairs.Add(pair.Key);
                }
            }

            if (interactive) {
                List<string> warnings = new List<string>();
                foreach (KeyValuePair<int, List<int>> sectionData in sectionPairs)
                {
                    if (this.sectorNumberToLetter(sectionData.Key).Equals(section) || "*".Equals(section))
                    {
                        if (!usedSections.ContainsKey(sectionData.Key))
                        {
                            warnings.Add(" - w turnieju nie ma par dla sektora " + this.sectorNumberToLetter(sectionData.Key));
                        }
                        else
                        {
                            List<int> missingPairs = new List<int>();
                            foreach (int pair in sectionData.Value)
                            {
                                if (!usedSections[sectionData.Key].Contains(pair))
                                {
                                    missingPairs.Add(pair);
                                }
                            }
                            if (missingPairs.Count > 0)
                            {
                                StringBuilder warning = new StringBuilder(" - w sektorze ");
                                warning.Append(this.sectorNumberToLetter(sectionData.Key));
                                warning.Append(" brakuje ");
                                warning.Append(missingPairs.Count);
                                warning.Append(" par:");
                                foreach (int pair in missingPairs)
                                {
                                    warning.Append(' ');
                                    warning.Append(pair);
                                }
                                warnings.Add(warning.ToString());
                            }
                        }
                    }
                }
                if (extraPairs.Count > 0)
                {
                    StringBuilder warning = new StringBuilder(" - w BWS nie ma w ogóle ");
                    warning.Append(extraPairs.Count);
                    warning.Append(" par:");
                    foreach (int pair in extraPairs)
                    {
                        warning.Append(' ');
                        warning.Append(pair);
                    }
                    warnings.Add(warning.ToString());
                }

                if (warnings.Count > 0)
                {
                    DialogResult warningDialog = MessageBox.Show("Wykryto potencjalne problemy z wczytaniem nazwisk: \n\n" + String.Join("\n", warnings.ToArray()) + "\n\nCzy chcesz wczytać nazwiska mimo wszystko?", "Problemy z nazwiskami", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (warningDialog == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            try
            {
                int sectionNumber = 0;
                if (!"*".Equals(section)) {
                    sectionNumber = this.sectorLetterToNumber(section);
                }
                char[] seatMapping = { 'N', 'S', 'E', 'W' };
                foreach (KeyValuePair<int, List<int>> sections in usedSections) {
                    if ("*".Equals(section) || sectionNumber == sections.Key) {
                        foreach (int pairNumber in sections.Value) {
                            PairPosition pair = pairs[sections.Key].Find(delegate(PairPosition p) { return p.pairNo == pairNumber; });
                            for (int i = 0; i < names[pair.pairNo].Count; i++) {
                                countNew += this.updateName(sections.Key.ToString(), pair.table.ToString(), pair.position[i].ToString(), names[pair.pairNo][i]);
                                if (tournament.type == Tournament.TYPE_TEAMY)
                                {
                                    char otherTableSeat = seatMapping[(Array.IndexOf(seatMapping, pair.position[i]) + 2) % 4];
                                    countNew += this.updateName(sections.Key.ToString(), (pair.table + SKOK_STOLOW).ToString(), otherTableSeat.ToString(), names[pair.pairNo][i]);
                                }
                            }
                            count += names[pair.pairNo].Count * ((tournament.type == Tournament.TYPE_TEAMY) ? 2 : 1);
                        }
                    }
                }
                StringBuilder errors = new StringBuilder();
                List<Setting> settings = new List<Setting>();
                settings.Add(new Setting("BM2NumberEntryEachRound", "integer", (tournament.type == Tournament.TYPE_TEAMY) ? "1" : "0"));
                settings.Add(new Setting("BM2NumberEntryPreloadValues", "integer", "1"));
                foreach (Setting s in settings)
                {
                    s.createField(sql);
                    Setting.save(s.name, s.defaultStr, this, errors);
                }
                if (interactive)
                {
                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString(), "Błąd ustawiania opcji BWS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    MessageBox.Show("Synchronizacja zakończona!\nPrzejrzanych nazwisk: " + count + "\nZmienionych: " + countNew,
                        "Synchronizacja nazwisk", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (sql.selectOne("SELECT BM2ShowPlayerNames FROM Settings") != "1")
                        MessageBox.Show("Pamiętaj żeby włączyć opcję \"pokazuj nazwiska\"!", "Brakujące ustawienie",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {
                if (interactive)
                {
                    MessageBox.Show(ee.Message, "Błąd wczytywania nazwisk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int getBoard(string function, string sector)
        {
            sector = sector.Trim();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append(function);
            query.Append(" FROM RoundData WHERE lowBoard > 0");
            if (sector.Length > 0)
            {
                query.Append(" AND `Section` IN(");
                query.Append(sector);
                query.Append(")");
            }
            string s = sql.selectOne(query.ToString());
            int i;
            if (int.TryParse(s, out i)) return i;
            else return 0;
        }

        public int lowBoard(string sector = "")
        {
            return this.getBoard("MIN(lowBoard)", sector);
        }

        public int highBoard(string sector = "")
        {
            return this.getBoard("MAX(highBoard)", sector);
        }

        public int highSection()
        {
            string s = sql.selectOne("SELECT max(`Section`) FROM `Tables`");
            int i;
            if (int.TryParse(s, out i)) return i;
            else return 0;
        }

        public int lowSection()
        {
            string s = sql.selectOne("SELECT min(`Section`) FROM `Tables`");
            int i;
            if (int.TryParse(s, out i)) return i;
            else return 0;
        }

        private void clearRecords(string section)
        {
            sql.query("DELETE FROM HandRecord WHERE `Section` = " + section);
            sql.query("DELETE FROM HandEvaluation WHERE `Section` = " + section);
        }

        public void clearHandRecords()
        {
            string sections = this.sectionsForHandRecords();
            if (sections != null)
            {
                string[] sectionLetters = sections.Split(',');
                for (int i = 0; i < sectionLetters.Length; i++)
                {
                    sectionLetters[i] = sectionLetters[i].Trim();
                }
                foreach (string section in sectionLetters)
                {
                    this.clearRecords(section);
                }
                this.displayHandRecordInfo(this.loadSectionBoards(sectionLetters));
            }
        }

        public int loadHandRecords(PBN pbn)
        {
            int count = 0;
            string[] sections = this.getSelectedSections();
            Dictionary<int, List<string>> boards = new Dictionary<int, List<string>>();
            foreach (string section in sections)
            {
                this.clearRecords(section);
                for (int i = this.lowBoard(section.Trim()); i <= this.highBoard(section.Trim()); i++)
                {
                    if (pbn.handRecords[i] != null)
                    {
                        HandRecord b = pbn.handRecords[i];
                        StringBuilder str = new StringBuilder(50);
                        str.Append("INSERT INTO HandRecord VALUES (");
                        str.Append(section); str.Append(",");
                        str.Append(i); str.Append(",'");
                        str.Append(String.Join("','", b.north)); str.Append("','");
                        str.Append(String.Join("','", b.east)); str.Append("','");
                        str.Append(String.Join("','", b.south)); str.Append("','");
                        str.Append(String.Join("','", b.west)); str.Append("')");
                        sql.query(str.ToString());
                        if (!boards.ContainsKey(i))
                        {
                            boards.Add(i, new List<string>());
                        }
                        boards[i].Add(this.sectorNumberToLetter(Int16.Parse(section)));
                        int[,] ddTable = pbn.ddTables[i].GetDDTable();
                        if (ddTable != null)
                        {
                            StringBuilder ddStr = new StringBuilder();
                            ddStr.Append("INSERT INTO HandEvaluation VALUES(");
                            ddStr.Append(section); ddStr.Append(",");
                            ddStr.Append(i); ddStr.Append(",");
                            for (int player = 0; player < 4; player++)
                            {
                                for (int denom = 0; denom < 5; denom++)
                                {
                                    ddStr.Append(ddTable[player, denom]);
                                    ddStr.Append(",");
                                }
                            }
                            for (int j = 0; j < 4; j++)
                            {
                                ddStr.Append(b.hpcs[j]);
                                if (j < 3)
                                {
                                    ddStr.Append(",");
                                }
                            }
                            ddStr.Append(")");
                            sql.query(ddStr.ToString());
                        }
                        count++;
                    }
                }
            }
            this.displayHandRecordInfo(this.loadSectionBoards(sections));
            return count;
        }

        internal string getMySQLDatabaseForSection()
        {
            try
            {
                string dbString = this.sql.selectOne("SELECT custom_MySQL FROM `Section` WHERE ID = 1");
                return dbString.Split(',')[3];
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        internal string detectTeamySection(string databaseName)
        {
            OleDbDataReader sections = this.sql.select("SELECT ID, custom_MySQL FROM `Section` WHERE custom_MySQL LIKE '%," + databaseName + ",%'");
            string section = null;
            while (sections.Read()) {
                string[] dbString = sections.GetString(1).Split(',');
                if (dbString[3].Trim().Equals(databaseName))
                {
                    section = this.sectorNumberToLetter(this.getBWSNumber(sections, 0));
                    break;
                }
            }
            sections.Close();
            return section;
        }
    }
}
