using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.DAL
{
    public class NhanVienDAL
    {
        // 1. Kiểm tra đăng nhập
        public DataTable DangNhap(string taiKhoan, string matKhau)
        {
            // Chỉ đăng nhập được nếu TrangThaiNV = 1 (Đang hoạt động)
            string query = "SELECT * FROM NHANVIEN WHERE TaiKhoan = @User AND MatKhau = @Pass AND TrangThaiNV = 1";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@User", taiKhoan),
                new SqlParameter("@Pass", matKhau)
            };

            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 2. Lấy danh sách nhân viên
        public DataTable GetDanhSachNhanVien()
        {
            string query = "SELECT * FROM NHANVIEN ORDER BY HoTenNV ASC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // 3. Thêm nhân viên mới (Đã bổ sung Giới tính, Địa chỉ, Trạng thái)
        public bool ThemNhanVien(NhanVien nv)
        {
            string query = "INSERT INTO NHANVIEN (HoTenNV, TaiKhoan, MatKhau, QuyenHan, NgaySinhNV, SDT_NV, GioiTinhNV, DiaChiNV, TrangThaiNV) " +
                           "VALUES (@HoTen, @TaiKhoan, @MatKhau, @QuyenHan, @NgaySinh, @SDT, @GioiTinh, @DiaChi, @TrangThai)";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@HoTen", nv.HoTenNV),
                new SqlParameter("@TaiKhoan", nv.TaiKhoan),
                new SqlParameter("@MatKhau", nv.MatKhau),
                new SqlParameter("@QuyenHan", nv.QuyenHan),
                new SqlParameter("@NgaySinh", nv.NgaySinhNV), // DatabaseHelper tự xử lý null nếu viết tốt, hoặc dùng ?? DBNull.Value
                new SqlParameter("@SDT", nv.SDT_NV),
                new SqlParameter("@GioiTinh", nv.GioiTinhNV), // <--- Mới thêm
                new SqlParameter("@DiaChi", nv.DiaChiNV),     // <--- Mới thêm
                new SqlParameter("@TrangThai", nv.TrangThaiNV) // <--- Mới thêm (Lấy từ CheckBox)
            };

            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // 4. Sửa nhân viên (Đã bổ sung Giới tính, Địa chỉ, Trạng thái)
        public bool SuaNhanVien(NhanVien nv)
        {
            // Cập nhật cả Giới tính, Địa chỉ và Trạng thái (để cho phép khóa tài khoản/nghỉ việc)
            string query = "UPDATE NHANVIEN SET HoTenNV = @HoTen, QuyenHan = @QuyenHan, NgaySinhNV = @NgaySinh, " +
                           "SDT_NV = @SDT, GioiTinhNV = @GioiTinh, DiaChiNV = @DiaChi, TrangThaiNV = @TrangThai " +
                           "WHERE MaNV = @MaNV";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@HoTen", nv.HoTenNV),
                new SqlParameter("@QuyenHan", nv.QuyenHan),
                new SqlParameter("@NgaySinh", nv.NgaySinhNV),
                new SqlParameter("@SDT", nv.SDT_NV),
                new SqlParameter("@GioiTinh", nv.GioiTinhNV), // <--- Mới thêm
                new SqlParameter("@DiaChi", nv.DiaChiNV),     // <--- Mới thêm
                new SqlParameter("@TrangThai", nv.TrangThaiNV) // <--- Mới thêm
            };

            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // 5. Xóa nhân viên (Xóa mềm - Chuyển trạng thái về 0)
        public bool XoaNhanVien(int maNV)
        {
            string query = "UPDATE NHANVIEN SET TrangThaiNV = 0 WHERE MaNV = @MaNV";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV)
            };

            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }
    }
}