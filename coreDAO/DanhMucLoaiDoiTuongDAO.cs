using coreDTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace coreDAO
{
    public class DanhMucLoaiDoiTuongDAO
    {
        public DataTable List(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, DanhMucLoaiDoiTuong.listProcedureName, DanhMucLoaiDoiTuong.tableName);
            return dt;
        }
        public DataTable ListValidMa(object Ma)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Ma", Ma);
            DataTable dt = dao.tableList(sqlParameters, DanhMucLoaiDoiTuong.validMaProcedureName, DanhMucLoaiDoiTuong.tableName);
            return dt;
        }
        public bool Insert(DanhMucLoaiDoiTuong obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucLoaiDoiTuong.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[5];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@TenBangDuLieu", obj.TenBangDuLieu);
                            sqlParameters[4] = new SqlParameter("@CreateDate", DBNull.Value)
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
        public bool Update(DanhMucLoaiDoiTuong obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucLoaiDoiTuong.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[5];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[2] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[3] = new SqlParameter("@TenBangDuLieu", obj.TenBangDuLieu);
                            sqlParameters[4] = new SqlParameter("@EditDate", DBNull.Value)
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
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucLoaiDoiTuong.deleteProcedureName, sqlConnection, sqlTransaction))
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
        public string GetTenBangDuLieu(object ID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@ID", ID);
                sqlParameters[1] = new SqlParameter("@TenBangDuLieu", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = 128
                };
                ConnectionDAO dao = new ConnectionDAO();
                bool OK = dao.ExecNonQuery(sqlParameters, DanhMucLoaiDoiTuong.getTenBangDuLieuProcedureName);
                string TenBangDuLieu = sqlParameters[1].Value.ToString();
                return TenBangDuLieu;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return string.Empty;
            }
        }
        public object GetID(object Ma)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@Ma", Ma);
                sqlParameters[1] = new SqlParameter("@ID", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                ConnectionDAO dao = new ConnectionDAO();
                bool OK = dao.ExecNonQuery(sqlParameters, DanhMucLoaiDoiTuong.getIDProcedureName);
                return sqlParameters[1].Value;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
        public static object GetMa(object ID)
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
                bool OK = dao.ExecNonQuery(sqlParameters, DanhMucLoaiDoiTuong.getMaProcedureName);
                return sqlParameters[1].Value;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
    }
}
