namespace coreUI.Forms
{
    partial class frmDanhMucPhanQuyenDonViUpdate
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
            this.txtMaDanhMucDonVi = new coreControls.saTextBox();
            this.txtTenDanhMucDonVi = new coreControls.saTextBox();
            this.chkXem = new coreControls.saCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Size = new System.Drawing.Size(580, 229);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(399, 201);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(491, 201);
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Location = new System.Drawing.Point(267, 201);
            // 
            // groupEditor
            // 
            this.groupEditor.Controls.Add(this.chkXem);
            this.groupEditor.Controls.Add(this.txtTenDanhMucDonVi);
            this.groupEditor.Controls.Add(this.txtMaDanhMucDonVi);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 197);
            // 
            // saLabel1
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance4;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(36, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Đơn vị";
            // 
            // txtMaDanhMucDonVi
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucDonVi.Appearance = appearance3;
            this.txtMaDanhMucDonVi.AutoSize = false;
            this.txtMaDanhMucDonVi.Enabled = false;
            this.txtMaDanhMucDonVi.Location = new System.Drawing.Point(87, 7);
            this.txtMaDanhMucDonVi.MaxLength = 128;
            this.txtMaDanhMucDonVi.Name = "txtMaDanhMucDonVi";
            this.txtMaDanhMucDonVi.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucDonVi.TabIndex = 0;
            // 
            // txtTenDanhMucDonVi
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucDonVi.Appearance = appearance2;
            this.txtTenDanhMucDonVi.AutoSize = false;
            this.txtTenDanhMucDonVi.Location = new System.Drawing.Point(260, 7);
            this.txtTenDanhMucDonVi.MaxLength = 255;
            this.txtTenDanhMucDonVi.Name = "txtTenDanhMucDonVi";
            this.txtTenDanhMucDonVi.Size = new System.Drawing.Size(306, 21);
            this.txtTenDanhMucDonVi.TabIndex = 1;
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
            // frmDanhMucPhanQuyenDonViUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucPhanQuyenDonViUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucDonViUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkXem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucDonVi;
        private coreControls.saTextBox txtMaDanhMucDonVi;
        private coreControls.saLabel saLabel1;
        private coreControls.saCheckBox chkXem;
    }
}