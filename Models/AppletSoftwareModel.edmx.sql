
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/03/2020 09:34:24
-- Generated from EDMX file: E:\Project\APPLETSOFTWARE\AppletSoftware-v1\AppletSoftware-v1\AppletSoftware\AppletSoftware\Models\AppletSoftwareModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-AppletSoftware-20180213033651];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetClients_AspNetClientsCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetClients] DROP CONSTRAINT [FK_AspNetClients_AspNetClientsCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetClients_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetClients] DROP CONSTRAINT [FK_AspNetClients_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetClientsCategories_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetClientsCategories] DROP CONSTRAINT [FK_AspNetClientsCategories_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetNews_AspNetNewsCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetNews] DROP CONSTRAINT [FK_AspNetNews_AspNetNewsCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetNews_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetNews] DROP CONSTRAINT [FK_AspNetNews_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetNewsCategories_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetNewsCategories] DROP CONSTRAINT [FK_AspNetNewsCategories_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetPlans_AspNetPlansCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetPlans] DROP CONSTRAINT [FK_AspNetPlans_AspNetPlansCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetPlans_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetPlans] DROP CONSTRAINT [FK_AspNetPlans_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetProjects_AspNetProjectsCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetProjects] DROP CONSTRAINT [FK_AspNetProjects_AspNetProjectsCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetProjects_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetProjects] DROP CONSTRAINT [FK_AspNetProjects_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetProjectsCategories_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetProjectsCategories] DROP CONSTRAINT [FK_AspNetProjectsCategories_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetTeams_AspNetTeamsCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetTeams] DROP CONSTRAINT [FK_AspNetTeams_AspNetTeamsCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetTeams_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetTeams] DROP CONSTRAINT [FK_AspNetTeams_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetTeamsCategories_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetTeamsCategories] DROP CONSTRAINT [FK_AspNetTeamsCategories_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetTestmonials_AspNetTestmonialsCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetTestmonials] DROP CONSTRAINT [FK_AspNetTestmonials_AspNetTestmonialsCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetTestmonials_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetTestmonials] DROP CONSTRAINT [FK_AspNetTestmonials_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetTestmonialsCategories_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetTestmonialsCategories] DROP CONSTRAINT [FK_AspNetTestmonialsCategories_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUsersInfoPlus_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsersInfoPlus] DROP CONSTRAINT [FK_AspNetUsersInfoPlus_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetClients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetClients];
GO
IF OBJECT_ID(N'[dbo].[AspNetClientsCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetClientsCategories];
GO
IF OBJECT_ID(N'[dbo].[AspNetNews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetNews];
GO
IF OBJECT_ID(N'[dbo].[AspNetNewsCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetNewsCategories];
GO
IF OBJECT_ID(N'[dbo].[AspNetPlans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetPlans];
GO
IF OBJECT_ID(N'[dbo].[AspNetPlansCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetPlansCategories];
GO
IF OBJECT_ID(N'[dbo].[AspNetProjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetProjects];
GO
IF OBJECT_ID(N'[dbo].[AspNetProjectsCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetProjectsCategories];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetTeams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetTeams];
GO
IF OBJECT_ID(N'[dbo].[AspNetTeamsCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetTeamsCategories];
GO
IF OBJECT_ID(N'[dbo].[AspNetTestmonials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetTestmonials];
GO
IF OBJECT_ID(N'[dbo].[AspNetTestmonialsCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetTestmonialsCategories];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsersInfoPlus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsersInfoPlus];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetClients'
CREATE TABLE [dbo].[AspNetClients] (
    [Client_Id] nvarchar(128)  NOT NULL,
    [Client_Fname_Ar] nvarchar(50)  NOT NULL,
    [Client_Fname_En] nvarchar(50)  NOT NULL,
    [Client_Lname_Ar] nvarchar(50)  NOT NULL,
    [Client_Lname_En] nvarchar(50)  NOT NULL,
    [Client_Email] nvarchar(50)  NOT NULL,
    [Client_PhoneNumber] nvarchar(15)  NOT NULL,
    [Client_CompanyName_Ar] nvarchar(50)  NOT NULL,
    [Client_CompanyName_En] nvarchar(50)  NOT NULL,
    [Client_Address_Ar] nvarchar(50)  NOT NULL,
    [Client_Address_En] nvarchar(50)  NOT NULL,
    [Client_DateTime] datetime  NOT NULL,
    [ClCat_Id] nvarchar(128)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL,
    [Client_Photo] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'AspNetClientsCategories'
CREATE TABLE [dbo].[AspNetClientsCategories] (
    [ClCat_Id] nvarchar(128)  NOT NULL,
    [ClCat_Name_Ar] nvarchar(50)  NOT NULL,
    [ClCat_Name_En] nvarchar(50)  NOT NULL,
    [ClCat_Description_Ar] nvarchar(500)  NOT NULL,
    [ClCat_Description_En] nvarchar(500)  NOT NULL,
    [ClCat_DateTime] datetime  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetNews'
CREATE TABLE [dbo].[AspNetNews] (
    [News_Id] nvarchar(128)  NOT NULL,
    [News_Title_Ar] nvarchar(250)  NOT NULL,
    [News_Title_En] nvarchar(250)  NOT NULL,
    [News_Short_Ar] nvarchar(500)  NOT NULL,
    [News_Short_En] nvarchar(500)  NOT NULL,
    [News_Long_Ar] nvarchar(max)  NOT NULL,
    [News_Long_En] nvarchar(max)  NOT NULL,
    [News_DateTime] datetime  NOT NULL,
    [News_Photo] nvarchar(250)  NOT NULL,
    [NCat_Id] nvarchar(128)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetNewsCategories'
CREATE TABLE [dbo].[AspNetNewsCategories] (
    [NCat_Id] nvarchar(128)  NOT NULL,
    [NCat_Name_Ar] nvarchar(50)  NOT NULL,
    [NCat_Name_En] nvarchar(50)  NOT NULL,
    [NCat_DateTime] datetime  NOT NULL,
    [NCat_Description_Ar] nvarchar(500)  NOT NULL,
    [NCat_Description_En] nvarchar(500)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetPlans'
CREATE TABLE [dbo].[AspNetPlans] (
    [Plan_Id] nvarchar(128)  NOT NULL,
    [Plan_Name_Ar] nvarchar(50)  NOT NULL,
    [Plan_Name_En] nvarchar(50)  NOT NULL,
    [Plan_Price] decimal(18,0)  NOT NULL,
    [Plan_DateTime] datetime  NOT NULL,
    [Plan_Description_Ar] nvarchar(max)  NOT NULL,
    [Plan_Description_En] nvarchar(max)  NOT NULL,
    [PlanCat_Id] nvarchar(128)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetPlansCategories'
CREATE TABLE [dbo].[AspNetPlansCategories] (
    [PlanCat_Id] nvarchar(128)  NOT NULL,
    [PlanCat_Name_Ar] nvarchar(50)  NOT NULL,
    [PlanCat_Name_En] nvarchar(50)  NOT NULL,
    [PlanCat_Description_Ar] nvarchar(500)  NOT NULL,
    [PlanCat_Description_En] nvarchar(500)  NOT NULL,
    [PlanCat_DateTime] datetime  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetProjects'
CREATE TABLE [dbo].[AspNetProjects] (
    [Project_Id] nvarchar(128)  NOT NULL,
    [Project_Name_Ar] nvarchar(250)  NOT NULL,
    [Project_Name_En] nvarchar(250)  NOT NULL,
    [Project_DateTime] datetime  NOT NULL,
    [Project_Photo] nvarchar(128)  NOT NULL,
    [Project_Url] nvarchar(250)  NULL,
    [Project_Descrption_Ar] nvarchar(500)  NOT NULL,
    [Project_Descrption_En] nvarchar(500)  NOT NULL,
    [PCat_Id] nvarchar(128)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetProjectsCategories'
CREATE TABLE [dbo].[AspNetProjectsCategories] (
    [PCat_Id] nvarchar(128)  NOT NULL,
    [PCat_Name_Ar] nvarchar(250)  NOT NULL,
    [PCat_Name_En] nvarchar(250)  NOT NULL,
    [PCat_DateTime] datetime  NOT NULL,
    [PCat_Description_Ar] nvarchar(500)  NOT NULL,
    [PCat_Description_En] nvarchar(500)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetTeams'
CREATE TABLE [dbo].[AspNetTeams] (
    [Team_Id] nvarchar(128)  NOT NULL,
    [Team_Fname_Ar] nvarchar(50)  NOT NULL,
    [Team_Fname_En] nvarchar(50)  NOT NULL,
    [Team_Lname_Ar] nvarchar(50)  NOT NULL,
    [Team_Lname_En] nvarchar(50)  NOT NULL,
    [Team_Email] nvarchar(50)  NOT NULL,
    [Team_Phone] nvarchar(50)  NOT NULL,
    [Team_Photo] nvarchar(50)  NOT NULL,
    [Team_DateTime] datetime  NOT NULL,
    [TCat_Id] nvarchar(128)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL,
    [Team_Salary] decimal(18,0)  NOT NULL,
    [Team_JobTitle_Ar] nvarchar(50)  NOT NULL,
    [Team_JobTitle_En] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AspNetTeamsCategories'
CREATE TABLE [dbo].[AspNetTeamsCategories] (
    [TCat_Id] nvarchar(128)  NOT NULL,
    [TCat_Name_Ar] nvarchar(50)  NOT NULL,
    [TCat_Name_En] nvarchar(50)  NOT NULL,
    [TCat_DateTime] datetime  NOT NULL,
    [TCat_Description_Ar] nvarchar(500)  NOT NULL,
    [TCat_Description_En] nvarchar(500)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetTestmonials'
CREATE TABLE [dbo].[AspNetTestmonials] (
    [Testmonial_Id] nvarchar(128)  NOT NULL,
    [Testmonial_Question_Ar] nvarchar(250)  NOT NULL,
    [Testmonial_Question_En] nvarchar(250)  NOT NULL,
    [Testmonial_Answer_Ar] nvarchar(max)  NOT NULL,
    [Testmonial_Answer_En] nvarchar(max)  NOT NULL,
    [Testmonial_DateTime] datetime  NOT NULL,
    [Testmonial_ClientName_Ar] nvarchar(50)  NOT NULL,
    [Testmonial_ClientName_En] nvarchar(50)  NOT NULL,
    [Testmonial_ClientJobTitle_Ar] nvarchar(50)  NOT NULL,
    [Testmonial_ClientJobTitle_En] nvarchar(50)  NOT NULL,
    [Testmonial_ClientPhoto] nvarchar(150)  NOT NULL,
    [TsCat_Id] nvarchar(128)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetTestmonialsCategories'
CREATE TABLE [dbo].[AspNetTestmonialsCategories] (
    [TsCat_Id] nvarchar(128)  NOT NULL,
    [TsCat_Name_Ar] nvarchar(50)  NOT NULL,
    [TsCat_Name_En] nvarchar(50)  NOT NULL,
    [TsCat_DateTime] datetime  NOT NULL,
    [TsCat_Description_En] nvarchar(500)  NOT NULL,
    [TsCat_Description_Ar] nvarchar(500)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUsersInfoPlus'
CREATE TABLE [dbo].[AspNetUsersInfoPlus] (
    [UInfoPlus_Id] nvarchar(128)  NOT NULL,
    [UInfoPlus_Fname_En] nvarchar(50)  NOT NULL,
    [UInfoPlus_Fname_Ar] nvarchar(50)  NOT NULL,
    [UInfo_Lname_En] nvarchar(50)  NOT NULL,
    [UInfo_Lname_Ar] nvarchar(50)  NOT NULL,
    [UInfo_Photo] nvarchar(50)  NOT NULL,
    [Id] nvarchar(128)  NOT NULL,
    [UInfo_DateTime] datetime  NOT NULL,
    [UInfo_Publisher] nvarchar(128)  NOT NULL
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

-- Creating table 'AspNetMessages'
CREATE TABLE [dbo].[AspNetMessages] (
    [Message_Id] nvarchar(128)  NOT NULL,
    [Message_Email] nvarchar(50)  NOT NULL,
    [Message_Subject] nvarchar(50)  NOT NULL,
    [Message_Content] nvarchar(max)  NOT NULL,
    [Message_Active] bit  NOT NULL,
    [Message_Response] bit  NOT NULL,
    [Message_DateTime] datetime  NOT NULL
);
GO

-- Creating table 'AspNetNewsLetters'
CREATE TABLE [dbo].[AspNetNewsLetters] (
    [Letter_Id] nvarchar(128)  NOT NULL,
    [Letter_Email] nvarchar(50)  NOT NULL,
    [Letter_Active] bit  NOT NULL,
    [Letter_Response] bit  NOT NULL,
    [Letter_DateTime] datetime  NOT NULL
);
GO

-- Creating table 'AspNetNotifications'
CREATE TABLE [dbo].[AspNetNotifications] (
    [Notify_Id] nvarchar(128)  NOT NULL,
    [Notify_Manager_Name] nvarchar(128)  NOT NULL,
    [Notify_Manager_Photo] nvarchar(128)  NOT NULL,
    [Notify_Title] nvarchar(128)  NOT NULL,
    [Notify_DateTime] datetime  NOT NULL,
    [Notify_Active] bit  NOT NULL,
    [Notify_Action] nvarchar(50)  NOT NULL,
    [Notify_Manager_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetPlanOrders'
CREATE TABLE [dbo].[AspNetPlanOrders] (
    [Order_Id] nvarchar(128)  NOT NULL,
    [Order_Email] nvarchar(50)  NOT NULL,
    [Order_Phone] nvarchar(50)  NOT NULL,
    [Order_Plan] nvarchar(150)  NOT NULL,
    [Order_Message] nvarchar(max)  NULL,
    [Order_Fname] nvarchar(50)  NOT NULL,
    [Order_Lname] nvarchar(50)  NOT NULL,
    [Order_Response] bit  NOT NULL,
    [Order_DateTime] datetime  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Client_Id] in table 'AspNetClients'
ALTER TABLE [dbo].[AspNetClients]
ADD CONSTRAINT [PK_AspNetClients]
    PRIMARY KEY CLUSTERED ([Client_Id] ASC);
GO

-- Creating primary key on [ClCat_Id] in table 'AspNetClientsCategories'
ALTER TABLE [dbo].[AspNetClientsCategories]
ADD CONSTRAINT [PK_AspNetClientsCategories]
    PRIMARY KEY CLUSTERED ([ClCat_Id] ASC);
GO

-- Creating primary key on [News_Id] in table 'AspNetNews'
ALTER TABLE [dbo].[AspNetNews]
ADD CONSTRAINT [PK_AspNetNews]
    PRIMARY KEY CLUSTERED ([News_Id] ASC);
GO

-- Creating primary key on [NCat_Id] in table 'AspNetNewsCategories'
ALTER TABLE [dbo].[AspNetNewsCategories]
ADD CONSTRAINT [PK_AspNetNewsCategories]
    PRIMARY KEY CLUSTERED ([NCat_Id] ASC);
GO

-- Creating primary key on [Plan_Id] in table 'AspNetPlans'
ALTER TABLE [dbo].[AspNetPlans]
ADD CONSTRAINT [PK_AspNetPlans]
    PRIMARY KEY CLUSTERED ([Plan_Id] ASC);
GO

-- Creating primary key on [PlanCat_Id] in table 'AspNetPlansCategories'
ALTER TABLE [dbo].[AspNetPlansCategories]
ADD CONSTRAINT [PK_AspNetPlansCategories]
    PRIMARY KEY CLUSTERED ([PlanCat_Id] ASC);
GO

-- Creating primary key on [Project_Id] in table 'AspNetProjects'
ALTER TABLE [dbo].[AspNetProjects]
ADD CONSTRAINT [PK_AspNetProjects]
    PRIMARY KEY CLUSTERED ([Project_Id] ASC);
GO

-- Creating primary key on [PCat_Id] in table 'AspNetProjectsCategories'
ALTER TABLE [dbo].[AspNetProjectsCategories]
ADD CONSTRAINT [PK_AspNetProjectsCategories]
    PRIMARY KEY CLUSTERED ([PCat_Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Team_Id] in table 'AspNetTeams'
ALTER TABLE [dbo].[AspNetTeams]
ADD CONSTRAINT [PK_AspNetTeams]
    PRIMARY KEY CLUSTERED ([Team_Id] ASC);
GO

-- Creating primary key on [TCat_Id] in table 'AspNetTeamsCategories'
ALTER TABLE [dbo].[AspNetTeamsCategories]
ADD CONSTRAINT [PK_AspNetTeamsCategories]
    PRIMARY KEY CLUSTERED ([TCat_Id] ASC);
GO

-- Creating primary key on [Testmonial_Id] in table 'AspNetTestmonials'
ALTER TABLE [dbo].[AspNetTestmonials]
ADD CONSTRAINT [PK_AspNetTestmonials]
    PRIMARY KEY CLUSTERED ([Testmonial_Id] ASC);
GO

-- Creating primary key on [TsCat_Id] in table 'AspNetTestmonialsCategories'
ALTER TABLE [dbo].[AspNetTestmonialsCategories]
ADD CONSTRAINT [PK_AspNetTestmonialsCategories]
    PRIMARY KEY CLUSTERED ([TsCat_Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UInfoPlus_Id] in table 'AspNetUsersInfoPlus'
ALTER TABLE [dbo].[AspNetUsersInfoPlus]
ADD CONSTRAINT [PK_AspNetUsersInfoPlus]
    PRIMARY KEY CLUSTERED ([UInfoPlus_Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Message_Id] in table 'AspNetMessages'
ALTER TABLE [dbo].[AspNetMessages]
ADD CONSTRAINT [PK_AspNetMessages]
    PRIMARY KEY CLUSTERED ([Message_Id] ASC);
GO

-- Creating primary key on [Letter_Id] in table 'AspNetNewsLetters'
ALTER TABLE [dbo].[AspNetNewsLetters]
ADD CONSTRAINT [PK_AspNetNewsLetters]
    PRIMARY KEY CLUSTERED ([Letter_Id] ASC);
GO

-- Creating primary key on [Notify_Id] in table 'AspNetNotifications'
ALTER TABLE [dbo].[AspNetNotifications]
ADD CONSTRAINT [PK_AspNetNotifications]
    PRIMARY KEY CLUSTERED ([Notify_Id] ASC);
GO

-- Creating primary key on [Order_Id] in table 'AspNetPlanOrders'
ALTER TABLE [dbo].[AspNetPlanOrders]
ADD CONSTRAINT [PK_AspNetPlanOrders]
    PRIMARY KEY CLUSTERED ([Order_Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClCat_Id] in table 'AspNetClients'
ALTER TABLE [dbo].[AspNetClients]
ADD CONSTRAINT [FK_AspNetClients_AspNetClientsCategories]
    FOREIGN KEY ([ClCat_Id])
    REFERENCES [dbo].[AspNetClientsCategories]
        ([ClCat_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetClients_AspNetClientsCategories'
CREATE INDEX [IX_FK_AspNetClients_AspNetClientsCategories]
ON [dbo].[AspNetClients]
    ([ClCat_Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetClients'
ALTER TABLE [dbo].[AspNetClients]
ADD CONSTRAINT [FK_AspNetClients_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetClients_AspNetUsers'
CREATE INDEX [IX_FK_AspNetClients_AspNetUsers]
ON [dbo].[AspNetClients]
    ([Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetClientsCategories'
ALTER TABLE [dbo].[AspNetClientsCategories]
ADD CONSTRAINT [FK_AspNetClientsCategories_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetClientsCategories_AspNetUsers'
CREATE INDEX [IX_FK_AspNetClientsCategories_AspNetUsers]
ON [dbo].[AspNetClientsCategories]
    ([Id]);
GO

-- Creating foreign key on [NCat_Id] in table 'AspNetNews'
ALTER TABLE [dbo].[AspNetNews]
ADD CONSTRAINT [FK_AspNetNews_AspNetNewsCategories]
    FOREIGN KEY ([NCat_Id])
    REFERENCES [dbo].[AspNetNewsCategories]
        ([NCat_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetNews_AspNetNewsCategories'
CREATE INDEX [IX_FK_AspNetNews_AspNetNewsCategories]
ON [dbo].[AspNetNews]
    ([NCat_Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetNews'
ALTER TABLE [dbo].[AspNetNews]
ADD CONSTRAINT [FK_AspNetNews_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetNews_AspNetUsers'
CREATE INDEX [IX_FK_AspNetNews_AspNetUsers]
ON [dbo].[AspNetNews]
    ([Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetNewsCategories'
ALTER TABLE [dbo].[AspNetNewsCategories]
ADD CONSTRAINT [FK_AspNetNewsCategories_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetNewsCategories_AspNetUsers'
CREATE INDEX [IX_FK_AspNetNewsCategories_AspNetUsers]
ON [dbo].[AspNetNewsCategories]
    ([Id]);
GO

-- Creating foreign key on [PlanCat_Id] in table 'AspNetPlans'
ALTER TABLE [dbo].[AspNetPlans]
ADD CONSTRAINT [FK_AspNetPlans_AspNetPlansCategories]
    FOREIGN KEY ([PlanCat_Id])
    REFERENCES [dbo].[AspNetPlansCategories]
        ([PlanCat_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetPlans_AspNetPlansCategories'
CREATE INDEX [IX_FK_AspNetPlans_AspNetPlansCategories]
ON [dbo].[AspNetPlans]
    ([PlanCat_Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetPlans'
ALTER TABLE [dbo].[AspNetPlans]
ADD CONSTRAINT [FK_AspNetPlans_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetPlans_AspNetUsers'
CREATE INDEX [IX_FK_AspNetPlans_AspNetUsers]
ON [dbo].[AspNetPlans]
    ([Id]);
GO

-- Creating foreign key on [PCat_Id] in table 'AspNetProjects'
ALTER TABLE [dbo].[AspNetProjects]
ADD CONSTRAINT [FK_AspNetProjects_AspNetProjectsCategories]
    FOREIGN KEY ([PCat_Id])
    REFERENCES [dbo].[AspNetProjectsCategories]
        ([PCat_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetProjects_AspNetProjectsCategories'
CREATE INDEX [IX_FK_AspNetProjects_AspNetProjectsCategories]
ON [dbo].[AspNetProjects]
    ([PCat_Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetProjects'
ALTER TABLE [dbo].[AspNetProjects]
ADD CONSTRAINT [FK_AspNetProjects_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetProjects_AspNetUsers'
CREATE INDEX [IX_FK_AspNetProjects_AspNetUsers]
ON [dbo].[AspNetProjects]
    ([Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetProjectsCategories'
ALTER TABLE [dbo].[AspNetProjectsCategories]
ADD CONSTRAINT [FK_AspNetProjectsCategories_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetProjectsCategories_AspNetUsers'
CREATE INDEX [IX_FK_AspNetProjectsCategories_AspNetUsers]
ON [dbo].[AspNetProjectsCategories]
    ([Id]);
GO

-- Creating foreign key on [TCat_Id] in table 'AspNetTeams'
ALTER TABLE [dbo].[AspNetTeams]
ADD CONSTRAINT [FK_AspNetTeams_AspNetTeamsCategories]
    FOREIGN KEY ([TCat_Id])
    REFERENCES [dbo].[AspNetTeamsCategories]
        ([TCat_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetTeams_AspNetTeamsCategories'
CREATE INDEX [IX_FK_AspNetTeams_AspNetTeamsCategories]
ON [dbo].[AspNetTeams]
    ([TCat_Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetTeams'
ALTER TABLE [dbo].[AspNetTeams]
ADD CONSTRAINT [FK_AspNetTeams_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetTeams_AspNetUsers'
CREATE INDEX [IX_FK_AspNetTeams_AspNetUsers]
ON [dbo].[AspNetTeams]
    ([Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetTeamsCategories'
ALTER TABLE [dbo].[AspNetTeamsCategories]
ADD CONSTRAINT [FK_AspNetTeamsCategories_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetTeamsCategories_AspNetUsers'
CREATE INDEX [IX_FK_AspNetTeamsCategories_AspNetUsers]
ON [dbo].[AspNetTeamsCategories]
    ([Id]);
GO

-- Creating foreign key on [TsCat_Id] in table 'AspNetTestmonials'
ALTER TABLE [dbo].[AspNetTestmonials]
ADD CONSTRAINT [FK_AspNetTestmonials_AspNetTestmonialsCategories]
    FOREIGN KEY ([TsCat_Id])
    REFERENCES [dbo].[AspNetTestmonialsCategories]
        ([TsCat_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetTestmonials_AspNetTestmonialsCategories'
CREATE INDEX [IX_FK_AspNetTestmonials_AspNetTestmonialsCategories]
ON [dbo].[AspNetTestmonials]
    ([TsCat_Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetTestmonials'
ALTER TABLE [dbo].[AspNetTestmonials]
ADD CONSTRAINT [FK_AspNetTestmonials_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetTestmonials_AspNetUsers'
CREATE INDEX [IX_FK_AspNetTestmonials_AspNetUsers]
ON [dbo].[AspNetTestmonials]
    ([Id]);
GO

-- Creating foreign key on [Id] in table 'AspNetTestmonialsCategories'
ALTER TABLE [dbo].[AspNetTestmonialsCategories]
ADD CONSTRAINT [FK_AspNetTestmonialsCategories_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetTestmonialsCategories_AspNetUsers'
CREATE INDEX [IX_FK_AspNetTestmonialsCategories_AspNetUsers]
ON [dbo].[AspNetTestmonialsCategories]
    ([Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [Id] in table 'AspNetUsersInfoPlus'
ALTER TABLE [dbo].[AspNetUsersInfoPlus]
ADD CONSTRAINT [FK_AspNetUsersInfoPlus_AspNetUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUsersInfoPlus_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUsersInfoPlus_AspNetUsers]
ON [dbo].[AspNetUsersInfoPlus]
    ([Id]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------