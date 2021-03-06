USE [master]
GO
/****** Object:  Database [TaxCalculator]    Script Date: 2019/01/16 22:51:05 ******/
CREATE DATABASE [TaxCalculator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaxCalculator', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TaxCalculator.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaxCalculator_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TaxCalculator_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TaxCalculator] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaxCalculator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaxCalculator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaxCalculator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaxCalculator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaxCalculator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaxCalculator] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaxCalculator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaxCalculator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaxCalculator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaxCalculator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaxCalculator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaxCalculator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaxCalculator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaxCalculator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaxCalculator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaxCalculator] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaxCalculator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaxCalculator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaxCalculator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaxCalculator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaxCalculator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaxCalculator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaxCalculator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaxCalculator] SET RECOVERY FULL 
GO
ALTER DATABASE [TaxCalculator] SET  MULTI_USER 
GO
ALTER DATABASE [TaxCalculator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaxCalculator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaxCalculator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaxCalculator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaxCalculator] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TaxCalculator', N'ON'
GO
ALTER DATABASE [TaxCalculator] SET QUERY_STORE = OFF
GO
USE [TaxCalculator]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TaxCalculator]
GO
/****** Object:  Table [dbo].[LupCalculationType]    Script Date: 2019/01/16 22:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LupCalculationType](
	[TaxTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TaxTypeName] [varchar](100) NULL,
 CONSTRAINT [PK_LupCalculationType] PRIMARY KEY CLUSTERED 
(
	[TaxTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LupPostalCode]    Script Date: 2019/01/16 22:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LupPostalCode](
	[PostalCodeId] [int] IDENTITY(1,1) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[TaxTypeId] [int] NOT NULL,
 CONSTRAINT [PK_LupPostalCode] PRIMARY KEY CLUSTERED 
(
	[PostalCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LupRate]    Script Date: 2019/01/16 22:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LupRate](
	[RateId] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](8, 2) NOT NULL,
	[FromRate] [decimal](18, 2) NOT NULL,
	[ToRate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_LupRate] PRIMARY KEY CLUSTERED 
(
	[RateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxCalculation]    Script Date: 2019/01/16 22:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxCalculation](
	[TaxCalculationId] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Name] [varchar](50) NULL,
	[TaxCalculated] [decimal](18, 2) NOT NULL,
	[AnnualIncome] [decimal](18, 2) NOT NULL,
	[CalculationType] [varchar](100) NULL,
 CONSTRAINT [PK_TaxCalculation] PRIMARY KEY CLUSTERED 
(
	[TaxCalculationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LupCalculationType] ON 
GO
INSERT [dbo].[LupCalculationType] ([TaxTypeId], [TaxTypeName]) VALUES (1, N'Progressive')
GO
INSERT [dbo].[LupCalculationType] ([TaxTypeId], [TaxTypeName]) VALUES (2, N'Flat Rate')
GO
INSERT [dbo].[LupCalculationType] ([TaxTypeId], [TaxTypeName]) VALUES (3, N'Flat Value')
GO
SET IDENTITY_INSERT [dbo].[LupCalculationType] OFF
GO
SET IDENTITY_INSERT [dbo].[LupPostalCode] ON 
GO
INSERT [dbo].[LupPostalCode] ([PostalCodeId], [PostalCode], [TaxTypeId]) VALUES (1, N'7441', 1)
GO
INSERT [dbo].[LupPostalCode] ([PostalCodeId], [PostalCode], [TaxTypeId]) VALUES (2, N'A100', 3)
GO
INSERT [dbo].[LupPostalCode] ([PostalCodeId], [PostalCode], [TaxTypeId]) VALUES (3, N'7000', 2)
GO
INSERT [dbo].[LupPostalCode] ([PostalCodeId], [PostalCode], [TaxTypeId]) VALUES (4, N'1000', 1)
GO
SET IDENTITY_INSERT [dbo].[LupPostalCode] OFF
GO
SET IDENTITY_INSERT [dbo].[LupRate] ON 
GO
INSERT [dbo].[LupRate] ([RateId], [Rate], [FromRate], [ToRate]) VALUES (1, CAST(10.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(8350.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[LupRate] ([RateId], [Rate], [FromRate], [ToRate]) VALUES (2, CAST(15.00 AS Decimal(8, 2)), CAST(8351.00 AS Decimal(18, 2)), CAST(33950.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[LupRate] ([RateId], [Rate], [FromRate], [ToRate]) VALUES (3, CAST(25.00 AS Decimal(8, 2)), CAST(33951.00 AS Decimal(18, 2)), CAST(82250.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[LupRate] ([RateId], [Rate], [FromRate], [ToRate]) VALUES (4, CAST(28.00 AS Decimal(8, 2)), CAST(82251.00 AS Decimal(18, 2)), CAST(171550.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[LupRate] ([RateId], [Rate], [FromRate], [ToRate]) VALUES (5, CAST(33.00 AS Decimal(8, 2)), CAST(171551.00 AS Decimal(18, 2)), CAST(372950.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[LupRate] ([RateId], [Rate], [FromRate], [ToRate]) VALUES (6, CAST(35.00 AS Decimal(8, 2)), CAST(372951.00 AS Decimal(18, 2)), CAST(999999999.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[LupRate] OFF
GO
SET IDENTITY_INSERT [dbo].[TaxCalculation] ON 
GO
INSERT [dbo].[TaxCalculation] ([TaxCalculationId], [DateCreated], [Name], [TaxCalculated], [AnnualIncome], [CalculationType]) VALUES (13, CAST(N'2019-01-16T22:46:27.360' AS DateTime), N'jefff', CAST(14000.00 AS Decimal(18, 2)), CAST(56000.00 AS Decimal(18, 2)), N'progressive')
GO
INSERT [dbo].[TaxCalculation] ([TaxCalculationId], [DateCreated], [Name], [TaxCalculated], [AnnualIncome], [CalculationType]) VALUES (14, CAST(N'2019-01-16T22:46:54.007' AS DateTime), N'kiran', CAST(2800.00 AS Decimal(18, 2)), CAST(56000.00 AS Decimal(18, 2)), N'flatvalue')
GO
INSERT [dbo].[TaxCalculation] ([TaxCalculationId], [DateCreated], [Name], [TaxCalculated], [AnnualIncome], [CalculationType]) VALUES (15, CAST(N'2019-01-16T22:47:47.643' AS DateTime), N'bobb', CAST(14000.00 AS Decimal(18, 2)), CAST(56000.00 AS Decimal(18, 2)), N'progressive')
GO
INSERT [dbo].[TaxCalculation] ([TaxCalculationId], [DateCreated], [Name], [TaxCalculated], [AnnualIncome], [CalculationType]) VALUES (16, CAST(N'2019-01-16T22:48:12.830' AS DateTime), N'fish', CAST(875.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), N'flatrate')
GO
SET IDENTITY_INSERT [dbo].[TaxCalculation] OFF
GO
ALTER TABLE [dbo].[LupPostalCode]  WITH CHECK ADD  CONSTRAINT [FK_LupPostalCode_LupCalculationType] FOREIGN KEY([TaxTypeId])
REFERENCES [dbo].[LupCalculationType] ([TaxTypeId])
GO
ALTER TABLE [dbo].[LupPostalCode] CHECK CONSTRAINT [FK_LupPostalCode_LupCalculationType]
GO
USE [master]
GO
ALTER DATABASE [TaxCalculator] SET  READ_WRITE 
GO
