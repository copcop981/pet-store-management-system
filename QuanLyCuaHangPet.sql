USE [master]
GO
/****** Object:  Database [QuanLyCuaHangPet]    Script Date: 21-Jul-22 6:53:10 PM ******/
CREATE DATABASE [QuanLyCuaHangPet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCuaHangPet', FILENAME = N'D:\IT\Db\QuanLyCuaHangPet.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyCuaHangPet_log', FILENAME = N'D:\IT\Db\QuanLyCuaHangPet_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyCuaHangPet] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCuaHangPet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCuaHangPet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCuaHangPet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCuaHangPet] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyCuaHangPet]
GO
/****** Object:  StoredProcedure [dbo].[getAll]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAll]
as
begin
	select * from Userr
end

GO
/****** Object:  Table [dbo].[Cash]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cash](
	[CashId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionNo] [varchar](30) NOT NULL,
	[Pid] [varchar](30) NOT NULL,
	[Pname] [nvarchar](250) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [int] NOT NULL,
	[Total] [int] NULL,
	[Cid] [int] NULL,
	[Cashier] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CashId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](250) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Cid] [int] IDENTITY(1,1) NOT NULL,
	[Cname] [nvarchar](250) NOT NULL,
	[Caddress] [nvarchar](250) NULL,
	[Cphone] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Pid] [int] IDENTITY(1,1) NOT NULL,
	[Pname] [nvarchar](250) NOT NULL,
	[Ptype] [nvarchar](250) NOT NULL,
	[Pcategory] [nvarchar](250) NOT NULL,
	[Pquantity] [int] NOT NULL,
	[Pprice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Revenue]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Revenue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date_Time] [datetime] NOT NULL,
	[Transaction_No] [varchar](30) NOT NULL,
	[Product_Name] [nvarchar](250) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Total] [int] NOT NULL,
	[Payer] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Revenue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TemporaryData]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TemporaryData](
	[CashId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionNo] [varchar](30) NOT NULL,
	[Pid] [varchar](30) NOT NULL,
	[Pname] [nvarchar](250) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [int] NOT NULL,
	[Total] [int] NULL,
	[Cid] [int] NULL,
	[Cashier] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CashId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Userr]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Userr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[address] [nvarchar](250) NULL,
	[phone] [varchar](30) NULL,
	[role] [nvarchar](250) NOT NULL,
	[birth] [date] NULL,
	[password] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [nvarchar](250) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Category]) VALUES (1, N'All')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (2, N'Dog')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (3, N'Cat')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (4, N'Fish')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (5, N'Bird')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Cid], [Cname], [Caddress], [Cphone]) VALUES (1, N'Lê Bảo Phúc', N'Đà Nẵng, Việt Nam', N'0905111459')
INSERT [dbo].[Customer] ([Cid], [Cname], [Caddress], [Cphone]) VALUES (2, N'Hoàng Trọng Quân', N'Đà Nẵng, Việt Nam', N'0763668789')
INSERT [dbo].[Customer] ([Cid], [Cname], [Caddress], [Cphone]) VALUES (3, N'Nguyễn Đặng Hoàng Lâm', N'Đà Nẵng, Việt Nam', N'0903335365')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (1, N'Betta', N'Betta', N'Fish', 300, 30000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (2, N'Goldfish', N'Goldfish', N'Fish', 100, 20000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (3, N'Angelfish', N'Angelfish', N'Fish', 100, 20000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (4, N'Wakin Goldfish', N'Goldfish', N'Fish', 200, 30000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (5, N'Half Black Angelfish', N'Angelfish', N'Fish', 300, 40000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (6, N'Autralian Silky Terrier', N'Terrier', N'Dog', 50, 50000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (7, N'Autralian Terrier', N'Terrier', N'Dog', 100, 40000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (8, N'German Shepherds', N'Becgie', N'Dog', 200, 50000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (9, N'Labrador Retriver', N'Retriver', N'Dog', 250, 50000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (10, N'Mumbai Cat', N'Cat', N'Cat', 50, 50000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (11, N'The American Bobtail', N'Cat', N'Cat', 200, 40000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (12, N'Parrotlets', N'Bird', N'Bird', 100, 70000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (13, N'Hyacinth Macaws', N'Bird', N'Bird', 200, 50000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (14, N'Quaker', N'Bird', N'Bird', 100, 30000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (15, N'Cockatoo', N'Bird', N'Bird', 400, 60000)
INSERT [dbo].[Product] ([Pid], [Pname], [Ptype], [Pcategory], [Pquantity], [Pprice]) VALUES (16, N'Conure', N'Bird', N'Bird', 300, 40000)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Userr] ON 

INSERT [dbo].[Userr] ([id], [name], [address], [phone], [role], [birth], [password]) VALUES (1, N'admin', N'Đà Nẵng, Việt Nam', N'0905111459', N'Administrator', CAST(0x95230B00 AS Date), N'admin')
INSERT [dbo].[Userr] ([id], [name], [address], [phone], [role], [birth], [password]) VALUES (2, N'cashier', N'Đà Nẵng, Việt Nam', N'', N'Cashier', CAST(0x25340B00 AS Date), N'cashier')
INSERT [dbo].[Userr] ([id], [name], [address], [phone], [role], [birth], [password]) VALUES (3, N'employee', N'Đà Nẵng, Việt Nam', N'', N'Employee', CAST(0xE0400B00 AS Date), N'')
INSERT [dbo].[Userr] ([id], [name], [address], [phone], [role], [birth], [password]) VALUES (4, N'employee2', N'Đà Nẵng, Việt Nam', N'', N'Employee', CAST(0xE0400B00 AS Date), N'')
SET IDENTITY_INSERT [dbo].[Userr] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [UserRole]) VALUES (1, N'All')
INSERT [dbo].[UserRole] ([Id], [UserRole]) VALUES (2, N'Administrator')
INSERT [dbo].[UserRole] ([Id], [UserRole]) VALUES (3, N'Cashier')
INSERT [dbo].[UserRole] ([Id], [UserRole]) VALUES (4, N'Employee')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
/****** Object:  Trigger [dbo].[total]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[total]
on [dbo].[Cash]
for insert, update, delete
as
begin
	update dbo.Cash set Total = Quantity * Price
end

GO
/****** Object:  Trigger [dbo].[total3]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[total3]
on [dbo].[Revenue]
for insert, update, delete
as
begin
	update dbo.Revenue set Total = Quantity * Price
end

GO
/****** Object:  Trigger [dbo].[total2]    Script Date: 21-Jul-22 6:53:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[total2]
on [dbo].[TemporaryData]
for insert, update, delete
as
begin
	update dbo.TemporaryData set Total = Quantity * Price
end

GO
USE [master]
GO
ALTER DATABASE [QuanLyCuaHangPet] SET  READ_WRITE 
GO
