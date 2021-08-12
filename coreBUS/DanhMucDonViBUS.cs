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
        public static bool Insert(ref DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
