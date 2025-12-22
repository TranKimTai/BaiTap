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
    public partial class frmNXB : Form
    {
        NhaXuatBan obj = new NhaXuatBan();
        public frmNXB()
        {
            InitializeComponent();
        }

        private void dgvNXB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvNXB.DataSource = obj.getDSNXB();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                obj.addNXD(txtMaNXB.Text, txtTenNXB.Text, txtDiachiNXB.Text, txtDienthoaiNXB.Text);
                dgvNXB.DataSource = obj.getDSNXB();
                MessageBox.Show("Them thanh cong!");
            }
            catch (Exception ex) { MessageBox.Show("Loi!"); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            obj.updateNXB(txtMaNXB.Text, txtTenNXB.Text, txtDiachiNXB.Text, txtDienthoaiNXB.Text);
            dgvNXB.DataSource = obj.getDSNXB();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            obj.deleteNXB(txtMaNXB.Text);
            dgvNXB.DataSource = obj.getDSNXB();
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtDiachiNXB.Clear();
            txtDienthoaiNXB.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNXB_Load(object sender, EventArgs e)
        {
            dgvNXB.DataSource = obj.getDSNXB();
        }
    }
}
