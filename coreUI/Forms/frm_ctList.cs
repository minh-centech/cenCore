using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coreBUS;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace coreUI.Forms
{
    public partial class frm_ctList : coreBase.BaseForms.frmBaseChungTuSingleList
    {
        public Func<DataTable> fList;
        public Action fInsert, fUpdate;
        public Func<bool> fDelete, fDeleteChiTiet;
        public string FixedColumnsList, HiddenColumnsList;
        static object IDChungTu;
        public frm_ctList()
        {
            InitializeComponent();
        }

        private void frm_ctList_Load(object sender, EventArgs e)
        {
            //Add các button là mẫu in chứng từ
            DataTable dtChungTuIn = DanhMucChungTuInBUS.List(IDDanhMucChungTu, null);
            foreach (DataRow drChungTuIn in dtChungTuIn.Rows)
            {
                ButtonTool btChungTuIn = new ButtonTool("_rpt_" + drChungTuIn["FileMauIn"].ToString() + "ID:" + drChungTuIn["ID"].ToString() + "SOLIEN:" + drChungTuIn["SoLien"].ToString() + "SPNAME:" + drChungTuIn["ListProcedureName"].ToString());
                btChungTuIn.SharedProps.Caption = drChungTuIn["Ten"].ToString();
                UltraToolbarsManager1.Tools.Add(btChungTuIn);
                ((PopupMenuTool)UltraToolbarsManager1.Toolbars[0].Tools["btIn"]).Tools.AddTool(btChungTuIn.Key);
                btChungTuIn.SharedProps.Visible = true;
            }
        }

        protected override void List()
        {
            dtData = fList();
            bsData = new BindingSource();
            bsData.DataSource = dtData;
            ug.FixedColumnsList = FixedColumnsList;
            ug.HiddenColumnsList = HiddenColumnsList;
            ug.AddSummaryRow = true;
            ug.DataSource = bsData;
            //ug.DisplayLayout.Bands[0].Columns["IDChungTu"].Hidden = false;
            //ug.DisplayLayout.Bands[0].Columns["ID"].Hidden = false;
        }
        public void InsertToList(DataTable dtUpdate)
        {
            dtData.Merge(dtUpdate);
        }
        public void UpdateToList(DataTable dtUpdate)
        {
            if (!coreCommon.coreCommon.IsNull(dtUpdate))
            {
                bool Found = false;
                for (int i = dtData.Rows.Count - 1; i >= 0; i--)
                {
                    Found = false;
                    //Cập nhật dòng chỉnh sửa
                    foreach (DataRow drChungTuUpdate in dtUpdate.Rows)
                    {
                        if (dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Rows[i]["ID"].ToString() == drChungTuUpdate["ID"].ToString())
                        {
                            dtData.Rows[i].ItemArray = drChungTuUpdate.ItemArray;
                            Found = true;
                        }
                    }
                    //Xóa dòng bị xóa
                    if (!coreCommon.coreCommon.IsNull(IDChungTu))
                        if (!Found && dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Columns.Contains("IDChungTu") && dtData.Rows[i]["IDChungTu"].ToString() == IDChungTu.ToString()) dtData.Rows[i].Delete();
                }
                //Thêm mới những dòng được thêm
                foreach (DataRow drChungTuUpdate in dtUpdate.Rows)
                {
                    Found = false;
                    foreach (DataRow drData in dtData.Rows)
                    {
                        if (drData.RowState != DataRowState.Deleted && drChungTuUpdate["ID"].ToString() == drData["ID"].ToString())
                        {
                            Found = true;
                        }
                    }
                    if (!Found) dtData.ImportRow(drChungTuUpdate);
                }
                dtData.AcceptChanges();
            }
        }
        protected override void InsertDanhMuc()
        {
            if (fInsert != null)
            {
                fInsert();
            }
        }
        protected override void UpdateDanhMuc()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fUpdate == null) return;
            IDChungTu = (dtData.Columns.Contains("IDChungTu")) ? ug.ActiveRow.Cells["IDChungTu"].Value.ToString() : null;
            fUpdate();
        }
        protected override void DeleteDanhMuc()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || (fDelete == null && fDeleteChiTiet == null)) return;
            if (coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa chứng từ này?", 0) == DialogResult.No) return;
            //Nếu ID = null thì xóa theo ID chứng từ
            bool OK = false;
            if (!coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value))
            {
                if (fDeleteChiTiet != null)
                    OK = fDeleteChiTiet();
                else
                {
                    if (fDelete != null)
                        OK = fDelete();
                }    
            }
            else
            {
                if (fDelete != null)
                    OK = fDelete();
            }
            if (OK)
            {
                int i = ug.ActiveRow.Index;
                bsData.RemoveCurrent();
                while (i > ug.Rows.Count - 1) i -= 1;
                if (i <= ug.Rows.Count - 1 && i >= 0)
                {
                    ug.Focus();
                    ug.Rows[i].Activate();
                }
                bsData.EndEdit();
            }
        }
    }
}
