--TẠO DATABASE QL_SanPham--
CREATE DATABASE QL_SanPham;

--SỬ DỤNG DATABASE--
USE QL_SanPham;

--TẠO BẢNG tblNhaSanXuat--
CREATE TABLE tblNhaSanXuat (
    MaNSX VARCHAR(50) PRIMARY KEY,
    TenNSX NVARCHAR(255)
);

--TẠO BẢNG tblLoai--
CREATE TABLE tblLoai (
    MaLoai VARCHAR(50) PRIMARY KEY,
    TenLoai NVARCHAR(255)
);

--TẠO BẢNG tblSanPham--
CREATE TABLE tblSanPham (
    MaSP VARCHAR(50) PRIMARY KEY,
    TenSP NVARCHAR(255),
    MaLoai VARCHAR(50),
    MaNSX VARCHAR(50),
    Gia DECIMAL(18, 2),
    GhiChu NVARCHAR(MAX),
    Hinh NVARCHAR(255),
	CONSTRAINT FK_SP_L FOREIGN KEY (MaLoai) REFERENCES tblLoai (MaLoai),
	CONSTRAINT FK_SP_NSX FOREIGN KEY (MaNSX) REFERENCES tblNhaSanXuat (MaNSX)
);

--TẠO BẢNG tblKhachHang-- 
CREATE TABLE tblKhachHang (
    MaKhachHang VARCHAR(50) PRIMARY KEY,
    TenKhachHang NVARCHAR(255),
    SoDienThoai VARCHAR(20),
    MatKhau VARCHAR(255)
);

--TẠO BẢNG tblHoaDon--
CREATE TABLE tblHoaDon (
    MaHoaDon VARCHAR(50) PRIMARY KEY,
    NgayTao DATETIME,
    MaKhachHang VARCHAR(50),
	CONSTRAINT FK_HD_KH FOREIGN KEY (MaKhachHang) REFERENCES tblKhachHang (MaKhachHang)
);

--TẠO BẢNG tblChiTiet--
CREATE TABLE tblChiTiet (
    MaHoaDon VARCHAR(50),
    MaSP VARCHAR(50),
    SoLuong INT,
    PRIMARY KEY (MaHoaDon, MaSP),
	CONSTRAINT FK_CT_HD FOREIGN KEY (MaHoaDon) REFERENCES tblHoaDon (MaHoaDon),
	CONSTRAINT FK_CT_SP FOREIGN KEY (MaSP) REFERENCES tblSanPham (MaSP)
);

--NHẬP LIỆU BẢNG tbtLoai--
INSERT INTO tblLoai (MaLoai, TenLoai) VALUES
('L01', N'Sách giáo khoa'),
('L02', N'Sách từ điển'),
('L03', N'Sách đại học'),
('L04', N'Truyện tranh');

SELECT*FROM tblLoai;

--NHẬP LIỆU BẢNG tblNhaSanXuat--
INSERT INTO tblNhaSanXuat (MaNSX, TenNSX) VALUES
('NSX01', N'NXB Giáo Dục'),
('NSX02', N'NXB Từ Điển Bách Khoa'),
('NSX03', N'NXB Đại Học Quốc Gia'),
('NSX04', N'NXB Kim Đồng');

SELECT*FROM tblNhaSanXuat;

--NHẬP LIỆU BẢNG tblSanPham--
INSERT INTO tblSanPham (MaSP, TenSP, MaLoai, MaNSX, Gia, GhiChu, Hinh) VALUES
('SP01', N'SGK Toán 12', 'L01', 'NSX01', 30000, N'Sách giáo khoa Toán 12, tái bản năm 2024, bám sát chương trình mới.', 'toan12.jpg'),
('SP02', N'SGK Ngữ văn 12', 'L01', 'NSX01', 28000, N'Sách giáo khoa Ngữ văn 12, cung cấp kiến thức văn học và kỹ năng viết.', 'nguvan12.jpg'),
('SP03', N'Từ điển 1000 từ', 'L02', 'NSX02', 56000, N'Từ điển cơ bản gồm 1000 từ thông dụng, dễ tra cứu.', 'td_1000tu.jpg'),
('SP04', N'Từ điển Anh - Anh', 'L02', 'NSX02', 120900, N'Từ điển Anh – Anh học thuật, giải thích chi tiết nghĩa và cách dùng.', 'td_anhanh.jpg'),
('SP05', N'Từ điển Hoa - Việt', 'L02', 'NSX02', 80000, N'Từ điển song ngữ Hoa – Việt, hỗ trợ học tập và giao tiếp.', 'td_hoaviet.jpg'),
('SP06', N'Từ điển Anh - Việt 500 từ', 'L02', 'NSX02', 45000, N'Phiên bản rút gọn, bao gồm 500 từ Anh – Việt cơ bản.', 'td_anhviet500.jpg'),
('SP07', N'Từ điển Việt - Anh', 'L02', 'NSX02', 60000, N'Từ điển Việt – Anh dành cho học sinh, dễ tra cứu.', 'td_vietanh.jpg'),
('SP08', N'Giáo trình Lập trình C', 'L03', 'NSX03', 95000, N'Giáo trình lập trình C, dành cho sinh viên ngành CNTT.', 'ltc.jpg'),
('SP09', N'Giáo trình Cấu trúc dữ liệu', 'L03', 'NSX03', 120000, N'Tài liệu về cấu trúc dữ liệu cơ bản, môn học nền tảng CNTT.', 'ctdl.jpg'),
('SP10', N'Doraemon tập 1', 'L04', 'NSX04', 18000, N'Truyện tranh Doraemon tập 1, nội dung vui nhộn, hấp dẫn thiếu nhi.', 'doraemon1.jpg'),
('SP11', N'Detective Conan tập 1', 'L04', 'NSX04', 20000, N'Truyện tranh Conan tập 1, mở đầu câu chuyện trinh thám nổi tiếng.', 'conan1.jpg');

SELECT*FROM tblSanPham;

--NHẬP LIỆU BẢNG tblKhachHang--
INSERT INTO tblKhachHang (MaKhachHang, TenKhachHang, SoDienThoai, MatKhau) VALUES
('KH01', N'Nguyễn Văn Trỗi', '0909123456', '123456'),
('KH02', N'Trần Thị Mơ', '0912345678', 'abcdef'),
('KH03', N'Lê Văn Sĩ', '0987654321', 'qwerty');

SELECT*FROM tblKhachHang;

--NHẬP LIỆU BẢNG tblHoaDon--
INSERT INTO tblHoaDon (MaHoaDon, NgayTao, MaKhachHang) VALUES
('HD01', '2025-09-01', 'KH01'),
('HD02', '2025-09-05', 'KH02'),
('HD03', '2025-09-10', 'KH01'),
('HD04', '2025-09-15', 'KH03');

SELECT*FROM tblHoaDon;

--NHẬP LIỆU BẢNG tblChiTiet--
INSERT INTO tblChiTiet (MaHoaDon, MaSP, SoLuong) VALUES
('HD01', 'SP01', 1),
('HD01', 'SP03', 1),
('HD01', 'SP07', 2),
('HD02', 'SP06', 1),
('HD03', 'SP02', 1),
('HD03', 'SP08', 1),
('HD04', 'SP05', 1),
('HD04', 'SP09', 1);

SELECT*FROM tblChiTiet;