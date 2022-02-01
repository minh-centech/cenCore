using coreBUS;
using coreDTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucDonVi : coreBase.BaseForms.frmBaseDanhMuc
    {
        public frmDanhMucDonVi()
        {
            InitializeComponent();
        }
        protected override void List()
        {
            dtData = DanhMucDonViBUS.List(null);
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
                    if (!coreCommon.coreCommon.IsNull(IDDanhMucDoiTuong))
                        if (!Found && dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Columns.Contains("ID") && dtData.Rows[i]["ID"].ToString() == IDDanhMucDoiTuong.ToString()) dtData.Rows[i].Delete();
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

        protected override void Insert()
        {
            frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Them,
                TenDanhMucLoaiDoiTuong = "Danh mục đơn vị",
                InsertToList = new Action(() => InsertToList(frmDanhMucDonViUpdate.dtUpdate))
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Copy()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            IDDanhMucDoiTuong = (dtData.Columns.Contains("ID")) ? ug.ActiveRow.Cells["ID"].Value.ToString() : null;
            frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                dataRow = ((DataRowView)bsData.Current).Row,
                TenDanhMucLoaiDoiTuong = "Danh mục đơn vị",
                InsertToList = new Action(() => InsertToList(frmDanhMucDonViUpdate.dtUpdate))
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Update()
        {
            if (ug.ActiveRow == null || !ug.ActiveRow.IsDataRow) return;
            IDDanhMucDoiTuong = (dtData.Columns.Contains("ID")) ? ug.ActiveRow.Cells["ID"].Value.ToString() : null;
            frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
            {
                CapNhat = coreCommon.ThaoTacDuLieu.Sua,
                dataRow = ((DataRowView)bsData.Current).Row,
                TenDanhMucLoaiDoiTuong = "Danh mục đơn vị",
                UpdateToList = new Action(() => UpdateToList(frmDanhMucDonViUpdate.dtUpdate))
            };
            frmUpdate.ShowDialog();
            frmUpdate.Dispose();
        }
        protected override void Delete()
        {
            //if (ug.ActiveRow != null && ug.ActiveRow.IsDataRow)
            //{
            //    deleteAction = new Action(() => { coreUI.DanhMuc.Delete(null, new Func<bool>(() => DanhMucDonViBUS.Delete(new DanhMucDonVi() { ID = ug.ActiveRow.Cells["ID"].Value })), ug, bsData); });
            //    base.Delete();
            //}
        }
    }
}
