using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH12
{
    class Tacgia
    {
        ThaotacCSDL db;

        public Tacgia()
        {
            db = new ThaotacCSDL();
        }
        public void addTacgia(String matg, String tentg, string dc, string dt)
        { 
            string sql = String.Format("Insert Into tblTacgia Values(N'{0}',N'{1}', N'{2}', N'{3}')",matg, tentg, dc, dt);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void updateTacgia(String matg, String tentg, string dc, string dt)
        {
            string sql = String.Format("UPDATE tblTacgia SET TenTG=N'{1}', Diachi=N'{2}', Dienthoai='{3}' WHERE MaTG='{0}'", matg, tentg, dc, dt);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void deleteTacgia(String matg)
        {
            string sql = String.Format("DELETE FROM tblTacgia WHERE MaTG='{0}'", matg);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);    
        }

        public DataTable getDSTacgia()
        { //Lay danh sach DM tac gia co trong CSDL
            String sql = "Select * from tblTacgia";
            DataTable dt = db.Execute(sql);
            return dt;
        }
    }
}
