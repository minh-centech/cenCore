using coreBUS;
using coreControls;
using coreDTO;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static coreUI.coreUI;

namespace coreUI.Forms
{
    public partial class frmDanhMucPhanQuyenBaoCaoUpdate : coreBase.BaseForms.frmBaseDanhMucUpdate
    {
        public Object IDDanhMucPhanQuyen = null;
        coreDTO.DanhMucPhanQuyenBaoCao obj = null;
        public static DataTable dtUpdate;
        public Action InsertToList, UpdateToList;
        public frmDanhMucPhanQuyenBaoCaoUpdate()
        {
            InitializeComponent();
            //LoaiDanhMuc = "DanhMucBaoCao";
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
                    txtMaDanhMucBaoCao.Value = null;
                    txtTenDanhMucBaoCao.Value = null;
                    chkXem.Checked = false;
                    txtMaDanhMucBaoCao.Focus();
                }
            }
        }
        private bool Save()
        {

            if (CapNhat == 1 || CapNhat == 3)
            {
                obj = new coreDTO.DanhMucPhanQuyenBaoCao
                {
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucBaoCao = txtMaDanhMucBaoCao.ID,
                    MaDanhMucBaoCao = txtMaDanhMucBaoCao.Value,
                    TenDanhMucBaoCao = txtTenDanhMucBaoCao.Value,
                    Xem = chkXem.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            else
            {
                obj = new coreDTO.DanhMucPhanQuyenBaoCao
                {
                    ID = dataRow["ID"],
                    IDDanhMucPhanQuyen = IDDanhMucPhanQuyen,
                    IDDanhMucBaoCao = txtMaDanhMucBaoCao.ID,
                    MaDanhMucBaoCao = txtMaDanhMucBaoCao.Value,
                    TenDanhMucBaoCao = txtTenDanhMucBaoCao.Value,
                    Xem = chkXem.Checked,
                    CreateDate = null,
                    EditDate = null
                };
            }
            bool OK = (CapNhat == 1 || CapNhat == 3) ? coreBUS.DanhMucPhanQuyenBaoCaoBUS.Insert(ref obj) : coreBUS.DanhMucPhanQuyenBaoCaoBUS.Update(ref obj);
            if (OK && obj != null && Int64.TryParse(obj.ID.ToString(), out Int64 _ID) && _ID > 0)
            {
                dtUpdate = coreBUS.DanhMucPhanQuyenBaoCaoBUS.List(obj.ID);
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



        private void frmDanhMucBaoCaoUpdate_Load(object sender, EventArgs e)
        {
            //Load danh mục chứng từ
            
            if (CapNhat >= 2)
            {
                IDDanhMucPhanQuyen = dataRow["IDDanhMucPhanQuyen"];
                txtMaDanhMucBaoCao.Value = dataRow["MaDanhMucBaoCao"];
                txtMaDanhMucBaoCao.ID = dataRow["IDDanhMucBaoCao"];
                txtTenDanhMucBaoCao.Value = dataRow["TenDanhMucBaoCao"];
                chkXem.Checked = bool.Parse(dataRow["Xem"].ToString());
            }
            coreUI.validData.SetValidTextbox(txtMaDanhMucBaoCao, new saTextBox[1] { txtTenDanhMucBaoCao }, new Func<DataTable>(() => DanhMucBaoCaoBUS.List(null).Tables[0]), "Ma", "ID", "Ten", null, null, null);
        }
    }
}
