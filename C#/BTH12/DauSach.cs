using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH12
{
    class DauSach
    {
        ThaotacCSDL db;

        public DauSach()
        {
            db = new ThaotacCSDL();
        }

        public DataTable getDSDauSach()
        { 
            String sql = "Select * from tblDauSach";
            DataTable dt = db.Execute(sql);
            return dt;
        }
        public DataTable getDSTacgia() => db.Execute("SELECT * FROM tbltacGia");
        public DataTable getDSNXB() => db.Execute("SELECT * FROM tblNhaXuatban");
        public DataTable getDSTheLoai() => db.Execute("SELECT * FROM tblTheLoai");

        public void addDauSach(String mads, String tends, int namxb, string ngaynhap, int solg, string matg, string manxb, string matl)
        {
            string sql = String.Format("Insert Into tblDauSach Values(N'{0}',N'{1}', N'{2}', N'{3}',N'{4}',N'{5}',N'{6}',N'{7}')", mads, tends, namxb, ngaynhap, solg, matg, manxb, matl);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void updateDauSach(String mads, String tends, int namxb, string ngaynhap, int solg, string matg, string manxb, string matl)
        {
            string sql = string.Format("UPDATE tblDauSach SET TenSach=N'{1}', NamXB={2}, NgayNhap='{3}', SoLg={4}, MaTG='{5}', MaNXB='{6}', MaTL='{7}' WHERE MaDS='{0}'",
             mads, tends, namxb, ngaynhap, solg, matg, manxb, matl);
            db.ExecuteNonQuery(sql);
        }

        public void deleteDauSach(String mads)
        {
            string sql = String.Format("DELETE FROM tblDauSach WHERE MaDS='{0}'", mads);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        



    }
}
