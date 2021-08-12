namespace coreUI.Forms
{
    partial class frmDanhMucMenuBaoCaoUpdate
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMaDanhMucBaoCao = new coreControls.saTextBox();
            this.txtTenDanhMucBaoCao = new coreControls.saTextBox();
            this.saLabel2 = new coreControls.saLabel();
            this.txtNoiDungHienThi = new coreControls.saTextBox();
            this.saLabel3 = new coreControls.saLabel();
            this.txtThuTuHienThi = new coreControls.saNumericBox();
            this.chkTachNhom = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungHienThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTuHienThi)).BeginInit();
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
            this.groupEditor.Controls.Add(this.txtTenDanhMucBaoCao);
            this.groupEditor.Controls.Add(this.txtNoiDungHienThi);
            this.groupEditor.Controls.Add(this.saLabel3);
            this.groupEditor.Controls.Add(this.saLabel2);
            this.groupEditor.Controls.Add(this.txtMaDanhMucBaoCao);
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
            this.saLabel1.Size = new System.Drawing.Size(46, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Báo cáo";
            // 
            // txtMaDanhMucBaoCao
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucBaoCao.Appearance = appearance7;
            this.txtMaDanhMucBaoCao.AutoSize = false;
            this.txtMaDanhMucBaoCao.Location = new System.Drawing.Point(101, 7);
            this.txtMaDanhMucBaoCao.MaxLength = 128;
            this.txtMaDanhMucBaoCao.Name = "txtMaDanhMucBaoCao";
            this.txtMaDanhMucBaoCao.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucBaoCao.TabIndex = 0;
            // 
            // txtTenDanhMucBaoCao
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucBaoCao.Appearance = appearance3;
            this.txtTenDanhMucBaoCao.AutoSize = false;
            this.txtTenDanhMucBaoCao.Location = new System.Drawing.Point(274, 7);
            this.txtTenDanhMucBaoCao.MaxLength = 255;
            this.txtTenDanhMucBaoCao.Name = "txtTenDanhMucBaoCao";
            this.txtTenDanhMucBaoCao.Size = new System.Drawing.Size(292, 21);
            this.txtTenDanhMucBaoCao.TabIndex = 1;
            this.txtTenDanhMucBaoCao.ValueChanged += new System.EventHandler(this.txtTenDanhMucBaoCao_ValueChanged);
            // 
            // saLabel2
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance6;
            this.saLabel2.AutoSize = true;
            this.saLabel2.Location = new System.Drawing.Point(6, 33);
            this.saLabel2.Name = "saLabel2";
            this.saLabel2.Size = new System.Drawing.Size(89, 14);
            this.saLabel2.TabIndex = 0;
            this.saLabel2.Text = "Nội dung hiển thị";
            // 
            // txtNoiDungHienThi
            // 
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtNoiDungHienThi.Appearance = appearance4;
            this.txtNoiDungHienThi.AutoSize = false;
            this.txtNoiDungHienThi.Location = new System.Drawing.Point(101, 34);
            this.txtNoiDungHienThi.MaxLength = 128;
            this.txtNoiDungHienThi.Name = "txtNoiDungHienThi";
            this.txtNoiDungHienThi.Size = new System.Drawing.Size(465, 21);
            this.txtNoiDungHienThi.TabIndex = 2;
            // 
            // saLabel3
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance5;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(6, 84);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(76, 14);
            this.saLabel3.TabIndex = 0;
            this.saLabel3.Text = "Thứ tự hiển thị";
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
            this.txtThuTuHienThi.TabIndex = 4;
            this.txtThuTuHienThi.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // chkTachNhom
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkTachNhom.Appearance = appearance1;
            this.chkTachNhom.AutoSize = true;
            this.chkTachNhom.BackColor = System.Drawing.Color.Transparent;
            this.chkTachNhom.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkTachNhom.Location = new System.Drawing.Point(101, 61);
            this.chkTachNhom.Name = "chkTachNhom";
            this.chkTachNhom.Size = new System.Drawing.Size(78, 17);
            this.chkTachNhom.TabIndex = 3;
            this.chkTachNhom.Text = "Tách nhóm";
            // 
            // frmDanhMucMenuBaoCaoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucMenuBaoCaoUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucBaoCaoUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungHienThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTuHienThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTachNhom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucBaoCao;
        private coreControls.saTextBox txtMaDanhMucBaoCao;
        private coreControls.saLabel saLabel1;
        private coreControls.saNumericBox txtThuTuHienThi;
        private coreControls.saTextBox txtNoiDungHienThi;
        private coreControls.saLabel saLabel3;
        private coreControls.saLabel saLabel2;
        private coreControls.saCheckBox chkTachNhom;
    }
}