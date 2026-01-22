using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    public static class Session
    {
        // Biến tĩnh (static) để truy cập từ bất cứ đâu mà không cần new
        public static int MaNV { get; set; } = 0;
        public static string HoTen { get; set; } = "";
        public static string QuyenHan { get; set; } = ""; // Admin, BacSi, ThuNgan, LeTan
    }
}
