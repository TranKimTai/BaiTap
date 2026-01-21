using QuanLyPhongKham.BUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmThongKe : Form
    {
        // Khai báo BUS
        ThongKeBUS tkBUS = new ThongKeBUS();

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // Mặc định load từ ngày 1 đầu tháng đến hiện tại
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            // Có thể gọi nút Xem luôn để load dữ liệu ngay khi mở form
            btnXem_Click(sender, e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // 1. LẤY DỮ LIỆU TỪ BUS
            DataTable dt = tkBUS.GetDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
            dgvDoanhThu.DataSource = dt;

            // 2. TRANG TRÍ DATA GRID VIEW
            TrangTriBangDoanhThu();

            // 3. TÍNH TOÁN SỐ LIỆU TỔNG HỢP (CHO CÁC CARD)
            TinhToanBaoCao(dt);
        }

        // Hàm riêng để trang trí bảng cho gọn code
        private void TrangTriBangDoanhThu()
        {
            if (dgvDoanhThu.Columns.Count > 0)
            {
                dgvDoanhThu.Columns["MaHD"].HeaderText = "Mã HĐ";
                dgvDoanhThu.Columns["MaHD"].Width = 60;

                dgvDoanhThu.Columns["NgayLapHD"].HeaderText = "Ngày Lập";
                dgvDoanhThu.Columns["NgayLapHD"].Width = 120;
                dgvDoanhThu.Columns["NgayLapHD"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                dgvDoanhThu.Columns["HoTenNV"].HeaderText = "Thu Ngân";
                dgvDoanhThu.Columns["HoTenBN"].HeaderText = "Bệnh Nhân";
                dgvDoanhThu.Columns["HoTenBN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvDoanhThu.Columns["TongTienThuoc"].HeaderText = "Tiền Thuốc";
                dgvDoanhThu.Columns["TongTienThuoc"].DefaultCellStyle.Format = "N0";
                dgvDoanhThu.Columns["TongTienThuoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvDoanhThu.Columns["TongTienDV"].HeaderText = "Tiền Dịch Vụ";
                dgvDoanhThu.Columns["TongTienDV"].DefaultCellStyle.Format = "N0";
                dgvDoanhThu.Columns["TongTienDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvDoanhThu.Columns["TongThanhToan"].HeaderText = "Tổng Cộng";
                dgvDoanhThu.Columns["TongThanhToan"].DefaultCellStyle.Format = "N0";
                dgvDoanhThu.Columns["TongThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDoanhThu.Columns["TongThanhToan"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            }
        }

        // Hàm tính toán tổng
        private void TinhToanBaoCao(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                // Cách 1: Tính Tổng Doanh Thu (Card Xanh Lá)
                // Dùng phương thức Compute thay vì foreach để nhanh hơn
                decimal tongTien = Convert.ToDecimal(dt.Compute("SUM(TongThanhToan)", string.Empty));
                lblTongDoanhThu.Text = tongTien.ToString("N0") + " VNĐ";

                // Cách 2: Tính Số Lượng Bệnh Nhân/Hóa Đơn (Card Xanh Dương)
                // Nếu bạn đã tạo Label lblTongBenhNhan thì bỏ comment dòng dưới
                lblTongBenhNhan.Text = dt.Rows.Count.ToString() + " Lượt";
            }
            else
            {
                lblTongDoanhThu.Text = "0 VNĐ";
                lblTongBenhNhan.Text = "0";
            }
        }

        // Các sự kiện thừa (Nếu không dùng có thể xóa bên giao diện Design)
        private void label2_Click(object sender, EventArgs e) { }
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void lblTongDoanhThu_Click(object sender, EventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}