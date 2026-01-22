using System;
using System.Data;
using QuanLyPhongKham.DAL;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.BUS
{
    public class PhieuKhamBUS
    {
        PhieuKhamDAL dal = new PhieuKhamDAL();

        // 1. Lấy danh sách phiếu khám (Dùng cho Lễ tân)
        public DataTable GetDanhSachPhieuKham(DateTime ngay)
        {
            return dal.GetDanhSachPhieuKham(ngay);
        }

        // Lấy danh sách chờ khám (Trạng thái = 0)
        public DataTable GetDanhSachChoKham(DateTime ngay)
        {
            return dal.GetDanhSachPhieuKham(ngay, 0);
        }

        public bool TaoPhieuKham(PhieuKham pk)
        {
            return dal.TaoPhieuKham(pk);
        }

        public bool CapNhatPhieuKham(PhieuKham pk)
        {
            return dal.CapNhatPhieuKham(pk);
        }

        // Lấy thông tin chi tiết 1 phiếu (Dùng để hiển thị lại thông tin cũ)
        // Trong PhieuKhamBUS.cs
        public PhieuKham GetThongTinPhieu(int maPhieu)
        {
            DataTable dt = dal.GetChiTietPhieu(maPhieu);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                PhieuKham pk = new PhieuKham();

                // Map các thông tin cơ bản
                pk.MaPhieu = Convert.ToInt32(r["MaPhieu"]);
                pk.MaBN = Convert.ToInt32(r["MaBN"]);
                pk.HoTenBN = r["HoTenBN"].ToString();
                pk.NgayKham = Convert.ToDateTime(r["NgayKham"]);

                // --- [MỚI] Lấy tên Bác Sĩ ---
                if (dt.Columns.Contains("HoTenNV"))
                    pk.TenBS = r["HoTenNV"].ToString();

                // Lấy thông tin khám
                pk.TrieuChung = r["TrieuChung"].ToString();
                pk.ChanDoan = r["ChanDoan"].ToString();
                pk.LoiDan = r["LoiDan"].ToString();

                // Lấy sinh hiệu (Xử lý null an toàn)
                pk.CanNang = r["CanNang"] != DBNull.Value ? Convert.ToSingle(r["CanNang"]) : 0;
                pk.ChieuCao = r["ChieuCao"] != DBNull.Value ? Convert.ToSingle(r["ChieuCao"]) : 0;
                pk.NhietDo = r["NhietDo"] != DBNull.Value ? Convert.ToSingle(r["NhietDo"]) : 0;
                pk.HuyetAp = r["HuyetAp"].ToString();

                // Lấy ngày tái khám
                if (r["NgayTaiKham"] != DBNull.Value) pk.NgayTaiKham = Convert.ToDateTime(r["NgayTaiKham"]);

                return pk;
            }
            return null;
        }

        // --- CÁC HÀM XỬ LÝ NÚT LƯU (KHÁM BỆNH) ---
        public int InsertPhieuKham_LayMa(PhieuKham pk)
        {
            return dal.InsertPhieuKham_LayMa(pk);
        }

        // Trong file PhieuKhamBUS.cs

        // [SỬA] Thêm tham số string ketQuaDV vào hàm này
        public void InsertChiTietDV(int maPhieu, int maDV, int soLuong, decimal donGia, decimal thanhTien, string ketQuaDV)
        {
            // Truyền tiếp xuống DAL
            dal.InsertChiTietDV(maPhieu, maDV, soLuong, donGia, thanhTien, ketQuaDV);
        }

        public void InsertToaThuoc(int maPhieu, int maThuoc, int soLuong, decimal giaBan, decimal thanhTien, string cachDung)
        {
            dal.InsertToaThuoc(maPhieu, maThuoc, soLuong, giaBan, thanhTien, cachDung);
        }

        // =========================================================
        // PHẦN BẠN ĐANG THIẾU (TRA CỨU LỊCH SỬ) - THÊM VÀO ĐÂY
        // =========================================================

        public DataTable GetLichSuKham(string tuKhoa)
        {
            return dal.GetLichSuKham(tuKhoa);
        }

        public DataTable GetThuocCuaPhieu(int maPhieu)
        {
            return dal.GetThuocCuaPhieu(maPhieu);
        }

        public DataTable GetDichVuCuaPhieu(int maPhieu)
        {
            return dal.GetDichVuCuaPhieu(maPhieu);
        }


        public DataTable GetChiTietToaThuoc(int maPK)
        {
            return dal.GetChiTietToaThuoc(maPK);
        }

        public DataTable GetChiTietDichVu(int maPK)
        {
            return dal.GetChiTietDichVu(maPK);
        }
    }
}