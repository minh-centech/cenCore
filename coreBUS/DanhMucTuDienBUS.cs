using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucTuDienBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ref DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
