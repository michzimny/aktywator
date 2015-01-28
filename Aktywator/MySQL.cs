using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using data = MySql.Data.MySqlClient.MySqlDataReader;

namespace Aktywator
{
    public class MySQL
    {
        private MySqlConnection conn;
        private string database;

        public MySQL(string database)
        {
            this.database = database;
            connect();
        }

        public void connect()
        {
            conn = new MySqlConnection((database != "" ? ("Database=" + database + ";") : "")
                + "Data Source=" + getHost() + ";User Id=" + getUser() + ";Password=" + getPass() 
                + ";Port=" + getPort() + ";charset=utf8;");

            conn.Open();
        }

        public void close()
        {
            try
            {
                conn.Close();
                conn = null;
            }
            catch (Exception)
            {
            }
        }

        public bool isOpen()
        {
            return conn != null;
        }

        public void query(string query)
        {
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
        }

        public string selectOne(string query)
        {
            MySqlCommand comm = new MySqlCommand(query, conn);
            object ob = comm.ExecuteScalar();
            if (ob != null) return ob.ToString();
            else return "";
        }

        public data select(string query)
        {
            MySqlCommand comm = new MySqlCommand(query, conn);
            return comm.ExecuteReader();
        }

        public static string test()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Data Source=" + getHost() + ";User Id=" + getUser() + ";Password=" + getPass()
                + ";Port=" + getPort() + ";charset=utf8;");
                conn.Open();
            }
            catch (MySqlException e)
            {
                return e.Message;
            }
            catch (Exception e)
            {
                return "Prawdopodobnie brakuje Ci dll-ki od MySQL'a.\n\n" + e.Message;
            }
            return "";
        }

        public static string getHost() { return Properties.Settings.Default.HOST; }
        public static string getUser() { return Properties.Settings.Default.USER; }
        public static string getPass() { return Properties.Settings.Default.PASS; }
        public static string getPort() { return Properties.Settings.Default.PORT; }
    }
}
