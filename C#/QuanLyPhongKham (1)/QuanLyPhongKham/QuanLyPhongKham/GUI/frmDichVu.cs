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
            SetButton(true); // Mặc định chế độ XEM
        }

        private void LoadData(string keyword = "")
        {
            DataTable dt = dvBUS.GetDanhSachDichVu(keyword);
            dgvDichVu.DataSource = dt;

            if (dgvDichVu.Columns.Count > 0)
            {
                dgvDichVu.Columns["MaDV"].HeaderText = "Mã DV";
                dgvDichVu.Columns["TenDV"].HeaderText = "Tên Dịch Vụ";
                dgvDichVu.Columns["GiaDV"].HeaderText = "Đơn Giá";

                // Định dạng tiền tệ
                dgvDichVu.Columns["GiaDV"].DefaultCellStyle.Format = "N0";
            }
        }

        private void SetNull()
        {
            txtTenDV.Text = "";
            txtGiaDV.Text = "";
            txtTenDV.Focus();
        }

        private void SetButton(bool val)
        {
            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnLuu.Enabled = !val;
            btnBoQua.Enabled = !val;
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                if (row.Cells["MaDV"].Value == null || row.Cells["MaDV"].Value == DBNull.Value) return;

                currMaDV = Convert.ToInt32(row.Cells["MaDV"].Value);
                txtTenDV.Text = row.Cells["TenDV"].Value.ToString();
                txtGiaDV.Text = row.Cells["GiaDV"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(false);
            currMode = "THEM";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currMaDV == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!"); return;
            }
            SetButton(false);
            currMode = "SUA";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currMaDV == 0) return;
            if (MessageBox.Show("Bạn chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (dvBUS.XoaDichVu(currMaDV))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        SetNull();
                    }
                }
                catch
                {
                    MessageBox.Show("Dịch vụ này đã được sử dụng, không thể xóa!");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDV.Text)) { MessageBox.Show("Chưa nhập tên dịch vụ!"); return; }

            DichVu dv = new DichVu();
            dv.TenDV = txtTenDV.Text;

            decimal gia;
            if (!decimal.TryParse(txtGiaDV.Text, out gia)) { MessageBox.Show("Giá tiền phải là số!"); return; }
            dv.GiaDV = gia;

            bool kq = false;
            if (currMode == "THEM") kq = dvBUS.ThemDichVu(dv);
            else if (currMode == "SUA")
            {
                dv.MaDV = currMaDV;
                kq = dvBUS.SuaDichVu(dv);
            }

            if (kq)
            {
                MessageBox.Show("Thành công!");
                LoadData();
                SetButton(true);
            }
            else MessageBox.Show("Thất bại!");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetNull();
            SetButton(true);
        }
    }
}
