
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/11/2019 23:24:39
-- Generated from EDMX file: C:\Users\Krunal Changawala\Downloads\OneDrive_1_10-19-2019\UniversalPaymentSystem_base Implementation\Payment\Payment\Models\BillPayment.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BillPayment];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[FK__PostPaid__Mobile__534D60F1]', 'F') IS NOT NULL
    ALTER TABLE [BillPaymentModelStoreContainer].[PostPaid] DROP CONSTRAINT [FK__PostPaid__Mobile__534D60F1];
GO
IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[FK__PrePaid__MobileN__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [BillPaymentModelStoreContainer].[PrePaid] DROP CONSTRAINT [FK__PrePaid__MobileN__5441852A];
GO
IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[FK__table_Log__Mobil__5535A963]', 'F') IS NOT NULL
    ALTER TABLE [BillPaymentModelStoreContainer].[table_Login] DROP CONSTRAINT [FK__table_Log__Mobil__5535A963];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[debit_creditcard_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[debit_creditcard_table];
GO
IF OBJECT_ID(N'[dbo].[table_Registration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[table_Registration];
GO
IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[Operator_Table1]', 'U') IS NOT NULL
    DROP TABLE [BillPaymentModelStoreContainer].[Operator_Table1];
GO
IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[PostPaid]', 'U') IS NOT NULL
    DROP TABLE [BillPaymentModelStoreContainer].[PostPaid];
GO
IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[PrePaid]', 'U') IS NOT NULL
    DROP TABLE [BillPaymentModelStoreContainer].[PrePaid];
GO
IF OBJECT_ID(N'[BillPaymentModelStoreContainer].[table_Login]', 'U') IS NOT NULL
    DROP TABLE [BillPaymentModelStoreContainer].[table_Login];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'debit_creditcard_table'
CREATE TABLE [dbo].[debit_creditcard_table] (
    [CardNumber] bigint  NOT NULL,
    [CVVNumber] int  NULL,
    [ExpiryDate] varchar(50)  NULL,
    [AccountHolderName] varchar(50)  NULL,
    [BankName] varchar(50)  NULL,
    [UserID] varchar(50)  NULL,
    [UserPassword] int  NULL,
    [Balance] decimal(19,4)  NULL
);
GO

-- Creating table 'table_Registration'
CREATE TABLE [dbo].[table_Registration] (
    [CustomerName] varchar(50)  NOT NULL,
    [MobileNumber] bigint  NOT NULL,
    [EmailID] varchar(50)  NOT NULL,
    [Plantype] varchar(50)  NOT NULL,
    [SecurityQuestion] varchar(50)  NOT NULL,
    [SecurityAnswer] varchar(50)  NOT NULL,
    [NewPassword] varchar(50)  NOT NULL,
    [ConfirmPassword] varchar(50)  NOT NULL,
    [Operator] varchar(50)  NOT NULL
);
GO

-- Creating table 'Operator_Table1'
CREATE TABLE [dbo].[Operator_Table1] (
    [Operator] varchar(50)  NOT NULL,
    [MRP] decimal(19,4)  NOT NULL,
    [ValidateDays] varchar(50)  NOT NULL,
    [Descriptions] varchar(50)  NOT NULL,
    [Roaming] varchar(50)  NOT NULL,
    [SMS] varchar(50)  NOT NULL,
    [DataSpeed] varchar(50)  NOT NULL
);
GO

-- Creating table 'PostPaids'
CREATE TABLE [dbo].[PostPaids] (
    [MobileNumber] bigint  NOT NULL,
    [Operator] varchar(50)  NULL
);
GO

-- Creating table 'PrePaids'
CREATE TABLE [dbo].[PrePaids] (
    [MobileNumber] bigint  NOT NULL,
    [Operator] varchar(50)  NULL
);
GO

-- Creating table 'table_Login'
CREATE TABLE [dbo].[table_Login] (
    [MobileNumber] bigint  NOT NULL,
    [ConfirmPassword] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CardNumber] in table 'debit_creditcard_table'
ALTER TABLE [dbo].[debit_creditcard_table]
ADD CONSTRAINT [PK_debit_creditcard_table]
    PRIMARY KEY CLUSTERED ([CardNumber] ASC);
GO

-- Creating primary key on [MobileNumber] in table 'table_Registration'
ALTER TABLE [dbo].[table_Registration]
ADD CONSTRAINT [PK_table_Registration]
    PRIMARY KEY CLUSTERED ([MobileNumber] ASC);
GO

-- Creating primary key on [Operator], [MRP], [ValidateDays], [Descriptions], [Roaming], [SMS], [DataSpeed] in table 'Operator_Table1'
ALTER TABLE [dbo].[Operator_Table1]
ADD CONSTRAINT [PK_Operator_Table1]
    PRIMARY KEY CLUSTERED ([Operator], [MRP], [ValidateDays], [Descriptions], [Roaming], [SMS], [DataSpeed] ASC);
GO

-- Creating primary key on [MobileNumber] in table 'PostPaids'
ALTER TABLE [dbo].[PostPaids]
ADD CONSTRAINT [PK_PostPaids]
    PRIMARY KEY CLUSTERED ([MobileNumber] ASC);
GO

-- Creating primary key on [MobileNumber] in table 'PrePaids'
ALTER TABLE [dbo].[PrePaids]
ADD CONSTRAINT [PK_PrePaids]
    PRIMARY KEY CLUSTERED ([MobileNumber] ASC);
GO

-- Creating primary key on [MobileNumber] in table 'table_Login'
ALTER TABLE [dbo].[table_Login]
ADD CONSTRAINT [PK_table_Login]
    PRIMARY KEY CLUSTERED ([MobileNumber] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MobileNumber] in table 'PostPaids'
ALTER TABLE [dbo].[PostPaids]
ADD CONSTRAINT [FK__PostPaid__Mobile__534D60F1]
    FOREIGN KEY ([MobileNumber])
    REFERENCES [dbo].[table_Registration]
        ([MobileNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MobileNumber] in table 'PrePaids'
ALTER TABLE [dbo].[PrePaids]
ADD CONSTRAINT [FK__PrePaid__MobileN__5441852A]
    FOREIGN KEY ([MobileNumber])
    REFERENCES [dbo].[table_Registration]
        ([MobileNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MobileNumber] in table 'table_Login'
ALTER TABLE [dbo].[table_Login]
ADD CONSTRAINT [FK__table_Log__Mobil__5535A963]
    FOREIGN KEY ([MobileNumber])
    REFERENCES [dbo].[table_Registration]
        ([MobileNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO


create table User_Transaction
(Id int primary key identity(1,1),
CustomerName varchar(50) not null,
MobileNumber bigint not null references table_Registration(MobileNumber),
PlantType varchar(50) not null,
Operator varchar(50),
Amount decimal(19,4) not null)
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------