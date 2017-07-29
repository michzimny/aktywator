using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using data = MySql.Data.MySqlClient.MySqlDataReader;

namespace Aktywator
{
    public class Tournament
    {
        public const int TYPE_PARY = 1;
        public const int TYPE_TEAMY = 2;
        public const int TYPE_UNKNOWN = 0;

        private string _name;
        public string name
        {
            get { return _name; }
        }

        private int _type; // 0-unknown, 1-Pary, 2-Teamy
        public int type
        {
            get { return _type; }
        }

        public MySQL mysql;

        public Tournament(string name)
        {
            this._name = name;
            mysql = new MySQL(name);
            recognizeType();
        }

        private void recognizeType()
        {
            if ((mysql.selectOne("SHOW TABLES LIKE 'admin'") == "admin")
                    && (mysql.selectOne("SHOW FIELDS IN admin LIKE 'dnazwa'") == "dnazwa")
                    && (mysql.selectOne("SHOW TABLES LIKE 'zawodnicy'") == "zawodnicy"))
                _type = Tournament.TYPE_PARY;
            else if ((mysql.selectOne("SHOW TABLES LIKE 'admin'") == "admin")
                    && (mysql.selectOne("SHOW FIELDS IN admin LIKE 'teamcnt'") == "teamcnt")
                    && (mysql.selectOne("SHOW TABLES LIKE 'players'") == "players"))
                _type = Tournament.TYPE_TEAMY;
            else _type = Tournament.TYPE_UNKNOWN;
        }

        public override string ToString()
        {
            return this.name + " [" + (this.type == Tournament.TYPE_PARY ? 'P' : 'T') + "]";
        }

        public static List<Tournament> getTournaments()
        {
            List<Tournament> list = new List<Tournament>();
            MySQL c = new MySQL("");
            data dbs = c.select("SHOW DATABASES;");
            while (dbs.Read())
            {
                Tournament t = new Tournament(dbs.GetString(0));
                if (t.type > Tournament.TYPE_UNKNOWN)
                    list.Add(t);
                t.mysql.close();
            }
            return list;
        }

        public string getSectionsNum()
        {
            if (type == Tournament.TYPE_PARY)
                return mysql.selectOne("SELECT COUNT(DISTINCT seknum) FROM sektory;");
            else 
                return "1";
        }

        public string getTablesNum()
        {
            if (type == Tournament.TYPE_PARY)
                return mysql.selectOne("SELECT COUNT(*) FROM sektory;");
            else
                return mysql.selectOne("SELECT teamcnt FROM admin;");
        }


        internal void setup()
        {
            if (this.mysql != null)
            {
                this.mysql.close();
                this.mysql.connect();
            }
        }

        internal string getName()
        {
            return this.name;
        }

        internal string getTypeLabel()
        {
            return this._type == Tournament.TYPE_PARY ? "Pary" : "Teamy";
        }
    }
}
