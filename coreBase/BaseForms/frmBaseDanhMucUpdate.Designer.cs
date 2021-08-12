namespace coreBase.BaseForms
{
    partial class frmBaseDanhMucUpdate
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.groupForm = new Infragistics.Win.Misc.UltraGroupBox();
            this.groupEditor = new Infragistics.Win.Misc.UltraGroupBox();
            this.cmdSaveNew = new Infragistics.Win.Misc.UltraButton();
            this.cmdSave = new Infragistics.Win.Misc.UltraButton();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).BeginInit();
            this.groupForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupForm
            // 
            this.groupForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupForm.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.groupForm.Controls.Add(this.groupEditor);
            this.groupForm.Controls.Add(this.cmdSaveNew);
            this.groupForm.Controls.Add(this.cmdSave);
            this.groupForm.Controls.Add(this.cmdCancel);
            this.groupForm.Location = new System.Drawing.Point(0, 0);
            this.groupForm.Name = "groupForm";
            this.groupForm.Size = new System.Drawing.Size(1010, 674);
            this.groupForm.TabIndex = 3;
            // 
            // groupEditor
            // 
            this.groupEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.groupEditor.Appearance = appearance1;
            this.groupEditor.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rectangular3D;
            this.groupEditor.Location = new System.Drawing.Point(3, 3);
            this.groupEditor.Name = "groupEditor";
            this.groupEditor.Size = new System.Drawing.Size(1004, 643);
            this.groupEditor.TabIndex = 6;
            this.groupEditor.UseAppStyling = false;
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.cmdSaveNew.Appearance = appearance2;
            this.cmdSaveNew.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdSaveNew.Location = new System.Drawing.Point(697, 648);
            this.cmdSaveNew.Name = "cmdSaveNew";
            this.cmdSaveNew.Size = new System.Drawing.Size(126, 23);
            this.cmdSaveNew.TabIndex = 101;
            this.cmdSaveNew.Tag = "cmdsave";
            this.cmdSaveNew.Text = "Lưu && &Thêm (Ctrl-N)";
            this.cmdSaveNew.Click += new System.EventHandler(this.cmdSaveAdd_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.cmdSave.Appearance = appearance3;
            this.cmdSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdSave.Location = new System.Drawing.Point(829, 648);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(86, 23);
            this.cmdSave.TabIndex = 102;
            this.cmdSave.Tag = "cmdsave";
            this.cmdSave.Text = "&Lưu (Ctrl-S)";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Opaque;
            this.cmdCancel.Appearance = appearance4;
            this.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cmdCancel.CausesValidation = false;
            this.cmdCancel.Location = new System.Drawing.Point(921, 648);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(86, 23);
            this.cmdCancel.TabIndex = 103;
            this.cmdCancel.Tag = "cmdclose";
            this.cmdCancel.Text = "Đó&ng (ESC)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmBaseDanhMucUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 674);
            this.ControlBox = false;
            this.Controls.Add(this.groupForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaseDanhMucUpdate";
            this.Text = "frm_donvi_capnhat";
            this.Load += new System.EventHandler(this.frm_donvi_capnhat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupForm)).EndInit();
            this.groupForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected internal Infragistics.Win.Misc.UltraGroupBox groupForm;
        protected internal Infragistics.Win.Misc.UltraButton cmdSave;
        protected internal Infragistics.Win.Misc.UltraButton cmdCancel;
        protected internal Infragistics.Win.Misc.UltraButton cmdSaveNew;
        protected internal Infragistics.Win.Misc.UltraGroupBox groupEditor;

    }
}