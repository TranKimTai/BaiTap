using System.Data;
using QuanLyPhongKham.DAL;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.BUS
{
    public class ThuocBUS
    {
        private ThuocDAL dal = new ThuocDAL();

        public DataTable GetDanhSachThuoc(string keyword = "")
        {
            return dal.GetDanhSachThuoc(keyword);
        }

        public bool ThemThuoc(Thuoc t)
        {
            if (string.IsNullOrEmpty(t.TenThuoc)) return false;
            // Giá và Số lượng không được âm (Dù SQL có check, nhưng C# check trước càng tốt)
            if (t.DonGiaThuoc < 0 || t.SoLuongTon < 0) return false;

            return dal.ThemThuoc(t);
        }

        public bool SuaThuoc(Thuoc t)
        {
            if (t.MaThuoc <= 0) return false;
            if (string.IsNullOrEmpty(t.TenThuoc)) return false;
            if (t.DonGiaThuoc < 0 || t.SoLuongTon < 0) return false;

            return dal.SuaThuoc(t);
        }

        public bool XoaThuoc(int maThuoc)
        {
            return dal.XoaThuoc(maThuoc);
        }
    }
}