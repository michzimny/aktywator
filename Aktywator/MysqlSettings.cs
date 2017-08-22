using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aktywator
{
    public partial class MysqlSettings : Form
    {
        public MysqlSettings()
        {
            InitializeComponent();
        }

        private void MysqlSettings_Load(object sender, EventArgs e)
        {
            eHost.Text = Properties.Settings.Default.HOST;
            eUser.Text = Properties.Settings.Default.USER;
            ePass.Text = Properties.Settings.Default.PASS;
            ePort.Text = Properties.Settings.Default.PORT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HOST = eHost.Text;
            Properties.Settings.Default.USER = eUser.Text;
            Properties.Settings.Default.PASS = ePass.Text;
            Properties.Settings.Default.PORT = ePort.Text;

            string msg = MySQL.test();
            if (msg == "")
            {
                Properties.Settings.Default.CONFIGURED = true;
                Properties.Settings.Default.Save();
                Close();
            }
            else
            {
                MessageBox.Show(msg, "Nieprawidłowe ustawienia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
