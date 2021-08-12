namespace coreUI.Forms
{
    partial class frmDanhMucPhanQuyenBaoCaoUpdate
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMaDanhMucBaoCao = new coreControls.saTextBox();
            this.txtTenDanhMucBaoCao = new coreControls.saTextBox();
            this.chkXem = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Location = new System.Drawing.Point(0, -1);
            this.groupForm.Size = new System.Drawing.Size(580, 232);
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
            this.groupEditor.Controls.Add(this.chkXem);
            this.groupEditor.Controls.Add(this.txtTenDanhMucBaoCao);
            this.groupEditor.Controls.Add(this.txtMaDanhMucBaoCao);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Location = new System.Drawing.Point(3, 2);
            this.groupEditor.Size = new System.Drawing.Size(574, 201);
            // 
            // saLabel1
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance4;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(46, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Báo cáo";
            // 
            // txtMaDanhMucBaoCao
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucBaoCao.Appearance = appearance3;
            this.txtMaDanhMucBaoCao.AutoSize = false;
            this.txtMaDanhMucBaoCao.Enabled = false;
            this.txtMaDanhMucBaoCao.Location = new System.Drawing.Point(87, 7);
            this.txtMaDanhMucBaoCao.MaxLength = 128;
            this.txtMaDanhMucBaoCao.Name = "txtMaDanhMucBaoCao";
            this.txtMaDanhMucBaoCao.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucBaoCao.TabIndex = 0;
            // 
            // txtTenDanhMucBaoCao
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucBaoCao.Appearance = appearance2;
            this.txtTenDanhMucBaoCao.AutoSize = false;
            this.txtTenDanhMucBaoCao.Location = new System.Drawing.Point(260, 7);
            this.txtTenDanhMucBaoCao.MaxLength = 255;
            this.txtTenDanhMucBaoCao.Name = "txtTenDanhMucBaoCao";
            this.txtTenDanhMucBaoCao.Size = new System.Drawing.Size(306, 21);
            this.txtTenDanhMucBaoCao.TabIndex = 1;
            // 
            // chkXem
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.chkXem.Appearance = appearance1;
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.Color.Transparent;
            this.chkXem.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkXem.Location = new System.Drawing.Point(87, 35);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(119, 17);
            this.chkXem.TabIndex = 2;
            this.chkXem.Text = "Được phép truy cập";
            // 
            // frmDanhMucPhanQuyenBaoCaoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucPhanQuyenBaoCaoUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucBaoCaoUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucBaoCao;
        private coreControls.saTextBox txtMaDanhMucBaoCao;
        private coreControls.saLabel saLabel1;
        private coreControls.saCheckBox chkXem;
    }
}