using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucLoaiDoiTuong : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucLoaiDoiTuong()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucLoaiDoiTuongBUS.List(null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            coreUI.clsDanhMucLoaiDoiTuong.Insert(new Action(() => coreUI.InsertToList(dtData, frmDanhMucLoaiDoiTuongUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucLoaiDoiTuong.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dtData, frmDanhMucLoaiDoiTuongUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucLoaiDoiTuong.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dtData, frmDanhMucLoaiDoiTuongUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dtData, frmDanhMucLoaiDoiTuongUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
            if (DanhMucLoaiDoiTuongBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }
    }
}
