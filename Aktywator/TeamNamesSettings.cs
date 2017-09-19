using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aktywator
{
    public partial class TeamNamesSettings : Form
    {
        public TeamNamesSettings()
        {
            InitializeComponent();
        }

        private MainForm form;
        private TeamyTournament tournament;
        public const int OpenClosedDiff = 1000;

        internal void initTournament(TeamyTournament tournament, MainForm form)
        {
            this.form = form;
            this.tournament = tournament;
            lTournamentName.Text = this.tournament.getName();
            int rounds = this.tournament.getRoundsNum();
            int segments = this.tournament.getSegmentsNum();
            cbRounds.Items.Clear();
            for (int i = 1; i <= rounds; i++)
            {
                cbRounds.Items.Add(i.ToString());
            }
            cbSegments.Items.Clear();
            for (int i = 1; i <= segments; i++)
            {
                cbSegments.Items.Add(i.ToString());
            }
            List<int> currentSegment = this.tournament.getCurrentSegment();
            cbRounds.SelectedIndex = currentSegment[0] - 1;
            cbSegments.SelectedIndex = currentSegment[1] - 1;
            cbSecondRow.SelectedIndex = 0;
        }

        public string getLabel()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(cbRounds.SelectedItem);
            ret.Append('-');
            ret.Append(cbSegments.SelectedItem);
            ret.Append(", ");
            if (rbShowTeamNames.Checked)
            {
                ret.Append("teamy");
                if (cbSecondRow.SelectedIndex == 1)
                {
                    ret.Append(" + IMP");
                }
                if (cbSecondRow.SelectedIndex == 2)
                {
                    ret.Append(" + VP");
                }
            }
            else
            {
                ret.Append("lineup");
            }
            return ret.ToString();
        }

        public bool arePlayerNamesDisplayed()
        {
            return rbShowPlayerNames.Checked;
        }

        public string getQuery()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("SELECT teams.id, ");
            if (rbShowTeamNames.Checked)
            {
                ret.Append("fullname, ");
                switch (cbSecondRow.SelectedIndex) {
                    case 0:
                        ret.Append("'' FROM teams ORDER BY teams.id");
                        break;
                    case 1:
                        ret.Append("CONCAT(SUM(IF(segments.homet = teams.id, impH+corrH, impV+corrV)), ' IMP') FROM teams LEFT JOIN segments ON (teams.id = segments.homet OR teams.id = segments.visit) AND segments.rnd = ");
                        ret.Append(cbRounds.SelectedItem);
                        ret.Append(" AND segments.segment < ");
                        ret.Append(cbSegments.SelectedItem);
                        ret.Append(" GROUP BY teams.id ORDER BY teams.id");
                        break;
                    case 2:
                        ret.Append("CONCAT(SUM(IF(matches.homet = teams.id, vph+corrh, vpv+corrv)), ' VP') FROM teams LEFT JOIN matches ON (teams.id = matches.homet OR teams.id = matches.visit) AND matches.rnd <= ");
                        ret.Append(cbRounds.SelectedItem);
                        ret.Append(" GROUP BY teams.id ORDER BY teams.id");
                        break;
                }
            }
            else
            {
                ret.Append("CONCAT(p1.gname, ' ', p1.sname), CONCAT(p2.gname, ' ', p2.sname) FROM teams JOIN segments ON segments.rnd = ");
                ret.Append(cbRounds.SelectedItem);
                ret.Append(" AND segments.segment = ");
                ret.Append(cbSegments.SelectedItem);
                ret.Append(" AND teams.id = segments.homet LEFT JOIN players p1 ON p1.id = segments.openN LEFT JOIN players p2 ON p2.id = segments.openS");

                ret.Append(" UNION SELECT teams.id, CONCAT(p1.gname, ' ', p1.sname), CONCAT(p2.gname, ' ', p2.sname) FROM teams JOIN segments ON segments.rnd = ");
                ret.Append(cbRounds.SelectedItem);
                ret.Append(" AND segments.segment = ");
                ret.Append(cbSegments.SelectedItem);
                ret.Append(" AND teams.id = segments.visit LEFT JOIN players p1 ON p1.id = segments.openE LEFT JOIN players p2 ON p2.id = segments.openW");

                ret.Append(" UNION SELECT teams.id + ");
                ret.Append(TeamNamesSettings.OpenClosedDiff);
                ret.Append(", CONCAT(p1.gname, ' ', p1.sname), CONCAT(p2.gname, ' ', p2.sname) FROM teams JOIN segments ON segments.rnd = ");
                ret.Append(cbRounds.SelectedItem);
                ret.Append(" AND segments.segment = ");
                ret.Append(cbSegments.SelectedItem);
                ret.Append(" AND teams.id = segments.homet LEFT JOIN players p1 ON p1.id = segments.closeE LEFT JOIN players p2 ON p2.id = segments.closeW");

                ret.Append(" UNION SELECT teams.id + ");
                ret.Append(TeamNamesSettings.OpenClosedDiff);
                ret.Append(", CONCAT(p1.gname, ' ', p1.sname), CONCAT(p2.gname, ' ', p2.sname) FROM teams JOIN segments ON segments.rnd = ");
                ret.Append(cbRounds.SelectedItem);
                ret.Append(" AND segments.segment = ");
                ret.Append(cbSegments.SelectedItem);
                ret.Append(" AND teams.id = segments.visit LEFT JOIN players p1 ON p1.id = segments.closeN LEFT JOIN players p2 ON p2.id = segments.closeS");
                ret.Append(" ORDER BY id");
            }
            Console.WriteLine(ret.ToString());
            return ret.ToString();
        }

        private void rbShowPlayerNames_CheckedChanged(object sender, EventArgs e)
        {
            cbSecondRow.Enabled = !rbShowPlayerNames.Checked;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeamNamesSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void TeamNamesSettings_Shown(object sender, EventArgs e)
        {
        }
    }
}
