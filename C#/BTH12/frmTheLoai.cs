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
    public partial class frmTheLoai : Form
    {
        TheLoai obj = new TheLoai();
        public frmTheLoai()
        {
            InitializeComponent();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            dgvTL.DataSource = obj.getDSTheLoai();
        }

        private void dgvTL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTL.Rows[e.RowIndex];
                txtMaTL.Text = row.Cells[0].Value.ToString();
                txtDienGiai.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                obj.addTheLoai(txtMaTL.Text, txtDienGiai.Text);
                dgvTL.DataSource = obj.getDSTheLoai();
                MessageBox.Show("Them thanh cong!");
            }
            catch (Exception ex) { MessageBox.Show("Loi!"); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            obj.updateTheLoai(txtMaTL.Text, txtDienGiai.Text);
            dgvTL.DataSource = obj.getDSTheLoai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            obj.deleteTheLoai(txtMaTL.Text);
            dgvTL.DataSource = obj.getDSTheLoai();
            txtMaTL.Clear();
            txtDienGiai.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
