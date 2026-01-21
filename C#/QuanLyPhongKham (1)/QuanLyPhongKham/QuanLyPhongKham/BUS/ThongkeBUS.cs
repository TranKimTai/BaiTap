using System;
using System.Data;
using QuanLyPhongKham.DAL;

namespace QuanLyPhongKham.BUS
{
    public class ThongKeBUS
    {
        ThongKeDAL dal = new ThongKeDAL();

        public DataTable GetDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return dal.GetChiTietDoanhThu(tuNgay, denNgay);
        }
    }
}