using System;

namespace QuanLyPhongKham.DTO
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaPhieu { get; set; }
        public DateTime NgayLapHD { get; set; }
        public int MaNV { get; set; } // Nhân viên thu ngân
        public decimal TongTienDV { get; set; }
        public decimal TongTienThuoc { get; set; }
        public decimal TongThanhToan { get; set; }
        public string HinhThucTT { get; set; } // Tiền mặt / Chuyển khoản
        public string GhiChuHD { get; set; }
    }
}