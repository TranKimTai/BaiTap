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
        // Gọi các BUS cần thiết
        BenhNhanBUS bnBUS = new BenhNhanBUS();
        ThuocBUS thuocBUS = new ThuocBUS();
        DichVuBUS dvBUS = new DichVuBUS();
        PhieuKhamBUS pkBUS = new PhieuKhamBUS();

        DataTable dtChiTietDV;
        DataTable dtToaThuoc;

        // --- [THÊM DÒNG NÀY] Biến lưu trạng thái (0: Tạo mới, >0: Cập nhật) ---
        private int currMaPhieu = 0;

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

        // 1. Đổ dữ liệu vào các ComboBox chọn
        private void LoadCombobox()
        {
            // Bệnh nhân
            cboBenhNhan.DataSource = bnBUS.GetAllBenhNhan(); // Hàm này bạn đã viết ở frmBenhNhan cũ
            cboBenhNhan.DisplayMember = "HoTenBN";
            cboBenhNhan.ValueMember = "MaBN";
            cboBenhNhan.SelectedIndex = -1;

            // Dịch vụ
            cboDichVu.DataSource = dvBUS.GetDanhSachDichVu();
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";

            // Thuốc
            cboThuoc.DataSource = thuocBUS.GetDanhSachThuoc();
            cboThuoc.DisplayMember = "TenThuoc";
            cboThuoc.ValueMember = "MaThuoc";


        }

        private void TrangTriLuoi()
        {
            // 1. Bảng Thuốc
            if (dgvToaThuoc.Columns.Count > 0)
            {
                dgvToaThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                dgvToaThuoc.Columns["MaThuoc"].Visible = false; // Ẩn mã cho đẹp
                dgvToaThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvToaThuoc.Columns["DonVi"].HeaderText = "Đơn Vị";
                dgvToaThuoc.Columns["SoLuong"].HeaderText = "SL";

                dgvToaThuoc.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvToaThuoc.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Thêm dấu phẩy (VD: 10,000)
                dgvToaThuoc.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvToaThuoc.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvToaThuoc.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvToaThuoc.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvToaThuoc.Columns["CachDung"].HeaderText = "Cách Dùng";
            }

            // 2. Bảng Dịch Vụ
            if (dgvChiTietDV.Columns.Count > 0)
            {
                dgvChiTietDV.Columns["MaDV"].HeaderText = "Mã DV";
                dgvChiTietDV.Columns["MaDV"].Visible = false; // Ẩn mã
                dgvChiTietDV.Columns["TenDV"].HeaderText = "Tên Dịch Vụ";

                dgvChiTietDV.Columns["GiaDV"].HeaderText = "Đơn Giá";
                dgvChiTietDV.Columns["GiaDV"].DefaultCellStyle.Format = "N0";
                dgvChiTietDV.Columns["GiaDV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvChiTietDV.Columns["SoLuong"].HeaderText = "SL";

                dgvChiTietDV.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTietDV.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTietDV.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // 2. Tạo cấu trúc bảng tạm (để hiển thị lên DataGridView)
        private void KhoiTaoBangTam()
        {
            // Bảng Dịch Vụ
            dtChiTietDV = new DataTable();
            dtChiTietDV.Columns.Add("MaDV", typeof(int));
            dtChiTietDV.Columns.Add("TenDV", typeof(string));
            dtChiTietDV.Columns.Add("GiaDV", typeof(decimal));
            dtChiTietDV.Columns.Add("SoLuong", typeof(int));
            dtChiTietDV.Columns.Add("ThanhTien", typeof(decimal));
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

        // 3. Nút Thêm Dịch Vụ
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (cboDichVu.SelectedIndex == -1) return;

            // Lấy thông tin dịch vụ đang chọn
            DataRowView row = (DataRowView)cboDichVu.SelectedItem;
            int maDV = Convert.ToInt32(row["MaDV"]);
            string tenDV = row["TenDV"].ToString();
            decimal giaDV = Convert.ToDecimal(row["GiaDV"]);

            // Kiểm tra xem đã thêm chưa, nếu rồi thì không thêm nữa (hoặc tăng số lượng tùy ý)
            foreach (DataRow r in dtChiTietDV.Rows)
            {
                if (Convert.ToInt32(r["MaDV"]) == maDV)
                {
                    MessageBox.Show("Dịch vụ này đã có trong danh sách!");
                    return;
                }
            }

            // Thêm vào bảng tạm
            dtChiTietDV.Rows.Add(maDV, tenDV, giaDV, 1, giaDV);
            TinhTongTien();
        }

        // 4. Nút Thêm Thuốc
        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedIndex == -1) return;

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                txtSoLuong.Focus();
                return;
            }

            // Lấy thông tin thuốc đang chọn
            DataRowView row = (DataRowView)cboThuoc.SelectedItem;
            int maThuoc = Convert.ToInt32(row["MaThuoc"]);
            string tenThuoc = row["TenThuoc"].ToString();
            string donVi = row["DonViTinh"].ToString();
            decimal donGia = Convert.ToDecimal(row["DonGiaThuoc"]);

            // --- ĐOẠN MỚI THÊM: LẤY TỒN KHO ---
            int tonKho = Convert.ToInt32(row["SoLuongTon"]);

            // Kiểm tra trường hợp thuốc đã có trong bảng kê (Cộng dồn)
            foreach (DataRow r in dtToaThuoc.Rows)
            {
                if (Convert.ToInt32(r["MaThuoc"]) == maThuoc)
                {
                    int slCu = Convert.ToInt32(r["SoLuong"]);
                    int slMoi = slCu + soLuong;

                    // --- KIỂM TRA TỒN KHO (Cộng dồn) ---
                    if (slMoi > tonKho)
                    {
                        MessageBox.Show("Không đủ thuốc! Kho chỉ còn " + tonKho + " " + donVi + ".\n(Đã kê: " + slCu + ", Thêm: " + soLuong + ")");
                        return;
                    }

                    r["SoLuong"] = slMoi;
                    r["ThanhTien"] = slMoi * donGia;
                    r["CachDung"] = txtCachDung.Text;
                    TinhTongTien();
                    return;
                }
            }

            // --- KIỂM TRA TỒN KHO (Thêm mới) ---
            if (soLuong > tonKho)
            {
                MessageBox.Show("Không đủ thuốc! Kho chỉ còn " + tonKho + " " + donVi);
                return;
            }

            // Nếu đủ thì thêm vào bảng
            dtToaThuoc.Rows.Add(maThuoc, tenThuoc, donVi, soLuong, donGia, soLuong * donGia, txtCachDung.Text);
            TinhTongTien();

            txtSoLuong.Text = "";
            txtCachDung.Text = "";
            cboThuoc.Focus();
        }

        // 5. Tính tổng tiền hiển thị chơi cho vui
        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in dtChiTietDV.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            foreach (DataRow r in dtToaThuoc.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);

            lblTongTien.Text = "TỔNG THANH TOÁN: " + tong.ToString("N0") + " VNĐ";
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvToaThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // --- [THÊM HÀM NÀY] Để chuyển đổi chuỗi sang số mà không bị lỗi ---
        private float ParseFloat(string val)
        {
            float result = 0;
            if (float.TryParse(val, out result)) return result;
            return 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (cboBenhNhan.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn bệnh nhân!"); return;
            }
            // Cảnh báo nếu phiếu trống
            if (dtChiTietDV.Rows.Count == 0 && dtToaThuoc.Rows.Count == 0)
            {
                if (MessageBox.Show("Phiếu này không có thuốc hay dịch vụ nào. Bạn có chắc muốn lưu?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            try
            {
                // 2. Tạo đối tượng Phiếu Khám và GOM DỮ LIỆU
                PhieuKham pk = new PhieuKham();
                pk.MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue);
                pk.MaNV = 1; // User hiện tại (Sau này thay bằng biến toàn cục User)
                pk.NgayKham = dtpNgayKham.Value;
                pk.TrieuChung = txtTrieuChung.Text;
                pk.ChanDoan = txtChanDoan.Text;

                // --- [PHẦN MỚI THÊM] ---
                pk.LoiDan = txtLoiDan.Text; // Lấy lời dặn

                // Lấy ngày tái khám (nếu có tick chọn)
                if (dtpTaiKham.Checked) pk.NgayTaiKham = dtpTaiKham.Value;
                else pk.NgayTaiKham = null;

                // Lấy sinh hiệu (Dùng hàm ParseFloat để tránh lỗi)
                pk.CanNang = ParseFloat(txtCanNang.Text);
                pk.ChieuCao = ParseFloat(txtChieuCao.Text);
                pk.NhietDo = ParseFloat(txtNhietDo.Text);
                pk.HuyetAp = txtHuyetAp.Text;
                // -----------------------

                // 3. GỌI BUS LƯU PHIẾU
                int maPhieuXuLy = 0;
                bool thanhCong = false;

                if (currMaPhieu > 0)
                {
                    // Trường hợp Cập nhật
                    pk.MaPhieu = currMaPhieu;
                    if (pkBUS.CapNhatPhieuKham(pk))
                    {
                        maPhieuXuLy = currMaPhieu;
                        thanhCong = true;
                    }
                }
                else
                {
                    // Trường hợp Tạo mới
                    maPhieuXuLy = pkBUS.InsertPhieuKham_LayMa(pk);
                    if (maPhieuXuLy > 0) thanhCong = true;
                }

                if (thanhCong)
                {
                    // Chỉ lưu chi tiết Thuốc/DV khi tạo mới (currMaPhieu == 0)
                    if (currMaPhieu == 0)
                    {
                        foreach (DataRow r in dtChiTietDV.Rows)
                        {
                            pkBUS.InsertChiTietDV(maPhieuXuLy, Convert.ToInt32(r["MaDV"]), Convert.ToInt32(r["SoLuong"]), Convert.ToDecimal(r["GiaDV"]), Convert.ToDecimal(r["ThanhTien"]));
                        }
                        foreach (DataRow r in dtToaThuoc.Rows)
                        {
                            pkBUS.InsertToaThuoc(maPhieuXuLy, Convert.ToInt32(r["MaThuoc"]), Convert.ToInt32(r["SoLuong"]), Convert.ToDecimal(r["DonGia"]), Convert.ToDecimal(r["ThanhTien"]), r["CachDung"].ToString());
                        }
                    }

                    MessageBox.Show("Lưu phiếu khám thành công! Mã phiếu: " + maPhieuXuLy);

                    // 4. RESET FORM (Dọn dẹp để khám người mới)
                    currMaPhieu = 0; // Về trạng thái thêm mới
                    cboBenhNhan.SelectedIndex = -1;

                    // Xóa các ô nhập liệu cũ
                    txtTrieuChung.Text = "";
                    txtChanDoan.Text = "";
                    txtLoiDan.Text = "";

                    // Xóa sinh hiệu
                    txtCanNang.Text = ""; txtChieuCao.Text = "";
                    txtHuyetAp.Text = ""; txtNhietDo.Text = "";

                    // Reset ngày tái khám
                    dtpTaiKham.Checked = false;

                    // Xóa bảng tạm
                    dtChiTietDV.Rows.Clear();
                    dtToaThuoc.Rows.Clear();
                    lblTongTien.Text = "TỔNG THANH TOÁN: 0 VNĐ";
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu phiếu khám!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}