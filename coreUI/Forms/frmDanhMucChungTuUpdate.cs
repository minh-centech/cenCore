using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucChungTuUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        coreDTO.DanhMucChungTu obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucChungTuUpdate()
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
                    txtMa.Value = null;
                    txtTen.Value = null;
                    txtKiHieu.Value = null;
                    cboLoaiManHinh.Value = null;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy)
            {
                obj = new coreDTO.DanhMucChungTu
                {
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    KiHieu = txtKiHieu.Value,
                    LoaiManHinh = cboLoaiManHinh.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucChungTu
                {
                    ID = dataRow["ID"],
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    KiHieu = txtKiHieu.Value,
                    LoaiManHinh = cboLoaiManHinh.Value,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == coreCommon.ThaoTacDuLieu.Them || CapNhat == coreCommon.ThaoTacDuLieu.Copy) ? coreBUS.DanhMucChungTuBUS.Insert(obj) : coreBUS.DanhMucChungTuBUS.Update(obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucChungTuBUS.List(obj.ID).Tables[coreDTO.DanhMucChungTu.tableName];
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
            foreach(string[] LoaiManHinh in coreCommon.coreCommon.listLoaiManHinh)
            {
                cboLoaiManHinh.Items.Add(LoaiManHinh[0], LoaiManHinh[1]);
            }    
            if (CapNhat >= coreCommon.ThaoTacDuLieu.Sua)
            {
                dataRow = coreBUS.DanhMucChungTuBUS.List(ID).Tables[coreDTO.DanhMucChungTu.tableName].Rows[0];
                if (coreCommon.coreCommon.IsNull(dataRow)) { coreCommon.coreCommon.ErrorMessageOkOnly("Không lấy được dữ liệu!"); this.DialogResult = DialogResult.Cancel; }
                txtMa.Value = dataRow["Ma"];
                txtTen.Value = dataRow["Ten"];
                txtKiHieu.Value = dataRow["KiHieu"];
                cboLoaiManHinh.Value = dataRow["LoaiManHinh"];
            }
        }
    }
}
