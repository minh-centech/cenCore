using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucPhanQuyen : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        BindingSource bsLoaiDoiTuong = null, bsChungTu = null, bsBaoCao = null;
        public frmDanhMucPhanQuyen()
        {
            InitializeComponent();
        }
        protected override void List()
        {

            dsData = DanhMucPhanQuyenBUS.List(null);

            bsData = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucPhanQuyen.tableName
            };

            bsDataChiTiet = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenDonVi.tableName
            };

            bsLoaiDoiTuong = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenLoaiDoiTuong.tableName
            };

            bsChungTu = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenChungTu.tableName
            };

            bsBaoCao = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenBaoCao.tableName
            };

            ug.DataSource = bsData;
            ugChiTiet.DataSource = bsDataChiTiet;
            ugLoaiDoiTuong.DataSource = bsLoaiDoiTuong;
            ugChungTu.DataSource = bsChungTu;
            ugBaoCao.DataSource = bsBaoCao;

            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenDonVi.tableName);
            tabChiTiet.Tabs["tabLoaiDoiTuong"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenLoaiDoiTuong.tableName);
            tabChiTiet.Tabs["tabChungTu"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenChungTu.tableName);
            tabChiTiet.Tabs["tabBaoCao"].Text = coreCommon.coreCommon.TraTuDien(DanhMucPhanQuyenBaoCao.tableName);
        }

        protected override void Insert()
        {
            coreUI.clsDanhMucPhanQuyen.Insert(new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucPhanQuyen.tableName], frmDanhMucPhanQuyenUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucPhanQuyen.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucPhanQuyen.tableName], frmDanhMucPhanQuyenUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucPhanQuyen.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyen.tableName], frmDanhMucPhanQuyenUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            if (DanhMucPhanQuyenBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }

        protected override void UpdateChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow) || !ugChiTiet.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucPhanQuyenDonVi.Update(ugChiTiet.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenDonVi.tableName], frmDanhMucPhanQuyenDonViUpdate.dtUpdate)));
                    break;
                case "TABLOAIDOITUONG":
                    if (coreCommon.coreCommon.IsNull(ugLoaiDoiTuong.ActiveRow) || !ugLoaiDoiTuong.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugLoaiDoiTuong.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucPhanQuyenLoaiDoiTuong.Update(ugLoaiDoiTuong.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenLoaiDoiTuong.tableName], frmDanhMucPhanQuyenLoaiDoiTuongUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTU":
                    if (coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow) || !ugChungTu.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucPhanQuyenChungTu.Update(ugChungTu.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenChungTu.tableName], frmDanhMucPhanQuyenChungTuUpdate.dtUpdate)));
                    break;
                case "TABBAOCAO":
                    if (coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow) || !ugBaoCao.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucPhanQuyenBaoCao.Update(ugBaoCao.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenBaoCao.tableName], frmDanhMucPhanQuyenBaoCaoUpdate.dtUpdate)));
                    break;
            }
        }
        private void ugBaoCao_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow) || !ugBaoCao.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugBaoCao.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucPhanQuyenBaoCao.Update(ugBaoCao.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenBaoCao.tableName], frmDanhMucPhanQuyenBaoCaoUpdate.dtUpdate)));
        }
        private void ugChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow) || !ugChungTu.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTu.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucPhanQuyenChungTu.Update(ugChungTu.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenChungTu.tableName], frmDanhMucPhanQuyenChungTuUpdate.dtUpdate)));
        }
        private void ugLoaiDoiTuong_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugLoaiDoiTuong.ActiveRow) || !ugLoaiDoiTuong.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugLoaiDoiTuong.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucPhanQuyenLoaiDoiTuong.Update(ugLoaiDoiTuong.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucPhanQuyenLoaiDoiTuong.tableName], frmDanhMucPhanQuyenLoaiDoiTuongUpdate.dtUpdate)));
        }
    }
}
