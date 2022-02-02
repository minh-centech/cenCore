using coreBUS;
using coreControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucChungTuQuyTrinhUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucChungTu = null;
        coreDTO.DanhMucChungTuQuyTrinh obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucChungTuQuyTrinhUpdate()
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
                    CapNhat = coreCommon.ThaoTacDuLieu.Them;
                    //Xóa text box
                    txtMaDanhMucChungTuQuyTrinh.Value = null;
                    txtTenDanhMucChungTuQuyTrinh.Value = null;
                    txtMaDanhMucChungTuQuyTrinh.Focus();
                }
            }
        }
        private bool Save()
        {
            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucChungTuQuyTrinh
                {
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.ID,
                    MaDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.Value,
                    TenDanhMucChungTuQuyTrinh = txtTenDanhMucChungTuQuyTrinh.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucChungTuQuyTrinh
                {
                    ID = dataRow["ID"],
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    IDDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.ID,
                    MaDanhMucChungTuQuyTrinh = txtMaDanhMucChungTuQuyTrinh.Value,
                    TenDanhMucChungTuQuyTrinh = txtTenDanhMucChungTuQuyTrinh.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucChungTuQuyTrinhBUS.Insert(obj) : coreBUS.DanhMucChungTuQuyTrinhBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucChungTuQuyTrinhBUS.List(obj.ID);
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
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucChungTuQuyTrinhBUS.List(ID).Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                IDDanhMucChungTu = dataRow["IDDanhMucChungTu"];
                txtMaDanhMucChungTuQuyTrinh.Value = dataRow["MaDanhMucChungTuQuyTrinh"];
                txtMaDanhMucChungTuQuyTrinh.ID = dataRow["IDDanhMucChungTuQuytrinh"];
                txtTenDanhMucChungTuQuyTrinh.Value = dataRow["TenDanhMucChungTuQuyTrinh"];
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucChungTuQuyTrinh, new saTextBox[1] { txtTenDanhMucChungTuQuyTrinh }, new Func<DataTable>(() => DanhMucChungTuBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
        }
    }
}
