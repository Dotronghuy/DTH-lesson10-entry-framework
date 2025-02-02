USE [DTHQLSV]
GO
/****** Object:  Table [dbo].[Ketqua]    Script Date: 6/24/2024 8:56:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ketqua](
	[MaSV] [nchar](10) NULL,
	[MaMH] [nchar](10) NULL,
	[Diem] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 6/24/2024 8:56:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKH] [nchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Monhoc]    Script Date: 6/24/2024 8:56:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monhoc](
	[MaMH] [nchar](10) NOT NULL,
	[TenMH] [nvarchar](50) NULL,
	[Sotiet] [float] NULL,
 CONSTRAINT [PK_Monhoc] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 6/24/2024 8:56:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [nchar](10) NOT NULL,
	[HoSV] [nvarchar](50) NULL,
	[TenSV] [nvarchar](50) NULL,
	[Phai] [nchar](10) NULL,
	[NS] [date] NULL,
	[NoiSinh] [nvarchar](50) NULL,
	[MaKH] [nchar](10) NULL,
	[HocBong] [nvarchar](50) NULL,
	[DTB] [float] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Ketqua] ([MaSV], [MaMH], [Diem]) VALUES (N'1         ', N'AV        ', 10)
INSERT [dbo].[Ketqua] ([MaSV], [MaMH], [Diem]) VALUES (N'2         ', N'L         ', 5)
INSERT [dbo].[Ketqua] ([MaSV], [MaMH], [Diem]) VALUES (N'2         ', N'CNTT      ', 10)
INSERT [dbo].[Khoa] ([MaKH], [TenKH]) VALUES (N'A         ', N'Anhh')
INSERT [dbo].[Khoa] ([MaKH], [TenKH]) VALUES (N'AV        ', N'Anh Văn')
INSERT [dbo].[Khoa] ([MaKH], [TenKH]) VALUES (N'L         ', N'Lý')
INSERT [dbo].[Khoa] ([MaKH], [TenKH]) VALUES (N'T         ', N'Toán')
INSERT [dbo].[Monhoc] ([MaMH], [TenMH], [Sotiet]) VALUES (N'AV        ', N'Anh Văn', 10)
INSERT [dbo].[Monhoc] ([MaMH], [TenMH], [Sotiet]) VALUES (N'CNTT      ', N'Công Nghệ Thông Tin', 10)
INSERT [dbo].[Monhoc] ([MaMH], [TenMH], [Sotiet]) VALUES (N'L         ', N'Lý', 10)
INSERT [dbo].[Monhoc] ([MaMH], [TenMH], [Sotiet]) VALUES (N'T         ', N'Toán', 10)
INSERT [dbo].[SinhVien] ([MaSV], [HoSV], [TenSV], [Phai], [NS], [NoiSinh], [MaKH], [HocBong], [DTB]) VALUES (N'1         ', N'Đỗ Trọng', N'Huy', N'Nam       ', CAST(N'2004-10-20' AS Date), N'Hà Nội', N'T         ', N'Có', 10)
INSERT [dbo].[SinhVien] ([MaSV], [HoSV], [TenSV], [Phai], [NS], [NoiSinh], [MaKH], [HocBong], [DTB]) VALUES (N'2         ', N'Nguyễn Văn', N'Thạo', N'Nữ        ', CAST(N'2004-05-17' AS Date), N'Hà Nội', N'L         ', N'Có', 5)
ALTER TABLE [dbo].[Ketqua]  WITH CHECK ADD  CONSTRAINT [FK_Ketqua_Monhoc] FOREIGN KEY([MaMH])
REFERENCES [dbo].[Monhoc] ([MaMH])
GO
ALTER TABLE [dbo].[Ketqua] CHECK CONSTRAINT [FK_Ketqua_Monhoc]
GO
ALTER TABLE [dbo].[Ketqua]  WITH CHECK ADD  CONSTRAINT [FK_Ketqua_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[Ketqua] CHECK CONSTRAINT [FK_Ketqua_SinhVien]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Khoa] FOREIGN KEY([MaKH])
REFERENCES [dbo].[Khoa] ([MaKH])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Khoa]
GO
