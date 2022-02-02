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
        public static bool Insert(DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
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
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }

    }
}
