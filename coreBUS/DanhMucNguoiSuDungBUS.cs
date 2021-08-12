using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucNguoiSuDungBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
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
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.ListValidMa(Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ref DanhMucNguoiSuDung obj)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucNguoiSuDung obj)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucNguoiSuDung obj)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object GetID(object Ma, object Password, out object IDDanhMucPhanQuyen, out bool isAdmin)
        {
            IDDanhMucPhanQuyen = null;
            isAdmin = false;
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.GetID(Ma, Password, out IDDanhMucPhanQuyen, out isAdmin);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool UpdatePassword(object ID, object Password)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.UpdatePassword(ID, Password);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
