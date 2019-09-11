USE [master]
GO
/****** Object:  Database [EstagioRen]    Script Date: 11/09/2019 17:53:04 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 11/09/2019 17:53:05 ******/
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
/****** Object:  StoredProcedure [dbo].[spAuthUser]    Script Date: 11/09/2019 17:53:05 ******/
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
/****** Object:  StoredProcedure [dbo].[spCreateUser]    Script Date: 11/09/2019 17:53:05 ******/
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
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 11/09/2019 17:53:05 ******/
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
/****** Object:  StoredProcedure [dbo].[spEditUser]    Script Date: 11/09/2019 17:53:05 ******/
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
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 11/09/2019 17:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserById]
	@id uniqueidentifier
as
select * from [User] where [Id] = @id
GO
/****** Object:  StoredProcedure [dbo].[spGetUsers]    Script Date: 11/09/2019 17:53:05 ******/
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
USE [master]
GO
ALTER DATABASE [EstagioRen] SET  READ_WRITE 
GO
