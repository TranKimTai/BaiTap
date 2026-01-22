using QuanLyPhongKham.BUS;
using QuanLyPhongKham.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongKham.GUI
{
    public partial class frmKhamBenh : Form
    {
        // Khai báo BUS
        private BenhNhanBUS bnBUS = new BenhNhanBUS();
        private ThuocBUS thuocBUS = new ThuocBUS();
        private DichVuBUS dvBUS = new DichVuBUS();
        private PhieuKhamBUS pkBUS = new PhieuKhamBUS();

        private DataTable dtChiTietDV;
        private DataTable dtToaThuoc;
        private int currMaPhieu = 0; // 0: Thêm mới, >0: Sửa

        public frmKhamBenh()
        {
            InitializeComponent();
        }

        private void frmKhamBenh_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            KhoiTaoBangTam();
            TinhTongTien();
            TrangTriLuoi();
        }

        private void LoadCombobox()
        {
            // 1. Bệnh nhân
            cboBenhNhan.DataSource = bnBUS.GetAllBenhNhan();
            cboBenhNhan.DisplayMember = "HoTenBN";
            cboBenhNhan.ValueMember = "MaBN";
            cboBenhNhan.SelectedIndex = -1;

            // 2. Dịch vụ
            cboDichVu.DataSource = dvBUS.GetDanhSachDichVu();
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
            cboDichVu.SelectedIndex = -1;

            // 3. Thuốc
            cboThuoc.DataSource = thuocBUS.GetDanhSachThuoc();
            cboThuoc.DisplayMember = "TenThuoc";
            cboThuoc.ValueMember = "MaThuoc";
            cboThuoc.SelectedIndex = -1;
        }

        private void KhoiTaoBangTam()
        {
            // Bảng Dịch Vụ (Đã thêm cột KetQuaDV)
            dtChiTietDV = new DataTable();
            dtChiTietDV.Columns.Add("MaDV", typeof(int));
            dtChiTietDV.Columns.Add("TenDV", typeof(string));
            dtChiTietDV.Columns.Add("GiaDV", typeof(decimal));
            dtChiTietDV.Columns.Add("SoLuong", typeof(int));
            dtChiTietDV.Columns.Add("ThanhTien", typeof(decimal));
            dtChiTietDV.Columns.Add("KetQuaDV", typeof(string)); // <--- Cột mới
            dgvChiTietDV.DataSource = dtChiTietDV;

            // Bảng Thuốc
            dtToaThuoc = new DataTable();
            dtToaThuoc.Columns.Add("MaThuoc", typeof(int));
            dtToaThuoc.Columns.Add("TenThuoc", typeof(string));
            dtToaThuoc.Columns.Add("DonVi", typeof(string));
            dtToaThuoc.Columns.Add("SoLuong", typeof(int));
            dtToaThuoc.Columns.Add("DonGia", typeof(decimal));
            dtToaThuoc.Columns.Add("ThanhTien", typeof(decimal));
            dtToaThuoc.Columns.Add("CachDung", typeof(string));
            dgvToaThuoc.DataSource = dtToaThuoc;
        }

        private void TrangTriLuoi()
        {
            // 1. Bảng Thuốc
            if (dgvToaThuoc.Columns.Count > 0)
            {
                dgvToaThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                dgvToaThuoc.Columns["MaThuoc"].Visible = false;
                dgvToaThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvToaThuoc.Columns["DonVi"].HeaderText = "Đơn Vị";
                dgvToaThuoc.Columns["SoLuong"].HeaderText = "SL";

                dgvToaThuoc.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvToaThuoc.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvToaThuoc.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvToaThuoc.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvToaThuoc.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvToaThuoc.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvToaThuoc.Columns["CachDung"].HeaderText = "Cách Dùng";
                dgvToaThuoc.Columns["TenThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // 2. Bảng Dịch Vụ
            if (dgvChiTietDV.Columns.Count > 0)
            {
                dgvChiTietDV.Columns["MaDV"].HeaderText = "Mã DV";
                dgvChiTietDV.Columns["MaDV"].Visible = false;
                dgvChiTietDV.Columns["TenDV"].HeaderText = "Tên Dịch Vụ";

                dgvChiTietDV.Columns["GiaDV"].HeaderText = "Đơn Giá";
                dgvChiTietDV.Columns["GiaDV"].DefaultCellStyle.Format = "N0";
                dgvChiTietDV.Columns["GiaDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvChiTietDV.Columns["SoLuong"].HeaderText = "SL";

                dgvChiTietDV.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTietDV.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTietDV.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvChiTietDV.Columns["TenDV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Trang trí cột Kết Quả
                if (dgvChiTietDV.Columns.Contains("KetQuaDV"))
                {
                    dgvChiTietDV.Columns["KetQuaDV"].HeaderText = "Kết Quả";
                    dgvChiTietDV.Columns["KetQuaDV"].Width = 150;
                }
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (cboDichVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ trước!", "Chưa chọn dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDichVu.Focus();
                return;
            }

            DataRowView row = (DataRowView)cboDichVu.SelectedItem;
            int maDV = Convert.ToInt32(row["MaDV"]);
            string tenDV = row["TenDV"].ToString();
            decimal giaDV = Convert.ToDecimal(row["GiaDV"]);
            string ketQua = txtKetQuaDV.Text; // <--- Lấy kết quả từ TextBox

            foreach (DataRow r in dtChiTietDV.Rows)
            {
                if (Convert.ToInt32(r["MaDV"]) == maDV)
                {
                    MessageBox.Show("Dịch vụ này đã có trong danh sách!", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Thêm vào bảng (Có thêm cột ketQua)
            dtChiTietDV.Rows.Add(maDV, tenDV, giaDV, 1, giaDV, ketQua);

            TinhTongTien();

            // Reset sau khi thêm
            cboDichVu.SelectedIndex = -1;
            txtKetQuaDV.Clear();
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thuốc trước!", "Chưa chọn thuốc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboThuoc.Focus();
                return;
            }

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng thuốc phải là số nguyên dương!", "Sai số lượng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            DataRowView row = (DataRowView)cboThuoc.SelectedItem;
            int maThuoc = Convert.ToInt32(row["MaThuoc"]);
            string tenThuoc = row["TenThuoc"].ToString();
            string donVi = row["DonViTinh"].ToString();
            decimal donGia = Convert.ToDecimal(row["DonGiaThuoc"]);
            int tonKho = Convert.ToInt32(row["SoLuongTon"]);

            foreach (DataRow r in dtToaThuoc.Rows)
            {
                if (Convert.ToInt32(r["MaThuoc"]) == maThuoc)
                {
                    int slCu = Convert.ToInt32(r["SoLuong"]);
                    int slMoi = slCu + soLuong;

                    if (slMoi > tonKho)
                    {
                        MessageBox.Show($"Không đủ thuốc! Kho chỉ còn {tonKho} {donVi}.\n(Đã kê: {slCu}, Thêm: {soLuong})", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    r["SoLuong"] = slMoi;
                    r["ThanhTien"] = slMoi * donGia;
                    r["CachDung"] = txtCachDung.Text;
                    TinhTongTien();
                    return;
                }
            }

            if (soLuong > tonKho)
            {
                MessageBox.Show($"Không đủ thuốc! Kho chỉ còn {tonKho} {donVi}", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtToaThuoc.Rows.Add(maThuoc, tenThuoc, donVi, soLuong, donGia, soLuong * donGia, txtCachDung.Text);
            TinhTongTien();

            // Reset sau khi thêm
            txtSoLuong.Clear();
            txtCachDung.Clear();
            cboThuoc.SelectedIndex = -1;
            cboThuoc.Focus();
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in dtChiTietDV.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            foreach (DataRow r in dtToaThuoc.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            lblTongTien.Text = "TỔNG THANH TOÁN: " + tong.ToString("N0") + " VNĐ";
        }

        private float ParseFloat(string val)
        {
            if (float.TryParse(val, out float result)) return result;
            return 0;
        }

        private bool KiemTraHopLe()
        {
            if (cboBenhNhan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBenhNhan.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtTrieuChung.Text))
            {
                MessageBox.Show("Vui lòng nhập triệu chứng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrieuChung.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtChanDoan.Text))
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChanDoan.Focus(); return false;
            }

            // Cảnh báo nếu phiếu trống
            if (dtChiTietDV.Rows.Count == 0 && dtToaThuoc.Rows.Count == 0)
            {
                if (MessageBox.Show("Phiếu này chưa có Thuốc hay Dịch vụ nào.\nBạn có chắc chắn muốn lưu?",
                    "Cảnh báo phiếu trống", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra hợp lệ (Giữ nguyên)
            if (!KiemTraHopLe()) return;

            // --- THÊM ĐOẠN HỎI XÁC NHẬN TẠI ĐÂY ---
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn lưu phiếu khám này?",
                                              "Xác nhận lưu",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            // Nếu người dùng chọn No thì dừng lại, không làm gì cả
            if (dr == DialogResult.No) return;
            // --------------------------------------

            try
            {
                PhieuKham pk = new PhieuKham();
                pk.MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue);
                pk.MaNV = 1; // User ID
                pk.NgayKham = dtpNgayKham.Value;
                pk.TrieuChung = txtTrieuChung.Text.Trim();
                pk.ChanDoan = txtChanDoan.Text.Trim();
                pk.LoiDan = txtLoiDan.Text.Trim();

                if (dtpTaiKham.Checked) pk.NgayTaiKham = dtpTaiKham.Value;
                else pk.NgayTaiKham = null;

                pk.CanNang = ParseFloat(txtCanNang.Text);
                pk.ChieuCao = ParseFloat(txtChieuCao.Text);
                pk.NhietDo = ParseFloat(txtNhietDo.Text);
                pk.HuyetAp = txtHuyetAp.Text;

                int maPhieuXuLy = 0;
                bool thanhCong = false;

                if (currMaPhieu > 0)
                {
                    pk.MaPhieu = currMaPhieu;
                    if (pkBUS.CapNhatPhieuKham(pk))
                    {
                        maPhieuXuLy = currMaPhieu;
                        thanhCong = true;
                    }
                }
                else
                {
                    maPhieuXuLy = pkBUS.InsertPhieuKham_LayMa(pk);
                    if (maPhieuXuLy > 0) thanhCong = true;
                }

                if (thanhCong)
                {
                    if (currMaPhieu == 0)
                    {
                        // Lưu Dịch vụ
                        foreach (DataRow r in dtChiTietDV.Rows)
                        {
                            string kq = r["KetQuaDV"].ToString();
                            pkBUS.InsertChiTietDV(maPhieuXuLy, Convert.ToInt32(r["MaDV"]), Convert.ToInt32(r["SoLuong"]), Convert.ToDecimal(r["GiaDV"]), Convert.ToDecimal(r["ThanhTien"]), kq);
                        }

                        // Lưu Toa thuốc
                        foreach (DataRow r in dtToaThuoc.Rows)
                        {
                            pkBUS.InsertToaThuoc(maPhieuXuLy, Convert.ToInt32(r["MaThuoc"]), Convert.ToInt32(r["SoLuong"]), Convert.ToDecimal(r["DonGia"]), Convert.ToDecimal(r["ThanhTien"]), r["CachDung"].ToString());
                        }
                    }

                    MessageBox.Show("Lưu phiếu khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Lưu thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            currMaPhieu = 0;
            cboBenhNhan.SelectedIndex = -1;
            cboDichVu.SelectedIndex = -1;
            cboThuoc.SelectedIndex = -1;

            txtTrieuChung.Clear();
            txtChanDoan.Clear();
            txtLoiDan.Clear();
            txtKetQuaDV.Clear(); // <--- Xóa ô kết quả

            txtCanNang.Clear();
            txtChieuCao.Clear();
            txtHuyetAp.Clear();
            txtNhietDo.Clear();

            dtpTaiKham.Checked = false;

            dtChiTietDV.Rows.Clear();
            dtToaThuoc.Rows.Clear();
            lblTongTien.Text = "TỔNG THANH TOÁN: 0 VNĐ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Các sự kiện UI thừa
        private void lblTongTien_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dgvToaThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}