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
        public Func<bool> fDelete;
        public string FixedColumnsList, HiddenColumnsList;
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
            if (dtUpdate != null)
            {
                bool Found = false;
                for (int i = dtData.Rows.Count - 1; i >= 0; i--)
                {
                    Found = false;
                    //Cập nhật dòng chỉnh sửa
                    foreach (DataRow drUpdate in dtUpdate.Rows)
                    {
                        if (dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Rows[i]["ID"].ToString() == drUpdate["ID"].ToString())
                        {
                            dtData.Rows[i].ItemArray = drUpdate.ItemArray;
                            Found = true;
                        }
                    }
                    //Nếu không tìm thấy thì phải cùng IDChungTu mới xóa
                    if (!Found && bsData.Current != null && dtData.Columns.Contains("IDChungTu") && dtUpdate.Columns.Contains("IDChungTu")&& dtData.Rows[i]["IDChungTu"].ToString() == ((DataRowView)bsData.Current).Row["IDChungTu"].ToString()) //
                    {
                        dtData.Rows[i].Delete();
                    }
                }
                //Thêm mới những dòng được thêm
                foreach (DataRow drUpdate in dtUpdate.Rows)
                {
                    Found = false;
                    foreach (DataRow drData in dtData.Rows)
                    {
                        if (drData.RowState != DataRowState.Deleted && drUpdate["ID"].ToString() == drData["ID"].ToString())
                        {
                            Found = true;
                        }
                    }
                    if (!Found) dtData.ImportRow(drUpdate);
                }
                dtData.AcceptChanges();
            }
        }
        protected override void Insert()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới chứng từ này!");
                return;
            }
            if (fInsert != null)
            {
                fInsert();
            }
        }
        protected override void Update()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Sua)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền sửa chứng từ này!");
                return;
            }
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fUpdate == null) return;
            fUpdate();
        }
        protected override void Delete()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenChungTu(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa chứng từ này!");
                return;
            }
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow || fDelete == null) return;
            if (coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa chứng từ này?", 0) == DialogResult.No) return;
            //Nếu ID = null thì xóa theo ID chứng từ
            bool OK = false;
            if (fDelete != null)
                OK = fDelete();
            if (OK)
                coreUI.ugDeleteRow(bsData, ug);
        }
    }
}
