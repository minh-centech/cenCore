using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucDoiTuongBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable ValidMa(object IDDanhMucLoaiDoiTuong, object Ma)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.ValidMa(IDDanhMucLoaiDoiTuong, Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ref DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object GetID(object IDDanhMucLoaiDoiTuong, object Ma)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.GetID(IDDanhMucLoaiDoiTuong, Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
