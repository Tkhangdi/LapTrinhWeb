
---- 1. Vô hiệu hóa tất cả các ràng buộc khóa ngoại
--EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL"
--GO
---- 2. Xóa dữ liệu trong tất cả các bảng
--EXEC sp_msforeachtable "DELETE FROM ?"
--GO
---- 3. Bật lại tất cả các ràng buộc khóa ngoại
--EXEC sp_msforeachtable "ALTER TABLE ? CHECK CONSTRAINT ALL"
--GO


USE [QL_ShopQuanAo]
GO



INSERT [dbo].[UserAccount] ([TenDangNhap], [MatKhau], [ChucVu]) VALUES (N'NV001', N'pass1', N'Nhân viên')
INSERT [dbo].[UserAccount] ([TenDangNhap], [MatKhau], [ChucVu]) VALUES (N'nv01', N'password6', N'Nhân viên')
INSERT [dbo].[UserAccount] ([TenDangNhap], [MatKhau], [ChucVu]) VALUES (N'nv02', N'password7', N'Nhân viên')
INSERT [dbo].[UserAccount] ([TenDangNhap], [MatKhau], [ChucVu]) VALUES (N'user01', N'password1', N'Khách hàng')
INSERT [dbo].[UserAccount] ([TenDangNhap], [MatKhau], [ChucVu]) VALUES (N'user02', N'password2', N'Khách hàng')
GO
INSERT [dbo].[KhachHang] ([TenDangNhap], [Ho], [Ten], [GioiTinh], [Email], [DienThoai], [DiaChi], [ThanhPho], [Tinh], [MaZip], [ChucVu]) VALUES (N'user01', N'Nguyễn Văn', N'A', N'Nam', N'a@gmail.com', N'0123456789', N'123 Đường A', N'Hà Nội', N'Hà Nội', N'100000', N'Khách hàng')
INSERT [dbo].[KhachHang] ([TenDangNhap], [Ho], [Ten], [GioiTinh], [Email], [DienThoai], [DiaChi], [ThanhPho], [Tinh], [MaZip], [ChucVu]) VALUES (N'user02', N'Trần Thị', N'B', N'Nữ', N'b@gmail.com', N'0123456790', N'456 Đường B', N'Hồ Chí Minh', N'Hồ Chí Minh', N'700000', N'Khách hàng')
GO
INSERT [dbo].[NhanVien] ([TenDangNhap], [Ho], [Ten], [GioiTinh], [Email], [DienThoai], [ChucVu]) VALUES (N'NV001', N'Nguyễn Văn', N'A', N'Nam', N'nva@gmail.com', N'0123456700', N'Nhân viên')
INSERT [dbo].[NhanVien] ([TenDangNhap], [Ho], [Ten], [GioiTinh], [Email], [DienThoai], [ChucVu]) VALUES (N'nv01', N'Nguyễn Văn', N'K', N'Nam', N'nvk@gmail.com', N'0123456799', N'Nhân viên')
INSERT [dbo].[NhanVien] ([TenDangNhap], [Ho], [Ten], [GioiTinh], [Email], [DienThoai], [ChucVu]) VALUES (N'nv02', N'Nguyễn Thị', N'L', N'Nữ', N'nvl@gmail.com', N'0123456800', N'Nhân viên')
GO

INSERT INTO [dbo].[Size] (MaSize, MoTaSize)
VALUES ('S', N'Kích thước nhỏ');
INSERT INTO [dbo].[Size] (MaSize, MoTaSize)
VALUES ('M', N'Kích thước trung bình');
INSERT INTO [dbo].[Size] (MaSize, MoTaSize)
VALUES ('L', N'Kích thước lớn');
INSERT INTO [dbo].[Size] (MaSize, MoTaSize)
VALUES ('XL', N'Kích thước rất lớn');
GO

INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH01', N'Nike')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH02', N'Adidas')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH04', N'H&M')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH06', N'Puma')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH07', N'Levi’s')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'DM01', N'Áo')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'DM02', N'Quần')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'DM07', N'Áo khoác')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'DM10', N'Đồ thể thao')
GO




-- Thêm sản phẩm cho danh mục Áo
INSERT INTO [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GioiTinh], [MaDanhMuc], [MaThuongHieu], [Gia], [MoTa], [Anh])
VALUES
('SP01', N'Áo Nike Thể Thao', N'Nam', 'DM01', 'TH01', 250000, N'Áo thể thao chất lượng cao', '9.jpg'),
('SP02', N'Áo Adidas Dáng Dài', N'Nữ', 'DM01', 'TH02', 350000, N'Áo dáng dài thoải mái', '21.jpg'),
('SP03', N'Áo H&M Basic', N'Nam', 'DM01', 'TH04', 200000, N'Áo basic phù hợp nhiều phong cách', '10.jpg'),
('SP04', N'Áo Puma Casual', N'Nữ', 'DM01', 'TH06', 300000, N'Áo casual thời thượng', '6.jpg'),
('SP05', N'Áo Levi’s Classic', N'Nam', 'DM01', 'TH07', 400000, N'Áo classic sang trọng', '17.jpg');
GO
-- Thêm sản phẩm cho danh mục Quần
INSERT INTO [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GioiTinh], [MaDanhMuc], [MaThuongHieu], [Gia], [MoTa], [Anh])
VALUES
('SP06', N'Quần Nike Thể Thao', N'Nam', 'DM02', 'TH01', 350000, N'Quần thể thao chất lượng cao', '12.jpg'),
('SP07', N'Quần Adidas Jogger', N'Nữ', 'DM02', 'TH02', 450000, N'Quần jogger thời trang', '22.jpg'),
('SP08', N'Quần H&M Basic', N'Nam', 'DM02', 'TH04', 300000, N'Quần basic phù hợp nhiều phong cách', '11.jpg'),
('SP09', N'Quần Puma Casual', N'Nữ', 'DM02', 'TH06', 380000, N'Quần casual thời thượng', '14.jpg'),
('SP10', N'Quần Levi’s Jean', N'Nam', 'DM02', 'TH07', 500000, N'Quần jean cổ điển', '23.jpg');
GO
-- Thêm sản phẩm cho danh mục Áo khoác
INSERT INTO [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GioiTinh], [MaDanhMuc], [MaThuongHieu], [Gia], [MoTa], [Anh])
VALUES
('SP11', N'Áo khoác Nike', N'Nam', 'DM07', 'TH01', 600000, N'Áo khoác thể thao ấm áp', '1.jpg'),
('SP12', N'Áo khoác Adidas', N'Nữ', 'DM07', 'TH02', 750000, N'Áo khoác chống gió thời trang', '3.jpg'),
('SP13', N'Áo khoác H&M', N'Nam', 'DM07', 'TH04', 500000, N'Áo khoác cơ bản', '2.jpg'),
('SP14', N'Áo khoác Puma', N'Nữ', 'DM07', 'TH06', 700000, N'Áo khoác nhẹ nhàng thoải mái', '4.jpg'),
('SP15', N'Áo khoác Levi’s', N'Nam', 'DM07', 'TH07', 800000, N'Áo khoác jean phong cách', '20.jpg');
GO
-- Thêm sản phẩm cho danh mục Đồ thể thao
INSERT INTO [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GioiTinh], [MaDanhMuc], [MaThuongHieu], [Gia], [MoTa], [Anh])
VALUES
('SP16', N'Bộ đồ Nike', N'Nam', 'DM10', 'TH01', 900000, N'Bộ đồ thể thao', '24.jpg'),
('SP17', N'Bộ đồ Adidas', N'Nữ', 'DM10', 'TH02', 850000, N'Bộ đồ thể thao cao cấp', '12.jpg'),
('SP18', N'Bộ đồ H&M', N'Nam', 'DM10', 'TH04', 750000, N'Bộ đồ năng động', '14.jpg'),
('SP19', N'Bộ đồ Puma', N'Nữ', 'DM10', 'TH06', 950000, N'Bộ đồ thời trang', '23.jpg'),
('SP20', N'Bộ đồ Levi’s', N'Nam', 'DM10', 'TH07', 1000000, N'Bộ đồ phong cách', '3.jpg');
GO





-- Insert sản phẩm với mỗi size S, M, L, XL và số lượng 20, trạng thái 'Còn hàng'
INSERT INTO [dbo].[Size_SanPham] ([MaSanPham], [MaSize], [SoLuong], [TrangThai])
VALUES
-- SP01
('SP01', 'S', 20, N'Còn hàng'),
('SP01', 'M', 20, N'Còn hàng'),
('SP01', 'L', 20, N'Còn hàng'),
('SP01', 'XL', 20, N'Còn hàng'),
-- SP02
('SP02', 'S', 20, N'Còn hàng'),
('SP02', 'M', 20, N'Còn hàng'),
('SP02', 'L', 20, N'Còn hàng'),
('SP02', 'XL', 20, N'Còn hàng'),
-- SP03
('SP03', 'S', 20, N'Còn hàng'),
('SP03', 'M', 20, N'Còn hàng'),
('SP03', 'L', 20, N'Còn hàng'),
('SP03', 'XL', 20, N'Còn hàng'),
-- SP04
('SP04', 'S', 20, N'Còn hàng'),
('SP04', 'M', 20, N'Còn hàng'),
('SP04', 'L', 20, N'Còn hàng'),
('SP04', 'XL', 20, N'Còn hàng'),
-- SP05
('SP05', 'S', 20, N'Còn hàng'),
('SP05', 'M', 20, N'Còn hàng'),
('SP05', 'L', 20, N'Còn hàng'),
('SP05', 'XL', 20, N'Còn hàng'),
-- SP06
('SP06', 'S', 20, N'Còn hàng'),
('SP06', 'M', 20, N'Còn hàng'),
('SP06', 'L', 20, N'Còn hàng'),
('SP06', 'XL', 20, N'Còn hàng'),
-- SP07
('SP07', 'S', 20, N'Còn hàng'),
('SP07', 'M', 20, N'Còn hàng'),
('SP07', 'L', 20, N'Còn hàng'),
('SP07', 'XL', 20, N'Còn hàng'),
-- SP08
('SP08', 'S', 20, N'Còn hàng'),
('SP08', 'M', 20, N'Còn hàng'),
('SP08', 'L', 20, N'Còn hàng'),
('SP08', 'XL', 20, N'Còn hàng'),
-- SP09
('SP09', 'S', 20, N'Còn hàng'),
('SP09', 'M', 20, N'Còn hàng'),
('SP09', 'L', 20, N'Còn hàng'),
('SP09', 'XL', 20, N'Còn hàng'),
-- SP10
('SP10', 'S', 20, N'Còn hàng'),
('SP10', 'M', 20, N'Còn hàng'),
('SP10', 'L', 20, N'Còn hàng'),
('SP10', 'XL', 20, N'Còn hàng'),
-- SP11
('SP11', 'S', 20, N'Còn hàng'),
('SP11', 'M', 20, N'Còn hàng'),
('SP11', 'L', 20, N'Còn hàng'),
('SP11', 'XL', 20, N'Còn hàng'),
-- SP12
('SP12', 'S', 20, N'Còn hàng'),
('SP12', 'M', 20, N'Còn hàng'),
('SP12', 'L', 20, N'Còn hàng'),
('SP12', 'XL', 20, N'Còn hàng'),
-- SP13
('SP13', 'S', 20, N'Còn hàng'),
('SP13', 'M', 20, N'Còn hàng'),
('SP13', 'L', 20, N'Còn hàng'),
('SP13', 'XL', 20, N'Còn hàng'),
-- SP14
('SP14', 'S', 20, N'Còn hàng'),
('SP14', 'M', 20, N'Còn hàng'),
('SP14', 'L', 20, N'Còn hàng'),
('SP14', 'XL', 20, N'Còn hàng'),
-- SP15
('SP15', 'S', 20, N'Còn hàng'),
('SP15', 'M', 20, N'Còn hàng'),
('SP15', 'L', 20, N'Còn hàng'),
('SP15', 'XL', 20, N'Còn hàng'),
-- SP16
('SP16', 'S', 20, N'Còn hàng'),
('SP16', 'M', 20, N'Còn hàng'),
('SP16', 'L', 20, N'Còn hàng'),
('SP16', 'XL', 20, N'Còn hàng'),
-- SP17
('SP17', 'S', 20, N'Còn hàng'),
('SP17', 'M', 20, N'Còn hàng'),
('SP17', 'L', 20, N'Còn hàng'),
('SP17', 'XL', 20, N'Còn hàng'),
-- SP18
('SP18', 'S', 20, N'Còn hàng'),
('SP18', 'M', 20, N'Còn hàng'),
('SP18', 'L', 20, N'Còn hàng'),
('SP18', 'XL', 20, N'Còn hàng'),
-- SP19
('SP19', 'S', 20, N'Còn hàng'),
('SP19', 'M', 20, N'Còn hàng'),
('SP19', 'L', 20, N'Còn hàng'),
('SP19', 'XL', 20, N'Còn hàng'),
-- SP20
('SP20', 'S', 20, N'Còn hàng'),
('SP20', 'M', 20, N'Còn hàng'),
('SP20', 'L', 20, N'Còn hàng'),
('SP20', 'XL', 20, N'Còn hàng');
GO








------Tháng 8------
-- Bảng DonHang (Đơn hàng)
INSERT INTO [dbo].[DonHang] ([MaDonHang], [MaKhachHang], [NgayDat], [DiaChiGiaoHang], [TrangThaiDonHang], [TongTien], [PhuongThucThanhToan]) VALUES
('DH001', 'user01', '2024-08-01', N'123 Đường A, Hà Nội', N'Đã xác nhận', 750000, N'Tiền mặt'),
('DH002', 'user01', '2024-08-02', N'123 Đường A, Hà Nội', N'Đã xác nhận', 1100000, N'Chuyển khoản'),
('DH003', 'user02', '2024-08-03', N'456 Đường B, Hồ Chí Minh', N'Đã hủy', 500000, N'Tiền mặt'),
('DH004', 'user01', '2024-08-04', N'123 Đường A, Hà Nội', N'Đã xác nhận', 650000, N'Tiền mặt'),
('DH005', 'user02', '2024-08-05', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Chuyển khoản'),
('DH006', 'user01', '2024-08-06', N'123 Đường A, Hà Nội', N'Đã xác nhận', 800000, N'Tiền mặt'),
('DH007', 'user02', '2024-08-07', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1200000, N'Chuyển khoản'),
('DH008', 'user01', '2024-08-08', N'123 Đường A, Hà Nội', N'Đã hủy', 400000, N'Tiền mặt'),
('DH009', 'user02', '2024-08-09', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 550000, N'Tiền mặt'),
('DH010', 'user01', '2024-08-10', N'123 Đường A, Hà Nội', N'Đã xác nhận', 1000000, N'Chuyển khoản'),
('DH011', 'user02', '2024-08-11', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 700000, N'Tiền mặt'),
('DH012', 'user01', '2024-08-12', N'123 Đường A, Hà Nội', N'Đã hủy', 300000, N'Tiền mặt'),
('DH013', 'user02', '2024-08-13', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Chuyển khoản'),
('DH014', 'user01', '2024-08-14', N'123 Đường A, Hà Nội', N'Đã xác nhận', 600000, N'Tiền mặt'),
('DH015', 'user02', '2024-08-15', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 850000, N'Chuyển khoản');
GO
-- Bảng ChiTietDonHang (Chi tiết đơn hàng)
INSERT INTO [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [MaSanPham], [SoLuong], [GiaDonVi], [MaSize], [ThanhTien]) VALUES
-- DH001
('CTDH0011', 'DH001', 'SP01', 2, 250000, 'M', 500000),
('CTDH0012', 'DH001', 'SP02', 1, 250000, 'L', 250000),
-- DH002
('CTDH0021', 'DH002', 'SP03', 3, 200000, 'XL', 600000),
('CTDH0022', 'DH002', 'SP04', 2, 250000, 'M', 500000),
-- DH003
('CTDH0031', 'DH003', 'SP05', 1, 400000, 'L', 400000),
('CTDH0032', 'DH003', 'SP01', 2, 50000, 'S', 100000),
-- DH004
('CTDH0041', 'DH004', 'SP02', 1, 350000, 'M', 350000),
('CTDH0042', 'DH004', 'SP06', 2, 150000, 'S', 300000),
-- DH005
('CTDH0051', 'DH005', 'SP07', 2, 450000, 'M', 900000),
('CTDH0052', 'DH005', 'SP08', 1, 50000, 'L', 50000),
-- DH006
('CTDH0061', 'DH006', 'SP09', 2, 380000, 'S', 760000),
-- DH007
('CTDH0071', 'DH007', 'SP10', 1, 500000, 'L', 500000),
('CTDH0072', 'DH007', 'SP11', 2, 350000, 'S', 700000),
-- DH008
('CTDH0081', 'DH008', 'SP12', 2, 350000, 'S', 700000),
-- DH009
('CTDH0091', 'DH009', 'SP13', 1, 500000, 'L', 500000),
-- DH010
('CTDH0101', 'DH010', 'SP14', 2, 500000, 'XL', 1000000),
-- DH011
('CTDH0111', 'DH011', 'SP15', 3, 800000, 'L', 2400000),
-- DH012
('CTDH0121', 'DH012', 'SP16', 1, 900000, 'M', 900000),
-- DH013
('CTDH0131', 'DH013', 'SP17', 1, 850000, 'L', 850000),
('CTDH0132', 'DH013', 'SP18', 1, 700000, 'XL', 700000),
-- DH014
('CTDH0141', 'DH014', 'SP19', 1, 900000, 'L', 900000),
-- DH015
('CTDH0151', 'DH015', 'SP20', 2, 1000000, 'XL', 2000000);
GO


--------Tháng 9--------
-- Bảng DonHang (Đơn hàng)
INSERT INTO [dbo].[DonHang] ([MaDonHang], [MaKhachHang], [NgayDat], [DiaChiGiaoHang], [TrangThaiDonHang], [TongTien], [PhuongThucThanhToan]) VALUES
('DH016', 'user01', '2024-09-01', N'123 Đường A, Hà Nội', N'Đã xác nhận', 750000, N'Tiền mặt'),
('DH017', 'user02', '2024-09-02', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1200000, N'Chuyển khoản'),
('DH018', 'user01', '2024-09-03', N'123 Đường A, Hà Nội', N'Đã hủy', 500000, N'Tiền mặt'),
('DH019', 'user02', '2024-09-04', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Chuyển khoản'),
('DH020', 'user01', '2024-09-05', N'123 Đường A, Hà Nội', N'Đã xác nhận', 850000, N'Tiền mặt'),
('DH021', 'user02', '2024-09-06', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 600000, N'Tiền mặt'),
('DH022', 'user01', '2024-09-07', N'123 Đường A, Hà Nội', N'Đã xác nhận', 700000, N'Chuyển khoản'),
('DH023', 'user02', '2024-09-08', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 800000, N'Tiền mặt'),
('DH024', 'user01', '2024-09-09', N'123 Đường A, Hà Nội', N'Đã hủy', 400000, N'Chuyển khoản'),
('DH025', 'user02', '2024-09-10', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1000000, N'Tiền mặt'),
('DH026', 'user01', '2024-09-11', N'123 Đường A, Hà Nội', N'Đã xác nhận', 750000, N'Chuyển khoản'),
('DH027', 'user02', '2024-09-12', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 800000, N'Tiền mặt'),
('DH028', 'user01', '2024-09-13', N'123 Đường A, Hà Nội', N'Đã xác nhận', 850000, N'Chuyển khoản'),
('DH029', 'user02', '2024-09-14', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Tiền mặt'),
('DH030', 'user01', '2024-09-15', N'123 Đường A, Hà Nội', N'Đã xác nhận', 600000, N'Chuyển khoản'),
('DH031', 'user02', '2024-09-16', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Tiền mặt'),
('DH032', 'user01', '2024-09-17', N'123 Đường A, Hà Nội', N'Đã xác nhận', 400000, N'Tiền mặt'),
('DH033', 'user02', '2024-09-18', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1000000, N'Chuyển khoản');
GO
-- Bảng ChiTietDonHang (Chi tiết đơn hàng)
INSERT INTO [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [MaSanPham], [SoLuong], [GiaDonVi], [MaSize], [ThanhTien])
VALUES
-- DH016
('CTDH0161', 'DH016', 'SP01', 2, 250000, 'M', 500000),
('CTDH0162', 'DH016', 'SP02', 1, 250000, 'L', 250000),
-- DH017
('CTDH0171', 'DH017', 'SP03', 3, 200000, 'XL', 600000),
('CTDH0172', 'DH017', 'SP04', 2, 250000, 'M', 500000),
-- DH018
('CTDH0181', 'DH018', 'SP05', 1, 400000, 'L', 400000),
-- DH019
('CTDH0191', 'DH019', 'SP06', 2, 350000, 'S', 700000),
('CTDH0192', 'DH019', 'SP07', 1, 450000, 'M', 450000),
-- DH020
('CTDH0201', 'DH020', 'SP08', 2, 300000, 'L', 600000),
-- DH021
('CTDH0211', 'DH021', 'SP09', 2, 380000, 'S', 760000),
-- DH022
('CTDH0221', 'DH022', 'SP10', 1, 500000, 'XL', 500000),
('CTDH0222', 'DH022', 'SP11', 2, 600000, 'M', 1200000),
-- DH023
('CTDH0231', 'DH023', 'SP12', 2, 750000, 'S', 1500000),
-- DH024
('CTDH0241', 'DH024', 'SP13', 1, 500000, 'M', 500000),
-- DH025
('CTDH0251', 'DH025', 'SP14', 2, 700000, 'L', 1400000),
-- DH026
('CTDH0261', 'DH026', 'SP15', 3, 800000, 'L', 2400000),
-- DH027
('CTDH0271', 'DH027', 'SP16', 1, 900000, 'M', 900000),
-- DH028
('CTDH0281', 'DH028', 'SP17', 2, 850000, 'S', 1700000),
-- DH029
('CTDH0291', 'DH029', 'SP18', 1, 750000, 'M', 750000),
-- DH030
('CTDH0301', 'DH030', 'SP19', 1, 950000, 'S', 950000),
-- DH031
('CTDH0311', 'DH031', 'SP20', 2, 1000000, 'XL', 2000000),
-- DH032
('CTDH0321', 'DH032', 'SP01', 1, 250000, 'L', 250000),
('CTDH0322', 'DH032', 'SP02', 2, 350000, 'S', 700000),
-- DH033
('CTDH0331', 'DH033', 'SP03', 1, 200000, 'L', 200000),
('CTDH0332', 'DH033', 'SP04', 2, 300000, 'M', 600000);
GO



--------------Tháng 7--------------
-- Bảng DonHang (Đơn hàng)
INSERT INTO [dbo].[DonHang] ([MaDonHang], [MaKhachHang], [NgayDat], [DiaChiGiaoHang], [TrangThaiDonHang], [TongTien], [PhuongThucThanhToan]) VALUES
('DH045', 'user01', '2024-07-01', N'123 Đường A, Hà Nội', N'Đã xác nhận', 750000, N'Tiền mặt'),
('DH046', 'user02', '2024-07-02', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1200000, N'Chuyển khoản'),
('DH047', 'user01', '2024-07-03', N'123 Đường A, Hà Nội', N'Đã hủy', 500000, N'Tiền mặt'),
('DH048', 'user02', '2024-07-04', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Chuyển khoản'),
('DH049', 'user01', '2024-07-05', N'123 Đường A, Hà Nội', N'Đã xác nhận', 850000, N'Tiền mặt'),
('DH050', 'user02', '2024-07-06', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 600000, N'Tiền mặt'),
('DH051', 'user01', '2024-07-07', N'123 Đường A, Hà Nội', N'Đã xác nhận', 700000, N'Chuyển khoản'),
('DH052', 'user02', '2024-07-08', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 800000, N'Tiền mặt'),
('DH053', 'user01', '2024-07-09', N'123 Đường A, Hà Nội', N'Đã hủy', 400000, N'Chuyển khoản'),
('DH054', 'user02', '2024-07-10', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1000000, N'Tiền mặt');
GO
-- Bảng ChiTietDonHang (Chi tiết đơn hàng) - Tháng 7
INSERT INTO [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [MaSanPham], [SoLuong], [GiaDonVi], [MaSize], [ThanhTien]) VALUES
-- DH045
('CTDH0451', 'DH045', 'SP01', 2, 250000, 'M', 500000),
('CTDH0452', 'DH045', 'SP02', 1, 250000, 'L', 250000),
-- DH046
('CTDH0461', 'DH046', 'SP03', 3, 200000, 'XL', 600000),
('CTDH0462', 'DH046', 'SP04', 2, 250000, 'M', 500000),
-- DH047
('CTDH0471', 'DH047', 'SP05', 1, 400000, 'L', 400000),
-- DH048
('CTDH0481', 'DH048', 'SP06', 2, 350000, 'S', 700000),
('CTDH0482', 'DH048', 'SP07', 1, 450000, 'M', 450000),
-- DH049
('CTDH0491', 'DH049', 'SP08', 2, 300000, 'L', 600000),
-- DH050
('CTDH0501', 'DH050', 'SP09', 2, 380000, 'S', 760000),
-- DH051
('CTDH0511', 'DH051', 'SP10', 1, 500000, 'XL', 500000),
('CTDH0512', 'DH051', 'SP11', 2, 600000, 'M', 1200000),
-- DH052
('CTDH0521', 'DH052', 'SP12', 2, 750000, 'S', 1500000),
-- DH053
('CTDH0531', 'DH053', 'SP13', 1, 500000, 'M', 500000),
-- DH054
('CTDH0541', 'DH054', 'SP14', 2, 700000, 'L', 1400000);
GO



----------------Tháng 10---------------
-- Bảng DonHang (Đơn hàng)
INSERT INTO [dbo].[DonHang] ([MaDonHang], [MaKhachHang], [NgayDat], [DiaChiGiaoHang], [TrangThaiDonHang], [TongTien], [PhuongThucThanhToan])
VALUES
('DH055', 'user01', '2024-10-01', N'123 Đường A, Hà Nội', N'Đã xác nhận', 750000, N'Tiền mặt'),
('DH056', 'user02', '2024-10-02', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1200000, N'Chuyển khoản'),
('DH057', 'user01', '2024-10-03', N'123 Đường A, Hà Nội', N'Đã hủy', 500000, N'Tiền mặt'),
('DH058', 'user02', '2024-10-04', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Chuyển khoản'),
('DH059', 'user01', '2024-10-05', N'123 Đường A, Hà Nội', N'Đã xác nhận', 850000, N'Tiền mặt'),
('DH060', 'user02', '2024-10-06', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 600000, N'Tiền mặt'),
('DH061', 'user01', '2024-10-07', N'123 Đường A, Hà Nội', N'Đã xác nhận', 700000, N'Chuyển khoản'),
('DH062', 'user02', '2024-10-08', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 800000, N'Tiền mặt'),
('DH063', 'user01', '2024-10-09', N'123 Đường A, Hà Nội', N'Đã hủy', 400000, N'Chuyển khoản'),
('DH064', 'user02', '2024-10-10', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1000000, N'Tiền mặt'),
('DH065', 'user01', '2024-10-11', N'123 Đường A, Hà Nội', N'Đã xác nhận', 950000, N'Tiền mặt'),
('DH066', 'user02', '2024-10-12', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 800000, N'Chuyển khoản'),
('DH067', 'user01', '2024-10-13', N'123 Đường A, Hà Nội', N'Đã xác nhận', 850000, N'Tiền mặt'),
('DH068', 'user02', '2024-10-14', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 900000, N'Tiền mặt'),
('DH069', 'user01', '2024-10-15', N'123 Đường A, Hà Nội', N'Đã hủy', 650000, N'Chuyển khoản'),
('DH070', 'user02', '2024-10-16', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 700000, N'Tiền mặt'),
('DH071', 'user01', '2024-10-17', N'123 Đường A, Hà Nội', N'Đã xác nhận', 800000, N'Chuyển khoản');
GO
-- Bảng ChiTietDonHang (Chi tiết đơn hàng)
INSERT INTO [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [MaSanPham], [SoLuong], [GiaDonVi], [MaSize], [ThanhTien])VALUES
-- DH055
('CTDH0551', 'DH055', 'SP01', 2, 250000, 'M', 500000),
('CTDH0552', 'DH055', 'SP02', 1, 250000, 'L', 250000),
-- DH056
('CTDH0561', 'DH056', 'SP03', 3, 200000, 'XL', 600000),
('CTDH0562', 'DH056', 'SP04', 2, 300000, 'M', 600000),
-- DH057
('CTDH0571', 'DH057', 'SP05', 1, 400000, 'L', 400000),
-- DH058
('CTDH0581', 'DH058', 'SP06', 2, 350000, 'S', 700000),
('CTDH0582', 'DH058', 'SP07', 1, 450000, 'M', 450000),
-- DH059
('CTDH0591', 'DH059', 'SP08', 2, 300000, 'L', 600000),
-- DH060
('CTDH0601', 'DH060', 'SP09', 2, 380000, 'S', 760000),
-- DH061
('CTDH0611', 'DH061', 'SP10', 1, 500000, 'XL', 500000),
('CTDH0612', 'DH061', 'SP11', 2, 600000, 'M', 1200000),
-- DH062
('CTDH0621', 'DH062', 'SP12', 2, 750000, 'S', 1500000),
-- DH063
('CTDH0631', 'DH063', 'SP13', 1, 500000, 'M', 500000),
-- DH064
('CTDH0641', 'DH064', 'SP14', 2, 700000, 'L', 1400000),
-- DH065
('CTDH0651', 'DH065', 'SP15', 3, 800000, 'L', 2400000),
-- DH066
('CTDH0661', 'DH066', 'SP16', 1, 900000, 'M', 900000),
-- DH067
('CTDH0671', 'DH067', 'SP17', 2, 850000, 'S', 1700000),
-- DH068
('CTDH0681', 'DH068', 'SP18', 1, 750000, 'M', 750000),
-- DH069
('CTDH0691', 'DH069', 'SP19', 1, 950000, 'S', 950000),
-- DH070
('CTDH0701', 'DH070', 'SP20', 2, 1000000, 'XL', 2000000),
-- DH071
('CTDH0711', 'DH071', 'SP01', 1, 250000, 'L', 250000),
('CTDH0712', 'DH071', 'SP02', 2, 350000, 'S', 700000);
GO

---------------Tháng 11-------------
-- Bảng DonHang (Đơn hàng)
INSERT INTO [dbo].[DonHang] ([MaDonHang], [MaKhachHang], [NgayDat], [DiaChiGiaoHang], [TrangThaiDonHang], [TongTien], [PhuongThucThanhToan])
VALUES
('DH072', 'user01', '2024-11-01', N'123 Đường A, Hà Nội', N'Đã xác nhận', 850000, N'Tiền mặt'),
('DH073', 'user02', '2024-11-02', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1200000, N'Chuyển khoản'),
('DH074', 'user01', '2024-11-03', N'123 Đường A, Hà Nội', N'Đã hủy', 450000, N'Tiền mặt'),
('DH075', 'user02', '2024-11-04', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 950000, N'Chuyển khoản'),
('DH076', 'user01', '2024-11-05', N'123 Đường A, Hà Nội', N'Đã xác nhận', 750000, N'Tiền mặt'),
('DH077', 'user02', '2024-11-06', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 680000, N'Tiền mặt'),
('DH078', 'user01', '2024-11-07', N'123 Đường A, Hà Nội', N'Đã xác nhận', 900000, N'Chuyển khoản'),
('DH079', 'user02', '2024-11-08', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1100000, N'Tiền mặt'),
('DH080', 'user01', '2024-11-09', N'123 Đường A, Hà Nội', N'Đã hủy', 550000, N'Chuyển khoản'),
('DH081', 'user02', '2024-11-10', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 980000, N'Tiền mặt'),
('DH082', 'user01', '2024-11-11', N'123 Đường A, Hà Nội', N'Đã xác nhận', 720000, N'Tiền mặt'),
('DH083', 'user02', '2024-11-12', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 880000, N'Chuyển khoản'),
('DH084', 'user01', '2024-11-13', N'123 Đường A, Hà Nội', N'Đã xác nhận', 650000, N'Tiền mặt'),
('DH085', 'user02', '2024-11-14', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 900000, N'Tiền mặt'),
('DH086', 'user01', '2024-11-15', N'123 Đường A, Hà Nội', N'Đã hủy', 750000, N'Chuyển khoản'),
('DH087', 'user02', '2024-11-16', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1050000, N'Tiền mặt'),
('DH088', 'user01', '2024-11-17', N'123 Đường A, Hà Nội', N'Đã xác nhận', 940000, N'Chuyển khoản'),
('DH089', 'user02', '2024-11-18', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 850000, N'Tiền mặt'),
('DH090', 'user01', '2024-11-19', N'123 Đường A, Hà Nội', N'Đã xác nhận', 720000, N'Chuyển khoản'),
('DH091', 'user02', '2024-11-20', N'456 Đường B, Hồ Chí Minh', N'Đã xác nhận', 1000000, N'Tiền mặt'),
('DH092', 'user01', '2024-11-21', N'123 Đường A, Hà Nội', N'Đã xác nhận', 890000, N'Chuyển khoản');
GO
-- Bảng ChiTietDonHang (Chi tiết đơn hàng)
INSERT INTO [dbo].[ChiTietDonHang] ([MaChiTietDonHang], [MaDonHang], [MaSanPham], [SoLuong], [GiaDonVi], [MaSize], [ThanhTien]) VALUES
-- DH072
('CTDH0721', 'DH072', 'SP01', 2, 250000, 'M', 500000),
('CTDH0722', 'DH072', 'SP02', 1, 350000, 'L', 350000),
-- DH073
('CTDH0731', 'DH073', 'SP03', 3, 200000, 'XL', 600000),
('CTDH0732', 'DH073', 'SP04', 2, 300000, 'M', 600000),
-- DH074
('CTDH0741', 'DH074', 'SP05', 1, 450000, 'L', 450000),
-- DH075
('CTDH0751', 'DH075', 'SP06', 2, 350000, 'S', 700000),
('CTDH0752', 'DH075', 'SP07', 1, 250000, 'M', 250000),
-- DH076
('CTDH0761', 'DH076', 'SP08', 2, 300000, 'L', 600000),
-- DH077
('CTDH0771', 'DH077', 'SP09', 2, 380000, 'S', 760000),
-- DH078
('CTDH0781', 'DH078', 'SP10', 1, 500000, 'XL', 500000),
('CTDH0782', 'DH078', 'SP11', 2, 600000, 'M', 1200000),
-- DH079
('CTDH0791', 'DH079', 'SP12', 2, 750000, 'S', 1500000),
-- DH080
('CTDH0801', 'DH080', 'SP13', 1, 550000, 'M', 550000),
-- DH081
('CTDH0811', 'DH081', 'SP14', 2, 490000, 'L', 980000),
-- DH082
('CTDH0821', 'DH082', 'SP15', 1, 720000, 'XL', 720000),
-- DH083
('CTDH0831', 'DH083', 'SP16', 2, 440000, 'M', 880000),
-- DH084
('CTDH0841', 'DH084', 'SP17', 1, 650000, 'S', 650000),
-- DH085
('CTDH0851', 'DH085', 'SP18', 1, 450000, 'L', 450000),
('CTDH0852', 'DH085', 'SP19', 1, 450000, 'M', 450000),
-- DH086
('CTDH0861', 'DH086', 'SP20', 2, 375000, 'XL', 750000),
-- DH087
('CTDH0871', 'DH087', 'SP01', 3, 350000, 'L', 1050000),
-- DH088
('CTDH0881', 'DH088', 'SP02', 2, 470000, 'S', 940000),
-- DH089
('CTDH0891', 'DH089', 'SP03', 2, 425000, 'M', 850000),
-- DH090
('CTDH0901', 'DH090', 'SP04', 1, 720000, 'L', 720000),
-- DH091
('CTDH0911', 'DH091', 'SP05', 2, 500000, 'XL', 1000000),
-- DH092
('CTDH0921', 'DH092', 'SP06', 2, 445000, 'M', 890000);
GO











