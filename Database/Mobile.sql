USE [master]
GO
/****** Object:  Database [Mobile]    Script Date: 7/11/2023 11:31:13 PM ******/
CREATE DATABASE [Mobile]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mobile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Mobile.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mobile_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Mobile_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Mobile] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mobile].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mobile] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mobile] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mobile] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mobile] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mobile] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mobile] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mobile] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mobile] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mobile] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mobile] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mobile] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mobile] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mobile] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mobile] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mobile] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mobile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mobile] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mobile] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mobile] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mobile] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mobile] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mobile] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mobile] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mobile] SET  MULTI_USER 
GO
ALTER DATABASE [Mobile] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mobile] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mobile] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mobile] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mobile] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mobile] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Mobile] SET QUERY_STORE = ON
GO
ALTER DATABASE [Mobile] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Mobile]
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 7/11/2023 11:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[couponId] [int] NOT NULL,
	[couponValue] [varchar](50) NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Coupon] PRIMARY KEY CLUSTERED 
(
	[couponId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 7/11/2023 11:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[memberId] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[phNo] [varchar](50) NULL,
	[otp] [varchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberCoupon]    Script Date: 7/11/2023 11:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberCoupon](
	[memberId] [int] NULL,
	[couponId] [int] NULL,
	[redemptionDate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OTP]    Script Date: 7/11/2023 11:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OTP](
	[memberId] [int] NULL,
	[otpCode] [varchar](50) NULL,
	[expireTimeStamp] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseHistory]    Script Date: 7/11/2023 11:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseHistory](
	[purchaseId] [int] IDENTITY(1,1) NOT NULL,
	[memberId] [int] NULL,
	[purchaseDetails] [varchar](50) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_PurchaseHistory] PRIMARY KEY CLUSTERED 
(
	[purchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OTP]  WITH CHECK ADD  CONSTRAINT [FK_OTP_Member] FOREIGN KEY([memberId])
REFERENCES [dbo].[Member] ([memberId])
GO
ALTER TABLE [dbo].[OTP] CHECK CONSTRAINT [FK_OTP_Member]
GO
ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Member] FOREIGN KEY([memberId])
REFERENCES [dbo].[Member] ([memberId])
GO
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Member]
GO
USE [master]
GO
ALTER DATABASE [Mobile] SET  READ_WRITE 
GO
