using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace coreDAO
{
    public class ConnectionDAO
    {
        public ConnectionDAO()
        {
        }
        public bool TestConnection(string connString)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        /// <summary>
        /// Thực thi lấy dữ liệu vào DataSet
        /// </summary>
        /// <param name="parameters">Danh sách tham số + giá trị truyền vào của Proc SQL</param>
        /// <param name="procName">Tên Proc SQL thực thi</param>
        /// <returns></returns>
        public DataSet dsList(SqlParameter[] parameters, string procName)
        {
            SqlConnection conn = new SqlConnection(coreCommon.GlobalVariables.ConnectionString);
            DataSet ds = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(procName, conn)
                {
                    CommandText = procName,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0
                };

                if (parameters != null)
                {
                    addParameters(cmd, parameters);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                ds = null;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return ds;
        }
        /// <summary>
        /// Thực thi lấy dữ liệu vào DataTable
        /// </summary>
        /// <param name="stored"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public DataTable tableList(SqlParameter[] parameters, string procName, string tablename)
        {
            SqlConnection conn = new SqlConnection(coreCommon.GlobalVariables.ConnectionString);
            DataTable dt = null;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(procName, conn)
                {
                    CommandText = procName,
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0
                };

                if (parameters != null)
                {
                    addParameters(cmd, parameters);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable(tablename);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                dt = null;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return dt;
        }
        //
        public bool ExecNonQuery(SqlParameter[] parameters, string procName)
        {
            using (SqlConnection conn = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(procName, conn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 0
                    };

                    if (parameters != null)
                    {
                        addParameters(cmd, parameters);
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }
        }
        //
        public Object ExecScalar(SqlParameter[] parameters, string procName)
        {
            using (SqlConnection conn = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(procName, conn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 0
                    };

                    if (parameters != null)
                    {
                        addParameters(cmd, parameters);
                    }

                    return cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }
        }
        /// <summary>
        /// Add parameters từ mảng
        /// </summary>
        /// <param name="parameters"></param>
        private void addParameters(SqlCommand cmd, SqlParameter[] parameters)
        {
            cmd.Parameters.Clear();
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
        }
        public DataSet InlineSql_Execute(string sqlString, SqlParameter[] parameters)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandText = sqlString
                };
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 0;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(dataset);
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dataset;

        }
        public DataTable InlineSql_ExecuteRDT(string sqlString, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandText = sqlString
                };
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 0;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(dt);
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }
        public void InlineSql_ExecuteNonQuery(string sqlString, SqlParameter[] parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandText = sqlString,
                    CommandTimeout = 0
                };
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static long CheckForeignKey(string TableName, string ColumnName, object CheckValue, string ErrorMessage)
        {
            object Count = null;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(coreCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("Check_ForeignKey", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] sqlParameters = new SqlParameter[5];
                        sqlParameters[0] = new SqlParameter("@TableName", TableName);
                        sqlParameters[1] = new SqlParameter("@ColumnName", ColumnName);
                        sqlParameters[2] = new SqlParameter("@ValueCheck", CheckValue);
                        sqlParameters[3] = new SqlParameter("@ErrorMessage", ErrorMessage);
                        sqlParameters[4] = new SqlParameter("@Count", DBNull.Value)
                        {
                            Size = 8,
                            Direction = ParameterDirection.InputOutput
                        };
                        sqlCommand.Parameters.AddRange(sqlParameters);
                        sqlCommand.ExecuteNonQuery();
                        Count = sqlParameters[4].Value;
                    }
                }
                return coreCommon.coreCommon.longParse(Count);
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return 1;
            }
        }
    }
}
