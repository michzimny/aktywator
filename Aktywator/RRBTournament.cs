using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Aktywator
{
    class RRBTournament : Tournament
    {
        private XmlDocument _xml;

        public RRBTournament(string name)
        {
            this._name = name;
            this._type = Tournament.TYPE_RRB;
        }

        override internal void setup()
        {
            this._xml = new XmlDocument();
            this._xml.Load(this._name);
        }

        override internal string getName()
        {
            string tName = this._xml.SelectSingleNode("//ustawienia/nazwa").InnerText.Trim();
            return tName.Length > 0 ? tName : Path.GetFileName(this._name);
        }

        override public string getSectionsNum()
        {
            List<string> sections = new List<string>();
            foreach (XmlNode table in this._xml.SelectNodes("//monitor/stoly/stol"))
            {
                string section = table.SelectSingleNode("sektor").InnerText;
                if (!sections.Contains(section))
                {
                    sections.Add(section);
                }
            }
            return sections.Count.ToString();
        }

        override public string getTablesNum()
        {
            return this._xml.SelectNodes("//monitor/stoly/stol").Count.ToString();
        }

        override internal string getTypeLabel()
        {
            return "RRBridge";
        }

        override internal Dictionary<int, List<string>> getNameList()
        {
            this._xml.Load(this._name);
            Dictionary<int, List<string>> names = new Dictionary<int, List<string>>();
            foreach (XmlNode pair in this._xml.SelectNodes("//lista/para"))
            {
                int pairNo = Int32.Parse(pair.SelectSingleNode("numer").InnerText);
                names.Add(pairNo, new List<string>());
                foreach (XmlNode player in pair.SelectNodes("gracz/nazwisko"))
                {
                    if ("pauza".Equals(player.InnerText.Trim()))
                    {
                        names[pairNo].Add(" ");
                    }
                    else
                    {
                        string[] name = player.InnerText.Trim().Split(' ');
                        if (name.Length > 0)
                        {
                            name[0] = (name[0].Length > 0) ? name[0][0].ToString() : " ";
                        }
                        names[pairNo].Add(String.Join(" ", name));
                    }
                }
            }

            foreach (KeyValuePair<int, List<string>> pair in names)
            {
                while (pair.Value.Count < 2)
                {
                    pair.Value.Add(" ");
                }
            }
            return names;
        }
    }
}
