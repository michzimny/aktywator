namespace Aktywator
{
    partial class MysqlSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MysqlSettings));
            this.eHost = new System.Windows.Forms.TextBox();
            this.eUser = new System.Windows.Forms.TextBox();
            this.ePass = new System.Windows.Forms.TextBox();
            this.ePort = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eHost
            // 
            this.eHost.Location = new System.Drawing.Point(12, 12);
            this.eHost.Name = "eHost";
            this.eHost.Size = new System.Drawing.Size(100, 20);
            this.eHost.TabIndex = 0;
            // 
            // eUser
            // 
            this.eUser.Location = new System.Drawing.Point(12, 38);
            this.eUser.Name = "eUser";
            this.eUser.Size = new System.Drawing.Size(100, 20);
            this.eUser.TabIndex = 1;
            // 
            // ePass
            // 
            this.ePass.Location = new System.Drawing.Point(12, 64);
            this.ePass.Name = "ePass";
            this.ePass.PasswordChar = '*';
            this.ePass.Size = new System.Drawing.Size(100, 20);
            this.ePass.TabIndex = 2;
            // 
            // ePort
            // 
            this.ePort.Location = new System.Drawing.Point(12, 90);
            this.ePort.Name = "ePort";
            this.ePort.Size = new System.Drawing.Size(100, 20);
            this.ePort.TabIndex = 3;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(12, 116);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(100, 23);
            this.bOk.TabIndex = 4;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // MysqlSettings
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 147);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.ePort);
            this.Controls.Add(this.ePass);
            this.Controls.Add(this.eUser);
            this.Controls.Add(this.eHost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MysqlSettings";
            this.Text = "Ustawienia MySQL";
            this.Load += new System.EventHandler(this.MysqlSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eHost;
        private System.Windows.Forms.TextBox eUser;
        private System.Windows.Forms.TextBox ePass;
        private System.Windows.Forms.TextBox ePort;
        private System.Windows.Forms.Button bOk;
    }
}