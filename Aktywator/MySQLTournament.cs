using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using data = MySql.Data.MySqlClient.MySqlDataReader;

namespace Aktywator
{
    public class MySQLTournament : Tournament
    {
        public MySQL mysql;

        public MySQLTournament(string name)
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

        public static List<MySQLTournament> getTournaments()
        {
            List<MySQLTournament> list = new List<MySQLTournament>();
            MySQL c = new MySQL("");
            data dbs = c.select("SHOW DATABASES;");
            while (dbs.Read())
            {
                MySQLTournament t = new MySQLTournament(dbs.GetString(0));
                if (t.type > Tournament.TYPE_UNKNOWN)
                    list.Add(t);
                t.mysql.close();
            }
            return list;
        }

        override internal void setup()
        {
            if (this.mysql != null)
            {
                this.mysql.close();
                this.mysql.connect();
            }
        }

        override internal string getName()
        {
            return this.name;
        }

        override public string getSectionsNum()
        {
            throw new NotImplementedException("Don't call this method on generic class instance");
        }

        override public string getTablesNum()
        {
            throw new NotImplementedException("Don't call this method on generic class instance");
        }

        override internal string getTypeLabel()
        {
            throw new NotImplementedException("Don't call this method on generic class instance");
        }

    }
}

