using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucLoaiDoiTuongBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable ListValidMa(object Ma)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.ListValidMa(Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucLoaiDoiTuong obj)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucLoaiDoiTuong obj)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
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
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GetTenBangDuLieu(object ID)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.GetTenBangDuLieu(ID);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static object GetID(object Ma)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.GetID(Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static object GetMa(object ID)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.GetMa(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static object GetIDThamSoHeThong(object MaThamSoLoaiDoiTuong)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(MaThamSoLoaiDoiTuong));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
