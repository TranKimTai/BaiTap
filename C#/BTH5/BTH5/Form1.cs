using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_ketqua.ReadOnly = true;
        }

        private void txt_son_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_som_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ketqua_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_cong_Click(object sender, EventArgs e)
        {
            float son = float.Parse(txt_son.Text);
            float som = float.Parse(txt_som.Text);
            float ketqua = son + som;
            txt_ketqua.Text = ketqua.ToString();
        }

        private void btn_tru_Click(object sender, EventArgs e)
        {
            float son = float.Parse(txt_son.Text);
            float som = float.Parse(txt_som.Text);
            float ketqua = son - som;
            txt_ketqua.Text = ketqua.ToString();
        }

        private void btn_nhan_Click(object sender, EventArgs e)
        {
            float son = float.Parse(txt_son.Text);
            float som = float.Parse(txt_som.Text);
            float ketqua = son * som;
            txt_ketqua.Text = ketqua.ToString();
        }

        private void btn_chia_Click(object sender, EventArgs e)
        {
            float son = float.Parse(txt_son.Text);
            float som = float.Parse(txt_som.Text);
            float ketqua = son / som;
            txt_ketqua.Text = ketqua.ToString();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            txt_son.Text = "";
            txt_som.Text = "";
            txt_ketqua.Text = "";
            txt_son.Focus();
        }

        private void vbtn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
