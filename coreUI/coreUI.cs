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
                txtMa.Value = null;
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
        public class DanhMuc
        {
            public static void Delete(object IDDanhMucLoaiDoiTuong, Func<bool> deleteProcedure, UltraGrid ug, BindingSource bs)
            {
                if (!coreCommon.coreCommon.IsNull(IDDanhMucLoaiDoiTuong))
                {
                    DanhMucPhanQuyenBUS.GetPhanQuyenLoaiDoiTuong(coreCommon.GlobalVariables.IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa);
                    if (!coreCommon.GlobalVariables.isAdmin && !Xoa)
                    {
                        coreCommon.coreCommon.ErrorMessageOkOnly("Bạn không có quyền xóa dữ liệu danh mục này!");
                        return;
                    }
                }
                if (coreCommon.coreCommon.QuestionMessage("Bạn có chắc chắn muốn xóa mục dữ liệu này?", 0) == DialogResult.Yes)
                {
                    if (deleteProcedure())
                    {
                        int i = ug.ActiveRow.Index;
                        bs.RemoveCurrent();
                        while (i > ug.Rows.Count - 1) i -= 1;
                        if (i <= ug.Rows.Count - 1 && i >= 0)
                        {
                            ug.Focus();
                            ug.Rows[i].Activate();
                        }
                    }
                }
            }
        }
        public class clsDanhMucDoiTuong
        {
            public static DataRow Insert(object IDDanhMucLoaiDoiTuong, DataTable dtData, Action InsertToList)
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
                    dataTable = dtData,
                    IDDanhMucLoaiDoiTuong = IDDanhMucLoaiDoiTuong,
                    InsertToList = InsertToList
                };
                frmUpdate.ShowDialog();
                return frmUpdate.dataRow;
            }
        }
    }
}
