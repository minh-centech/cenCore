using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucChungTuBUS
    {
        public static DataSet List(object ID)
        {
            try
            {
                DanhMucChungTuDAO dao = new DanhMucChungTuDAO();
                DataSet ds = dao.List(ID);
                ds.Tables[0].TableName = DanhMucChungTu.tableName;
                ds.Tables[1].TableName = DanhMucChungTuTrangThai.tableName;
                ds.Tables[2].TableName = DanhMucChungTuIn.tableName;
                ds.Tables[3].TableName = DanhMucChungTuQuyTrinh.tableName;
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucChungTuTrangThai.tableName, ds.Tables[DanhMucChungTu.tableName].Columns["ID"], ds.Tables[DanhMucChungTuTrangThai.tableName].Columns["IDDanhMucChungTu"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucChungTuIn.tableName, ds.Tables[DanhMucChungTu.tableName].Columns["ID"], ds.Tables[DanhMucChungTuIn.tableName].Columns["IDDanhMucChungTu"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucChungTuQuyTrinh.tableName, ds.Tables[DanhMucChungTu.tableName].Columns["ID"], ds.Tables[DanhMucChungTuQuyTrinh.tableName].Columns["IDDanhMucChungTu"]);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucChungTu obj)
        {
            try
            {
                DanhMucChungTuDAO dao = new DanhMucChungTuDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucChungTu obj)
        {
            try
            {
                DanhMucChungTuDAO dao = new DanhMucChungTuDAO();
                return dao.Update(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(object ID)
        {
            try
            {
                DanhMucChungTuDAO dao = new DanhMucChungTuDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static object GetID(object Ma)
        {
            try
            {
                DanhMucChungTuDAO dao = new DanhMucChungTuDAO();
                return dao.GetID(Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

    public class DanhMucChungTuTrangThaiBUS
    {
        public static DataTable List(object ID, object IDDanhMucChungTu)
        {
            try
            {
                DanhMucChungTuTrangThaiDAO dao = new DanhMucChungTuTrangThaiDAO();
                return dao.List(ID, IDDanhMucChungTu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucChungTuTrangThai obj)
        {
            try
            {
                DanhMucChungTuTrangThaiDAO dao = new DanhMucChungTuTrangThaiDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucChungTuTrangThai obj)
        {
            try
            {
                DanhMucChungTuTrangThaiDAO dao = new DanhMucChungTuTrangThaiDAO();
                return dao.Update(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(object ID)
        {
            try
            {
                DanhMucChungTuTrangThaiDAO dao = new DanhMucChungTuTrangThaiDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucChungTuInBUS
    {
        public static DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                DanhMucChungTuInDAO dao = new DanhMucChungTuInDAO();
                return dao.List(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucChungTuIn obj)
        {
            try
            {
                DanhMucChungTuInDAO dao = new DanhMucChungTuInDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucChungTuIn obj)
        {
            try
            {
                DanhMucChungTuInDAO dao = new DanhMucChungTuInDAO();
                return dao.Update(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(object ID)
        {
            try
            {
                DanhMucChungTuInDAO dao = new DanhMucChungTuInDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucChungTuQuyTrinhBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucChungTuQuyTrinhDAO dao = new DanhMucChungTuQuyTrinhDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucChungTuQuyTrinh obj)
        {
            try
            {
                DanhMucChungTuQuyTrinhDAO dao = new DanhMucChungTuQuyTrinhDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucChungTuQuyTrinh obj)
        {
            try
            {
                DanhMucChungTuQuyTrinhDAO dao = new DanhMucChungTuQuyTrinhDAO();
                return dao.Update(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(object ID)
        {
            try
            {
                DanhMucChungTuQuyTrinhDAO dao = new DanhMucChungTuQuyTrinhDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }
}
