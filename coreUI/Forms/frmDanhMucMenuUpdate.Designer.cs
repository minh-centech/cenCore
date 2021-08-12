namespace coreUI.Forms
{
    partial class frmDanhMucMenuUpdate
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMa = new coreControls.saTextBox();
            this.saLabel2 = new coreControls.saLabel();
            this.txtTen = new coreControls.saTextBox();
            this.txtThuTuHienThi = new coreControls.saNumericBox();
            this.saLabel3 = new coreControls.saLabel();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTuHienThi)).BeginInit();
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
            this.groupEditor.Controls.Add(this.txtThuTuHienThi);
            this.groupEditor.Controls.Add(this.saLabel3);
            this.groupEditor.Controls.Add(this.txtTen);
            this.groupEditor.Controls.Add(this.txtMa);
            this.groupEditor.Controls.Add(this.saLabel2);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 198);
            // 
            // saLabel1
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance6;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(20, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Mã";
            // 
            // txtMa
            // 
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMa.Appearance = appearance4;
            this.txtMa.AutoSize = false;
            this.txtMa.Location = new System.Drawing.Point(102, 7);
            this.txtMa.MaxLength = 128;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(237, 21);
            this.txtMa.TabIndex = 0;
            // 
            // saLabel2
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance5;
            this.saLabel2.AutoSize = true;
            this.saLabel2.Location = new System.Drawing.Point(6, 34);
            this.saLabel2.Name = "saLabel2";
            this.saLabel2.Size = new System.Drawing.Size(24, 14);
            this.saLabel2.TabIndex = 0;
            this.saLabel2.Text = "Tên";
            // 
            // txtTen
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTen.Appearance = appearance3;
            this.txtTen.AutoSize = false;
            this.txtTen.Location = new System.Drawing.Point(102, 34);
            this.txtTen.MaxLength = 255;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(464, 21);
            this.txtTen.TabIndex = 1;
            // 
            // txtThuTuHienThi
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtThuTuHienThi.Appearance = appearance1;
            this.txtThuTuHienThi.AutoSize = false;
            this.txtThuTuHienThi.Location = new System.Drawing.Point(102, 61);
            this.txtThuTuHienThi.MaskInput = "-nnn,nnn,nnn,nnn,nnn";
            this.txtThuTuHienThi.Name = "txtThuTuHienThi";
            this.txtThuTuHienThi.Nullable = true;
            this.txtThuTuHienThi.PromptChar = ' ';
            this.txtThuTuHienThi.Size = new System.Drawing.Size(237, 21);
            this.txtThuTuHienThi.TabIndex = 5;
            this.txtThuTuHienThi.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // saLabel3
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance2;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(6, 61);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(76, 14);
            this.saLabel3.TabIndex = 4;
            this.saLabel3.Text = "Thứ tự hiển thị";
            // 
            // frmDanhMucMenuUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucMenuUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucMenuUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTuHienThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTen;
        private coreControls.saTextBox txtMa;
        private coreControls.saLabel saLabel2;
        private coreControls.saLabel saLabel1;
        private coreControls.saNumericBox txtThuTuHienThi;
        private coreControls.saLabel saLabel3;
    }
}