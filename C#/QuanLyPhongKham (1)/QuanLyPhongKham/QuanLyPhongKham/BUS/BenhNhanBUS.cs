using System.Data;
using QuanLyPhongKham.DAL;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.BUS
{
    public class BenhNhanBUS
    {
        private BenhNhanDAL dal = new BenhNhanDAL();

        // 1. Hàm lấy tất cả (Gọi hàm GetAll bên DAL)
        public DataTable GetAllBenhNhan()
        {
            return dal.GetAllBenhNhan();
        }

        // 2. Hàm tìm kiếm (Gọi hàm TimKiem bên DAL)
        public DataTable TimKiemBenhNhan(string keyword)
        {
            return dal.TimKiemBenhNhan(keyword);
        }

        public bool ThemBenhNhan(BenhNhan bn)
        {
            if (string.IsNullOrEmpty(bn.HoTenBN)) return false;
            return dal.ThemBenhNhan(bn);
        }

        public bool SuaBenhNhan(BenhNhan bn)
        {
            if (bn.MaBN <= 0) return false;
            return dal.SuaBenhNhan(bn);
        }

        public bool XoaBenhNhan(int maBN)
        {
            return dal.XoaBenhNhan(maBN);
        }
    }
}