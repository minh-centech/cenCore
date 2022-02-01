using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucNguoiSuDungUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucMenu = null;
        Object Password = null;
        coreDTO.DanhMucNguoiSuDung obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucNguoiSuDungUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucChungTu";
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
                    txtMaDanhMucPhanQuyen.Value = null;
                    txtTenDanhMucPhanQuyen.Value = null;
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucNguoiSuDung
                {
                    IDDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.ID,
                    MaDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.Value,
                    TenDanhMucPhanQuyen = txtTenDanhMucPhanQuyen.Value,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    isAdmin = chkAdmin.Checked,
                    Password = coreCommon.coreCommon.EncryptString(""),
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucNguoiSuDung
                {
                    ID = dataRow["ID"],
                    IDDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.ID,
                    MaDanhMucPhanQuyen = txtMaDanhMucPhanQuyen.Value,
                    TenDanhMucPhanQuyen = txtTenDanhMucPhanQuyen.Value,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    isAdmin = chkAdmin.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucNguoiSuDungBUS.Insert(ref obj) : coreBUS.DanhMucNguoiSuDungBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucNguoiSuDungBUS.List(obj.ID);
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



        private void frmDanhMucChungTuUpdate_Load(object sender, EventArgs e)
        {
            
            //
            if (CapNhat >= 2)
            {
                txtMaDanhMucPhanQuyen.Value = dataRow["MaDanhMucPhanQuyen"];
                txtMaDanhMucPhanQuyen.ID = dataRow["IDDanhMucPhanQuyen"];
                txtTenDanhMucPhanQuyen.Value = dataRow["TenDanhMucPhanQuyen"];
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                chkAdmin.Checked = Boolean.Parse(dataRow["isAdmin"].ToString());
                Password = dataRow["Password"];
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucPhanQuyen, new saTextBox[1] { txtTenDanhMucPhanQuyen }, new Func<DataTable>(() => DanhMucPhanQuyenBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
        }
    }
}
