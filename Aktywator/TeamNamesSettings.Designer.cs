namespace Aktywator
{
    partial class TeamNamesSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lTournamentName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRounds = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSegments = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbShowTeamNames = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSecondRow = new System.Windows.Forms.ComboBox();
            this.rbShowPlayerNames = new System.Windows.Forms.RadioButton();
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turniej:";
            // 
            // lTournamentName
            // 
            this.lTournamentName.AutoSize = true;
            this.lTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTournamentName.Location = new System.Drawing.Point(61, 13);
            this.lTournamentName.Name = "lTournamentName";
            this.lTournamentName.Size = new System.Drawing.Size(109, 13);
            this.lTournamentName.TabIndex = 1;
            this.lTournamentName.Text = "lTournamentName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Runda:";
            // 
            // cbRounds
            // 
            this.cbRounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRounds.FormattingEnabled = true;
            this.cbRounds.Location = new System.Drawing.Point(61, 39);
            this.cbRounds.Name = "cbRounds";
            this.cbRounds.Size = new System.Drawing.Size(41, 21);
            this.cbRounds.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Segment:";
            // 
            // cbSegments
            // 
            this.cbSegments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSegments.FormattingEnabled = true;
            this.cbSegments.Location = new System.Drawing.Point(166, 39);
            this.cbSegments.Name = "cbSegments";
            this.cbSegments.Size = new System.Drawing.Size(41, 21);
            this.cbSegments.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Wyświetl:";
            // 
            // rbShowTeamNames
            // 
            this.rbShowTeamNames.AutoSize = true;
            this.rbShowTeamNames.Checked = true;
            this.rbShowTeamNames.Location = new System.Drawing.Point(16, 90);
            this.rbShowTeamNames.Name = "rbShowTeamNames";
            this.rbShowTeamNames.Size = new System.Drawing.Size(95, 17);
            this.rbShowTeamNames.TabIndex = 7;
            this.rbShowTeamNames.TabStop = true;
            this.rbShowTeamNames.Text = "nazwy teamów";
            this.rbShowTeamNames.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "drugi wiersz:";
            // 
            // cbSecondRow
            // 
            this.cbSecondRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSecondRow.FormattingEnabled = true;
            this.cbSecondRow.Items.AddRange(new object[] {
            "nic",
            "wynik meczu w IMP",
            "wynik drużyny w VP"});
            this.cbSecondRow.Location = new System.Drawing.Point(103, 112);
            this.cbSecondRow.Name = "cbSecondRow";
            this.cbSecondRow.Size = new System.Drawing.Size(115, 21);
            this.cbSecondRow.TabIndex = 9;
            // 
            // rbShowPlayerNames
            // 
            this.rbShowPlayerNames.AutoSize = true;
            this.rbShowPlayerNames.Location = new System.Drawing.Point(16, 137);
            this.rbShowPlayerNames.Name = "rbShowPlayerNames";
            this.rbShowPlayerNames.Size = new System.Drawing.Size(114, 17);
            this.rbShowPlayerNames.TabIndex = 10;
            this.rbShowPlayerNames.Text = "nazwiska z lineupu";
            this.rbShowPlayerNames.UseVisualStyleBackColor = true;
            this.rbShowPlayerNames.CheckedChanged += new System.EventHandler(this.rbShowPlayerNames_CheckedChanged);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(16, 164);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(202, 23);
            this.bClose.TabIndex = 11;
            this.bClose.Text = "Zamknij";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // TeamNamesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 199);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.rbShowPlayerNames);
            this.Controls.Add(this.cbSecondRow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbShowTeamNames);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSegments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRounds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lTournamentName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TeamNamesSettings";
            this.Text = "JFR Teamy - nazwiska";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeamNamesSettings_FormClosed);
            this.Shown += new System.EventHandler(this.TeamNamesSettings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lTournamentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRounds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSegments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbShowTeamNames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSecondRow;
        private System.Windows.Forms.RadioButton rbShowPlayerNames;
        private System.Windows.Forms.Button bClose;
    }
}