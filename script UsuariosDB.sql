USE [master]
GO
/****** Object:  Database [UsuariosDB]    Script Date: 25/9/2023 18:50:39 ******/
CREATE DATABASE [UsuariosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UsuariosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UsuariosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UsuariosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UsuariosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UsuariosDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsuariosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsuariosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsuariosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsuariosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsuariosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsuariosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsuariosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsuariosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsuariosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsuariosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsuariosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsuariosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsuariosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsuariosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsuariosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsuariosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsuariosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsuariosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsuariosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsuariosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsuariosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsuariosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsuariosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsuariosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [UsuariosDB] SET  MULTI_USER 
GO
ALTER DATABASE [UsuariosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsuariosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsuariosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsuariosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UsuariosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UsuariosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UsuariosDB', N'ON'
GO
ALTER DATABASE [UsuariosDB] SET QUERY_STORE = OFF
GO
USE [UsuariosDB]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25/9/2023 18:50:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/9/2023 18:50:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [varchar](100) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[estado] [int] NOT NULL,
	[idrol] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([idrol])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [UsuariosDB] SET  READ_WRITE 
GO
