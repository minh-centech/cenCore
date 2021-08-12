namespace coreUI.Forms
{
    partial class frmDanhMucChungTuTrangThaiUpdate
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMa = new coreControls.saTextBox();
            this.saLabel2 = new coreControls.saLabel();
            this.txtTen = new coreControls.saTextBox();
            this.chkHachToan = new coreControls.saCheckBox();
            this.chkSua = new coreControls.saCheckBox();
            this.chkXoa = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHachToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXoa)).BeginInit();
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
            this.groupEditor.Controls.Add(this.chkXoa);
            this.groupEditor.Controls.Add(this.chkSua);
            this.groupEditor.Controls.Add(this.chkHachToan);
            this.groupEditor.Controls.Add(this.txtTen);
            this.groupEditor.Controls.Add(this.txtMa);
            this.groupEditor.Controls.Add(this.saLabel2);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 198);
            // 
            // saLabel1
            // 
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance7;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(20, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Mã";
            // 
            // txtMa
            // 
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMa.Appearance = appearance5;
            this.txtMa.AutoSize = false;
            this.txtMa.Location = new System.Drawing.Point(87, 7);
            this.txtMa.MaxLength = 128;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(252, 21);
            this.txtMa.TabIndex = 0;
            // 
            // saLabel2
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance6;
            this.saLabel2.AutoSize = true;
            this.saLabel2.Location = new System.Drawing.Point(6, 34);
            this.saLabel2.Name = "saLabel2";
            this.saLabel2.Size = new System.Drawing.Size(24, 14);
            this.saLabel2.TabIndex = 0;
            this.saLabel2.Text = "Tên";
            // 
            // txtTen
            // 
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTen.Appearance = appearance4;
            this.txtTen.AutoSize = false;
            this.txtTen.Location = new System.Drawing.Point(87, 34);
            this.txtTen.MaxLength = 255;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(479, 21);
            this.txtTen.TabIndex = 1;
            // 
            // chkHachToan
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkHachToan.Appearance = appearance3;
            this.chkHachToan.AutoSize = true;
            this.chkHachToan.BackColor = System.Drawing.Color.Transparent;
            this.chkHachToan.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkHachToan.Location = new System.Drawing.Point(87, 62);
            this.chkHachToan.Name = "chkHachToan";
            this.chkHachToan.Size = new System.Drawing.Size(128, 17);
            this.chkHachToan.TabIndex = 2;
            this.chkHachToan.Text = "Được phép hạch toán";
            // 
            // chkSua
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkSua.Appearance = appearance2;
            this.chkSua.AutoSize = true;
            this.chkSua.BackColor = System.Drawing.Color.Transparent;
            this.chkSua.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkSua.Location = new System.Drawing.Point(87, 85);
            this.chkSua.Name = "chkSua";
            this.chkSua.Size = new System.Drawing.Size(97, 17);
            this.chkSua.TabIndex = 3;
            this.chkSua.Text = "Được phép sửa";
            // 
            // chkXoa
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkXoa.Appearance = appearance1;
            this.chkXoa.AutoSize = true;
            this.chkXoa.BackColor = System.Drawing.Color.Transparent;
            this.chkXoa.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkXoa.Location = new System.Drawing.Point(87, 108);
            this.chkXoa.Name = "chkXoa";
            this.chkXoa.Size = new System.Drawing.Size(97, 17);
            this.chkXoa.TabIndex = 4;
            this.chkXoa.Text = "Được phép xóa";
            // 
            // frmDanhMucChungTuTrangThaiUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucChungTuTrangThaiUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucDonViUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHachToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTen;
        private coreControls.saTextBox txtMa;
        private coreControls.saLabel saLabel2;
        private coreControls.saLabel saLabel1;
        private coreControls.saCheckBox chkXoa;
        private coreControls.saCheckBox chkSua;
        private coreControls.saCheckBox chkHachToan;
    }
}