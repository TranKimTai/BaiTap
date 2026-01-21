using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyPhongKham.DTO;

namespace QuanLyPhongKham.DAL
{
    public class PhieuKhamDAL
    {
        // =================================================================
        // PHẦN 1: QUẢN LÝ DANH SÁCH PHIẾU KHÁM (Dùng cho Lễ tân, Bác sĩ)
        // =================================================================

        // 1. Lấy danh sách phiếu khám theo ngày và trạng thái
        public DataTable GetDanhSachPhieuKham(DateTime ngay, int trangThai = -1)
        {
            string query = @"SELECT p.MaPhieu, p.NgayKham, b.HoTenBN, p.TrangThaiPhieu, 
                                    p.TrieuChung, p.ChanDoan
                             FROM PHIEUKHAM p
                             JOIN BENHNHAN b ON p.MaBN = b.MaBN
                             WHERE CONVERT(DATE, p.NgayKham) = @Ngay";

            if (trangThai != -1)
            {
                query += " AND p.TrangThaiPhieu = " + trangThai;
            }

            query += " ORDER BY p.MaPhieu DESC";

            SqlParameter[] param = { new SqlParameter("@Ngay", ngay.Date) };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 2. Tạo phiếu khám mới (Lễ tân tiếp nhận - Chỉ tạo cơ bản)
        public bool TaoPhieuKham(PhieuKham pk)
        {
            string query = @"INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, TrangThaiPhieu, TrieuChung) 
                             VALUES (@Ngay, @MaBN, @MaNV, 0, @TrieuChung)";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ngay", pk.NgayKham),
                new SqlParameter("@MaBN", pk.MaBN),
                new SqlParameter("@MaNV", pk.MaNV),
                new SqlParameter("@TrieuChung", pk.TrieuChung ?? (object)DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // 3. Cập nhật thông tin sau khi khám (Bác sĩ lưu - Update đầy đủ)
        public bool CapNhatPhieuKham(PhieuKham pk)
        {
            string query = @"UPDATE PHIEUKHAM 
                             SET CanNang = @CN, ChieuCao = @CC, HuyetAp = @HA, NhietDo = @ND,
                                 TrieuChung = @TC, ChanDoan = @CD, LoiDan = @LD, 
                                 NgayTaiKham = @TaiKham, TrangThaiPhieu = 1
                             WHERE MaPhieu = @MaPhieu";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", pk.MaPhieu),
                new SqlParameter("@CN", pk.CanNang),
                new SqlParameter("@CC", pk.ChieuCao),
                new SqlParameter("@HA", pk.HuyetAp ?? ""),
                new SqlParameter("@ND", pk.NhietDo),
                new SqlParameter("@TC", pk.TrieuChung ?? ""),
                new SqlParameter("@CD", pk.ChanDoan ?? ""),
                new SqlParameter("@LD", pk.LoiDan ?? ""),
                new SqlParameter("@TaiKham", pk.NgayTaiKham ?? (object)DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // =================================================================
        // PHẦN 2: NGHIỆP VỤ KHÁM BỆNH (Dùng cho nút LƯU ở form Khám Bệnh)
        // =================================================================

        // 4. Tạo phiếu khám và TRẢ VỀ MÃ PHIẾU (ĐÃ SỬA: BỔ SUNG SINH HIỆU)
        // Hàm này dùng khi Bác sĩ tự tạo phiếu khám mới và điền luôn các chỉ số
        // 4. Tạo phiếu khám và TRẢ VỀ MÃ PHIẾU (ĐÃ CẬP NHẬT 4 CHỈ SỐ)
        // 4. Tạo phiếu khám (ĐẦY ĐỦ: SINH HIỆU + LỜI DẶN + TÁI KHÁM)
        public int InsertPhieuKham_LayMa(PhieuKham pk)
        {
            // Bổ sung: LoiDan, NgayTaiKham
            string query = @"INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, TrieuChung, ChanDoan, LoiDan, NgayTaiKham,
                                            CanNang, ChieuCao, HuyetAp, NhietDo, TrangThaiPhieu) 
                     VALUES (@Ngay, @MaBN, @MaNV, @TrieuChung, @ChanDoan, @LoiDan, @NgayTaiKham,
                             @CN, @CC, @HA, @ND, 1);
                     SELECT SCOPE_IDENTITY();";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ngay", pk.NgayKham),
                new SqlParameter("@MaBN", pk.MaBN),
                new SqlParameter("@MaNV", pk.MaNV),
                new SqlParameter("@TrieuChung", pk.TrieuChung ?? ""),
                new SqlParameter("@ChanDoan", pk.ChanDoan ?? ""),
        
                // --- THÊM MỚI ---
                new SqlParameter("@LoiDan", pk.LoiDan ?? ""),
                // Kiểm tra nếu có ngày tái khám thì truyền vào, không thì NULL
                new SqlParameter("@NgayTaiKham", pk.NgayTaiKham.HasValue ? (object)pk.NgayTaiKham.Value : DBNull.Value),

                // --- SINH HIỆU ---
                new SqlParameter("@CN", pk.CanNang),
                new SqlParameter("@CC", pk.ChieuCao),
                new SqlParameter("@HA", pk.HuyetAp ?? ""),
                new SqlParameter("@ND", pk.NhietDo)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }

        // 5. Thêm chi tiết Dịch vụ
        public bool InsertChiTietDV(int maPhieu, int maDV, int soLuong, decimal donGia, decimal thanhTien)
        {
            string query = @"INSERT INTO CHITIETDICHVU (MaPhieu, MaDV, SoLuongDV, DonGiaDV, ThanhTienDV)
                             VALUES (@MaPhieu, @MaDV, @SL, @Gia, @ThanhTien)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaDV", maDV),
                new SqlParameter("@SL", soLuong),
                new SqlParameter("@Gia", donGia),
                new SqlParameter("@ThanhTien", thanhTien)
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // 6. Thêm Toa thuốc & TRỪ TỒN KHO
        public bool InsertToaThuoc(int maPhieu, int maThuoc, int soLuong, decimal giaBan, decimal thanhTien, string cachDung)
        {
            string query = @"INSERT INTO TOATHUOC (MaPhieu, MaThuoc, SoLuongThuoc, GiaBanThuoc, ThanhTienThuoc, CachDung)
                             VALUES (@MaPhieu, @MaThuoc, @SL, @Gia, @ThanhTien, @CachDung);

                             UPDATE THUOC SET SoLuongTon = SoLuongTon - @SL WHERE MaThuoc = @MaThuoc;";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaThuoc", maThuoc),
                new SqlParameter("@SL", soLuong),
                new SqlParameter("@Gia", giaBan),
                new SqlParameter("@ThanhTien", thanhTien),
                new SqlParameter("@CachDung", cachDung ?? "")
            };
            return DatabaseHelper.ExecuteNonQuery(query, param) > 0;
        }

        // =================================================================
        // PHẦN 3: LỊCH SỬ & TRA CỨU (Dùng cho form Lịch Sử Khám)
        // =================================================================

        // 7. Lấy lịch sử khám của bệnh nhân
        public DataTable GetLichSuKham(string tuKhoa)
        {
            string query = @"SELECT p.MaPhieu, p.NgayKham, nv.HoTenNV, b.HoTenBN, p.ChanDoan
                             FROM PHIEUKHAM p
                             JOIN BENHNHAN b ON p.MaBN = b.MaBN
                             JOIN NHANVIEN nv ON p.MaNV = nv.MaNV
                             WHERE (b.HoTenBN LIKE @Key OR b.SDT_BN LIKE @Key)
                             ORDER BY p.NgayKham DESC";

            SqlParameter[] param = { new SqlParameter("@Key", "%" + tuKhoa + "%") };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 8. Lấy chi tiết 1 phiếu (Dùng để hiển thị lại thông tin phiếu cũ)
        // 8. Lấy chi tiết 1 phiếu (Cập nhật: Lấy thêm Tên Bác Sĩ)
        public DataTable GetChiTietPhieu(int maPhieu)
        {
            // Thêm JOIN NHANVIEN để lấy HoTenNV
            string query = @"SELECT p.*, b.HoTenBN, nv.HoTenNV
                     FROM PHIEUKHAM p
                     JOIN BENHNHAN b ON p.MaBN = b.MaBN
                     JOIN NHANVIEN nv ON p.MaNV = nv.MaNV
                     WHERE p.MaPhieu = " + maPhieu;

            return DatabaseHelper.ExecuteQuery(query);
        }

        // 9. Lấy danh sách thuốc của 1 phiếu
        public DataTable GetThuocCuaPhieu(int maPhieu)
        {
            string query = @"SELECT t.TenThuoc, tt.SoLuongThuoc, t.DonViTinh, tt.CachDung
                             FROM TOATHUOC tt
                             JOIN THUOC t ON tt.MaThuoc = t.MaThuoc
                             WHERE tt.MaPhieu = " + maPhieu;
            return DatabaseHelper.ExecuteQuery(query);
        }

        // 10. Lấy danh sách dịch vụ của 1 phiếu
        public DataTable GetDichVuCuaPhieu(int maPhieu)
        {
            string query = @"SELECT dv.TenDV, ctdv.KetQuaDV
                             FROM CHITIETDICHVU ctdv
                             JOIN DICHVU dv ON ctdv.MaDV = dv.MaDV
                             WHERE ctdv.MaPhieu = " + maPhieu;
            return DatabaseHelper.ExecuteQuery(query);
        }

        // 11. Hàm lấy chi tiết Toa thuốc (Cho Form Thanh Toán)
        public DataTable GetChiTietToaThuoc(int maPK)
        {
            string sql = string.Format(@"
                SELECT 
                    t.TenThuoc, 
                    t.DonViTinh, 
                    tt.SoLuongThuoc AS SoLuong, 
                    tt.GiaBanThuoc AS DonGia, 
                    tt.ThanhTienThuoc AS ThanhTien 
                FROM TOATHUOC tt
                INNER JOIN THUOC t ON tt.MaThuoc = t.MaThuoc
                WHERE tt.MaPhieu = {0}", maPK);

            return DatabaseHelper.ExecuteQuery(sql);
        }

        // 12. Hàm lấy chi tiết Dịch vụ (Cho Form Thanh Toán)
        public DataTable GetChiTietDichVu(int maPK)
        {
            string sql = string.Format(@"
                SELECT 
                    dv.TenDV, 
                    ct.SoLuongDV AS SoLuong, 
                    ct.DonGiaDV AS DonGia, 
                    ct.ThanhTienDV AS ThanhTien 
                FROM CHITIETDICHVU ct
                INNER JOIN DICHVU dv ON ct.MaDV = dv.MaDV
                WHERE ct.MaPhieu = {0}", maPK);

            return DatabaseHelper.ExecuteQuery(sql);
        }
    }
}