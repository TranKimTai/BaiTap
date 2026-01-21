using System.Data;
using QuanLyPhongKham.DAL;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.BUS
{
    public class DichVuBUS
    {
        private DichVuDAL dal = new DichVuDAL();

        public DataTable GetDanhSachDichVu(string keyword = "")
        {
            return dal.GetDanhSachDichVu(keyword);
        }

        public bool ThemDichVu(DichVu dv)
        {
            if (string.IsNullOrEmpty(dv.TenDV)) return false;
            if (dv.GiaDV < 0) return false;
            return dal.ThemDichVu(dv);
        }

        public bool SuaDichVu(DichVu dv)
        {
            if (dv.MaDV <= 0) return false;
            if (dv.GiaDV < 0) return false;
            return dal.SuaDichVu(dv);
        }

        public bool XoaDichVu(int maDV)
        {
            return dal.XoaDichVu(maDV);
        }
    }
}