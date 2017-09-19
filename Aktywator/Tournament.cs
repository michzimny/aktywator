using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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

        virtual public void displayNameList(DataGridView grid)
        {
            Dictionary<int, List<string>> names = this.getNameList();
            foreach (KeyValuePair<int, List<string>> item in names) {
                if (!this.updateNameListRow(grid, item.Key, item.Value))
                {
                    this.addNameListRow(grid, item.Key, item.Value);
                }
            }
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!names.ContainsKey(Int32.Parse(row.Cells[0].Value.ToString())))
                {
                    toDelete.Add(row);
                }
            }
            foreach (DataGridViewRow r in toDelete)
            {
                grid.Rows.Remove(r);
            }
        }

        virtual internal bool updateNameListRow(DataGridView grid, int pairNumber, List<string> names)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (Int32.Parse(row.Cells[0].Value.ToString()) == pairNumber)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (!(bool)row.Cells[i].Tag)
                        {
                            row.Cells[i].Value = names[i - 1];
                            row.Cells[i].Tag = false;
                            row.Cells[i].Style.BackColor = Color.White;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        virtual internal void addNameListRow(DataGridView grid, int pairNumber, List<string> names)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell());
            row.Cells[0].Value = pairNumber.ToString();
            foreach (string name in names)
            {
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = name;
                cell.Tag = false;
                row.Cells.Add(cell);
            }
            grid.Rows.Add(row);
        }

        virtual internal void clearCellLocks(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                for (int i = 1; i < 3; i++)
                {
                    row.Cells[i].Tag = false;
                    row.Cells[i].Style.BackColor = Color.White;
                }
            }
        }

        virtual internal string shortenNameToBWS(string name)
        {
            name = Common.bezOgonkow(name);
            if ("pauza".Equals(name.Trim()))
            {
                return " ";
            }
            else
            {
                if (this._type != Tournament.TYPE_TEAMY || MainForm.teamNames.arePlayerNamesDisplayed())
                {
                    string[] nameParts = name.Trim().Split(' ');
                    if (nameParts.Length > 0)
                    {
                        nameParts[0] = (nameParts[0].Length > 0) ? nameParts[0][0].ToString() : " ";
                    }
                    name = String.Join(" ", nameParts);
                }
                if (name.Length > 18)
                {
                    name = name.Substring(0, 18);
                }
                return name;
            }
        }

        virtual public Dictionary<int, List<string>> getBWSNames(DataGridView grid)
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                List<string> names = new List<string>();
                for (int i = 1; i < 3; i++)
                {
                    names.Add(this.shortenNameToBWS(row.Cells[i].Value.ToString()));
                }
                dict.Add(Int32.Parse(row.Cells[0].Value.ToString()), names);
            }
            return dict;
        }


    }
}
