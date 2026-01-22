using QuanLyPhongKham.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmMain : Form
    {
        private Form currentFormChild;

        public frmMain()
        {
            InitializeComponent();
        }

        // 3. Sự kiện Load form - Nơi thực hiện PHÂN QUYỀN & HIỆN TÊN
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.HoTen))
            {
                this.Text = "HỆ THỐNG QUẢN LÝ PHÒNG KHÁM - " + Session.HoTen + " (" + Session.QuyenHan + ")";
            }

            PhanQuyen();

            //footer
            if (!string.IsNullOrEmpty(Session.HoTen))
            {
                lblUser.Text = "Đang đăng nhập: " + Session.HoTen + " | Quyền: " + Session.QuyenHan;
            }

            // Khởi động đồng hồ
            timer1.Start();
        }
        private void PhanQuyen()
        {
            // Reset: Bật tất cả trước khi khóa
            tsbKhamBenh.Enabled = true;
            tsbThanhToan.Enabled = true;
            tsbThuoc.Enabled = true;
            tsbBenhNhan.Enabled = true;

            mnuNhanVien.Enabled = true;
            mnuDoanhThu.Enabled = true;

            // Bắt đầu khóa theo quyền
            if (Session.QuyenHan == "BacSi")
            {
                // Bác sĩ không được quản lý nhân viên, không xem doanh thu
                mnuNhanVien.Enabled = false;
                mnuDoanhThu.Enabled = false;
                tsbThanhToan.Enabled = false; // Bác sĩ chỉ khám, không thu tiền
            }
            else if (Session.QuyenHan == "ThuNgan")
            {
                // Thu ngân không được khám, không được sửa thuốc
                tsbKhamBenh.Enabled = false;
                tsbThuoc.Enabled = false;
                mnuNhanVien.Enabled = false;
            }
            else if (Session.QuyenHan == "LeTan")
            {
                // Lễ tân chỉ quản lý bệnh nhân
                tsbKhamBenh.Enabled = false;
                tsbThanhToan.Enabled = false;
                tsbThuoc.Enabled = false;
                mnuDoanhThu.Enabled = false;
            }
        }
        // --- 2. HÀM MỞ FORM CON (CHUẨN) ---
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlBody.Controls.Add(childForm);
            pnlBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            //pnlFooter.BringToFront();

            // Cập nhật tiêu đề Form Main để biết đang ở đâu
            this.Text = "HỆ THỐNG QUẢN LÝ PHÒNG KHÁM - " + childForm.Text.ToUpper();
        }
        //--HÀM XỬ LÝ ĐĂNG XUẤT--
        private void XuLyDangXuat()
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.MaNV = 0;
                Session.HoTen = "";
                Session.QuyenHan = "";

                this.Hide();
                frmLogin login = new frmLogin();
                login.ShowDialog();
                this.Close();
            }
        }

        // --- CÁC SỰ KIỆN CLICK MENU ---


        //Thanh công cụ
        private void tsbKhamBenh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhamBenh());
        }

        private void tsbThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThanhToan());
        }

        private void tsbThuoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThuoc());
        }

        private void tsbBenhNhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBenhNhan());
        }

        private void tsbThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            //chưa làm
            MessageBox.Show("Chức năng đang phát triển!");
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            XuLyDangXuat();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
        }

        private void mnuBenhNhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBenhNhan());
        }

        private void mnuThuoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThuoc());
        }

        private void mnuDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDichVu());
        }

        private void mnuKhamBenh_Click(object sender, EventArgs e)
        {
            tsbKhamBenh_Click(sender, e);
        }

        private void mnuThanhToan_Click(object sender, EventArgs e)
        {
            tsbThanhToan_Click(sender, e);
        }

        private void mnuDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
        }

        private void mnuLichSu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichSuKham());
        }


        //đồng hồ
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void lblClock_Click(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem người dùng có thực sự muốn thoát không
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Nếu chọn "No" (Không thoát) -> Hủy lệnh đóng cửa sổ
                e.Cancel = true;
            }
        }
    }
}