using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucMenuLoaiDoiTuongUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucMenu = null;
        coreDTO.DanhMucMenuLoaiDoiTuong obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucMenuLoaiDoiTuongUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucLoaiDoiTuong";
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
                    txtMaDanhMucLoaiDoiTuong.Value = null;
                    txtTenDanhMucLoaiDoiTuong.Value = null;
                    txtNoiDungHienThi.Value = null;
                    chkTachNhom.Checked = false;
                    txtThuTuHienThi.Value = 0;
                    txtMaDanhMucLoaiDoiTuong.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucMenuLoaiDoiTuong
                {
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.ID,
                    MaDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.Value,
                    TenDanhMucLoaiDoiTuong = txtTenDanhMucLoaiDoiTuong.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucMenuLoaiDoiTuong
                {
                    ID = dataRow["ID"],
                    IDDanhMucMenu = IDDanhMucMenu,
                    IDDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.ID,
                    MaDanhMucLoaiDoiTuong = txtMaDanhMucLoaiDoiTuong.Value,
                    TenDanhMucLoaiDoiTuong = txtTenDanhMucLoaiDoiTuong.Value,
                    NoiDungHienThi = txtNoiDungHienThi.Value,
                    PhanCachNhom = chkTachNhom.Checked,
                    ThuTuHienThi = txtThuTuHienThi.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucMenuLoaiDoiTuongBUS.Insert(ref obj) : coreBUS.DanhMucMenuLoaiDoiTuongBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucMenuLoaiDoiTuongBUS.List(obj.ID);
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



        private void frmDanhMucLoaiDoiTuongUpdate_Load(object sender, EventArgs e)
        {
            coreUI.validData.SetValidTextbox(txtMaDanhMucLoaiDoiTuong, new saTextBox[1] { txtTenDanhMucLoaiDoiTuong }, new Func<DataTable>(() => DanhMucLoaiDoiTuongBUS.ListValidMa(txtMaDanhMucLoaiDoiTuong.Value)), "Ma", "ID", "Ten", null, null, null);
            if (CapNhat >= 2)
            {
                IDDanhMucMenu = dataRow["IDDanhMucMenu"];
                txtMaDanhMucLoaiDoiTuong.Value = dataRow["MaDanhMucLoaiDoiTuong"];
                txtMaDanhMucLoaiDoiTuong.ID = dataRow["IDDanhMucLoaiDoiTuong"];
                txtTenDanhMucLoaiDoiTuong.Value = dataRow["TenDanhMucLoaiDoiTuong"];
                txtNoiDungHienThi.Value = dataRow["NoiDungHienThi"];
                chkTachNhom.Checked = coreCommon.coreCommon.stringParseBoolean(dataRow["PhanCachNhom"]);
                txtThuTuHienThi.Value = int.Parse(dataRow["ThuTuHienThi"].ToString());
            }
        }

        private void txtTenDanhMucLoaiDoiTuong_ValueChanged(object sender, EventArgs e)
        {
            if (CapNhat == 1) txtNoiDungHienThi.Value = txtTenDanhMucLoaiDoiTuong.Value;
        }
    }
}
