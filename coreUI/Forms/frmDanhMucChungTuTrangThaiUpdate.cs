using System;
using System.Data;
using System.Windows.Forms;
namespace coreUI.Forms
{
    public partial class frmDanhMucChungTuTrangThaiUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucChungTu = null;
        coreDTO.DanhMucChungTuTrangThai obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucChungTuTrangThaiUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucDonVi";
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
                    chkHachToan.Checked = false;
                    chkSua.Checked = false;
                    chkXoa.Checked = false;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucChungTuTrangThai
                {
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    HachToan = chkHachToan.Checked,
                    Sua = chkSua.Checked,
                    Xoa = chkXoa.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucChungTuTrangThai
                {
                    ID = dataRow["ID"],
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    HachToan = chkHachToan.Checked,
                    Sua = chkSua.Checked,
                    Xoa = chkXoa.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucChungTuTrangThaiBUS.Insert(ref obj) : coreBUS.DanhMucChungTuTrangThaiBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucChungTuTrangThaiBUS.List(obj.ID, IDDanhMucChungTu);
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



        private void frmDanhMucDonViUpdate_Load(object sender, EventArgs e)
        {
            if (CapNhat >= 2)
            {
                IDDanhMucChungTu = dataRow["IDDanhMucChungTu"];
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                chkHachToan.Checked = Boolean.Parse(dataRow["HachToan"].ToString());
                chkSua.Checked = Boolean.Parse(dataRow["Sua"].ToString());
                chkXoa.Checked = Boolean.Parse(dataRow["Xoa"].ToString());
            }
        }
    }
}
