using System.Data;
using QuanLyPhongKham.DAL;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.BUS
{
    public class HoaDonBUS
    {
        HoaDonDAL dal = new HoaDonDAL();

        public DataTable GetDanhSachChoThanhToan(string keyword = "")
        {
            return dal.GetDanhSachChoThanhToan(keyword);
        }

        public decimal GetTongTienDV(int maPhieu)
        {
            return dal.GetTongTienDV(maPhieu);
        }

        public decimal GetTongTienThuoc(int maPhieu)
        {
            return dal.GetTongTienThuoc(maPhieu);
        }

        public bool ThanhToan(HoaDon hd)
        {
            return dal.ThanhToan(hd);
        }
    }
}