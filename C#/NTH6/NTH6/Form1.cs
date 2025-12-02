using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTH6
{
    public partial class Form1 : Form
    {
        string pheptoan = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.txt_ketqua.Text += btn.Text;
        }

        private void pheptoan_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            pheptoan = btn.Text;
            txt_tam.Text = txt_ketqua.Text;
            txt_ketqua.Text = " ";
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            
            switch (pheptoan)
            {

                case "+":
                    {
                        txt_ketqua.Text = (double.Parse(txt_ketqua.Text) + double.Parse(txt_tam.Text)).ToString();
                        break;

                    }
                case "-":
                    {
                        txt_ketqua.Text = (double.Parse(txt_tam.Text) - double.Parse(txt_ketqua.Text)).ToString();
                        break;

                    }
                case "*":
                    {
                        txt_ketqua.Text = (double.Parse(txt_ketqua.Text) * double.Parse(txt_tam.Text)).ToString();
                        break;

                    }
                case "/":
                    {
                        if (double.Parse(txt_ketqua.Text) == 0) //chia 0
                        {
                            MessageBox.Show("Không thể chia cho 0!");
                            return;
                        }

                        txt_ketqua.Text = (double.Parse(txt_tam.Text) / double.Parse(txt_ketqua.Text)).ToString();
                        break;

                    }

            }

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_ketqua.Text = "";
            txt_tam.Text = "";
        }

        private void txt_ketqua_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txt_ketqua.Text += btn.Text;
        }
    }
    }

