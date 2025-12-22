using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH12
{
    public partial class frmDauSach : Form
    {
        DauSach obj = new DauSach();
        public frmDauSach()
        {
            InitializeComponent();
        }

        private void frmDauSach_Load(object sender, EventArgs e)
        {
            this.dgvDS.DataSource = obj.getDSDauSach();

            this.cbTacGia.DataSource = obj.getDSTacgia();
            this.cbTacGia.ValueMember = "MaTG";
            this.cbTacGia.DisplayMember = "TenTG";

            this.cbNXB.DataSource = obj.getDSNXB();
            this.cbNXB.ValueMember = "MaNXB";
            this.cbNXB.DisplayMember = "TenNXB";

            this.cbTheLoai.DataSource = obj.getDSTheLoai();
            this.cbTheLoai.ValueMember = "MaTL";
            this.cbTheLoai.DisplayMember = "TenTL";

        }

        private void btnCNTG_Click(object sender, EventArgs e)
        {
            frmTacgia_TH13 tg = new frmTacgia_TH13();
            tg.Show();
        }

        private void btnCNTL_Click(object sender, EventArgs e)
        {
            frmTheLoai tl = new frmTheLoai();
            tl.Show();
        }

        private void btnCNNXB_Click(object sender, EventArgs e)
        {
            frmNXB nxb = new frmNXB();
            nxb.Show();
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDS.Rows[e.RowIndex];
                txtMaDS.Text = row.Cells[0].Value.ToString();
                txtTenDS.Text = row.Cells[1].Value.ToString();
                txtNamXB.Text = row.Cells[2].Value.ToString();
                try
                {
                    txtNgayNhap.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                }
                catch { txtNgayNhap.Value = DateTime.Now; }
                
                txtSolg.Text = row.Cells[4].Value.ToString();
                
                cbTacGia.SelectedValue = row.Cells[5].Value.ToString();
                cbNXB.SelectedValue = row.Cells[6].Value.ToString();
                cbTheLoai.SelectedValue = row.Cells[7].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtMaDS.Text = "";
            this.txtTenDS.Text = "";
            this.txtSolg.Text = "0";
            this.txtNamXB.Text = DateTime.Now.Year.ToString();
            this.txtNgayNhap.Value = DateTime.Now;

            this.cbNXB.Text = "Chọn nhà xuất bản";
            this.cbTacGia.Text = "Chọn tác giả";
            this.cbTheLoai.Text = "Chọn thể loại";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy dữ liệu từ giao diện
                string mads = txtMaDS.Text;
                string tensach = txtTenDS.Text;
                int namxb = int.Parse(txtNamXB.Text);
                int solg = int.Parse(txtSolg.Text);
                string ngaynhap = txtNgayNhap.Value.ToString("yyyy-MM-dd");
                string matl = cbTheLoai.SelectedValue.ToString();
                string manxb = cbNXB.SelectedValue.ToString();
                string matg = cbTacGia.SelectedValue.ToString();

                // Gọi hàm Sửa bên lớp DauSach
                obj.addDauSach(mads, tensach, namxb, ngaynhap, solg, matl, manxb, matg);

                MessageBox.Show("Sửa thành công!");

                // Tải lại lưới và mở khóa ô Mã sách để nhập mới nếu cần
                dgvDS.DataSource = obj.getDSDauSach();
                txtMaDS.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDS.Text == "") return;
            obj.deleteDauSach(txtMaDS.Text);
            MessageBox.Show("Đã Xóa");
            dgvDS.DataSource = obj.getDSDauSach();
            btnThem_Click(sender, e);
            txtMaDS.Enabled = true;
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                string mads = txtMaDS.Text;
                string tensach = txtTenDS.Text;
                int namxb = int.Parse(txtNamXB.Text);
                int solg = int.Parse(txtSolg.Text);
                string ngaynhap = txtNgayNhap.Value.ToString("dd-MM-yyyy");
                string matl = cbTheLoai.SelectedValue.ToString();
                string manxb = cbNXB.SelectedValue.ToString();
                string matg = cbTacGia.SelectedValue.ToString();

                // Gọi hàm Sửa bên lớp DauSach
                obj.updateDauSach(mads, tensach, namxb, ngaynhap, solg, matl, manxb, matg);

                MessageBox.Show("Sửa thành công!");

                // Tải lại lưới và mở khóa ô Mã sách để nhập mới nếu cần
                dgvDS.DataSource = obj.getDSDauSach();
                txtMaDS.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
