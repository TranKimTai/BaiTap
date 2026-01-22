using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.DAL
{
    public class BenhNhanDAL
    {
        // 1. Hàm lấy TOÀN BỘ danh sách (Không tham số)
        public DataTable GetAllBenhNhan()
        {
            string query = "SELECT * FROM BENHNHAN WHERE TrangThai = 1";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // 2. Hàm TÌM KIẾM riêng (Có tham số keyword)
        public DataTable TimKiemBenhNhan(string keyword)
        {
            string query = "SELECT * FROM BENHNHAN WHERE HoTenBN LIKE @Keyword OR SDT_BN LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // 3. Thêm
        public bool ThemBenhNhan(BenhNhan bn)
        {
            string query = "INSERT INTO BENHNHAN (HoTenBN, NamSinhBN, GioiTinhBN, SDT_BN, DiaChiBN, TienSuBenh) " +
                           "VALUES (@HoTen, @NamSinh, @GioiTinh, @SDT, @DiaChi, @TienSu)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@HoTen", bn.HoTenBN),
                new SqlParameter("@NamSinh", bn.NamSinhBN ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", bn.GioiTinhBN),
                new SqlParameter("@SDT", bn.SDT_BN),
                new SqlParameter("@DiaChi", bn.DiaChiBN),
                new SqlParameter("@TienSu", bn.TienSuBenh)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // 4. Sửa
        public bool SuaBenhNhan(BenhNhan bn)
        {
            string query = "UPDATE BENHNHAN SET HoTenBN=@HoTen, NamSinhBN=@NamSinh, GioiTinhBN=@GioiTinh, " +
                           "SDT_BN=@SDT, DiaChiBN=@DiaChi, TienSuBenh=@TienSu WHERE MaBN=@MaBN";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaBN", bn.MaBN),
                new SqlParameter("@HoTen", bn.HoTenBN),
                new SqlParameter("@NamSinh", bn.NamSinhBN ?? (object)DBNull.Value),
                new SqlParameter("@GioiTinh", bn.GioiTinhBN),
                new SqlParameter("@SDT", bn.SDT_BN),
                new SqlParameter("@DiaChi", bn.DiaChiBN),
                new SqlParameter("@TienSu", bn.TienSuBenh)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // 5. Xóa
        public bool XoaBenhNhan(int maBN)
        {
            string query = "UPDATE BENHNHAN SET TrangThai = 0 WHERE MaBN = @MaBN";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@MaBN", maBN) };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }
    }
}