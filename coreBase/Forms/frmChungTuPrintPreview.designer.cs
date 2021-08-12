namespace coreBase.Forms
{
    partial class frmChungTuPrintPreview
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btIn");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.EnableDrillDown = false;
            this.crystalReportViewer.EnableRefresh = false;
            this.crystalReportViewer.EnableToolTips = false;
            this.crystalReportViewer.Location = new System.Drawing.Point(0, 23);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowCopyButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(567, 400);
            this.crystalReportViewer.TabIndex = 0;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // _frmChungTuPrintPreview_Toolbars_Dock_Area_Left
            // 
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 23);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.Name = "_frmChungTuPrintPreview_Toolbars_Dock_Area_Left";
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 400);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.MdiMergeable = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            appearance1.Image = global::coreBase.Properties.Resources._in;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance1;
            buttonTool2.SharedPropsInternal.Caption = "In";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            // 
            // _frmChungTuPrintPreview_Toolbars_Dock_Area_Right
            // 
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(567, 23);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.Name = "_frmChungTuPrintPreview_Toolbars_Dock_Area_Right";
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 400);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmChungTuPrintPreview_Toolbars_Dock_Area_Top
            // 
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.Name = "_frmChungTuPrintPreview_Toolbars_Dock_Area_Top";
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(567, 23);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom
            // 
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 423);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.Name = "_frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom";
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(567, 0);
            this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // frmChungTuPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 423);
            this.Controls.Add(this.crystalReportViewer);
            this.Controls.Add(this._frmChungTuPrintPreview_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmChungTuPrintPreview_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._frmChungTuPrintPreview_Toolbars_Dock_Area_Top);
            this.Name = "frmChungTuPrintPreview";
            this.Text = "frmChungTuPrintPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChungTuPrintPreview_FormClosing);
            this.Load += new System.EventHandler(this.frmChungTuPrintPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChungTuPrintPreview_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChungTuPrintPreview_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChungTuPrintPreview_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChungTuPrintPreview_Toolbars_Dock_Area_Top;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        public Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
    }
}