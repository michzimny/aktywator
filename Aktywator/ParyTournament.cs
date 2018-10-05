using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Aktywator
{
    class ParyTournament: MySQLTournament
    {
        private bool _indy = false;

        public ParyTournament(string name, int type = Tournament.TYPE_PARY)
            : base(name, type)
        {
            this._type = Tournament.TYPE_PARY;
            this._indy = this.isIndy();
        }

        override internal string getTypeLabel()
        {
            string label = "Pary";
            if (this._indy)
            {
                label += " (indywiduel)";
                MessageBox.Show(
                    "Nazwiska w turnieju indywidualnym są wyświetlane PARAMI, według rozstawienia w pierwszej rundzie.\n" + 
                    "Używać TYLKO dla turniejów typu Finał GPPP ze stałym skojarzeniem par!",
                    "Nazwiska w turnieju indywidualnym", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return label;
        }

        private bool isIndy()
        {
            this.setup();
            bool pary;
            Boolean.TryParse(this.mysql.selectOne("SELECT pary FROM admin;"), out pary);
            return !pary;
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
            string query = this._indy ? 
                "SELECT pairs.pair, CONCAT(zawodnicy.imie, ' ', zawodnicy.nazw) name FROM ( " +
                "SELECT zN player, zN pair, 0 in_pair FROM zapisy WHERE rnd = 1 GROUP BY zN UNION " +
                "SELECT zS player, zN pair, 1 in_pair FROM zapisy WHERE rnd = 1 GROUP BY zN UNION " +
                "SELECT zE player, zE pair, 0 in_pair FROM zapisy WHERE rnd = 1 GROUP BY zN UNION " +
                "SELECT zW player, zE pair, 1 in_pair FROM zapisy WHERE rnd = 1 GROUP BY zN " +
                ") pairs JOIN zawodnicy ON pairs.player = zawodnicy.id ORDER BY pairs.pair, pairs.in_pair;" : 
                "SELECT idp, CONCAT(imie, ' ', nazw) name FROM zawodnicy ORDER BY idp";
            MySqlDataReader dbData = this.mysql.select(query);
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
