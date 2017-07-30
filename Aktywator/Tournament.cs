using System;
using System.Collections.Generic;
using System.Text;

namespace Aktywator
{
    abstract public class Tournament
    {
        public const int TYPE_PARY = 1;
        public const int TYPE_TEAMY = 2;
        public const int TYPE_UNKNOWN = 0;

        protected string _name;
        public string name
        {
            get { return _name; }
        }

        protected int _type; // 0-unknown, 1-Pary, 2-Teamy
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
    }
}
