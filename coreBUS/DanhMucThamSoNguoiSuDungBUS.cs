using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class DanhMucThamSoNguoiSuDungBUS
    {
        public static DataTable List(object ID)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(DanhMucThamSoNguoiSuDung obj)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DanhMucThamSoNguoiSuDung obj)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
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
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.Delete(ID);
            }
            catch (Exception ex) { return false; }
        }
        public static object GetGiaTri(object Ma)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.GetGiaTri(Ma);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object UpdateGiaTri(object Ma, object GiaTri)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.UpdateGiaTri(Ma, GiaTri);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
