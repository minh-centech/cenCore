namespace coreUI.Forms
{
    partial class frmDanhMucPhanQuyenLoaiDoiTuongUpdate
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
            this.txtMaDanhMucLoaiDoiTuong = new coreControls.saTextBox();
            this.txtTenDanhMucLoaiDoiTuong = new coreControls.saTextBox();
            this.chkXem = new coreControls.saCheckBox();
            this.chkThem = new coreControls.saCheckBox();
            this.chkSua = new coreControls.saCheckBox();
            this.chkXoa = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucLoaiDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucLoaiDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Size = new System.Drawing.Size(578, 229);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(397, 203);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(489, 203);
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Location = new System.Drawing.Point(265, 203);
            // 
            // groupEditor
            // 
            this.groupEditor.Controls.Add(this.chkXoa);
            this.groupEditor.Controls.Add(this.chkSua);
            this.groupEditor.Controls.Add(this.chkThem);
            this.groupEditor.Controls.Add(this.chkXem);
            this.groupEditor.Controls.Add(this.txtTenDanhMucLoaiDoiTuong);
            this.groupEditor.Controls.Add(this.txtMaDanhMucLoaiDoiTuong);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(572, 199);
            // 
            // saLabel1
            // 
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance7;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(4, 8);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(75, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Loại đối tượng";
            // 
            // txtMaDanhMucLoaiDoiTuong
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucLoaiDoiTuong.Appearance = appearance6;
            this.txtMaDanhMucLoaiDoiTuong.AutoSize = false;
            this.txtMaDanhMucLoaiDoiTuong.Enabled = false;
            this.txtMaDanhMucLoaiDoiTuong.Location = new System.Drawing.Point(85, 9);
            this.txtMaDanhMucLoaiDoiTuong.MaxLength = 128;
            this.txtMaDanhMucLoaiDoiTuong.Name = "txtMaDanhMucLoaiDoiTuong";
            this.txtMaDanhMucLoaiDoiTuong.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucLoaiDoiTuong.TabIndex = 0;
            // 
            // txtTenDanhMucLoaiDoiTuong
            // 
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucLoaiDoiTuong.Appearance = appearance5;
            this.txtTenDanhMucLoaiDoiTuong.AutoSize = false;
            this.txtTenDanhMucLoaiDoiTuong.Location = new System.Drawing.Point(258, 9);
            this.txtTenDanhMucLoaiDoiTuong.MaxLength = 255;
            this.txtTenDanhMucLoaiDoiTuong.Name = "txtTenDanhMucLoaiDoiTuong";
            this.txtTenDanhMucLoaiDoiTuong.Size = new System.Drawing.Size(306, 21);
            this.txtTenDanhMucLoaiDoiTuong.TabIndex = 1;
            // 
            // chkXem
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkXem.Appearance = appearance4;
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.Color.Transparent;
            this.chkXem.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkXem.Location = new System.Drawing.Point(85, 37);
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
            this.chkThem.Location = new System.Drawing.Point(85, 60);
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
            this.chkSua.Location = new System.Drawing.Point(85, 83);
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
            this.chkXoa.Location = new System.Drawing.Point(85, 106);
            this.chkXoa.Name = "chkXoa";
            this.chkXoa.Size = new System.Drawing.Size(97, 17);
            this.chkXoa.TabIndex = 5;
            this.chkXoa.Text = "Được phép xóa";
            // 
            // frmDanhMucPhanQuyenLoaiDoiTuongUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucPhanQuyenLoaiDoiTuongUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucLoaiDoiTuongUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucLoaiDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucLoaiDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucLoaiDoiTuong;
        private coreControls.saTextBox txtMaDanhMucLoaiDoiTuong;
        private coreControls.saLabel saLabel1;
        private coreControls.saCheckBox chkXem;
        private coreControls.saCheckBox chkXoa;
        private coreControls.saCheckBox chkSua;
        private coreControls.saCheckBox chkThem;
    }
}