using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Aktywator
{
    class Setting
    {
        public string name;
        public string type;
        public string defaultStr;
        public string table;
        public CheckBox field;
        private Bws bws;
        public Version bcsV;
        public Version fwV;

        public Setting(string name, CheckBox field, Bws bws, Version bcsVersion, Version firmwareVersion)
        {
            this.name = name;
            this.field = field;
            this.bws = bws;
            this.bcsV = bcsVersion;
            this.fwV = firmwareVersion;
        }

        public void load(string section = null)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT ");
            str.Append(this.name);
            str.Append(" FROM Settings");
            if (section != null)
            {
                str.Append(" WHERE `Section` = ");
                str.Append(section);
            }
            field.Checked = false;
            string a = bws.sql.selectOne(str.ToString());
            field.Checked = a.ToUpper() == "TRUE" ? true : false;
        }

        public static string load(string name, Bws bws, StringBuilder errors, string section = null)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT ");
            str.Append(name);
            str.Append(" FROM Settings");
            if (section != null)
            {
                str.Append(" WHERE `Section` = ");
                str.Append(section);
            }
            try
            {
                return bws.sql.selectOne(str.ToString());
            }
            catch (OleDbException)
            {
                if (errors.Length > 0) errors.Append(", ");
                errors.Append(name);
                return "";
            }
        }

        public void save(string section = null)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE Settings SET ");
            str.Append(this.name);
            if (field.Checked) str.Append("=true");
            else str.Append("=false");
            if (section != null)
            {
                str.Append(" WHERE `Section` = ");
                str.Append(section);
            }
            bws.sql.query(str.ToString());
        }

        public static void save(string name, string value, Bws bws, StringBuilder errors, string section = null)
        {
            StringBuilder str = new StringBuilder();
            str.Append("UPDATE Settings SET ");
            str.Append(name);
            str.Append("=");
            str.Append(value);
            if (section != null)
            {
                str.Append(" WHERE `Section` = ");
                str.Append(section);
            }
            try
            {
                bws.sql.query(str.ToString());
            }
            catch (OleDbException)
            {
                if (errors.Length > 0) errors.Append(", ");
                errors.Append(name);
            }
        }

        public Setting(string name, string type)
        {
            this.name = name;
            this.type = type;
            this.defaultStr = "";
            this.table = "Settings";
        }

        public Setting(string name, string type, string defaultStr)
        {
            this.name = name;
            this.type = type;
            this.defaultStr = defaultStr;
            this.table = "Settings";
        }

        public Setting(string name, string type, string defaultStr, string table)
        {
            this.name = name;
            this.type = type;
            this.defaultStr = defaultStr;
            this.table = table;
        }

        public string getAddColumnSql()
        {
            StringBuilder str = new StringBuilder();
            str.Append("ALTER TABLE ");
            str.Append(this.table);
            str.Append(" ADD COLUMN ");
            str.Append(this.name);
            str.Append(" ");
            str.Append(this.type);
            str.Append(";");
            return str.ToString();
        }

        public string getSetDefaultSql()
        {
            StringBuilder str = new StringBuilder();
            if (defaultStr.Length > 0)
            {
                str.Append("UPDATE ");
                str.Append(this.table);
                str.Append(" SET ");
                str.Append(this.name);
                str.Append("=");
                str.Append(this.defaultStr);
                str.Append(";");
            }
            return str.ToString();
        }

        public void createField(Sql sql, bool setDefault = true)
        {
            try
            {
                sql.query(this.getAddColumnSql());
            }
            catch (OleDbException)
            {
            }
            if (setDefault)
            {
                try
                {
                    sql.query(this.getSetDefaultSql());
                }
                catch (OleDbException)
                {
                }
            }
        }
    }
}
