using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenu : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        BindingSource bsChungTu = null, bsBaoCao = null;
        public frmDanhMucMenu()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dsData = DanhMucMenuBUS.List(null);

            bsData = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucMenu.tableName
            };

            bsDataChiTiet = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucMenuLoaiDoiTuong.tableName
            };

            bsChungTu = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucMenuChungTu.tableName
            };

            bsBaoCao = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucMenuBaoCao.tableName
            };

            ug.DataSource = bsData;
            ugChiTiet.DataSource = bsDataChiTiet;
            ugChungTu.DataSource = bsChungTu;
            ugBaoCao.DataSource = bsBaoCao;

            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucMenuLoaiDoiTuong.tableName);
            tabChiTiet.Tabs["tabChungTu"].Text = coreCommon.coreCommon.TraTuDien(DanhMucMenuChungTu.tableName);
            tabChiTiet.Tabs["tabBaoCao"].Text = coreCommon.coreCommon.TraTuDien(DanhMucMenuBaoCao.tableName);
        }

        protected override void Insert()
        {
            coreUI.clsDanhMucMenu.Insert(new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenu.tableName], frmDanhMucMenuUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucMenu.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenu.tableName], frmDanhMucMenuUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucMenu.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucMenu.tableName], frmDanhMucMenuUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenu.tableName], frmDanhMucMenuUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
            if (DanhMucMenuBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }

        protected override void InsertChiTiet()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    coreUI.clsDanhMucMenuLoaiDoiTuong.Insert(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuLoaiDoiTuong.tableName], frmDanhMucMenuLoaiDoiTuongUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTU":
                    coreUI.clsDanhMucMenuChungTu.Insert(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuChungTu.tableName], frmDanhMucMenuChungTuUpdate.dtUpdate)));
                    break;
                case "TABBAOCAO":
                    coreUI.clsDanhMucMenuBaoCao.Insert(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuBaoCao.tableName], frmDanhMucMenuBaoCaoUpdate.dtUpdate)));
                    break;
            }
        }
        protected override void UpdateChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow) || !ugChiTiet.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucMenuLoaiDoiTuong.Update(ugChiTiet.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucMenuLoaiDoiTuong.tableName], frmDanhMucMenuLoaiDoiTuongUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuLoaiDoiTuong.tableName], frmDanhMucMenuLoaiDoiTuongUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTU":
                    if (coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow) || !ugChungTu.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucMenuChungTu.Update(ugChungTu.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucMenuChungTu.tableName], frmDanhMucMenuChungTuUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuChungTu.tableName], frmDanhMucMenuChungTuUpdate.dtUpdate)));
                    break;
                case "TABBAOCAO":
                    if (coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow) || !ugBaoCao.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucMenuBaoCao.Update(ugBaoCao.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucMenuBaoCao.tableName], frmDanhMucMenuBaoCaoUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuBaoCao.tableName], frmDanhMucMenuBaoCaoUpdate.dtUpdate)));
                    break;
            }
        }

        protected override void DeleteChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow) || !ugChiTiet.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
                    if (DanhMucMenuLoaiDoiTuongBUS.Delete(ugChiTiet.ActiveRow.Cells["ID"].Value))
                        coreUI.ugDeleteRow(bsDataChiTiet, ugChiTiet);
                    break;
                case "TABCHUNGTU":
                    if (coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow) || !ugChungTu.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
                    if (DanhMucMenuChungTuBUS.Delete(ugChungTu.ActiveRow.Cells["ID"].Value))
                        coreUI.ugDeleteRow(bsChungTu, ugChungTu);
                    break;
                case "TABBAOCAO":
                    if (coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow) || !ugBaoCao.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow.Cells["ID"].Value) || coreCommon.coreCommon.QuestionMessage("Bạn chắc chắn muốn xóa dữ liệu này?", 0) == DialogResult.No) return;
                    if (DanhMucMenuBaoCaoBUS.Delete(ugBaoCao.ActiveRow.Cells["ID"].Value))
                        coreUI.ugDeleteRow(bsBaoCao, ugBaoCao);
                    break;
            }
        }

        private void ugBaoCao_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow) || !ugBaoCao.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucMenuBaoCao.Update(ugBaoCao.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucMenuBaoCao.tableName], frmDanhMucMenuBaoCaoUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuBaoCao.tableName], frmDanhMucMenuBaoCaoUpdate.dtUpdate)));
        }
        private void ugChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow) || !ugChungTu.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucMenuChungTu.Update(ugChungTu.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucMenuChungTu.tableName], frmDanhMucMenuChungTuUpdate.dtUpdate)), new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucMenuChungTu.tableName], frmDanhMucMenuChungTuUpdate.dtUpdate)));
        }
    }
}
