CREATE DATABASE [QL_ShopQuanAo]
GO
USE [QL_ShopQuanAo]
GO

--update DonHang set NgayDat = '2024-12-04' where MaDonHang = 'DH202412071'

/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaChiTietDonHang] [varchar](50) NOT NULL,
	[MaDonHang] [varchar](50) NULL,
	[MaSanPham] [varchar](50) NULL,
	[SoLuong] [int] NULL,
	[GiaDonVi] [decimal](10, 2) NULL,
	[MaSize] [varchar](50) NULL,
	[ThanhTien] decimal(10,2)
PRIMARY KEY CLUSTERED 
(
	[MaChiTietDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [varchar](50) NOT NULL,
	[MaSanPham] [varchar](50) NULL,
	[MaKhachHang] [varchar](50) NULL,
	[DanhGia] [int] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[NgayDanhGia] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [varchar](50) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [varchar](50) NOT NULL,
	[MaKhachHang] [varchar](50) NULL,
	--[MaNhanVien] [nvarchar](50) NULL,
	[NgayDat] [datetime] NULL,
	[DiaChiGiaoHang] [nvarchar](255) NULL,
	[TrangThaiDonHang] [nvarchar](50) NULL check ([TrangThaiDonHang] in (N'Đã xác nhận',N'Đang xử lý',N'Đã hủy')),
	[TongTien] decimal(10,2),
	[PhuongThucThanhToan] nvarchar(50) null check ([PhuongThucThanhToan] in (N'Tiền mặt',N'Chuyển khoản'))
PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[TenDangNhap] [varchar](50) NOT NULL,
	[Ho] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[ThanhPho] [nvarchar](50) NULL,
	[Tinh] [nvarchar](50) NULL,
	[MaZip] [nvarchar](10) NULL,
	[ChucVu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaGiamGia]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaGiamGia](
	[MaGiamGia] [varchar](50) NOT NULL,
	[PhanTramGiam] [decimal](5, 2) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGiamGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[TenDangNhap] [varchar](50) NOT NULL,
	[Ho] [nvarchar](50) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](20) NULL,
	[ChucVu] [nvarchar](255) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [varchar](50) NOT NULL,
	[TenSanPham] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](255) NOT NULL,
	[MaDanhMuc] [varchar](50) NULL,
	[MaThuongHieu] [varchar](50) NULL,
	[Gia] [decimal](10, 2) NULL,
	[MoTa] [nvarchar](max) NULL,
	[Anh] [varchar](100) NULL
	
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhamMaGiamGia]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamMaGiamGia](
	[MaSanPham] [varchar](50) NOT NULL,
	[MaGiamGia] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC,
	[MaGiamGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Size]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[MaSize] [varchar](50) NOT NULL,
	
	[MoTaSize] [nvarchar](255) NULL
	
PRIMARY KEY CLUSTERED 
(
	[MaSize] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Size_SanPham](
	[MaSanPham] [varchar](50)Not  NULL,
	[MaSize] [varchar](50) NOT NULL,
	[SoLuong] int ,
	[TrangThai] [nvarchar](255) NULL check ([TrangThai] in (N'Còn hàng',N'Hết hàng')),
	Foreign key ([MaSanPham]) references SanPham([MaSanPham]),
	Foreign key ([MaSize]) references Size([MaSize])
	)
	GO
ALTER TABLE [Size_SanPham]
ADD CONSTRAINT msp_ms PRIMARY KEY ([MaSanPham], [MaSize]);
GO

CREATE TABLE LichSuNhapHang (
	MaLSNH varchar(50) primary key,
	MaSP varchar(50) references SanPham([MaSanPham]),
	MaSize varchar(50) references Size([MaSize]),
	SoLuong int,
	NgayNhap date,
	TongGia decimal(10,2),
	MaNhanVien [varchar](50) references NhanVien([TenDangNhap])
)

/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaThuongHieu] [varchar](50) NOT NULL,
	[TenThuongHieu] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 13/11/2024 2:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[ChucVu] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Index [UQ__KhachHan__A9D105346FD4D190]    Script Date: 13/11/2024 2:49:01 AM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A9D105343FA0DCEA]    Script Date: 13/11/2024 2:49:01 AM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Size_SanPham] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaSize])
REFERENCES [dbo].[Size] ([MaSize])
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([TenDangNhap])
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([TenDangNhap])
GO
--ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
--REFERENCES [dbo].[NhanVien] ([TenDangNhap])
--GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[UserAccount] ([TenDangNhap])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[UserAccount] ([TenDangNhap])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[SanPhamMaGiamGia]  WITH CHECK ADD FOREIGN KEY([MaGiamGia])
REFERENCES [dbo].[MaGiamGia] ([MaGiamGia])
GO
ALTER TABLE [dbo].[SanPhamMaGiamGia]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD CHECK  (([ChucVu]=N'Khách hàng'))
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CK__KhachHang__GioiT__3F466844] CHECK  (([GioiTinh]=N'Nữ' OR [GioiTinh]=N'Nam'))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CK__KhachHang__GioiT__3F466844]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([ChucVu]=N'Nhân viên'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([GioiTinh]=N'Nữ' OR [GioiTinh]=N'Nam'))
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [CK__SanPham__GioiTin__3B75D760] CHECK  (([GioiTinh]=N'Nữ' OR [GioiTinh]=N'Nam'))
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [CK__SanPham__GioiTin__3B75D760]
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD CHECK  (([ChucVu]=N'Khách hàng' OR [ChucVu]=N'Nhân viên'))
GO




/****** Object:  Trigger [dbo].[trg_UpdateTrangThaiSanPham]    Script Date: 13/11/2024 2:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateTrangThaiSanPham]
ON [dbo].[Size_SanPham]
AFTER INSERT,UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật trạng thái thành 'Hết hàng' khi SoLuong = 0
    UPDATE dbo.Size_SanPham
    SET TrangThai = N'Hết hàng'
    WHERE SoLuong = 0 AND MaSanPham IN (SELECT MaSanPham FROM inserted);

    -- Cập nhật trạng thái thành 'Còn hàng' khi SoLuong > 0
    UPDATE dbo.Size_SanPham
    SET TrangThai = N'Còn hàng'
    WHERE SoLuong > 0 AND MaSanPham IN (SELECT MaSanPham FROM inserted);
END;
GO
ALTER TABLE [dbo].[Size_SanPham] ENABLE TRIGGER [trg_UpdateTrangThaiSanPham]
GO


CREATE TRIGGER trg_UpdateSoLuongSauDatHang
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    -- Bắt đầu khối xử lý
    SET NOCOUNT ON;

    -- Kiểm tra tồn kho
    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        INNER JOIN Size_SanPham sp
            ON i.MaSanPham = sp.MaSanPham AND i.MaSize = sp.MaSize
        WHERE sp.SoLuong < i.SoLuong
    )
    BEGIN
        -- Nếu không đủ số lượng, rollback giao dịch và báo lỗi
        RAISERROR ('Không đủ số lượng tồn kho cho sản phẩm!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Cập nhật số lượng tồn kho
    UPDATE sp
    SET sp.SoLuong = sp.SoLuong - i.SoLuong
    FROM Size_SanPham sp
    INNER JOIN INSERTED i
        ON sp.MaSanPham = i.MaSanPham AND sp.MaSize = i.MaSize;

END;
GO









