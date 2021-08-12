using coreDAO;
using coreDTO;
using System;
using System.Data;
namespace coreBUS
{
    public class NhatKyDuLieuBUS
    {
        public static DataTable List()
        {
            try
            {
                NhatKyDuLieuDAO dao = new NhatKyDuLieuDAO();
                return dao.List();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
