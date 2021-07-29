USE [master]
GO
/****** Object:  Database [Billycock_Produccion]    Script Date: 29/07/2021 04:12:12 PM ******/
CREATE DATABASE [Billycock_Produccion]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Billycock_Produccion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
USE [Billycock_Produccion]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 29/07/2021 04:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/07/2021 04:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUENTA]    Script Date: 29/07/2021 04:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUENTA](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[correo] [nvarchar](max) NULL,
	[diminutivo] [nvarchar](max) NULL,
	[netflix] [bit] NOT NULL,
	[amazon] [bit] NOT NULL,
	[disney] [bit] NOT NULL,
	[hbo] [bit] NOT NULL,
	[youtube] [bit] NOT NULL,
	[spotify] [bit] NOT NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_CUENTA] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTADO]    Script Date: 29/07/2021 04:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO](
	[idEstado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_ESTADO] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HISTORIA]    Script Date: 29/07/2021 04:12:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORIA](
	[idHistory] [int] IDENTITY(1,1) NOT NULL,
	[Request] [nvarchar](max) NULL,
	[Response] [nvarchar](max) NULL,
	[fecha] [datetime2](7) NOT NULL,
	[integracion] [nvarchar](max) NULL,
 CONSTRAINT [PK_HISTORIA] PRIMARY KEY CLUSTERED 
(
	[idHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PLATAFORMA]    Script Date: 29/07/2021 04:12:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLATAFORMA](
	[idPlataforma] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[numeroMaximoUsuarios] [int] NULL,
	[precio] [float] NOT NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_PLATAFORMA] PRIMARY KEY CLUSTERED 
(
	[idPlataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PLATAFORMACUENTA]    Script Date: 29/07/2021 04:12:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLATAFORMACUENTA](
	[idPlataforma] [int] NOT NULL,
	[idCuenta] [int] NOT NULL,
	[usuariosdisponibles] [int] NULL,
	[fechaPago] [nvarchar](max) NULL,
	[clave] [nvarchar](max) NULL,
 CONSTRAINT [PK_PLATAFORMACUENTA] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC,
	[idPlataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 29/07/2021 04:12:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 29/07/2021 04:12:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](max) NULL,
	[fechaInscripcion] [datetime2](7) NULL,
	[idEstado] [int] NULL,
	[facturacion] [nvarchar](max) NULL,
	[pago] [int] NULL,
	[pin] [nvarchar](max) NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOPLATAFORMACUENTA]    Script Date: 29/07/2021 04:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOPLATAFORMACUENTA](
	[idUsuario] [int] NOT NULL,
	[idPlataforma] [int] NOT NULL,
	[idCuenta] [int] NOT NULL,
	[cantidad] [int] NULL,
 CONSTRAINT [PK_USUARIOPLATAFORMACUENTA] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idPlataforma] ASC,
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210707175208_Billycock', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210709204512_Billycock2', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210714022623_Billycock3', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210714031953_Billycock4', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210714034829_Billycock5', N'5.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210729141607_PinAdd', N'5.0.7')
GO
SET IDENTITY_INSERT [dbo].[CUENTA] ON 
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (1, N'billycocknetflix1@gmail.com', N'Bc1', 1, 0, 1, 0, 0, 1, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (2, N'billycocknetflix2@gmail.com', N'Bc2', 1, 0, 1, 0, 1, 0, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (3, N'billycocknetflix3@gmail.com', N'Bc3', 1, 0, 1, 0, 0, 0, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (4, N'billycocknetflix4@gmail.com', N'Bc4', 1, 0, 1, 0, 0, 0, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (5, N'billycocknetflix5@gmail.com', N'Bc5', 0, 0, 0, 0, 0, 0, 2)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (6, N'billycocknetflix6@gmail.com', N'Bc6', 1, 0, 0, 0, 0, 0, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (7, N'billycocknetflix7@gmail.com', N'Bc7', 1, 1, 0, 0, 0, 0, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (8, N'billycocknetflix8@gmail.com', N'Bc8', 1, 0, 0, 0, 0, 0, 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (9, N'billycocknetflix9@gmail.com', N'Bc9', 0, 0, 0, 0, 0, 0, 2)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [idEstado]) VALUES (10, N'billycocknetflix10@gmail.com', N'Bc10', 1, 1, 0, 0, 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[CUENTA] OFF
GO
SET IDENTITY_INSERT [dbo].[ESTADO] ON 
GO
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (1, N'Activo')
GO
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (2, N'Inactivo')
GO
SET IDENTITY_INSERT [dbo].[ESTADO] OFF
GO
SET IDENTITY_INSERT [dbo].[HISTORIA] ON 
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (1, N'{"idUsuario":0,"descripcion":"Prueba Pruebita","fechaInscripcion":null,"idEstado":null,"facturacion":null,"pago":12,"descEstado":null,"usuarioPlataformacuentas":null}', N'CREACION Correcta DE USUARIO', CAST(N'2021-07-08T17:42:15.3790743' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (2, N'{"idUsuario":0,"descripcion":"Prueba Pruebita 2","fechaInscripcion":null,"idEstado":null,"facturacion":null,"pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'CREACION Correcta DE USUARIO', CAST(N'2021-07-08T17:44:26.4846407' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (3, N'{"idUsuario":1,"descripcion":"Prueba Pruebita","fechaInscripcion":"2021-07-08T17:41:33.9277521","idEstado":1,"facturacion":null,"pago":12,"descEstado":"Activo","usuarioPlataformacuentas":null}', N'ELIMINACION Correcta DE USUARIO', CAST(N'2021-07-08T17:59:02.2561549' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (4, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":"2021-07-08T17:43:48.4661554","idEstado":1,"facturacion":null,"pago":10,"descEstado":"Activo","usuarioPlataformacuentas":null}', N'ELIMINACION Correcta DE USUARIO', CAST(N'2021-07-08T17:59:15.3081354' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (5, N'{"idUsuario":0,"descripcion":"Prueba Pruebota","fechaInscripcion":null,"idEstado":null,"facturacion":null,"pago":20,"descEstado":null,"usuarioPlataformacuentas":null}', N'CREACION Correcta DE USUARIO', CAST(N'2021-07-08T18:00:43.2817500' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (6, N'{"idUsuario":1,"descripcion":"Prueba Pruebita","fechaInscripcion":"2021-07-08T17:41:33.9277521","idEstado":2,"facturacion":null,"pago":12,"descEstado":"Inactivo","usuarioPlataformacuentas":null}', N'ELIMINACION Correcta DE USUARIO', CAST(N'2021-07-08T19:15:22.7684226' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (7, N'{"idUsuario":3,"descripcion":"Prueba Pruebota","fechaInscripcion":"2021-07-08T17:59:50.6060517","idEstado":1,"facturacion":"15/08/2021","pago":20,"descEstado":"Activo","usuarioPlataformacuentas":null}', N'ELIMINACION Correcta DE USUARIO', CAST(N'2021-07-08T19:15:31.2160463' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (8, N'{"idUsuario":3,"descripcion":"Prueba Pruebota","fechaInscripcion":null,"idEstado":1,"facturacion":"15/08/2021","pago":20,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION Correcta DE USUARIO', CAST(N'2021-07-08T19:15:46.2686048' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (9, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":null,"idEstado":1,"facturacion":null,"pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION Correcta DE USUARIO', CAST(N'2021-07-08T19:15:58.8244313' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (10, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":"2021-07-08T17:43:48.4661554","idEstado":2,"facturacion":null,"pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'Eliminacion XXX de Usuario', CAST(N'2021-07-08T21:48:01.7178140' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (11, N'{"idUsuario":3,"descripcion":"Prueba Pruebota","fechaInscripcion":"2021-07-08T17:59:50.6060517","idEstado":2,"facturacion":"15/08/2021","pago":20,"descEstado":null,"usuarioPlataformacuentas":null}', N'ELIMINACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:54:54.3207660' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (12, N'{"idUsuario":3,"descripcion":"Prueba Pruebota","fechaInscripcion":"2021-07-08T17:59:50.6060517","idEstado":1,"facturacion":"15/08/2021","pago":20,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:55:47.0879309' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (13, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":"2021-07-08T17:43:48.4661554","idEstado":1,"facturacion":null,"pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:56:36.6365779' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (14, N'{"idUsuario":1,"descripcion":"Prueba Pruebita","fechaInscripcion":"2021-07-08T17:41:33.9277521","idEstado":1,"facturacion":null,"pago":12,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:56:55.7710263' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (15, N'{"idUsuario":1,"descripcion":"Prueba Pruebita","fechaInscripcion":"2021-07-08T17:41:33.9277521","idEstado":2,"facturacion":null,"pago":12,"descEstado":null,"usuarioPlataformacuentas":null}', N'ELIMINACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:57:09.9226032' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (16, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":"2021-07-08T17:43:48.4661554","idEstado":2,"facturacion":null,"pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'ELIMINACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:57:14.7176731' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (17, N'{"idUsuario":3,"descripcion":"Prueba Pruebota","fechaInscripcion":"2021-07-08T17:59:50.6060517","idEstado":2,"facturacion":"15/08/2021","pago":20,"descEstado":null,"usuarioPlataformacuentas":null}', N'ELIMINACION CORRECTA DE USUARIO', CAST(N'2021-07-08T21:57:18.7627151' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (18, N'{"idUsuario":3,"descripcion":"Prueba Pruebota","fechaInscripcion":"2021-07-08T17:59:50.6060517","idEstado":1,"facturacion":"15/08/2021","pago":20,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-09T23:16:45.0748953' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (19, N'{"idUsuario":4,"descripcion":"Prueba Pruebotaza","fechaInscripcion":"2021-07-10T08:05:43.1065234-05:00","idEstado":1,"facturacion":"15/08/2021","pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'CREACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:05:46.4539951' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (20, N'{"idUsuario":4,"descripcion":"Prueba Pruebotaza","fechaInscripcion":"2021-07-10T08:05:43.1065234","idEstado":1,"facturacion":"15/08/2021","pago":12,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:09:17.4086702' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (21, N'{"idUsuario":4,"descripcion":"Prueba Pruebotaza","fechaInscripcion":"2021-07-10T08:05:43.1065234","idEstado":1,"facturacion":"15/08/2021","pago":15,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:09:45.3816053' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (22, N'{"idUsuario":1,"descripcion":"Prueba Pruebita","fechaInscripcion":"2021-07-08T17:41:33.9277521","idEstado":1,"facturacion":null,"pago":12,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:11:07.3464536' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (23, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":"2021-07-08T17:43:48.4661554","idEstado":1,"facturacion":null,"pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:12:39.6985279' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (24, N'{"idUsuario":1,"descripcion":"Prueba Pruebita","fechaInscripcion":"2021-07-08T17:41:33.9277521","idEstado":1,"facturacion":"15/08/2021","pago":12,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:27:43.7890790' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (25, N'{"idUsuario":2,"descripcion":"Prueba Pruebita 2","fechaInscripcion":"2021-07-08T17:43:48.4661554","idEstado":1,"facturacion":"15/08/2021","pago":10,"descEstado":null,"usuarioPlataformacuentas":null}', N'ACTUALIZACION CORRECTA DE USUARIO', CAST(N'2021-07-10T08:27:56.0627752' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (26, N'{"idPlataformaCuenta":null,"usuariosdisponibles":0,"fechaPago":"23/07","clave":null,"idPlataforma":1,"Plataforma":null,"idCuenta":1,"Cuenta":null}', N'CREACION INCORRECTA DE PLATAFORMACUENTA', CAST(N'2021-07-14T18:35:34.6161558' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (27, N'{"idPlataformaCuenta":null,"usuariosdisponibles":0,"fechaPago":"29/07","clave":null,"idPlataforma":2,"Plataforma":null,"idCuenta":7,"Cuenta":null}', N'CREACION INCORRECTA DE PLATAFORMACUENTA', CAST(N'2021-07-14T18:35:36.1996641' AS DateTime2), NULL)
GO
INSERT [dbo].[HISTORIA] ([idHistory], [Request], [Response], [fecha], [integracion]) VALUES (28, N'{"idPlataformaCuenta":null,"usuariosdisponibles":2,"fechaPago":"28/07","clave":null,"idPlataforma":3,"Plataforma":null,"idCuenta":2,"Cuenta":null}', N'CREACION INCORRECTA DE PLATAFORMACUENTA', CAST(N'2021-07-14T18:35:36.6993542' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[HISTORIA] OFF
GO
SET IDENTITY_INSERT [dbo].[PLATAFORMA] ON 
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (1, N'Netflix', 5, 12, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (2, N'Amazon', 5, 8, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (3, N'Disney+', 6, 8, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (5, N'Youtube Premium', 5, 10, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (6, N'Spotify Premium', 5, 10, 1)
GO
SET IDENTITY_INSERT [dbo].[PLATAFORMA] OFF
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 1, 0, N'23/07', N'Underground-05')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (3, 1, 0, N'24/07', N'Redrose-89')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (6, 1, 3, N'28/07', N'Bigdog+4')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 2, 1, N'03/08', N'Beautifullife-8')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (3, 2, 2, N'28/07', N'Lotusflower+45')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (5, 2, 2, N'07/08', N'Nayjuw+29')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 3, 0, N'28/07', N'Whitedove+23')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (3, 3, 0, N'28/07', N'Cottoncandy+27')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 4, 0, N'10/08', N'Butterfly+55')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (3, 4, 6, N'23/08', N'Loveflower-25')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 6, 0, N'26/08', N'Admin+27')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 7, 0, N'24/09', N'Bluebunny+95')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (2, 7, 0, N'29/07', N'Bluepearl-29')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 8, 0, N'20/08', N'Uglyduckling-4')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (1, 10, 3, N'17/08', N'Happylife+65')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago], [clave]) VALUES (2, 10, 1, N'23/07', N'Blackkitten+15')
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago], [pin]) VALUES (1, N'Prueba Pruebita', CAST(N'2021-07-08T17:41:33.9277521' AS DateTime2), 1, N'15/08/2021', 12, NULL)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago], [pin]) VALUES (2, N'Prueba Pruebita 2', CAST(N'2021-07-08T17:43:48.4661554' AS DateTime2), 1, N'15/08/2021', 10, NULL)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago], [pin]) VALUES (3, N'Prueba Pruebota', CAST(N'2021-07-08T17:59:50.6060517' AS DateTime2), 1, N'15/08/2021', 20, NULL)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago], [pin]) VALUES (4, N'Prueba Pruebotaza', CAST(N'2021-07-10T08:05:43.1065234' AS DateTime2), 1, N'15/08/2021', 15, NULL)
GO
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
/****** Object:  Index [IX_PLATAFORMACUENTA_idPlataforma]    Script Date: 29/07/2021 04:12:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_PLATAFORMACUENTA_idPlataforma] ON [dbo].[PLATAFORMACUENTA]
(
	[idPlataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_principal_name]    Script Date: 29/07/2021 04:12:28 PM ******/
ALTER TABLE [dbo].[sysdiagrams] ADD  CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_USUARIOPLATAFORMACUENTA_idCuenta]    Script Date: 29/07/2021 04:12:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_USUARIOPLATAFORMACUENTA_idCuenta] ON [dbo].[USUARIOPLATAFORMACUENTA]
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_USUARIOPLATAFORMACUENTA_idPlataforma]    Script Date: 29/07/2021 04:12:28 PM ******/
CREATE NONCLUSTERED INDEX [IX_USUARIOPLATAFORMACUENTA_idPlataforma] ON [dbo].[USUARIOPLATAFORMACUENTA]
(
	[idPlataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PLATAFORMACUENTA]  WITH CHECK ADD  CONSTRAINT [FK_PLATAFORMACUENTA_CUENTA_idCuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[CUENTA] ([idCuenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PLATAFORMACUENTA] CHECK CONSTRAINT [FK_PLATAFORMACUENTA_CUENTA_idCuenta]
GO
ALTER TABLE [dbo].[PLATAFORMACUENTA]  WITH CHECK ADD  CONSTRAINT [FK_PLATAFORMACUENTA_PLATAFORMA_idPlataforma] FOREIGN KEY([idPlataforma])
REFERENCES [dbo].[PLATAFORMA] ([idPlataforma])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PLATAFORMACUENTA] CHECK CONSTRAINT [FK_PLATAFORMACUENTA_PLATAFORMA_idPlataforma]
GO
ALTER TABLE [dbo].[USUARIOPLATAFORMACUENTA]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOPLATAFORMACUENTA_CUENTA_idCuenta] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[CUENTA] ([idCuenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[USUARIOPLATAFORMACUENTA] CHECK CONSTRAINT [FK_USUARIOPLATAFORMACUENTA_CUENTA_idCuenta]
GO
ALTER TABLE [dbo].[USUARIOPLATAFORMACUENTA]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOPLATAFORMACUENTA_PLATAFORMA_idPlataforma] FOREIGN KEY([idPlataforma])
REFERENCES [dbo].[PLATAFORMA] ([idPlataforma])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[USUARIOPLATAFORMACUENTA] CHECK CONSTRAINT [FK_USUARIOPLATAFORMACUENTA_PLATAFORMA_idPlataforma]
GO
ALTER TABLE [dbo].[USUARIOPLATAFORMACUENTA]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOPLATAFORMACUENTA_USUARIO_idUsuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO] ([idUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[USUARIOPLATAFORMACUENTA] CHECK CONSTRAINT [FK_USUARIOPLATAFORMACUENTA_USUARIO_idUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 29/07/2021 04:12:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
USE [master]
GO
ALTER DATABASE [Billycock_Produccion] SET  READ_WRITE 
GO
