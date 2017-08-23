namespace Aktywator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lFirstSectorSettings = new System.Windows.Forms.Label();
            this.cbSettingsSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lRequiredVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lDetectedVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lRequiredFirmware = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.bLoad = new System.Windows.Forms.ToolStripButton();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.xResetFunctionKey = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xPINcode = new System.Windows.Forms.TextBox();
            this.xConfirmNP = new System.Windows.Forms.CheckBox();
            this.xScoreCorrection = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.xAutoShutDownBPC = new System.Windows.Forms.CheckBox();
            this.xRemainingBoards = new System.Windows.Forms.CheckBox();
            this.xNextSeatings = new System.Windows.Forms.CheckBox();
            this.xScoreRecap = new System.Windows.Forms.CheckBox();
            this.xAutoShowScoreRecap = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.xCheckLeadCard = new System.Windows.Forms.CheckBox();
            this.xLeadCard = new System.Windows.Forms.CheckBox();
            this.xViewHandrecord = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.xGroupSections = new System.Windows.Forms.CheckBox();
            this.xShowResults = new System.Windows.Forms.CheckBox();
            this.xRepeatResults = new System.Windows.Forms.CheckBox();
            this.xShowPercentage = new System.Windows.Forms.CheckBox();
            this.xShowContract = new System.Windows.Forms.CheckBox();
            this.xResultsOverview = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.xCollectPlay = new System.Windows.Forms.CheckBox();
            this.xBoardOrderVerification = new System.Windows.Forms.CheckBox();
            this.xIntermediateResults = new System.Windows.Forms.CheckBox();
            this.xAutoBoardNumber = new System.Windows.Forms.CheckBox();
            this.xCollectBidding = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xMemberNumbers = new System.Windows.Forms.CheckBox();
            this.xShowPairNumbers = new System.Windows.Forms.CheckBox();
            this.xMemberNumbersNoBlankEntry = new System.Windows.Forms.CheckBox();
            this.xShowPlayerNames = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.namesPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.numNamesRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numTeamsTableOffset = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.namesGridView = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NorthSouth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EastWest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lTournament = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lSkok = new System.Windows.Forms.Label();
            this.lSections = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lTables = new System.Windows.Forms.Label();
            this.syncToolStrip = new System.Windows.Forms.ToolStrip();
            this.bSync = new System.Windows.Forms.ToolStripButton();
            this.bAutoSync = new System.Windows.Forms.ToolStripButton();
            this.eInterval = new System.Windows.Forms.ToolStripTextBox();
            this.eOomRounds = new System.Windows.Forms.ToolStripTextBox();
            this.lOomLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.bMySQLTournament = new System.Windows.Forms.ToolStripMenuItem();
            this.bRRBTournament = new System.Windows.Forms.ToolStripMenuItem();
            this.bMysqlSettings = new System.Windows.Forms.ToolStripButton();
            this.bForceSync = new System.Windows.Forms.ToolStripButton();
            this.bTruncate = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.bLoadHands = new System.Windows.Forms.ToolStripButton();
            this.bClearHands = new System.Windows.Forms.ToolStripButton();
            this.lRecordSections = new System.Windows.Forms.Label();
            this.cblSections = new System.Windows.Forms.CheckedListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openPBN = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelFilename = new System.Windows.Forms.ToolStripLabel();
            this.bLaunch = new System.Windows.Forms.ToolStripButton();
            this.bUpdateSession = new System.Windows.Forms.ToolStripButton();
            this.namesTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.namesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamesRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsTableOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namesGridView)).BeginInit();
            this.syncToolStrip.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Filter = "BWS|*.bws";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status1,
            this.status2,
            this.status3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 568);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(583, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusBar";
            // 
            // status1
            // 
            this.status1.Name = "status1";
            this.status1.Size = new System.Drawing.Size(106, 17);
            this.status1.Text = "Michał Zimniewicz";
            // 
            // status2
            // 
            this.status2.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.status2.Name = "status2";
            this.status2.Size = new System.Drawing.Size(118, 17);
            this.status2.Text = "toolStripStatusLabel1";
            // 
            // status3
            // 
            this.status3.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.status3.Name = "status3";
            this.status3.Size = new System.Drawing.Size(118, 17);
            this.status3.Text = "toolStripStatusLabel2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 568);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(577, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lFirstSectorSettings);
            this.tabPage1.Controls.Add(this.cbSettingsSection);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.statusStrip2);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(569, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ustawienia";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lFirstSectorSettings
            // 
            this.lFirstSectorSettings.AutoSize = true;
            this.lFirstSectorSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFirstSectorSettings.Location = new System.Drawing.Point(119, 39);
            this.lFirstSectorSettings.Name = "lFirstSectorSettings";
            this.lFirstSectorSettings.Size = new System.Drawing.Size(263, 13);
            this.lFirstSectorSettings.TabIndex = 49;
            this.lFirstSectorSettings.Text = "załadowano ustawienia z pierwszego sektora";
            // 
            // cbSettingsSection
            // 
            this.cbSettingsSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingsSection.FormattingEnabled = true;
            this.cbSettingsSection.Items.AddRange(new object[] {
            "*"});
            this.cbSettingsSection.Location = new System.Drawing.Point(59, 36);
            this.cbSettingsSection.Name = "cbSettingsSection";
            this.cbSettingsSection.Size = new System.Drawing.Size(53, 21);
            this.cbSettingsSection.TabIndex = 48;
            this.cbSettingsSection.SelectedIndexChanged += new System.EventHandler(this.cbSettingsSection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Sektor:";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.White;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lRequiredVersion,
            this.toolStripStatusLabel2,
            this.lDetectedVersion,
            this.toolStripStatusLabel3,
            this.lRequiredFirmware});
            this.statusStrip2.Location = new System.Drawing.Point(3, 486);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(563, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 46;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabel1.Text = "Wymagana wersja BCS:";
            // 
            // lRequiredVersion
            // 
            this.lRequiredVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRequiredVersion.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.lRequiredVersion.Name = "lRequiredVersion";
            this.lRequiredVersion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lRequiredVersion.Size = new System.Drawing.Size(44, 17);
            this.lRequiredVersion.Text = "0.0.0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel2.Text = "Wykryta wersja BCS:";
            // 
            // lDetectedVersion
            // 
            this.lDetectedVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDetectedVersion.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.lDetectedVersion.Name = "lDetectedVersion";
            this.lDetectedVersion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lDetectedVersion.Size = new System.Drawing.Size(44, 17);
            this.lDetectedVersion.Text = "0.0.0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel3.Text = "Wymagany firmware:";
            // 
            // lRequiredFirmware
            // 
            this.lRequiredFirmware.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRequiredFirmware.Name = "lRequiredFirmware";
            this.lRequiredFirmware.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lRequiredFirmware.Size = new System.Drawing.Size(44, 17);
            this.lRequiredFirmware.Text = "0.0.0";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bLoad,
            this.bSave});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(563, 25);
            this.toolStrip2.TabIndex = 45;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // bLoad
            // 
            this.bLoad.Image = ((System.Drawing.Image)(resources.GetObject("bLoad.Image")));
            this.bLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(216, 22);
            this.bLoad.Text = "Ponownie wczytaj ustawienia z BWS";
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bSave
            // 
            this.bSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(108, 22);
            this.bSave.Text = "Zapisz do BWS";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.xResetFunctionKey);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.xPINcode);
            this.groupBox7.Controls.Add(this.xConfirmNP);
            this.groupBox7.Controls.Add(this.xScoreCorrection);
            this.groupBox7.Location = new System.Drawing.Point(267, 355);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(294, 121);
            this.groupBox7.TabIndex = 44;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Opcje sędziowskie";
            // 
            // xResetFunctionKey
            // 
            this.xResetFunctionKey.AutoSize = true;
            this.xResetFunctionKey.Location = new System.Drawing.Point(13, 92);
            this.xResetFunctionKey.Name = "xResetFunctionKey";
            this.xResetFunctionKey.Size = new System.Drawing.Size(207, 17);
            this.xResetFunctionKey.TabIndex = 24;
            this.xResetFunctionKey.Text = "zawodnik może zresetować pierniczka";
            this.xResetFunctionKey.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "PIN";
            // 
            // xPINcode
            // 
            this.xPINcode.Location = new System.Drawing.Point(41, 21);
            this.xPINcode.MaxLength = 4;
            this.xPINcode.Name = "xPINcode";
            this.xPINcode.Size = new System.Drawing.Size(37, 20);
            this.xPINcode.TabIndex = 14;
            this.xPINcode.Text = "0000";
            // 
            // xConfirmNP
            // 
            this.xConfirmNP.AutoSize = true;
            this.xConfirmNP.Location = new System.Drawing.Point(13, 46);
            this.xConfirmNP.Name = "xConfirmNP";
            this.xConfirmNP.Size = new System.Drawing.Size(198, 17);
            this.xConfirmNP.TabIndex = 22;
            this.xConfirmNP.Text = "NoPlay potwierdzany przez sędziego";
            this.xConfirmNP.UseVisualStyleBackColor = true;
            // 
            // xScoreCorrection
            // 
            this.xScoreCorrection.AutoSize = true;
            this.xScoreCorrection.Location = new System.Drawing.Point(13, 69);
            this.xScoreCorrection.Name = "xScoreCorrection";
            this.xScoreCorrection.Size = new System.Drawing.Size(186, 17);
            this.xScoreCorrection.TabIndex = 23;
            this.xScoreCorrection.Text = "zawodnicy sami poprawiają zapisy";
            this.xScoreCorrection.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.xAutoShutDownBPC);
            this.groupBox6.Controls.Add(this.xRemainingBoards);
            this.groupBox6.Controls.Add(this.xNextSeatings);
            this.groupBox6.Controls.Add(this.xScoreRecap);
            this.groupBox6.Controls.Add(this.xAutoShowScoreRecap);
            this.groupBox6.Location = new System.Drawing.Point(267, 209);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(294, 140);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Koniec rundy";
            // 
            // xAutoShutDownBPC
            // 
            this.xAutoShutDownBPC.AutoSize = true;
            this.xAutoShutDownBPC.Location = new System.Drawing.Point(13, 114);
            this.xAutoShutDownBPC.Name = "xAutoShutDownBPC";
            this.xAutoShutDownBPC.Size = new System.Drawing.Size(166, 17);
            this.xAutoShutDownBPC.TabIndex = 17;
            this.xAutoShutDownBPC.Text = "automat. wyłącz BCS po sesji";
            this.xAutoShutDownBPC.UseVisualStyleBackColor = true;
            // 
            // xRemainingBoards
            // 
            this.xRemainingBoards.AutoSize = true;
            this.xRemainingBoards.Location = new System.Drawing.Point(13, 68);
            this.xRemainingBoards.Name = "xRemainingBoards";
            this.xRemainingBoards.Size = new System.Drawing.Size(205, 17);
            this.xRemainingBoards.TabIndex = 11;
            this.xRemainingBoards.Text = "pokazuj liczbę rozdań do końca rundy";
            this.xRemainingBoards.UseVisualStyleBackColor = true;
            // 
            // xNextSeatings
            // 
            this.xNextSeatings.AutoSize = true;
            this.xNextSeatings.Location = new System.Drawing.Point(13, 91);
            this.xNextSeatings.Name = "xNextSeatings";
            this.xNextSeatings.Size = new System.Drawing.Size(192, 17);
            this.xNextSeatings.TabIndex = 8;
            this.xNextSeatings.Text = "pokazuj rozstawienie kolejnej rundy";
            this.xNextSeatings.UseVisualStyleBackColor = true;
            // 
            // xScoreRecap
            // 
            this.xScoreRecap.AutoSize = true;
            this.xScoreRecap.Location = new System.Drawing.Point(13, 22);
            this.xScoreRecap.Name = "xScoreRecap";
            this.xScoreRecap.Size = new System.Drawing.Size(176, 17);
            this.xScoreRecap.TabIndex = 12;
            this.xScoreRecap.Text = "podgląd zapisów bieżącej rundy";
            this.xScoreRecap.UseVisualStyleBackColor = true;
            // 
            // xAutoShowScoreRecap
            // 
            this.xAutoShowScoreRecap.AutoSize = true;
            this.xAutoShowScoreRecap.Location = new System.Drawing.Point(13, 45);
            this.xAutoShowScoreRecap.Name = "xAutoShowScoreRecap";
            this.xAutoShowScoreRecap.Size = new System.Drawing.Size(228, 17);
            this.xAutoShowScoreRecap.TabIndex = 13;
            this.xAutoShowScoreRecap.Text = "podgląd zapisów na koniec rundy automat.";
            this.xAutoShowScoreRecap.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.xCheckLeadCard);
            this.groupBox5.Controls.Add(this.xLeadCard);
            this.groupBox5.Controls.Add(this.xViewHandrecord);
            this.groupBox5.Location = new System.Drawing.Point(4, 355);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(257, 121);
            this.groupBox5.TabIndex = 42;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rozkłady";
            // 
            // xCheckLeadCard
            // 
            this.xCheckLeadCard.AutoSize = true;
            this.xCheckLeadCard.Location = new System.Drawing.Point(12, 71);
            this.xCheckLeadCard.Name = "xCheckLeadCard";
            this.xCheckLeadCard.Size = new System.Drawing.Size(180, 17);
            this.xCheckLeadCard.TabIndex = 32;
            this.xCheckLeadCard.Text = "sprawdź kartę wistu z rozkładem";
            this.xCheckLeadCard.UseVisualStyleBackColor = true;
            // 
            // xLeadCard
            // 
            this.xLeadCard.AutoSize = true;
            this.xLeadCard.Location = new System.Drawing.Point(12, 48);
            this.xLeadCard.Name = "xLeadCard";
            this.xLeadCard.Size = new System.Drawing.Size(111, 17);
            this.xLeadCard.TabIndex = 21;
            this.xLeadCard.Text = "pytaj o kartę wistu";
            this.xLeadCard.UseVisualStyleBackColor = true;
            // 
            // xViewHandrecord
            // 
            this.xViewHandrecord.AutoSize = true;
            this.xViewHandrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xViewHandrecord.Location = new System.Drawing.Point(12, 25);
            this.xViewHandrecord.Name = "xViewHandrecord";
            this.xViewHandrecord.Size = new System.Drawing.Size(123, 17);
            this.xViewHandrecord.TabIndex = 29;
            this.xViewHandrecord.Text = "pokazuj rozkłady";
            this.xViewHandrecord.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.xGroupSections);
            this.groupBox4.Controls.Add(this.xShowResults);
            this.groupBox4.Controls.Add(this.xRepeatResults);
            this.groupBox4.Controls.Add(this.xShowPercentage);
            this.groupBox4.Controls.Add(this.xShowContract);
            this.groupBox4.Controls.Add(this.xResultsOverview);
            this.groupBox4.Location = new System.Drawing.Point(267, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(294, 138);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Protokół";
            // 
            // xGroupSections
            // 
            this.xGroupSections.AutoSize = true;
            this.xGroupSections.Location = new System.Drawing.Point(34, 89);
            this.xGroupSections.Name = "xGroupSections";
            this.xGroupSections.Size = new System.Drawing.Size(227, 17);
            this.xGroupSections.TabIndex = 4;
            this.xGroupSections.Text = "wspólne maksowanie wszystkich sektorów";
            this.xGroupSections.UseVisualStyleBackColor = true;
            // 
            // xShowResults
            // 
            this.xShowResults.AutoSize = true;
            this.xShowResults.Location = new System.Drawing.Point(13, 20);
            this.xShowResults.Name = "xShowResults";
            this.xShowResults.Size = new System.Drawing.Size(159, 17);
            this.xShowResults.TabIndex = 1;
            this.xShowResults.Text = "pokazuj wynik rozdania jako";
            this.xShowResults.UseVisualStyleBackColor = true;
            this.xShowResults.CheckedChanged += new System.EventHandler(this.xShowResults_CheckedChanged);
            // 
            // xRepeatResults
            // 
            this.xRepeatResults.AutoSize = true;
            this.xRepeatResults.Enabled = false;
            this.xRepeatResults.Location = new System.Drawing.Point(34, 43);
            this.xRepeatResults.Name = "xRepeatResults";
            this.xRepeatResults.Size = new System.Drawing.Size(155, 17);
            this.xRepeatResults.TabIndex = 2;
            this.xRepeatResults.Text = "nieskończone przeglądanie";
            this.xRepeatResults.UseVisualStyleBackColor = true;
            // 
            // xShowPercentage
            // 
            this.xShowPercentage.AutoSize = true;
            this.xShowPercentage.Enabled = false;
            this.xShowPercentage.Location = new System.Drawing.Point(34, 66);
            this.xShowPercentage.Name = "xShowPercentage";
            this.xShowPercentage.Size = new System.Drawing.Size(102, 17);
            this.xShowPercentage.TabIndex = 3;
            this.xShowPercentage.Text = "pokaż % wyniku";
            this.xShowPercentage.UseVisualStyleBackColor = true;
            // 
            // xShowContract
            // 
            this.xShowContract.AutoSize = true;
            this.xShowContract.Location = new System.Drawing.Point(13, 112);
            this.xShowContract.Name = "xShowContract";
            this.xShowContract.Size = new System.Drawing.Size(150, 17);
            this.xShowContract.TabIndex = 20;
            this.xShowContract.Text = "pokazuj znaczki brydżowe";
            this.xShowContract.UseVisualStyleBackColor = true;
            // 
            // xResultsOverview
            // 
            this.xResultsOverview.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xResultsOverview.Enabled = false;
            this.xResultsOverview.FormattingEnabled = true;
            this.xResultsOverview.Items.AddRange(new object[] {
            "frekwens, 6x1",
            "frekwens, 6x2",
            "frekwens, 4x1",
            "traveler, 6x1",
            "traveler, 6x2",
            "traveler, 4x1"});
            this.xResultsOverview.Location = new System.Drawing.Point(178, 18);
            this.xResultsOverview.Name = "xResultsOverview";
            this.xResultsOverview.Size = new System.Drawing.Size(103, 21);
            this.xResultsOverview.TabIndex = 28;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.xCollectPlay);
            this.groupBox3.Controls.Add(this.xBoardOrderVerification);
            this.groupBox3.Controls.Add(this.xIntermediateResults);
            this.groupBox3.Controls.Add(this.xAutoBoardNumber);
            this.groupBox3.Controls.Add(this.xCollectBidding);
            this.groupBox3.Location = new System.Drawing.Point(3, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 140);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zapis rozdania";
            // 
            // xCollectPlay
            // 
            this.xCollectPlay.AutoSize = true;
            this.xCollectPlay.Location = new System.Drawing.Point(12, 114);
            this.xCollectPlay.Name = "xCollectPlay";
            this.xCollectPlay.Size = new System.Drawing.Size(146, 17);
            this.xCollectPlay.TabIndex = 31;
            this.xCollectPlay.Text = "zbieraj przebieg rozgrywki";
            this.xCollectPlay.UseVisualStyleBackColor = true;
            // 
            // xBoardOrderVerification
            // 
            this.xBoardOrderVerification.AutoSize = true;
            this.xBoardOrderVerification.Location = new System.Drawing.Point(12, 45);
            this.xBoardOrderVerification.Name = "xBoardOrderVerification";
            this.xBoardOrderVerification.Size = new System.Drawing.Size(156, 17);
            this.xBoardOrderVerification.TabIndex = 15;
            this.xBoardOrderVerification.Text = "sprawdzaj kolejność rozdań";
            this.xBoardOrderVerification.UseVisualStyleBackColor = true;
            // 
            // xIntermediateResults
            // 
            this.xIntermediateResults.AutoSize = true;
            this.xIntermediateResults.Location = new System.Drawing.Point(12, 68);
            this.xIntermediateResults.Name = "xIntermediateResults";
            this.xIntermediateResults.Size = new System.Drawing.Size(161, 17);
            this.xIntermediateResults.TabIndex = 16;
            this.xIntermediateResults.Text = "zbieranie danych pośrednich";
            this.xIntermediateResults.UseVisualStyleBackColor = true;
            // 
            // xAutoBoardNumber
            // 
            this.xAutoBoardNumber.AutoSize = true;
            this.xAutoBoardNumber.Location = new System.Drawing.Point(12, 22);
            this.xAutoBoardNumber.Name = "xAutoBoardNumber";
            this.xAutoBoardNumber.Size = new System.Drawing.Size(174, 17);
            this.xAutoBoardNumber.TabIndex = 10;
            this.xAutoBoardNumber.Text = "automat. wpisuj numer rozdania";
            this.xAutoBoardNumber.UseVisualStyleBackColor = true;
            // 
            // xCollectBidding
            // 
            this.xCollectBidding.AutoSize = true;
            this.xCollectBidding.Location = new System.Drawing.Point(12, 91);
            this.xCollectBidding.Name = "xCollectBidding";
            this.xCollectBidding.Size = new System.Drawing.Size(97, 17);
            this.xCollectBidding.TabIndex = 30;
            this.xCollectBidding.Text = "zbieraj licytację";
            this.xCollectBidding.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xMemberNumbers);
            this.groupBox2.Controls.Add(this.xShowPairNumbers);
            this.groupBox2.Controls.Add(this.xMemberNumbersNoBlankEntry);
            this.groupBox2.Controls.Add(this.xShowPlayerNames);
            this.groupBox2.Location = new System.Drawing.Point(5, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 138);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rozstawienie";
            // 
            // xMemberNumbers
            // 
            this.xMemberNumbers.AutoSize = true;
            this.xMemberNumbers.Location = new System.Drawing.Point(12, 67);
            this.xMemberNumbers.Name = "xMemberNumbers";
            this.xMemberNumbers.Size = new System.Drawing.Size(133, 17);
            this.xMemberNumbers.TabIndex = 6;
            this.xMemberNumbers.Text = "pytaj o ID zawodników";
            this.xMemberNumbers.UseVisualStyleBackColor = true;
            this.xMemberNumbers.CheckedChanged += new System.EventHandler(this.xMemberNumbers_CheckedChanged);
            // 
            // xShowPairNumbers
            // 
            this.xShowPairNumbers.AutoSize = true;
            this.xShowPairNumbers.Location = new System.Drawing.Point(12, 44);
            this.xShowPairNumbers.Name = "xShowPairNumbers";
            this.xShowPairNumbers.Size = new System.Drawing.Size(118, 17);
            this.xShowPairNumbers.TabIndex = 5;
            this.xShowPairNumbers.Text = "pokazuj numery par";
            this.xShowPairNumbers.UseVisualStyleBackColor = true;
            // 
            // xMemberNumbersNoBlankEntry
            // 
            this.xMemberNumbersNoBlankEntry.AutoSize = true;
            this.xMemberNumbersNoBlankEntry.Enabled = false;
            this.xMemberNumbersNoBlankEntry.Location = new System.Drawing.Point(33, 90);
            this.xMemberNumbersNoBlankEntry.Name = "xMemberNumbersNoBlankEntry";
            this.xMemberNumbersNoBlankEntry.Size = new System.Drawing.Size(131, 17);
            this.xMemberNumbersNoBlankEntry.TabIndex = 7;
            this.xMemberNumbersNoBlankEntry.Text = "ID nie może być puste";
            this.xMemberNumbersNoBlankEntry.UseVisualStyleBackColor = true;
            // 
            // xShowPlayerNames
            // 
            this.xShowPlayerNames.AutoSize = true;
            this.xShowPlayerNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xShowPlayerNames.Location = new System.Drawing.Point(12, 21);
            this.xShowPlayerNames.Name = "xShowPlayerNames";
            this.xShowPlayerNames.Size = new System.Drawing.Size(126, 17);
            this.xShowPlayerNames.TabIndex = 9;
            this.xShowPlayerNames.Text = "pokazuj nazwiska";
            this.xShowPlayerNames.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.namesPanel);
            this.tabPage2.Controls.Add(this.syncToolStrip);
            this.tabPage2.Controls.Add(this.toolStrip4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(569, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nazwiska";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // namesPanel
            // 
            this.namesPanel.Controls.Add(this.button1);
            this.namesPanel.Controls.Add(this.numNamesRefreshInterval);
            this.namesPanel.Controls.Add(this.label10);
            this.namesPanel.Controls.Add(this.label9);
            this.namesPanel.Controls.Add(this.label7);
            this.namesPanel.Controls.Add(this.numTeamsTableOffset);
            this.namesPanel.Controls.Add(this.label3);
            this.namesPanel.Controls.Add(this.namesGridView);
            this.namesPanel.Controls.Add(this.lTournament);
            this.namesPanel.Controls.Add(this.label4);
            this.namesPanel.Controls.Add(this.lType);
            this.namesPanel.Controls.Add(this.label5);
            this.namesPanel.Controls.Add(this.lSkok);
            this.namesPanel.Controls.Add(this.lSections);
            this.namesPanel.Controls.Add(this.label8);
            this.namesPanel.Controls.Add(this.label6);
            this.namesPanel.Controls.Add(this.lTables);
            this.namesPanel.Location = new System.Drawing.Point(3, 31);
            this.namesPanel.Name = "namesPanel";
            this.namesPanel.Size = new System.Drawing.Size(562, 449);
            this.namesPanel.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(469, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Usuń zmiany";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numNamesRefreshInterval
            // 
            this.numNamesRefreshInterval.Location = new System.Drawing.Point(408, 73);
            this.numNamesRefreshInterval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numNamesRefreshInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNamesRefreshInterval.Name = "numNamesRefreshInterval";
            this.numNamesRefreshInterval.Size = new System.Drawing.Size(41, 20);
            this.numNamesRefreshInterval.TabIndex = 33;
            this.numNamesRefreshInterval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numNamesRefreshInterval.ValueChanged += new System.EventHandler(this.numNamesRefreshInterval_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Odśwież podgląd co (sek.):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(499, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Zmiany wprowadzone powyżej nie zostaną nadpisane danymi z turnieju i nie zostaną " +
                "zapisane w turnieju.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 26);
            this.label7.TabIndex = 30;
            this.label7.Text = "Podgląd nazwisk:\r\n(najedź, by zobaczyć skrócony tekst dla BWS)";
            // 
            // numTeamsTableOffset
            // 
            this.numTeamsTableOffset.Location = new System.Drawing.Point(505, 43);
            this.numTeamsTableOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTeamsTableOffset.Name = "numTeamsTableOffset";
            this.numTeamsTableOffset.Size = new System.Drawing.Size(53, 20);
            this.numTeamsTableOffset.TabIndex = 29;
            this.numTeamsTableOffset.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Turniej:";
            // 
            // namesGridView
            // 
            this.namesGridView.AllowUserToAddRows = false;
            this.namesGridView.AllowUserToDeleteRows = false;
            this.namesGridView.AllowUserToResizeColumns = false;
            this.namesGridView.AllowUserToResizeRows = false;
            this.namesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.namesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.namesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.NorthSouth,
            this.EastWest});
            this.namesGridView.Location = new System.Drawing.Point(2, 98);
            this.namesGridView.Name = "namesGridView";
            this.namesGridView.Size = new System.Drawing.Size(557, 318);
            this.namesGridView.TabIndex = 28;
            this.namesGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.namesGridView_CellMouseEnter);
            this.namesGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.namesGridView_CellValueChanged);
            // 
            // Number
            // 
            this.Number.HeaderText = "Nr";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // NorthSouth
            // 
            this.NorthSouth.FillWeight = 300F;
            this.NorthSouth.HeaderText = "NS";
            this.NorthSouth.Name = "NorthSouth";
            // 
            // EastWest
            // 
            this.EastWest.FillWeight = 300F;
            this.EastWest.HeaderText = "EW";
            this.EastWest.Name = "EastWest";
            // 
            // lTournament
            // 
            this.lTournament.AutoSize = true;
            this.lTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTournament.Location = new System.Drawing.Point(64, 18);
            this.lTournament.Name = "lTournament";
            this.lTournament.Size = new System.Drawing.Size(0, 16);
            this.lTournament.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Typ:";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(64, 45);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(0, 13);
            this.lType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sektorów:";
            // 
            // lSkok
            // 
            this.lSkok.AutoSize = true;
            this.lSkok.Location = new System.Drawing.Point(430, 45);
            this.lSkok.Name = "lSkok";
            this.lSkok.Size = new System.Drawing.Size(74, 13);
            this.lSkok.TabIndex = 19;
            this.lSkok.Text = "skok stołów =";
            this.lSkok.Visible = false;
            // 
            // lSections
            // 
            this.lSections.AutoSize = true;
            this.lSections.Location = new System.Drawing.Point(403, 18);
            this.lSections.Name = "lSections";
            this.lSections.Size = new System.Drawing.Size(0, 13);
            this.lSections.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(323, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Do serwerka wysyłane są tylko nazwiska, które się zaktualizowały.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Stołów:";
            // 
            // lTables
            // 
            this.lTables.AutoSize = true;
            this.lTables.Location = new System.Drawing.Point(403, 45);
            this.lTables.Name = "lTables";
            this.lTables.Size = new System.Drawing.Size(0, 13);
            this.lTables.TabIndex = 8;
            // 
            // syncToolStrip
            // 
            this.syncToolStrip.BackColor = System.Drawing.Color.White;
            this.syncToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.syncToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.syncToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.syncToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSync,
            this.bAutoSync,
            this.eInterval,
            this.eOomRounds,
            this.lOomLabel,
            this.toolStripButton2});
            this.syncToolStrip.Location = new System.Drawing.Point(3, 483);
            this.syncToolStrip.Name = "syncToolStrip";
            this.syncToolStrip.Size = new System.Drawing.Size(563, 25);
            this.syncToolStrip.TabIndex = 27;
            this.syncToolStrip.Text = "toolStrip5";
            // 
            // bSync
            // 
            this.bSync.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSync.Image = ((System.Drawing.Image)(resources.GetObject("bSync.Image")));
            this.bSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSync.Name = "bSync";
            this.bSync.Size = new System.Drawing.Size(130, 22);
            this.bSync.Text = "Synchronizuj teraz";
            this.bSync.Click += new System.EventHandler(this.bSync_Click);
            // 
            // bAutoSync
            // 
            this.bAutoSync.Image = ((System.Drawing.Image)(resources.GetObject("bAutoSync.Image")));
            this.bAutoSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAutoSync.Margin = new System.Windows.Forms.Padding(30, 1, 0, 2);
            this.bAutoSync.Name = "bAutoSync";
            this.bAutoSync.Size = new System.Drawing.Size(114, 22);
            this.bAutoSync.Text = "Synchronizuj co:";
            this.bAutoSync.Click += new System.EventHandler(this.bAutoSync_Click);
            // 
            // eInterval
            // 
            this.eInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eInterval.Name = "eInterval";
            this.eInterval.Size = new System.Drawing.Size(50, 25);
            // 
            // eOomRounds
            // 
            this.eOomRounds.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eOomRounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eOomRounds.Enabled = false;
            this.eOomRounds.Name = "eOomRounds";
            this.eOomRounds.Size = new System.Drawing.Size(80, 25);
            this.eOomRounds.ToolTipText = "Jeśli nie wiesz do czego to jest, to nic nie wpisuj!";
            // 
            // lOomLabel
            // 
            this.lOomLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lOomLabel.Enabled = false;
            this.lOomLabel.Name = "lOomLabel";
            this.lOomLabel.Size = new System.Drawing.Size(92, 22);
            this.lOomLabel.Text = "Rundy dla OOM";
            this.lOomLabel.ToolTipText = "Jeśli nie wiesz do czego to jest, to nic nie wpisuj!";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "‎✔";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton2.ToolTipText = "Jeśli nie wiesz do czego to jest, to nic nie wpisuj!";
            this.toolStripButton2.CheckedChanged += new System.EventHandler(this.toolStripButton2_CheckedChanged);
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackColor = System.Drawing.Color.White;
            this.toolStrip4.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.bMysqlSettings,
            this.bForceSync,
            this.bTruncate});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(563, 25);
            this.toolStrip4.TabIndex = 26;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bMySQLTournament,
            this.bRRBTournament});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripSplitButton1.Text = "Turniej";
            this.toolStripSplitButton1.ToolTipText = "Wybierz turniej";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // bMySQLTournament
            // 
            this.bMySQLTournament.Image = ((System.Drawing.Image)(resources.GetObject("bMySQLTournament.Image")));
            this.bMySQLTournament.Name = "bMySQLTournament";
            this.bMySQLTournament.Size = new System.Drawing.Size(95, 22);
            this.bMySQLTournament.Text = "JFR";
            this.bMySQLTournament.ToolTipText = "JFR Pary lub JFR Teamy";
            this.bMySQLTournament.Click += new System.EventHandler(this.bMySQLTournament_Click);
            // 
            // bRRBTournament
            // 
            this.bRRBTournament.Image = ((System.Drawing.Image)(resources.GetObject("bRRBTournament.Image")));
            this.bRRBTournament.Name = "bRRBTournament";
            this.bRRBTournament.Size = new System.Drawing.Size(95, 22);
            this.bRRBTournament.Text = "RRB";
            this.bRRBTournament.ToolTipText = "Red Rose Bridge";
            this.bRRBTournament.Click += new System.EventHandler(this.bRRBTournament_Click);
            // 
            // bMysqlSettings
            // 
            this.bMysqlSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bMysqlSettings.Image = ((System.Drawing.Image)(resources.GetObject("bMysqlSettings.Image")));
            this.bMysqlSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMysqlSettings.Name = "bMysqlSettings";
            this.bMysqlSettings.Size = new System.Drawing.Size(125, 22);
            this.bMysqlSettings.Text = "Ustawienia MySQL";
            this.bMysqlSettings.Click += new System.EventHandler(this.bMysqlSettings_Click);
            // 
            // bForceSync
            // 
            this.bForceSync.Image = ((System.Drawing.Image)(resources.GetObject("bForceSync.Image")));
            this.bForceSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bForceSync.Margin = new System.Windows.Forms.Padding(65, 1, 0, 2);
            this.bForceSync.Name = "bForceSync";
            this.bForceSync.Size = new System.Drawing.Size(122, 22);
            this.bForceSync.Text = "Wymuś przesłanie";
            this.bForceSync.ToolTipText = "Wymuś przesłanie wszystkich do serwerka ponownie";
            this.bForceSync.Click += new System.EventHandler(this.bForceSync_Click);
            // 
            // bTruncate
            // 
            this.bTruncate.Image = ((System.Drawing.Image)(resources.GetObject("bTruncate.Image")));
            this.bTruncate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bTruncate.Name = "bTruncate";
            this.bTruncate.Size = new System.Drawing.Size(139, 22);
            this.bTruncate.Text = "Usuń nazwiska z BWS";
            this.bTruncate.Click += new System.EventHandler(this.bTruncate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip3);
            this.tabPage3.Controls.Add(this.lRecordSections);
            this.tabPage3.Controls.Add(this.cblSections);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(569, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rozkłady";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.White;
            this.toolStrip3.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bLoadHands,
            this.bClearHands});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(563, 25);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // bLoadHands
            // 
            this.bLoadHands.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bLoadHands.Image = ((System.Drawing.Image)(resources.GetObject("bLoadHands.Image")));
            this.bLoadHands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bLoadHands.Name = "bLoadHands";
            this.bLoadHands.Size = new System.Drawing.Size(122, 22);
            this.bLoadHands.Text = "Wczytaj rozkłady";
            this.bLoadHands.Click += new System.EventHandler(this.bLoadHands_Click);
            // 
            // bClearHands
            // 
            this.bClearHands.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bClearHands.Image = ((System.Drawing.Image)(resources.GetObject("bClearHands.Image")));
            this.bClearHands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bClearHands.Name = "bClearHands";
            this.bClearHands.Size = new System.Drawing.Size(230, 22);
            this.bClearHands.Text = "Usuń rozkłady dla wszystkich sektorów";
            this.bClearHands.Click += new System.EventHandler(this.bClearHands_Click);
            // 
            // lRecordSections
            // 
            this.lRecordSections.AutoSize = true;
            this.lRecordSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRecordSections.Location = new System.Drawing.Point(6, 138);
            this.lRecordSections.Name = "lRecordSections";
            this.lRecordSections.Size = new System.Drawing.Size(54, 13);
            this.lRecordSections.TabIndex = 7;
            this.lRecordSections.Text = "Sektory:";
            // 
            // cblSections
            // 
            this.cblSections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cblSections.CheckOnClick = true;
            this.cblSections.FormattingEnabled = true;
            this.cblSections.Location = new System.Drawing.Point(9, 162);
            this.cblSections.Name = "cblSections";
            this.cblSections.Size = new System.Drawing.Size(546, 285);
            this.cblSections.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(479, 78);
            this.label11.TabIndex = 1;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openPBN
            // 
            this.openPBN.Filter = "PBN|*.pbn";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelFilename,
            this.bLaunch,
            this.bUpdateSession});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(583, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelFilename
            // 
            this.labelFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(0, 22);
            // 
            // bLaunch
            // 
            this.bLaunch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bLaunch.Image = ((System.Drawing.Image)(resources.GetObject("bLaunch.Image")));
            this.bLaunch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bLaunch.Name = "bLaunch";
            this.bLaunch.Size = new System.Drawing.Size(54, 22);
            this.bLaunch.Text = "BCS";
            this.bLaunch.ToolTipText = "Uruchom BCS";
            this.bLaunch.Click += new System.EventHandler(this.bLaunch_Click);
            // 
            // bUpdateSession
            // 
            this.bUpdateSession.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bUpdateSession.Image = ((System.Drawing.Image)(resources.GetObject("bUpdateSession.Image")));
            this.bUpdateSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUpdateSession.Name = "bUpdateSession";
            this.bUpdateSession.Size = new System.Drawing.Size(65, 22);
            this.bUpdateSession.Text = "Update";
            this.bUpdateSession.ToolTipText = "Update ustawień w trakcie sesji";
            this.bUpdateSession.Click += new System.EventHandler(this.updateSession_Click);
            // 
            // namesTimer
            // 
            this.namesTimer.Interval = 3000;
            this.namesTimer.Tick += new System.EventHandler(this.namesTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 590);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Aktywator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.namesPanel.ResumeLayout(false);
            this.namesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamesRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamsTableOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namesGridView)).EndInit();
            this.syncToolStrip.ResumeLayout(false);
            this.syncToolStrip.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status1;
        private System.Windows.Forms.ToolStripStatusLabel status2;
        private System.Windows.Forms.ToolStripStatusLabel status3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox xPINcode;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox xAutoShutDownBPC;
        public System.Windows.Forms.CheckBox xIntermediateResults;
        public System.Windows.Forms.CheckBox xBoardOrderVerification;
        public System.Windows.Forms.CheckBox xMemberNumbersNoBlankEntry;
        public System.Windows.Forms.CheckBox xMemberNumbers;
        public System.Windows.Forms.CheckBox xLeadCard;
        public System.Windows.Forms.CheckBox xShowContract;
        public System.Windows.Forms.CheckBox xShowPairNumbers;
        public System.Windows.Forms.CheckBox xGroupSections;
        public System.Windows.Forms.CheckBox xShowPercentage;
        public System.Windows.Forms.CheckBox xRepeatResults;
        public System.Windows.Forms.CheckBox xShowResults;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.CheckBox xConfirmNP;
        public System.Windows.Forms.CheckBox xShowPlayerNames;
        public System.Windows.Forms.CheckBox xAutoBoardNumber;
        public System.Windows.Forms.CheckBox xScoreCorrection;
        public System.Windows.Forms.CheckBox xAutoShowScoreRecap;
        public System.Windows.Forms.CheckBox xScoreRecap;
        public System.Windows.Forms.CheckBox xNextSeatings;
        public System.Windows.Forms.CheckBox xRemainingBoards;
        public System.Windows.Forms.CheckBox xResetFunctionKey;
        private System.Windows.Forms.Label lTournament;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lTables;
        private System.Windows.Forms.Label lSections;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lSkok;
        public System.Windows.Forms.ComboBox xResultsOverview;
        public System.Windows.Forms.CheckBox xViewHandrecord;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openPBN;
        public System.Windows.Forms.CheckBox xCollectPlay;
        public System.Windows.Forms.CheckBox xCollectBidding;
        public System.Windows.Forms.CheckBox xCheckLeadCard;
        public System.Windows.Forms.CheckedListBox cblSections;
        private System.Windows.Forms.Label lRecordSections;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel labelFilename;
        private System.Windows.Forms.ToolStripButton bLaunch;
        private System.Windows.Forms.ToolStripButton bUpdateSession;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lRequiredVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lDetectedVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lRequiredFirmware;
        private System.Windows.Forms.ToolStripButton bLoad;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton bLoadHands;
        private System.Windows.Forms.ToolStripButton bClearHands;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem bMySQLTournament;
        private System.Windows.Forms.ToolStripMenuItem bRRBTournament;
        private System.Windows.Forms.ToolStripButton bMysqlSettings;
        private System.Windows.Forms.ToolStrip syncToolStrip;
        private System.Windows.Forms.ToolStripButton bSync;
        private System.Windows.Forms.ToolStripButton bForceSync;
        private System.Windows.Forms.ToolStripButton bTruncate;
        private System.Windows.Forms.ToolStripButton bAutoSync;
        private System.Windows.Forms.ToolStripTextBox eInterval;
        private System.Windows.Forms.ToolStripTextBox eOomRounds;
        private System.Windows.Forms.ToolStripLabel lOomLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView namesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn NorthSouth;
        private System.Windows.Forms.DataGridViewTextBoxColumn EastWest;
        private System.Windows.Forms.Panel namesPanel;
        private System.Windows.Forms.Timer namesTimer;
        public System.Windows.Forms.NumericUpDown numTeamsTableOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numNamesRefreshInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lFirstSectorSettings;
        public System.Windows.Forms.ComboBox cbSettingsSection;
    }
}

