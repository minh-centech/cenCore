namespace coreUI.Forms
{
    partial class frmDanhMucMenuLoaiDoiTuongUpdate
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMaDanhMucLoaiDoiTuong = new coreControls.saTextBox();
            this.txtTenDanhMucLoaiDoiTuong = new coreControls.saTextBox();
            this.txtThuTuHienThi = new coreControls.saNumericBox();
            this.txtNoiDungHienThi = new coreControls.saTextBox();
            this.saLabel3 = new coreControls.saLabel();
            this.saLabel2 = new coreControls.saLabel();
            this.chkTachNhom = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucLoaiDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucLoaiDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTuHienThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungHienThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTachNhom)).BeginInit();
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
            this.groupEditor.Controls.Add(this.chkTachNhom);
            this.groupEditor.Controls.Add(this.txtThuTuHienThi);
            this.groupEditor.Controls.Add(this.txtNoiDungHienThi);
            this.groupEditor.Controls.Add(this.saLabel3);
            this.groupEditor.Controls.Add(this.saLabel2);
            this.groupEditor.Controls.Add(this.txtTenDanhMucLoaiDoiTuong);
            this.groupEditor.Controls.Add(this.txtMaDanhMucLoaiDoiTuong);
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
            this.saLabel1.Size = new System.Drawing.Size(75, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Loại đối tượng";
            // 
            // txtMaDanhMucLoaiDoiTuong
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucLoaiDoiTuong.Appearance = appearance7;
            this.txtMaDanhMucLoaiDoiTuong.AutoSize = false;
            this.txtMaDanhMucLoaiDoiTuong.Location = new System.Drawing.Point(101, 7);
            this.txtMaDanhMucLoaiDoiTuong.MaxLength = 128;
            this.txtMaDanhMucLoaiDoiTuong.Name = "txtMaDanhMucLoaiDoiTuong";
            this.txtMaDanhMucLoaiDoiTuong.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucLoaiDoiTuong.TabIndex = 0;
            // 
            // txtTenDanhMucLoaiDoiTuong
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucLoaiDoiTuong.Appearance = appearance6;
            this.txtTenDanhMucLoaiDoiTuong.AutoSize = false;
            this.txtTenDanhMucLoaiDoiTuong.Location = new System.Drawing.Point(274, 7);
            this.txtTenDanhMucLoaiDoiTuong.MaxLength = 255;
            this.txtTenDanhMucLoaiDoiTuong.Name = "txtTenDanhMucLoaiDoiTuong";
            this.txtTenDanhMucLoaiDoiTuong.Size = new System.Drawing.Size(292, 21);
            this.txtTenDanhMucLoaiDoiTuong.TabIndex = 1;
            this.txtTenDanhMucLoaiDoiTuong.ValueChanged += new System.EventHandler(this.txtTenDanhMucLoaiDoiTuong_ValueChanged);
            // 
            // txtThuTuHienThi
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtThuTuHienThi.Appearance = appearance2;
            this.txtThuTuHienThi.AutoSize = false;
            this.txtThuTuHienThi.FormatString = "##,###0";
            this.txtThuTuHienThi.Location = new System.Drawing.Point(101, 84);
            this.txtThuTuHienThi.MaskInput = "-nnn,nnn,nnn,nnn,nnn";
            this.txtThuTuHienThi.Name = "txtThuTuHienThi";
            this.txtThuTuHienThi.Nullable = true;
            this.txtThuTuHienThi.PromptChar = ' ';
            this.txtThuTuHienThi.Size = new System.Drawing.Size(167, 21);
            this.txtThuTuHienThi.TabIndex = 12;
            this.txtThuTuHienThi.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // txtNoiDungHienThi
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtNoiDungHienThi.Appearance = appearance3;
            this.txtNoiDungHienThi.AutoSize = false;
            this.txtNoiDungHienThi.Location = new System.Drawing.Point(101, 34);
            this.txtNoiDungHienThi.MaxLength = 128;
            this.txtNoiDungHienThi.Name = "txtNoiDungHienThi";
            this.txtNoiDungHienThi.Size = new System.Drawing.Size(465, 21);
            this.txtNoiDungHienThi.TabIndex = 10;
            // 
            // saLabel3
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance4;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(6, 84);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(76, 14);
            this.saLabel3.TabIndex = 8;
            this.saLabel3.Text = "Thứ tự hiển thị";
            // 
            // saLabel2
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance5;
            this.saLabel2.AutoSize = true;
            this.saLabel2.Location = new System.Drawing.Point(6, 33);
            this.saLabel2.Name = "saLabel2";
            this.saLabel2.Size = new System.Drawing.Size(89, 14);
            this.saLabel2.TabIndex = 9;
            this.saLabel2.Text = "Nội dung hiển thị";
            // 
            // chkTachNhom
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkTachNhom.Appearance = appearance1;
            this.chkTachNhom.AutoSize = true;
            this.chkTachNhom.BackColor = System.Drawing.Color.Transparent;
            this.chkTachNhom.Location = new System.Drawing.Point(101, 61);
            this.chkTachNhom.Name = "chkTachNhom";
            this.chkTachNhom.Size = new System.Drawing.Size(78, 17);
            this.chkTachNhom.TabIndex = 11;
            this.chkTachNhom.Text = "Tách nhóm";
            // 
            // frmDanhMucMenuLoaiDoiTuongUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucMenuLoaiDoiTuongUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucLoaiDoiTuongUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucLoaiDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucLoaiDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTuHienThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungHienThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTachNhom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucLoaiDoiTuong;
        private coreControls.saTextBox txtMaDanhMucLoaiDoiTuong;
        private coreControls.saLabel saLabel1;
        private coreControls.saNumericBox txtThuTuHienThi;
        private coreControls.saTextBox txtNoiDungHienThi;
        private coreControls.saLabel saLabel3;
        private coreControls.saLabel saLabel2;
        private coreControls.saCheckBox chkTachNhom;
    }
}