using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyPhongKham.DAL
{
    public class ThongKeDAL
    {
        // Hàm này lấy danh sách hóa đơn chi tiết
        // Dùng để:
        // 1. Hiển thị lên DataGridView (Tab 1)
        // 2. Tính tổng tiền (Card Doanh Thu) bằng cách cộng cột TongThanhToan
        // 3. Đếm số dòng (Card Số Bệnh Nhân)
        public DataTable GetChiTietDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            // Join 4 bảng để lấy đầy đủ thông tin: Hóa đơn, Nhân viên thu ngân, Phiếu khám, Bệnh nhân
            string query = @"
                SELECT 
                    h.MaHD, 
                    h.NgayLapHD, 
                    nv.HoTenNV, 
                    b.HoTenBN, 
                    h.TongTienThuoc, 
                    h.TongTienDV, 
                    h.TongThanhToan
                FROM HOADON h
                JOIN NHANVIEN nv ON h.MaNV = nv.MaNV
                JOIN PHIEUKHAM p ON h.MaPhieu = p.MaPhieu
                JOIN BENHNHAN b ON p.MaBN = b.MaBN
                WHERE h.NgayLapHD BETWEEN @TuNgay AND @DenNgay
                ORDER BY h.NgayLapHD DESC"; // Sắp xếp ngày mới nhất lên đầu

            SqlParameter[] param = new SqlParameter[]
            {
                // Lấy từ 00:00:00 ngày bắt đầu
                new SqlParameter("@TuNgay", tuNgay.Date),
                
                // Lấy đến 23:59:59 ngày kết thúc
                new SqlParameter("@DenNgay", denNgay.Date.AddDays(1).AddSeconds(-1))
            };

            return DatabaseHelper.ExecuteQuery(query, param);
        }
    }
}