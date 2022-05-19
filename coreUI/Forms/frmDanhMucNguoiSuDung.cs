using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucNguoiSuDung : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucNguoiSuDung()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucNguoiSuDungBUS.List(null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
            ug.DisplayLayout.Bands[0].Columns["Password"].Hidden = true;
        }
        protected override void Insert()
        {
            coreUI.clsDanhMucNguoiSuDung.Insert(new Action(() => coreUI.InsertToList(dtData, frmDanhMucNguoiSuDungUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucNguoiSuDung.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dtData, frmDanhMucNguoiSuDungUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucNguoiSuDung.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dtData, frmDanhMucNguoiSuDungUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dtData, frmDanhMucNguoiSuDungUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
            if (DanhMucNguoiSuDungBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }
    }
}
