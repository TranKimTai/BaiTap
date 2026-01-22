using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmBenhNhan : Form
    {
        BenhNhanBUS bnBUS = new BenhNhanBUS();
        private string currMode = "";
        private int currMaBN = 0;

        public frmBenhNhan()
        {
            InitializeComponent();
        }

        private void frmBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();
            SetButton(true);
        }

        private void LoadData(string keyword = "")
        {
            DataTable dt = string.IsNullOrEmpty(keyword) ? bnBUS.GetAllBenhNhan() : bnBUS.TimKiemBenhNhan(keyword);
            dgvBenhNhan.DataSource = dt;
            HienDuLieu();
        }

        private void HienDuLieu()
        {
            if (dgvBenhNhan.Columns.Count > 0)
            {
                dgvBenhNhan.Columns["MaBN"].HeaderText = "Mã BN";
                dgvBenhNhan.Columns["HoTenBN"].HeaderText = "Họ Tên";
                dgvBenhNhan.Columns["NamSinhBN"].HeaderText = "Năm Sinh";
                dgvBenhNhan.Columns["GioiTinhBN"].HeaderText = "Giới Tính";
                dgvBenhNhan.Columns["SDT_BN"].HeaderText = "SĐT";
                dgvBenhNhan.Columns["DiaChiBN"].HeaderText = "Địa Chỉ";
                dgvBenhNhan.Columns["TienSuBenh"].HeaderText = "Tiền Sử";
                dgvBenhNhan.Columns["TrangThai"].HeaderText = "Trạng thái";

            }
        }

        private void SetNull()
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            cboGioiTinh.SelectedIndex = -1;
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTienSu.Clear();

            currMaBN = 0;
            txtHoTen.Focus();
        }

        private void SetButton(bool viewMode)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = viewMode;
            btnLuu.Enabled = btnBoQua.Enabled = !viewMode;
            tlpInput.Enabled = !viewMode;
            dgvBenhNhan.Enabled = viewMode;
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvBenhNhan.Rows[e.RowIndex];
            currMaBN = Convert.ToInt32(r.Cells["MaBN"].Value);

            txtHoTen.Text = r.Cells["HoTenBN"].Value?.ToString() ?? "";
            txtNamSinh.Text = r.Cells["NamSinhBN"].Value?.ToString() ?? "";
            cboGioiTinh.Text = r.Cells["GioiTinhBN"].Value?.ToString() ?? "";
            txtSDT.Text = r.Cells["SDT_BN"].Value?.ToString() ?? "";
            txtDiaChi.Text = r.Cells["DiaChiBN"].Value?.ToString() ?? "";
            txtTienSu.Text = r.Cells["TienSuBenh"].Value?.ToString() ?? "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            currMode = "THEM";
            SetButton(false);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            txtTimKiem.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaBN == 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currMode = "SUA";
            SetButton(false);
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaBN == 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bệnh nhân này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bnBUS.XoaBenhNhan(currMaBN))
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
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (cboGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }

            if (!int.TryParse(txtNamSinh.Text, out int namSinh) || namSinh < 1900 || namSinh > DateTime.Now.Year)
            {
                MessageBox.Show($"Năm sinh không hợp lệ (1900-{DateTime.Now.Year})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            BenhNhan bn = new BenhNhan
            {
                HoTenBN = txtHoTen.Text.Trim(),
                GioiTinhBN = cboGioiTinh.Text,
                NamSinhBN = namSinh,
                SDT_BN = txtSDT.Text.Trim(),
                DiaChiBN = txtDiaChi.Text.Trim(),
                TienSuBenh = txtTienSu.Text.Trim()
            };

            try
            {
                bool result = false;
                if (currMode == "THEM")
                    result = bnBUS.ThemBenhNhan(bn);
                else if (currMode == "SUA")
                {
                    bn.MaBN = currMaBN;
                    result = bnBUS.SuaBenhNhan(bn);
                }

                if (result)
                {
                    MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetNull();
                    SetButton(true);
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên bệnh nhân cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return;
            }
            LoadData(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pnlInput_Paint(object sender, PaintEventArgs e) { }
    }
}