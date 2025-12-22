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
    public partial class fmTacGia : Form
    {
        public fmTacGia()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connString = "server=.; database=LTUD_QLTV;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);
            string sql = "select * from tblTacgia";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                hienthiReader(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chào các bạn nha!");
            }
            finally
            {
                conn.Close();
            }
        }

        public void hienthiReader(SqlDataReader reader)
        {
            while (reader.Read())
            {
                this.txtMaTG.Text = reader["MaTG"].ToString();
                this.txtTenTG.Text = reader["TenTG"].ToString();
                this.txtDiachiTG.Text = reader["DiachiTG"].ToString();
                this.txtDienthoaiTG.Text = reader["Dienthoai"].ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtMaTG.Text ="";
            this.txtTenTG.Text ="";
            this.txtDiachiTG.Text ="";
            this.txtDienthoaiTG.Text ="";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matg = this.txtMaTG.Text;
            string tentg = this.txtTenTG.Text;
            string diachi = this.txtDiachiTG.Text;
            string dienthoai = this.txtDienthoaiTG.Text;
            string sql = String.Format("Insert into tblTacgia values('{0}',N'{1}',N'{2}','{3}')",matg,tentg,diachi,dienthoai);
            string connString = "server=.;database=LTUD_QLTV;Integrated Security=SSPI;";
            
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(matg + "đã có trong CSDL!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string matg = this.txtMaTG.Text;
            string sql = String.Format("Delete from tblTacgia where MaTG='{0}'", matg);
            string connString = "server=.;database=LTUD_QLTV;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                int kq = cmd.ExecuteNonQuery();

                if (kq != 1)
                {
                    MessageBox.Show("Da xoa thanh cong!" + matg);
                    sql = "select * from tblTacgia";
                    cmd.CommandText = sql;
                    SqlDataReader reader = cmd.ExecuteReader();
                    hienthiReader(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(matg + "Khong xoa thanh cong!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connString = "server=.;database=LTUD_QLTV;Integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            string sql = "select * from tblTacgia";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            try
            { 
                ad.Fill(dt);
                dgvTacgia.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai du lieu len luoi!" + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvTacgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaTG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenTG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiachiTG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDienthoaiTG_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
