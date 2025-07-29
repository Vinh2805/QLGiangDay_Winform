
CREATE TABLE SinhVien (
    SinhVienID nvarchar(10) PRIMARY KEY not null,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh BIT,  -- 1: Nam, 0: N?
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE GiangVien (
    GiangVienID nvarchar(10) PRIMARY KEY not null,
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE MonHoc (
    MonHocID nvarchar(10) PRIMARY KEY not null,
    TenMonHoc NVARCHAR(100) NOT NULL,
    SoTinChi INT,
    HocKy NVARCHAR(20),
	HocPhi float
	
);


CREATE TABLE LopHoc (
    LopHocID nvarchar(10) PRIMARY KEY not null,
    TenLop NVARCHAR(100) NOT NULL,
    NamHoc NVARCHAR(20),
    KiHoc NVARCHAR(20)
);
CREATE TABLE TaiKhoan (
    TaiKhoanID nvarchar(10) not null,
	TenDangNhap nvarchar(255) not null,
	MatKhau nvarchar(255) not null
);

INSERT INTO TaiKhoan(TaiKhoanId,TenDangNhap,MatKhau)
VALUES 
('0','Admin','admin123'),
('0','Admin1','admin123'),
('0','Admin2','admin123'),
('0','Admin3','admin123'),
('1','Son','Son123'),
('1','Manh','Manh123'),
('1','Anh','Anh123'),
('1','Vinh','Vinh123');

CREATE TABLE ThongBao (
    ThongBaoID nvarchar(10) PRIMARY KEY not null,
    TieuDe NVARCHAR(100),
    NoiDung NVARCHAR(MAX),
    NgayGui DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('Moi', 'DaXem', 'Huy')),
);

CREATE TABLE ThongBao_NguoiNhan (
    ThongBaoID nvarchar(10) FOREIGN KEY REFERENCES ThongBao(ThongBaoID),
    NguoiNhanID nvarchar(10),  -- Có th? là SinhVienID ho?c GiangVienID
    LoaiNguoiNhan NVARCHAR(20) CHECK (LoaiNguoiNhan IN ('SinhVien', 'GiangVien')), -- Xác d?nh lo?i ngu?i nh?n
    PRIMARY KEY (ThongBaoID, NguoiNhanID, LoaiNguoiNhan)  -- Khóa chính là s? k?t h?p c?a ba tru?ng
);

CREATE TABLE SinhVien_LopHoc (
    SinhVienID nvarchar(10) FOREIGN KEY REFERENCES SinhVien(SinhVienID),
    LopHocID nvarchar(10) FOREIGN KEY REFERENCES LopHoc(LopHocID),
    PRIMARY KEY (SinhVienID, LopHocID)  -- Khóa chính là s? k?t h?p c?a hai tru?ng
);

CREATE TABLE GiangVien_MonHoc (
    GiangVienID nvarchar(10) FOREIGN KEY REFERENCES GiangVien(GiangVienID),
    MonHocID nvarchar(10) FOREIGN KEY REFERENCES MonHoc(MonHocID),
    PRIMARY KEY (GiangVienID, MonHocID)  -- Khóa chính là s? k?t h?p c?a hai tru?ng
);

CREATE TABLE SinhVien_MonHoc (
    SinhVienID nvarchar(10) FOREIGN KEY REFERENCES SinhVien(SinhVienID),
    MonHocID nvarchar(10) FOREIGN KEY REFERENCES MonHoc(MonHocID),
    PRIMARY KEY (SinhVienID, MonHocID)  -- Khóa chính là s? k?t h?p c?a hai tru?ng
);
INSERT INTO SinhVien (SinhVienID, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email)
VALUES 
('SV01', 'Nguyễn Văn A', '2000-01-15', 1, 'Hà Nội', '0123456789', 'vana@example.com'),
('SV02', 'Trần Thị B', '2001-02-20', 0, 'Hà Nội', '0987654321', 'thib@example.com'),
('SV03', 'Lê Văn C', '1999-03-25', 1, 'Hồ Chí Minh', '0123456788', 'vanc@example.com'),
('SV04', 'Nguyễn Thị D', '2000-04-30', 0, 'Đà Nẵng', '0123456787', 'thid@example.com'),
('SV05', 'Phạm Minh E', '2001-05-05', 1, 'Cần Thơ', '0123456786', 'mine@example.com'),
('SV06', 'Trần Văn F', '2002-06-15', 1, 'Hà Nội', '0123456785', 'vanf@example.com'),
('SV07', 'Lê Thị G', '2001-07-20', 0, 'Hồ Chí Minh', '0123456784', 'thig@example.com'),
('SV08', 'Nguyễn Văn H', '1999-08-10', 1, 'Đà Nẵng', '0123456783', 'vanh@example.com'),
('SV09', 'Trần Thị I', '2000-09-25', 0, 'Hà Nội', '0123456782', 'thii@example.com'),
('SV10', 'Lê Văn J', '2001-10-05', 1, 'Cần Thơ', '0123456781', 'vanj@example.com'),
('SV11', 'Nguyễn Văn K', '1998-11-12', 1, 'Hà Nội', '0123456780', 'vank@example.com'),
('SV12', 'Trần Thị L', '2002-12-15', 0, 'Hồ Chí Minh', '0123456790', 'thil@example.com'),
('SV13', 'Lê Văn M', '2000-01-18', 1, 'Đà Nẵng', '0123456701', 'vanm@example.com'),
('SV14', 'Nguyễn Thị N', '2003-02-22', 0, 'Cần Thơ', '0123456702', 'thin@example.com'),
('SV15', 'Phạm Minh O', '2001-03-30', 1, 'Hà Nội', '0123456703', 'mino@example.com');

INSERT INTO GiangVien (GiangVienID, HoTen, ChucVu, DiaChi, SoDienThoai, Email)
VALUES 
('GV01', 'Phạm Minh D', 'Giảng viên', 'Đà Nẵng', '0123456781', 'mind@example.com'),
('GV02', 'Nguyễn Thị E', 'Giảng viên', 'Hà Nội', '0987654312', 'thie@example.com'),
('GV03', 'Lê Văn F', 'Giảng viên', 'Hồ Chí Minh', '0123456782', 'vanf@example.com'),
('GV04', 'Trần Văn G', 'Giảng viên', 'Hà Nội', '0123456783', 'vang@example.com'),
('GV05', 'Nguyễn Văn H', 'Giảng viên', 'Đà Nẵng', '0123456784', 'vanh@example.com'),
('GV06', 'Phạm Thị I', 'Giảng viên', 'Cần Thơ', '0123456785', 'thiI@example.com'),
('GV07', 'Lê Minh J', 'Giảng viên', 'Hồ Chí Minh', '0123456786', 'minj@example.com');

INSERT INTO MonHoc (MonHocID, TenMonHoc, SoTinChi, HocKy, HocPhi)
VALUES 
('MH01', 'Lập trình C#', 3, 'Học kỳ 1', 500000),
('MH02', 'Cơ sở dữ liệu', 3, 'Học kỳ 1', 600000),
('MH03', 'Thiết kế web', 2, 'Học kỳ 2', 400000),
('MH04', 'Mạng máy tính', 3, 'Học kỳ 1', 550000),
('MH05', 'Hệ điều hành', 3, 'Học kỳ 2', 650000),
('MH06', 'Phân tích thiết kế hệ thống', 2, 'Học kỳ 2', 300000),
('MH07', 'Di động và ứng dụng', 3, 'Học kỳ 3', 700000);

INSERT INTO LopHoc (LopHocID, TenLop, NamHoc, KiHoc)
VALUES 
('LH01', 'Lớp 12A1', '2024-2025', 'Học kỳ 1'),
('LH02', 'Lớp 12A2', '2024-2025', 'Học kỳ 1'),
('LH03', 'Lớp 12B1', '2024-2025', 'Học kỳ 1'),
('LH04', 'Lớp 12C1', '2024-2025', 'Học kỳ 1'),
('LH05', 'Lớp 12D1', '2024-2025', 'Học kỳ 1'),
('LH06', 'Lớp 12E1', '2024-2025', 'Học kỳ 1'),
('LH07', 'Lớp 12F1', '2024-2025', 'Học kỳ 1');

INSERT INTO ThongBao (ThongBaoID, TieuDe, NoiDung, NgayGui, TrangThai)
VALUES 
('TB01', 'Thông báo họp lớp', 'Họp lớp vào lúc 7 giờ tối thứ Bảy.', DEFAULT, 'Moi'),
('TB02', 'Lịch thi cuối kỳ', 'Thông báo lịch thi cuối kỳ môn Lập trình C#.', DEFAULT, 'Moi'),
('TB03', 'Thông báo học phí', 'Học phí kỳ này cần nộp trước ngày 30.', DEFAULT, 'Moi'),
('TB04', 'Giải bóng đá sinh viên', 'Tổ chức giải bóng đá vào cuối tháng.', DEFAULT, 'Moi'),
('TB05', 'Khai giảng học kỳ mới', 'Khai giảng vào 5/9.', DEFAULT, 'Moi'),
('TB06', 'Thay đổi giảng viên', 'Giảng viên môn Cơ sở dữ liệu đã thay đổi.', DEFAULT, 'Moi'),
('TB07', 'Nhắc nhở lịch học', 'Các bạn nhớ kiểm tra lịch học hàng tuần.', DEFAULT, 'Moi');

INSERT INTO ThongBao_NguoiNhan (ThongBaoID, NguoiNhanID, LoaiNguoiNhan)
VALUES 
('TB01', 'SV01', 'SinhVien'),  -- Thông báo 1 gửi cho sinh viên 1
('TB02', 'SV02', 'SinhVien'),  -- Thông báo 2 gửi cho sinh viên 2
('TB03', 'SV03', 'SinhVien'),  -- Thông báo 3 gửi cho sinh viên 3
('TB04', 'SV04', 'SinhVien'),  -- Thông báo 4 gửi cho sinh viên 4
('TB05', 'SV05', 'SinhVien'),  -- Thông báo 5 gửi cho sinh viên 5
('TB06', 'GV06', 'GiangVien'),  -- Thông báo 6 gửi cho giảng viên 6
('TB07', 'GV01', 'GiangVien');  -- Thông báo 7 gửi cho giảng viên 1

INSERT INTO SinhVien_LopHoc (SinhVienID, LopHocID)
VALUES 
('SV01', 'LH01'),  -- Sinh viên 1 tham gia lớp 1
('SV01', 'LH02'),  -- Sinh viên 1 tham gia lớp 2
('SV02', 'LH01'),  -- Sinh viên 2 tham gia lớp 1
('SV02', 'LH03'),  -- Sinh viên 2 tham gia lớp 3
('SV03', 'LH02'),  -- Sinh viên 3 tham gia lớp 2
('SV04', 'LH01'),  -- Sinh viên 4 tham gia lớp 1
('SV05', 'LH02'),  -- Sinh viên 5 tham gia lớp 2
('SV06', 'LH03'),  -- Sinh viên 6 tham gia lớp 3
('SV07', 'LH01'),  -- Sinh viên 7 tham gia lớp 1
('SV08', 'LH02'),  -- Sinh viên 8 tham gia lớp 2
('SV09', 'LH03'),  -- Sinh viên 9 tham gia lớp 3
('SV10', 'LH01'),  -- Sinh viên 10 tham gia lớp 1
('SV11', 'LH02'),  -- Sinh viên 11 tham gia lớp 2
('SV12', 'LH03'),  -- Sinh viên 12 tham gia lớp 3
('SV13', 'LH01'),  -- Sinh viên 13 tham gia lớp 1
('SV14', 'LH02'),  -- Sinh viên 14 tham gia lớp 2
('SV15', 'LH03');  -- Sinh viên 15 tham gia lớp 3

INSERT INTO GiangVien_MonHoc (GiangVienID, MonHocID)
VALUES 
('GV01', 'MH01'),  -- Giảng viên 1 dạy môn 1
('GV01', 'MH02'),  -- Giảng viên 1 dạy môn 2
('GV02', 'MH02'),  -- Giảng viên 2 dạy môn 2
('GV02', 'MH03'),  -- Giảng viên 2 dạy môn 3
('GV03', 'MH03'),  -- Giảng viên 3 dạy môn 3
('GV04', 'MH04'),  -- Giảng viên 4 dạy môn 4
('GV05', 'MH05'),  -- Giảng viên 5 dạy môn 5
('GV06', 'MH06'),  -- Giảng viên 6 dạy môn 6
('GV07', 'MH07');  -- Giảng viên 7 dạy môn 7

INSERT INTO SinhVien_MonHoc (SinhVienID, MonHocID)
VALUES 
('SV01', 'MH01'),  -- Sinh viên 1 học môn 1
('SV01', 'MH02'),  -- Sinh viên 1 học môn 2
('SV02', 'MH02'),  -- Sinh viên 2 học môn 2
('SV02', 'MH03'),  -- Sinh viên 2 học môn 3
('SV03', 'MH03'),  -- Sinh viên 3 học môn 3
('SV03', 'MH01'),  -- Sinh viên 3 học môn 1
('SV04', 'MH01'),  -- Sinh viên 4 học môn 1
('SV05', 'MH02'),  -- Sinh viên 5 học môn 2
('SV06', 'MH03'),  -- Sinh viên 6 học môn 3
('SV07', 'MH04'),  -- Sinh viên 7 học môn 4
('SV08', 'MH05'),  -- Sinh viên 8 học môn 5
('SV09', 'MH06'),  -- Sinh viên 9 học môn 6
('SV10', 'MH07'),  -- Sinh viên 10 học môn 7
('SV11', 'MH01'),  -- Sinh viên 11 học môn 1
('SV12', 'MH02'),  -- Sinh viên 12 học môn 2
('SV13', 'MH03'),  -- Sinh viên 13 học môn 3
('SV14', 'MH04'),  -- Sinh viên 14 học môn 4
('SV15', 'MH05');  -- Sinh viên 15 học môn 5
