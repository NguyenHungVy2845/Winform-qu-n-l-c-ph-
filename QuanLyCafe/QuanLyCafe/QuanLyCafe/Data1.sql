--           SCRIPT DATABASE QUANLYCAFE HOÀN CHỈNH         --
-- (Tổng hợp từ File Mới và File Cũ, đã sửa lỗi & bổ sung) --

-- 1. TẠO DATABASE (Nếu chưa có)
IF DB_ID(N'QuanLyCafe') IS NULL
CREATE DATABASE QuanLyCafe;
GO
USE QuanLyCafe;
GO

-- 2. HỦY BỎ CÁC ĐỐI TƯỢNG CŨ (Đúng thứ tự)
-- Hủy View
IF OBJECT_ID('dbo.v_DoanhThuTheoNgay','V') IS NOT NULL DROP VIEW dbo.v_DoanhThuTheoNgay;
IF OBJECT_ID('dbo.v_TopMonBanChay','V')    IS NOT NULL DROP VIEW dbo.v_TopMonBanChay;
GO

-- Hủy Bảng (Từ con -> cha để không lỗi khóa ngoại)
IF OBJECT_ID('dbo.ChiTietHoaDon','U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID('dbo.HoaDon','U')         IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID('dbo.Mon','U')            IS NOT NULL DROP TABLE dbo.Mon;
IF OBJECT_ID('dbo.LoaiMon','U')        IS NOT NULL DROP TABLE dbo.LoaiMon;
IF OBJECT_ID('dbo.Ban','U')            IS NOT NULL DROP TABLE dbo.Ban;
IF OBJECT_ID('dbo.KhuyenMai','U')      IS NOT NULL DROP TABLE dbo.KhuyenMai;
IF OBJECT_ID('dbo.NhanVien','U')       IS NOT NULL DROP TABLE dbo.NhanVien;
IF OBJECT_ID('dbo.ChamCong','U')       IS NOT NULL DROP TABLE dbo.ChamCong;
IF OBJECT_ID('dbo.NgayNghi','U')       IS NOT NULL DROP TABLE dbo.NgayNghi;
IF OBJECT_ID('dbo.TaiKhoan','U')       IS NOT NULL DROP TABLE dbo.TaiKhoan;
GO

-- 3. TẠO CÁC BẢNG (Từ cha -> con)

-- Bảng TAI KHOAN (Cha)
CREATE TABLE dbo.TaiKhoan
(
TenDangNhap   NVARCHAR(100) PRIMARY KEY,
TenHienThi    NVARCHAR(100) NOT NULL DEFAULT N'Nguoi dung',
MatKhauMaHoa  NVARCHAR(200) NOT NULL,
LoaiTaiKhoan  TINYINT NOT NULL CONSTRAINT CK_TaiKhoan_Loai CHECK (LoaiTaiKhoan IN (0,1)), -- 0=NV, 1=Admin
DangHoatDong  BIT NOT NULL CONSTRAINT DF_TaiKhoan_HoatDong DEFAULT (1),
NgayTao       DATETIME2(0) NOT NULL CONSTRAINT DF_TaiKhoan_NgayTao DEFAULT (SYSDATETIME())
);
GO

-- Bảng LOAI MON (Cha)
CREATE TABLE dbo.LoaiMon
(
Id          INT IDENTITY(1,1) PRIMARY KEY,
TenLoai     NVARCHAR(100) NOT NULL CONSTRAINT UQ_LoaiMon_Ten UNIQUE,
DangSuDung  BIT NOT NULL CONSTRAINT DF_LoaiMon_DangSuDung DEFAULT (1)
);
GO

-- Bảng BAN (Cha)
CREATE TABLE dbo.Ban
(
Id        INT IDENTITY(1,1) PRIMARY KEY,
TenBan    NVARCHAR(100) NOT NULL CONSTRAINT UQ_Ban_Ten UNIQUE,
TrangThai TINYINT NOT NULL CONSTRAINT DF_Ban_TrangThai DEFAULT (0) CONSTRAINT CK_Ban_TrangThai CHECK (TrangThai IN (0,1,2)), -- 0=Trống, 1=Có người, 2=Khóa
GhiChu    NVARCHAR(200) NULL
);
GO
CREATE INDEX IX_Ban_TrangThai ON dbo.Ban(TrangThai);
GO

-- Bảng KHUYEN MAI (Cha)
CREATE TABLE dbo.KhuyenMai
(
Id          INT IDENTITY(1,1) PRIMARY KEY,
Ma          VARCHAR(20) NOT NULL CONSTRAINT UQ_KM_Ma UNIQUE,
Kieu        TINYINT NOT NULL CONSTRAINT CK_KM_Kieu CHECK (Kieu IN (0,1)), -- 0=%, 1=Tiền
GiaTri      DECIMAL(12,2) NOT NULL CONSTRAINT CK_KM_GiaTri CHECK (GiaTri >= 0),
NgayBatDau  DATETIME2(0) NOT NULL,
NgayKetThuc DATETIME2(0) NOT NULL,
DangSuDung  BIT NOT NULL CONSTRAINT DF_KM_DangSuDung DEFAULT (1)
);
GO

-- Bảng MON (Con của LoaiMon)
CREATE TABLE dbo.Mon
(
Id          INT IDENTITY(1,1) PRIMARY KEY,
TenMon      NVARCHAR(100) NOT NULL,
IdLoaiMon   INT NOT NULL CONSTRAINT FK_Mon_LoaiMon FOREIGN KEY REFERENCES dbo.LoaiMon(Id),
GiaTien     DECIMAL(12,2) NOT NULL CONSTRAINT CK_Mon_GiaTien CHECK (GiaTien >= 0),
DangSuDung  BIT NOT NULL CONSTRAINT DF_Mon_DangSuDung DEFAULT (1),
CONSTRAINT UQ_Mon_Ten_TheoLoai UNIQUE (TenMon, IdLoaiMon)
);
GO
CREATE INDEX IX_Mon_LoaiMon ON dbo.Mon(IdLoaiMon);
GO

-- Bảng NHAN VIEN (Con của TaiKhoan)
CREATE TABLE dbo.NhanVien
(
Id                  INT IDENTITY(1,1) PRIMARY KEY,
HoTen               NVARCHAR(100) NOT NULL,
SoDienThoai         VARCHAR(15) NULL UNIQUE,
TenDangNhapTaiKhoan NVARCHAR(100) NULL,
CaLam               NVARCHAR(20)  NULL,
DangHoatDong        BIT NOT NULL CONSTRAINT DF_NhanVien_HoatDong DEFAULT (1),
CONSTRAINT FK_NhanVien_TaiKhoan
FOREIGN KEY (TenDangNhapTaiKhoan) REFERENCES dbo.TaiKhoan(TenDangNhap)
ON DELETE SET NULL ON UPDATE CASCADE -- Sửa TenDangNhap thì tự động cập nhật
);
GO

-- Bảng HOA DON (Con của Ban, TaiKhoan, KhuyenMai)
CREATE TABLE dbo.HoaDon
(
Id           INT IDENTITY(1,1) PRIMARY KEY,
ThoiGianVao  DATETIME2(0) NOT NULL CONSTRAINT DF_HoaDon_Vao DEFAULT (SYSDATETIME()),
ThoiGianRa   DATETIME2(0) NULL,
IdBan        INT NOT NULL CONSTRAINT FK_HoaDon_Ban FOREIGN KEY REFERENCES dbo.Ban(Id),
TrangThai    TINYINT NOT NULL CONSTRAINT DF_HoaDon_TrangThai DEFAULT (0) CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThai IN (0,1)),
NguoiChot    NVARCHAR(100) NULL CONSTRAINT FK_HoaDon_NguoiChot FOREIGN KEY REFERENCES dbo.TaiKhoan(TenDangNhap),
IdKhuyenMai  INT NULL CONSTRAINT FK_HoaDon_KhuyenMai FOREIGN KEY REFERENCES dbo.KhuyenMai(Id),
TienGiamGia  DECIMAL(12,2) NOT NULL CONSTRAINT DF_HoaDon_GiamGia DEFAULT (0) CONSTRAINT CK_HoaDon_GiamGia CHECK (TienGiamGia >= 0),
CONSTRAINT CK_HoaDon_ThoiGian CHECK (ThoiGianRa IS NULL OR ThoiGianRa >= ThoiGianVao)
);
GO
CREATE INDEX IX_HoaDon_Ban_TrangThai ON dbo.HoaDon(IdBan, TrangThai);
CREATE INDEX IX_HoaDon_ThoiGianRa    ON dbo.HoaDon(ThoiGianRa);
GO

-- Bảng CHI TIET HOA DON (Con của HoaDon, Mon)
CREATE TABLE dbo.ChiTietHoaDon
(
Id                  INT IDENTITY(1,1) PRIMARY KEY,
IdHoaDon            INT NOT NULL CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY REFERENCES dbo.HoaDon(Id) ON DELETE CASCADE, -- Xóa Hóa đơn thì xóa chi tiết
IdMon               INT NOT NULL CONSTRAINT FK_CTHD_Mon FOREIGN KEY REFERENCES dbo.Mon(Id),
SoLuong             INT NOT NULL CONSTRAINT CK_CTHD_SoLuong CHECK (SoLuong > 0),
DonGiaTaiThoiDiem   DECIMAL(12,2) NOT NULL CONSTRAINT CK_CTHD_DonGia CHECK (DonGiaTaiThoiDiem >= 0),
CONSTRAINT UQ_CTHD_HoaDon_Mon UNIQUE (IdHoaDon, IdMon)
);
GO
CREATE INDEX IX_CTHD_HoaDon ON dbo.ChiTietHoaDon(IdHoaDon);
CREATE INDEX IX_CTHD_Mon    ON dbo.ChiTietHoaDon(IdMon);
GO

-- Bảng CHẤM CÔNG (Con của TaiKhoan)
CREATE TABLE dbo.ChamCong
(
Id INT IDENTITY(1,1) PRIMARY KEY,
TenDangNhap NVARCHAR(100) NOT NULL,
ThoiGianVao DATETIME2(0) NOT NULL CONSTRAINT DF_ChamCong_Vao DEFAULT (SYSDATETIME()),
ThoiGianRa DATETIME2(0) NULL,
CONSTRAINT FK_ChamCong_TaiKhoan -- Bổ sung khóa ngoại còn thiếu
FOREIGN KEY (TenDangNhap) REFERENCES dbo.TaiKhoan(TenDangNhap)
ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- Bảng NGÀY NGHỈ (Con của TaiKhoan)
CREATE TABLE dbo.NgayNghi
(
Id INT IDENTITY(1,1) PRIMARY KEY,
TenDangNhap NVARCHAR(100) NOT NULL,
NgayNghi DATE NOT NULL,
LyDo NVARCHAR(200) NULL,
CONSTRAINT FK_NgayNghi_TaiKhoan -- Bổ sung khóa ngoại
FOREIGN KEY (TenDangNhap) REFERENCES dbo.TaiKhoan(TenDangNhap)
ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- 4. TẠO CÁC VIEW

-- View Doanh thu
CREATE VIEW dbo.v_DoanhThuTheoNgay
AS
WITH TongTheoHoaDon AS (
SELECT
hd.Id,
CAST(hd.ThoiGianRa AS DATE) AS Ngay,
SUM(ct.SoLuong * ct.DonGiaTaiThoiDiem) AS TienHang,
MAX(hd.TienGiamGia) AS GiamGia
FROM dbo.HoaDon hd
JOIN dbo.ChiTietHoaDon ct ON ct.IdHoaDon = hd.Id
WHERE hd.TrangThai = 1 AND hd.ThoiGianRa IS NOT NULL
GROUP BY hd.Id, CAST(hd.ThoiGianRa AS DATE)
)
SELECT
Ngay,
SUM(TienHang - GiamGia) AS DoanhThu
FROM TongTheoHoaDon
GROUP BY Ngay;
GO

-- View Top món bán chạy
CREATE VIEW dbo.v_TopMonBanChay
AS
SELECT
ct.IdMon,
m.TenMon,
SUM(ct.SoLuong) AS TongSoLuong
FROM dbo.HoaDon hd
JOIN dbo.ChiTietHoaDon ct ON ct.IdHoaDon = hd.Id
JOIN dbo.Mon m ON m.Id = ct.IdMon
WHERE hd.TrangThai = 1
GROUP BY ct.IdMon, m.TenMon;
GO

-- 5. THÊM DỮ LIỆU MẪU (Bắt buộc để App chạy)

-- Tạo tài khoản Admin (pass: 123456)
INSERT INTO dbo.TaiKhoan (TenDangNhap, TenHienThi, MatKhauMaHoa, LoaiTaiKhoan, DangHoatDong)
VALUES (
N'admin',
N'Quản trị',
-- Mật khẩu '123456' được hash bằng SHA256 (cho C#)
N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
1,
1
);

-- Tạo tài khoản Nhân viên (pass: 123456)
INSERT INTO dbo.TaiKhoan (TenDangNhap, TenHienThi, MatKhauMaHoa, LoaiTaiKhoan, DangHoatDong)
VALUES (
N'staff',
N'Nhân viên',
-- Mật khẩu '123456' được hash bằng SHA256 (cho C#)
N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
0,
1
);
GO

-- Thêm Bàn (Để hiện các ô vuông)
INSERT INTO Ban (TenBan, TrangThai) VALUES
(N'Bàn 1', 0), (N'Bàn 2', 0), (N'Bàn 3', 0),
(N'Bàn 4', 0), (N'Bàn 5', 0), (N'Bàn 6', 0),
(N'Bàn 7', 0), (N'Bàn 8', 0), (N'Bàn 9', 0), (N'Bàn 10', 0);
GO

-- 1. Đảm bảo có 3 danh mục chuẩn
IF NOT EXISTS (SELECT * FROM LoaiMon WHERE TenLoai = N'Thức ăn')
    INSERT INTO LoaiMon(TenLoai, DangSuDung) VALUES (N'Thức ăn', 1);

IF NOT EXISTS (SELECT * FROM LoaiMon WHERE TenLoai = N'Đồ uống')
    INSERT INTO LoaiMon(TenLoai, DangSuDung) VALUES (N'Đồ uống', 1);

IF NOT EXISTS (SELECT * FROM LoaiMon WHERE TenLoai = N'Combo')
    INSERT INTO LoaiMon(TenLoai, DangSuDung) VALUES (N'Combo', 1);
GO

-- 2. (Tùy chọn) Chuyển các món cũ về đúng loại
-- Ví dụ: Chuyển "Cà Phê", "Trà Sữa" về "Đồ uống"
UPDATE Mon 
SET IdLoaiMon = (SELECT Id FROM LoaiMon WHERE TenLoai = N'Đồ uống')
WHERE IdLoaiMon IN (SELECT Id FROM LoaiMon WHERE TenLoai IN (N'Cà Phê', N'Trà Sữa', N'Sinh Tố'));

-- Chuyển "Ăn vặt" về "Thức ăn"
UPDATE Mon 
SET IdLoaiMon = (SELECT Id FROM LoaiMon WHERE TenLoai = N'Thức ăn')
WHERE IdLoaiMon IN (SELECT Id FROM LoaiMon WHERE TenLoai = N'Ăn Vặt');

-- 1. Thêm cột Số Lượng Tồn và Giá Nhập vào bảng Mon
-- Mặc định tồn kho = 10 như bạn yêu cầu, Giá nhập = 0
ALTER TABLE dbo.Mon ADD SoLuongTon INT NOT NULL DEFAULT 10;
ALTER TABLE dbo.Mon ADD GiaNhap DECIMAL(12,2) NOT NULL DEFAULT 0;
GO

-- 2. Tạo bảng LỊCH SỬ NHẬP HÀNG (Để lưu chi phí phục vụ báo cáo Lợi nhuận)
CREATE TABLE dbo.LichSuNhapHang
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdMon INT NOT NULL,
    SoLuongNhap INT NOT NULL,
    DonGiaNhap DECIMAL(12,2) NOT NULL, -- Giá tại thời điểm nhập
    TongTien AS (SoLuongNhap * DonGiaNhap), -- Cột tự tính
    NgayNhap DATETIME2(0) DEFAULT SYSDATETIME(),
    CONSTRAINT FK_NhapHang_Mon FOREIGN KEY (IdMon) REFERENCES dbo.Mon(Id)
);
GO