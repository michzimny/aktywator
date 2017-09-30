using System;
using System.Collections.Generic;
using System.Text;

using System.Data.OleDb;
using data = System.Data.OleDb.OleDbDataReader;

namespace Aktywator
{
    class OleDbRowMissingException : Exception
    {
    }

    class Sql
    {
        private OleDbConnection connection;

        public Sql(string filename)
        {
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=" + filename + ";";
            connection = new OleDbConnection(connStr);
            connection.Open();
        }

        public void close()
        {
            connection.Close();
        }

        public bool isOpen()
        {
            if (connection == null) return false;
            else return connection.State == System.Data.ConnectionState.Open;
        }

        public int query(string q)
        {
            OleDbCommand cmd = new OleDbCommand(q, connection);
            return cmd.ExecuteNonQuery();
        }
        public string selectOne(string q, bool checkForRow = false)
        {
            OleDbCommand cmd = new OleDbCommand(q, connection);
            object o = cmd.ExecuteScalar();
            if (o == null) // it's null if the row does not exist, it'd be DBNull.Value if NULL was the value in existing row
            {
                if (!checkForRow)
                {
                    return "";
                }
                throw new OleDbRowMissingException();
            }
            return o.ToString();
        }
        public data select(string q)
        {
            OleDbCommand cmd = new OleDbCommand(q, connection);
            return cmd.ExecuteReader();
        }

        public bool checkTableExists(string tableName)
        {
            try
            {
                selectOne("select count(*) from " + tableName);
            }
            catch (OleDbException)
            {
                return false;
            }
            return true;
        }

        public bool checkFieldExists(string tableName, string fieldName)
        {
            try
            {
                selectOne("select " + fieldName + " from " + tableName);
            }
            catch (OleDbException)
            {
                return false;
            }
            return true;
        }

        internal void insert(string table, Dictionary<string, object> columns)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO ");
            query.Append(table);
            query.Append(" (");
            List<string> keys = new List<string>();
            List<string> parameters = new List<string>();
            foreach (string key in columns.Keys)
            {
                keys.Add("`" + key + "`");
                parameters.Add("@" + key);
            }
            string[] fields = keys.ToArray();
            query.Append(String.Join(", ", fields));
            query.Append(") VALUES(");
            query.Append(String.Join(", ", parameters.ToArray()));
            query.Append(")");
            OleDbCommand command = new OleDbCommand(query.ToString(), connection);
            foreach (KeyValuePair<string, object> column in columns)
            {
                command.Parameters.AddWithValue("@" + column.Key, column.Value);
            }
            command.ExecuteScalar();
        }
    }
}
