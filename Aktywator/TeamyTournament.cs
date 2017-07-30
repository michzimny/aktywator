using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Aktywator
{
    class TeamyTournament : MySQLTournament
    {
        public TeamyTournament(string name)
            : base(name)
        {
            this._type = Tournament.TYPE_TEAMY;
        }

        override internal string getTypeLabel()
        {
            return "Teamy";
        }

        override public string getSectionsNum()
        {
            return "1";
        }

        override public string getTablesNum()
        {
            return this.mysql.selectOne("SELECT teamcnt FROM admin;");
        }

        override internal Dictionary<int, List<string>> getNameList()
        {
            Dictionary<int, List<String>> teams = new Dictionary<int, List<string>>();
            MySqlDataReader dbData = this.mysql.select("SELECT id, fullname NAME FROM teams");
            while (dbData.Read())
            {
                List<string> names = new List<string>();
                names.Add(dbData.IsDBNull(1) ? "" : dbData.GetString(1));
                names.Add("");
                teams.Add(dbData.GetInt32(0), names);
            }
            dbData.Close();
            return teams;
        }

    }
}
