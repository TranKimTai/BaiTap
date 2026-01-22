using QuanLyPhongKham.DAL;
using QuanLyPhongKham.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyPhongKham.BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL nvDAL = new NhanVienDAL();

        public bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            DataTable dt = nvDAL.DangNhap(taiKhoan, matKhau);

            if (dt.Rows.Count > 0)
            {
                // Đăng nhập thành công -> Lưu thông tin vào Session ngay lập tức
                DataRow r = dt.Rows[0];
                Session.MaNV = Convert.ToInt32(r["MaNV"]);
                Session.HoTen = r["HoTenNV"].ToString();
                Session.QuyenHan = r["QuyenHan"].ToString();
                return true;
            }
            return false;
        }

        public DataTable GetDanhSachNhanVien()
        {
            return nvDAL.GetDanhSachNhanVien();
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            // Kiểm tra rỗng (Validation)
            if (string.IsNullOrEmpty(nv.HoTenNV) || string.IsNullOrEmpty(nv.TaiKhoan))
                return false;
            return nvDAL.ThemNhanVien(nv);
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            if (nv.MaNV <= 0 || string.IsNullOrEmpty(nv.HoTenNV))
                return false;
            return nvDAL.SuaNhanVien(nv);
        }

        public bool XoaNhanVien(int maNV)
        {
            return nvDAL.XoaNhanVien(maNV);
        }
    }
}