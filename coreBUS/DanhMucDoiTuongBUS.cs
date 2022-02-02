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
        public static bool Insert(DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
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
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Delete(ID);
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
