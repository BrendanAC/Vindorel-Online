
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2015 03:04:50
-- Generated from EDMX file: C:\Users\Oğulcan Gürçağlar\Desktop\vindorel_online\Vindorel_Online\Models\VindorelOnline.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vindorel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Towns_Players]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Towns] DROP CONSTRAINT [FK_Towns_Players];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Players];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Towns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Towns];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Access] bit  NOT NULL,
    [Race] nvarchar(15)  NOT NULL,
    [Job] nvarchar(15)  NOT NULL,
    [ExpPoint] int  NOT NULL,
    [TechPoint] int  NOT NULL,
    [Gold] int  NOT NULL,
    [HeroName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Towns'
CREATE TABLE [dbo].[Towns] (
    [TownId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [x] int  NOT NULL,
    [y] int  NOT NULL,
    [TownName] nvarchar(50)  NOT NULL,
    [Wood] int  NOT NULL,
    [Food] int  NOT NULL,
    [Iron] int  NOT NULL,
    [Population] int  NOT NULL,
    [BuildingSpace1_Type] int  NOT NULL,
    [BuildingSpace1_Level] int  NOT NULL,
    [BuildingSpace2_Type] int  NOT NULL,
    [BuildingSpace2_Level] int  NOT NULL,
    [BuildingSpace3_Type] int  NOT NULL,
    [BuildingSpace3_Level] int  NOT NULL,
    [BuildingSpace4_Type] int  NOT NULL,
    [BuildingSpace4_Level] int  NOT NULL,
    [BuildingSpace5_Type] int  NOT NULL,
    [BuildingSpace5_Level] int  NOT NULL,
    [BuildingSpace6_Type] int  NOT NULL,
    [BuildingSpace6_Level] int  NOT NULL,
    [BuildingSpace7_Type] int  NOT NULL,
    [BuildingSpace7_Level] int  NOT NULL,
    [BuildingSpace8_Type] int  NOT NULL,
    [BuildingSpace8_Level] int  NOT NULL,
    [BuildingSpace9_Type] int  NOT NULL,
    [BuildingSpace9_Level] int  NOT NULL,
    [BuildingSpace10_Type] int  NOT NULL,
    [BuildingSpace10_Level] int  NOT NULL,
    [BuildingSpace11_Type] int  NOT NULL,
    [BuildingSpace11_Level] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TownId] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [PK_Towns]
    PRIMARY KEY CLUSTERED ([TownId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [FK_Towns_Players]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Players]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Towns_Players'
CREATE INDEX [IX_FK_Towns_Players]
ON [dbo].[Towns]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------