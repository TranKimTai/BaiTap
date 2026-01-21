using System;

namespace QuanLyPhongKham.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTenNV { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string QuyenHan { get; set; } // Admin, BacSi, LeTan, ThuNgan
        public DateTime? NgaySinhNV { get; set; } // Cho phép null
        public string GioiTinhNV { get; set; }
        public string SDT_NV { get; set; }
        public string DiaChiNV { get; set; }
        public bool TrangThaiNV { get; set; } // Bit trong SQL là bool trong C#

        // Constructor mặc định
        public NhanVien() { }
    }
}