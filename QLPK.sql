USE [master]
GO
/****** Object:  Database [QLPhongKhamT]    Script Date: 5/1/2018 10:15:52 PM ******/
CREATE DATABASE [QLPhongKhamT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLPhongKhamT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER_2\MSSQL\DATA\QLPhongKhamT.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPhongKhamT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER_2\MSSQL\DATA\QLPhongKhamT_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPhongKhamT] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPhongKhamT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPhongKhamT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLPhongKhamT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLPhongKhamT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLPhongKhamT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLPhongKhamT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLPhongKhamT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET RECOVERY FULL 
GO
ALTER DATABASE [QLPhongKhamT] SET  MULTI_USER 
GO
ALTER DATABASE [QLPhongKhamT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLPhongKhamT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLPhongKhamT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLPhongKhamT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLPhongKhamT', N'ON'
GO
USE [QLPhongKhamT]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClinicalExamination]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicalExamination](
	[ClinicalExaminationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nchar](10) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ClinicalExaminationType] PRIMARY KEY CLUSTERED 
(
	[ClinicalExaminationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClinicalExaminationResult]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicalExaminationResult](
	[ClinicalExaminationResultID] [int] IDENTITY(1,1) NOT NULL,
	[ClinicalExaminationID] [int] NOT NULL,
	[Result] [nvarchar](500) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[ExaminationResultID] [int] NOT NULL,
 CONSTRAINT [PK_ClinicalExamination] PRIMARY KEY CLUSTERED 
(
	[ClinicalExaminationResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drug]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drug](
	[DrugID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Price] [money] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_Drug] PRIMARY KEY CLUSTERED 
(
	[DrugID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[BirthDay] [date] NOT NULL,
	[IdentifyCard] [nchar](10) NOT NULL,
	[Phone] [nchar](11) NOT NULL,
	[Position] [int] NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Gender] [bit] NOT NULL,
	[RoomID] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExaminationResult]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExaminationResult](
	[ExaminationResultID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NOT NULL,
	[PatientID] [int] NOT NULL,
	[DoctorID] [int] NOT NULL,
	[DispenserID] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[Result] [nvarchar](50) NULL,
 CONSTRAINT [PK_ExaminationResult] PRIMARY KEY CLUSTERED 
(
	[ExaminationResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartientOfDay]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartientOfDay](
	[PartientID] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
 CONSTRAINT [PK_PartientOfDay] PRIMARY KEY CLUSTERED 
(
	[Number] ASC,
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[IdentifyCard] [nchar](10) NULL,
	[Phone] [nchar](11) NULL,
	[Address] [nvarchar](250) NULL,
	[Gender] [bit] NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrescriptionDetail]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrescriptionDetail](
	[PrescriptionDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ExaminationResultID] [int] NOT NULL,
	[DrugID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [money] NULL,
	[Dosage] [nvarchar](50) NULL,
	[Usage] [nvarchar](50) NULL,
 CONSTRAINT [PK_PrescriptionDetail] PRIMARY KEY CLUSTERED 
(
	[PrescriptionDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[Room] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeOfDrug]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfDrug](
	[TypeOfDrugID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TypeOfDrug] PRIMARY KEY CLUSTERED 
(
	[TypeOfDrugID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkSchedule]    Script Date: 5/1/2018 10:15:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSchedule](
	[WorkScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
 CONSTRAINT [PK_WorkSchedule] PRIMARY KEY CLUSTERED 
(
	[WorkScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([UserName], [Password], [EmployeeID]) VALUES (N'admin               ', N'admin', 1)
INSERT [dbo].[Account] ([UserName], [Password], [EmployeeID]) VALUES (N'duclt               ', N'123456', 2)
SET IDENTITY_INSERT [dbo].[Drug] ON 

INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (4, N'Fentanyl', N'Injectable Tiêm; ống 0,1mg/2ml', 15000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (6, N'Halothan  ', N'Respiratory Đường hô hấp; lọ 250ml', 2000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (7, N'Ketamin   ', N'Ịnjectable Tiêm; 50mg/ml ống 10ml ', 2500.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (27, N'Oxygen    ', N'Respiratory Spray Đường hô hấp; bình khí hoá lỏng', 2500.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (29, N'Thiopental', N'Injectable Tiêm; lọ 500mg, 1g bột pha tiêm', 4000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (31, N'Bupivacain', N'Injectable Tiêm; dung dịch 0,25%, 0,50%, ống 4ml', 3500.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (35, N'Procain   ', N'Injectable Tiêm; dung dịch 1%, 3%, 5%, ống 1ml, 2ml', 7000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (36, N'Morphin   ', N'Injectable Tiêm; ống 10mg/ml', 15000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (37, N'Atropin   ', N'Injectable Tiêm; ống 0,25 mg/ml', 10000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (43, N'Diclofenac', N'Tablet Uống; viên 100mg, 500mg, gói 100mg', 12000.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (44, N'Ibuprofen ', N'Tablet Uống; viên 200mg, 400mg ', 7000.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (45, N'Meloxicam ', N'Tablet Uống, viên 7,5mg, 15mg', 25000.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (51, N'Paracetamo', N'Tablet Uống; viên 100mg, 500mg', 70000.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (54, N'Allopurino', N'Tablet Uống; viên 100mg, 300mg', 25000.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (55, N'Alimemazin', N'Tablet Uống; viên 5mg', 5000.0000, 3)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (57, N'Epinephrin', N'Injectable Tiêm; ống 1mg/ml', 7000.0000, 3)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (59, N'Prednisol ', N'Tablet Uống; viên 5mg', 18000.0000, 3)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (60, N'Dimercapro', N'Injectable Tiêm; ống 50mg/2ml', 45000.0000, 4)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (62, N'Methionin ', N'Tablet Uống; viên 250mg', 26000.0000, 4)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (63, N'Methylen  ', N'Injectable Tiêm, dung dịch 1%, ống 1ml', 57000.0000, 4)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (64, N'Valproic  ', N'Tablet Uống; viên 200mg, 500mg', 102000.0000, 5)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (65, N'Phenytoin ', N'Tablet Uống; viên 100mg', 64000.0000, 5)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (67, N'Niclosamid', N'Tablet Uống; viên 500mg', 21000.0000, 6)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (70, N'Diethylcar', N'Tablet Uống; viên 50mg, 100mg', 25000.0000, 6)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (71, N'Cefaclor  ', N'Tablet Uống; viên 250mg, 500mg', 12000.0000, 6)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (72, N'Ergotamin ', N'Injectable Tiêm; ống 0,5mg/ml', 13000.0000, 7)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (74, N'Propranolo', N'Tablet Uống; viên 20mg, 40mg', 16000.0000, 7)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (75, N'Cisplatin ', N'Injectable Tiêm; ống 10mg, 50mg', 22000.0000, 7)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (77, N'Tamoxifen ', N'Tablet Uống; viên 10mg, 20mg', 9000.0000, 8)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (78, N'Mitomycin ', N'Powder Injectable Tiêm; lọ 2mg, 10mg bột pha tiêm', 8000.0000, 8)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (79, N'Filgrastim', N'Injectable Tiêm;ống 30IU/ml', 10000.0000, 8)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (81, N'Biperiden ', N'Tablet Uống; viên 2mg, 4mg', 22000.0000, 9)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (82, N'Carbidopa ', N'Tablet Uống; viên 25mg và 250mg', 15000.0000, 9)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (83, N'Acid Folic', N'Tablet Uống; viên 1mg, 5mg ', 5000.0000, 10)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (84, N'Warfarin  ', N'Tablet Uống; viên 1mg, 2mg, 5 mg', 7000.0000, 10)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (85, N'Albumin   ', N'Injectable Tiêm; dung dịch 5%, 25 %, chai 50ml, 100ml', 200000.0000, 11)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (86, N'Dextran 70', N'Perfusion Truyền; dung dịch 6%, chai 250ml, 500ml ', 250000.0000, 11)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (87, N'Atenolol  ', N'Tablet Uống; viên 50mg, 100mg', 33000.0000, 12)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (88, N'Captopril ', N'Tablet Uống; viên 25mg, 50mg', 22000.0000, 12)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (89, N'Cồn BSI   ', N'Topical Solution Dùng ngoài; lọ 15ml', 7000.0000, 13)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (90, N'Kẽm oxyd  ', N'Topical Pommade Dùng ngoài; mỡ, tuýp 15g', 11000.0000, 13)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (91, N'Iohexol   ', N'Injectable Tiêm; ống 5,82g, 7,77g/15ml, 6,47g/10ml', 6000.0000, 14)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (92, N'Cồn iod   ', N'Topical Solution Dùng ngoài; dung dịch 2,5%, lọ 15ml', 8000.0000, 15)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (93, N'Manitol   ', N'Perfusion Tiêm truyền; dung dịch 10%, 20%', 42000.0000, 16)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (94, N'Cimetidin ', N'Tablet Uống; viên 200mg, 400mg', 96000.0000, 17)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (96, N'Ranitidin ', N'Tablet Uống; viên 150mg, 300mg', 78000.0000, 17)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (98, N'Prednisol ', N'Tablet Uống; viên 1mg, 5mg', 39000.0000, 18)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (99, N'Levonor   ', N'Tablet Uống; viên 0,03mg', 43000.0000, 18)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (100, N'Vaccin tả ', N'Oral Solution Dung dịch uống', 34000.0000, 19)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (101, N'Pancuron  ', N'Injectable Tiêm; ống 4mg/2ml', 6400.0000, 20)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (102, N'Argyrol   ', N'Collyre (Ophthalmic solution) Nhỏ mắt; dung dịch 3%', 3300.0000, 21)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (103, N'Timolol   ', N'Collyre (Ophthalmic solution) Nhỏ mắt; dung dịch 0,25%, 0,5%', 5500.0000, 21)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (106, N'Oxytocin  ', N'Injectable Tiêm; ống 5IU, 10IU/ml', 2200.0000, 23)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (109, N'Valproic  ', N'Tablet Uống; viên 200mg, 500mg', 6200.0000, 24)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (110, N'Terbutalin', N'Injectable Tiêm; ống 0,5mg/ml', 25000.0000, 25)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (111, N'Dextrome  ', N'Tablet Uống; viên 15mg', 50000.0000, 25)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (112, N'Kaliclorid', N'Tablet Uống, viên 600mg', 44000.0000, 26)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (114, N'Vitamin A ', N'Coated Tablet Uống; viên bọc đường 5.000 IU', 78000.0000, 30)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (115, N'Vitamin C ', N'Tablet Uống; viên 50mg, 100mg, 500mg', 26000.0000, 31)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (122, N'Test      ', N'Panasetamol', 3001.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (123, N'Test      ', N'Panasetamol', 3001.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (124, N'Test      ', N'Panasetamol', 3001.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (125, N'Test      ', N'Panasetamol', 3001.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (126, N'ad        ', N'da', 23424.0000, 2)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (128, N'Test 123  ', N'Test 123', 100000.0000, 16)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (130, N'test 1/5  ', N'', 3000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (132, N'Tiêu chảy ', N'', 2000.0000, 1)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (133, N'Test Thuốc tiêu chảy', N'', 3000.0000, 17)
INSERT [dbo].[Drug] ([DrugID], [Name], [Description], [Price], [TypeID]) VALUES (134, N'123', N'123', 1230.0000, 1)
SET IDENTITY_INSERT [dbo].[Drug] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [MiddleName], [BirthDay], [IdentifyCard], [Phone], [Position], [Address], [Gender], [RoomID], [Active]) VALUES (1, N'Nguyễn ', N'An', N'Văn', CAST(0x241A0B00 AS Date), N'1245124651', N'01664247985', 1, N'245 Q3 TpHCM', 1, 1, 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [MiddleName], [BirthDay], [IdentifyCard], [Phone], [Position], [Address], [Gender], [RoomID], [Active]) VALUES (2, N'Luong', N'Thành', N'Đức', CAST(0x5F160B00 AS Date), N'2145412486', N'0909451468 ', 2, N'26e Q9 TpHCM', 0, 2, 1)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [MiddleName], [BirthDay], [IdentifyCard], [Phone], [Position], [Address], [Gender], [RoomID], [Active]) VALUES (3, N'Tri', N'Nguyen', N'Dang', CAST(0x7A1E0B00 AS Date), N'2132312312', N'02321312132', 3, N'12 Nguyen Van troi', 1, 3, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[ExaminationResult] ON 

INSERT [dbo].[ExaminationResult] ([ExaminationResultID], [Time], [PatientID], [DoctorID], [DispenserID], [Description], [Result]) VALUES (1, CAST(0x0000A89D00000000 AS DateTime), 1, 1, 1, N'Viêm dạ dày', N'Viêm loét dạ dày')
SET IDENTITY_INSERT [dbo].[ExaminationResult] OFF
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (1, 1, 1)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (3, 1, 2)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (4, 1, 3)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (2, 1, 4)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (5, 1, 5)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (7, 2, 1)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (8, 2, 2)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (9, 2, 3)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (7, 2, 4)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (10, 2, 5)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (11, 3, 1)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (13, 3, 2)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (13, 3, 3)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (19, 3, 4)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (19, 3, 5)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (8, 4, 1)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (1, 4, 2)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (2, 4, 3)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (23, 4, 4)
INSERT [dbo].[PartientOfDay] ([PartientID], [Number], [RoomID]) VALUES (24, 4, 5)
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (1, N'Nguyễn ', N'Ân', N'Đắc Hồng', N'154847849 ', N'01664348980', N'Gò vấp TpHCM', 0)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (2, N'Phan', N'Thằng', N'Đức', N'245146847 ', N'0909465874 ', N'Thủ đức', 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (3, N'Nguyen', N'Tri', N'Dang', N'123123134 ', N'09334143234', N'Go vap', 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (4, N'An', N'Nguyen', NULL, N'123456    ', N'0936051328 ', N'123 Nguyen Van cong', 0)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (5, N'An', N'Nguyen', N'Dac Hong', N'12345678  ', N'0936051328 ', N'123 Nguyen Van cong', 0)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (7, N'Tri', N'Nguyen', NULL, N'124233214 ', N'0932524344 ', NULL, 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (8, N'Thuan', N'Nguyen', NULL, N'3114343543', N'094325242  ', NULL, 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (9, N'Thanh', N'Lê', N'Tất', N'1314123434', N'12343543   ', N'12 Nguyễn Văn Công', 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (10, N'Thanh', N'Le', NULL, N'1314123434', NULL, NULL, 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (11, N'Thanh', N'Le', NULL, N'1314123434', NULL, NULL, 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (13, N'An', N'nguyen', NULL, N'35232345  ', NULL, NULL, 0)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (19, N'QQQQ', N'213', N'123', N'12341     ', NULL, NULL, 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (23, N'Tri', N'Nguyen', NULL, N'12515231  ', NULL, NULL, 1)
INSERT [dbo].[Patient] ([PatientID], [FirstName], [LastName], [MiddleName], [IdentifyCard], [Phone], [Address], [Gender]) VALUES (24, N'Ngân', N'Nguyễn', N'', N'323244    ', N'14324332   ', N'12 Gò Vấp', 0)
SET IDENTITY_INSERT [dbo].[Patient] OFF
SET IDENTITY_INSERT [dbo].[PrescriptionDetail] ON 

INSERT [dbo].[PrescriptionDetail] ([PrescriptionDetailID], [ExaminationResultID], [DrugID], [Quantity], [Day], [Description], [Price], [Dosage], [Usage]) VALUES (4, 1, 4, 4, 3, N'Trị Viêm', 25000.0000, N'Dosaque do', N'Usaqeu')
SET IDENTITY_INSERT [dbo].[PrescriptionDetail] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomID], [Room]) VALUES (1, N'XN-01     ')
INSERT [dbo].[Room] ([RoomID], [Room]) VALUES (2, N'PK-RHM    ')
INSERT [dbo].[Room] ([RoomID], [Room]) VALUES (3, N'PK-TMH    ')
INSERT [dbo].[Room] ([RoomID], [Room]) VALUES (4, N'PK-NK     ')
INSERT [dbo].[Room] ([RoomID], [Room]) VALUES (5, N'PK-NoiK   ')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[TypeOfDrug] ON 

INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (1, N'THUỐC GÂY MÊ, TÊ', N'Bao gồm các nhóm Thuốc gây mê và oxygen, Thuốc gây tê tại chỗ,Thuốc tiền mê')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (2, N'THUỐC GIẢM ĐAU, HẠ SỐT, NHÓM CHỐNG VIÊM ', N'Bao gồm các nhóm Thuốc giảm đau không có opi, hạ sốt, chống viêm không steroid,  Thuốc giảm đau loại opi,Thuốc điều trị bệnh gút')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (3, N'THUỐC CHỐNG DỊ ỨNG', N'Bao gồm các nhóm thuốc chống dị ứng và trường hợp quá mẫn cảm với thuốc')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (4, N'THUỐC GIẢI ĐỘC', N'Bao gồm các nhóm Thuốc giải độc đặc hiệu, và Thuốc giải độc không đặc hiệu')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (5, N'THUỐC CHỐNG ĐỘNG KINH', N'Bao gồm các nhóm thuốc chống động kinh')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (6, N'THUỐC TRỊ KÝ SINH TRÙNG, CHỐNG NHIỄM KHUẨN', N'Bao gồm các nhóm Thuốc trị giun, sán,Thuốc chống nhiễm khuẩn,Thuốc chống nấm,Thuốc điều trị bệnh do động vật nguyên sinh,Thuốc chống virus')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (7, N'THUỐC ĐIỀU TRỊ ĐAU NỬA ĐẦU', N'Bao gồm các nhóm thuốc điều trị cơn đau cấp,Thuốc phòng bệnh')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (8, N'THUỐC TÁC DỤNG ĐỐI VỚI MÁU', N'Bao gồm các nhóm Thuốc chống thiếu máu,Thuốc tác dụng lên quá trình đông máu và các loại khác')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (9, N'CHẾ PHẨM MÁU – DUNG DỊCH CAO PHÂN TỬ', N'Bao gồm các nhóm Dung dịch cao phân tử,Chế phẩm máu,')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (10, N'THUỐC TIM MẠCH', N'Bao gồm các nhóm thuốc chống đau thắt ngực,Thuốc chống loạn nhịpThuốc điều trị tăng huyết áp,Thuốc điều trị hạ huyết áp,Thuốc điều trị suy tim,Thuốc chống huyết khối,Thuốc hạ lipit máu')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (11, N'THUỐC CHỐNG PARKINSON', N'Bao gồm các nhóm thuốc chống Parkinson')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (12, N'THUỐC CHỐNG UNG THƯ ', N'Bao gồm các nhóm thuốc ức chế miễn dịch,Thuốc chống ung thư,Thuốc hỗ trợ trong điều trị ung thư')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (13, N'THUỐC NGOÀI DA', N'Bao gồm các nhóm thuốc chống nấm,Thuốc chống nhiễm khuẩn,Thuốc chống viêm ngứa,Thuốc có tác dụng làm tiêu sừng,Thuốc trị ghẻ và Thuốc có tác dụng ngăn tia tử ngoại')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (14, N'THUỐC DÙNG CHẨN ĐOÁN', N'Bao gồm các nhóm thuốc dùng cho mắt,Thuốc cản quang')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (15, N'THUỐC TẨY TRÙNG VÀ KHỬ TRÙNG', N'Bao gồm các nhóm thuốc tẩy trùng và khử trùng')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (16, N'THUỐC LỢI TIỂU', N'Bao gồm các nhóm thuốc lợi tiểu')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (17, N'THUỐC ĐƯỜNG TIÊU HOÁ', N'Bao gồm các nhóm thuốc chống loét dạ dày, tá tràng, thuốc chống nôn,thuốc chống co thắt,thuốc tẩy, nhuận tràng và thuốc tiêu chảy')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (18, N'HORMON, NỘI TIẾT TỐ, THUỐC TRÁNH THỤ THAI', N'Bao gồm các nhóm Hormon thượng thận và những chất tổng hợp thay thế, Các chất Androgen, Thuốc tránh thai,Chất estrogen,Insulin và thuốc hạ đường huyết')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (19, N'SINH PHẨM MIỄN DỊCH', N'Bao gồm các nhóm thuốc Huyết thanh và Globulin miễn dịch')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (20, N'THUỐC GIÃN CƠ VÀ TĂNG TRƯƠNG LỰC CƠ', N'Bao gồm các nhóm thuốc giãn cơ và tăng trương lực cơ')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (21, N'THUỐC DÙNG CHO MẮT,TAI MŨI HỌNG', N'Bao gồm các nhóm thuốc chống nhiễm khuẩn, kháng virus,Thuốc chống viêm,Thuốc làm co đồng tử và giảm nhãn áp')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (23, N'THUỐC CÓ TÁC DỤNG THÚC ĐẺ, CẦM MÁU SAU SINH', N'Bao gồm các nhóm thuốc thúc đẻ, cầm máu sau đẻ,Thuốc chống đẻ non')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (24, N'DUNG DỊCH TẤM PHÂN MÀNG BỤNG', N'Bao gồm các nhóm thuốc lọc thận')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (25, N'THUỐC CO\HỐNG RỐI LOẠN TÂM THẦN', N'Bao gồm các nhóm thuốc chống loạn thần,Thuốc chống trầm cảm,Thuốc điều trị ám ảnh và hoảng loạn thần kinh')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (26, N'THUỐC TÁC DỤNG TRÊN ĐƯỜNG HÔ HẤP', N'Bao gồm các nhóm thuốc chữa hen,Thuốc chữa ho')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (30, N'DUNG DỊCH ĐIỀU CHỈNH NƯỚC ĐIỆN GIẢI, CÂN BẰNG ACID', N'Bao gồm các nhóm thuốc uống, Thuốc tiêm truyền')
INSERT [dbo].[TypeOfDrug] ([TypeOfDrugID], [Type], [Description]) VALUES (31, N'VITAMIN VÀ CÁC CHẤT VÔ CƠ', N'Bao gồm các nhóm Vitamin')
SET IDENTITY_INSERT [dbo].[TypeOfDrug] OFF
/****** Object:  Index [IX_Employee]    Script Date: 5/1/2018 10:15:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employee] ON [dbo].[Employee]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Employee]
GO
ALTER TABLE [dbo].[ClinicalExaminationResult]  WITH CHECK ADD  CONSTRAINT [FK_ClinicalExamination_ExaminationResult] FOREIGN KEY([ExaminationResultID])
REFERENCES [dbo].[ExaminationResult] ([ExaminationResultID])
GO
ALTER TABLE [dbo].[ClinicalExaminationResult] CHECK CONSTRAINT [FK_ClinicalExamination_ExaminationResult]
GO
ALTER TABLE [dbo].[ClinicalExaminationResult]  WITH CHECK ADD  CONSTRAINT [FK_ClinicalExaminationResult_ClinicalExamination] FOREIGN KEY([ClinicalExaminationID])
REFERENCES [dbo].[ClinicalExamination] ([ClinicalExaminationTypeID])
GO
ALTER TABLE [dbo].[ClinicalExaminationResult] CHECK CONSTRAINT [FK_ClinicalExaminationResult_ClinicalExamination]
GO
ALTER TABLE [dbo].[Drug]  WITH CHECK ADD  CONSTRAINT [FK_Drug_TypeOfDrug] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeOfDrug] ([TypeOfDrugID])
GO
ALTER TABLE [dbo].[Drug] CHECK CONSTRAINT [FK_Drug_TypeOfDrug]
GO
ALTER TABLE [dbo].[ExaminationResult]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationResult_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[ExaminationResult] CHECK CONSTRAINT [FK_ExaminationResult_Patient]
GO
ALTER TABLE [dbo].[PartientOfDay]  WITH CHECK ADD  CONSTRAINT [FK_PartientOfDay_Patient] FOREIGN KEY([PartientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[PartientOfDay] CHECK CONSTRAINT [FK_PartientOfDay_Patient]
GO
ALTER TABLE [dbo].[PrescriptionDetail]  WITH CHECK ADD  CONSTRAINT [FK_PrescriptionDetail_Drug] FOREIGN KEY([DrugID])
REFERENCES [dbo].[Drug] ([DrugID])
GO
ALTER TABLE [dbo].[PrescriptionDetail] CHECK CONSTRAINT [FK_PrescriptionDetail_Drug]
GO
ALTER TABLE [dbo].[PrescriptionDetail]  WITH CHECK ADD  CONSTRAINT [FK_PrescriptionDetail_ExaminationResult] FOREIGN KEY([ExaminationResultID])
REFERENCES [dbo].[ExaminationResult] ([ExaminationResultID])
GO
ALTER TABLE [dbo].[PrescriptionDetail] CHECK CONSTRAINT [FK_PrescriptionDetail_ExaminationResult]
GO
ALTER TABLE [dbo].[WorkSchedule]  WITH CHECK ADD  CONSTRAINT [FK_WorkSchedule_Employee1] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[WorkSchedule] CHECK CONSTRAINT [FK_WorkSchedule_Employee1]
GO
ALTER TABLE [dbo].[WorkSchedule]  WITH CHECK ADD  CONSTRAINT [FK_WorkSchedule_Room1] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[WorkSchedule] CHECK CONSTRAINT [FK_WorkSchedule_Room1]
GO
USE [master]
GO
ALTER DATABASE [QLPhongKhamT] SET  READ_WRITE 
GO
