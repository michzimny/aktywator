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
                names.Add(dbData.IsDBNull(1) ? " " : dbData.GetString(1));
                names.Add(" ");
                teams.Add(dbData.GetInt32(0), names);
            }
            dbData.Close();
            return teams;
        }

        private int rounds = 0;
        internal int getRoundsNum()
        {
            if (this.rounds == 0)
            {
                this.rounds = Int32.Parse(this.mysql.selectOne("SELECT roundcnt FROM admin"));
            }
            return this.rounds;
        }

        private int segments = 0;
        internal int getSegmentsNum()
        {
            if (this.segments == 0)
            {
                this.segments = Int32.Parse(this.mysql.selectOne("SELECT segmentsperround FROM admin"));
            }
            return this.segments;
        }

        internal List<int> getCurrentSegment()
        {
            MySqlDataReader finished = this.mysql.select("SELECT rnd, segm FROM admin");
            List<int> segment = new List<int>();
            finished.Read();
            segment.Add(finished.GetInt32(0));
            segment.Add(finished.GetInt32(1));
            segment[1]++;
            if (segment[1] > this.getSegmentsNum()) {
                segment[0]++;
                if (segment[0] > this.getRoundsNum())
                {
                    segment[0] = this.getRoundsNum();
                    segment[1] = this.getSegmentsNum();
                }
            }
            finished.Close();
            return segment;
        }
    }
}
