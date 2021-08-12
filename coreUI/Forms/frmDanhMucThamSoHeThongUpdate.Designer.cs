namespace coreUI.Forms
{
    partial class frmDanhMucThamSoHeThongUpdate
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMa = new coreControls.saTextBox();
            this.saLabel2 = new coreControls.saLabel();
            this.txtTen = new coreControls.saTextBox();
            this.saLabel3 = new coreControls.saLabel();
            this.txtGiaTri = new coreControls.saTextBox();
            this.saLabel4 = new coreControls.saLabel();
            this.txtGhiChu = new coreControls.saTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
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
            this.groupEditor.Controls.Add(this.txtGhiChu);
            this.groupEditor.Controls.Add(this.txtGiaTri);
            this.groupEditor.Controls.Add(this.saLabel4);
            this.groupEditor.Controls.Add(this.txtTen);
            this.groupEditor.Controls.Add(this.saLabel3);
            this.groupEditor.Controls.Add(this.txtMa);
            this.groupEditor.Controls.Add(this.saLabel2);
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
            // txtMa
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMa.Appearance = appearance6;
            this.txtMa.AutoSize = false;
            this.txtMa.Location = new System.Drawing.Point(72, 7);
            this.txtMa.MaxLength = 128;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(267, 21);
            this.txtMa.TabIndex = 0;
            // 
            // saLabel2
            // 
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance7;
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
            this.txtTen.Location = new System.Drawing.Point(72, 34);
            this.txtTen.MaxLength = 255;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(494, 21);
            this.txtTen.TabIndex = 1;
            // 
            // saLabel3
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance5;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(6, 61);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(34, 14);
            this.saLabel3.TabIndex = 0;
            this.saLabel3.Text = "Giá trị";
            // 
            // txtGiaTri
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtGiaTri.Appearance = appearance2;
            this.txtGiaTri.AutoSize = false;
            this.txtGiaTri.Location = new System.Drawing.Point(72, 61);
            this.txtGiaTri.MaxLength = 255;
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(494, 21);
            this.txtGiaTri.TabIndex = 2;
            // 
            // saLabel4
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel4.Appearance = appearance3;
            this.saLabel4.AutoSize = true;
            this.saLabel4.Location = new System.Drawing.Point(6, 88);
            this.saLabel4.Name = "saLabel4";
            this.saLabel4.Size = new System.Drawing.Size(43, 14);
            this.saLabel4.TabIndex = 0;
            this.saLabel4.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtGhiChu.Appearance = appearance1;
            this.txtGhiChu.AutoSize = false;
            this.txtGhiChu.Location = new System.Drawing.Point(72, 88);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(494, 21);
            this.txtGhiChu.TabIndex = 3;
            // 
            // frmDanhMucThamSoHeThongUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucThamSoHeThongUpdate";
            this.Text = "frmDanhMucThamSoHeThongUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucThamSoHeThongUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTen;
        private coreControls.saTextBox txtMa;
        private coreControls.saLabel saLabel2;
        private coreControls.saLabel saLabel1;
        private coreControls.saTextBox txtGhiChu;
        private coreControls.saTextBox txtGiaTri;
        private coreControls.saLabel saLabel4;
        private coreControls.saLabel saLabel3;
    }
}