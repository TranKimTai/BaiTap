using QuanLyPhongKham.BUS;
using System;
using System.Data;
using System.Linq;
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

            // 1. Hiện lưới
            dgvDoanhThu.DataSource = dt;
            TrangTriBangDoanhThu();

            // 2. Tính tổng (Card)
            TinhToanBaoCao(dt);

            // 3. VẼ BIỂU ĐỒ (MỚI)
            VeBieuDo(dt);
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
        // Hàm tính toán tổng hợp số liệu
        private void TinhToanBaoCao(DataTable dt)
        {
            // Kiểm tra nếu bảng có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                // --- 1. TÍNH TỔNG DOANH THU ---
                // Dùng hàm Compute để tính tổng cột "TongThanhToan"
                object sumObject = dt.Compute("SUM(TongThanhToan)", string.Empty);
                decimal tongTien = 0;

                // Kiểm tra null để tránh lỗi nếu cột không có số liệu
                if (sumObject != DBNull.Value)
                {
                    tongTien = Convert.ToDecimal(sumObject);
                }

                lblTongDoanhThu.Text = tongTien.ToString("N0") + " VNĐ";

                // --- 2. TÍNH TỔNG BỆNH NHÂN (SỐ LƯỢT KHÁM) ---
                // Mỗi dòng trong dt là 1 hóa đơn => 1 lượt khám
                int soLuotKham = dt.Rows.Count;

                // Gán vào Label (Đảm bảo bạn đã đặt tên label là lblTongBenhNhan)
                lblTongBenhNhan.Text = soLuotKham.ToString("N0");
            }
            else
            {
                // Trường hợp không tìm thấy dữ liệu nào
                lblTongDoanhThu.Text = "0 VNĐ";
                lblTongBenhNhan.Text = "0 Lượt";
            }
        }

        // Các sự kiện thừa (Nếu không dùng có thể xóa bên giao diện Design)
        private void label2_Click(object sender, EventArgs e) { }
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void lblTongDoanhThu_Click(object sender, EventArgs e) { }

        private void lblTongBenhNhan_Click(object sender, EventArgs e)
        {

        }

        private void dgvDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        // Nút Hôm Nay
        private void btnHomNay_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;
            btnXem_Click(sender, e); // Tự động bấm nút Xem luôn
        }

        // Nút Tháng Này
        private void btnThangNay_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1); // Ngày 1
            dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddDays(-1); // Ngày cuối tháng
            btnXem_Click(sender, e);
        }

        private void VeBieuDo(DataTable dt)
        {
            // 1. Xóa dữ liệu cũ
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear(); // Xóa tiêu đề cũ nếu có để tránh trùng

            // 2. Thêm Tiêu đề cho biểu đồ
            var title = chartDoanhThu.Titles.Add("BIỂU ĐỒ DOANH THU THEO NGÀY");
            title.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            title.ForeColor = System.Drawing.Color.DarkBlue;

            // 3. XỬ LÝ DỮ LIỆU: Gộp nhóm theo ngày và Tính tổng tiền
            // (Vì DataTable chứa từng hóa đơn lẻ, ta cần gộp lại để vẽ 1 cột/ngày)
            var dataGop = dt.AsEnumerable()
                .GroupBy(row => Convert.ToDateTime(row["NgayLapHD"]).ToString("dd/MM")) // Nhóm theo ngày/tháng
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongTien = g.Sum(row => Convert.ToDecimal(row["TongThanhToan"])),
                    NgayGoc = g.First().Field<DateTime>("NgayLapHD") // Lấy ngày gốc để sắp xếp
                })
                .OrderBy(x => x.NgayGoc) // Sắp xếp ngày cũ bên trái, ngày mới bên phải
                .ToList();

            // 4. Tạo Series mới
            var series = chartDoanhThu.Series.Add("Doanh Thu");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.Color = System.Drawing.Color.FromArgb(65, 140, 240); // Màu xanh dịu mắt
            series.BorderWidth = 1;
            series.BorderColor = System.Drawing.Color.White;

            // 5. Cấu hình hiển thị số liệu
            series.IsValueShownAsLabel = true; // Hiện số trên đầu cột
            series.LabelFormat = "#,##0";      // Định dạng số (VD: 280,000)
            series.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            // 6. Đổ dữ liệu vào biểu đồ
            foreach (var item in dataGop)
            {
                series.Points.AddXY(item.Ngay, item.TongTien);
            }

            // 7. Trang trí trục (Axis) cho thoáng
            var chartArea = chartDoanhThu.ChartAreas[0];

            // Trục ngang (Ngày)
            chartArea.AxisX.MajorGrid.Enabled = false; // Tắt lưới dọc nhìn cho đỡ rối
            chartArea.AxisX.Interval = 1; // Hiện đủ tên các ngày
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9);

            // Trục dọc (Tiền)
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // Lưới ngang mờ
            chartArea.AxisY.LabelStyle.Format = "#,##0"; // Số trục dọc có dấu phẩy
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartDoanhThu_Click_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}