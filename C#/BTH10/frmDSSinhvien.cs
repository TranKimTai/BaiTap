using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH10
{
    public partial class frmDSSinhvien : Form
    {
        List<Sinhvien> dssv = new List<Sinhvien>();
        public frmDSSinhvien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_Nam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            frmTTSinhvien frmsv = new frmTTSinhvien();
            

            if(frmsv.ShowDialog()== DialogResult.OK)
            {Sinhvien sv = new Sinhvien();
                sv.hoten = frmsv.txtHoTen.Text;
                sv.diachi = frmsv.txtDiaChi.Text;
                sv.dienthoai = frmsv.txtDienThoai.Text;
                sv.namsinh = int.Parse(frmsv.txtNamSinh.Text);
                sv.gioitinh = frmsv.rbtn_nam.Checked;
                sv.khoahoc = frmsv.cb_KhoaHoc.Text;
                dssv.Add(sv);
                lb_dssv.Items.Add(frmsv.txtHoTen.Text);

            }
        }

        private void lb_Khoahoc_Click(object sender, EventArgs e)
        {

        }

        private void lb_Diachi_Click(object sender, EventArgs e)
        {

        }

        private void lb_dienthoai_Click(object sender, EventArgs e)
        {

        }

        private void lb_Namsinh_Click(object sender, EventArgs e)
        {

        }

        private void lb_gioitinh_Click(object sender, EventArgs e)
        {

        }

        private void lb_hoten_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_Nu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = lb_dssv.SelectedIndex;
            if (index >= 0)
            {
                dssv.RemoveAt(index);
                lb_dssv.Items.RemoveAt(index);
            }
        }

        private void frmDSSinhvien_Load(object sender, EventArgs e)
        {

        }

        private void btn_Capnhat_Click(object sender, EventArgs e)
        {
            int index = lb_dssv.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa thông tin!");
                return;
            }
            Sinhvien svCansua = dssv[index];
            frmTTSinhvien frmsv = new frmTTSinhvien();

            frmsv.txtHoTen.Text = svCansua.hoten;
            frmsv.txtNamSinh.Text = svCansua.namsinh.ToString();
            frmsv.txtDienThoai.Text = svCansua.dienthoai;
            frmsv.txtDiaChi.Text = svCansua.diachi;
            frmsv.cb_KhoaHoc.Text = svCansua.khoahoc;
            if (svCansua.gioitinh == true)
            {
                frmsv.rbtn_nam.Checked = true;
            }
            else
            {
                frmsv.rbtn_nu.Checked = true;
            }

            if (frmsv.ShowDialog() == DialogResult.OK)
            {
                svCansua.hoten = frmsv.txtHoTen.Text;
                svCansua.diachi = frmsv.txtDiaChi.Text;
                svCansua.dienthoai = frmsv.txtDienThoai.Text;
                svCansua.khoahoc = frmsv.cb_KhoaHoc.Text;

                int.TryParse(frmsv.txtNamSinh.Text, out svCansua.namsinh);

                if (frmsv.rbtn_nam.Checked)
                    svCansua.gioitinh = true;
                else
                    svCansua.gioitinh = false;

                lb_dssv.Items[index] = svCansua.hoten;
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
        }

        private void btn_Thoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
