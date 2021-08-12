namespace coreBase.Forms
{
    partial class frmChangePassword
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uDA = new Infragistics.Win.Misc.UltraDesktopAlert(this.components);
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.groupEditor = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtOldPassword = new coreControls.saTextBox();
            this.txtNewPassword2 = new coreControls.saTextBox();
            this.txtNewPassword1 = new coreControls.saTextBox();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            this.cmdSave = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.uDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel3
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel3.Appearance = appearance1;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(6, 66);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(125, 14);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Tag = "NgonNgu";
            this.ultraLabel3.Text = "Xác nhận password mới";
            // 
            // ultraLabel2
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(6, 39);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(75, 14);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Tag = "NamLamViec";
            this.ultraLabel2.Text = "Password mới";
            // 
            // ultraLabel1
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(6, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(69, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Tag = "DonVi";
            this.ultraLabel1.Text = "Password cũ";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.ultraGroupBox1.Controls.Add(this.groupEditor);
            this.ultraGroupBox1.Controls.Add(this.cmdCancel);
            this.ultraGroupBox1.Controls.Add(this.cmdSave);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(348, 130);
            this.ultraGroupBox1.TabIndex = 4;
            // 
            // groupEditor
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.groupEditor.Appearance = appearance4;
            this.groupEditor.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.groupEditor.Controls.Add(this.txtOldPassword);
            this.groupEditor.Controls.Add(this.txtNewPassword2);
            this.groupEditor.Controls.Add(this.ultraLabel1);
            this.groupEditor.Controls.Add(this.txtNewPassword1);
            this.groupEditor.Controls.Add(this.ultraLabel2);
            this.groupEditor.Controls.Add(this.ultraLabel3);
            this.groupEditor.Location = new System.Drawing.Point(3, 3);
            this.groupEditor.Name = "groupEditor";
            this.groupEditor.Size = new System.Drawing.Size(344, 100);
            this.groupEditor.TabIndex = 1;
            this.groupEditor.UseAppStyling = false;
            // 
            // txtOldPassword
            // 
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtOldPassword.Appearance = appearance5;
            this.txtOldPassword.AutoSize = false;
            this.txtOldPassword.Location = new System.Drawing.Point(138, 12);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(200, 21);
            this.txtOldPassword.TabIndex = 0;
            // 
            // txtNewPassword2
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtNewPassword2.Appearance = appearance6;
            this.txtNewPassword2.AutoSize = false;
            this.txtNewPassword2.Location = new System.Drawing.Point(138, 66);
            this.txtNewPassword2.Name = "txtNewPassword2";
            this.txtNewPassword2.PasswordChar = '*';
            this.txtNewPassword2.Size = new System.Drawing.Size(200, 21);
            this.txtNewPassword2.TabIndex = 2;
            // 
            // txtNewPassword1
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtNewPassword1.Appearance = appearance7;
            this.txtNewPassword1.AutoSize = false;
            this.txtNewPassword1.Location = new System.Drawing.Point(138, 39);
            this.txtNewPassword1.Name = "txtNewPassword1";
            this.txtNewPassword1.PasswordChar = '*';
            this.txtNewPassword1.Size = new System.Drawing.Size(200, 21);
            this.txtNewPassword1.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance8.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.cmdCancel.Appearance = appearance8;
            this.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdCancel.CausesValidation = false;
            this.cmdCancel.Location = new System.Drawing.Point(276, 104);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(69, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Tag = "cmdclose";
            this.cmdCancel.Text = "Đó&ng";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance9.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.cmdSave.Appearance = appearance9;
            this.cmdSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdSave.Location = new System.Drawing.Point(201, 104);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(69, 23);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Tag = "cmdsave";
            this.cmdSave.Text = "&Lưu";
            this.cmdSave.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 130);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu đăng nhập";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private coreControls.saTextBox txtOldPassword;
        private coreControls.saTextBox txtNewPassword2;
        private coreControls.saTextBox txtNewPassword1;
        private Infragistics.Win.Misc.UltraDesktopAlert uDA;
        public Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        public Infragistics.Win.Misc.UltraGroupBox groupEditor;
        public Infragistics.Win.Misc.UltraButton cmdCancel;
        public Infragistics.Win.Misc.UltraButton cmdSave;
    }
}