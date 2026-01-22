CREATE DATABASE QuanLy_PhongKham;
GO
USE QuanLy_PhongKham;
GO

-- ====================================================
-- 1. DANH MỤC (BẢNG CHA)
-- ====================================================

-- 1. Bảng NHÂN VIÊN
CREATE TABLE NHANVIEN (
    MaNV INT IDENTITY(1,1) PRIMARY KEY, 
    
    -- [BẮT BUỘC] Để đăng nhập và hiển thị tên
    HoTenNV NVARCHAR(100) NOT NULL, 
    TaiKhoan VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(100) NOT NULL,
    QuyenHan NVARCHAR(20) NOT NULL CHECK (QuyenHan IN ('Admin', 'BacSi', 'LeTan', 'ThuNgan')),
    
    -- [TÙY CHỌN] Cho phép NULL để nhập liệu nhanh hơn
    NgaySinhNV DATE,            
    GioiTinhNV NVARCHAR(10),    
    SDT_NV VARCHAR(15), 
    DiaChiNV NVARCHAR(200),
    
    TrangThaiNV BIT DEFAULT 1 NOT NULL
);

-- 2. Bảng BỆNH NHÂN
CREATE TABLE BENHNHAN (
    MaBN INT IDENTITY(1,1) PRIMARY KEY, 
    
    -- [BẮT BUỘC]
    HoTenBN NVARCHAR(100) NOT NULL, 
    
    -- [TÙY CHỌN] Khám cấp cứu nhiều khi chưa kịp hỏi kỹ
    NamSinhBN INT CHECK (NamSinhBN > 1900),              
    GioiTinhBN NVARCHAR(10),
    SDT_BN VARCHAR(20),        
    DiaChiBN NVARCHAR(200),
    TienSuBenh NVARCHAR(MAX)    
);
ALTER TABLE BENHNHAN ADD TrangThai BIT DEFAULT 1;
-- Cập nhật lại các dòng cũ đang bị NULL thành 1 (Đang hoạt động)
UPDATE BENHNHAN SET TrangThai = 1 WHERE TrangThai IS NULL;

-- 3. Bảng DỊCH VỤ
CREATE TABLE DICHVU (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    
    -- [BẮT BUỘC] Tên và Giá không thể thiếu
    TenDV NVARCHAR(100) NOT NULL UNIQUE,
    GiaDV DECIMAL(18,0) NOT NULL DEFAULT 0 CHECK (GiaDV >= 0)
);

-- 4. Bảng THUỐC
CREATE TABLE THUOC (
    MaThuoc INT IDENTITY(1,1) PRIMARY KEY,
    
    -- [BẮT BUỘC]
    TenThuoc NVARCHAR(100) NOT NULL UNIQUE,
    DonViTinh NVARCHAR(20) NOT NULL,  
    
    -- Giá và Tồn kho mặc định là 0, không được NULL
    DonGiaThuoc DECIMAL(18,0) NOT NULL DEFAULT 0 CHECK (DonGiaThuoc >= 0), 
    SoLuongTon INT NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    
    -- [TÙY CHỌN]
    HoatChat NVARCHAR(100)
);

-- ====================================================
-- 2. NGHIỆP VỤ (BẢNG CON)
-- ====================================================

-- 5. Bảng PHIẾU KHÁM
CREATE TABLE PHIEUKHAM (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    NgayKham DATETIME NOT NULL DEFAULT GETDATE(),
    
    -- [BẮT BUỘC] Không có BN và BS thì phiếu vô nghĩa
    MaBN INT NOT NULL REFERENCES BENHNHAN(MaBN),
    MaNV INT NOT NULL REFERENCES NHANVIEN(MaNV), -- Bác sĩ khám
    
    -- [TÙY CHỌN] Sinh hiệu (Có thể bác sĩ lười đo)
    CanNang FLOAT,       
    ChieuCao FLOAT,      
    HuyetAp VARCHAR(20), 
    NhietDo FLOAT,       
    
    -- [TÙY CHỌN] Thông tin khám
    TrieuChung NVARCHAR(MAX), 
    ChanDoan NVARCHAR(MAX),   
    LoiDan NVARCHAR(MAX),
    NgayTaiKham DATE,    
    
    TrangThaiPhieu INT NOT NULL DEFAULT 0 CHECK (TrangThaiPhieu IN (0, 1, 2))
);

-- 6. Bảng CHI TIẾT DỊCH VỤ
CREATE TABLE CHITIETDICHVU (
    -- Khóa ngoại trùng tên khóa chính
    MaPhieu INT NOT NULL REFERENCES PHIEUKHAM(MaPhieu),
    MaDV INT NOT NULL REFERENCES DICHVU(MaDV),
    
    -- [BẮT BUỘC] Số lượng và Tiền phải có số liệu cụ thể
    SoLuongDV INT NOT NULL DEFAULT 1 CHECK (SoLuongDV > 0),
    DonGiaDV DECIMAL(18,0) NOT NULL DEFAULT 0, 
    
    -- [TÙY CHỌN] Kết quả có thể nhập sau
    KetQuaDV NVARCHAR(MAX),     
    
    -- Cột này C# tính xong Insert vào (Bắt buộc có số)
    ThanhTienDV DECIMAL(18,0) NOT NULL DEFAULT 0, 
    
    PRIMARY KEY (MaPhieu, MaDV)
);

-- 7. Bảng CHI TIẾT TOA THUỐC
CREATE TABLE TOATHUOC (
    MaPhieu INT NOT NULL REFERENCES PHIEUKHAM(MaPhieu),
    MaThuoc INT NOT NULL REFERENCES THUOC(MaThuoc),
    
    SoLuongThuoc INT NOT NULL DEFAULT 1 CHECK (SoLuongThuoc > 0),
    
    -- [TÙY CHỌN]
    CachDung NVARCHAR(200),
    
    -- [BẮT BUỘC]
    GiaBanThuoc DECIMAL(18,0) NOT NULL DEFAULT 0, 
    ThanhTienThuoc DECIMAL(18,0) NOT NULL DEFAULT 0, 
    
    PRIMARY KEY (MaPhieu, MaThuoc)
);

-- ====================================================
-- 3. TÀI CHÍNH
-- ====================================================

-- 8. Bảng HÓA ĐƠN
CREATE TABLE HOADON (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    
    -- Một phiếu chỉ 1 hóa đơn
    MaPhieu INT NOT NULL UNIQUE REFERENCES PHIEUKHAM(MaPhieu), 
    NgayLapHD DATETIME NOT NULL DEFAULT GETDATE(),
    
    -- Nhân viên thu ngân
    MaNV INT NOT NULL REFERENCES NHANVIEN(MaNV), 
    
    -- Tiền nong TUYỆT ĐỐI KHÔNG ĐỂ NULL (Dễ gây lỗi khi cộng trừ)
    TongTienDV DECIMAL(18,0) NOT NULL DEFAULT 0,
    TongTienThuoc DECIMAL(18,0) NOT NULL DEFAULT 0,
    TongThanhToan DECIMAL(18,0) NOT NULL DEFAULT 0,
    
    HinhThucTT NVARCHAR(50) DEFAULT N'Tiền mặt', 
    GhiChuHD NVARCHAR(200)
);
GO


------------đanh dấu---------------
USE QuanLy_PhongKham;
GO

-- ====================================================
-- PHẦN 0: LÀM SẠCH & CẬP NHẬT CẤU TRÚC
-- ====================================================

-- 1. Xóa dữ liệu cũ
ALTER TABLE CHITIETDICHVU NOCHECK CONSTRAINT ALL;
ALTER TABLE TOATHUOC NOCHECK CONSTRAINT ALL;
ALTER TABLE HOADON NOCHECK CONSTRAINT ALL;
ALTER TABLE PHIEUKHAM NOCHECK CONSTRAINT ALL;
ALTER TABLE NHANVIEN NOCHECK CONSTRAINT ALL;
ALTER TABLE BENHNHAN NOCHECK CONSTRAINT ALL;
ALTER TABLE DICHVU NOCHECK CONSTRAINT ALL;
ALTER TABLE THUOC NOCHECK CONSTRAINT ALL;

DELETE FROM HOADON;
DELETE FROM TOATHUOC;
DELETE FROM CHITIETDICHVU;
DELETE FROM PHIEUKHAM;
DELETE FROM NHANVIEN;
DELETE FROM BENHNHAN;
DELETE FROM DICHVU;
DELETE FROM THUOC;

-- Reset ID về 0
DBCC CHECKIDENT ('NHANVIEN', RESEED, 0);
DBCC CHECKIDENT ('BENHNHAN', RESEED, 0);
DBCC CHECKIDENT ('DICHVU', RESEED, 0);
DBCC CHECKIDENT ('THUOC', RESEED, 0);
DBCC CHECKIDENT ('PHIEUKHAM', RESEED, 0);
DBCC CHECKIDENT ('HOADON', RESEED, 0);

-- 2. CẬP NHẬT RÀNG BUỘC CHO PHÉP 'DuocSi'
-- Tìm và xóa constraint cũ của cột QuyenHan (vì constraint cũ chỉ cho phép Admin, BacSi...)
DECLARE @ConstraintName NVARCHAR(200);
SELECT @ConstraintName = name 
FROM sys.check_constraints 
WHERE parent_object_id = OBJECT_ID('NHANVIEN') AND definition LIKE '%QuyenHan%';

IF @ConstraintName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE NHANVIEN DROP CONSTRAINT ' + @ConstraintName);
END

-- Thêm constraint mới bao gồm 'DuocSi'
ALTER TABLE NHANVIEN 
ADD CONSTRAINT CK_QuyenHan CHECK (QuyenHan IN ('Admin', 'BacSi', 'LeTan', 'ThuNgan', 'DuocSi'));

-- Bật lại kiểm tra khóa ngoại
ALTER TABLE CHITIETDICHVU CHECK CONSTRAINT ALL;
ALTER TABLE TOATHUOC CHECK CONSTRAINT ALL;
ALTER TABLE HOADON CHECK CONSTRAINT ALL;
ALTER TABLE PHIEUKHAM CHECK CONSTRAINT ALL;
ALTER TABLE NHANVIEN CHECK CONSTRAINT ALL;
ALTER TABLE BENHNHAN CHECK CONSTRAINT ALL;
ALTER TABLE DICHVU CHECK CONSTRAINT ALL;
ALTER TABLE THUOC CHECK CONSTRAINT ALL;
GO

-- ====================================================
-- PHẦN 1: DỮ LIỆU NHÂN SỰ & DANH MỤC (TAI MŨI HỌNG)
-- ====================================================

-- 1. NHÂN VIÊN (5 Người như yêu cầu)
INSERT INTO NHANVIEN (HoTenNV, TaiKhoan, MatKhau, QuyenHan, NgaySinhNV, GioiTinhNV, SDT_NV, DiaChiNV, TrangThaiNV) VALUES 
(N'Nguyễn Quản Trị', 'admin', '123', 'Admin', '1985-01-01', N'Nam', '0901111111', N'Q1, TP.HCM', 1),
(N'BS.CK1 Lê Văn Thính', 'bacsi', '123', 'BacSi', '1978-05-20', N'Nam', '0902222222', N'Q3, TP.HCM', 1), -- Chuyên khoa Tai Mũi Họng
(N'Trần Thị Đón', 'letan', '123', 'LeTan', '1998-08-15', N'Nữ', '0903333333', N'Q5, TP.HCM', 1),
(N'Phạm Thị Thuốc', 'duocsi', '123', 'DuocSi', '1995-12-12', N'Nữ', '0904444444', N'Q10, TP.HCM', 1),
(N'Hoàng Thị Tiền', 'thungan', '123', 'ThuNgan', '1992-03-10', N'Nữ', '0905555555', N'Tân Bình, TP.HCM', 1);

-- 2. DỊCH VỤ (Chuyên khoa Tai Mũi Họng)
INSERT INTO DICHVU (TenDV, GiaDV) VALUES 
(N'Khám Tai Mũi Họng (Nội soi)', 200000), -- DV phổ biến nhất
(N'Hút dịch mũi xoang', 50000),
(N'Lấy dị vật (Hóc xương, dị vật tai)', 300000),
(N'Xông khí dung mũi họng', 60000),
(N'Rửa tai / Lấy ráy tai', 80000),
(N'Đốt cuốn mũi (Sóng cao tần)', 500000),
(N'Đo thính lực đồ', 150000),
(N'Tiểu phẫu trích rạch áp xe', 400000);

-- 3. THUỐC (Đặc thù TMH: Kháng sinh, Kháng viêm, Xịt, Nhỏ)
INSERT INTO THUOC (TenThuoc, DonViTinh, DonGiaThuoc, SoLuongTon, HoatChat) VALUES 
-- Kháng sinh
(N'Augmentin 1g', N'Viên', 22000, 500, N'Amoxicillin + Clavulanic'),
(N'Zinnat 500mg', N'Viên', 24000, 400, N'Cefuroxime'),
(N'Klacid 500mg', N'Viên', 28000, 300, N'Clarithromycin'),
-- Kháng viêm / Giảm phù nề
(N'Medrol 16mg', N'Viên', 5000, 1000, N'Methylprednisolone'),
(N'Alpha Choay', N'Viên', 3000, 2000, N'Chymotrypsin'),
-- Thuốc điều trị triệu chứng (Ho, Sổ mũi, Dị ứng)
(N'Telfast HD 180mg', N'Viên', 8000, 600, N'Fexofenadine (Chống dị ứng)'),
(N'Siro Prospan', N'Chai', 85000, 100, N'Cao lá thường xuân (Trị ho)'),
(N'Acemuc 200mg', N'Gói', 3000, 800, N'Acetylcysteine (Long đờm)'),
-- Thuốc dùng tại chỗ (Xịt, Nhỏ)
(N'Otrivin 0.1%', N'Lọ', 55000, 150, N'Xylometazoline (Xịt nghẹt mũi)'),
(N'Sterimar (Nước biển sâu)', N'Chai', 90000, 100, N'Nước biển sâu (Rửa mũi)'),
(N'Otipax', N'Lọ', 60000, 200, N'Phenazone + Lidocaine (Nhỏ tai)'),
(N'Betadine Súc họng', N'Chai', 70000, 120, N'Povidone-Iodine');

-- 4. BỆNH NHÂN (Đủ lứa tuổi)
INSERT INTO BENHNHAN (HoTenBN, NamSinhBN, GioiTinhBN, SDT_BN, DiaChiBN, TienSuBenh, TrangThai) VALUES 
(N'Nguyễn Văn An', 2018, N'Nam', '0918000001', N'Q1, TP.HCM', N'Hay bị viêm phế quản', 1), -- Trẻ em
(N'Trần Thị Bích', 1990, N'Nữ', '0918000002', N'Q3, TP.HCM', N'Viêm mũi dị ứng thời tiết', 1),
(N'Lê Hùng Cường', 1985, N'Nam', '0918000003', N'Q5, TP.HCM', N'Hút thuốc lá nhiều', 1),
(N'Phạm Thị Duyên', 2020, N'Nữ', '0918000004', N'Tân Bình', N'Không', 1), -- Trẻ em
(N'Hoàng Văn Em', 1960, N'Nam', '0918000005', N'Bình Thạnh', N'Cao huyết áp', 1),
(N'Đỗ Thị Mai', 1995, N'Nữ', '0918000006', N'Gò Vấp', N'Viêm xoang mãn tính', 1),
(N'Võ Tấn Tài', 1988, N'Nam', '0918000007', N'Thủ Đức', N'Dị ứng hải sản', 1);

-- ====================================================
-- PHẦN 2: KỊCH BẢN KHÁM BỆNH (DỮ LIỆU NGHIỆP VỤ)
-- ====================================================

-- --- KỊCH BẢN 1: BÉ BỊ VIÊM TAI GIỮA (Đã xong) ---
-- Bệnh nhân: Nguyễn Văn An (Trẻ em)
INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, CanNang, ChieuCao, NhietDo, TrieuChung, ChanDoan, LoiDan, TrangThaiPhieu) 
VALUES (GETDATE(), 1, 2, 22, 110, 38.5, 
        N'Sốt cao, đau tai phải, quấy khóc', 
        N'Viêm tai giữa cấp mủ (P)', 
        N'Tái khám sau 3 ngày, không để nước vào tai', 2);
DECLARE @P1 INT = SCOPE_IDENTITY();

-- Dịch vụ
INSERT INTO CHITIETDICHVU (MaPhieu, MaDV, SoLuongDV, DonGiaDV, ThanhTienDV, KetQuaDV) VALUES 
(@P1, 1, 1, 200000, 200000, N'Màng nhĩ phải sung huyết, phồng'),
(@P1, 5, 1, 80000, 80000, N'Làm sạch ống tai');

-- Thuốc
INSERT INTO TOATHUOC (MaPhieu, MaThuoc, SoLuongThuoc, GiaBanThuoc, ThanhTienThuoc, CachDung) VALUES 
(@P1, 2, 10, 24000, 240000, N'Sáng 1 viên, chiều 1 viên (Pha nước)'), -- Zinnat
(@P1, 11, 1, 60000, 60000, N'Nhỏ tai ngày 2 lần'), -- Otipax
(@P1, 7, 1, 85000, 85000, N'Uống 5ml khi ho'); -- Prospan

-- Hóa đơn
INSERT INTO HOADON (MaPhieu, NgayLapHD, MaNV, TongTienDV, TongTienThuoc, TongThanhToan, HinhThucTT) 
VALUES (@P1, GETDATE(), 5, 280000, 385000, 665000, N'Tiền mặt');


-- --- KỊCH BẢN 2: NGƯỜI LỚN BỊ HÓC XƯƠNG CÁ (Cấp cứu - Đã xong) ---
-- Bệnh nhân: Lê Hùng Cường
INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, HuyetAp, TrieuChung, ChanDoan, LoiDan, TrangThaiPhieu) 
VALUES (DATEADD(HOUR, -2, GETDATE()), 3, 2, '120/80', 
        N'Nuốt đau, cảm giác vướng ở họng sau khi ăn cá', 
        N'Dị vật họng miệng (Xương cá)', 
        N'Ăn mềm, uống thuốc theo đơn', 2);
DECLARE @P2 INT = SCOPE_IDENTITY();

-- Dịch vụ
INSERT INTO CHITIETDICHVU (MaPhieu, MaDV, SoLuongDV, DonGiaDV, ThanhTienDV, KetQuaDV) VALUES 
(@P2, 3, 1, 300000, 300000, N'Gắp ra 1 xương cá dài 2cm ở amidan trái');

-- Thuốc (Chỉ cần kháng viêm, giảm đau)
INSERT INTO TOATHUOC (MaPhieu, MaThuoc, SoLuongThuoc, GiaBanThuoc, ThanhTienThuoc, CachDung) VALUES 
(@P2, 5, 10, 3000, 30000, N'Ngậm dưới lưỡi ngày 4 viên'), -- Alpha Choay
(@P2, 12, 1, 70000, 70000, N'Súc họng sau khi ăn'); -- Betadine

-- Hóa đơn
INSERT INTO HOADON (MaPhieu, NgayLapHD, MaNV, TongTienDV, TongTienThuoc, TongThanhToan, HinhThucTT) 
VALUES (@P2, DATEADD(HOUR, -1, GETDATE()), 5, 300000, 100000, 400000, N'Chuyển khoản');


-- --- KỊCH BẢN 3: VIÊM XOANG MÃN TÍNH (Đã xong) ---
-- Bệnh nhân: Đỗ Thị Mai
INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, CanNang, TrieuChung, ChanDoan, LoiDan, TrangThaiPhieu) 
VALUES ('2026-01-20', 6, 2, 50, 
        N'Đau đầu vùng trán, chảy mũi xanh, nghẹt mũi', 
        N'Đợt cấp Viêm xoang mạn', 
        N'Rửa mũi hàng ngày, tái khám nếu không đỡ', 2);
DECLARE @P3 INT = SCOPE_IDENTITY();

-- Dịch vụ
INSERT INTO CHITIETDICHVU (MaPhieu, MaDV, SoLuongDV, DonGiaDV, ThanhTienDV, KetQuaDV) VALUES 
(@P3, 1, 1, 200000, 200000, N'Khe giữa 2 bên nhiều mủ đặc'),
(@P3, 2, 1, 50000, 50000, N'Hút sạch dịch mũi');

-- Thuốc (Toa nặng đô)
INSERT INTO TOATHUOC (MaPhieu, MaThuoc, SoLuongThuoc, GiaBanThuoc, ThanhTienThuoc, CachDung) VALUES 
(@P3, 1, 14, 22000, 308000, N'Sáng 1 viên, chiều 1 viên (Sau ăn)'), -- Augmentin
(@P3, 4, 10, 5000, 50000, N'Sáng 1 viên (Sau ăn)'), -- Medrol
(@P3, 8, 10, 3000, 30000, N'Sáng 1 gói, chiều 1 gói'), -- Acemuc
(@P3, 10, 1, 90000, 90000, N'Xịt rửa mũi ngày 3 lần'); -- Sterimar

-- Hóa đơn
INSERT INTO HOADON (MaPhieu, NgayLapHD, MaNV, TongTienDV, TongTienThuoc, TongThanhToan, HinhThucTT) 
VALUES (@P3, '2026-01-20 10:00:00', 5, 250000, 478000, 728000, N'Tiền mặt');


-- --- KỊCH BẢN 4: VIÊM MŨI DỊ ỨNG (Chưa thanh toán - Trạng thái 1) ---
-- Bệnh nhân: Trần Thị Bích
INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, TrieuChung, ChanDoan, LoiDan, TrangThaiPhieu) 
VALUES (GETDATE(), 2, 2, 
        N'Hắt hơi liên tục, ngứa mũi, mắt đỏ', 
        N'Viêm mũi dị ứng thời tiết', 
        N'Tránh tiếp xúc phấn hoa, bụi', 1);
DECLARE @P4 INT = SCOPE_IDENTITY();

-- Dịch vụ
INSERT INTO CHITIETDICHVU (MaPhieu, MaDV, SoLuongDV, DonGiaDV, ThanhTienDV, KetQuaDV) VALUES 
(@P4, 1, 1, 200000, 200000, N'Niêm mạc mũi nhợt nhạt, cuốn mũi quá phát');

-- Thuốc
INSERT INTO TOATHUOC (MaPhieu, MaThuoc, SoLuongThuoc, GiaBanThuoc, ThanhTienThuoc, CachDung) VALUES 
(@P4, 6, 10, 8000, 80000, N'Tối uống 1 viên'), -- Telfast
(@P4, 9, 1, 55000, 55000, N'Xịt khi ngạt'); -- Otrivin


-- --- KỊCH BẢN 5: CHỜ KHÁM (Trạng thái 0) ---
-- Bệnh nhân: Võ Tấn Tài
INSERT INTO PHIEUKHAM (NgayKham, MaBN, MaNV, TrieuChung, TrangThaiPhieu) 
VALUES (GETDATE(), 7, 2, 
        N'Ù tai trái, nghe kém đột ngột', 0);

GO

-- Kiểm tra
SELECT * FROM NHANVIEN;
SELECT * FROM PHIEUKHAM;
SELECT * FROM HOADON;