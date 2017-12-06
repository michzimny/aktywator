using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aktywator
{
    public struct TournamentListItem
    {
        public int Type;
        public string Name;
        public string Label;
    }

    public partial class ChooseTournament : Form
    {
        private TournamentListItem[] turns;
        public MySQLTournament chosenTournament;

        public ChooseTournament()
        {
            InitializeComponent();
        }

        private void ChooseTournament_Load(object sender, EventArgs e)
        {
            List<TournamentListItem> list = MySQLTournament.getTournaments();
            turns = new TournamentListItem[list.Count];
            int c = 0;
            foreach (TournamentListItem t in list)
            {
                turns[c++] = t;
                listBox.Items.Add(t.Label);
            }
        }

        private void bChoose_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                switch (turns[listBox.SelectedIndex].Type)
                {
                    case Tournament.TYPE_PARY:
                        chosenTournament = new ParyTournament(turns[listBox.SelectedIndex].Name);
                        break;
                    case Tournament.TYPE_TEAMY:
                        chosenTournament = new TeamyTournament(turns[listBox.SelectedIndex].Name);
                        break;
                }
                Close();
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bChoose_Click(sender, e);
        }
    }
}
