using coreBUS;
using coreCommon;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucChungTu : coreBase.BaseForms.frmBaseDanhMucChiTiet
    {
        BindingSource bsChungTuIn = null, bsChungTuQuyTrinh = null;
        public frmDanhMucChungTu()
        {
            InitializeComponent();
        }
        protected override void List()
        {

            dsData = DanhMucChungTuBUS.List(null);

            bsData = new BindingSource
            {
                DataSource = dsData,
                DataMember = DanhMucChungTu.tableName
            };

            bsDataChiTiet = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucChungTuTrangThai.tableName
            };

            bsChungTuIn = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucChungTuIn.tableName
            };

            bsChungTuQuyTrinh = new BindingSource
            {
                DataSource = bsData,
                DataMember = GlobalVariables.prefix_DataRelation + DanhMucChungTuQuyTrinh.tableName
            };

            ug.DataSource = bsData;
            ugChiTiet.DataSource = bsDataChiTiet;
            ugChungTuIn.DataSource = bsChungTuIn;
            ugChungTuQuyTrinh.DataSource = bsChungTuQuyTrinh;

            tabChiTiet.Tabs["tabChiTiet"].Text = coreCommon.coreCommon.TraTuDien(DanhMucChungTuTrangThai.tableName);
            tabChiTiet.Tabs["tabChungTuIn"].Text = coreCommon.coreCommon.TraTuDien(DanhMucChungTuIn.tableName);
            tabChiTiet.Tabs["tabChungTuQuyTrinh"].Text = coreCommon.coreCommon.TraTuDien(DanhMucChungTuQuyTrinh.tableName);

            //ug.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            //ugChiTiet.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            //ugChungTuIn.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            //ugChungTuQuyTrinh.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
        }

        protected override void Insert()
        {
            coreUI.clsDanhMucChungTu.Insert(new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucChungTu.tableName], frmDanhMucChungTuUpdate.dtUpdate)));
        }
        protected override void Copy()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucChungTu.Copy(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucChungTu.tableName], frmDanhMucChungTuUpdate.dtUpdate)));
        }
        protected override void Update()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucChungTu.Update(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucChungTu.tableName], frmDanhMucChungTuUpdate.dtUpdate)));
        }
        protected override void Delete()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            if (DanhMucChungTuBUS.Delete(ug.ActiveRow.Cells["ID"].Value))
                coreUI.ugDeleteRow(bsData, ug);
        }

        protected override void InsertChiTiet()
        {
            if (coreCommon.coreCommon.IsNull(ug.ActiveRow) || !ug.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ug.ActiveRow.Cells["ID"].Value)) return;
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    coreUI.clsDanhMucChungTuTrangThai.Insert(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucChungTuTrangThai.tableName], frmDanhMucChungTuTrangThaiUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTUIN":
                    coreUI.clsDanhMucChungTuIn.Insert(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucChungTuIn.tableName], frmDanhMucChungTuInUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTUQUYTRINH":
                    coreUI.clsDanhMucChungTuQuyTrinh.Insert(ug.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.InsertToList(dsData.Tables[DanhMucChungTuQuyTrinh.tableName], frmDanhMucChungTuQuyTrinhUpdate.dtUpdate)));
                    break;
            }
        }
        protected override void UpdateChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow) || !ugChiTiet.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucChungTuTrangThai.Update(ugChiTiet.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucChungTuTrangThai.tableName], frmDanhMucChungTuTrangThaiUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTUIN":
                    if (coreCommon.coreCommon.IsNull(ugChungTuIn.ActiveRow) || !ugChungTuIn.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTuIn.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucChungTuIn.Update(ugChungTuIn.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucChungTuIn.tableName], frmDanhMucChungTuInUpdate.dtUpdate)));
                    break;
                case "TABCHUNGTUQUYTRINH":
                    if (coreCommon.coreCommon.IsNull(ugChungTuQuyTrinh.ActiveRow) || !ugChungTuQuyTrinh.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value)) return;
                    coreUI.clsDanhMucChungTuQuyTrinh.Update(ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucChungTuQuyTrinh.tableName], frmDanhMucChungTuQuyTrinhUpdate.dtUpdate)));
                    break;
            }
        }
        private void ugChungTuQuyTrinh_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugChungTuQuyTrinh.ActiveRow) || !ugChungTuQuyTrinh.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucChungTuQuyTrinh.Update(ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucChungTuQuyTrinh.tableName], frmDanhMucChungTuQuyTrinhUpdate.dtUpdate)));
        }
        private void ugChungTuIn_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (coreCommon.coreCommon.IsNull(ugChungTuIn.ActiveRow) || !ugChungTuIn.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTuIn.ActiveRow.Cells["ID"].Value)) return;
            coreUI.clsDanhMucChungTuIn.Update(ugChungTuIn.ActiveRow.Cells["ID"].Value, new Action(() => coreUI.UpdateToList(dsData.Tables[DanhMucChungTuIn.tableName], frmDanhMucChungTuInUpdate.dtUpdate)));
        }

        protected override void DeleteChiTiet()
        {
            switch (tabChiTiet.SelectedTab.Key.ToUpper())
            {
                case "TABCHITIET":
                    if (coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow) || !ugChiTiet.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChiTiet.ActiveRow.Cells["ID"].Value)) return;
                    if (DanhMucChungTuTrangThaiBUS.Delete(ugChiTiet.ActiveRow.Cells["ID"].Value))
                        coreUI.ugDeleteRow(bsDataChiTiet, ugChiTiet);
                    break;
                case "TABCHUNGTUIN":
                    if (coreCommon.coreCommon.IsNull(ugChungTuIn.ActiveRow) || !ugChungTuIn.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTuIn.ActiveRow.Cells["ID"].Value)) return;
                    if (DanhMucChungTuInBUS.Delete(ugChungTuIn.ActiveRow.Cells["ID"].Value))
                        coreUI.ugDeleteRow(bsChungTuIn, ugChungTuIn);
                    break;
                case "TABCHUNGTUQUYTRINH":
                    if (coreCommon.coreCommon.IsNull(ugChungTuQuyTrinh.ActiveRow) || !ugChungTuQuyTrinh.ActiveRow.IsDataRow || coreCommon.coreCommon.IsNull(ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value)) return;
                    if (DanhMucChungTuQuyTrinhBUS.Delete(ugChungTuQuyTrinh.ActiveRow.Cells["ID"].Value))
                        coreUI.ugDeleteRow(bsChungTuQuyTrinh, ugChungTuQuyTrinh);
                    break;
            }
        }
    }
}
