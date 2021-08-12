namespace coreUI.Forms
{
    partial class frmDesktop
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.uBarMenu = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.uBarBaoCao = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.uBarMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uBarBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // uBarMenu
            // 
            this.uBarMenu.AcceptsFocus = Infragistics.Win.DefaultableBoolean.True;
            this.uBarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance1.FontData.SizeInPoints = 8F;
            this.uBarMenu.GroupSettings.AppearancesSmall.NavigationPaneHeaderAppearance = appearance1;
            this.uBarMenu.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.uBarMenu.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
            this.uBarMenu.ImageSizeLarge = new System.Drawing.Size(20, 20);
            this.uBarMenu.ImageSizeSmall = new System.Drawing.Size(20, 20);
            this.uBarMenu.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
            this.uBarMenu.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
            this.uBarMenu.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            this.uBarMenu.ItemSettings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
            this.uBarMenu.ItemSettings.UseDefaultImage = Infragistics.Win.DefaultableBoolean.False;
            this.uBarMenu.Location = new System.Drawing.Point(3, 28);
            this.uBarMenu.Name = "uBarMenu";
            this.uBarMenu.NavigationOverflowButtonAreaVisible = false;
            this.uBarMenu.Size = new System.Drawing.Size(337, 405);
            this.uBarMenu.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
            this.uBarMenu.TabIndex = 0;
            this.uBarMenu.UseLargeGroupHeaderImages = Infragistics.Win.DefaultableBoolean.True;
            this.uBarMenu.GroupClick += new Infragistics.Win.UltraWinExplorerBar.GroupClickEventHandler(this.uBarMenu_GroupClick);
            this.uBarMenu.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uBarMenu_ItemClick);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Far;
            this.ultraGroupBox1.Controls.Add(this.uBarBaoCao);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance4.FontData.SizeInPoints = 12F;
            appearance4.TextHAlignAsString = "Left";
            this.ultraGroupBox1.HeaderAppearance = appearance4;
            this.ultraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder;
            this.ultraGroupBox1.Location = new System.Drawing.Point(415, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(349, 436);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.Text = "Báo cáo";
            // 
            // uBarBaoCao
            // 
            this.uBarBaoCao.AcceptsFocus = Infragistics.Win.DefaultableBoolean.True;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance2.TextHAlignAsString = "Left";
            this.uBarBaoCao.Appearance = appearance2;
            this.uBarBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance3.FontData.SizeInPoints = 8F;
            this.uBarBaoCao.GroupSettings.AppearancesSmall.NavigationPaneHeaderAppearance = appearance3;
            this.uBarBaoCao.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.uBarBaoCao.ImageSizeLarge = new System.Drawing.Size(20, 20);
            this.uBarBaoCao.ImageSizeSmall = new System.Drawing.Size(20, 20);
            this.uBarBaoCao.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
            this.uBarBaoCao.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
            this.uBarBaoCao.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.True;
            this.uBarBaoCao.ItemSettings.UseDefaultImage = Infragistics.Win.DefaultableBoolean.False;
            this.uBarBaoCao.Location = new System.Drawing.Point(3, 28);
            this.uBarBaoCao.Name = "uBarBaoCao";
            this.uBarBaoCao.NavigationOverflowButtonAreaVisible = false;
            this.uBarBaoCao.Size = new System.Drawing.Size(343, 405);
            this.uBarBaoCao.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
            this.uBarBaoCao.TabIndex = 0;
            this.uBarBaoCao.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uBarMenu_ItemClick);
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Near;
            this.ultraGroupBox5.Controls.Add(this.uBarMenu);
            this.ultraGroupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraGroupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance5.FontData.SizeInPoints = 12F;
            appearance5.TextHAlignAsString = "Left";
            this.ultraGroupBox5.HeaderAppearance = appearance5;
            this.ultraGroupBox5.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder;
            this.ultraGroupBox5.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(343, 436);
            this.ultraGroupBox5.TabIndex = 5;
            this.ultraGroupBox5.Text = "Menu";
            // 
            // frmDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 436);
            this.Controls.Add(this.ultraGroupBox5);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDesktop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDesktop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uBarMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uBarBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uBarMenu;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uBarBaoCao;
    }
}