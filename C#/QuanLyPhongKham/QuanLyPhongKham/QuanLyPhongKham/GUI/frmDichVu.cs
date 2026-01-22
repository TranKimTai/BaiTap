using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System.Data.SqlClient; 
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmDichVu : Form
    {
        private DichVuBUS dvBUS = new DichVuBUS();
        private string currMode = "";
        private int currMaDV = 0;

        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
            SetButton(true);
        }

        private void LoadData(string keyword = "")
        {
            DataTable dt = dvBUS.GetDanhSachDichVu(keyword);
            dgvDichVu.DataSource = dt;
            ConfigGrid();
        }

        private void ConfigGrid()
        {
            if (dgvDichVu.Columns.Count > 0)
            {
                dgvDichVu.Columns["MaDV"].HeaderText = "Mã DV";
                dgvDichVu.Columns["TenDV"].HeaderText = "Tên Dịch Vụ";
                dgvDichVu.Columns["GiaDV"].HeaderText = "Đơn Giá";

                dgvDichVu.Columns["GiaDV"].DefaultCellStyle.Format = "N0";
                dgvDichVu.Columns["GiaDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDichVu.Columns["TenDV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetNull()
        {
            txtTenDV.Clear();
            txtGiaDV.Clear();
            currMaDV = 0;
            txtTenDV.Focus();
        }

        private void SetButton(bool viewMode)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = viewMode;
            btnLuu.Enabled = btnBoQua.Enabled = !viewMode;
            tlpInput.Enabled = !viewMode;
            dgvDichVu.Enabled = viewMode;
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvDichVu.Rows[e.RowIndex];

            if (r.Cells["MaDV"].Value == null || r.Cells["MaDV"].Value == DBNull.Value) return;
            currMaDV = Convert.ToInt32(r.Cells["MaDV"].Value);

            txtTenDV.Text = r.Cells["TenDV"].Value?.ToString() ?? "";

            if (decimal.TryParse(r.Cells["GiaDV"].Value?.ToString(), out decimal gia))
                txtGiaDV.Text = gia.ToString("0");
            else
                txtGiaDV.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            currMode = "THEM";
            SetButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaDV == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currMode = "SUA";
            SetButton(false);
            txtTenDV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaDV == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (dvBUS.XoaDichVu(currMaDV))
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
                    MessageBox.Show("Dịch vụ này đã được sử dụng trong phiếu khám, không thể xóa!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus(); return;
            }

            if (!decimal.TryParse(txtGiaDV.Text, out decimal gia) || gia < 0)
            {
                MessageBox.Show("Giá tiền phải là số dương!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaDV.Focus(); return;
            }

            // 2. Tạo đối tượng
            DichVu dv = new DichVu
            {
                TenDV = txtTenDV.Text.Trim(),
                GiaDV = gia
            };

            // 3. Thực hiện Lưu với cách bắt lỗi "bao sân"
            try
            {
                bool kq = false;
                if (currMode == "THEM")
                    kq = dvBUS.ThemDichVu(dv);
                else if (currMode == "SUA")
                {
                    dv.MaDV = currMaDV;
                    kq = dvBUS.SuaDichVu(dv);
                }

                if (kq)
                {
                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetNull();
                    SetButton(true);
                }
                else
                {
                    MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // --- ĐÂY LÀ PHẦN SỬA QUAN TRỌNG NHẤT ---

                // Lấy nội dung lỗi và chuyển thành chữ thường để so sánh cho dễ
                string loi = ex.Message.ToLower();

                // Kiểm tra xem trong câu lỗi có từ khóa báo trùng không
                // "unique", "duplicate" là từ khóa của SQL, "trùng" là phòng hờ
                if (loi.Contains("unique") || loi.Contains("duplicate") || loi.Contains("trùng"))
                {
                    MessageBox.Show("Tên này ĐÃ CÓ trong hệ thống!\nVui lòng đặt tên khác để không bị trùng.",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Tự động bôi đen tên để bạn nhập lại ngay
                    txtTenDV.Focus();
                    txtTenDV.SelectAll();
                }
                else
                {
                    // Nếu là lỗi khác thì mới hiện nguyên văn
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }
    }
}