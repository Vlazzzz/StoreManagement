USE [master]
GO
/****** Object:  Database [dbSupermarket2]    Script Date: 5/24/2024 5:00:23 PM ******/
CREATE DATABASE [dbSupermarket2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSupermarket2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbSupermarket2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbSupermarket2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbSupermarket2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbSupermarket2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSupermarket2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSupermarket2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSupermarket2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSupermarket2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSupermarket2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSupermarket2] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSupermarket2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSupermarket2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSupermarket2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSupermarket2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSupermarket2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSupermarket2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSupermarket2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSupermarket2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSupermarket2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSupermarket2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSupermarket2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSupermarket2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSupermarket2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSupermarket2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSupermarket2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSupermarket2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSupermarket2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSupermarket2] SET RECOVERY FULL 
GO
ALTER DATABASE [dbSupermarket2] SET  MULTI_USER 
GO
ALTER DATABASE [dbSupermarket2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSupermarket2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSupermarket2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSupermarket2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbSupermarket2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbSupermarket2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbSupermarket2', N'ON'
GO
ALTER DATABASE [dbSupermarket2] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbSupermarket2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbSupermarket2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ProducerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OriginCountry] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Producers] PRIMARY KEY CLUSTERED 
(
	[ProducerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Barcode] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProducerId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[IssueDate] [datetime2](7) NOT NULL,
	[AmountReceived] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptProduct]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptProduct](
	[ReceiptId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [nvarchar](max) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ReceiptProducts] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [nvarchar](max) NOT NULL,
	[SupplyDate] [datetime2](7) NOT NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[UserType] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 5/24/2024 5:00:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ProducerId]    Script Date: 5/24/2024 5:00:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProducerId] ON [dbo].[Product]
(
	[ProducerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Receipts_UserId]    Script Date: 5/24/2024 5:00:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Receipts_UserId] ON [dbo].[Receipt]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReceiptProducts_ProductId]    Script Date: 5/24/2024 5:00:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReceiptProducts_ProductId] ON [dbo].[ReceiptProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stocks_ProductId]    Script Date: 5/24/2024 5:00:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Stocks_ProductId] ON [dbo].[Stock]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Producer] ADD  CONSTRAINT [DF_Producer_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Receipt] ADD  CONSTRAINT [DF_Receipt_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ReceiptProduct] ADD  CONSTRAINT [DF_ReceiptProduct_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF_Stock_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Products_Producers_ProducerId] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producer] ([ProducerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Producers_ProducerId]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipts_Users_UserId]
GO
ALTER TABLE [dbo].[ReceiptProduct]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptProducts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReceiptProduct] CHECK CONSTRAINT [FK_ReceiptProducts_Products_ProductId]
GO
ALTER TABLE [dbo].[ReceiptProduct]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptProducts_Receipts_ReceiptId] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReceiptProduct] CHECK CONSTRAINT [FK_ReceiptProducts_Receipts_ReceiptId]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stocks_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stocks_Products_ProductId]
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryIdByName]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryIdByName]
    @CategoryName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CategoryId
    FROM Category
    WHERE Name = @CategoryName;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryNameById]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryNameById]
    @CategoryId INT
AS
BEGIN
    SELECT Name FROM Category WHERE CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[GetProducerIdByName]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducerIdByName]
    @ProducerName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProducerId
    FROM Producer
    WHERE Name = @ProducerName;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProducerNameById]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProducerNameById]
    @ProducerId INT
AS
BEGIN
    SELECT Name FROM Producer WHERE ProducerId = @ProducerId
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductNameById]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductNameById]
    @ProductId INT
AS
BEGIN
    SELECT Name FROM Product WHERE ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[sbUserSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sbUserSelectOne]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @UserType BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId INT;

    SELECT @UserId = UserId, @UserType = UserType
    FROM [User]
    WHERE Username = @Username AND Password = @Password AND IsActive = 1;

    IF @UserId IS NOT NULL
    BEGIN
        -- User found
        RETURN 1;
    END
    ELSE
    BEGIN
        -- User not found
        RETURN 0;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Category
CREATE PROCEDURE [dbo].[spCategoryDelete]
    @CategoryId int
AS
BEGIN
    UPDATE Category
    SET IsActive = 0
    WHERE CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Category
CREATE PROCEDURE [dbo].[spCategoryInsert]
    @Name nvarchar(50)
AS
BEGIN
    INSERT INTO Category(Name)
    VALUES (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[spCategorySelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Category
CREATE PROCEDURE [dbo].[spCategorySelectAll]
AS
BEGIN
    SELECT * FROM Category WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spCategorySelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Category
CREATE PROCEDURE [dbo].[spCategorySelectOne]
    @CategoryId int
AS
BEGIN
    SELECT * FROM Category WHERE CategoryId = @CategoryId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spCategoryUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Category
CREATE PROCEDURE [dbo].[spCategoryUpdate]
    @CategoryId int,
    @Name nvarchar(50)
AS
BEGIN
    UPDATE Category
    SET Name = @Name
    WHERE CategoryId = @CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[spCheckUserCredentials]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCheckUserCredentials]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @UserCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Count the number of active users with the given username and password
    SELECT @UserCount = COUNT(*)
    FROM [User]
    WHERE [Username] = @Username 
      AND [Password] = @Password 
      AND [IsActive] = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[spCheckUserType]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCheckUserType]
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @IsAdmin BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the user with the given username, password, and active status exists
    IF EXISTS (
        SELECT 1
        FROM [User]
        WHERE [Username] = @Username 
          AND [Password] = @Password 
          AND [IsActive] = 1
    )
    BEGIN
        -- Get the UserType directly
        SELECT @IsAdmin = UserType
        FROM [User]
        WHERE [Username] = @Username 
          AND [Password] = @Password 
          AND [IsActive] = 1;

        RETURN 1;  -- User exists
    END
    ELSE
    BEGIN
        RETURN 0;  -- User does not exist
    END
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUserNameById]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUserNameById]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Username
    FROM [User]
    WHERE UserId = @UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Producer
CREATE PROCEDURE [dbo].[spProducerDelete]
    @ProducerId int
AS
BEGIN
    UPDATE Producer
    SET IsActive = 0
    WHERE ProducerId = @ProducerId
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Producer
CREATE PROCEDURE [dbo].[spProducerInsert]
    @Name nvarchar(50),
    @OriginCountry nvarchar(50)
AS
BEGIN
    INSERT INTO Producer(Name, OriginCountry)
    VALUES (@Name, @OriginCountry)
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerSelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Producer
CREATE PROCEDURE [dbo].[spProducerSelectAll]
AS
BEGIN
    SELECT * FROM Producer WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Producer
CREATE PROCEDURE [dbo].[spProducerSelectOne]
    @ProducerId int
AS
BEGIN
    SELECT * FROM Producer WHERE ProducerId = @ProducerId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProducerUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Producer
CREATE PROCEDURE [dbo].[spProducerUpdate]
    @ProducerId int,
    @Name nvarchar(50),
    @OriginCountry nvarchar(50)
AS
BEGIN
    UPDATE Producer
    SET Name = @Name, OriginCountry = @OriginCountry
    WHERE ProducerId = @ProducerId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Product
CREATE PROCEDURE [dbo].[spProductDelete]
    @ProductId int
AS
BEGIN
    UPDATE Product
    SET IsActive = 0
    WHERE ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Product
CREATE PROCEDURE [dbo].[spProductInsert]
    @Name nvarchar(50),
    @Barcode nvarchar(50),
    @CategoryId int,
    @ProducerId int
AS
BEGIN
    INSERT INTO Product(Name, Barcode, CategoryId, ProducerId)
    VALUES (@Name, @Barcode, @CategoryId, @ProducerId)
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptDelete]
    @ReceiptId int,
    @ProductId int
AS
BEGIN
    UPDATE ReceiptProduct
    SET IsActive = 0
    WHERE ReceiptId = @ReceiptId AND ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptInsert]
    @ReceiptId int,
    @ProductId int,
    @Quantity int,
    @Unit nvarchar(50),
    @SubTotal decimal(18, 2)
AS
BEGIN
    INSERT INTO ReceiptProduct(ReceiptId, ProductId, Quantity, Unit, SubTotal)
    VALUES (@ReceiptId, @ProductId, @Quantity, @Unit, @SubTotal)
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptSelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptSelectAll]
AS
BEGIN
    SELECT * FROM ReceiptProduct WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptSelectOne]
    @ReceiptId int,
    @ProductId int
AS
BEGIN
    SELECT * FROM ReceiptProduct WHERE ReceiptId = @ReceiptId AND ProductId = @ProductId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductReceiptUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for ProductReceipt
CREATE PROCEDURE [dbo].[spProductReceiptUpdate]
    @ReceiptId int,
    @ProductId int,
    @Quantity int,
    @Unit nvarchar(50),
    @SubTotal decimal(18, 2)
AS
BEGIN
    UPDATE ReceiptProduct
    SET Quantity = @Quantity, Unit = @Unit, SubTotal = @SubTotal
    WHERE ReceiptId = @ReceiptId AND ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spProductSelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Product
CREATE PROCEDURE [dbo].[spProductSelectAll]
AS
BEGIN
    SELECT * FROM Product WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Product
CREATE PROCEDURE [dbo].[spProductSelectOne]
    @ProductId int
AS
BEGIN
    SELECT * FROM Product WHERE ProductId = @ProductId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spProductUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Product
CREATE PROCEDURE [dbo].[spProductUpdate]
    @ProductId int,
    @Name nvarchar(50),
    @Barcode nvarchar(50),
    @CategoryId int,
    @ProducerId int
AS
BEGIN
    UPDATE Product
    SET Name = @Name, Barcode = @Barcode, CategoryId = @CategoryId, ProducerId = @ProducerId
    WHERE ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptDelete]
    @ReceiptId int
AS
BEGIN
    UPDATE Receipt
    SET IsActive = 0
    WHERE ReceiptId = @ReceiptId
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptInsert]
    @UserId int,
    @IssueDate datetime,
    @AmountReceived decimal(18, 2)
AS
BEGIN
    INSERT INTO Receipt(UserId, IssueDate, AmountReceived)
    VALUES (@UserId, @IssueDate, @AmountReceived)
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptSelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptSelectAll]
AS
BEGIN
    SELECT * FROM Receipt WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptSelectOne]
    @ReceiptId int
AS
BEGIN
    SELECT * FROM Receipt WHERE ReceiptId = @ReceiptId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spReceiptUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Receipt
CREATE PROCEDURE [dbo].[spReceiptUpdate]
    @ReceiptId int,
    @UserId int,
    @IssueDate datetime,
    @AmountReceived decimal(18, 2)
AS
BEGIN
    UPDATE Receipt
    SET UserId = @UserId, IssueDate = @IssueDate, AmountReceived = @AmountReceived
    WHERE ReceiptId = @ReceiptId
END
GO
/****** Object:  StoredProcedure [dbo].[spStockDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for Stock
CREATE PROCEDURE [dbo].[spStockDelete]
    @StockId int
AS
BEGIN
    UPDATE Stock
    SET IsActive = 0
    WHERE StockId = @StockId
END
GO
/****** Object:  StoredProcedure [dbo].[spStockInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for Stock
CREATE PROCEDURE [dbo].[spStockInsert]
    @ProductId int,
    @Quantity int,
    @Unit nvarchar(50),
    @SupplyDate datetime,
    @ExpiryDate datetime,
    @PurchasePrice decimal(18, 2)
AS
BEGIN
    INSERT INTO Stock(ProductId, Quantity, Unit, SupplyDate, ExpiryDate, PurchasePrice)
    VALUES (@ProductId, @Quantity, @Unit, @SupplyDate, @ExpiryDate, @PurchasePrice)
END
GO
/****** Object:  StoredProcedure [dbo].[spStockSelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for Stock
CREATE PROCEDURE [dbo].[spStockSelectAll]
AS
BEGIN
    SELECT * FROM Stock WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spStockSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for Stock
CREATE PROCEDURE [dbo].[spStockSelectOne]
    @StockId int
AS
BEGIN
    SELECT * FROM Stock WHERE StockId = @StockId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spStockUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for Stock
CREATE PROCEDURE [dbo].[spStockUpdate]
    @StockId int,
    @ProductId int,
    @Quantity int,
    @Unit nvarchar(50),
    @SupplyDate datetime,
    @ExpiryDate datetime,
    @PurchasePrice decimal(18, 2)
AS
BEGIN
    UPDATE Stock
    SET ProductId = @ProductId, Quantity = @Quantity, Unit = @Unit, SupplyDate = @SupplyDate, ExpiryDate = @ExpiryDate, PurchasePrice = @PurchasePrice
    WHERE StockId = @StockId
END
GO
/****** Object:  StoredProcedure [dbo].[spUserDelete]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete operation for User
CREATE PROCEDURE [dbo].[spUserDelete]
    @UserId int
AS
BEGIN
    UPDATE [User]
    SET IsActive = 0
    WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[spUserInsert]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insert operation for User
CREATE PROCEDURE [dbo].[spUserInsert]
    @Username nvarchar(50),
    @Password nvarchar(50),
    @UserType bit
AS
BEGIN
    INSERT INTO [User](Username, Password, UserType)
    VALUES (@Username, @Password, @UserType)
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectAll]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectAll operation for User
CREATE PROCEDURE [dbo].[spUserSelectAll]
AS
BEGIN
    SELECT * FROM [User] WHERE IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectAllAdmins]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserSelectAllAdmins]
AS
BEGIN
    SELECT * FROM [User] WHERE UserType = 0 AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectAllCashiers]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUserSelectAllCashiers]
AS
BEGIN
    SELECT * FROM [User] WHERE UserType = 1 AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSelectOne]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectOne operation for User
CREATE PROCEDURE [dbo].[spUserSelectOne]
    @UserId int
AS
BEGIN
    SELECT * FROM [User] WHERE UserId = @UserId AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spUserUpdate]    Script Date: 5/24/2024 5:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update operation for User
CREATE PROCEDURE [dbo].[spUserUpdate]
    @UserId int,
    @Username nvarchar(50),
    @Password nvarchar(50),
    @UserType int
AS
BEGIN
    UPDATE [User]
    SET Username = @Username, Password = @Password, UserType = @UserType
    WHERE UserId = @UserId
END
GO
USE [master]
GO
ALTER DATABASE [dbSupermarket2] SET  READ_WRITE 
GO
