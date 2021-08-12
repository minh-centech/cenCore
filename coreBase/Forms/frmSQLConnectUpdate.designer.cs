namespace coreBase.Forms
{
    partial class frmSQLConnectUpdate
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.lblPassword = new Infragistics.Win.Misc.UltraLabel();
            this.lblUserName = new Infragistics.Win.Misc.UltraLabel();
            this.cmdOK = new Infragistics.Win.Misc.UltraButton();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtUserName = new coreControls.saTextBox();
            this.txtPassword = new coreControls.saTextBox();
            this.txtServer = new coreControls.saTextBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtData = new coreControls.saTextBox();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmdTestConnection = new Infragistics.Win.Misc.UltraButton();
            this.txtMoTa = new coreControls.saTextBox();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.lblPassword.Appearance = appearance1;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(26, 114);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(54, 14);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Tag = "UserName";
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.lblUserName.Appearance = appearance2;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(26, 87);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Tag = "UserName";
            this.lblUserName.Text = "UserName";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(237, 154);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Tag = "cmdok";
            this.cmdOK.Text = "&OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(318, 154);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(74, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Tag = "cmdclose";
            this.cmdCancel.Text = "Đó&ng";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox2);
            this.ultraGroupBox1.Controls.Add(this.cmdTestConnection);
            this.ultraGroupBox1.Controls.Add(this.cmdOK);
            this.ultraGroupBox1.Controls.Add(this.cmdCancel);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(398, 183);
            this.ultraGroupBox1.TabIndex = 6;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.ultraGroupBox2.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.txtData);
            this.ultraGroupBox2.Controls.Add(this.txtMoTa);
            this.ultraGroupBox2.Controls.Add(this.txtServer);
            this.ultraGroupBox2.Controls.Add(this.lblUserName);
            this.ultraGroupBox2.Controls.Add(this.txtUserName);
            this.ultraGroupBox2.Controls.Add(this.lblPassword);
            this.ultraGroupBox2.Controls.Add(this.txtPassword);
            this.ultraGroupBox2.Location = new System.Drawing.Point(6, 6);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(386, 145);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.UseAppStyling = false;
            // 
            // txtUserName
            // 
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtUserName.Appearance = appearance10;
            this.txtUserName.AutoSize = false;
            this.txtUserName.Location = new System.Drawing.Point(103, 87);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(277, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtPassword.Appearance = appearance11;
            this.txtPassword.AutoSize = false;
            this.txtPassword.Location = new System.Drawing.Point(103, 114);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(277, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // txtServer
            // 
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtServer.Appearance = appearance9;
            this.txtServer.AutoSize = false;
            this.txtServer.Location = new System.Drawing.Point(74, 33);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(306, 21);
            this.txtServer.TabIndex = 1;
            // 
            // ultraLabel1
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel1.Appearance = appearance6;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(6, 33);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(38, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Tag = "UserName";
            this.ultraLabel1.Text = "Server";
            // 
            // txtData
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtData.Appearance = appearance7;
            this.txtData.AutoSize = false;
            this.txtData.Location = new System.Drawing.Point(74, 60);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(306, 21);
            this.txtData.TabIndex = 2;
            // 
            // ultraLabel2
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(6, 60);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(28, 14);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Tag = "UserName";
            this.ultraLabel2.Text = "Data";
            // 
            // cmdTestConnection
            // 
            this.cmdTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestConnection.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdTestConnection.Location = new System.Drawing.Point(6, 154);
            this.cmdTestConnection.Name = "cmdTestConnection";
            this.cmdTestConnection.Size = new System.Drawing.Size(75, 23);
            this.cmdTestConnection.TabIndex = 3;
            this.cmdTestConnection.Tag = "cmdok";
            this.cmdTestConnection.Text = "&Test";
            this.cmdTestConnection.Click += new System.EventHandler(this.cmdTestConnection_Click);
            // 
            // txtMoTa
            // 
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMoTa.Appearance = appearance8;
            this.txtMoTa.AutoSize = false;
            this.txtMoTa.Location = new System.Drawing.Point(74, 6);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(306, 21);
            this.txtMoTa.TabIndex = 0;
            // 
            // ultraLabel3
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel3.Appearance = appearance5;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(6, 6);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(32, 14);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Tag = "UserName";
            this.ultraLabel3.Text = "Mô tả";
            // 
            // frmSQLConnectUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 183);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSQLConnectUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khai báo kết nối dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton cmdOK;
        private Infragistics.Win.Misc.UltraButton cmdCancel;
        private Infragistics.Win.Misc.UltraLabel lblPassword;
        private Infragistics.Win.Misc.UltraLabel lblUserName;
        private coreControls.saTextBox txtUserName;
        private coreControls.saTextBox txtPassword;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private coreControls.saTextBox txtData;
        private coreControls.saTextBox txtServer;
        private Infragistics.Win.Misc.UltraButton cmdTestConnection;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private coreControls.saTextBox txtMoTa;
    }
}