using System;

namespace QuanLyPhongKham.DTO
{
    public class Thuoc
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGiaThuoc { get; set; } // SQL là DECIMAL -> C# là decimal
        public int SoLuongTon { get; set; }
        public string HoatChat { get; set; }
    }
}