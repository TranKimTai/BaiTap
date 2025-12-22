using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH12
{
    class NhaXuatBan
    {
        ThaotacCSDL db;

        public NhaXuatBan()
        {
            db = new ThaotacCSDL();
        }

        public void addNXD(String manxb, String tennxb, string dc, string dt)
        {
            string sql = String.Format("Insert Into tblNhaXuatBan Values(N'{0}',N'{1}', N'{2}', N'{3}')", manxb, tennxb, dc, dt);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void updateNXB(String manxb, String tennxb, string dc, string dt)
        {
            string sql = String.Format("UPDATE tblNhaXuatBan SET TenNXB=N'{1}', DiachiNXB=N'{2}', DienthoaiNXB='{3}' WHERE MaNXB='{0}'", manxb, tennxb, dc, dt);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public void deleteNXB(String manxb)
        {
            string sql = String.Format("DELETE FROM tblNhaXuatBan WHERE MaNXB='{0}'", manxb);
            Console.WriteLine(sql);
            db.ExecuteNonQuery(sql);
        }

        public DataTable getDSNXB()
        { //Lay danh sach DM tac gia co trong CSDL
            String sql = "Select * from tblNhaXuatBan";
            DataTable dt = db.Execute(sql);
            return dt;
        }
    }
}
