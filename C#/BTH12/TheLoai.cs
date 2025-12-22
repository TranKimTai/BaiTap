using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH12
{
    class TheLoai
    {
        private ThaotacCSDL db;

        public TheLoai()
        {
            db = new ThaotacCSDL();
        }

        public void addTheLoai(String matl, String diengiai)
        {
            string sql = String.Format("Insert Into tblTheLoai Values(N'{0}',N'{1}')", matl, diengiai);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void updateTheLoai(String matl, String diengiai)
        {
            string sql = String.Format("UPDATE tblTheLoai SET DiengiaiTL=N'{1}' WHERE MaTL='{0}'", matl, diengiai);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void deleteTheLoai(String matl)
        {
            string sql = String.Format("DELETE FROM tblTheLoai WHERE MaTL='{0}'", matl);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public DataTable getDSTheLoai()
        { //Lay danh sach DM tac gia co trong CSDL
            String sql = "Select * from tblTheLoai";
            DataTable dt = db.Execute(sql);
            return dt;
        }

    }
}
