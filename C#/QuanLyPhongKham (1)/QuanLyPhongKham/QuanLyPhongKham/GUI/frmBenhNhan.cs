using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmBenhNhan : Form
    {
        // 1. Khai báo BUS
        BenhNhanBUS bnBUS = new BenhNhanBUS();

        // 2. Biến lưu trạng thái
        private string currMode = "";
        private int currMaBN = 0;

        public frmBenhNhan()
        {
            InitializeComponent();
        }

        // 3. Sự kiện Load Form
        private void frmBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();      // Tải dữ liệu

            // --- SỬA QUAN TRỌNG TẠI ĐÂY ---
            // true = Chế độ XEM (Hiện 3 nút Thêm/Sửa/Xóa, Ẩn nút Lưu/Bỏ qua, Khóa nhập liệu)
            SetButton(true);
        }

        // 4. Hàm Load dữ liệu
        private void LoadData(string keyword = "")
        {
            DataTable dt;
            if (string.IsNullOrEmpty(keyword))
                dt = bnBUS.GetAllBenhNhan();
            else
                dt = bnBUS.TimKiemBenhNhan(keyword);

            dgvBenhNhan.DataSource = dt;

            // Đặt tên cột hiển thị
            if (dgvBenhNhan.Columns.Count > 0)
            {
                dgvBenhNhan.Columns["MaBN"].HeaderText = "Mã BN";
                dgvBenhNhan.Columns["HoTenBN"].HeaderText = "Họ Tên";
                dgvBenhNhan.Columns["NamSinhBN"].HeaderText = "Năm Sinh";
                dgvBenhNhan.Columns["GioiTinhBN"].HeaderText = "Giới Tính";
                dgvBenhNhan.Columns["SDT_BN"].HeaderText = "SĐT";
                dgvBenhNhan.Columns["DiaChiBN"].HeaderText = "Địa Chỉ";
                dgvBenhNhan.Columns["TienSuBenh"].HeaderText = "Tiền Sử";
            }
        }

        // 5. Hàm Xóa trắng
        private void SetNull()
        {
            txtHoTen.Text = "";
            txtNamSinh.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTienSu.Text = "";
            txtHoTen.Focus();
        }

        // 6. Hàm Bật/Tắt nút (Logic cốt lõi)
        private void SetButton(bool val)
        {
            // val = true (Chế độ Xem): Sáng nút chức năng, Mờ nút lưu
            // val = false (Chế độ Nhập): Mờ nút chức năng, Sáng nút lưu
            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;

            btnLuu.Enabled = !val;
            btnBoQua.Enabled = !val;

            // Khóa/Mở GroupBox nhập liệu
        }

        // 7. Click bảng (Chỉ xem, KHÔNG tự động chuyển chế độ Sửa)
        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBenhNhan.Rows[e.RowIndex];
                currMaBN = Convert.ToInt32(row.Cells["MaBN"].Value);

                txtHoTen.Text = row.Cells["HoTenBN"].Value.ToString();

                if (row.Cells["NamSinhBN"].Value != DBNull.Value)
                    txtNamSinh.Text = row.Cells["NamSinhBN"].Value.ToString();
                else
                    txtNamSinh.Text = "";

                cboGioiTinh.Text = row.Cells["GioiTinhBN"].Value.ToString();
                txtSDT.Text = row.Cells["SDT_BN"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChiBN"].Value.ToString();
                txtTienSu.Text = row.Cells["TienSuBenh"].Value.ToString();
            }
        }

        // 8. Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();        // Xóa trắng
            SetButton(false); // Chuyển sang chế độ NHẬP (Ẩn Thêm, Hiện Lưu)
            currMode = "THEM";
            txtHoTen.Focus();
        }

        // 9. Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaBN == 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần sửa!");
                return;
            }
            SetButton(false); // Chuyển sang chế độ NHẬP (Ẩn Sửa, Hiện Lưu)
            currMode = "SUA";
        }

        // 10. Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaBN == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bnBUS.XoaBenhNhan(currMaBN))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    SetNull();
                    // Xóa xong vẫn ở chế độ Xem (SetButton true)
                }
            }
        }

        // 11. Nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return;
            }

            BenhNhan bn = new BenhNhan();
            bn.HoTenBN = txtHoTen.Text;
            bn.GioiTinhBN = cboGioiTinh.Text;
            bn.SDT_BN = txtSDT.Text;
            bn.DiaChiBN = txtDiaChi.Text;
            bn.TienSuBenh = txtTienSu.Text;

            // 2. XỬ LÝ NĂM SINH (THÊM ĐOẠN NÀY ĐỂ CHẶN LỖI 1222)
            int namSinh;
            if (int.TryParse(txtNamSinh.Text, out namSinh))
            {
                // Kiểm tra logic: Năm sinh phải từ 1900 đến năm hiện tại
                if (namSinh < 1900 || namSinh > DateTime.Now.Year)
                {
                    MessageBox.Show("Năm sinh không hợp lệ! (Phải từ 1900 đến " + DateTime.Now.Year + ")");
                    txtNamSinh.Focus();
                    return; // Dừng lại, không Lưu nữa
                }
                bn.NamSinhBN = namSinh;
            }
            else
            {
                MessageBox.Show("Năm sinh phải là số!");
                txtNamSinh.Focus();
                return;
            }

            // 3. Gọi BUS để lưu
            bool ketQua = false;
            try
            {
                if (currMode == "THEM")
                    ketQua = bnBUS.ThemBenhNhan(bn);
                else if (currMode == "SUA")
                {
                    bn.MaBN = currMaBN;
                    ketQua = bnBUS.SuaBenhNhan(bn);
                }

                if (ketQua)
                {
                    MessageBox.Show("Thao tác thành công!");
                    LoadData();
                    SetButton(true);
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại!");
                }
            }
            catch (Exception ex)
            {
                // Bắt các lỗi khác nếu có
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
            SetNull();
        }

        // 12. Nút Bỏ qua
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            // Bỏ qua thì quay về chế độ Xem
            SetButton(true);
        }

        // 13. Nút Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}