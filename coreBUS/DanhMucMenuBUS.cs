using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucMenuBUS
    {
       public static DataSet List(object ID)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                DataSet ds = dao.List(ID);
                ds.Tables[0].TableName = DanhMucMenu.tableName;
                ds.Tables[1].TableName = DanhMucMenuLoaiDoiTuong.tableName;
                ds.Tables[2].TableName = DanhMucMenuChungTu.tableName;
                ds.Tables[3].TableName = DanhMucMenuBaoCao.tableName;
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucMenuLoaiDoiTuong.tableName, ds.Tables[DanhMucMenu.tableName].Columns["ID"], ds.Tables[DanhMucMenuLoaiDoiTuong.tableName].Columns["IDDanhMucMenu"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucMenuChungTu.tableName, ds.Tables[DanhMucMenu.tableName].Columns["ID"], ds.Tables[DanhMucMenuChungTu.tableName].Columns["IDDanhMucMenu"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucMenuBaoCao.tableName, ds.Tables[DanhMucMenu.tableName].Columns["ID"], ds.Tables[DanhMucMenuBaoCao.tableName].Columns["IDDanhMucMenu"]);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucMenu obj)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucMenu obj)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
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
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucMenuLoaiDoiTuongBUS
    {
        public static DataTable List(Object ID = null, Object IDDanhMucMenu = null)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.List(ID, IDDanhMucMenu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucMenuLoaiDoiTuong obj)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucMenuLoaiDoiTuong obj)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
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
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucMenuChungTuBUS
    {
        public static DataTable List(Object ID = null, Object IDDanhMucMenu = null)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.List(ID, IDDanhMucMenu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucMenuChungTu obj)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucMenuChungTu obj)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
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
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucMenuBaoCaoBUS
    {
        public static DataTable List(Object ID = null, Object IDDanhMucMenu = null)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.List(ID, IDDanhMucMenu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucMenuBaoCao obj)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucMenuBaoCao obj)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
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
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }
}
