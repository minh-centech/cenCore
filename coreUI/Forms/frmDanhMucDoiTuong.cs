using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucDoiTuong : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucDoiTuong()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
            if (!coreCommon.GlobalVariables.isAdmin && !Xem)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xem dữ liệu danh mục này!");
                return;
            }
            dtData = DanhMucDoiTuongBUS.List(null, IDDanhMucLoaiDoiTuong, null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }

        public void InsertToList(DataTable dtUpdate)
        {
            dtData.Merge(dtUpdate);
        }
        protected override void Insert()
        {
            coreUI.clsDanhMucDoiTuong.Insert(IDDanhMucLoaiDoiTuong, new Action(() => coreUI.InsertToList(dtData, frmDanhMucDoiTuongUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucDoiTuong.Copy(IDDanhMucLoaiDoiTuong, ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dtData, frmDanhMucDoiTuongUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucDoiTuong.Update(IDDanhMucLoaiDoiTuong, ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dtData, frmDanhMucDoiTuongUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dtData, frmDanhMucDoiTuongUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
            if (DanhMucDoiTuongBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }
    }
}
