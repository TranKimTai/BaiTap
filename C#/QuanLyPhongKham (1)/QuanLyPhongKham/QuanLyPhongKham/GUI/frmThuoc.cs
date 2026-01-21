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
    public partial class frmThuoc : Form
    {
        private ThuocBUS thuocBUS = new ThuocBUS();
        private string currMode = "";
        private int currMaThuoc = 0;

        public frmThuoc()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

            // Đặt tên cột tiếng Việt
            if (dgvThuoc.Columns.Count > 0)
            {
                dgvThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                dgvThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc";
                dgvThuoc.Columns["DonViTinh"].HeaderText = "Đơn Vị";
                dgvThuoc.Columns["DonGiaThuoc"].HeaderText = "Đơn Giá";
                dgvThuoc.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvThuoc.Columns["HoatChat"].HeaderText = "Hoạt Chất";

                // Định dạng cột Giá tiền (thêm dấu phẩy cho dễ nhìn)
                dgvThuoc.Columns["DonGiaThuoc"].DefaultCellStyle.Format = "N0";
            }
        }

        private void SetNull()
        {
            txtTenThuoc.Text = "";
            cboDonViTinh.SelectedIndex = -1; // Hoặc cboDonViTinh.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtHoatChat.Text = "";
            txtTenThuoc.Focus();
        }

        private void SetButton(bool val)
        {
            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnLuu.Enabled = !val;
            btnBoQua.Enabled = !val;
        }

        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(false);
            currMode = "THEM";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaThuoc == 0)
            {
                MessageBox.Show("Vui lòng chọn thuốc cần sửa!");
                return;
            }
            SetButton(false);
            currMode = "SUA";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaThuoc == 0) return;
            if (MessageBox.Show("Bạn chắc chắn xóa thuốc này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Bắt lỗi nếu thuốc đã được kê đơn (Foreign Key)
                try
                {
                    if (thuocBUS.XoaThuoc(currMaThuoc))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        SetNull();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa! Thuốc này đã từng được kê đơn cho bệnh nhân.");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!"); return;
            }

            Thuoc t = new Thuoc();
            t.TenThuoc = txtTenThuoc.Text;
            t.DonViTinh = cboDonViTinh.Text;
            t.HoatChat = txtHoatChat.Text;

            // Xử lý giá tiền (decimal)
            decimal gia;
            if (decimal.TryParse(txtDonGia.Text, out gia)) t.DonGiaThuoc = gia;
            else { MessageBox.Show("Đơn giá phải là số!"); return; }

            // Xử lý số lượng (int)
            int sl;
            if (int.TryParse(txtSoLuong.Text, out sl)) t.SoLuongTon = sl;
            else { MessageBox.Show("Số lượng phải là số nguyên!"); return; }

            bool result = false;
            if (currMode == "THEM") result = thuocBUS.ThemThuoc(t);
            else if (currMode == "SUA")
            {
                t.MaThuoc = currMaThuoc;
                result = thuocBUS.SuaThuoc(t);
            }

            if (result)
            {
                MessageBox.Show("Thành công!");
                LoadData();
                SetButton(true);
            }
            else MessageBox.Show("Thất bại! Có thể tên thuốc bị trùng.");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm Realtime luôn cho xịn
            LoadData(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
