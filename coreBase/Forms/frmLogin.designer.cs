namespace coreBase.Forms
{
    partial class frmLogin
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.lblPassword = new Infragistics.Win.Misc.UltraLabel();
            this.lblUserName = new Infragistics.Win.Misc.UltraLabel();
            this.cmdOK = new Infragistics.Win.Misc.UltraButton();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            this.cmdSQLConnect = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.cboConnect = new coreControls.saComboDanhMuc();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUserName = new coreControls.saTextBox();
            this.txtPassword = new coreControls.saTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.lblPassword.Appearance = appearance1;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(5, 99);
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
            this.lblUserName.Location = new System.Drawing.Point(5, 72);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(24, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Tag = "UserName";
            this.lblUserName.Text = "Tên";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(240, 176);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Tag = "cmdok";
            this.cmdOK.Text = "&OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(321, 176);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(74, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Tag = "cmdclose";
            this.cmdCancel.Text = "Đó&ng";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSQLConnect
            // 
            this.cmdSQLConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSQLConnect.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdSQLConnect.Location = new System.Drawing.Point(2, 176);
            this.cmdSQLConnect.Name = "cmdSQLConnect";
            this.cmdSQLConnect.Size = new System.Drawing.Size(89, 23);
            this.cmdSQLConnect.TabIndex = 5;
            this.cmdSQLConnect.Tag = "OK";
            this.cmdSQLConnect.Text = "SQL Connect...";
            this.cmdSQLConnect.Click += new System.EventHandler(this.cmdSQLConnect_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.ultraGroupBox1.Controls.Add(this.ultraGroupBox2);
            this.ultraGroupBox1.Controls.Add(this.cmdSQLConnect);
            this.ultraGroupBox1.Controls.Add(this.cmdOK);
            this.ultraGroupBox1.Controls.Add(this.cmdCancel);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(398, 202);
            this.ultraGroupBox1.TabIndex = 6;
            this.ultraGroupBox1.Text = "Đăng nhập";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.ultraGroupBox2.Controls.Add(this.cboConnect);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox2.Controls.Add(this.lblUserName);
            this.ultraGroupBox2.Controls.Add(this.txtUserName);
            this.ultraGroupBox2.Controls.Add(this.lblPassword);
            this.ultraGroupBox2.Controls.Add(this.txtPassword);
            this.ultraGroupBox2.Location = new System.Drawing.Point(3, 19);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(392, 155);
            this.ultraGroupBox2.TabIndex = 0;
            this.ultraGroupBox2.UseAppStyling = false;
            // 
            // cboConnect
            // 
            this.cboConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.cboConnect.Appearance = appearance4;
            this.cboConnect.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboConnect.AutoSize = false;
            this.cboConnect.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboConnect.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboConnect.Location = new System.Drawing.Point(73, 45);
            this.cboConnect.Name = "cboConnect";
            this.cboConnect.Size = new System.Drawing.Size(310, 21);
            this.cboConnect.TabIndex = 0;
            // 
            // ultraLabel1
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel1.Appearance = appearance5;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(6, 45);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(39, 14);
            this.ultraLabel1.TabIndex = 3;
            this.ultraLabel1.Tag = "UserName";
            this.ultraLabel1.Text = "Kết nối";
            // 
            // txtUserName
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtUserName.Appearance = appearance6;
            this.txtUserName.AutoSize = false;
            this.txtUserName.Location = new System.Drawing.Point(73, 72);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(310, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtPassword.Appearance = appearance7;
            this.txtPassword.AutoSize = false;
            this.txtPassword.Location = new System.Drawing.Point(73, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(148, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 202);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton cmdOK;
        private Infragistics.Win.Misc.UltraButton cmdCancel;
        private Infragistics.Win.Misc.UltraLabel lblPassword;
        private Infragistics.Win.Misc.UltraLabel lblUserName;
        private coreControls.saTextBox txtUserName;
        private coreControls.saTextBox txtPassword;
        public Infragistics.Win.Misc.UltraButton cmdSQLConnect;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private coreControls.saComboDanhMuc cboConnect;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}