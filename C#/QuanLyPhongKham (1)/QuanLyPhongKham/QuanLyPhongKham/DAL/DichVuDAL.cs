using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.DAL
{
    public class DichVuDAL
    {
        // 1. Lấy danh sách
        public DataTable GetDanhSachDichVu(string keyword = "")
        {
            string query = "SELECT * FROM DICHVU";
            SqlParameter[] parameters = null;

            if (!string.IsNullOrEmpty(keyword))
            {
                query += " WHERE TenDV LIKE @Keyword";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };
            }
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // 2. Thêm
        public bool ThemDichVu(DichVu dv)
        {
            string query = "INSERT INTO DICHVU (TenDV, GiaDV) VALUES (@Ten, @Gia)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Ten", dv.TenDV),
                new SqlParameter("@Gia", dv.GiaDV)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // 3. Sửa
        public bool SuaDichVu(DichVu dv)
        {
            string query = "UPDATE DICHVU SET TenDV = @Ten, GiaDV = @Gia WHERE MaDV = @Ma";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Ma", dv.MaDV),
                new SqlParameter("@Ten", dv.TenDV),
                new SqlParameter("@Gia", dv.GiaDV)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        // 4. Xóa
        public bool XoaDichVu(int maDV)
        {
            string query = "DELETE FROM DICHVU WHERE MaDV = @Ma";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Ma", maDV) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}