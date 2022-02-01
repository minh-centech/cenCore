using System;
using System.Data;
using System.Windows.Forms;

namespace coreUI.Forms
{
    public partial class frmDanhMucChungTuInUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucChungTu = null;
        coreDTO.DanhMucChungTuIn obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucChungTuInUpdate()
        {
            InitializeComponent();
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
                    txtListProcedureName.Value = null;
                    txtFileMauIn.Value = null;
                    txtSoLien.Value = 0;
                    chkPrintPreview.Checked = true;
                    txtMa.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucChungTuIn
                {
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ListProcedureName = txtListProcedureName.Value,
                    FileMauIn = txtFileMauIn.Value,
                    SoLien = txtSoLien.Value,
                    PrintPreview = chkPrintPreview.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucChungTuIn
                {
                    ID = dataRow["ID"],
                    IDDanhMucChungTu = IDDanhMucChungTu,
                    Ma = txtMa.Value,
                    Ten = txtTen.Value,
                    ListProcedureName = txtListProcedureName.Value,
                    FileMauIn = txtFileMauIn.Value,
                    SoLien = txtSoLien.Value,
                    PrintPreview = chkPrintPreview.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucChungTuInBUS.Insert(ref obj) : coreBUS.DanhMucChungTuInBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucChungTuInBUS.List(IDDanhMucChungTu, obj.ID);
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
                txtListProcedureName.Value = dataRow["ListProcedureName"];
                txtFileMauIn.Value = dataRow["FileMauIn"];
                txtSoLien.Value = dataRow["SoLien"];
                chkPrintPreview.Checked = Boolean.Parse(dataRow["PrintPreview"].ToString());
            }
        }
    }
}
