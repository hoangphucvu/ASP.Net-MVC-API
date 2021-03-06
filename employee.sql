USE [master]
GO
/****** Object:  Database [EmployeeManagement]    Script Date: 6/24/2016 4:32:44 PM ******/
CREATE DATABASE [EmployeeManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EmployeeManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmployeeManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EmployeeManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmployeeManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EmployeeManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EmployeeManagement]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/24/2016 4:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[MiddleName] [nvarchar](10) NULL,
	[LastName] [nvarchar](10) NOT NULL,
	[DOB] [date] NOT NULL,
	[Gender] [bit] NOT NULL,
	[StartDate] [date] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [StartDate]) VALUES (1, N'Nguyen', N'Van', N'An', CAST(N'1995-03-12' AS Date), 1, CAST(N'2016-06-13' AS Date))
INSERT [dbo].[Employee] ([ID], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [StartDate]) VALUES (2, N'Hoang', N'Minh', N'Vu', CAST(N'1994-03-20' AS Date), 1, CAST(N'2016-06-13' AS Date))
INSERT [dbo].[Employee] ([ID], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [StartDate]) VALUES (3, N'Son', N'Minh', N'Anh', CAST(N'1995-03-12' AS Date), 1, CAST(N'2016-06-13' AS Date))
INSERT [dbo].[Employee] ([ID], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [StartDate]) VALUES (4, N'Hoang', N'Nguyen', N'Phuong', CAST(N'1994-06-13' AS Date), 0, CAST(N'2016-06-13' AS Date))
SET IDENTITY_INSERT [dbo].[Employee] OFF
USE [master]
GO
ALTER DATABASE [EmployeeManagement] SET  READ_WRITE 
GO
