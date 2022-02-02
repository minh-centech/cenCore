using coreDAO;
using coreDTO;
using System;
using System.Data;

namespace coreBUS
{
    public class DanhMucBaoCaoBUS
    {
        public static DataSet List(object ID)
        {
            try
            {
                DanhMucBaoCaoDAO dao = new DanhMucBaoCaoDAO();
                DataSet ds = dao.List(ID);
                ds.Tables[0].TableName = DanhMucBaoCao.tableName;
                ds.Tables[1].TableName = DanhMucBaoCaoCot.tableName;
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucBaoCaoCot.tableName, ds.Tables[DanhMucBaoCao.tableName].Columns["ID"], ds.Tables[DanhMucBaoCaoCot.tableName].Columns["IDDanhMucBaoCao"]);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucBaoCao obj)
        {
            try
            {
                DanhMucBaoCaoDAO dao = new DanhMucBaoCaoDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucBaoCao obj)
        {
            try
            {
                DanhMucBaoCaoDAO dao = new DanhMucBaoCaoDAO();
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
                DanhMucBaoCaoDAO dao = new DanhMucBaoCaoDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string GetMaByID(object ID)
        {
            try
            {
                DanhMucBaoCaoDAO dao = new DanhMucBaoCaoDAO();
                return dao.GetMaByID(ID);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }

    public class DanhMucBaoCaoCotBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucBaoCaoCotDAO dao = new DanhMucBaoCaoCotDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucBaoCaoCot obj)
        {
            try
            {
                DanhMucBaoCaoCotDAO dao = new DanhMucBaoCaoCotDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucBaoCaoCot obj)
        {
            try
            {
                DanhMucBaoCaoCotDAO dao = new DanhMucBaoCaoCotDAO();
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
                DanhMucBaoCaoCotDAO dao = new DanhMucBaoCaoCotDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class DanhMucNhomBaoCaoBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucNhomBaoCaoDAO dao = new DanhMucNhomBaoCaoDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucNhomBaoCao obj)
        {
            try
            {
                DanhMucNhomBaoCaoDAO dao = new DanhMucNhomBaoCaoDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucNhomBaoCao obj)
        {
            try
            {
                DanhMucNhomBaoCaoDAO dao = new DanhMucNhomBaoCaoDAO();
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
                DanhMucNhomBaoCaoDAO dao = new DanhMucNhomBaoCaoDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
