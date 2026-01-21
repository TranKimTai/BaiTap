using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmThanhToan : Form
    {
        HoaDonBUS hdBUS = new HoaDonBUS();
        PhieuKhamBUS pkBUS = new PhieuKhamBUS();
        private int currMaPhieu = 0;
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadDanhSachCho();
            cboHinhThuc.SelectedIndex = 0;
        }
        private void LoadDanhSachCho()
        {
            DataTable dt = hdBUS.GetDanhSachChoThanhToan(txtTimKiem.Text.Trim());
            dgvChoThanhToan.DataSource = dt;

            // Đặt tên cột
            if (dgvChoThanhToan.Columns.Count > 0)
            {
                dgvChoThanhToan.Columns["MaPhieu"].HeaderText = "Mã Phiếu";
                dgvChoThanhToan.Columns["NgayKham"].HeaderText = "Ngày Khám";
                dgvChoThanhToan.Columns["HoTenBN"].HeaderText = "Bệnh Nhân";
                dgvChoThanhToan.Columns["SDT_BN"].HeaderText = "SĐT";
                dgvChoThanhToan.Columns["NamSinhBN"].Visible = false; // Ẩn bớt cho gọn
            }
        }

        // Trong frmThanhToan.cs
        private void dgvChoThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChoThanhToan.Rows[e.RowIndex];

                // 1. Lấy Mã phiếu
                currMaPhieu = Convert.ToInt32(row.Cells["MaPhieu"].Value);

                // 2. Gọi BUS lấy thông tin ĐẦY ĐỦ (đã cập nhật ở Bước 1)
                PhieuKham pk = pkBUS.GetThongTinPhieu(currMaPhieu);

                if (pk != null)
                {
                    // --- Hiển thị thông tin cơ bản ---
                    lblMaPhieu.Text =  Convert.ToString(pk.MaPhieu);
                    lblTenBN.Text = pk.HoTenBN.ToUpper(); // In hoa cho đẹp
                    lblNgayKham.Text = pk.NgayKham.ToString("dd/MM/yyyy");

                    // --- Hiển thị thông tin KHÁM BỆNH (Mới thêm) ---
                    lblChanDoan.Text =  pk.ChanDoan;
                    lblTrieuChung.Text = pk.TrieuChung;
                    lblLoiDan.Text =  pk.LoiDan;

                    // Hiển thị Sinh hiệu gộp chung 1 dòng cho gọn
                    lblSinhHieu.Text = string.Format("Cân nặng: {0}kg\nChiều cao: {1}cm\nHuyết áp: {2}\nNhiệt độ: {3}°C",
                                                     pk.CanNang, pk.ChieuCao, pk.HuyetAp, pk.NhietDo);

                    // Hiển thị ngày tái khám (nếu có)
                    if (pk.NgayTaiKham != null)
                        lblTaiKham.Text = pk.NgayTaiKham.Value.ToString("dd/MM/yyyy");
                    else
                        lblTaiKham.Text = "Không";
                }

                // 3. Load bảng chi tiết Thuốc & Dịch vụ (Code cũ giữ nguyên)
                LoadBangThuoc(currMaPhieu);
                LoadBangDichVu(currMaPhieu);
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            decimal tongTienThuoc = 0;
            decimal tongTienDV = 0;

            // 1. Cộng tiền Thuốc
            if (dgvThuoc.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvThuoc.Rows)
                {
                    // Kiểm tra null để tránh lỗi
                    if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                    {
                        tongTienThuoc += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                    }
                }
            }

            // 2. Cộng tiền Dịch vụ
            if (dgvDichVu.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDichVu.Rows)
                {
                    // Cột thành tiền bên Dịch vụ (tùy tên cột bạn đặt trong SQL/DAL, thường là ThanhTien)
                    if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                    {
                        tongTienDV += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                    }
                }
            }

            // 3. Hiển thị lên Label
            // Lưu giá trị số vào .Tag để lúc bấm nút Thanh Toán lấy ra dùng cho chính xác
            lblTienThuoc.Tag = tongTienThuoc;
            lblTienDV.Tag = tongTienDV;
            lblTongCong.Tag = (tongTienThuoc + tongTienDV);

            // Hiển thị dạng chữ có dấu phẩy cho đẹp
            lblTienThuoc.Text = tongTienThuoc.ToString("N0") + " VNĐ";
            lblTienDV.Text = tongTienDV.ToString("N0") + " VNĐ";
            lblTongCong.Text = (tongTienThuoc + tongTienDV).ToString("N0") + " VNĐ";
        }

        // --- HÀM 1: ĐỔ DỮ LIỆU VÀO BẢNG THUỐC ---
        private void LoadBangThuoc(int maPhieu)
        {
            // Lấy dữ liệu từ BUS
            DataTable dt = pkBUS.GetChiTietToaThuoc(maPhieu);
            dgvThuoc.DataSource = dt;

            // Trang trí bảng Thuốc
            if (dgvThuoc.Columns.Count > 0)
            {
                // Ẩn các cột ID không cần thiết
                if (dgvThuoc.Columns.Contains("MaThuoc")) dgvThuoc.Columns["MaThuoc"].Visible = false;
                if (dgvThuoc.Columns.Contains("MaPK")) dgvThuoc.Columns["MaPK"].Visible = false;

                dgvThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvThuoc.Columns["TenThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvThuoc.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvThuoc.Columns["DonViTinh"].Width = 50;

                dgvThuoc.Columns["SoLuong"].HeaderText = "SL";
                dgvThuoc.Columns["SoLuong"].Width = 40;
                dgvThuoc.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvThuoc.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvThuoc.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvThuoc.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                
            }
        }

        // --- HÀM 2: ĐỔ DỮ LIỆU VÀO BẢNG DỊCH VỤ ---
        private void LoadBangDichVu(int maPhieu)
        {
            // Lấy dữ liệu từ BUS
            DataTable dt = pkBUS.GetChiTietDichVu(maPhieu);
            dgvDichVu.DataSource = dt;

            // Trang trí bảng Dịch Vụ
            if (dgvDichVu.Columns.Count > 0)
            {
                if (dgvDichVu.Columns.Contains("MaDV")) dgvDichVu.Columns["MaDV"].Visible = false;
                if (dgvDichVu.Columns.Contains("MaPK")) dgvDichVu.Columns["MaPK"].Visible = false;

                dgvDichVu.Columns["TenDV"].HeaderText = "Tên Dịch Vụ";
                dgvDichVu.Columns["TenDV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvDichVu.Columns["SoLuong"].HeaderText = "SL";
                dgvDichVu.Columns["SoLuong"].Width = 40;
                dgvDichVu.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Kiểm tra tên cột giá bên SQL là GiaDV hay DonGia để hiển thị
                string colGia = dgvDichVu.Columns.Contains("GiaDV") ? "GiaDV" : "DonGia";

                dgvDichVu.Columns[colGia].HeaderText = "Đơn Giá";
                dgvDichVu.Columns[colGia].DefaultCellStyle.Format = "N0";
                dgvDichVu.Columns[colGia].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        // 1. SỰ KIỆN CLICK BẢNG THUỐC
        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào tiêu đề (RowIndex = -1) thì bỏ qua
            if (e.RowIndex == -1) return;

            // Lấy dòng hiện tại
            DataGridViewRow row = dgvThuoc.Rows[e.RowIndex];

            // Lấy thông tin (Cần đảm bảo tên cột đúng với code LoadBangThuoc lúc nãy)
            string tenThuoc = row.Cells["TenThuoc"].Value.ToString();
            string soLuong = row.Cells["SoLuong"].Value.ToString();
            string thanhTien = row.Cells["ThanhTien"].Value.ToString();

            // Ví dụ: Hiển thị thông báo hoặc đưa thông tin vào một Label nào đó
            // Ở đây mình ví dụ hiện MessageBox để bạn test là sự kiện đã chạy
            MessageBox.Show($"Bạn chọn thuốc: {tenThuoc}\nSố lượng: {soLuong}\nThành tiền: {thanhTien:N0}", "Thông tin thuốc");
        }

        // 2. SỰ KIỆN CLICK BẢNG DỊCH VỤ
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];

            string tenDV = row.Cells["TenDV"].Value.ToString();
            string giaDV = row.Cells["ThanhTien"].Value.ToString(); // Dịch vụ SL thường là 1 nên Thành tiền = Giá

            MessageBox.Show($"Bạn chọn dịch vụ: {tenDV}\nChi phí: {giaDV:N0}", "Thông tin dịch vụ");
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currMaPhieu == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần thanh toán!"); return;
            }

            if (MessageBox.Show("Xác nhận thanh toán cho phiếu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HoaDon hd = new HoaDon();
                hd.MaPhieu = currMaPhieu;
                hd.MaNV = 1; // Tạm thời để admin, sau này lấy User đăng nhập
                hd.NgayLapHD = DateTime.Now;
                hd.TongTienThuoc = Convert.ToDecimal(lblTienThuoc.Tag);
                hd.TongTienDV = Convert.ToDecimal(lblTienDV.Tag);
                hd.TongThanhToan = Convert.ToDecimal(lblTongCong.Tag);
                hd.HinhThucTT = cboHinhThuc.Text;
                hd.GhiChuHD = txtGhiChu.Text;

                if (hdBUS.ThanhToan(hd))
                {
                    MessageBox.Show("Thanh toán thành công! Đã in hóa đơn.");
                    LoadDanhSachCho();

                    // ======================================================
                    // CẬP NHẬT PHẦN RESET GIAO DIỆN TẠI ĐÂY
                    // ======================================================

                    // 1. Xóa các biến tạm và Label
                    currMaPhieu = 0;
                    lblTenBN.Text = "...";
                    lblMaPhieu.Text = "...";
                    lblNgayKham.Text = "...";

                    // 2. Reset tiền về 0
                    lblTongCong.Text = "0 VNĐ";
                    lblTienThuoc.Text = "0 VNĐ";   // Thêm chữ VNĐ cho đồng bộ
                    lblTienDV.Text = "0 VNĐ";      // Thêm chữ VNĐ cho đồng bộ

                    // 3. Xóa trắng 2 bảng chi tiết (QUAN TRỌNG)
                    dgvThuoc.DataSource = null;
                    dgvDichVu.DataSource = null;

                    // 4. Reset phần nhập liệu
                    txtGhiChu.Text = "";

                    // Hãy dùng SelectedIndex = 0 để quay về mặc định
                    if (cboHinhThuc.Items.Count > 0)
                        cboHinhThuc.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!");
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDanhSachCho();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTongCong_Click(object sender, EventArgs e)
        {

        }

        private void lblTienDV_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTienThuoc_Click(object sender, EventArgs e)
        {

        }

        private void lblTenBN_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTongCong_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTongCong_Click_2(object sender, EventArgs e)
        {

        }

        private void dgvChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
