using coreDTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace coreDAO
{
    public class DanhMucNhomBaoCaoDAO
    {
        public DataTable List(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, DanhMucNhomBaoCao.listProcedureName, DanhMucNhomBaoCao.tableName);
            return dt;
        }
        public bool Insert(DanhMucNhomBaoCao obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucNhomBaoCao.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[4];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Update(DanhMucNhomBaoCao obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucNhomBaoCao.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[4];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.EditDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Delete(object ID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucNhomBaoCao.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
    }
    public class DanhMucBaoCaoDAO
    {
        public DataSet List(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataSet ds = dao.dsList(sqlParameters, DanhMucBaoCao.listProcedureName);
            return ds;
        }
        public bool Insert(DanhMucBaoCao obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucBaoCao.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[19];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@ReportProcedureName", obj.ReportProcedureName);
                            sqlParameters[4] = new SqlParameter("@FixedColumnList", obj.FixedColumnList);
                            sqlParameters[5] = new SqlParameter("@KhoGiay", obj.KhoGiay);
                            sqlParameters[6] = new SqlParameter("@HuongIn", obj.HuongIn);
                            sqlParameters[7] = new SqlParameter("@ChucDanhKy", obj.ChucDanhKy);
                            sqlParameters[8] = new SqlParameter("@DienGiaiKy", obj.DienGiaiKy);
                            sqlParameters[9] = new SqlParameter("@TenNguoiKy", obj.TenNguoiKy);
                            sqlParameters[10] = new SqlParameter("@FileInMau", obj.FileInMau);
                            sqlParameters[11] = new SqlParameter("@FileExcelMau", obj.FileExcelMau);
                            sqlParameters[12] = new SqlParameter("@SheetExcelMau", obj.SheetExcelMau);
                            sqlParameters[13] = new SqlParameter("@SoDongBatDau", obj.SoDongBatDau);
                            sqlParameters[14] = new SqlParameter("@ThamChieuChungTu", obj.ThamChieuChungTu);
                            sqlParameters[15] = new SqlParameter("@IDDanhMucBaoCaoThamChieu", obj.IDDanhMucBaoCaoThamChieu);
                            sqlParameters[16] = new SqlParameter("@IDDanhMucBaoCaoCopyCot", obj.IDDanhMucBaoCaoCopyCot);
                            sqlParameters[17] = new SqlParameter("@IDDanhMucNhomBaoCao", obj.IDDanhMucNhomBaoCao);
                            sqlParameters[18] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Update(DanhMucBaoCao obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucBaoCao.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[17];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@ReportProcedureName", obj.ReportProcedureName);
                            sqlParameters[4] = new SqlParameter("@FixedColumnList", obj.FixedColumnList);
                            sqlParameters[5] = new SqlParameter("@KhoGiay", obj.KhoGiay);
                            sqlParameters[6] = new SqlParameter("@HuongIn", obj.HuongIn);
                            sqlParameters[7] = new SqlParameter("@ChucDanhKy", obj.ChucDanhKy);
                            sqlParameters[8] = new SqlParameter("@DienGiaiKy", obj.DienGiaiKy);
                            sqlParameters[9] = new SqlParameter("@TenNguoiKy", obj.TenNguoiKy);
                            sqlParameters[10] = new SqlParameter("@FileInMau", obj.FileInMau);
                            sqlParameters[11] = new SqlParameter("@FileExcelMau", obj.FileExcelMau);
                            sqlParameters[12] = new SqlParameter("@SheetExcelMau", obj.SheetExcelMau);
                            sqlParameters[13] = new SqlParameter("@SoDongBatDau", obj.SoDongBatDau);
                            sqlParameters[14] = new SqlParameter("@ThamChieuChungTu", obj.ThamChieuChungTu);
                            sqlParameters[15] = new SqlParameter("@IDDanhMucNhomBaoCao", obj.IDDanhMucNhomBaoCao);
                            sqlParameters[16] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.EditDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Delete(object ID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucBaoCao.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public string GetMaByID(object ID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@ID", ID);
                sqlParameters[1] = new SqlParameter("@Ma", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = 128
                };
                ConnectionDAO dao = new ConnectionDAO();
                dao.ExecNonQuery(sqlParameters, DanhMucBaoCao.getMaProcedureName);
                return (!coreCommon.coreCommon.IsNull(sqlParameters[1].Value)) ? sqlParameters[1].Value.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return string.Empty;
            }
        }
    }
    public class DanhMucBaoCaoCotDAO
    {
        public DataTable List(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, DanhMucBaoCaoCot.listProcedureName, DanhMucBaoCaoCot.tableName);
            return dt;
        }
        public bool Insert(DanhMucBaoCaoCot obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucBaoCaoCot.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[11];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucBaoCao", obj.IDDanhMucBaoCao);
                            sqlParameters[2] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[3] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[4] = new SqlParameter("@ColumnWidth", obj.ColumnWidth);
                            sqlParameters[5] = new SqlParameter("@HeaderHeight", obj.HeaderHeight);
                            sqlParameters[6] = new SqlParameter("@TenNhomCot", obj.TenNhomCot);
                            sqlParameters[7] = new SqlParameter("@ThuTu", obj.ThuTu);
                            sqlParameters[8] = new SqlParameter("@TenCotExcel", obj.TenCotExcel);
                            sqlParameters[9] = new SqlParameter("@KieuDuLieu", obj.KieuDuLieu);
                            sqlParameters[10] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Update(DanhMucBaoCaoCot obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucBaoCaoCot.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[10];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@ColumnWidth", obj.ColumnWidth);
                            sqlParameters[4] = new SqlParameter("@HeaderHeight", obj.HeaderHeight);
                            sqlParameters[5] = new SqlParameter("@TenNhomCot", obj.TenNhomCot);
                            sqlParameters[6] = new SqlParameter("@ThuTu", obj.ThuTu);
                            sqlParameters[7] = new SqlParameter("@TenCotExcel", obj.TenCotExcel);
                            sqlParameters[8] = new SqlParameter("@KieuDuLieu", obj.KieuDuLieu);
                            sqlParameters[9] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };

                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Delete(object ID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucBaoCaoCot.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
    }
}
