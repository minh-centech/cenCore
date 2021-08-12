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
        public static bool Insert(ref DanhMucPhanQuyen obj)
        {
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucPhanQuyen obj)
        {
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucPhanQuyen obj)
        {
            try
            {
                DanhMucPhanQuyenDAO dao = new DanhMucPhanQuyenDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
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
        public static bool Insert(ref DanhMucPhanQuyenDonVi obj)
        {
            try
            {
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucPhanQuyenDonVi obj)
        {
            try
            {
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucPhanQuyenDonVi obj)
        {
            try
            {
                DanhMucPhanQuyenDonViDAO dao = new DanhMucPhanQuyenDonViDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
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
        public static bool Insert(ref DanhMucPhanQuyenLoaiDoiTuong obj)
        {
            try
            {
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucPhanQuyenLoaiDoiTuong obj)
        {
            try
            {
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucPhanQuyenLoaiDoiTuong obj)
        {
            try
            {
                DanhMucPhanQuyenLoaiDoiTuongDAO dao = new DanhMucPhanQuyenLoaiDoiTuongDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
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
        public static bool Insert(ref DanhMucPhanQuyenChungTu obj)
        {
            try
            {
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucPhanQuyenChungTu obj)
        {
            try
            {
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucPhanQuyenChungTu obj)
        {
            try
            {
                DanhMucPhanQuyenChungTuDAO dao = new DanhMucPhanQuyenChungTuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
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
        public static bool Insert(ref DanhMucPhanQuyenBaoCao obj)
        {
            try
            {
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucPhanQuyenBaoCao obj)
        {
            try
            {
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucPhanQuyenBaoCao obj)
        {
            try
            {
                DanhMucPhanQuyenBaoCaoDAO dao = new DanhMucPhanQuyenBaoCaoDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
