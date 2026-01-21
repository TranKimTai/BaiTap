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

            // Format cột
            if (dgvLichSu.Columns.Count > 0)
            {
                dgvLichSu.Columns["MaPhieu"].Visible = false; // Ẩn mã đi
                dgvLichSu.Columns["NgayKham"].HeaderText = "Ngày Khám";
                dgvLichSu.Columns["HoTenNV"].HeaderText = "Bác Sĩ";
                dgvLichSu.Columns["ChanDoan"].Visible = false; // Ẩn bớt cho gọn bảng

                // Format ngày giờ
                dgvLichSu.Columns["NgayKham"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void dgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLichSu.Rows[e.RowIndex];
                int maPhieu = Convert.ToInt32(row.Cells["MaPhieu"].Value);

                // 1. Hiển thị thông tin chẩn đoán (Lấy từ dòng đang chọn hoặc query lại DB)
                // Ở đây mình query lại chi tiết phiếu để lấy đầy đủ Triệu chứng, Lời dặn...
                PhieuKham pk = pkBUS.GetThongTinPhieu(maPhieu); // Hàm này bạn đã viết ở bài PhieuKhamBUS
                if (pk != null)
                {
                    // --- Hiển thị thông tin cơ bản ---
                    lblMaPhieu.Text = Convert.ToString(pk.MaPhieu);
                    lblTenBN.Text = pk.HoTenBN.ToUpper(); // In hoa cho đẹp
                    lblNgayKham.Text = pk.NgayKham.ToString("dd/MM/yyyy");

                    // --- Hiển thị thông tin KHÁM BỆNH (Mới thêm) ---
                    lblChanDoan.Text = pk.ChanDoan;
                    lblTrieuChung.Text = pk.TrieuChung;
                    lblLoiDan.Text = pk.LoiDan;

                    // Hiển thị Sinh hiệu gộp chung 1 dòng cho gọn
                    lblSinhHieu.Text = string.Format("Cân nặng: {0}kg\nChiều cao: {1}cm\nHuyết áp: {2}\nNhiệt độ: {3}°C",
                                                     pk.CanNang, pk.ChieuCao, pk.HuyetAp, pk.NhietDo);

                    // Hiển thị ngày tái khám (nếu có)
                    if (pk.NgayTaiKham != null)
                        lblTaiKham.Text = pk.NgayTaiKham.Value.ToString("dd/MM/yyyy");
                    else
                        lblTaiKham.Text = "Không";

                }

                // 2. Đổ dữ liệu Thuốc
                dgvThuoc.DataSource = pkBUS.GetThuocCuaPhieu(maPhieu); // Bạn nhớ thêm hàm này vào BUS gọi DAL nhé

                // 3. Đổ dữ liệu Dịch vụ
                dgvDichVu.DataSource = pkBUS.GetDichVuCuaPhieu(maPhieu); // Bạn nhớ thêm hàm này vào BUS gọi DAL nhé
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
