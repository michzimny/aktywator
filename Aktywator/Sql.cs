using System;
using System.Collections.Generic;
using System.Text;

using System.Data.OleDb;
using data = System.Data.OleDb.OleDbDataReader;

namespace Aktywator
{
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
        public string selectOne(string q)
        {
            OleDbCommand cmd = new OleDbCommand(q, connection);
            object o = cmd.ExecuteScalar();
            if (o == null) return "";
            else return o.ToString();
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
    }
}
