using coreDTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace coreDAO
{
    public class NhatKyDuLieuDAO
    {
        public DataTable List()
        {
            ConnectionDAO dao = new ConnectionDAO();
            DataTable dt = dao.tableList(null, NhatKyDuLieu.listProcedureName, NhatKyDuLieu.tableName);
            return dt;
        }
        public static bool Insert(string NoiDung, object AutoID, object AutoIDChungTu, object AutoIDChungTuChiTiet, int ThaoTac, string TenBangDuLieu, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(NhatKyDuLieu.insertProcedureName, sqlConnection, sqlTransaction);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[10];
                NhatKyDuLieu objNhatKyDuLieu = new NhatKyDuLieu()
                {
                    IDDanhMucNguoiSuDung = coreCommon.GlobalVariables.IDDanhMucNguoiSuDung,
                    MaDanhMucNguoiSuDung = coreCommon.GlobalVariables.MaDanhMucNguoiSuDung,
                    TenDanhMucNguoiSuDung = coreCommon.GlobalVariables.TenDanhMucNguoiSuDung,
                    AutoID = AutoID,
                    AutoIDChungTu = AutoIDChungTu,
                    AutoIDChungTuChiTiet = AutoIDChungTuChiTiet,
                    DuLieu = NoiDung,
                    ThaoTac = DBNull.Value,
                    TenBangDuLieu = TenBangDuLieu,
                    DuLieuGoc = DBNull.Value
                };
                if (ThaoTac == coreCommon.ThaoTacDuLieu.Them)
                {
                    objNhatKyDuLieu.ThaoTac = coreCommon.ThaoTacDuLieu.DienGiaiThem;
                    //foreach (DataColumn dcDuLieu in drDuLieu.Table.Columns)
                    //{
                    //    if (!dcDuLieu.ColumnName.StartsWith("ID") && !dcDuLieu.ColumnName.StartsWith("MaDanhMucNguoiSuDung") && dcDuLieu.ColumnName != "HinhAnh" && dcDuLieu.ColumnName != "CreateDate" && dcDuLieu.ColumnName != "EditDate" && !coreCommon.coreCommon.IsNull(drDuLieu[dcDuLieu]))
                    //    {
                    //        if (dcDuLieu.DataType == typeof(DateTime))
                    //            objNhatKyDuLieu.DuLieu += coreCommon.coreCommon.TraTuDien(dcDuLieu.ColumnName) + ": " + ((DateTime)drDuLieu[dcDuLieu]).ToString("dd/MM/yyyy hh:mm") + "; ";
                    //        else if (dcDuLieu.DataType == typeof(float) || dcDuLieu.DataType == typeof(double))
                    //            objNhatKyDuLieu.DuLieu += coreCommon.coreCommon.TraTuDien(dcDuLieu.ColumnName) + ": " + Math.Round(float.Parse(coreCommon.coreCommon.IsNull(drDuLieu[dcDuLieu].ToString()) ? "0" : drDuLieu[dcDuLieu].ToString()), 3) + "; ";
                    //        else
                    //            objNhatKyDuLieu.DuLieu += coreCommon.coreCommon.TraTuDien(dcDuLieu.ColumnName) + ": " + drDuLieu[dcDuLieu].ToString() + "; ";
                    //    }
                    //}
                }
                if (ThaoTac == coreCommon.ThaoTacDuLieu.Sua)
                {
                    objNhatKyDuLieu.ThaoTac = coreCommon.ThaoTacDuLieu.DienGiaiSua;
                }
                if (ThaoTac == coreCommon.ThaoTacDuLieu.Xoa)
                {
                    objNhatKyDuLieu.ThaoTac = coreCommon.ThaoTacDuLieu.DienGiaiXoa;
                }
                sqlParameters[0] = new SqlParameter("@IDDanhMucNguoiSuDung", objNhatKyDuLieu.IDDanhMucNguoiSuDung);
                sqlParameters[1] = new SqlParameter("@MaDanhMucNguoiSuDung", objNhatKyDuLieu.MaDanhMucNguoiSuDung);
                sqlParameters[2] = new SqlParameter("@TenDanhMucNguoiSuDung", objNhatKyDuLieu.TenDanhMucNguoiSuDung);
                sqlParameters[3] = new SqlParameter("@AutoID", objNhatKyDuLieu.AutoID);
                sqlParameters[4] = new SqlParameter("@AutoIDChungTu", objNhatKyDuLieu.AutoIDChungTu);
                sqlParameters[5] = new SqlParameter("@AutoIDChungTuChiTiet", objNhatKyDuLieu.AutoIDChungTuChiTiet);
                sqlParameters[6] = new SqlParameter("@ThaoTac", objNhatKyDuLieu.ThaoTac);
                sqlParameters[7] = new SqlParameter("@TenBangDuLieu", objNhatKyDuLieu.TenBangDuLieu);
                sqlParameters[8] = new SqlParameter("@DuLieu", objNhatKyDuLieu.DuLieu);
                sqlParameters[9] = new SqlParameter("@DuLieuGoc", objNhatKyDuLieu.DuLieuGoc);
                sqlCommand.Parameters.AddRange(sqlParameters);
                int rowAfftected = sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                coreCommon.coreCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }

    }
}
