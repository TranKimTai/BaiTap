using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH12
{
    class ThaotacCSDL
    {
        SqlConnection sqlConn;

        SqlDataAdapter da;

        DataSet ds;

        public ThaotacCSDL()
        {
            string strCnn = "Data Source=.; Database=LTUD_QLTV; Integrated Security=True";
            sqlConn=new SqlConnection(strCnn);
        }

        public DataTable Execute(string sqlStr)
        { 
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }   
        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn);
            sqlConn.Open(); //Mo ket noi
            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            sqlConn.Close();//Dong ket noi
        }
    }

   
}
