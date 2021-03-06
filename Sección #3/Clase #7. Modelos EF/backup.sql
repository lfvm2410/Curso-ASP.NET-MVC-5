USE [master]
GO
/****** Object:  Database [Test]    Script Date: 24/07/2015 10:58:39 p.m. ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLSERVERLUIS\MSSQL\DATA\Test.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLSERVERLUIS\MSSQL\DATA\Test_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Adjunto]    Script Date: 24/07/2015 10:58:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adjunto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Alumno_id] [int] NOT NULL,
	[Archivo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Adjunto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 24/07/2015 10:58:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Sexo] [int] NOT NULL,
	[FechaNacimiento] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlumnoCurso]    Script Date: 24/07/2015 10:58:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnoCurso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Alumno_id] [int] NOT NULL,
	[Curso_id] [int] NOT NULL,
	[Nota] [decimal](18, 2) NOT NULL CONSTRAINT [DF_AlumnoCurso_Nota]  DEFAULT ((0)),
 CONSTRAINT [PK_AlumnoCurso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Curso]    Script Date: 24/07/2015 10:58:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Curso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Adjunto] ON 

INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (1, 2004, N'abc.jpg')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (2, 2004, N'20150707185512.xlsx')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (3, 2004, N'20150707190840.xlsx')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (4, 2004, N'20150707190844.xlsx')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (5, 2004, N'20150707190844.xlsx')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (6, 2004, N'20150707190845.xlsx')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (7, 2004, N'20150707190845.xlsx')
INSERT [dbo].[Adjunto] ([id], [Alumno_id], [Archivo]) VALUES (8, 2004, N'20150707190845.xlsx')
SET IDENTITY_INSERT [dbo].[Adjunto] OFF
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([id], [Nombre], [Apellido], [Sexo], [FechaNacimiento]) VALUES (2004, N'Eduardo x', N'Rodriguez Patiño', 1, N'1989-02-11')
INSERT [dbo].[Alumno] ([id], [Nombre], [Apellido], [Sexo], [FechaNacimiento]) VALUES (3009, N'Nombre 1', N'Apellido ', 1, N'1989-15-02')
SET IDENTITY_INSERT [dbo].[Alumno] OFF
SET IDENTITY_INSERT [dbo].[AlumnoCurso] ON 

INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (1, 2004, 1, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (2, 2004, 2, CAST(17.00 AS Decimal(18, 2)))
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (3, 2004, 3, CAST(16.00 AS Decimal(18, 2)))
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (4, 2004, 4, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[AlumnoCurso] ([id], [Alumno_id], [Curso_id], [Nota]) VALUES (5, 3009, 1, CAST(20.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[AlumnoCurso] OFF
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (1, N'ASP.NET MVC')
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (2, N'Angular JS')
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (3, N'jQuery')
INSERT [dbo].[Curso] ([id], [Nombre]) VALUES (4, N'Laravel')
SET IDENTITY_INSERT [dbo].[Curso] OFF
ALTER TABLE [dbo].[Adjunto]  WITH CHECK ADD  CONSTRAINT [FK_Adjunto_Alumno] FOREIGN KEY([Alumno_id])
REFERENCES [dbo].[Alumno] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Adjunto] CHECK CONSTRAINT [FK_Adjunto_Alumno]
GO
ALTER TABLE [dbo].[AlumnoCurso]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoCurso_Alumno] FOREIGN KEY([Alumno_id])
REFERENCES [dbo].[Alumno] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlumnoCurso] CHECK CONSTRAINT [FK_AlumnoCurso_Alumno]
GO
ALTER TABLE [dbo].[AlumnoCurso]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoCurso_Curso] FOREIGN KEY([Curso_id])
REFERENCES [dbo].[Curso] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlumnoCurso] CHECK CONSTRAINT [FK_AlumnoCurso_Curso]
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
