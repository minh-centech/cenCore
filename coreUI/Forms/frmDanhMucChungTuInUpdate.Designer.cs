namespace coreUI.Forms
{
    partial class frmDanhMucChungTuInUpdate
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMa = new coreControls.saTextBox();
            this.saLabel2 = new coreControls.saLabel();
            this.txtTen = new coreControls.saTextBox();
            this.saLabel3 = new coreControls.saLabel();
            this.txtListProcedureName = new coreControls.saTextBox();
            this.saLabel4 = new coreControls.saLabel();
            this.txtFileMauIn = new coreControls.saTextBox();
            this.txtSoLien = new coreControls.saNumericBox();
            this.saLabel5 = new coreControls.saLabel();
            this.chkPrintPreview = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtListProcedureName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileMauIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Size = new System.Drawing.Size(580, 230);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(399, 204);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(491, 204);
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Location = new System.Drawing.Point(267, 204);
            // 
            // groupEditor
            // 
            this.groupEditor.Controls.Add(this.chkPrintPreview);
            this.groupEditor.Controls.Add(this.txtSoLien);
            this.groupEditor.Controls.Add(this.txtFileMauIn);
            this.groupEditor.Controls.Add(this.txtTen);
            this.groupEditor.Controls.Add(this.txtListProcedureName);
            this.groupEditor.Controls.Add(this.txtMa);
            this.groupEditor.Controls.Add(this.saLabel5);
            this.groupEditor.Controls.Add(this.saLabel4);
            this.groupEditor.Controls.Add(this.saLabel3);
            this.groupEditor.Controls.Add(this.saLabel2);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 199);
            // 
            // saLabel1
            // 
            appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance11;
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
            this.txtMa.Location = new System.Drawing.Point(87, 7);
            this.txtMa.MaxLength = 128;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(252, 21);
            this.txtMa.TabIndex = 0;
            // 
            // saLabel2
            // 
            appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel2.Appearance = appearance10;
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
            // saLabel3
            // 
            appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel3.Appearance = appearance9;
            this.saLabel3.AutoSize = true;
            this.saLabel3.Location = new System.Drawing.Point(6, 60);
            this.saLabel3.Name = "saLabel3";
            this.saLabel3.Size = new System.Drawing.Size(52, 14);
            this.saLabel3.TabIndex = 0;
            this.saLabel3.Text = "Tên store";
            // 
            // txtListProcedureName
            // 
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtListProcedureName.Appearance = appearance5;
            this.txtListProcedureName.AutoSize = false;
            this.txtListProcedureName.Location = new System.Drawing.Point(87, 61);
            this.txtListProcedureName.MaxLength = 128;
            this.txtListProcedureName.Name = "txtListProcedureName";
            this.txtListProcedureName.Size = new System.Drawing.Size(252, 21);
            this.txtListProcedureName.TabIndex = 2;
            // 
            // saLabel4
            // 
            appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel4.Appearance = appearance8;
            this.saLabel4.AutoSize = true;
            this.saLabel4.Location = new System.Drawing.Point(6, 88);
            this.saLabel4.Name = "saLabel4";
            this.saLabel4.Size = new System.Drawing.Size(34, 14);
            this.saLabel4.TabIndex = 0;
            this.saLabel4.Text = "File in";
            // 
            // txtFileMauIn
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtFileMauIn.Appearance = appearance3;
            this.txtFileMauIn.AutoSize = false;
            this.txtFileMauIn.Location = new System.Drawing.Point(87, 88);
            this.txtFileMauIn.MaxLength = 255;
            this.txtFileMauIn.Name = "txtFileMauIn";
            this.txtFileMauIn.Size = new System.Drawing.Size(479, 21);
            this.txtFileMauIn.TabIndex = 3;
            // 
            // txtSoLien
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtSoLien.Appearance = appearance2;
            this.txtSoLien.AutoSize = false;
            this.txtSoLien.Location = new System.Drawing.Point(87, 116);
            this.txtSoLien.MaskInput = "-nnn,nnn,nnn,nnn,nnn";
            this.txtSoLien.Name = "txtSoLien";
            this.txtSoLien.Nullable = true;
            this.txtSoLien.PromptChar = ' ';
            this.txtSoLien.Size = new System.Drawing.Size(252, 21);
            this.txtSoLien.TabIndex = 4;
            this.txtSoLien.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            // 
            // saLabel5
            // 
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel5.Appearance = appearance7;
            this.saLabel5.AutoSize = true;
            this.saLabel5.Location = new System.Drawing.Point(6, 116);
            this.saLabel5.Name = "saLabel5";
            this.saLabel5.Size = new System.Drawing.Size(39, 14);
            this.saLabel5.TabIndex = 0;
            this.saLabel5.Text = "Số liên";
            // 
            // chkPrintPreview
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkPrintPreview.Appearance = appearance1;
            this.chkPrintPreview.AutoSize = true;
            this.chkPrintPreview.BackColor = System.Drawing.Color.Transparent;
            this.chkPrintPreview.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkPrintPreview.Location = new System.Drawing.Point(87, 143);
            this.chkPrintPreview.Name = "chkPrintPreview";
            this.chkPrintPreview.Size = new System.Drawing.Size(102, 17);
            this.chkPrintPreview.TabIndex = 5;
            this.chkPrintPreview.Text = "Xem trước khi in";
            // 
            // frmDanhMucChungTuInUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 230);
            this.Name = "frmDanhMucChungTuInUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucDonViUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtListProcedureName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileMauIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTen;
        private coreControls.saTextBox txtMa;
        private coreControls.saLabel saLabel2;
        private coreControls.saLabel saLabel1;
        private coreControls.saTextBox txtListProcedureName;
        private coreControls.saLabel saLabel3;
        private coreControls.saNumericBox txtSoLien;
        private coreControls.saTextBox txtFileMauIn;
        private coreControls.saLabel saLabel5;
        private coreControls.saLabel saLabel4;
        private coreControls.saCheckBox chkPrintPreview;
    }
}