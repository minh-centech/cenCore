namespace coreUI.Forms
{
    partial class frmDanhMucNguoiSuDungUpdate
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMaDanhMucPhanQuyen = new coreControls.saTextBox();
            this.txtTenDanhMucPhanQuyen = new coreControls.saTextBox();
            this.txtMa = new coreControls.saTextBox();
            this.saLabel2 = new coreControls.saLabel();
            this.saLabel3 = new coreControls.saLabel();
            this.txtTen = new coreControls.saTextBox();
            this.chkAdmin = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucPhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucPhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Size = new System.Drawing.Size(580, 229);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(399, 203);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(491, 203);
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Location = new System.Drawing.Point(267, 203);
            // 
            // groupEditor
            // 
            this.groupEditor.Controls.Add(this.chkAdmin);
            this.groupEditor.Controls.Add(this.txtTen);
            this.groupEditor.Controls.Add(this.txtMa);
            this.groupEditor.Controls.Add(this.saLabel2);
            this.groupEditor.Controls.Add(this.txtTenDanhMucPhanQuyen);
            this.groupEditor.Controls.Add(this.saLabel3);
            this.groupEditor.Controls.Add(this.txtMaDanhMucPhanQuyen);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 198);
            // 
            // saLabel1
            // 
            appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance8;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(20, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Mã";
            // 
            // txtMaDanhMucPhanQuyen
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucPhanQuyen.Appearance = appearance7;
            this.txtMaDanhMucPhanQuyen.AutoSize = false;
            this.txtMaDanhMucPhanQuyen.Location = new System.Drawing.Point(101, 60);
            this.txtMaDanhMucPhanQuyen.MaxLength = 128;
            this.txtMaDanhMucPhanQuyen.Name = "txtMaDanhMucPhanQuyen";
            this.txtMaDanhMucPhanQuyen.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucPhanQuyen.TabIndex = 2;
            // 
            // txtTenDanhMucPhanQuyen
            // 
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucPhanQuyen.Appearance = appearance5;
            this.txtTenDanhMucPhanQuyen.AutoSize = false;
            this.txtTenDanhMucPhanQuyen.Location = new System.Drawing.Point(274, 60);
            this.txtTenDanhMucPhanQuyen.MaxLength = 255;
            this.txtTenDanhMucPhanQuyen.Name = "txtTenDanhMucPhanQuyen";
            this.txtTenDanhMucPhanQuyen.Size = new System.Drawing.Size(292, 21);
            this.txtTenDanhMucPhanQuyen.TabIndex = 3;
            // 
            // txtMa
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMa.Appearance = appearance3;
            this.txtMa.AutoSize = false;
            this.txtMa.Location = new System.Drawing.Point(101, 6);
            this.txtMa.MaxLength = 128;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(167, 21);
            this.txtMa.TabIndex = 0;
            // 
            // saLabel2
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance4;
            this.saLabel2.AutoSize = true;
            this.saLabel2.Location = new System.Drawing.Point(6, 60);
            this.saLabel2.Name = "saLabel2";
            this.saLabel2.Size = new System.Drawing.Size(65, 14);
            this.saLabel2.TabIndex = 5;
            this.saLabel2.Text = "Phân quyền";
            // 
            // saLabel3
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance6;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(6, 33);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(24, 14);
            this.saLabel3.TabIndex = 0;
            this.saLabel3.Text = "Tên";
            // 
            // txtTen
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTen.Appearance = appearance2;
            this.txtTen.AutoSize = false;
            this.txtTen.Location = new System.Drawing.Point(101, 33);
            this.txtTen.MaxLength = 128;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(465, 21);
            this.txtTen.TabIndex = 1;
            // 
            // chkAdmin
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkAdmin.Appearance = appearance1;
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.chkAdmin.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkAdmin.Location = new System.Drawing.Point(101, 88);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(105, 17);
            this.chkAdmin.TabIndex = 4;
            this.chkAdmin.Text = "Là người quản trị";
            // 
            // frmDanhMucNguoiSuDungUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucNguoiSuDungUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucChungTuUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucPhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucPhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucPhanQuyen;
        private coreControls.saTextBox txtMaDanhMucPhanQuyen;
        private coreControls.saLabel saLabel1;
        private coreControls.saTextBox txtMa;
        private coreControls.saLabel saLabel2;
        private coreControls.saTextBox txtTen;
        private coreControls.saLabel saLabel3;
        private coreControls.saCheckBox chkAdmin;
    }
}