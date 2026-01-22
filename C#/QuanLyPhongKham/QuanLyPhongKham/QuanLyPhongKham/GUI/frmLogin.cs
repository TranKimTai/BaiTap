using System;
using System.Windows.Forms;
using QuanLyPhongKham.BUS; // Gọi BUS
using QuanLyPhongKham.DTO; // Gọi DTO

namespace QuanLyPhongKham.GUI
{
    public partial class frmLogin : Form
    {
        // Khai báo BUS để kiểm tra đăng nhập
        NhanVienBUS nvBUS = new NhanVienBUS();

        public frmLogin()
        {
            InitializeComponent();
        }

        // Sự kiện nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtTaiKhoan.Text.Trim();
            string p = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!"); return;
            }

            // Gọi hàm kiểm tra đăng nhập bên BUS
            if (nvBUS.KiemTraDangNhap(u, p))
            {
                MessageBox.Show("Đăng nhập thành công!\nXin chào: " + Session.HoTen);

                // Ẩn form đăng nhập đi
                this.Hide();

                // Mở form Main lên
                frmMain f = new frmMain();
                f.ShowDialog();

                // Khi tắt form Main thì tắt luôn chương trình
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        // Sự kiện nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}