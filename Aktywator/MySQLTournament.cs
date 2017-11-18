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

        public MySQLTournament(string name, int type)
        {
            this._name = name;
            this._type = type;
            if (this._type < Tournament.TYPE_UNKNOWN || this._type > Tournament.TYPE_RRB)
            {
                this._type = Tournament.TYPE_UNKNOWN;
            }
            mysql = new MySQL(name);
        }

        public override string ToString()
        {
            return this.name + " [" + (this.type == Tournament.TYPE_PARY ? 'P' : 'T') + "]";
        }

        public static List<MySQLTournament> getTournaments()
        {
            List<MySQLTournament> list = new List<MySQLTournament>();
            MySQL c = new MySQL("");
            data dbs = c.select("SELECT TABLE_SCHEMA, COLUMN_NAME FROM information_schema.COLUMNS WHERE TABLE_NAME = 'admin' AND COLUMN_NAME IN ('dnazwa', 'teamcnt') ORDER BY TABLE_SCHEMA;");
            while (dbs.Read())
            {
                list.Add(new MySQLTournament(dbs.GetString(0), "dnazwa".Equals(dbs.GetString(1)) ? Tournament.TYPE_PARY : Tournament.TYPE_TEAMY));
            }
            dbs.Close();
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

