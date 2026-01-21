using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham.DAL
{
    public class DatabaseHelper
    {
        // LƯU Ý: Bạn cần thay đổi chuỗi kết nối này cho đúng với máy của bạn
        // Data Source = Tên Máy chủ SQL của bạn (ví dụ: .\SQLEXPRESS hoặc LOCALHOST)
        private static string connectionString = @"Data Source=LAPTOP-DCE4C360\BEGAU;Initial Catalog=QuanLy_PhongKham;Integrated Security=True";

        // Hàm lấy kết nối
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm thực thi truy vấn trả về bảng dữ liệu (Dùng cho SELECT)
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    conn.Open();
                    da.Fill(dt);
                    conn.Close();

                    return dt;
                }
            }
        }

        // Hàm thực thi truy vấn không trả về dữ liệu (Dùng cho INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                    conn.Close();

                    return rowsAffected;
                }
            }
        }
    }
}