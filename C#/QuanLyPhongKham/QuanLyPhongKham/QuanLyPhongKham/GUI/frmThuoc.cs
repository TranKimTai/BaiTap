using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmThuoc : Form
    {
        private ThuocBUS thuocBUS = new ThuocBUS();
        private string currMode = "";
        private int currMaThuoc = 0;

        public frmThuoc()
        {
            InitializeComponent();
        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
            SetButton(true);
        }

        private void LoadData(string keyword = "")
        {
            DataTable dt = thuocBUS.GetDanhSachThuoc(keyword);
            dgvThuoc.DataSource = dt;
            ConfigGrid();
        }

        private void ConfigGrid()
        {
            if (dgvThuoc.Columns.Count > 0)
            {
                dgvThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                dgvThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvThuoc.Columns["DonViTinh"].HeaderText = "Đơn Vị";
                dgvThuoc.Columns["DonGiaThuoc"].HeaderText = "Đơn Giá";
                dgvThuoc.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvThuoc.Columns["HoatChat"].HeaderText = "Hoạt Chất";

                dgvThuoc.Columns["DonGiaThuoc"].DefaultCellStyle.Format = "N0";
                dgvThuoc.Columns["DonGiaThuoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvThuoc.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvThuoc.Columns["TenThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetNull()
        {
            txtTenThuoc.Clear();
            cboDonViTinh.SelectedIndex = -1;
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtHoatChat.Clear();

            currMaThuoc = 0;
            txtTenThuoc.Focus();
        }

        private void SetButton(bool viewMode)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = viewMode;
            btnLuu.Enabled = btnBoQua.Enabled = !viewMode;

            tlpInput.Enabled = !viewMode;

            dgvThuoc.Enabled = viewMode;
        }

        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvThuoc.Rows[e.RowIndex];

            if (r.Cells["MaThuoc"].Value == null || r.Cells["MaThuoc"].Value == DBNull.Value) return;
            currMaThuoc = Convert.ToInt32(r.Cells["MaThuoc"].Value);

            txtTenThuoc.Text = r.Cells["TenThuoc"].Value?.ToString() ?? "";
            cboDonViTinh.Text = r.Cells["DonViTinh"].Value?.ToString() ?? "";
            txtHoatChat.Text = r.Cells["HoatChat"].Value?.ToString() ?? "";

            if (decimal.TryParse(r.Cells["DonGiaThuoc"].Value?.ToString(), out decimal gia))
                txtDonGia.Text = gia.ToString("0");
            else
                txtDonGia.Text = "0";

            if (int.TryParse(r.Cells["SoLuongTon"].Value?.ToString(), out int sl))
                txtSoLuong.Text = sl.ToString();
            else
                txtSoLuong.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            currMode = "THEM";
            SetButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaThuoc == 0)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currMode = "SUA";
            SetButton(false);
            txtTenThuoc.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaThuoc == 0)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa thuốc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (thuocBUS.XoaThuoc(currMaThuoc))
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
                catch
                {
                    MessageBox.Show("Không thể xóa! Thuốc này đã từng được kê đơn cho bệnh nhân.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA NHẬP LIỆU
            if (string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuoc.Focus(); return;
            }

            if (string.IsNullOrWhiteSpace(cboDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDonViTinh.Focus(); return;
            }

            // Xử lý giá tiền
            if (!decimal.TryParse(txtDonGia.Text, out decimal gia) || gia < 0)
            {
                MessageBox.Show("Đơn giá phải là số dương!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus(); return;
            }

            // Xử lý số lượng tồn
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên dương!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus(); return;
            }

            // 2. TẠO ĐỐI TƯỢNG THUỐC
            Thuoc t = new Thuoc
            {
                TenThuoc = txtTenThuoc.Text.Trim(),
                DonViTinh = cboDonViTinh.Text.Trim(),
                HoatChat = txtHoatChat.Text.Trim(),
                DonGiaThuoc = gia,
                SoLuongTon = sl
            };

            // 3. THỰC HIỆN LƯU (BẮT LỖI TRÙNG TÊN TẠI ĐÂY)
            try
            {
                bool result = false;
                if (currMode == "THEM")
                    result = thuocBUS.ThemThuoc(t);
                else if (currMode == "SUA")
                {
                    t.MaThuoc = currMaThuoc;
                    result = thuocBUS.SuaThuoc(t);
                }

                if (result)
                {
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetNull();
                    SetButton(true);
                }
                else
                {
                    MessageBox.Show("Lưu thất bại! Có lỗi khi ghi dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // --- LOGIC QUAN TRỌNG NHẤT: BẮT LỖI TRÙNG TÊN ---

                // Chuyển thông báo lỗi thành chữ thường để dễ so sánh
                string loi = ex.Message.ToLower();

                // Kiểm tra các từ khóa báo hiệu lỗi trùng lặp (UNIQUE KEY)
                if (loi.Contains("violation") || loi.Contains("unique") || loi.Contains("duplicate"))
                {
                    MessageBox.Show("Tên thuốc này ĐÃ CÓ trong kho!\nVui lòng kiểm tra lại tên hoặc đơn vị tính.",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Bôi đen tên thuốc để bạn sửa lại ngay
                    txtTenThuoc.Focus();
                    txtTenThuoc.SelectAll();
                }
                else
                {
                    // Các lỗi khác (Mất mạng, sai tên cột...)
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return;
            }
            LoadData(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void txtTimKiem_TextChanged_1(object sender, EventArgs e) { }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            txtTimKiem.Text = "";
        }
    }
}