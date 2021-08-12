namespace coreUI.Forms
{
    partial class frmDanhMucPhanQuyenChungTuUpdate
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMaDanhMucChungTu = new coreControls.saTextBox();
            this.txtTenDanhMucChungTu = new coreControls.saTextBox();
            this.chkXem = new coreControls.saCheckBox();
            this.chkThem = new coreControls.saCheckBox();
            this.chkSua = new coreControls.saCheckBox();
            this.chkXoa = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Size = new System.Drawing.Size(580, 231);
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
            this.groupEditor.Controls.Add(this.chkXoa);
            this.groupEditor.Controls.Add(this.chkSua);
            this.groupEditor.Controls.Add(this.chkThem);
            this.groupEditor.Controls.Add(this.chkXem);
            this.groupEditor.Controls.Add(this.txtTenDanhMucChungTu);
            this.groupEditor.Controls.Add(this.txtMaDanhMucChungTu);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 199);
            // 
            // saLabel1
            // 
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance7;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(50, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Chứng từ";
            // 
            // txtMaDanhMucChungTu
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucChungTu.Appearance = appearance6;
            this.txtMaDanhMucChungTu.AutoSize = false;
            this.txtMaDanhMucChungTu.Enabled = false;
            this.txtMaDanhMucChungTu.Location = new System.Drawing.Point(87, 7);
            this.txtMaDanhMucChungTu.MaxLength = 128;
            this.txtMaDanhMucChungTu.Name = "txtMaDanhMucChungTu";
            this.txtMaDanhMucChungTu.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucChungTu.TabIndex = 0;
            // 
            // txtTenDanhMucChungTu
            // 
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucChungTu.Appearance = appearance5;
            this.txtTenDanhMucChungTu.AutoSize = false;
            this.txtTenDanhMucChungTu.Location = new System.Drawing.Point(260, 7);
            this.txtTenDanhMucChungTu.MaxLength = 255;
            this.txtTenDanhMucChungTu.Name = "txtTenDanhMucChungTu";
            this.txtTenDanhMucChungTu.Size = new System.Drawing.Size(306, 21);
            this.txtTenDanhMucChungTu.TabIndex = 1;
            // 
            // chkXem
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkXem.Appearance = appearance4;
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.Color.Transparent;
            this.chkXem.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkXem.Location = new System.Drawing.Point(87, 35);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(119, 17);
            this.chkXem.TabIndex = 2;
            this.chkXem.Text = "Được phép truy cập";
            this.chkXem.CheckedChanged += new System.EventHandler(this.chkXem_CheckedChanged);
            // 
            // chkThem
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkThem.Appearance = appearance3;
            this.chkThem.AutoSize = true;
            this.chkThem.BackColor = System.Drawing.Color.Transparent;
            this.chkThem.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkThem.Location = new System.Drawing.Point(87, 58);
            this.chkThem.Name = "chkThem";
            this.chkThem.Size = new System.Drawing.Size(104, 17);
            this.chkThem.TabIndex = 3;
            this.chkThem.Text = "Được phép thêm";
            // 
            // chkSua
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkSua.Appearance = appearance2;
            this.chkSua.AutoSize = true;
            this.chkSua.BackColor = System.Drawing.Color.Transparent;
            this.chkSua.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkSua.Location = new System.Drawing.Point(87, 81);
            this.chkSua.Name = "chkSua";
            this.chkSua.Size = new System.Drawing.Size(97, 17);
            this.chkSua.TabIndex = 4;
            this.chkSua.Text = "Được phép sửa";
            // 
            // chkXoa
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkXoa.Appearance = appearance1;
            this.chkXoa.AutoSize = true;
            this.chkXoa.BackColor = System.Drawing.Color.Transparent;
            this.chkXoa.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkXoa.Location = new System.Drawing.Point(87, 104);
            this.chkXoa.Name = "chkXoa";
            this.chkXoa.Size = new System.Drawing.Size(97, 17);
            this.chkXoa.TabIndex = 5;
            this.chkXoa.Text = "Được phép xóa";
            // 
            // frmDanhMucPhanQuyenChungTuUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucPhanQuyenChungTuUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucChungTuUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucChungTu;
        private coreControls.saTextBox txtMaDanhMucChungTu;
        private coreControls.saLabel saLabel1;
        private coreControls.saCheckBox chkXem;
        private coreControls.saCheckBox chkXoa;
        private coreControls.saCheckBox chkSua;
        private coreControls.saCheckBox chkThem;
    }
}