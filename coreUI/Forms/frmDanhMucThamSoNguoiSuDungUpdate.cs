using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucThamSoNguoiSuDungUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        coreDTO.DanhMucThamSoNguoiSuDung obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucThamSoNguoiSuDungUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucThamSoNguoiSuDung";
        }
        protected override void SaveData(bool AddNew)
        {
            if (Save())
            {
                if (!AddNew)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    CapNhat = 1;
                    //Xóa text box
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtGiaTri.Value = null;
                    txtGhiChu.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucThamSoNguoiSuDung
                {
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    GiaTri = txtGiaTri.Value,
                    GhiChu = txtGhiChu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucThamSoNguoiSuDung
                {
                    ID = dataRow["ID"],
                    IDDanhMucDonVi = coreCommon.GlobalVariables.IDDonVi,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    GiaTri = txtGiaTri.Value,
                    GhiChu = txtGhiChu.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucThamSoNguoiSuDungBUS.Insert(ref obj) : coreBUS.DanhMucThamSoNguoiSuDungBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucThamSoNguoiSuDungBUS.List(obj.ID);
                if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
                {
                    if (InsertToList != null)
                        InsertToList();
                }
                else
                {
                    if (UpdateToList != null)
                        UpdateToList();
                }
                dataRow = dtUpdate.Rows[0];
                ID = obj.ID;
                return true;
            }
            else
            {
                ID = null;
                return false;
            }
        }

        private void frmDanhMucThamSoNguoiSuDungUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat >= 2)
            {
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtGiaTri.Value = dataRow["GiaTri"];
                txtGhiChu.Value = dataRow["GhiChu"];
            }
        }
    }
}
