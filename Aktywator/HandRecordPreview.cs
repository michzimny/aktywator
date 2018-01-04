using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aktywator
{
    public partial class HandRecordPreview : Form
    {
        public HandRecordPreview()
        {
            InitializeComponent();
        }

        internal HandRecordPreview(HandRecord record, string boardNo) : this()
        {
            lNorthSpades.Text = record.north[0];
            lNorthHearts.Text = record.north[1];
            lNorthDiamonds.Text = record.north[2];
            lNorthClubs.Text = record.north[3];
            lEastSpades.Text = record.east[0];
            lEastHearts.Text = record.east[1];
            lEastDiamonds.Text = record.east[2];
            lEastClubs.Text = record.east[3];
            lSouthSpades.Text = record.south[0];
            lSouthHearts.Text = record.south[1];
            lSouthDiamonds.Text = record.south[2];
            lSouthClubs.Text = record.south[3];
            lWestSpades.Text = record.west[0];
            lWestHearts.Text = record.west[1];
            lWestDiamonds.Text = record.west[2];
            lWestClubs.Text = record.west[3];
            this.Text = "ROZDANIE " + boardNo;
        }
    }
}
