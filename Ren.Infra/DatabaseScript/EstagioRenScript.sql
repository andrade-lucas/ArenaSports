USE [master]
GO
/****** Object:  Database [EstagioRen]    Script Date: 03/10/2019 17:08:28 ******/
CREATE DATABASE [EstagioRen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EstagioRen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EstagioRen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EstagioRen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EstagioRen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EstagioRen] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EstagioRen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EstagioRen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EstagioRen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EstagioRen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EstagioRen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EstagioRen] SET ARITHABORT OFF 
GO
ALTER DATABASE [EstagioRen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EstagioRen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EstagioRen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EstagioRen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EstagioRen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EstagioRen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EstagioRen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EstagioRen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EstagioRen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EstagioRen] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EstagioRen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EstagioRen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EstagioRen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EstagioRen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EstagioRen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EstagioRen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EstagioRen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EstagioRen] SET RECOVERY FULL 
GO
ALTER DATABASE [EstagioRen] SET  MULTI_USER 
GO
ALTER DATABASE [EstagioRen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EstagioRen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EstagioRen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EstagioRen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EstagioRen] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EstagioRen', N'ON'
GO
ALTER DATABASE [EstagioRen] SET QUERY_STORE = OFF
GO
USE [EstagioRen]
GO
/****** Object:  Table [dbo].[Heritage]    Script Date: 03/10/2019 17:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Heritage](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[Status] [int] NOT NULL,
	[BarCode] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 03/10/2019 17:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [text] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/10/2019 17:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](60) NOT NULL,
	[LastName] [varchar](60) NULL,
	[Document] [varchar](14) NOT NULL,
	[Phone] [varchar](20) NULL,
	[Status] [bit] NOT NULL,
	[Email] [varchar](160) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Image] [varchar](1024) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spAuthUser]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAuthUser]
	@email varchar(160),
	@password varchar(200)
as
select
	[Id], 
	[FirstName] as [Name],
	[Email],
	[Status]
from [User]
where
	[Email] = @email and [Password] = @password
and
	[Status] = 1
GO
/****** Object:  StoredProcedure [dbo].[spBookHeritage]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spBookHeritage]
	@id uniqueidentifier
as
update Heritage set [Status] = 1 where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[spCreateHeritage]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spCreateHeritage]
	@id uniqueidentifier,
	@description varchar(50),
	@purchaseDate datetime,
	@status int,
	@barCode varchar(50)
as
insert into Heritage(Id, Description, PurchaseDate, Status, BarCode)
values (@id, @description, @purchaseDate, @status, @barCode)
GO
/****** Object:  StoredProcedure [dbo].[spCreateProject]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spCreateProject]
	@id uniqueidentifier,
	@title varchar(50),
	@description text,
	@createdAt datetime,
	@updatedAt datetime,
	@ownerId uniqueidentifier,
	@status int
as
insert into [Project] ([Id], [Title], [Description], [CreatedAt], [UpdatedAt], [OwnerId], [Status])
values (@id, @title, @description, @createdAt, @updatedAt, @ownerId, @status)
GO
/****** Object:  StoredProcedure [dbo].[spCreateUser]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCreateUser]
	@id uniqueidentifier,
	@firstName varchar(60),
	@lastName varchar(60),
	@document varchar(14),
	@phone varchar(20),
	@status bit,
	@email varchar(160),
	@password varchar(200),
	@image varchar(1024)
as
insert into [User](
	[Id], [FirstName], [LastName], [Document], [Phone], [Status], [Email], [Password], [Image]
) values (
	@id, @firstName, @lastName, @document, @phone, @status, @email, @password, @image
)
GO
/****** Object:  StoredProcedure [dbo].[spDeleteHeritage]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteHeritage]
	@id uniqueidentifier
as
delete from Heritage where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[spDeleteProject]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteProject]
	@id uniqueidentifier
as
delete from Project where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteUser]
	@id uniqueidentifier
as
delete from [User]
where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditHeritage]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spEditHeritage]
	@id uniqueidentifier,
	@description varchar(50),
	@purchaseDate datetime,
	@status int,
	@barCode varchar(50)
as
update Heritage set Description = @description, PurchaseDate = @purchaseDate, Status = @status, BarCode = @barCode
where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditProject]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spEditProject]
	@id uniqueidentifier,
	@title varchar(50),
	@description text,
	@updatedAt datetime,
	@ownerId uniqueidentifier,
	@status int
as
update [Project] set [Title] = @title, [Description] = @description, 
	[UpdatedAt] = @updatedAt, [OwnerId] = @ownerId, [Status] = @status
where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spEditUser]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spEditUser]
	@id uniqueidentifier,
	@firstName varchar(60),
	@lastName varchar(60),
	@email varchar(160),
	@phone varchar(20),
	@status bit,
	@image varchar(1024)
as
update [User] set 
	[FirstName] = @firstName, [LastName] = @lastName, [Phone] = @phone, 
	[Status] = @status, [Email] = @email, [Image] = @image
where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetHeritageById]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetHeritageById]
	@id uniqueidentifier
as
select * from Heritage
where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetHeritages]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetHeritages]
as
select
	Id, Description, Status
from Heritage
GO
/****** Object:  StoredProcedure [dbo].[spGetProjectById]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetProjectById]
	@id uniqueidentifier
as
select * from Project where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetProjectOwner]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetProjectOwner]
	@ownerId uniqueidentifier
as
select Id as OwnerId, FirstName, LastName, Status from [User] where Id = @ownerId
GO
/****** Object:  StoredProcedure [dbo].[spGetProjects]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetProjects]
as
select [Project].[Id], [Title], concat([User].FirstName, ' ', [User].LastName) as [Owner], Project.Status from [Project]
left join [User] on [User].Id = Project.OwnerId
GO
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserById]
	@id uniqueidentifier
as
select * from [User] where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetUsers]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUsers]
as
select
	[Id], 
	CONCAT([FirstName], ' ', [LastName]) as [Name],
	[Document],
	[Email],
	[Status]
from [User]
GO
/****** Object:  StoredProcedure [dbo].[spIsHeritageAvailable]    Script Date: 03/10/2019 17:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spIsHeritageAvailable]
	@id uniqueidentifier
as
select case when exists(select Id from Heritage where Id = @id and Status = 0)
then cast(1 as bit)
else cast(0 as bit)
end
GO
USE [master]
GO
ALTER DATABASE [EstagioRen] SET  READ_WRITE 
GO
