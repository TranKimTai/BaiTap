using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.DAL
{
    public class ThuocDAL
    {
        // 1. Lấy danh sách (Có tìm kiếm)
        public DataTable GetDanhSachThuoc(string keyword = "")
        {
            string query = "SELECT * FROM THUOC";
            SqlParameter[] parameters = null;

            if (!string.IsNullOrEmpty(keyword))
            {
                query += " WHERE TenThuoc LIKE @Keyword OR HoatChat LIKE @Keyword";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };
            }
            // Sắp xếp thuốc mới nhất lên đầu
            query += " ORDER BY MaThuoc DESC";

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // 2. Thêm thuốc
        public bool ThemThuoc(Thuoc t)
        {
            string query = "INSERT INTO THUOC (TenThuoc, DonViTinh, DonGiaThuoc, SoLuongTon, HoatChat) " +
                           "VALUES (@Ten, @DVT, @Gia, @SL, @HoatChat)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Ten", t.TenThuoc),
                new SqlParameter("@DVT", t.DonViTinh),
                new SqlParameter("@Gia", t.DonGiaThuoc),
                new SqlParameter("@SL", t.SoLuongTon),
                new SqlParameter("@HoatChat", t.HoatChat ?? (object)DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // 3. Sửa thuốc
        public bool SuaThuoc(Thuoc t)
        {
            string query = "UPDATE THUOC SET TenThuoc = @Ten, DonViTinh = @DVT, " +
                           "DonGiaThuoc = @Gia, SoLuongTon = @SL, HoatChat = @HoatChat " +
                           "WHERE MaThuoc = @MaThuoc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaThuoc", t.MaThuoc),
                new SqlParameter("@Ten", t.TenThuoc),
                new SqlParameter("@DVT", t.DonViTinh),
                new SqlParameter("@Gia", t.DonGiaThuoc),
                new SqlParameter("@SL", t.SoLuongTon),
                new SqlParameter("@HoatChat", t.HoatChat ?? (object)DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // 4. Xóa thuốc
        public bool XoaThuoc(int maThuoc)
        {
            // Lưu ý: Nếu thuốc đã được kê đơn (nằm trong bảng TOATHUOC) thì SQL sẽ báo lỗi khóa ngoại.
            // Chúng ta sẽ bắt lỗi này ở GUI để thông báo cho người dùng.
            string query = "DELETE FROM THUOC WHERE MaThuoc = @MaThuoc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaThuoc", maThuoc)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}