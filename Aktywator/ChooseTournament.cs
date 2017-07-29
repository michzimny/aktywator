using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aktywator
{
    public partial class ChooseTournament : Form
    {
        private MySQLTournament[] turns;
        public MySQLTournament chosenTournament;

        public ChooseTournament()
        {
            InitializeComponent();
        }

        private void ChooseTournament_Load(object sender, EventArgs e)
        {
            List<MySQLTournament> list = MySQLTournament.getTournaments();
            turns = new MySQLTournament[list.Count];
            int c = 0;
            foreach (MySQLTournament t in list)
            {
                turns[c++] = t;
                listBox.Items.Add(t.ToString());
            }
        }

        private void bChoose_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                chosenTournament = turns[listBox.SelectedIndex];
                Close();
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bChoose_Click(sender, e);
        }
    }
}
