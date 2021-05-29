
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2021 16:40:45
-- Generated from EDMX file: C:\Users\Dejan\Desktop\Karantin\4.2 godina\Baze2\Projekat\Projekat\BP2Project\DatabaseModel\ProjectModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BazePodataka2Projekat];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Zaposleni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[PoslovniProstori]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PoslovniProstori];
GO
IF OBJECT_ID(N'[dbo].[Hardveri]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hardveri];
GO
IF OBJECT_ID(N'[dbo].[Timovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Timovi];
GO
IF OBJECT_ID(N'[dbo].[Projekati]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projekati];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Zaposleni'
CREATE TABLE [dbo].[Zaposleni] (
    [Id] nchar(100)  NOT NULL,
    [D_ZAP] datetime  NULL,
    [PLAT] int  NOT NULL
);
GO

-- Creating table 'PoslovniProstori'
CREATE TABLE [dbo].[PoslovniProstori] (
    [SP] nchar(100)  NOT NULL,
    [DIM] decimal(18,0)  NOT NULL,
    [BRM] int  NULL
);
GO

-- Creating table 'Hardveri'
CREATE TABLE [dbo].[Hardveri] (
    [SH] nchar(100)  NOT NULL,
    [CPU] nvarchar(max)  NULL,
    [RAM] int  NULL,
    [HDD] int  NULL
);
GO

-- Creating table 'Timovi'
CREATE TABLE [dbo].[Timovi] (
    [ST] nchar(100)  NOT NULL,
    [PR] nvarchar(max)  NULL
);
GO

-- Creating table 'Projekati'
CREATE TABLE [dbo].[Projekati] (
    [SP] nchar(100)  NOT NULL,
    [DD] datetime  NOT NULL,
    [DP] datetime  NULL,
    [RI] datetime  NULL,
    [KI] int  NULL,
    [SZ] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Zaposleni'
ALTER TABLE [dbo].[Zaposleni]
ADD CONSTRAINT [PK_Zaposleni]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SP] in table 'PoslovniProstori'
ALTER TABLE [dbo].[PoslovniProstori]
ADD CONSTRAINT [PK_PoslovniProstori]
    PRIMARY KEY CLUSTERED ([SP] ASC);
GO

-- Creating primary key on [SH] in table 'Hardveri'
ALTER TABLE [dbo].[Hardveri]
ADD CONSTRAINT [PK_Hardveri]
    PRIMARY KEY CLUSTERED ([SH] ASC);
GO

-- Creating primary key on [ST] in table 'Timovi'
ALTER TABLE [dbo].[Timovi]
ADD CONSTRAINT [PK_Timovi]
    PRIMARY KEY CLUSTERED ([ST] ASC);
GO

-- Creating primary key on [SP] in table 'Projekati'
ALTER TABLE [dbo].[Projekati]
ADD CONSTRAINT [PK_Projekati]
    PRIMARY KEY CLUSTERED ([SP] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------