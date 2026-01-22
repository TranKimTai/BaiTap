using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using QuanLyPhongKham.DAL;
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
    public partial class frmLichSuKham : Form
    {
        PhieuKhamBUS pkBUS = new PhieuKhamBUS();
        public frmLichSuKham()
        {
            InitializeComponent();
        }

        private void frmLichSuKham_Load(object sender, EventArgs e)
        {
            btnTim_Click(sender, e);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = pkBUS.GetLichSuKham(txtTimKiem.Text.Trim());
            dgvLichSu.DataSource = dt;

            // Format cột tiếng Việt
            if (dgvLichSu.Columns.Count > 0)
            {
                // Ẩn cột ID
                if (dgvLichSu.Columns.Contains("MaPhieu")) dgvLichSu.Columns["MaPhieu"].Visible = false;
                if (dgvLichSu.Columns.Contains("MaBN")) dgvLichSu.Columns["MaBN"].Visible = false;
                if (dgvLichSu.Columns.Contains("MaNV")) dgvLichSu.Columns["MaNV"].Visible = false;

                // Đặt tên cột tiếng Việt
                if (dgvLichSu.Columns.Contains("NgayKham"))
                {
                    dgvLichSu.Columns["NgayKham"].HeaderText = "Ngày Khám";
                    dgvLichSu.Columns["NgayKham"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                if (dgvLichSu.Columns.Contains("HoTenBN"))
                {
                    dgvLichSu.Columns["HoTenBN"].HeaderText = "Bệnh Nhân";
                    dgvLichSu.Columns["HoTenBN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvLichSu.Columns.Contains("HoTenNV"))
                {
                    dgvLichSu.Columns["HoTenNV"].HeaderText = "Bác Sĩ Khám";
                }

                // Tùy chọn: Có thể hiện Chẩn đoán ra luôn nếu muốn
                if (dgvLichSu.Columns.Contains("ChanDoan"))
                {
                    dgvLichSu.Columns["ChanDoan"].HeaderText = "Chẩn Đoán Sơ Bộ";
                }
            }
        }

        private void dgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nên dùng CellClick thay vì CellContentClick để click vào ô trắng cũng nhận
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLichSu.Rows[e.RowIndex];

                // Kiểm tra null trước khi convert
                if (row.Cells["MaPhieu"].Value == DBNull.Value) return;

                int maPhieu = Convert.ToInt32(row.Cells["MaPhieu"].Value);

                // 1. Lấy thông tin phiếu chi tiết
                PhieuKham pk = pkBUS.GetThongTinPhieu(maPhieu);
                if (pk != null)
                {
                    // --- Hiển thị thông tin Label (Giữ nguyên code của bạn) ---
                    lblMaPhieu.Text = Convert.ToString(pk.MaPhieu);
                    lblTenBN.Text = pk.HoTenBN.ToUpper();
                    lblNgayKham.Text = pk.NgayKham.ToString("dd/MM/yyyy");

                    lblChanDoan.Text = pk.ChanDoan;
                    lblTrieuChung.Text = pk.TrieuChung;
                    lblLoiDan.Text = pk.LoiDan;

                    lblSinhHieu.Text = string.Format("Cân nặng: {0}kg  |  Chiều cao: {1}cm\nHuyết áp: {2}  |  Nhiệt độ: {3}°C",
                                                    pk.CanNang, pk.ChieuCao, pk.HuyetAp, pk.NhietDo);

                    if (pk.NgayTaiKham != null)
                        lblTaiKham.Text = pk.NgayTaiKham.Value.ToString("dd/MM/yyyy");
                    else
                        lblTaiKham.Text = "Không";
                }

                // 2. Đổ dữ liệu Thuốc & Format tiếng Việt
                dgvThuoc.DataSource = pkBUS.GetThuocCuaPhieu(maPhieu);
                FormatLuoiThuoc(); // <--- Gọi hàm format

                // 3. Đổ dữ liệu Dịch vụ & Format tiếng Việt
                dgvDichVu.DataSource = pkBUS.GetDichVuCuaPhieu(maPhieu);
                FormatLuoiDV();    // <--- Gọi hàm format
            }
        }
        // Hàm trang trí bảng Thuốc
        private void FormatLuoiThuoc()
        {
            if (dgvThuoc.Columns.Count > 0)
            {
                // 1. Ẩn các cột ID thừa
                if (dgvThuoc.Columns.Contains("MaThuoc")) dgvThuoc.Columns["MaThuoc"].Visible = false;
                if (dgvThuoc.Columns.Contains("MaPhieu")) dgvThuoc.Columns["MaPhieu"].Visible = false;

                // 2. Cột Tên Thuốc
                if (dgvThuoc.Columns.Contains("TenThuoc"))
                {
                    dgvThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                    dgvThuoc.Columns["TenThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // 3. Cột Số Lượng (Sửa lại đúng tên cột trong hình bạn gửi: SoLuongThuoc)
                string colSL = dgvThuoc.Columns.Contains("SoLuongThuoc") ? "SoLuongThuoc" : "SoLuong";
                if (dgvThuoc.Columns.Contains(colSL))
                {
                    dgvThuoc.Columns[colSL].HeaderText = "Số Lượng";
                    dgvThuoc.Columns[colSL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 4. Cột Đơn Vị
                if (dgvThuoc.Columns.Contains("DonVi")) // Hoặc DonViTinh
                {
                    dgvThuoc.Columns["DonViTinh"].HeaderText = "Đơn Vị";
                    dgvThuoc.Columns["DonViTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 5. Cột Cách Dùng
                if (dgvThuoc.Columns.Contains("CachDung"))
                {
                    dgvThuoc.Columns["CachDung"].HeaderText = "Cách Dùng / Liều Lượng";
                }
            }
        }

        // Hàm trang trí bảng Dịch Vụ
        private void FormatLuoiDV()
        {
            if (dgvDichVu.Columns.Count > 0)
            {
                // 1. Ẩn cột ID
                if (dgvDichVu.Columns.Contains("MaDV")) dgvDichVu.Columns["MaDV"].Visible = false;
                if (dgvDichVu.Columns.Contains("MaPhieu")) dgvDichVu.Columns["MaPhieu"].Visible = false;

                // 2. Cột Tên Dịch Vụ
                if (dgvDichVu.Columns.Contains("TenDV"))
                {
                    dgvDichVu.Columns["TenDV"].HeaderText = "Tên Dịch Vụ / Cận Lâm Sàng";
                    dgvDichVu.Columns["TenDV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // 3. Cột Kết Quả (Sửa lại đúng tên cột trong hình bạn gửi: KetQuaDV)
                string colKQ = dgvDichVu.Columns.Contains("KetQuaDV") ? "KetQuaDV" : "KetQua";
                if (dgvDichVu.Columns.Contains(colKQ))
                {
                    dgvDichVu.Columns[colKQ].HeaderText = "Kết Quả";
                    // Tự động xuống dòng nếu kết quả dài quá
                    dgvDichVu.Columns[colKQ].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }

                // 4. Cột Giá (Nếu có)
                if (dgvDichVu.Columns.Contains("GiaDV"))
                {
                    dgvDichVu.Columns["GiaDV"].HeaderText = "Chi Phí";
                    dgvDichVu.Columns["GiaDV"].DefaultCellStyle.Format = "N0";
                    dgvDichVu.Columns["GiaDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
