using System;
using System.Collections.Generic;
using System.Text;

namespace Aktywator
{
    class TeamyTournament : MySQLTournament
    {
        public TeamyTournament(string name)
            : base(name)
        {
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

    }
}
