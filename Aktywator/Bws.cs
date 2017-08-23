using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

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

        private class SectionCheckBox
        {
            private string section;
            private string label;

            public SectionCheckBox(string section, string label)
            {
                this.section = section;
                this.label = label;
            }

            override public string ToString()
            {
                return this.label;
            }

            public string getSection()
            {
                return this.section;
            }
        }

        public Bws(string filename, MainForm main)
        {
            this._filename = filename;
            sql = new Sql(filename);
            this.main = main;
            string[] sections = this.getSections().Split(',');
            foreach (string section in sections)
            {
                SectionCheckBox item = new SectionCheckBox(section, "sektor " + this.sectorNumberToLetter(Int16.Parse(section)) + " (rozdania " + this.lowBoard(section) + "-" + this.highBoard(section) + ")");
                main.cblSections.Items.Add(item);
            }
            for (int i = 0; i < main.cblSections.Items.Count; i++)
            {
                main.cblSections.SetItemChecked(i, true);
            }
        }

        private int sectorLetterToNumber(string sector)
        {
            return sector.ToUpper()[0] - 'A' + 1;
        }

        private string sectorNumberToLetter(int sector)
        {
            char character = (char)('A' - 1 + sector);
            return character.ToString();
        }

        public string[] getSelectedSections()
        {
            List<string> sections = new List<string>();
            foreach (SectionCheckBox section in main.cblSections.CheckedItems)
            {
                sections.Add(section.getSection());
            }
            return sections.ToArray();
        }

        public List<Setting> initSettings()
        {
            settings = new List<Setting>();
            settings.Add(new Setting("ShowResults", main.xShowResults, this, new Version(2, 0, 0), new Version(1, 3, 1)));
            settings.Add(new Setting("RepeatResults", main.xRepeatResults, this, null, null));
            settings.Add(new Setting("ShowPercentage", main.xShowPercentage, this, null, null));
            //settings.Add(new Setting("GroupSections", main.xGroupSections, this, null, null));
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

            foreach (Setting s in defaultSettings)
            {
                s.createField(sql);
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

        public void updateSettings()
        {
            sql.query("UPDATE Tables SET UpdateFromRound=997;");
        }

        public void loadSettings()
        {
            StringBuilder errors = new StringBuilder();
            foreach (Setting s in settings)
            {
                try
                {
                    s.load();
                }
                catch (OleDbException)
                {
                    if (errors.Length > 0) errors.Append(", ");
                    errors.Append(s.name);
                }
            }
            main.xShowContract.Checked = (Setting.load("ShowContract", this, errors) == "0");
            main.xShowPlayerNames.Checked = (Setting.load("BM2ShowPlayerNames", this, errors) != "0");
            main.xPINcode.Text = Setting.load("BM2PINcode", this, errors);
            int resultsOverview = 0;
            int.TryParse(Setting.load("BM2ResultsOverview", this, errors), out resultsOverview);
            main.xResultsOverview.SelectedIndex = resultsOverview;

            if (errors.Length > 0)
            {
                MessageBox.Show("Nie można uzyskać dostępu do pól: \n" + errors.ToString() + ".\nPrawdopodobnie te pola nie istnieją.",
                    "Brakuje pól w tabeli Settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void saveSettings()
        {
            StringBuilder errors = new StringBuilder();
            foreach (Setting s in settings)
            {
                try
                {
                    s.save();
                }
                catch (OleDbException)
                {
                    if (errors.Length > 0) errors.Append(", ");
                    errors.Append(s.name);
                }
            }
            Setting.save("ShowContract", main.xShowContract.Checked ? "0" : "1", this, errors);
            Setting.save("BM2ShowPlayerNames", main.xShowPlayerNames.Checked ? "1" : "0", this, errors);
            Setting.save("BM2NameSource", "2", this, errors);
            Setting.save("BM2PINcode", "'" + main.xPINcode.Text + "'", this, errors);
            Setting.save("BM2ResultsOverview", main.xResultsOverview.SelectedIndex.ToString(), this, errors);

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

        public void syncNames(Tournament tournament, bool interactive, string startRounds)
        {
            int count = 0, countNew = 0, SKOK_STOLOW = 100;
            OleDbDataReader d;
            startRounds = startRounds.Trim();

            if (tournament.type != Tournament.TYPE_TEAMY)
            {
                if (tournament.type == Tournament.TYPE_PARY && startRounds.Length > 0)
                {
                    d = sql.select("SELECT `Section`, `Table`, NSPair, EWPair FROM RoundData WHERE NSPair>0 AND `Round` in (" + startRounds + ")");
                }
                else
                {
                    string fromRound = sql.selectOne("SELECT min(`Round`) FROM RoundData WHERE NSPair>0");
                    d = sql.select("SELECT `Section`, `Table`, NSPair, EWPair FROM RoundData WHERE `Round`=" + fromRound);
                }
            }
            else
            {
                d = sql.select("SELECT `Section`, `Table`, NSPair, EWPair FROM RoundData WHERE `Table`<=" + SKOK_STOLOW);
            }

            try
            {
                Dictionary<int, List<String>> names = tournament.getNameList();

                while (d.Read())
                {
                    string section = this.getBWSNumber(d, 0).ToString();
                    string table = this.getBWSNumber(d, 1).ToString();
                    int ns = this.getBWSNumber(d, 2);
                    int ew = this.getBWSNumber(d, 3);

                    try
                    {
                        if (!names.ContainsKey(ns))
                        {
                            throw new KeyNotFoundException(ns.ToString());
                        }
                        countNew += updateName(section, table, "N", names[ns][0]);
                        countNew += updateName(section, table, "S", names[ns][1]);
                        count += 2;
                        if (tournament.type == Tournament.TYPE_TEAMY)
                        {
                            countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "E", names[ns][0]);
                            countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "W", names[ns][1]);
                            count += 2;
                        }
                    }
                    catch (KeyNotFoundException keyE)
                    {
                        if (interactive)
                        {
                            DialogResult dr = MessageBox.Show("W bws-ie jest para/team (" + keyE.Message + ")"
                            + ", który nie istnieje w wybranym turnieju."
                            + "Może to nie ten turniej?" + "\n\n" + "Kontynuować wczytywanie?",
                            "Zły turniej", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.No) break;
                        }
                    }
                    try
                    {
                        if (!names.ContainsKey(ew))
                        {
                            throw new KeyNotFoundException(ew.ToString());
                        }
                        countNew += updateName(section, table, "E", names[ew][0]);
                        countNew += updateName(section, table, "W", names[ew][1]);
                        count += 2;
                        if (tournament.type == Tournament.TYPE_TEAMY)
                        {
                            countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "N", names[ew][0]);
                            countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "S", names[ew][1]);
                            count += 2;
                        }
                    }
                    catch (KeyNotFoundException keyE)
                    {
                        if (interactive)
                        {
                            DialogResult dr = MessageBox.Show("W bws-ie jest para/team (" + keyE.Message + ")"
                            + ", który nie istnieje w wybranym turnieju."
                            + "Może to nie ten turniej?" + "\n\n" + "Kontynuować wczytywanie?",
                            "Zły turniej", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.No) break;
                        }
                    }
                }
                List<Setting> settings = new List<Setting>();
                settings.Add(new Setting("BM2NumberEntryEachRound", "integer", (tournament.type == Tournament.TYPE_TEAMY) ? "1" : "0"));
                settings.Add(new Setting("BM2NumberEntryPreloadValues", "integer", "1"));
                foreach (Setting s in settings)
                {
                    s.createField(sql);
                }
                if (interactive)
                {
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
                foreach (string section in this.sectionsForHandRecords().Split(','))
                {
                    this.clearRecords(section.Trim());
                }
            }
        }

        public int loadHandRecords(PBN pbn)
        {
            int count = 0;
            foreach (string section in this.getSelectedSections())
            {
                this.clearRecords(section);
                for (int i = this.lowBoard(section.Trim()); i <= this.highBoard(section.Trim()); i++)
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
            return count;
        }
    }
}
