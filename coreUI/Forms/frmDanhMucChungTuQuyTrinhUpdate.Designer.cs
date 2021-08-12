namespace coreUI.Forms
{
    partial class frmDanhMucChungTuQuyTrinhUpdate
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.saLabel1 = new coreControls.saLabel();
            this.txtMaDanhMucChungTuQuyTrinh = new coreControls.saTextBox();
            this.txtTenDanhMucChungTuQuyTrinh = new coreControls.saTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucChungTuQuyTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucChungTuQuyTrinh)).BeginInit();
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
            this.groupEditor.Controls.Add(this.txtTenDanhMucChungTuQuyTrinh);
            this.groupEditor.Controls.Add(this.txtMaDanhMucChungTuQuyTrinh);
            this.groupEditor.Controls.Add(this.saLabel1);
            this.groupEditor.Size = new System.Drawing.Size(574, 198);
            // 
            // saLabel1
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.saLabel1.Appearance = appearance3;
            this.saLabel1.AutoSize = true;
            this.saLabel1.Location = new System.Drawing.Point(6, 6);
            this.saLabel1.Name = "saLabel1";
            this.saLabel1.Size = new System.Drawing.Size(50, 14);
            this.saLabel1.TabIndex = 0;
            this.saLabel1.Text = "Chứng từ";
            // 
            // txtMaDanhMucChungTuQuyTrinh
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMaDanhMucChungTuQuyTrinh.Appearance = appearance2;
            this.txtMaDanhMucChungTuQuyTrinh.AutoSize = false;
            this.txtMaDanhMucChungTuQuyTrinh.Location = new System.Drawing.Point(87, 7);
            this.txtMaDanhMucChungTuQuyTrinh.MaxLength = 128;
            this.txtMaDanhMucChungTuQuyTrinh.Name = "txtMaDanhMucChungTuQuyTrinh";
            this.txtMaDanhMucChungTuQuyTrinh.Size = new System.Drawing.Size(167, 21);
            this.txtMaDanhMucChungTuQuyTrinh.TabIndex = 0;
            // 
            // txtTenDanhMucChungTuQuyTrinh
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtTenDanhMucChungTuQuyTrinh.Appearance = appearance1;
            this.txtTenDanhMucChungTuQuyTrinh.AutoSize = false;
            this.txtTenDanhMucChungTuQuyTrinh.Location = new System.Drawing.Point(260, 7);
            this.txtTenDanhMucChungTuQuyTrinh.MaxLength = 255;
            this.txtTenDanhMucChungTuQuyTrinh.Name = "txtTenDanhMucChungTuQuyTrinh";
            this.txtTenDanhMucChungTuQuyTrinh.Size = new System.Drawing.Size(306, 21);
            this.txtTenDanhMucChungTuQuyTrinh.TabIndex = 1;
            // 
            // frmDanhMucChungTuQuyTrinhUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Name = "frmDanhMucChungTuQuyTrinhUpdate";
            this.Text = "frmDanhMucDonViUpdate";
            this.Load += new System.EventHandler(this.frmDanhMucDonViUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanhMucChungTuQuyTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanhMucChungTuQuyTrinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private coreControls.saTextBox txtTenDanhMucChungTuQuyTrinh;
        private coreControls.saTextBox txtMaDanhMucChungTuQuyTrinh;
        private coreControls.saLabel saLabel1;
    }
}