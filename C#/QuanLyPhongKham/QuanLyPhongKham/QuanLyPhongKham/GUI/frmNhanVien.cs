using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmNhanVien : Form
    {
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private string currMode = "";
        private int currMaNV = 0;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            SetButton(true); // Chế độ Xem
        }

        private void LoadData()
        {
            DataTable dt = nvBUS.GetDanhSachNhanVien();
            dgvNhanVien.DataSource = dt;
            ConfigGrid();
        }

        private void ConfigGrid()
        {
            if (dgvNhanVien.Columns.Count > 0)
            {
                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                dgvNhanVien.Columns["HoTenNV"].HeaderText = "Họ tên";
                dgvNhanVien.Columns["TaiKhoan"].HeaderText = "Tài khoản";
                dgvNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
                dgvNhanVien.Columns["QuyenHan"].HeaderText = "Chức vụ";
                dgvNhanVien.Columns["NgaySinhNV"].HeaderText = "Ngày sinh";
                dgvNhanVien.Columns["GioiTinhNV"].HeaderText = "Giới tính";
                dgvNhanVien.Columns["SDT_NV"].HeaderText = "SĐT";
                dgvNhanVien.Columns["DiaChiNV"].HeaderText = "Địa chỉ";
                dgvNhanVien.Columns["TrangThaiNV"].HeaderText = "Đang làm";

                dgvNhanVien.Columns["NgaySinhNV"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void SetNull()
        {
            txtHoTen.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            if (cboQuyenHan.Items.Count > 0) cboQuyenHan.SelectedIndex = 0;
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            chkTrangThai.Checked = true;

            currMaNV = 0; // Reset ID để an toàn
            txtHoTen.Focus();
        }

        // --- HÀM BẬT/TẮT NÚT VÀ INPUT ---
        private void SetButton(bool viewMode)
        {
            // 1. Nút chức năng
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = viewMode;
            btnLuu.Enabled = btnBoQua.Enabled = !viewMode;

            // 2. Vùng nhập liệu (TableLayoutPanel)
            // Khi xem (viewMode=true) -> Enabled=false (Mờ đi, ko cho nhập)
            // Khi thêm/sửa (viewMode=false) -> Enabled=true (Sáng lên, cho nhập)
            tlpInput.Enabled = !viewMode;

            // 3. Bảng dữ liệu
            dgvNhanVien.Enabled = viewMode; // Khóa bảng khi đang sửa
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvNhanVien.Rows[e.RowIndex];

            if (r.Cells["MaNV"].Value == null || r.Cells["MaNV"].Value == DBNull.Value) return;
            currMaNV = Convert.ToInt32(r.Cells["MaNV"].Value);

            // Đổ dữ liệu an toàn
            txtHoTen.Text = r.Cells["HoTenNV"].Value?.ToString() ?? "";
            txtTaiKhoan.Text = r.Cells["TaiKhoan"].Value?.ToString() ?? "";
            txtMatKhau.Text = r.Cells["MatKhau"].Value?.ToString() ?? "";
            txtSDT.Text = r.Cells["SDT_NV"].Value?.ToString() ?? "";
            txtDiaChi.Text = r.Cells["DiaChiNV"].Value?.ToString() ?? "";

            cboQuyenHan.Text = r.Cells["QuyenHan"].Value?.ToString() ?? "";
            cboGioiTinh.Text = r.Cells["GioiTinhNV"].Value?.ToString() ?? "";

            if (r.Cells["NgaySinhNV"].Value != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(r.Cells["NgaySinhNV"].Value);

            if (r.Cells["TrangThaiNV"].Value != DBNull.Value)
                chkTrangThai.Checked = Convert.ToBoolean(r.Cells["TrangThaiNV"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull(); // Reset form & ID
            currMode = "THEM";
            SetButton(false);

            // Khi Thêm: Mở ô Tài khoản cho nhập
            txtTaiKhoan.Enabled = true;
            txtTaiKhoan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaNV == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currMode = "SUA";
            SetButton(false);

            // Khi Sửa: Khóa riêng ô Tài khoản (không cho sửa username)
            txtTaiKhoan.Enabled = false;

            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaNV == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nvBUS.XoaNhanVien(currMaNV))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetNull();
                    SetButton(true);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- VALIDATION ---
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            { MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtHoTen.Focus(); return; }

            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            { MessageBox.Show("Vui lòng nhập tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtTaiKhoan.Focus(); return; }

            if (cboQuyenHan.SelectedIndex == -1)
            { MessageBox.Show("Vui lòng chọn chức vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); cboQuyenHan.Focus(); return; }

            // --- TẠO ĐỐI TƯỢNG ---
            NhanVien nv = new NhanVien
            {
                HoTenNV = txtHoTen.Text.Trim(),
                TaiKhoan = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                QuyenHan = cboQuyenHan.Text,
                NgaySinhNV = dtpNgaySinh.Value,
                SDT_NV = txtSDT.Text.Trim(),
                DiaChiNV = txtDiaChi.Text.Trim(),
                GioiTinhNV = cboGioiTinh.Text,
                TrangThaiNV = chkTrangThai.Checked
            };

            // --- GỌI BUS ---
            try
            {
                bool kq = false;
                if (currMode == "THEM")
                    kq = nvBUS.ThemNhanVien(nv);
                else if (currMode == "SUA")
                {
                    nv.MaNV = currMaNV;
                    kq = nvBUS.SuaNhanVien(nv);
                }

                if (kq)
                {
                    MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetNull();
                    SetButton(true);
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại! (Có thể tài khoản đã tồn tại)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }

        // Các sự kiện UI thừa
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtMatKhau_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pnlInput_Paint(object sender, PaintEventArgs e) { }
        private void pnlLeft_Paint(object sender, PaintEventArgs e) { }
        private void pnlLeft_Paint_1(object sender, PaintEventArgs e) { }
    }
}