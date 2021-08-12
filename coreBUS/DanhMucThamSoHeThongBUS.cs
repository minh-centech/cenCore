using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucThamSoHeThongBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucThamSoHeThongDAO dao = new DanhMucThamSoHeThongDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ref DanhMucThamSoHeThong obj)
        {
            try
            {
                DanhMucThamSoHeThongDAO dao = new DanhMucThamSoHeThongDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucThamSoHeThong obj)
        {
            try
            {
                DanhMucThamSoHeThongDAO dao = new DanhMucThamSoHeThongDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucThamSoHeThong obj)
        {
            try
            {
                DanhMucThamSoHeThongDAO dao = new DanhMucThamSoHeThongDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object GetGiaTri(object Ma)
        {
            try
            {
                DanhMucThamSoHeThongDAO dao = new DanhMucThamSoHeThongDAO();
                return dao.GetGiaTri(Ma);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
