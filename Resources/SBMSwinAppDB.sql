USE [master]
GO
/****** Object:  Database [SBMSwinAppDb]    Script Date: 11/14/2019 8:38:05 PM ******/
CREATE DATABASE [SBMSwinAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SBMSwinAppDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MDSHAHADAT\MSSQL\DATA\SBMSwinAppDb.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SBMSwinAppDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MDSHAHADAT\MSSQL\DATA\SBMSwinAppDb_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SBMSwinAppDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SBMSwinAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SBMSwinAppDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SBMSwinAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SBMSwinAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SBMSwinAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SBMSwinAppDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET RECOVERY FULL 
GO
ALTER DATABASE [SBMSwinAppDb] SET  MULTI_USER 
GO
ALTER DATABASE [SBMSwinAppDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SBMSwinAppDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SBMSwinAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SBMSwinAppDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SBMSwinAppDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SBMSwinAppDb', N'ON'
GO
USE [SBMSwinAppDb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](25) NULL,
	[Name] [varchar](40) NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Contact] [varchar](100) NULL,
	[LoyaltyPoint] [float] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [varchar](50) NULL,
	[ReorderLevel] [int] NOT NULL,
	[Description] [varchar](100) NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseDetails]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseID] [int] NULL,
	[ProductID] [int] NULL,
	[ManufactureDate] [date] NULL,
	[ExpireDate] [date] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[MRP] [float] NULL,
	[Remark] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](25) NULL,
	[Date] [date] NOT NULL,
	[InvoiceNo] [varchar](25) NULL,
	[SupplierID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](25) NULL,
	[Date] [date] NULL,
	[CustomerID] [int] NULL,
	[PaidAmount] [float] NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SalesID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [float] NULL,
	[MRP] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suppliers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](25) NULL,
	[Name] [varchar](40) NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Contact] [varchar](100) NULL,
	[ContactPerson] [varchar](100) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ProductsView]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProductsView]
AS SELECT p.ID, p.Code, p.Name, ReorderLevel, Description, CategoryID, c.Name as CategoryName
FROM Products p, Categories c
WHERE p.CategoryID=c.ID;

GO
/****** Object:  View [dbo].[SalesDetailsRecord]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[SalesDetailsRecord] as
Select sd.SalesID as SalesID, pv.Name as ProductName, pv.CategoryName as Category, Quantity, MRP, (Quantity*MRP) as TotalMRP
From SalesDetails as sd
Left Join Sales as s on s.ID=sd.SalesID
Left Join ProductsView as pv on pv.ID=sd.ProductID
GO
/****** Object:  View [dbo].[PurchaseView]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PurchaseView] AS
SELECT pu.ProductID as ProductID, pr.Name as ProductName, SUM(Quantity) AS Purchaseqty
FROM PurchaseDetails as pu, Products as pr
WHERE ProductID= pr.ID
GROUP BY ProductID, Name
GO
/****** Object:  View [dbo].[SalesView]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SalesView] AS
SELECT sa.ProductID as ProductID , pr.Name as ProductName, SUM(Quantity) AS SalesQty
FROM SalesDetails as sa, Products as pr
WHERE sa.ProductID= pr.ID
GROUP BY ProductID, Name
GO
/****** Object:  View [dbo].[AvailableQty]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[AvailableQty] as SELECT pv.ProductID, COALESCE(pv.Purchaseqty, 0) as PurchaseQty ,COALESCE(sv.SalesQty, 0) as SalesQty , COALESCE(pv.Purchaseqty - sv.SalesQty,pv.Purchaseqty) AS AvlQty
FROM   dbo.PurchaseView AS pv LEFT OUTER JOIN
             dbo.SalesView AS sv ON sv.ProductID = pv.ProductID
GO
/****** Object:  View [dbo].[PurchaseDetailsRecord]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create view [dbo].[PurchaseDetailsRecord] as
  Select pu.PurchaseID, p.Name, p.Code, pu.ManufactureDate, pu.ExpireDate, pu.Quantity, pu.UnitPrice, (pu.Quantity* pu.UnitPrice) as TotalPrice, MRP,Remark
  from PurchaseDetails as pu 
  Left join Products as p on pu.ProductID= p.ID
  Left join Purchases as pur on pu.PurchaseID=pur.ID
GO
/****** Object:  View [dbo].[PurchaseShortRecord]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PurchaseShortRecord]
AS
SELECT p.ID, p.Code AS PurchaseCode, p.Date AS PurchaseDate, p.InvoiceNo, s.Name AS SupplierName, SUM(pd.Quantity * pd.UnitPrice) AS Totalprice
FROM   dbo.Purchases AS p LEFT OUTER JOIN
             dbo.Suppliers AS s ON p.SupplierID = s.ID LEFT OUTER JOIN
             dbo.PurchaseDetails AS pd ON pd.PurchaseID = p.ID
WHERE (p.ID = pd.PurchaseID)
GROUP BY p.ID, p.Code, p.Date, p.InvoiceNo, s.Name

GO
/****** Object:  View [dbo].[PurchaseStockView]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[PurchaseStockView] as Select 
pd.ProductID as ProductID, p.Name as ProductName, c.Name as CategoryName, p.ReorderLevel,pd.ExpireDate, pu.Date as PurchaseDate, pd.Quantity as PurchaseQty
From PurchaseDetails as pd
Left Join Purchases as pu on pu.ID =pd.PurchaseID
Left Join Products as p on pd.ProductID =p.ID
Left Join Categories as c on p.CategoryID =c.ID
GO
/****** Object:  View [dbo].[ReportView]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create view [dbo].[ReportView] as   select pd.ProductID,p.Code as ProductCode, p.Name as Product,
  c.Name as Category,
  SUM(pd.Quantity) as PurchasedQty, COALESCE(SUM(sd.Quantity),0) as SoldQty, COALESCE(SUM(pd.Quantity-sd.Quantity),(SUM(pd.Quantity))) as AvailableQty,
   pd.UnitPrice,  ISNULL( sd.MRP,pd.MRP) as MRP,
    ISNULL( SUM(sd.Quantity*pd.UnitPrice),SUM(pd.Quantity*pd.UnitPrice)) as CostPrice,
     ISNULL( SUM(s.PaidAmount), 0) as SoldPrice,
	  ISNULL(SUM(s.PaidAmount- (sd.Quantity*pd.UnitPrice)),0) as ProfitOnSales,
	   SUM((pd.Quantity-ISNULL(sd.Quantity,0))* (ISNULL(sd.MRP,pd.MRP)-pd.UnitPrice)) as ProfitOnPurchase
  from PurchaseDetails as pd
  Left Join SalesDetails as sd on pd.ProductID=sd.ProductID
  Left join Sales as s on sd.SalesID =s.ID
  left join Products as p on pd.ProductID =p.ID
  Left join Categories as c on p.CategoryID =c.ID
  Group By pd.ProductID,p.Code, p.Name, c.Name, pd.UnitPrice, sd.MRP,pd.MRP
GO
/****** Object:  View [dbo].[ReportViewByDate]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   Create view [dbo].[ReportViewByDate] as select  pu.Date as PurchaseDate, pd.ProductID,p.Code as Code, p.Name as Product, c.Name as Category,pd.Quantity as PurchasedQty,
   sd.Quantity as SoldQty,pd.Quantity-sd.Quantity as AvailableQty, pd.UnitPrice, ISNULL(sd.MRP,pd.MRP) as MRP,
    sd.Quantity*pd.UnitPrice as CostPrice,  s.PaidAmount, (s.PaidAmount- (sd.Quantity*pd.UnitPrice)) as ProfitOnSales,
	 ((pd.Quantity-sd.Quantity)* (sd.MRP-pd.UnitPrice)) as ProfitOnPurchase, s.Date as SalesDate
  from PurchaseDetails as pd
  Left Outer Join Purchases as pu on pu.ID=pd.PurchaseID 
  Left Outer Join SalesDetails as sd on pd.ProductID=sd.ProductID
  Left Outer join Sales as s on sd.SalesID =s.ID
  left Outer join Products as p on pd.ProductID =p.ID
  Left Outer join Categories as c on p.CategoryID =c.ID
GO
/****** Object:  View [dbo].[SalesShortRecord]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[SalesShortRecord] as
Select s.ID as SalesID, s.Code as SalesCode, s.Date as SalesDate, c.Name as CustomerName, PaidAmount
From Sales as s
Left Join Customers as c on c.ID = s.CustomerID
GO
/****** Object:  View [dbo].[SalesStockView]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[SalesStockView] as Select 
sd.ProductID as ProductID, p.Name as ProductName, c.Name as CategoryName, p.ReorderLevel, s.Date as SalesDate, sd.Quantity as SalesQty
From SalesDetails as sd
Left Join Sales as s on s.ID =sd.SalesID
Left Join Products as p on sd.ProductID =p.ID
Left Join Categories as c on p.CategoryID =c.ID
GO
/****** Object:  View [dbo].[TestReportViewByDate]    Script Date: 11/14/2019 8:38:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view  [dbo].[TestReportViewByDate] as
SELECT pu.Date AS PurchaseDate, pd.ProductID, p.Code, p.Name AS Product, c.Name AS Category, pd.Quantity AS PurchasedQty,ISNULL(sd.Quantity,0) AS SoldQty , IsNull(pd.Quantity,0) - ISNULL(sd.Quantity,0) AS AvailableQty, pd.UnitPrice, ISNULL(sd.MRP, pd.MRP) AS MRP, 
             ISNULL( sd.Quantity, (IsNull(pd.Quantity,0) - ISNULL(sd.Quantity,0)))* pd.UnitPrice AS CostPrice, ISNULL(s.PaidAmount,0) as PaidAmount, ISNULL(s.PaidAmount,0) - ISNULL(sd.Quantity,0) * pd.UnitPrice AS ProfitOnSales, (pd.Quantity - isnull(sd.Quantity,0))  * (isnull(sd.MRP,pd.mrp) - pd.UnitPrice) AS ProfitOnPurchase, s.Date AS SalesDate
FROM   dbo.PurchaseDetails AS pd LEFT OUTER JOIN
             dbo.Purchases AS pu ON pu.ID = pd.PurchaseID LEFT OUTER JOIN
             dbo.SalesDetails AS sd ON pd.ProductID = sd.ProductID LEFT OUTER JOIN
             dbo.Sales AS s ON sd.SalesID = s.ID LEFT OUTER JOIN
             dbo.Products AS p ON pd.ProductID = p.ID LEFT OUTER JOIN
             dbo.Categories AS c ON p.CategoryID = c.ID
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (3022, N'CA01', N'Mobile')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (3023, N'CA02', N'Computer')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (4005, N'CA03', N'Storage')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (4019, N'CA05', N'Scaner')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (4020, N'CA06', N'Office Equipment')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (4021, N'CA04', N'Monitor')
INSERT [dbo].[Categories] ([ID], [Code], [Name]) VALUES (5011, N'CA07', N'Battery')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (1008, N'CU01', N'Basar Khan', N'Sukrabad', N'basar@gmail.com', N'10101010101', 73.5)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (1009, N'CU02', N'Shifat Mia', N'Kolabagan', N'shifat@gmail.com', N'12121212121', 100.5)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (1010, N'CU03', N'Rajib Sarker', N'Mohammadpur', N'rajib@gmail.com', N'23232323232', 21.5)
INSERT [dbo].[Customers] ([ID], [Code], [Name], [Address], [Email], [Contact], [LoyaltyPoint]) VALUES (1011, N'CU04', N'Shahadat', N'Dhanmondi 32', N'shahadat@gmail.com', N'01722358099', 20)
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2008, N'PR01', N'Samsung', 10, N'Good Product', 3022)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2009, N'PR02', N'Asus Vivobook', 15, N'Average Product', 3023)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2010, N'PR03', N'Apple', 20, N'High cost.', 3022)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2011, N'PR04', N'Lenevo Ideapad', 12, N'Good at performance.', 3023)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2012, N'PR05', N'HDD', 25, N'High Quality', 4005)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2013, N'PR06', N'SSD', 20, N'Super fast.', 4005)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2014, N'PR07', N'Micro SD', 30, N'Good', 4005)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2015, N'PR08', N'HP Pavilion', 15, N'Quality', 3023)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2016, N'PR09', N'Mi', 10, N'Good', 3022)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (2017, N'PR10', N'Nokia', 10, N'Strong build  quality.', 3022)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (3014, N'PR11', N'Volvo 520', 10, N'Strong', 5011)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (4014, N'PR12', N'LG HD', 10, N'High Quality Product', 4021)
INSERT [dbo].[Products] ([ID], [Code], [Name], [ReorderLevel], [Description], [CategoryID]) VALUES (4015, N'PR13', N'Asus Gaming Monitor', 20, N'Super power', 4021)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[PurchaseDetails] ON 

INSERT [dbo].[PurchaseDetails] ([ID], [PurchaseID], [ProductID], [ManufactureDate], [ExpireDate], [Quantity], [UnitPrice], [MRP], [Remark]) VALUES (3013, 3020, 2008, CAST(N'2019-10-24' AS Date), CAST(N'2019-10-24' AS Date), 10, 10000, 12500, N'Good')
INSERT [dbo].[PurchaseDetails] ([ID], [PurchaseID], [ProductID], [ManufactureDate], [ExpireDate], [Quantity], [UnitPrice], [MRP], [Remark]) VALUES (3014, 3020, 2010, CAST(N'2019-10-24' AS Date), CAST(N'2019-10-24' AS Date), 5, 20000, 25000, N'High quality')
INSERT [dbo].[PurchaseDetails] ([ID], [PurchaseID], [ProductID], [ManufactureDate], [ExpireDate], [Quantity], [UnitPrice], [MRP], [Remark]) VALUES (3015, 3021, 4014, CAST(N'2019-10-01' AS Date), CAST(N'2019-10-31' AS Date), 10, 10000, 12500, N'Good product.')
INSERT [dbo].[PurchaseDetails] ([ID], [PurchaseID], [ProductID], [ManufactureDate], [ExpireDate], [Quantity], [UnitPrice], [MRP], [Remark]) VALUES (3016, 3021, 4015, CAST(N'2019-10-28' AS Date), CAST(N'2019-10-28' AS Date), 20, 20000, 25000, N'Super')
SET IDENTITY_INSERT [dbo].[PurchaseDetails] OFF
SET IDENTITY_INSERT [dbo].[Purchases] ON 

INSERT [dbo].[Purchases] ([ID], [Code], [Date], [InvoiceNo], [SupplierID]) VALUES (3020, N'2019-0001', CAST(N'2019-10-23' AS Date), N'Invo-0002', 1012)
INSERT [dbo].[Purchases] ([ID], [Code], [Date], [InvoiceNo], [SupplierID]) VALUES (3021, N'2019-0002', CAST(N'2019-10-28' AS Date), N'Invo-003', 1014)
SET IDENTITY_INSERT [dbo].[Purchases] OFF
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([ID], [Code], [Date], [CustomerID], [PaidAmount]) VALUES (2016, N'2019-0001', CAST(N'2019-10-24' AS Date), 1008, 12250)
INSERT [dbo].[Sales] ([ID], [Code], [Date], [CustomerID], [PaidAmount]) VALUES (2017, N'2019-0002', CAST(N'2019-10-23' AS Date), 1008, 24250)
INSERT [dbo].[Sales] ([ID], [Code], [Date], [CustomerID], [PaidAmount]) VALUES (2018, N'2019-0003', CAST(N'2019-10-24' AS Date), 1009, 23750)
INSERT [dbo].[Sales] ([ID], [Code], [Date], [CustomerID], [PaidAmount]) VALUES (2021, N'2019-0004', CAST(N'2019-10-28' AS Date), 1009, 34875)
INSERT [dbo].[Sales] ([ID], [Code], [Date], [CustomerID], [PaidAmount]) VALUES (3021, N'2019-0005', CAST(N'2019-10-31' AS Date), 1010, 12375)
SET IDENTITY_INSERT [dbo].[Sales] OFF
SET IDENTITY_INSERT [dbo].[SalesDetails] ON 

INSERT [dbo].[SalesDetails] ([ID], [SalesID], [ProductID], [Quantity], [MRP]) VALUES (2015, 2016, 2008, 1, 12500)
INSERT [dbo].[SalesDetails] ([ID], [SalesID], [ProductID], [Quantity], [MRP]) VALUES (2016, 2017, 2010, 1, 25000)
INSERT [dbo].[SalesDetails] ([ID], [SalesID], [ProductID], [Quantity], [MRP]) VALUES (2017, 2018, 2010, 1, 25000)
INSERT [dbo].[SalesDetails] ([ID], [SalesID], [ProductID], [Quantity], [MRP]) VALUES (2020, 2021, 2008, 1, 12500)
INSERT [dbo].[SalesDetails] ([ID], [SalesID], [ProductID], [Quantity], [MRP]) VALUES (2021, 2021, 2010, 1, 25000)
INSERT [dbo].[SalesDetails] ([ID], [SalesID], [ProductID], [Quantity], [MRP]) VALUES (3020, 3021, 2008, 1, 12500)
SET IDENTITY_INSERT [dbo].[SalesDetails] OFF
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (1012, N'SU01', N'Sonet Mia', N'Kustia', N'sonet@gmail.com', N'11111111111', N'Shakil-01245645')
INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (1013, N'SU02', N'Siblu Mia', N'Dinajpur', N'shiblu@gmail.com', N'22222222222', N'Shakil-123456')
INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (1014, N'SU03', N'Foridul Islam', N'Mirpur', N'farid@gmail.com', N'33333333333', N'Fahad-258965')
INSERT [dbo].[Suppliers] ([ID], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (1015, N'SU04', N'Rofik Mia', N'Savar', N'rofik@gmail.com', N'44444444444', N'Sofik-164565')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([ID])
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([SalesID])
REFERENCES [dbo].[Sales] ([ID])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[33] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "p"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 185
               Right = 272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 189
               Left = 48
               Bottom = 367
               Right = 272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pd"
            Begin Extent = 
               Top = 371
               Left = 48
               Bottom = 549
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PurchaseShortRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PurchaseShortRecord'
GO
USE [master]
GO
ALTER DATABASE [SBMSwinAppDb] SET  READ_WRITE 
GO
