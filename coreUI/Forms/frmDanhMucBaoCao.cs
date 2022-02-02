using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucBaoCao : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        public frmDanhMucBaoCao()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dsData = DanhMucBaoCaoBUS.List(null);

            bsData = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucBaoCao.tableName
            };

            bsDataChiTiet = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucBaoCaoCot.tableName
            };
            ug.DataSource = bsData;
            ugChiTiet.DataSource = bsDataChiTiet;
            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucBaoCaoCot.tableName);
        }
        //
        protected override void Insert()
        {
            coreUI.clsDanhMucBaoCao.Insert(new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucBaoCao.tableName], frmDanhMucBaoCaoUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucBaoCao.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucBaoCao.tableName], frmDanhMucBaoCaoUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucBaoCao.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucBaoCao.tableName], frmDanhMucBaoCaoUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            if (DanhMucBaoCaoBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }

        protected override void InsertChiTiet()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucBaoCao.Insert(new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucBaoCaoCot.tableName], frmDanhMucBaoCaoCotUpdate.dtUpdate)));
        }
        protected override void UpdateChiTiet()
        {
            coreUI.clsDanhMucBaoCaoCot.Update(ugChiTiet.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucBaoCaoCot.tableName], frmDanhMucBaoCaoCotUpdate.dtUpdate)));
        }
        protected override void DeleteChiTiet()
        {
            if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow) || !ugChiTiet.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value)) return;
            if (DanhMucBaoCaoBUS.Delete(ugChiTiet.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsDataChiTiet, ugChiTiet);
        }
    }
}
