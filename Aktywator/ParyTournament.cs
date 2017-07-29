using System;
using System.Collections.Generic;
using System.Text;

namespace Aktywator
{
    class ParyTournament: MySQLTournament
    {
        public ParyTournament(string name)
            : base(name)
        {
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

    }
}
