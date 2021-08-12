using coreControls;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreBase.BaseForms
{
    public partial class frmBaseGridUpdate : Form
    {
        public DataTable dt;
        public String TableName;
        public Boolean Saved = false, GridValidation = true;
        public Int32 RowID = 0;
        public Func<long> checkForeignKey;
        public BindingSource bs;
        public frmBaseGridUpdate()
        {
            InitializeComponent();
            saUpdateGrid.ConfirmDelete = false;
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            saUpdateGrid.AfterCellUpdate += new CellEventHandler(ugChiTiet_AfterCellUpdate);
            saUpdateGrid.AfterRowInsert += new RowEventHandler(ugChiTiet_AfterRowInsert);
            if (dt != null)
            {
                bs = new BindingSource
                {
                    DataSource = dt
                };
                saUpdateGrid.DataSource = bs;
                saUpdateGrid.SetEditableState(false);
                if (dt.Rows.Count == 0)
                {
                    bs.AddNew();
                    saUpdateGrid.Rows[0].Activate();
                    saUpdateGrid.ActiveRow.Cells["ID"].Value = coreCommon.coreCommon.MaxTempID(dt);
                }
            }
        }
        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key.ToString().ToUpper())
            {
                case "BTOK":
                    bs.EndEdit();
                    UpdateData();
                    if (!Saved) return;
                    this.Close();
                    break;
                case "BTXOADONG":
                    XoaChungTuChiTiet();
                    break;
                case "BTTHEMDONG":
                    ThemChungTuChiTiet();
                    break;
            }
        }
        protected virtual void List()
        {
        }
        protected virtual void UpdateData()
        {
        }
        protected virtual void ThemChungTuChiTiet()
        {
            GridValidation = false;
            bs.AddNew();
            saUpdateGrid.Focus();
            saUpdateGrid.DisplayLayout.Rows[saUpdateGrid.DisplayLayout.Rows.Count - 1].Activate();
            saUpdateGrid.ActiveRow.Cells["ID"].Value = RowID + coreCommon.coreCommon.MaxTempID(dt);
            foreach (UltraGridColumn ugCol in saUpdateGrid.DisplayLayout.Bands[0].Columns)
            {
                if (!ugCol.Hidden)
                {
                    saUpdateGrid.ActiveCell = saUpdateGrid.ActiveRow.Cells[ugCol.Key];
                    saUpdateGrid.ActiveCell.Activate();
                    break;
                }
            }
            GridValidation = true;
        }
        protected virtual void XoaChungTuChiTiet()
        {
            if (saUpdateGrid.ActiveRow == null) return;
            if (checkForeignKey != null && checkForeignKey() > 0) return;
            int i = saUpdateGrid.ActiveRow.Index;
            bs.RemoveCurrent();
            while (i > saUpdateGrid.Rows.Count - 1) i -= 1;
            if (i <= saUpdateGrid.Rows.Count - 1 && i >= 0)
            {
                saUpdateGrid.Focus();
                saUpdateGrid.Rows[i].Activate();
            }
        }
        private void frmBaseGridUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                DialogResult dlg = coreCommon.coreCommon.QuestionMessage("Bạn có muốn lưu lại dữ liệu trước khi thoát?", 1);
                switch (dlg)
                {
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        dt.RejectChanges();
                        bs.EndEdit();
                        break;
                    case System.Windows.Forms.DialogResult.Yes:
                        bs.EndEdit();
                        UpdateData();
                        if (!Saved) e.Cancel = true;
                        break;
                }
            }
        }
        private void ugChiTiet_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            if (GridValidation)
                gridColumnDataProcess((saUpdateGrid)sender, e.Cell, out GridValidation, true);
        }
        private void ugChiTiet_AfterRowInsert(object sender, RowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(e.Row.Cells["ID"].Value))
                e.Row.Cells["ID"].Value = RowID + coreCommon.coreCommon.MaxTempID(dt);
        }
        //Valid các ô nhập dữ liệu trên lưới
        protected virtual void gridColumnDataProcess(UltraGrid ug, UltraGridCell uCell, out Boolean GridValidation, Boolean ShowLookUp)
        {
            GridValidation = true;
        }
        private void frmBaseGridUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
