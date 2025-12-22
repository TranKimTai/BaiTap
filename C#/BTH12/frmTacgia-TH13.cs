using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH12
{
    public partial class frmTacgia_TH13 : Form
    {
        
        Tacgia obj = new Tacgia();
        public frmTacgia_TH13()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvTacgia.DataSource = obj.getDSTacgia();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try {
                obj.addTacgia(txtMaTG.Text, txtTenTG.Text, txtDiachiTG.Text, txtDienthoaiTG.Text);
                dgvTacgia.DataSource = obj.getDSTacgia();
                MessageBox.Show("Them thanh cong!");
            }catch (Exception ex) { MessageBox.Show("Loi!"); }
        }


        private void frmTacgia_TH13_Load(object sender, EventArgs e)
        {
            dgvTacgia.DataSource = obj.getDSTacgia();
        }

        private void dgvTacgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTacgia.Rows[e.RowIndex];
                txtMaTG.Text = row.Cells[0].Value.ToString();
                txtTenTG.Text = row.Cells[1].Value.ToString();
                txtDiachiTG.Text = row.Cells[2].Value.ToString();
                txtDienthoaiTG.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            obj.deleteTacgia(txtMaTG.Text);
            dgvTacgia.DataSource = obj.getDSTacgia();
            txtMaTG.Clear();
            txtTenTG.Clear();
            txtDiachiTG.Clear();
            txtDienthoaiTG.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            obj.updateTacgia(txtMaTG.Text, txtTenTG.Text, txtDiachiTG.Text, txtDienthoaiTG.Text);
            dgvTacgia.DataSource = obj.getDSTacgia();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
