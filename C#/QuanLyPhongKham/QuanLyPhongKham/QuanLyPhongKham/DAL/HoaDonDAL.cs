using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.DAL
{
    public class HoaDonDAL
    {
        // 1. Lấy danh sách bệnh nhân ĐÃ KHÁM (Trạng thái = 1) để chờ thu tiền
        public DataTable GetDanhSachChoThanhToan(string keyword = "")
        {
            string query = @"SELECT p.MaPhieu, p.NgayKham, b.HoTenBN, b.NamSinhBN, b.SDT_BN
                             FROM PHIEUKHAM p
                             JOIN BENHNHAN b ON p.MaBN = b.MaBN
                             WHERE p.TrangThaiPhieu = 1"; // 1 = Đã khám xong

            if (!string.IsNullOrEmpty(keyword))
            {
                query += " AND (b.HoTenBN LIKE @Key OR b.SDT_BN LIKE @Key)";
            }

            SqlParameter[] param = { new SqlParameter("@Key", "%" + keyword + "%") };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 2. Tính tổng tiền Dịch vụ của 1 phiếu (Để hiển thị lên màn hình)
        public decimal GetTongTienDV(int maPhieu)
        {
            string query = "SELECT SUM(ThanhTienDV) FROM CHITIETDICHVU WHERE MaPhieu = " + maPhieu;

            // Lấy về cả bảng dữ liệu (DataTable)
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            // Kiểm tra: Nếu bảng có dòng và ô đầu tiên không rỗng
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0][0]); // Lấy giá trị ô dòng 0, cột 0
            }
            return 0;
        }

        // 3. Tính tổng tiền Thuốc của 1 phiếu
        public decimal GetTongTienThuoc(int maPhieu)
        {
            string query = "SELECT SUM(ThanhTienThuoc) FROM TOATHUOC WHERE MaPhieu = " + maPhieu;

            // Lấy về cả bảng dữ liệu
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            // Kiểm tra và lấy giá trị
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            return 0;
        }

        // 4. Lưu Hóa Đơn và Cập nhật trạng thái Phiếu sang 2 (Hoàn tất)
        public bool ThanhToan(HoaDon hd)
        {
            // Transaction: Đảm bảo cả 2 lệnh (Lưu Hóa Đơn + Update Phiếu) cùng thành công hoặc cùng thất bại
            string query = @"INSERT INTO HOADON (MaPhieu, MaNV, TongTienDV, TongTienThuoc, TongThanhToan, HinhThucTT, GhiChuHD)
                             VALUES (@MaPhieu, @MaNV, @TienDV, @TienThuoc, @Tong, @HT, @GhiChu);

                             UPDATE PHIEUKHAM SET TrangThaiPhieu = 2 WHERE MaPhieu = @MaPhieu;";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", hd.MaPhieu),
                new SqlParameter("@MaNV", hd.MaNV),
                new SqlParameter("@TienDV", hd.TongTienDV),
                new SqlParameter("@TienThuoc", hd.TongTienThuoc),
                new SqlParameter("@Tong", hd.TongThanhToan),
                new SqlParameter("@HT", hd.HinhThucTT),
                new SqlParameter("@GhiChu", hd.GhiChuHD ?? "")
            };

            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }
    }
}