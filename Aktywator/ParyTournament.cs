using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Aktywator
{
    class ParyTournament: MySQLTournament
    {
        public ParyTournament(string name)
            : base(name)
        {
            this._type = Tournament.TYPE_PARY;
        }

        override internal string getTypeLabel()
        {
            return "Pary";
        }

        override public string getSectionsNum()
        {
            return this.mysql.selectOne("SELECT COUNT(DISTINCT seknum) FROM sektory;");
        }

        override public string getTablesNum()
        {
            return this.mysql.selectOne("SELECT COUNT(*) FROM sektory;");
        }

        override internal Dictionary<int, List<string>> getNameList()
        {
            Dictionary<int, List<String>> pairs = new Dictionary<int, List<string>>();
            MySqlDataReader dbData = this.mysql.select("SELECT idp, CONCAT(imie, ' ', nazw) name FROM zawodnicy");
            while (dbData.Read())
            {
                int pairNo = dbData.GetInt32(0);
                if (!pairs.ContainsKey(pairNo))
                {
                    pairs.Add(pairNo, new List<string>());
                }
                pairs[pairNo].Add(dbData.IsDBNull(1) ? " " : dbData.GetString(1));
            }
            foreach (KeyValuePair<int, List<string>> pair in pairs)
            {
                while (pair.Value.Count < 2)
                {
                    pair.Value.Add(" ");
                }
            }
            dbData.Close();
            return pairs;
        }

    }
}
