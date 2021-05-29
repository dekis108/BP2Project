
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2021 19:46:39
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

IF OBJECT_ID(N'[dbo].[FK_ProjekatTimRadiNaProjektu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projekati] DROP CONSTRAINT [FK_ProjekatTimRadiNaProjektu];
GO
IF OBJECT_ID(N'[dbo].[FK_TimRadiNaProjektuTim_TimRadiNaProjektu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimRadiNaProjektuTim] DROP CONSTRAINT [FK_TimRadiNaProjektuTim_TimRadiNaProjektu];
GO
IF OBJECT_ID(N'[dbo].[FK_TimRadiNaProjektuTim_Tim]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimRadiNaProjektuTim] DROP CONSTRAINT [FK_TimRadiNaProjektuTim_Tim];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaposleniPoslovniProstor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni] DROP CONSTRAINT [FK_ZaposleniPoslovniProstor];
GO
IF OBJECT_ID(N'[dbo].[FK_Admin_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Admin] DROP CONSTRAINT [FK_Admin_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Dispecer_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Dispecer] DROP CONSTRAINT [FK_Dispecer_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Programer_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Programer] DROP CONSTRAINT [FK_Programer_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Menadzer_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Menadzer] DROP CONSTRAINT [FK_Menadzer_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Racunar_inherits_Hardver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hardveri_Racunar] DROP CONSTRAINT [FK_Racunar_inherits_Hardver];
GO
IF OBJECT_ID(N'[dbo].[FK_Mobilni_inherits_Hardver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hardveri_Mobilni] DROP CONSTRAINT [FK_Mobilni_inherits_Hardver];
GO

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
IF OBJECT_ID(N'[dbo].[TimRadiNaProjektu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimRadiNaProjektu];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Admin];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Dispecer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Dispecer];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Programer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Programer];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Menadzer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Menadzer];
GO
IF OBJECT_ID(N'[dbo].[Hardveri_Racunar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hardveri_Racunar];
GO
IF OBJECT_ID(N'[dbo].[Hardveri_Mobilni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hardveri_Mobilni];
GO
IF OBJECT_ID(N'[dbo].[TimRadiNaProjektuTim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimRadiNaProjektuTim];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Zaposleni'
CREATE TABLE [dbo].[Zaposleni] (
    [Id] nchar(100)  NOT NULL,
    [D_ZAP] datetime  NULL,
    [PLAT] int  NOT NULL,
    [PoslovniProstor_SP] nchar(100)  NOT NULL
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
    [SZ] nvarchar(max)  NULL,
    [TimRadiNaProjektus_Id] nchar(100)  NOT NULL
);
GO

-- Creating table 'TimRadiNaProjektu'
CREATE TABLE [dbo].[TimRadiNaProjektu] (
    [OZ] decimal(18,0)  NOT NULL,
    [Id] nchar(100)  NOT NULL
);
GO

-- Creating table 'Zaposleni_Admin'
CREATE TABLE [dbo].[Zaposleni_Admin] (
    [NPR] nvarchar(max)  NULL,
    [Id] nchar(100)  NOT NULL
);
GO

-- Creating table 'Zaposleni_Dispecer'
CREATE TABLE [dbo].[Zaposleni_Dispecer] (
    [Id] nchar(100)  NOT NULL
);
GO

-- Creating table 'Zaposleni_Programer'
CREATE TABLE [dbo].[Zaposleni_Programer] (
    [O_PROD] int  NULL,
    [Id] nchar(100)  NOT NULL
);
GO

-- Creating table 'Zaposleni_Menadzer'
CREATE TABLE [dbo].[Zaposleni_Menadzer] (
    [Id] nchar(100)  NOT NULL
);
GO

-- Creating table 'Hardveri_Racunar'
CREATE TABLE [dbo].[Hardveri_Racunar] (
    [VM] nvarchar(max)  NULL,
    [SH] nchar(100)  NOT NULL
);
GO

-- Creating table 'Hardveri_Mobilni'
CREATE TABLE [dbo].[Hardveri_Mobilni] (
    [MDIM] decimal(18,0)  NOT NULL,
    [OS] nvarchar(max)  NULL,
    [SH] nchar(100)  NOT NULL
);
GO

-- Creating table 'TimRadiNaProjektuTim'
CREATE TABLE [dbo].[TimRadiNaProjektuTim] (
    [TimRadiNaProjektu_Id] nchar(100)  NOT NULL,
    [Tim_ST] nchar(100)  NOT NULL
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

-- Creating primary key on [Id] in table 'TimRadiNaProjektu'
ALTER TABLE [dbo].[TimRadiNaProjektu]
ADD CONSTRAINT [PK_TimRadiNaProjektu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zaposleni_Admin'
ALTER TABLE [dbo].[Zaposleni_Admin]
ADD CONSTRAINT [PK_Zaposleni_Admin]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zaposleni_Dispecer'
ALTER TABLE [dbo].[Zaposleni_Dispecer]
ADD CONSTRAINT [PK_Zaposleni_Dispecer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zaposleni_Programer'
ALTER TABLE [dbo].[Zaposleni_Programer]
ADD CONSTRAINT [PK_Zaposleni_Programer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zaposleni_Menadzer'
ALTER TABLE [dbo].[Zaposleni_Menadzer]
ADD CONSTRAINT [PK_Zaposleni_Menadzer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SH] in table 'Hardveri_Racunar'
ALTER TABLE [dbo].[Hardveri_Racunar]
ADD CONSTRAINT [PK_Hardveri_Racunar]
    PRIMARY KEY CLUSTERED ([SH] ASC);
GO

-- Creating primary key on [SH] in table 'Hardveri_Mobilni'
ALTER TABLE [dbo].[Hardveri_Mobilni]
ADD CONSTRAINT [PK_Hardveri_Mobilni]
    PRIMARY KEY CLUSTERED ([SH] ASC);
GO

-- Creating primary key on [TimRadiNaProjektu_Id], [Tim_ST] in table 'TimRadiNaProjektuTim'
ALTER TABLE [dbo].[TimRadiNaProjektuTim]
ADD CONSTRAINT [PK_TimRadiNaProjektuTim]
    PRIMARY KEY CLUSTERED ([TimRadiNaProjektu_Id], [Tim_ST] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TimRadiNaProjektus_Id] in table 'Projekati'
ALTER TABLE [dbo].[Projekati]
ADD CONSTRAINT [FK_ProjekatTimRadiNaProjektu]
    FOREIGN KEY ([TimRadiNaProjektus_Id])
    REFERENCES [dbo].[TimRadiNaProjektu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjekatTimRadiNaProjektu'
CREATE INDEX [IX_FK_ProjekatTimRadiNaProjektu]
ON [dbo].[Projekati]
    ([TimRadiNaProjektus_Id]);
GO

-- Creating foreign key on [TimRadiNaProjektu_Id] in table 'TimRadiNaProjektuTim'
ALTER TABLE [dbo].[TimRadiNaProjektuTim]
ADD CONSTRAINT [FK_TimRadiNaProjektuTim_TimRadiNaProjektu]
    FOREIGN KEY ([TimRadiNaProjektu_Id])
    REFERENCES [dbo].[TimRadiNaProjektu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tim_ST] in table 'TimRadiNaProjektuTim'
ALTER TABLE [dbo].[TimRadiNaProjektuTim]
ADD CONSTRAINT [FK_TimRadiNaProjektuTim_Tim]
    FOREIGN KEY ([Tim_ST])
    REFERENCES [dbo].[Timovi]
        ([ST])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TimRadiNaProjektuTim_Tim'
CREATE INDEX [IX_FK_TimRadiNaProjektuTim_Tim]
ON [dbo].[TimRadiNaProjektuTim]
    ([Tim_ST]);
GO

-- Creating foreign key on [PoslovniProstor_SP] in table 'Zaposleni'
ALTER TABLE [dbo].[Zaposleni]
ADD CONSTRAINT [FK_ZaposleniPoslovniProstor]
    FOREIGN KEY ([PoslovniProstor_SP])
    REFERENCES [dbo].[PoslovniProstori]
        ([SP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZaposleniPoslovniProstor'
CREATE INDEX [IX_FK_ZaposleniPoslovniProstor]
ON [dbo].[Zaposleni]
    ([PoslovniProstor_SP]);
GO

-- Creating foreign key on [Id] in table 'Zaposleni_Admin'
ALTER TABLE [dbo].[Zaposleni_Admin]
ADD CONSTRAINT [FK_Admin_inherits_Zaposleni]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Zaposleni]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Zaposleni_Dispecer'
ALTER TABLE [dbo].[Zaposleni_Dispecer]
ADD CONSTRAINT [FK_Dispecer_inherits_Zaposleni]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Zaposleni]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Zaposleni_Programer'
ALTER TABLE [dbo].[Zaposleni_Programer]
ADD CONSTRAINT [FK_Programer_inherits_Zaposleni]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Zaposleni]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Zaposleni_Menadzer'
ALTER TABLE [dbo].[Zaposleni_Menadzer]
ADD CONSTRAINT [FK_Menadzer_inherits_Zaposleni]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Zaposleni]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SH] in table 'Hardveri_Racunar'
ALTER TABLE [dbo].[Hardveri_Racunar]
ADD CONSTRAINT [FK_Racunar_inherits_Hardver]
    FOREIGN KEY ([SH])
    REFERENCES [dbo].[Hardveri]
        ([SH])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SH] in table 'Hardveri_Mobilni'
ALTER TABLE [dbo].[Hardveri_Mobilni]
ADD CONSTRAINT [FK_Mobilni_inherits_Hardver]
    FOREIGN KEY ([SH])
    REFERENCES [dbo].[Hardveri]
        ([SH])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------