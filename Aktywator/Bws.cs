using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using mydata = MySql.Data.MySqlClient.MySqlDataReader;
using data = System.Data.OleDb.OleDbDataReader;

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

        public Bws(string filename, MainForm main)
        {
            this._filename = filename;
            sql = new Sql(filename);
            this.main = main;
            string[] sections = this.getSections().Split(',');
            main.lWczytywane.Text = this.getBoardRangeText(sections);
            foreach (string section in sections)
            {
                main.cblSections.Items.Add(this.sectorNumberToLetter(Int16.Parse(section)));
            }
            for (int i = 0; i < main.cblSections.Items.Count; i++)
            {
                main.cblSections.SetItemChecked(i, true);
            }
        }

        private int sectorLetterToNumber(string sector)
        {
            return sector[0] - 'A' + 1;
        }

        private string sectorNumberToLetter(int sector)
        {
            char character = (char)('A' - 1 + sector);
            return character.ToString();
        }

        public string getBoardRangeText(string[] sectors)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Wczytywane rozkłady:");
            foreach (string sector in sectors)
            {
                sb.Append("\n      ");
                sb.Append(this.lowBoard(sector));
                sb.Append("-");
                sb.Append(this.highBoard(sector));
                sb.Append(" (sektor ");
                sb.Append(this.sectorNumberToLetter(Int16.Parse(sector)));
                sb.Append(")");
            }
            return sb.ToString();
        }

        public string[] getSelectedSections()
        {
            List<string> sections = new List<string>();
            foreach (string section in main.cblSections.CheckedItems)
            {
                sections.Add(this.sectorLetterToNumber(section).ToString());
            }
            return sections.ToArray();
        }

        public void initSettings()
        {
            settings = new List<Setting>();
            settings.Add(new Setting("ShowResults", main.xShowResults, this));
            settings.Add(new Setting("RepeatResults", main.xRepeatResults, this));
            settings.Add(new Setting("ShowPercentage", main.xShowPercentage, this));
            //settings.Add(new Setting("GroupSections", main.xGroupSections, this));
            settings.Add(new Setting("ShowPairNumbers", main.xShowPairNumbers, this));
            settings.Add(new Setting("IntermediateResults", main.xIntermediateResults, this));
            settings.Add(new Setting("ShowContract", main.xShowContract, this));
            settings.Add(new Setting("LeadCard", main.xLeadCard, this));
            settings.Add(new Setting("MemberNumbers", main.xMemberNumbers, this));
            settings.Add(new Setting("MemberNumbersNoBlankEntry", main.xMemberNumbersNoBlankEntry, this));
            settings.Add(new Setting("BoardOrderVerification", main.xBoardOrderVerification, this));
            settings.Add(new Setting("AutoShutDownBPC", main.xAutoShutDownBPC, this));
            settings.Add(new Setting("BM2ConfirmNP", main.xConfirmNP, this));
            settings.Add(new Setting("BM2RemainingBoards", main.xRemainingBoards, this));
            settings.Add(new Setting("BM2NextSeatings", main.xNextSeatings, this));
            settings.Add(new Setting("BM2ScoreRecap", main.xScoreRecap, this));
            settings.Add(new Setting("BM2AutoShowScoreRecap", main.xAutoShowScoreRecap, this));
            settings.Add(new Setting("BM2ScoreCorrection", main.xScoreCorrection, this));
            settings.Add(new Setting("BM2AutoBoardNumber", main.xAutoBoardNumber, this));
            settings.Add(new Setting("BM2ResetFunctionKey", main.xResetFunctionKey, this));
            settings.Add(new Setting("BM2ViewHandrecord", main.xViewHandrecord, this));
            settings.Add(new Setting("BM2RecordBidding", main.xCollectBidding, this));
            settings.Add(new Setting("BM2RecordPlay", main.xCollectPlay, this));
            settings.Add(new Setting("BM2ValidateLeadCard", main.xCheckLeadCard, this));
        }

        private string getSectionList(string table)
        {
            try
            {
                string s;
                data d = sql.select("SELECT DISTINCT `Section` FROM " + table + " ORDER BY 1");
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

        public void runBCS()
        {
            string app = Common.ProgramFilesx86() + "\\Bridgemate Pro\\BMPro.exe";
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

        public bool isBm2()
        {
            if (!sql.checkFieldExists("Settings", "BM2PINcode"))
                return false;
            if (!sql.checkFieldExists("PlayerNames", "Name"))
                return false;
            if (!sql.checkFieldExists("PlayerNumbers", "Name"))
                return false;
            if (!sql.checkFieldExists("Settings", "BM2ViewHandrecord"))
                return false;
            if (!sql.checkTableExists("HandRecord"))
                return false;
            if (!sql.checkTableExists("HandEvaluation"))
                return false;

            return true;
        }

        public void convert()
        {
            List<Setting> settings = new List<Setting>();
            settings.Add(new Setting("BM2PINcode", "text(4)", "'5431'"));
            settings.Add(new Setting("BM2ConfirmNP", "bit", "true"));
            settings.Add(new Setting("BM2RemainingBoards", "bit", "false"));
            settings.Add(new Setting("BM2NextSeatings", "bit", "true"));
            settings.Add(new Setting("BM2ScoreRecap", "bit", "false"));
            settings.Add(new Setting("BM2AutoShowScoreRecap", "bit", "false"));
            settings.Add(new Setting("BM2ScoreCorrection", "bit", "false"));
            settings.Add(new Setting("BM2AutoBoardNumber", "bit", "false"));
            settings.Add(new Setting("BM2ResultsOverview", "integer", "1"));
            settings.Add(new Setting("BM2ShowPlayerNames", "integer", "0"));
            settings.Add(new Setting("BM2Ranking", "integer", "0"));
            settings.Add(new Setting("BM2GameSummary", "bit", "false"));
            settings.Add(new Setting("BM2SummaryPoints", "integer", "0"));
            settings.Add(new Setting("BM2PairNumberEntry", "integer", "0"));
            settings.Add(new Setting("BM2ResetFunctionKey", "bit", "false"));
            settings.Add(new Setting("BM2ShowHands", "bit", "false"));
            settings.Add(new Setting("BM2NumberValidation", "integer", "0"));
            settings.Add(new Setting("BM2NameSource", "integer", "2"));
            settings.Add(new Setting("BM2ViewHandrecord", "bit", "false"));
            settings.Add(new Setting("BM2EnterHandrecord", "bit", "false"));
            settings.Add(new Setting("BM2RecordBidding", "bit", "false"));
            settings.Add(new Setting("BM2RecordPlay", "bit", "false"));
            settings.Add(new Setting("BM2ValidateLeadCard", "bit", "false"));

            settings.Add(new Setting("Name", "text(18)", "''", "PlayerNumbers"));
            settings.Add(new Setting("Updated", "bit", "false", "PlayerNumbers"));

            foreach (Setting s in settings)
            {
                try
                {
                    sql.query(s.getAddColumnSql());
                    sql.query(s.getSetDefaultSql());
                }
                catch (OleDbException)
                {
                }
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
            string actual = sql.selectOne("SELECT Name FROM PlayerNumbers WHERE `Section`=" + section + " AND `Table`=" + table
                + " AND `Direction`='" + direction + "'");
            if (actual != name)
            {
                sql.query("UPDATE PlayerNumbers SET Name='" + name + "', Updated=TRUE WHERE `Section`=" + section + " AND `Table`=" + table
                + " AND `Direction`='" + direction + "'");
                return 1;
            }
            else return 0;
        }

        public void syncNames(Tournament tournament, bool interactive, string startRounds)
        {
            int count = 0, countNew = 0, SKOK_STOLOW = 100;
            data d;
            startRounds = startRounds.Trim();

            if (tournament.type == 1)
            {
                if (startRounds.Length > 0)
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
                d = sql.select("SELECT `Section`, `Table`, NSPair, EWPair FROM RoundData WHERE `Table`<=100");
            }

            while (d.Read())
            {
                string section = d.GetInt32(0).ToString();
                string table = d.GetInt32(1).ToString();
                string ns = d.GetInt32(2).ToString();
                string ew = d.GetInt32(3).ToString();

                StringBuilder query = new StringBuilder();
                if (tournament.type == 1)
                {
                    query.Append("SELECT CONCAT(SUBSTR(imie,1,1),'.',nazw) name FROM zawodnicy WHERE idp=");
                    query.Append(ns);
                    query.Append(" OR idp="); 
                    query.Append(ew);
                    query.Append(" ORDER BY idp ");
                    if (int.Parse(ew) < int.Parse(ns))
                        query.Append("DESC");
                }
                else
                {
                    query.Append("SELECT fullname NAME FROM teams WHERE id=");
                    query.Append(ns);
                    query.Append(" UNION ALL SELECT ' ' UNION ALL");
                    query.Append(" SELECT fullname NAME FROM teams WHERE id=");
                    query.Append(ew);
                    query.Append(" UNION ALL SELECT ' '; ");
                }
                mydata n = tournament.mysql.select(query.ToString());

                try
                {
                    n.Read();
                    countNew += updateName(section, table, "N", n.IsDBNull(0) ? "" : n.GetString(0));
                    if (tournament.type == 2)
                        countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "E", n.IsDBNull(0) ? "" : n.GetString(0));
                    n.Read();
                    countNew += updateName(section, table, "S", n.IsDBNull(0) ? "" : n.GetString(0));
                    if (tournament.type == 2)
                        countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "W", n.IsDBNull(0) ? "" : n.GetString(0));
                    n.Read();
                    countNew += updateName(section, table, "E", n.IsDBNull(0) ? "" : n.GetString(0));
                    if (tournament.type == 2)
                        countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "N", n.IsDBNull(0) ? "" : n.GetString(0));
                    n.Read();
                    countNew += updateName(section, table, "W", n.IsDBNull(0) ? "" : n.GetString(0));
                    if (tournament.type == 2)
                        countNew += updateName(section, (int.Parse(table) + SKOK_STOLOW).ToString(), "S", n.IsDBNull(0) ? "" : n.GetString(0));

                    if (tournament.type == 1) count += 4;
                    else count += 8;
                }
                catch (MySqlException ee)
                {
                    if (interactive)
                    {
                        if (ee.ErrorCode == -2147467259)
                        {
                            DialogResult dr = MessageBox.Show("W bws-ie jest para/team (" + ns + " albo " + ew
                                + "), który nie istnieje w wybranym turnieju. Może to nie ten turniej?",
                                "Zły turniej", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                            if (dr == DialogResult.Abort) return;
                        }
                        else
                        {
                            MessageBox.Show(ee.Message, "Błąd MySQL", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                        }
                    }
                }
                try
                {
                    n.Close();
                }
                catch (Exception) { }
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

        public void loadHandRecords(PBN pbn)
        {
            foreach (string section in this.getSections().Split(','))
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
                        str.Append(b.north[0]); str.Append("','");
                        str.Append(b.north[1]); str.Append("','");
                        str.Append(b.north[2]); str.Append("','");
                        str.Append(b.north[3]); str.Append("','");
                        str.Append(b.east[0]); str.Append("','");
                        str.Append(b.east[1]); str.Append("','");
                        str.Append(b.east[2]); str.Append("','");
                        str.Append(b.east[3]); str.Append("','");
                        str.Append(b.south[0]); str.Append("','");
                        str.Append(b.south[1]); str.Append("','");
                        str.Append(b.south[2]); str.Append("','");
                        str.Append(b.south[3]); str.Append("','");
                        str.Append(b.west[0]); str.Append("','");
                        str.Append(b.west[1]); str.Append("','");
                        str.Append(b.west[2]); str.Append("','");
                        str.Append(b.west[3]); str.Append("')");
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
                    }
            }
        }
    }
}
