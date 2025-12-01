using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Thư viện cung cấp các đối tượng để làm việc với SQL Server
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH13
{
    public partial class frmTacgia_Load : Form
    {
       

        public frmTacgia_Load()
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện (nút, textbox...)
        }

        // Sự kiện xảy ra khi Form được tải lên (Load)
        private void frmTacgia_Load_Load(object sender, EventArgs e)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu: Server là máy local (.), Database là LTUD_QLTV
            string connString = "server=.; database=LTUD_QLTV; Integrated Security =SSPI;";

            // Tạo đối tượng kết nối
            SqlConnection conn = new SqlConnection(connString);

            // Câu lệnh SQL lấy tất cả dữ liệu từ bảng tblTacgia
            string sql = "select * from tblTacgia";

            try
            {
                conn.Open(); // Mở kết nối đến database

                // Tạo đối tượng thực thi câu lệnh SQL
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text; // Xác định đây là câu lệnh dạng văn bản
                cmd.CommandText = sql; // Gán câu lệnh SQL

                // Thực thi lệnh Select và trả về bộ đọc dữ liệu (Reader)
                SqlDataReader reader = cmd.ExecuteReader();

                // Gọi hàm hiển thị dữ liệu đọc được
                hienthiReader(reader);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có vấn đề (ví dụ không kết nối được)
                MessageBox.Show("Lỗi xóa sự kiện!" + ex.ToString());
            }
            finally
            {
                conn.Close(); // Đóng kết nối để giải phóng tài nguyên (luôn chạy dù lỗi hay không)
            }
        }

        // Hàm hiển thị dữ liệu từ SqlDataReader lên Textbox
        private void hienthiReader(SqlDataReader reader)
        {
            // Vòng lặp đọc từng dòng dữ liệu
            while (reader.Read())
            {
                // Gán dữ liệu từ các cột trong database vào các Textbox tương ứng
                // Lưu ý: Code này sẽ ghi đè liên tục, chỉ hiển thị dòng cuối cùng đọc được
                this.txtMaTG.Text = reader["MaTG"].ToString();
                this.txtTenTG.Text = reader["TenTG"].ToString();
                this.txtDiaChi.Text = reader["Diachi"].ToString();
                this.txtDienthoaiTG.Text = reader["DienThoai"].ToString();
            }
        }

        // Sự kiện khi nhấn nút Thêm (dùng để xóa trắng các ô nhập liệu)
        private void btnThem_Click(object sender, EventArgs e)
        {
            setDefault(); // Gọi hàm reset giá trị về rỗng
        }

        // Hàm đặt các Textbox về trạng thái rỗng
        private void setDefault()
        {
            this.txtMaTG.Text = "";
            this.txtTenTG.Text = "";
            this.txtDiaChi.Text = "";
            this.txtDienthoaiTG.Text = "";
        }

        // Sự kiện khi nhấn nút Lưu (Thêm mới dữ liệu vào Database)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu người dùng nhập từ giao diện
            string matg = this.txtMaTG.Text;
            string tentg = this.txtTenTG.Text;
            string diachi = this.txtDiaChi.Text;
            string dienthoai = this.txtDienthoaiTG.Text;

            // Tạo câu lệnh SQL Insert (Lưu ý: Code gốc dùng 'value' thay vì 'VALUES')
            string sql = String.Format("Insert into tblTacgia values('{0}',N'{1}',N'{2}','{3}')", matg, tentg, diachi, dienthoai);

            // Khai báo lại chuỗi kết nối và tạo kết nối mới
            string connString = "server=.; database=LTUD_QLTV;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open(); // Mở kết nối
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                // Thực thi câu lệnh Insert (ExecuteNonQuery dùng cho lệnh không trả về dữ liệu)
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Bắt lỗi (thường là lỗi trùng khóa chính hoặc sai cú pháp SQL)
                MessageBox.Show(matg + "đã có trong CSDL!");
            }
            finally
            {
                conn.Close(); // Đóng kết nối
            }
        }

        // Sự kiện khi nhấn nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            

           
            // Lấy mã tác giả cần xóa
            string matg = this.txtMaTG.Text;

            // Tạo câu lệnh SQL 

            string sql = String.Format("Delete from tblTacgia where MaTG ='{0}'", matg);

            string connString = "server=.; database=LTUD_QLTV;Integrated Security=SSPI;";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                // Thực thi lệnh và lấy số dòng bị ảnh hưởng
                int kq = cmd.ExecuteNonQuery();

                // Kiểm tra kết quả (kq != -1 nghĩa là thực thi thành công trong một số ngữ cảnh cũ)
                if (kq != -1)
                {
                    MessageBox.Show("đã xóa thành công!" + matg );

                    // Sau khi xóa (hoặc thực hiện lệnh), load lại danh sách để cập nhật giao diện
                    sql = "select * from tblTacgia";
                    cmd.CommandText = sql;
                    SqlDataReader reader = cmd.ExecuteReader();
                    hienthiReader(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(matg + "không xóa thành công!");
            }
            finally
            {
                conn.Close();
            }

        }

        // Sự kiện khi nhấn nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 1. Khai báo chuỗi kết nối
            string connString = "server=.; database=LTUD_QLTV; Integrated Security =SSPI;";
            SqlConnection conn = new SqlConnection(connString);

           
            try
            {
                conn.Open();
                // 2. Câu lệnh SQL lấy dữ liệu
                string sql = "select * from tblTacgia";

                // 3. Sử dụng SqlDataAdapter để làm cầu nối trung gian
                // Nó tự động mở kết nối, lấy dữ liệu và đóng kết nối (rất tiện cho Grid)
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);

                // 4. Tạo một bảng dữ liệu ảo (DataTable) để chứa dữ liệu lấy về
                DataTable dt = new DataTable();

                // 5. Đổ dữ liệu từ Adapter vào DataTable
                ad.Fill(dt);

                // 6. Gán nguồn dữ liệu của DataGridView bằng DataTable vừa có
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lên lưới: " + ex.Message);
            }
            // Với SqlDataAdapter.Fill, ta thường không cần gọi conn.Close() thủ công 
            // vì nó tự quản lý, nhưng để chắc chắn bạn có thể thêm finally conn.Close() nếu muốn.
        }
    }
}