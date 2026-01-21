using System;

namespace QuanLyPhongKham.DTO
{
    public class PhieuKham
    {
        public int MaPhieu { get; set; }
        public DateTime NgayKham { get; set; }
        public int MaBN { get; set; }
        public int MaNV { get; set; } // Bác sĩ khám

        // Thông tin sinh hiệu (cho phép null)
        public float CanNang { get; set; }
        public float ChieuCao { get; set; }
        public string HuyetAp { get; set; }
        public float NhietDo { get; set; }

        // Chẩn đoán
        public string TrieuChung { get; set; }
        public string ChanDoan { get; set; }
        public string LoiDan { get; set; }
        public DateTime? NgayTaiKham { get; set; } // Dấu ? nghĩa là có thể null

        // Trạng thái: 0=Chờ khám, 1=Đã khám, 2=Đã thanh toán
        public int TrangThaiPhieu { get; set; }

        public string HoTenBN { get; set; }

        public string TenBS { get; set; }
    }
}