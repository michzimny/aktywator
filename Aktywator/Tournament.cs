using System;
using System.Collections.Generic;
using System.Text;

namespace Aktywator
{
    abstract public class Tournament
    {
        public const int TYPE_PARY = 1;
        public const int TYPE_TEAMY = 2;
        public const int TYPE_RRB = 3;
        public const int TYPE_UNKNOWN = 0;

        protected string _name;
        public string name
        {
            get { return _name; }
        }

        protected int _type = Tournament.TYPE_UNKNOWN; // 0-unknown, 1-Pary, 2-Teamy, 3-RRB
        public int type
        {
            get { return _type; }
        }

        abstract internal void setup();

        abstract internal string getName();

        abstract public string getSectionsNum();

        abstract public string getTablesNum();

        abstract internal string getTypeLabel();

        virtual internal Dictionary<int, List<string>> getNameList()
        {
            return new Dictionary<int, List<string>>();
        }

        virtual internal string shortenNameToBWS(string name)
        {
            if ("pauza".Equals(name.Trim()))
            {
                return " ";
            }
            else
            {
                string[] nameParts = name.Trim().Split(' ');
                if (nameParts.Length > 0)
                {
                    nameParts[0] = (nameParts[0].Length > 0) ? nameParts[0][0].ToString() : " ";
                }
                return String.Join(" ", nameParts);
            }
        }
    }
}
