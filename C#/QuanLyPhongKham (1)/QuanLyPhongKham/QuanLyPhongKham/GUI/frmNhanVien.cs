using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;// Nhớ using BUS
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmNhanVien : Form
    {
        NhanVienBUS nvBUS = new NhanVienBUS();
        private string currMode = ""; // Lưu trạng thái: "THEM" hoặc "SUA"
        private int currMaNV = 0; // Lưu Mã NV đang chọn để sửa/xóa
        public frmNhanVien()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form vừa load lên
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            chkTrangThai.Checked = true;
            SetButton(true);
        }

        // Hàm đổ dữ liệu vào bảng
        private void LoadData()
        {
            DataTable dt = nvBUS.GetDanhSachNhanVien();
            dgvNhanVien.DataSource = dt;

            // Đặt tên cột hiển thị tiếng Việt (KHÔNG ẨN CỘT NÀO)
            if (dgvNhanVien.Columns.Count > 0)
            {
                if (dgvNhanVien.Columns.Contains("MaNV")) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvNhanVien.Columns.Contains("HoTenNV")) dgvNhanVien.Columns["HoTenNV"].HeaderText = "Họ tên";
                if (dgvNhanVien.Columns.Contains("TaiKhoan")) dgvNhanVien.Columns["TaiKhoan"].HeaderText = "Tài khoản";

                // Mật khẩu vẫn hiện theo yêu cầu của bạn
                if (dgvNhanVien.Columns.Contains("MatKhau")) dgvNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";

                if (dgvNhanVien.Columns.Contains("QuyenHan")) dgvNhanVien.Columns["QuyenHan"].HeaderText = "Chức vụ";
                if (dgvNhanVien.Columns.Contains("NgaySinhNV")) dgvNhanVien.Columns["NgaySinhNV"].HeaderText = "Ngày sinh";

                // Các cột mới
                if (dgvNhanVien.Columns.Contains("GioiTinhNV")) dgvNhanVien.Columns["GioiTinhNV"].HeaderText = "Giới tính";
                if (dgvNhanVien.Columns.Contains("SDT_NV")) dgvNhanVien.Columns["SDT_NV"].HeaderText = "SĐT";
                if (dgvNhanVien.Columns.Contains("DiaChiNV")) dgvNhanVien.Columns["DiaChiNV"].HeaderText = "Địa chỉ";
                if (dgvNhanVien.Columns.Contains("TrangThaiNV")) dgvNhanVien.Columns["TrangThaiNV"].HeaderText = "Đang làm";
            }
        }

        private void SetNull()
        {
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = ""; // <--- Reset ô địa chỉ mới

            if (cboQuyenHan.Items.Count > 0) cboQuyenHan.SelectedIndex = 0;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;

            chkTrangThai.Checked = true;

            dtpNgaySinh.Value = DateTime.Now;
            txtTaiKhoan.Enabled = true;
        }

        private void SetButton(bool val)
        {
            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnLuu.Enabled = !val;
            btnBoQua.Enabled = !val;

            // Khóa các ô nhập liệu khi chưa bấm nút Thêm/Sửa
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                currMaNV = Convert.ToInt32(row.Cells["MaNV"].Value);

                // Đổ dữ liệu text cơ bản
                txtHoTen.Text = row.Cells["HoTenNV"].Value.ToString();
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString(); // Hiện lại mật khẩu để sửa
                txtSDT.Text = row.Cells["SDT_NV"].Value.ToString();
                cboQuyenHan.Text = row.Cells["QuyenHan"].Value.ToString();

                // Đổ dữ liệu ĐỊA CHỈ (Kiểm tra null)
                if (dgvNhanVien.Columns.Contains("DiaChiNV") && row.Cells["DiaChiNV"].Value != DBNull.Value)
                    txtDiaChi.Text = row.Cells["DiaChiNV"].Value.ToString();
                else
                    txtDiaChi.Text = "";

                // Đổ dữ liệu GIỚI TÍNH
                if (row.Cells["GioiTinhNV"].Value != DBNull.Value)
                    cboGioiTinh.Text = row.Cells["GioiTinhNV"].Value.ToString();

                // Đổ dữ liệu NGÀY SINH
                if (row.Cells["NgaySinhNV"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinhNV"].Value);

                // Đổ dữ liệu TRẠNG THÁI (CHECKBOX)
                if (dgvNhanVien.Columns.Contains("TrangThaiNV") && row.Cells["TrangThaiNV"].Value != DBNull.Value)
                {
                    chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThaiNV"].Value);
                }
                else
                {
                    chkTrangThai.Checked = false;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(false); // Ẩn Thêm/Sửa/Xóa, Hiện Lưu/Bỏ qua
            currMode = "THEM";
            txtTaiKhoan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaNV == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }
            SetButton(false);
            currMode = "SUA";
            txtTaiKhoan.Enabled = false; // Không cho sửa tài khoản
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaNV == 0) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (nvBUS.XoaNhanVien(currMaNV))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    SetNull();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text)) { MessageBox.Show("Vui lòng nhập họ tên!"); return; }
            if (string.IsNullOrEmpty(txtTaiKhoan.Text)) { MessageBox.Show("Vui lòng nhập tài khoản!"); return; }

            NhanVien nv = new NhanVien();
            nv.HoTenNV = txtHoTen.Text;
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            nv.QuyenHan = cboQuyenHan.Text;
            nv.NgaySinhNV = dtpNgaySinh.Value;
            nv.SDT_NV = txtSDT.Text;

            // Lấy dữ liệu mới thêm
            nv.DiaChiNV = txtDiaChi.Text;           // <--- Lấy địa chỉ
            nv.GioiTinhNV = cboGioiTinh.Text;       // <--- Lấy giới tính
            nv.TrangThaiNV = chkTrangThai.Checked;  // <--- Lấy trạng thái

            bool ketQua = false;
            if (currMode == "THEM")
            {
                ketQua = nvBUS.ThemNhanVien(nv);
            }
            else if (currMode == "SUA")
            {
                nv.MaNV = currMaNV;
                ketQua = nvBUS.SuaNhanVien(nv);
            }

            if (ketQua)
            {
                MessageBox.Show("Thao tác thành công!");
                LoadData();
                SetButton(true);
                SetNull();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại! Có thể tài khoản đã tồn tại.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }

        private void pnlLeft_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}