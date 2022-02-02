using coreBUS;
using coreControls;
using coreUI.Forms;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace coreUI
{
    public class coreUI
    {
        public static void ugDeleteRow(BindingSource bsData, UltraGrid ug)
        {
            int i = ug.ActiveRow.Index;
            bsData.RemoveCurrent();
            while (i > ug.Rows.Count - 1) i -= 1;
            if (i <= ug.Rows.Count - 1 && i >= 0)
            {
                ug.Focus();
                ug.Rows[i].Activate();
            }
            bsData.EndEdit();
        }
        public static void InsertToList(DataTable dtData, DataTable dtUpdate)
        {
            dtData.Merge(dtUpdate);
        }
        public static void UpdateToList(DataTable dtData, DataTable dtUpdate)
        {
            if (!coreCommon.coreCommon.IsNull(dtUpdate))
            {
                bool Found = false;
                for (int i = dtData.Rows.Count - 1; i >= 0; i--)
                {
                    Found = false;
                    //Cập nhật dòng chỉnh sửa
                    foreach (DataRow drUpdate in dtUpdate.Rows)
                    {
                        if (dtData.Rows[i].RowState != DataRowState.Deleted && dtData.Rows[i]["ID"].ToString() == drUpdate["ID"].ToString())
                        {
                            dtData.Rows[i].ItemArray = drUpdate.ItemArray;
                            Found = true;
                        }
                    }
                }
                //Thêm mới những dòng được thêm
                foreach (DataRow drUpdate in dtUpdate.Rows)
                {
                    Found = false;
                    foreach (DataRow drData in dtData.Rows)
                    {
                        if (drData.RowState != DataRowState.Deleted && drUpdate["ID"].ToString() == drData["ID"].ToString())
                        {
                            Found = true;
                        }
                    }
                    if (!Found) dtData.ImportRow(drUpdate);
                }
                dtData.AcceptChanges();
            }
        }
        public class validData
        {
            public static void SetValidTextbox(saTextBox txtMa, saTextBox[] txtMoRong, Func<DataTable> validProcedure, string ValidColumnName, string ValueColumnName, string ReturnColumnList, Func<DataRow> insertProcedure, Action UpdateCustomData, Action DeleteCustomData)
            {
                if (txtMoRong != null)
                {
                    foreach (saTextBox textBox in txtMoRong)
                    {
                        textBox.Enabled = false;
                    }    
                }    
                txtMa.validProcedure = validProcedure;
                txtMa.insertProcedure = insertProcedure;
                txtMa.ValidColumnName = ValidColumnName;
                txtMa.ValueColumnName = ValueColumnName;
                txtMa.ReturnColumnsList = ReturnColumnList;
                txtMa.txtMoRong = txtMoRong;
                txtMa.IsModified = false;
              
                txtMa.Validating += new CancelEventHandler(validData.txtBox_Validating);
            }
            public static void txtBox_Validating(object sender, CancelEventArgs e)
            {
                saTextBox txtID = (saTextBox)sender;
                txtID.Text = txtID.Text.Trim();
                if (txtID.validProcedure != null) //Nếu có loại danh mục thì mới valid
                {
                    //Xoá textbox chứa thông tin trả về nếu ko có dữ liệu
                    if (txtID.Text == "")
                    {
                        txtID.ID = null;
                        //Tìm textbox chứa tên
                        if (txtID.txtMoRong != null && txtID.txtMoRong.Count() > 0)
                        {
                            foreach (saTextBox txtMoRong in txtID.txtMoRong)
                            {
                                txtMoRong.Text = "";
                            }
                        }
                    }
                    //
                    if (coreCommon.coreCommon.IsNull(txtID.ID))
                    {
                        if (!txtID.IsNullable | txtID.Text != "")
                        {
                            String[] sMoRong = txtID.ReturnColumnsList.Split(';');

                            DataTable dtValid = txtID.validProcedure();

                            if (dtValid.Rows.Count == 1)
                            {
                                txtID.Text = dtValid.Rows[0][txtID.ValidColumnName].ToString();
                                txtID.ID = dtValid.Rows[0][txtID.ValueColumnName].ToString();
                                if (txtID.txtMoRong != null)
                                {
                                    for (Int32 i = 0; i < txtID.txtMoRong.Count(); i++)
                                    {
                                        if (i <= sMoRong.Length - 1)
                                        {
                                            if (dtValid.Columns.Contains(sMoRong[i]))
                                            {
                                                txtID.txtMoRong[i].Value = dtValid.Rows[0][sMoRong[i]];
                                                //coreCommon.coreCommon.ErrorMessageOkOnly(txtID.txtMoRong[i].Name + ": " + sMoRong[i] + ": " + dtValid.Rows[0][sMoRong[i]].ToString());
                                            }
                                        }
                                        else
                                            txtID.txtMoRong[i].Value = null;
                                    }
                                }
                                txtID.IsModified = false;
                                return;
                            }
                            Forms.frmDataValid frmLookUp = new Forms.frmDataValid
                            {
                                
                                validProcedure = txtID.validProcedure,
                                insertProcedure = txtID.insertProcedure,
                                validColumn = txtID.ValidColumnName,
                                validValue = txtID.Text
                            };
                            frmLookUp.ShowDialog();
                            if (frmLookUp.dataRow != null)
                            {
                                txtID.Text = frmLookUp.dataRow[txtID.ValidColumnName].ToString();
                                txtID.ID = frmLookUp.dataRow[txtID.ValueColumnName].ToString();
                                if (txtID.txtMoRong != null)
                                {
                                    for (Int32 i = 0; i < txtID.txtMoRong.Count(); i++)
                                    {
                                        if (i <= sMoRong.Length - 1)
                                        {
                                            if (dtValid.Columns.Contains(sMoRong[i]))
                                                txtID.txtMoRong[i].Text = frmLookUp.dataRow[sMoRong[i]].ToString();
                                        }
                                        else
                                            txtID.txtMoRong[i].Text = "";
                                    }
                                }
                                txtID.IsModified = false;
                                return;
                            }
                        }
                    }
                }
            }
            public static void SetValidComboEditor(saComboDanhMuc cbo, Func<DataTable> listProcedure, Func<DataRow> insertProcedure, string ValidColumnName, string ValueColumnName)
            {
                cbo.DataSource = listProcedure();
                cbo.listProcedure = listProcedure;
                cbo.insertProcedure = insertProcedure;
                cbo.ValueMember = ValueColumnName;
                cbo.DisplayMember = ValidColumnName;
            }
            public static void cboDanhMuc_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F5)
                {
                    saComboDanhMuc cboDanhMuc = (saComboDanhMuc)sender;
                    //Gọi form lookup tương ứng theo store
                    Forms.frmDataValid frmLookUp = new Forms.frmDataValid
                    {
                        validProcedure = cboDanhMuc.listProcedure,
                        insertProcedure = cboDanhMuc.insertProcedure,
                        validColumn = cboDanhMuc.DisplayMember,
                        validValue = cboDanhMuc.Text
                    };
                    frmLookUp.ShowDialog();
                    if (frmLookUp.dataRow != null)
                    {
                        cboDanhMuc.DataSource = frmLookUp.dataRow.Table;
                        cboDanhMuc.Value = frmLookUp.dataRow[cboDanhMuc.ValueMember];
                    }
                    frmLookUp.Dispose();
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
            public static void txtDanhMuc_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F5)
                {
                    saTextBox txtDanhMuc = (saTextBox)sender;
                    //Gọi form lookup tương ứng theo store
                    Forms.frmDataValid frmLookUp = new Forms.frmDataValid
                    {
                        validProcedure = txtDanhMuc.validProcedure,
                        insertProcedure = txtDanhMuc.insertProcedure,
                        validColumn = txtDanhMuc.ValidColumnName,
                        validValue = txtDanhMuc.Text
                    };
                    frmLookUp.ShowDialog();
                    if (frmLookUp.dataRow != null)
                    {
                        txtDanhMuc.Value = frmLookUp.dataRow[txtDanhMuc.ValidColumnName];
                        txtDanhMuc.ID = frmLookUp.dataRow[txtDanhMuc.ValueColumnName];
                        String[] sMoRong = txtDanhMuc.ReturnColumnsList.Split(';');
                        if (txtDanhMuc.txtMoRong != null)
                        {
                            for (Int32 i = 0; i < txtDanhMuc.txtMoRong.Count(); i++)
                            {
                                if (i <= sMoRong.Length - 1)
                                {
                                    if (frmLookUp.dataRow.Table.Columns.Contains(sMoRong[i]))
                                        txtDanhMuc.txtMoRong[i].Text = frmLookUp.dataRow[sMoRong[i]].ToString();
                                }
                                else
                                    txtDanhMuc.txtMoRong[i].Text = "";
                            }
                        }
                    }
                    frmLookUp.Dispose();
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
            public static void gridColumnValid(UltraGridCell uCell, string ValidColumName, string ReturnValueColumnList, string ReturnDataColumnList, Func<DataTable> listProcedure, Func<DataRow> insertProcedure, bool ShowLookup, out bool GridValidation)
            {
                if (!uCell.Row.IsDataRow) { GridValidation = true; return; }
                string[] ReturnValueColumnNames = ReturnValueColumnList.Split(';');
                string[] ReturnDataColumnNames = ReturnDataColumnList.Split(';');
                GridValidation = false;
                foreach (string ColumName in ReturnValueColumnNames)
                {
                    if (ColumName.ToUpper() != uCell.Column.Key.ToUpper())
                    {
                        uCell.Row.Cells[ColumName].Value = DBNull.Value;
                    }
                }
                if (coreCommon.coreCommon.IsNull(uCell.Row.Cells[uCell.Column.Key].Value)) { GridValidation = true; return; }
                DataTable dataTable = listProcedure();
                if (dataTable == null) { uCell.Row.Cells[uCell.Column.Key].Value = DBNull.Value; GridValidation = true;  return; }
                if (dataTable.Rows.Count == 1 && dataTable.Rows[0][ValidColumName].ToString() == uCell.Row.Cells[uCell.Column.Key].Value.ToString())
                {
                    GridValidation = false;
                    for(int i = 0; i <= ReturnValueColumnNames.Count() - 1; i++)
                    {
                        if (ReturnDataColumnNames.Count() >= i && dataTable.Columns.Contains(ReturnDataColumnNames[i]))
                        {
                            uCell.Row.Cells[ReturnValueColumnNames[i]].Value = dataTable.Rows[0][ReturnDataColumnNames[i]];
                        }
                    }
                    GridValidation = true;
                    return;
                }
                if (ShowLookup)
                {
                    frmDataValid frm_ctValid = new frmDataValid()
                    {
                        validProcedure = listProcedure,
                        insertProcedure = insertProcedure,
                        validColumn = ValidColumName,
                        validValue = uCell.Value
                    };
                    frm_ctValid.ShowDialog();
                    if (frm_ctValid.dataRow == null) { GridValidation = true; return; }
                    GridValidation = false;
                    for (int i = 0; i <= ReturnValueColumnNames.Count() - 1; i++)
                    {
                        if (ReturnDataColumnNames.Count() >= i && dataTable.Columns.Contains(ReturnDataColumnNames[i]))
                        {
                            uCell.Row.Cells[ReturnValueColumnNames[i]].Value = frm_ctValid.dataRow[ReturnDataColumnNames[i]];
                        }
                    }
                    GridValidation = true;
                    return;
                }
            }
        }
        public class clsDanhMucDoiTuong
        {
            public static DataRow Insert(object IDDanhMucLoaiDoiTuong, Action InsertToList)
            {
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
                if (!coreCommon.GlobalVariables.isAdmin && !Them)
                {
                    coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                    return null;
                }
                frmDanhMucDoiTuongUpdate frmUpdate = new frmDanhMucDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucLoaiDoiTuong, object IDDanhMucDoiTuong, Action UpdateToList)
            {
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
                if (!coreCommon.GlobalVariables.isAdmin && !Them)
                {
                    coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                    return null;
                }
                frmDanhMucDoiTuongUpdate frmUpdate = new frmDanhMucDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    ID = IDDanhMucDoiTuong,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucLoaiDoiTuong, object IDDanhMucDoiTuong, Action InsertToList)
            {
                DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
                if (!coreCommon.GlobalVariables.isAdmin && !Them)
                {
                    coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền thêm mới dữ liệu danh mục này!");
                    return null;
                }
                frmDanhMucDoiTuongUpdate frmUpdate = new frmDanhMucDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    ID = IDDanhMucDoiTuong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucBaoCao
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucBaoCao, Action UpdateToList)
            {
                frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucBaoCao,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucBaoCao, Action InsertToList)
            {
                frmDanhMucBaoCaoUpdate frmUpdate = new frmDanhMucBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucBaoCao,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucBaoCaoCot
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucBaoCaoCot, Action UpdateToList)
            {
                frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucBaoCaoCot,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucBaoCaoCot, Action InsertToList)
            {
                frmDanhMucBaoCaoCotUpdate frmUpdate = new frmDanhMucBaoCaoCotUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucBaoCaoCot,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucChungTu
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucChungTuUpdate frmUpdate = new frmDanhMucChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucChungTu, Action UpdateToList)
            {
                frmDanhMucChungTuUpdate frmUpdate = new frmDanhMucChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucChungTu,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucChungTu, Action InsertToList)
            {
                frmDanhMucChungTuUpdate frmUpdate = new frmDanhMucChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucChungTu,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucChungTuIn
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucChungTuInUpdate frmUpdate = new frmDanhMucChungTuInUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucChungTuIn, Action UpdateToList)
            {
                frmDanhMucChungTuInUpdate frmUpdate = new frmDanhMucChungTuInUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucChungTuIn,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucChungTuIn, Action InsertToList)
            {
                frmDanhMucChungTuInUpdate frmUpdate = new frmDanhMucChungTuInUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucChungTuIn,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucChungTuQuyTrinh
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucChungTuQuyTrinhUpdate frmUpdate = new frmDanhMucChungTuQuyTrinhUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucChungTuQuyTrinh, Action UpdateToList)
            {
                frmDanhMucChungTuQuyTrinhUpdate frmUpdate = new frmDanhMucChungTuQuyTrinhUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucChungTuQuyTrinh,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucChungTuQuyTrinh, Action InsertToList)
            {
                frmDanhMucChungTuQuyTrinhUpdate frmUpdate = new frmDanhMucChungTuQuyTrinhUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucChungTuQuyTrinh,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucChungTuTrangThai
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucChungTuTrangThaiUpdate frmUpdate = new frmDanhMucChungTuTrangThaiUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucChungTuTrangThai, Action UpdateToList)
            {
                frmDanhMucChungTuTrangThaiUpdate frmUpdate = new frmDanhMucChungTuTrangThaiUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucChungTuTrangThai,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucChungTuTrangThai, Action InsertToList)
            {
                frmDanhMucChungTuTrangThaiUpdate frmUpdate = new frmDanhMucChungTuTrangThaiUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucChungTuTrangThai,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucDonVi
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucDonVi, Action UpdateToList)
            {
                frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucDonVi,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucDonVi, Action InsertToList)
            {
                frmDanhMucDonViUpdate frmUpdate = new frmDanhMucDonViUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucDonVi,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucLoaiDoiTuong
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucLoaiDoiTuong, Action UpdateToList)
            {
                frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucLoaiDoiTuong,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucLoaiDoiTuong, Action InsertToList)
            {
                frmDanhMucLoaiDoiTuongUpdate frmUpdate = new frmDanhMucLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucLoaiDoiTuong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucMenu
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucMenuUpdate frmUpdate = new frmDanhMucMenuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucMenu, Action UpdateToList)
            {
                frmDanhMucMenuUpdate frmUpdate = new frmDanhMucMenuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucMenu,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucMenu, Action InsertToList)
            {
                frmDanhMucMenuUpdate frmUpdate = new frmDanhMucMenuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucMenu,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucMenuBaoCao
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucMenuBaoCaoUpdate frmUpdate = new frmDanhMucMenuBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucMenuBaoCao, Action UpdateToList)
            {
                frmDanhMucMenuBaoCaoUpdate frmUpdate = new frmDanhMucMenuBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucMenuBaoCao,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucMenuBaoCao, Action InsertToList)
            {
                frmDanhMucMenuBaoCaoUpdate frmUpdate = new frmDanhMucMenuBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucMenuBaoCao,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucMenuChungTu
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucMenuChungTuUpdate frmUpdate = new frmDanhMucMenuChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucMenuChungTu, Action UpdateToList)
            {
                frmDanhMucMenuChungTuUpdate frmUpdate = new frmDanhMucMenuChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucMenuChungTu,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucMenuChungTu, Action InsertToList)
            {
                frmDanhMucMenuChungTuUpdate frmUpdate = new frmDanhMucMenuChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucMenuChungTu,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucMenuLoaiDoiTuong
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucMenuLoaiDoiTuongUpdate frmUpdate = new frmDanhMucMenuLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucMenuLoaiDoiTuong, Action UpdateToList)
            {
                frmDanhMucMenuLoaiDoiTuongUpdate frmUpdate = new frmDanhMucMenuLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucMenuLoaiDoiTuong,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucMenuLoaiDoiTuong, Action InsertToList)
            {
                frmDanhMucMenuLoaiDoiTuongUpdate frmUpdate = new frmDanhMucMenuLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucMenuLoaiDoiTuong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucNguoiSuDung
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucNguoiSuDungUpdate frmUpdate = new frmDanhMucNguoiSuDungUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucNguoiSuDung, Action UpdateToList)
            {
                frmDanhMucNguoiSuDungUpdate frmUpdate = new frmDanhMucNguoiSuDungUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucNguoiSuDung,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucNguoiSuDung, Action InsertToList)
            {
                frmDanhMucNguoiSuDungUpdate frmUpdate = new frmDanhMucNguoiSuDungUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucNguoiSuDung,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucNhomBaoCao
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucNhomBaoCaoUpdate frmUpdate = new frmDanhMucNhomBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucNhomBaoCao, Action UpdateToList)
            {
                frmDanhMucNhomBaoCaoUpdate frmUpdate = new frmDanhMucNhomBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucNhomBaoCao,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucNhomBaoCao, Action InsertToList)
            {
                frmDanhMucNhomBaoCaoUpdate frmUpdate = new frmDanhMucNhomBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucNhomBaoCao,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucPhanQuyen
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucPhanQuyenUpdate frmUpdate = new frmDanhMucPhanQuyenUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucPhanQuyen, Action UpdateToList)
            {
                frmDanhMucPhanQuyenUpdate frmUpdate = new frmDanhMucPhanQuyenUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucPhanQuyen,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucPhanQuyen, Action InsertToList)
            {
                frmDanhMucPhanQuyenUpdate frmUpdate = new frmDanhMucPhanQuyenUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucPhanQuyen,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucPhanQuyenBaoCao
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucPhanQuyenBaoCaoUpdate frmUpdate = new frmDanhMucPhanQuyenBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucPhanQuyenBaoCao, Action UpdateToList)
            {
                frmDanhMucPhanQuyenBaoCaoUpdate frmUpdate = new frmDanhMucPhanQuyenBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucPhanQuyenBaoCao,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucPhanQuyenBaoCao, Action InsertToList)
            {
                frmDanhMucPhanQuyenBaoCaoUpdate frmUpdate = new frmDanhMucPhanQuyenBaoCaoUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucPhanQuyenBaoCao,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucPhanQuyenChungTu
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucPhanQuyenChungTuUpdate frmUpdate = new frmDanhMucPhanQuyenChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucPhanQuyenChungTu, Action UpdateToList)
            {
                frmDanhMucPhanQuyenChungTuUpdate frmUpdate = new frmDanhMucPhanQuyenChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucPhanQuyenChungTu,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucPhanQuyenChungTu, Action InsertToList)
            {
                frmDanhMucPhanQuyenChungTuUpdate frmUpdate = new frmDanhMucPhanQuyenChungTuUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucPhanQuyenChungTu,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucPhanQuyenDonVi
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucPhanQuyenDonViUpdate frmUpdate = new frmDanhMucPhanQuyenDonViUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucPhanQuyenDonVi, Action UpdateToList)
            {
                frmDanhMucPhanQuyenDonViUpdate frmUpdate = new frmDanhMucPhanQuyenDonViUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucPhanQuyenDonVi,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucPhanQuyenDonVi, Action InsertToList)
            {
                frmDanhMucPhanQuyenDonViUpdate frmUpdate = new frmDanhMucPhanQuyenDonViUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucPhanQuyenDonVi,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucPhanQuyenLoaiDoiTuong
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucPhanQuyenLoaiDoiTuongUpdate frmUpdate = new frmDanhMucPhanQuyenLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucPhanQuyenLoaiDoiTuong, Action UpdateToList)
            {
                frmDanhMucPhanQuyenLoaiDoiTuongUpdate frmUpdate = new frmDanhMucPhanQuyenLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucPhanQuyenLoaiDoiTuong,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucPhanQuyenLoaiDoiTuong, Action InsertToList)
            {
                frmDanhMucPhanQuyenLoaiDoiTuongUpdate frmUpdate = new frmDanhMucPhanQuyenLoaiDoiTuongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucPhanQuyenLoaiDoiTuong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucThamSoHeThong
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucThamSoHeThongUpdate frmUpdate = new frmDanhMucThamSoHeThongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucThamSoHeThong, Action UpdateToList)
            {
                frmDanhMucThamSoHeThongUpdate frmUpdate = new frmDanhMucThamSoHeThongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucThamSoHeThong,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucThamSoHeThong, Action InsertToList)
            {
                frmDanhMucThamSoHeThongUpdate frmUpdate = new frmDanhMucThamSoHeThongUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucThamSoHeThong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucThamSoNguoiSuDung
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucThamSoNguoiSuDung, Action UpdateToList)
            {
                frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucThamSoNguoiSuDung,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucThamSoNguoiSuDung, Action InsertToList)
            {
                frmDanhMucThamSoNguoiSuDungUpdate frmUpdate = new frmDanhMucThamSoNguoiSuDungUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucThamSoNguoiSuDung,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
        public class clsDanhMucTuDien
        {
            public static DataRow Insert(Action InsertToList)
            {
                frmDanhMucTuDienUpdate frmUpdate = new frmDanhMucTuDienUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Update(object IDDanhMucTuDien, Action UpdateToList)
            {
                frmDanhMucTuDienUpdate frmUpdate = new frmDanhMucTuDienUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Them,
                    ID = IDDanhMucTuDien,
                    UpdateToList = UpdateToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
            public static DataRow Copy(object IDDanhMucTuDien, Action InsertToList)
            {
                frmDanhMucTuDienUpdate frmUpdate = new frmDanhMucTuDienUpdate
                {
                    CapNhat = coreCommon.ThaoTacDuLieu.Copy,
                    ID = IDDanhMucTuDien,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
    }
}
