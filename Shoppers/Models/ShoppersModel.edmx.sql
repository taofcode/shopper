
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2018 18:46:30
-- Generated from EDMX file: C:\Users\Shelton.Chiuswa\Documents\lesisure research\Shoppers\Shoppers\Shoppers\Models\ShoppersModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [shopper];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Charges_Carts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Charges] DROP CONSTRAINT [FK_Charges_Carts];
GO
IF OBJECT_ID(N'[dbo].[FK_Charges_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Charges] DROP CONSTRAINT [FK_Charges_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_DeliveryAddresses_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliveryAddresses] DROP CONSTRAINT [FK_DeliveryAddresses_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItems_Carts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItems_Carts];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItems_Stock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductItems_Stock];
GO
IF OBJECT_ID(N'[dbo].[FK_Stocks_Categories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stocks] DROP CONSTRAINT [FK_Stocks_Categories];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_Carts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Carts];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Customers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Carts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carts];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Charges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Charges];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[DeliveryAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveryAddresses];
GO
IF OBJECT_ID(N'[dbo].[Enquiries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enquiries];
GO
IF OBJECT_ID(N'[dbo].[ProductItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductItems];
GO
IF OBJECT_ID(N'[dbo].[Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Settings];
GO
IF OBJECT_ID(N'[dbo].[Stocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stocks];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Count] int  NULL,
    [DateCreated] datetime  NULL,
    [CartId] nvarchar(250)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Charges'
CREATE TABLE [dbo].[Charges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Amount] float  NULL,
    [Description] nvarchar(max)  NULL,
    [CategoryId] nvarchar(250)  NULL,
    [CartId] int  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Lastname] nvarchar(max)  NULL,
    [DateRegistered] datetime  NULL,
    [ContactNo] nvarchar(max)  NULL,
    [UserId] nvarchar(250)  NULL,
    [HasAccount] bit  NULL
);
GO

-- Creating table 'DeliveryAddresses'
CREATE TABLE [dbo].[DeliveryAddresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NULL,
    [ContactNo] nvarchar(250)  NULL,
    [City] nvarchar(250)  NULL,
    [CustomerId] int  NULL
);
GO

-- Creating table 'Enquiries'
CREATE TABLE [dbo].[Enquiries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Email] nvarchar(max)  NULL,
    [Message] nvarchar(max)  NULL,
    [DateCreated] datetime  NULL
);
GO

-- Creating table 'ProductItems'
CREATE TABLE [dbo].[ProductItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StockId] int  NOT NULL,
    [LastDateUpdated] datetime  NULL,
    [UpdatedBy] nvarchar(max)  NULL,
    [Qty] float  NULL,
    [CartId] int  NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VariableName] nvarchar(max)  NULL,
    [VariableValue] nvarchar(max)  NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Description] nvarchar(max)  NULL,
    [CategoryId] nvarchar(250)  NULL,
    [Rank] int  NULL,
    [Price] float  NULL,
    [QtyInStock] float  NULL,
    [ReOrderLevel] float  NULL,
    [PathUrl] nvarchar(max)  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] int  NULL,
    [Sms] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [CustomerId] int  NULL,
    [Currency] nvarchar(50)  NULL,
    [ResultXML] nvarchar(max)  NULL,
    [RefNo] nvarchar(max)  NULL,
    [CartId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [Id] in table 'Charges'
ALTER TABLE [dbo].[Charges]
ADD CONSTRAINT [PK_Charges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeliveryAddresses'
ALTER TABLE [dbo].[DeliveryAddresses]
ADD CONSTRAINT [PK_DeliveryAddresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Enquiries'
ALTER TABLE [dbo].[Enquiries]
ADD CONSTRAINT [PK_Enquiries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [PK_ProductItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CartId] in table 'Charges'
ALTER TABLE [dbo].[Charges]
ADD CONSTRAINT [FK_Charges_Carts]
    FOREIGN KEY ([CartId])
    REFERENCES [dbo].[Carts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Charges_Carts'
CREATE INDEX [IX_FK_Charges_Carts]
ON [dbo].[Charges]
    ([CartId]);
GO

-- Creating foreign key on [CartId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItems_Carts]
    FOREIGN KEY ([CartId])
    REFERENCES [dbo].[Carts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItems_Carts'
CREATE INDEX [IX_FK_ProductItems_Carts]
ON [dbo].[ProductItems]
    ([CartId]);
GO

-- Creating foreign key on [CartId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_Carts]
    FOREIGN KEY ([CartId])
    REFERENCES [dbo].[Carts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_Carts'
CREATE INDEX [IX_FK_Transactions_Carts]
ON [dbo].[Transactions]
    ([CartId]);
GO

-- Creating foreign key on [CategoryId] in table 'Charges'
ALTER TABLE [dbo].[Charges]
ADD CONSTRAINT [FK_Charges_Categories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Charges_Categories'
CREATE INDEX [IX_FK_Charges_Categories]
ON [dbo].[Charges]
    ([CategoryId]);
GO

-- Creating foreign key on [CategoryId] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [FK_Stocks_Categories]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Stocks_Categories'
CREATE INDEX [IX_FK_Stocks_Categories]
ON [dbo].[Stocks]
    ([CategoryId]);
GO

-- Creating foreign key on [CustomerId] in table 'DeliveryAddresses'
ALTER TABLE [dbo].[DeliveryAddresses]
ADD CONSTRAINT [FK_DeliveryAddresses_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryAddresses_Customers'
CREATE INDEX [IX_FK_DeliveryAddresses_Customers]
ON [dbo].[DeliveryAddresses]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_Customers'
CREATE INDEX [IX_FK_Transactions_Customers]
ON [dbo].[Transactions]
    ([CustomerId]);
GO

-- Creating foreign key on [StockId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductItems_Stock]
    FOREIGN KEY ([StockId])
    REFERENCES [dbo].[Stocks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItems_Stock'
CREATE INDEX [IX_FK_ProductItems_Stock]
ON [dbo].[ProductItems]
    ([StockId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------