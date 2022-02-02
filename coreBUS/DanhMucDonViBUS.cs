using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucDonViBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
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
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
