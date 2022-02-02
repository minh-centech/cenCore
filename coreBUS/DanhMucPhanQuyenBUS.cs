using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucPhanQuyenBUS
    {
        public static DataSet List(object ID)
        {
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                DataSet ds = dao.List(ID);
                ds.Tables[0].TableName = DanhMucPhanQuyen.tableName;
                ds.Tables[1].TableName = DanhMucPhanQuyenDonVi.tableName;
                ds.Tables[2].TableName = DanhMucPhanQuyenLoaiDoiTuong.tableName;
                ds.Tables[3].TableName = DanhMucPhanQuyenChungTu.tableName;
                ds.Tables[4].TableName = DanhMucPhanQuyenBaoCao.tableName;
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenDonVi.tableName, ds.Tables[DanhMucPhanQuyen.tableName].Columns["ID"], ds.Tables[DanhMucPhanQuyenDonVi.tableName].Columns["IDDanhMucPhanQuyen"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenLoaiDoiTuong.tableName, ds.Tables[DanhMucPhanQuyen.tableName].Columns["ID"], ds.Tables[DanhMucPhanQuyenLoaiDoiTuong.tableName].Columns["IDDanhMucPhanQuyen"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenChungTu.tableName, ds.Tables[DanhMucPhanQuyen.tableName].Columns["ID"], ds.Tables[DanhMucPhanQuyenChungTu.tableName].Columns["IDDanhMucPhanQuyen"]);
                ds.Relations.Add(coreCommon.GlobalVariables.prefix_DataRelation + DanhMucPhanQuyenBaoCao.tableName, ds.Tables[DanhMucPhanQuyen.tableName].Columns["ID"], ds.Tables[DanhMucPhanQuyenBaoCao.tableName].Columns["IDDanhMucPhanQuyen"]);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucPhanQuyen obj)
        {
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucPhanQuyen obj)
        {
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
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
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }
        public static void GetPhanQuyenDonVi(object IDDanhMucPhanQuyen, object IDDanhMucDonVi, out bool Xem)
        {
            Xem = false;
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                dao.GetPhanQuyenDonVi(IDDanhMucPhanQuyen, IDDanhMucDonVi, out Xem);
            }
            catch (Exception ex)
            {
            }
        }
        public static void GetPhanQuyenLoaiDoiTuong(object IDDanhMucPhanQuyen, object IDDanhMucLoaiDoiTuong, out bool Xem, out bool Them, out bool Sua, out bool Xoa)
        {
            Xem = false;
            Them = false;
            Sua = false;
            Xoa = false;
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                dao.GetPhanQuyenLoaiDoiTuong(IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, out Xem, out Them, out Sua, out Xoa);
            }
            catch (Exception ex)
            {
            }
        }
        public static void GetPhanQuyenChungTu(object IDDanhMucPhanQuyen, object IDDanhMucChungTu, out bool Xem, out bool Them, out bool Sua, out bool Xoa)
        {
            Xem = false;
            Them = false;
            Sua = false;
            Xoa = false;
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                dao.GetPhanQuyenChungTu(IDDanhMucPhanQuyen, IDDanhMucChungTu, out Xem, out Them, out Sua, out Xoa);
            }
            catch (Exception ex)
            {
            }
        }
        public static void GetPhanQuyenBaoCao(object IDDanhMucPhanQuyen, object IDDanhMucBaoCao, out bool Xem)
        {
            Xem = false;
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                dao.GetPhanQuyenBaoCao(IDDanhMucPhanQuyen, IDDanhMucBaoCao, out Xem);
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class DanhMucPhanQuyenDonViBUS
    {
        public static DataTable List(Object ID = null, Object IDDanhMucPhanQuyen = null)
        {
            try
            {
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
                return dao.List(ID, IDDanhMucPhanQuyen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucPhanQuyenDonVi obj)
        {
            try
            {
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucPhanQuyenDonVi obj)
        {
            try
            {
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
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
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucPhanQuyenLoaiDoiTuongBUS
    {
        public static DataTable List(Object ID = null, Object IDDanhMucPhanQuyen = null)
        {
            try
            {
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
                return dao.List(ID, IDDanhMucPhanQuyen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucPhanQuyenLoaiDoiTuong obj)
        {
            try
            {
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucPhanQuyenLoaiDoiTuong obj)
        {
            try
            {
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
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
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucPhanQuyenChungTuBUS
    {
        public static DataTable List(Object ID = null, Object IDDanhMucPhanQuyen = null)
        {
            try
            {
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
                return dao.List(ID, IDDanhMucPhanQuyen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucPhanQuyenChungTu obj)
        {
            try
            {
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucPhanQuyenChungTu obj)
        {
            try
            {
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
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
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }

    public class DanhMucPhanQuyenBaoCaoBUS
    {
       
        public static DataTable List(Object ID = null, Object IDDanhMucPhanQuyen = null)
        {
            try
            {
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
                return dao.List(ID, IDDanhMucPhanQuyen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucPhanQuyenBaoCao obj)
        {
            try
            {
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucPhanQuyenBaoCao obj)
        {
            try
            {
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
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
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }
}
