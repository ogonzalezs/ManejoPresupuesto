USE [master]
GO
/****** Object:  Database [ManejoPresupuesto]    Script Date: 29-06-2022 8:09:42 ******/
CREATE DATABASE [ManejoPresupuesto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ManejoPresupuesto', FILENAME = N'E:\program files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ManejoPresupuesto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ManejoPresupuesto_log', FILENAME = N'E:\program files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ManejoPresupuesto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ManejoPresupuesto] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManejoPresupuesto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManejoPresupuesto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManejoPresupuesto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManejoPresupuesto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ManejoPresupuesto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManejoPresupuesto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ManejoPresupuesto] SET  MULTI_USER 
GO
ALTER DATABASE [ManejoPresupuesto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManejoPresupuesto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManejoPresupuesto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManejoPresupuesto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ManejoPresupuesto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ManejoPresupuesto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ManejoPresupuesto] SET QUERY_STORE = OFF
GO
USE [ManejoPresupuesto]
GO
/****** Object:  Table [dbo].[tbl_Categorias]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Categorias](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[TipoOperacionId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Categorias] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Cuentas]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Cuentas](
	[CuentaId] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[TipoCuentaId] [int] NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
	[Descripcion] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tbl_Cuentas] PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TiposCuentas]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TiposCuentas](
	[TipoCuentaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_tbl_TiposCuentas] PRIMARY KEY CLUSTERED 
(
	[TipoCuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TipoTransacciones]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TipoTransacciones](
	[TipoTransaccionId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_TipoTransacciones] PRIMARY KEY CLUSTERED 
(
	[TipoTransaccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Transacciones]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Transacciones](
	[TransaccionId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[CuentaId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[FechaTransaccion] [datetime] NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[TipoTransaccionId] [int] NOT NULL,
	[Nota] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tbl_Transacciones] PRIMARY KEY CLUSTERED 
(
	[TransaccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Usuarios]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[EmailNormalizado] [nvarchar](256) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Transacciones] ADD  CONSTRAINT [DF_tbl_Transacciones_FechaTransaccion]  DEFAULT (getdate()) FOR [FechaTransaccion]
GO
ALTER TABLE [dbo].[tbl_Categorias]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Categorias_tbl_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[tbl_Usuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[tbl_Categorias] CHECK CONSTRAINT [FK_tbl_Categorias_tbl_Usuarios]
GO
ALTER TABLE [dbo].[tbl_Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Cuentas_tbl_TiposCuentas] FOREIGN KEY([TipoCuentaId])
REFERENCES [dbo].[tbl_TiposCuentas] ([TipoCuentaId])
GO
ALTER TABLE [dbo].[tbl_Cuentas] CHECK CONSTRAINT [FK_tbl_Cuentas_tbl_TiposCuentas]
GO
ALTER TABLE [dbo].[tbl_TiposCuentas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TiposCuentas_tbl_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[tbl_Usuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[tbl_TiposCuentas] CHECK CONSTRAINT [FK_tbl_TiposCuentas_tbl_Usuarios]
GO
ALTER TABLE [dbo].[tbl_Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Transacciones_tbl_Categorias] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[tbl_Categorias] ([CategoriaId])
GO
ALTER TABLE [dbo].[tbl_Transacciones] CHECK CONSTRAINT [FK_tbl_Transacciones_tbl_Categorias]
GO
ALTER TABLE [dbo].[tbl_Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Transacciones_tbl_Cuentas] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[tbl_Cuentas] ([CuentaId])
GO
ALTER TABLE [dbo].[tbl_Transacciones] CHECK CONSTRAINT [FK_tbl_Transacciones_tbl_Cuentas]
GO
ALTER TABLE [dbo].[tbl_Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Transacciones_tbl_TipoTransacciones] FOREIGN KEY([TipoTransaccionId])
REFERENCES [dbo].[tbl_TipoTransacciones] ([TipoTransaccionId])
GO
ALTER TABLE [dbo].[tbl_Transacciones] CHECK CONSTRAINT [FK_tbl_Transacciones_tbl_TipoTransacciones]
GO
ALTER TABLE [dbo].[tbl_Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Transacciones_tbl_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[tbl_Usuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[tbl_Transacciones] CHECK CONSTRAINT [FK_tbl_Transacciones_tbl_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[Transacciones_Insertar]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Transacciones_Insertar]
	@UsuarioId nvarchar(450),
	@Monto decimal(18,2),
	@TipoTransaccionID int,
	@Nota nvarchar(1000) = null
AS
BEGIN
	
	Insert Into tbl_Transacciones(UsuarioId, Monto, TipoTransaccionId, Nota)
	Values (@UsuarioId, @Monto, @TipoTransaccionID, @Nota)
END
GO
/****** Object:  StoredProcedure [dbo].[Transacciones_SelectConTipoOperacion]    Script Date: 29-06-2022 8:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Transacciones_SelectConTipoOperacion]
	@FechaTransaccion datetime
AS
BEGIN
	SELECT t.TransaccionId, t.UsuarioId, t.Monto, t.Nota, tt.Descripcion
	FROM tbl_Transacciones t
	JOIN tbl_TipoTransacciones tt ON t.TipoTransaccionId = tt.TipoTransaccionId
	WHERE t.FechaTransaccion = @FechaTransaccion
END
GO
USE [master]
GO
ALTER DATABASE [ManejoPresupuesto] SET  READ_WRITE 
GO
