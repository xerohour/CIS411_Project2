
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/21/2013 12:18:01
-- Generated from EDMX file: C:\Users\Scott\Documents\Code_Projects\Repository\CIS411_Project\CIS411_Project.dal\BooksDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [student6];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BOOK_CATEGORY]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOOK] DROP CONSTRAINT [FK_BOOK_CATEGORY];
GO
IF OBJECT_ID(N'[dbo].[FK_BOOK_CONDITION]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOOK] DROP CONSTRAINT [FK_BOOK_CONDITION];
GO
IF OBJECT_ID(N'[dbo].[FK_BOOK_USER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BOOK] DROP CONSTRAINT [FK_BOOK_USER];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BOOK]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BOOK];
GO
IF OBJECT_ID(N'[dbo].[CATEGORY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CATEGORY];
GO
IF OBJECT_ID(N'[dbo].[CONDITION]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CONDITION];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[USER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USER];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BOOKs'
CREATE TABLE [dbo].[BOOKs] (
    [BOOK_ID] decimal(18,0)  NOT NULL,
    [BOOK_TITLE] nvarchar(50)  NULL,
    [BOOK_DESC] nvarchar(max)  NULL,
    [BOOK_AUTHOR] nvarchar(50)  NULL,
    [BOOK_EDITION] decimal(18,0)  NULL,
    [ISBN10] decimal(18,0)  NULL,
    [ISBN13] decimal(18,0)  NULL,
    [CONDITION_ID] decimal(18,0)  NOT NULL,
    [CATEGORY_ID] decimal(18,0)  NOT NULL,
    [USER_ID] decimal(18,0)  NOT NULL,
    [BOOK_PRICE] decimal(18,0)  NULL,
    [CREATED_TIMESTAMP] datetime  NULL,
    [BOOK_PUBLISHER] nvarchar(50)  NULL
);
GO

-- Creating table 'CATEGORies'
CREATE TABLE [dbo].[CATEGORies] (
    [CATEGORY_ID] decimal(18,0)  NOT NULL,
    [CATEGORY_NAME] nvarchar(50)  NULL
);
GO

-- Creating table 'CONDITIONs'
CREATE TABLE [dbo].[CONDITIONs] (
    [CONDITION_ID] decimal(18,0)  NOT NULL,
    [CONDITION_NAME] nvarchar(50)  NULL,
    [CONDITION_DESC] nvarchar(max)  NULL
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

-- Creating table 'USERs'
CREATE TABLE [dbo].[USERs] (
    [USER_ID] decimal(18,0)  NOT NULL,
    [USER_FNAME] nvarchar(50)  NULL,
    [USER_LNAME] nvarchar(50)  NULL,
    [USER_DISPLAYNAME] nvarchar(50)  NULL,
    [PASSWORD] nvarchar(50)  NULL,
    [REPUTATION] decimal(18,0)  NULL,
    [USER_EMAIL] nvarchar(50)  NULL,
    [CREATED_TIMESTAMP] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BOOK_ID] in table 'BOOKs'
ALTER TABLE [dbo].[BOOKs]
ADD CONSTRAINT [PK_BOOKs]
    PRIMARY KEY CLUSTERED ([BOOK_ID] ASC);
GO

-- Creating primary key on [CATEGORY_ID] in table 'CATEGORies'
ALTER TABLE [dbo].[CATEGORies]
ADD CONSTRAINT [PK_CATEGORies]
    PRIMARY KEY CLUSTERED ([CATEGORY_ID] ASC);
GO

-- Creating primary key on [CONDITION_ID] in table 'CONDITIONs'
ALTER TABLE [dbo].[CONDITIONs]
ADD CONSTRAINT [PK_CONDITIONs]
    PRIMARY KEY CLUSTERED ([CONDITION_ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [USER_ID] in table 'USERs'
ALTER TABLE [dbo].[USERs]
ADD CONSTRAINT [PK_USERs]
    PRIMARY KEY CLUSTERED ([USER_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CATEGORY_ID] in table 'BOOKs'
ALTER TABLE [dbo].[BOOKs]
ADD CONSTRAINT [FK_BOOK_CATEGORY]
    FOREIGN KEY ([CATEGORY_ID])
    REFERENCES [dbo].[CATEGORies]
        ([CATEGORY_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BOOK_CATEGORY'
CREATE INDEX [IX_FK_BOOK_CATEGORY]
ON [dbo].[BOOKs]
    ([CATEGORY_ID]);
GO

-- Creating foreign key on [CONDITION_ID] in table 'BOOKs'
ALTER TABLE [dbo].[BOOKs]
ADD CONSTRAINT [FK_BOOK_CONDITION]
    FOREIGN KEY ([CONDITION_ID])
    REFERENCES [dbo].[CONDITIONs]
        ([CONDITION_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BOOK_CONDITION'
CREATE INDEX [IX_FK_BOOK_CONDITION]
ON [dbo].[BOOKs]
    ([CONDITION_ID]);
GO

-- Creating foreign key on [USER_ID] in table 'BOOKs'
ALTER TABLE [dbo].[BOOKs]
ADD CONSTRAINT [FK_BOOK_USER]
    FOREIGN KEY ([USER_ID])
    REFERENCES [dbo].[USERs]
        ([USER_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BOOK_USER'
CREATE INDEX [IX_FK_BOOK_USER]
ON [dbo].[BOOKs]
    ([USER_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------