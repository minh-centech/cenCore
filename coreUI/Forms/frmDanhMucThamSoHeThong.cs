using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucThamSoHeThong : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucThamSoHeThong()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucThamSoHeThongBUS.List(null);
            bsData = new BindingSource
            {
                DataSource = dtData
            };
            ug.DataSource = bsData;
        }
        protected override void Insert()
        {
            coreUI.clsDanhMucThamSoHeThong.Insert(new Action(() => coreUI.InsertToList(dtData, frmDanhMucThamSoHeThongUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucThamSoHeThong.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dtData, frmDanhMucThamSoHeThongUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucThamSoHeThong.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dtData, frmDanhMucThamSoHeThongUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dtData, frmDanhMucThamSoHeThongUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
            if (DanhMucThamSoHeThongBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }
    }
}
