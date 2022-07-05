using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreDTO
{
    public class webAPIresponse
    {
        public int Status = 0; //0: không có lỗi, 1: có lỗi
        public string Data = string.Empty; //Dữ liệu trả về kiểu json
        public string ErrorMsg = string.Empty; //Thông báo lỗi hiển thị cho người dùng
    }
}
