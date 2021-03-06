USE [master]
GO
/****** Object:  Database [aspnet-AppletSoftware-20180213033651]    Script Date: 2018-02-16 04:50:46 AM ******/
CREATE DATABASE [aspnet-AppletSoftware-20180213033651]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'aspnet-AppletSoftware-20180213033651.mdf', FILENAME = N'E:\Project\APPLETSOFTWARE\AppletSoftware-v1\AppletSoftware-v1\AppletSoftware\AppletSoftware\App_Data\aspnet-AppletSoftware-20180213033651.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'aspnet-AppletSoftware-20180213033651_log.ldf', FILENAME = N'E:\Project\APPLETSOFTWARE\AppletSoftware-v1\AppletSoftware-v1\AppletSoftware\AppletSoftware\App_Data\aspnet-AppletSoftware-20180213033651_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [aspnet-AppletSoftware-20180213033651].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET  ENABLE_BROKER 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET  MULTI_USER 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET QUERY_STORE = OFF
GO
USE [aspnet-AppletSoftware-20180213033651]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [aspnet-AppletSoftware-20180213033651]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetClients]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetClients](
	[Client_Id] [nvarchar](128) NOT NULL,
	[Client_Fname_Ar] [nvarchar](50) NOT NULL,
	[Client_Fname_En] [nvarchar](50) NOT NULL,
	[Client_Lname_Ar] [nvarchar](50) NOT NULL,
	[Client_Lname_En] [nvarchar](50) NOT NULL,
	[Client_Email] [nvarchar](50) NOT NULL,
	[Client_PhoneNumber] [nvarchar](15) NOT NULL,
	[Client_CompanyName_Ar] [nvarchar](50) NOT NULL,
	[Client_CompanyName_En] [nvarchar](50) NOT NULL,
	[Client_Address_Ar] [nvarchar](50) NOT NULL,
	[Client_Address_En] [nvarchar](50) NOT NULL,
	[Client_DateTime] [datetime] NOT NULL,
	[ClCat_Id] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetClients] PRIMARY KEY CLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetClientsCategories]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetClientsCategories](
	[ClCat_Id] [nvarchar](128) NOT NULL,
	[ClCat_Name_Ar] [nvarchar](50) NOT NULL,
	[ClCat_Name_En] [nvarchar](50) NOT NULL,
	[ClCat_Description_Ar] [nvarchar](500) NOT NULL,
	[ClCat_Description_En] [nvarchar](500) NOT NULL,
	[ClCat_DateTime] [datetime] NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetClientsCategories] PRIMARY KEY CLUSTERED 
(
	[ClCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetNews]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetNews](
	[News_Id] [nvarchar](128) NOT NULL,
	[News_Title_Ar] [nvarchar](250) NOT NULL,
	[News_Title_En] [nvarchar](250) NOT NULL,
	[News_Short_Ar] [nvarchar](500) NOT NULL,
	[News_Short_En] [nvarchar](500) NOT NULL,
	[News_Long_Ar] [nvarchar](max) NOT NULL,
	[News_Long_En] [nvarchar](max) NOT NULL,
	[News_DateTime] [datetime] NOT NULL,
	[News_Photo] [nvarchar](250) NOT NULL,
	[NCat_Id] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetNews] PRIMARY KEY CLUSTERED 
(
	[News_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetNewsCategories]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetNewsCategories](
	[NCat_Id] [nvarchar](128) NOT NULL,
	[NCat_Name_Ar] [nvarchar](50) NOT NULL,
	[NCat_Name_En] [nvarchar](50) NOT NULL,
	[NCat_DateTime] [datetime] NOT NULL,
	[NCat_Description_Ar] [nvarchar](500) NOT NULL,
	[NCat_Description_En] [nvarchar](500) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetNewsCategories] PRIMARY KEY CLUSTERED 
(
	[NCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetPlans]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetPlans](
	[Plan_Id] [nvarchar](128) NOT NULL,
	[Plan_Name_Ar] [nvarchar](50) NOT NULL,
	[Plan_Name_En] [nvarchar](50) NOT NULL,
	[Plan_Price] [decimal](18, 0) NOT NULL,
	[Plan_DateTime] [datetime] NOT NULL,
	[Plan_Description_Ar] [nvarchar](max) NOT NULL,
	[Plan_Description_En] [nvarchar](max) NOT NULL,
	[PlanCat_Id] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetPlans] PRIMARY KEY CLUSTERED 
(
	[Plan_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetPlansCategories]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetPlansCategories](
	[PlanCat_Id] [nvarchar](128) NOT NULL,
	[PlanCat_Name_Ar] [nvarchar](50) NOT NULL,
	[PlanCat_Name_En] [nvarchar](50) NOT NULL,
	[PlanCat_Description_Ar] [nvarchar](500) NOT NULL,
	[PlanCat_Description_En] [nvarchar](500) NOT NULL,
	[PlanCat_DateTime] [datetime] NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetPlansCategories] PRIMARY KEY CLUSTERED 
(
	[PlanCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetProjects]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetProjects](
	[Project_Id] [nvarchar](128) NOT NULL,
	[Project_Name_Ar] [nvarchar](250) NOT NULL,
	[Project_Name_En] [nvarchar](250) NOT NULL,
	[Project_DateTime] [datetime] NOT NULL,
	[Project_Photo] [nvarchar](128) NOT NULL,
	[Project_Url] [nvarchar](250) NULL,
	[Project_Descrption_Ar] [nvarchar](500) NOT NULL,
	[Project_Descrption_En] [nvarchar](500) NOT NULL,
	[PCat_Id] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetProjects] PRIMARY KEY CLUSTERED 
(
	[Project_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetProjectsCategories]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetProjectsCategories](
	[PCat_Id] [nvarchar](128) NOT NULL,
	[PCat_Name_Ar] [nvarchar](250) NOT NULL,
	[PCat_Name_En] [nvarchar](250) NOT NULL,
	[PCat_DateTime] [datetime] NOT NULL,
	[PCat_Description_Ar] [nvarchar](500) NOT NULL,
	[PCat_Description_En] [nvarchar](500) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetProjectsCategories] PRIMARY KEY CLUSTERED 
(
	[PCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetTeams]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetTeams](
	[Team_Id] [nvarchar](128) NOT NULL,
	[Team_Fname_Ar] [nvarchar](50) NOT NULL,
	[Team_Fname_En] [nvarchar](50) NOT NULL,
	[Team_Lname_Ar] [nvarchar](50) NOT NULL,
	[Team_Lname_En] [nvarchar](50) NOT NULL,
	[Team_Email] [nvarchar](50) NOT NULL,
	[Team_Phone] [nvarchar](50) NOT NULL,
	[Team_Photo] [nvarchar](50) NOT NULL,
	[Team_DateTime] [datetime] NOT NULL,
	[TCat_Id] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
	[Team_Salary] [decimal](18, 0) NOT NULL,
	[Team_JobTitle_Ar] [nvarchar](50) NOT NULL,
	[Team_JobTitle_En] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AspNetTeams] PRIMARY KEY CLUSTERED 
(
	[Team_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetTeamsCategories]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetTeamsCategories](
	[TCat_Id] [nvarchar](128) NOT NULL,
	[TCat_Name_Ar] [nvarchar](50) NOT NULL,
	[TCat_Name_En] [nvarchar](50) NOT NULL,
	[TCat_DateTime] [datetime] NOT NULL,
	[TCat_Description_Ar] [nvarchar](500) NOT NULL,
	[TCat_Description_En] [nvarchar](500) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetTeamsCategories] PRIMARY KEY CLUSTERED 
(
	[TCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetTestmonials]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetTestmonials](
	[Testmonial_Id] [nvarchar](128) NOT NULL,
	[Testmonial_Question_Ar] [nvarchar](250) NOT NULL,
	[Testmonial_Question_En] [nvarchar](250) NOT NULL,
	[Testmonial_Answer_Ar] [nvarchar](max) NOT NULL,
	[Testmonial_Answer_En] [nvarchar](max) NOT NULL,
	[Testmonial_DateTime] [datetime] NOT NULL,
	[Testmonial_ClientName_Ar] [nvarchar](50) NOT NULL,
	[Testmonial_ClientName_En] [nvarchar](50) NOT NULL,
	[Testmonial_ClientJobTitle_Ar] [nvarchar](50) NOT NULL,
	[Testmonial_ClientJobTitle_En] [nvarchar](50) NOT NULL,
	[Testmonial_ClientPhoto] [nvarchar](150) NOT NULL,
	[TsCat_Id] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetTestmonials] PRIMARY KEY CLUSTERED 
(
	[Testmonial_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetTestmonialsCategories]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetTestmonialsCategories](
	[TsCat_Id] [nvarchar](128) NOT NULL,
	[TsCat_Name_Ar] [nvarchar](50) NOT NULL,
	[TsCat_Name_En] [nvarchar](50) NOT NULL,
	[TsCat_DateTime] [datetime] NOT NULL,
	[TsCat_Description_En] [nvarchar](500) NOT NULL,
	[TsCat_Description_Ar] [nvarchar](500) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetTestmonialsCategories] PRIMARY KEY CLUSTERED 
(
	[TsCat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsersInfoPlus]    Script Date: 2018-02-16 04:50:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsersInfoPlus](
	[UInfoPlus_Id] [nvarchar](128) NOT NULL,
	[UInfoPlus_Fname_En] [nvarchar](50) NOT NULL,
	[UInfoPlus_Fname_Ar] [nvarchar](50) NOT NULL,
	[UInfo_Lname_En] [nvarchar](50) NOT NULL,
	[UInfo_Lname_Ar] [nvarchar](50) NOT NULL,
	[UInfo_Photo] [nvarchar](50) NOT NULL,
	[Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUsersInfoPlus] PRIMARY KEY CLUSTERED 
(
	[UInfoPlus_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2018-02-16 04:50:47 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 2018-02-16 04:50:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 2018-02-16 04:50:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 2018-02-16 04:50:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 2018-02-16 04:50:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 2018-02-16 04:50:47 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetClients]  WITH CHECK ADD  CONSTRAINT [FK_AspNetClients_AspNetClientsCategories] FOREIGN KEY([ClCat_Id])
REFERENCES [dbo].[AspNetClientsCategories] ([ClCat_Id])
GO
ALTER TABLE [dbo].[AspNetClients] CHECK CONSTRAINT [FK_AspNetClients_AspNetClientsCategories]
GO
ALTER TABLE [dbo].[AspNetClients]  WITH CHECK ADD  CONSTRAINT [FK_AspNetClients_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetClients] CHECK CONSTRAINT [FK_AspNetClients_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetClientsCategories]  WITH CHECK ADD  CONSTRAINT [FK_AspNetClientsCategories_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetClientsCategories] CHECK CONSTRAINT [FK_AspNetClientsCategories_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetNews]  WITH CHECK ADD  CONSTRAINT [FK_AspNetNews_AspNetNewsCategories] FOREIGN KEY([NCat_Id])
REFERENCES [dbo].[AspNetNewsCategories] ([NCat_Id])
GO
ALTER TABLE [dbo].[AspNetNews] CHECK CONSTRAINT [FK_AspNetNews_AspNetNewsCategories]
GO
ALTER TABLE [dbo].[AspNetNews]  WITH CHECK ADD  CONSTRAINT [FK_AspNetNews_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetNews] CHECK CONSTRAINT [FK_AspNetNews_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetNewsCategories]  WITH CHECK ADD  CONSTRAINT [FK_AspNetNewsCategories_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetNewsCategories] CHECK CONSTRAINT [FK_AspNetNewsCategories_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetPlans]  WITH CHECK ADD  CONSTRAINT [FK_AspNetPlans_AspNetPlansCategories] FOREIGN KEY([PlanCat_Id])
REFERENCES [dbo].[AspNetPlansCategories] ([PlanCat_Id])
GO
ALTER TABLE [dbo].[AspNetPlans] CHECK CONSTRAINT [FK_AspNetPlans_AspNetPlansCategories]
GO
ALTER TABLE [dbo].[AspNetPlans]  WITH CHECK ADD  CONSTRAINT [FK_AspNetPlans_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetPlans] CHECK CONSTRAINT [FK_AspNetPlans_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetProjects]  WITH CHECK ADD  CONSTRAINT [FK_AspNetProjects_AspNetProjectsCategories] FOREIGN KEY([PCat_Id])
REFERENCES [dbo].[AspNetProjectsCategories] ([PCat_Id])
GO
ALTER TABLE [dbo].[AspNetProjects] CHECK CONSTRAINT [FK_AspNetProjects_AspNetProjectsCategories]
GO
ALTER TABLE [dbo].[AspNetProjects]  WITH CHECK ADD  CONSTRAINT [FK_AspNetProjects_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetProjects] CHECK CONSTRAINT [FK_AspNetProjects_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetProjectsCategories]  WITH CHECK ADD  CONSTRAINT [FK_AspNetProjectsCategories_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetProjectsCategories] CHECK CONSTRAINT [FK_AspNetProjectsCategories_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetTeams]  WITH CHECK ADD  CONSTRAINT [FK_AspNetTeams_AspNetTeamsCategories] FOREIGN KEY([TCat_Id])
REFERENCES [dbo].[AspNetTeamsCategories] ([TCat_Id])
GO
ALTER TABLE [dbo].[AspNetTeams] CHECK CONSTRAINT [FK_AspNetTeams_AspNetTeamsCategories]
GO
ALTER TABLE [dbo].[AspNetTeams]  WITH CHECK ADD  CONSTRAINT [FK_AspNetTeams_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetTeams] CHECK CONSTRAINT [FK_AspNetTeams_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetTeamsCategories]  WITH CHECK ADD  CONSTRAINT [FK_AspNetTeamsCategories_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetTeamsCategories] CHECK CONSTRAINT [FK_AspNetTeamsCategories_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetTestmonials]  WITH CHECK ADD  CONSTRAINT [FK_AspNetTestmonials_AspNetTestmonialsCategories] FOREIGN KEY([TsCat_Id])
REFERENCES [dbo].[AspNetTestmonialsCategories] ([TsCat_Id])
GO
ALTER TABLE [dbo].[AspNetTestmonials] CHECK CONSTRAINT [FK_AspNetTestmonials_AspNetTestmonialsCategories]
GO
ALTER TABLE [dbo].[AspNetTestmonials]  WITH CHECK ADD  CONSTRAINT [FK_AspNetTestmonials_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetTestmonials] CHECK CONSTRAINT [FK_AspNetTestmonials_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetTestmonialsCategories]  WITH CHECK ADD  CONSTRAINT [FK_AspNetTestmonialsCategories_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetTestmonialsCategories] CHECK CONSTRAINT [FK_AspNetTestmonialsCategories_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsersInfoPlus]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsersInfoPlus_AspNetUsers] FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsersInfoPlus] CHECK CONSTRAINT [FK_AspNetUsersInfoPlus_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [aspnet-AppletSoftware-20180213033651] SET  READ_WRITE 
GO
