SET IDENTITY_INSERT [dbo].[CUENTA] ON 
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (1, N'billycocknetflix1@gmail.com', N'Bc1', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (2, N'billycocknetflix2@gmail.com', N'Bc2', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (3, N'billycocknetflix3@gmail.com', N'Bc3', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (4, N'billycocknetflix4@gmail.com', N'Bc4', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (5, N'billycocknetflix5@gmail.com', N'Bc5', 2)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (6, N'billycocknetflix6@gmail.com', N'Bc6', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (7, N'billycocknetflix7@gmail.com', N'Bc7', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (8, N'billycocknetflix8@gmail.com', N'Bc8', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (9, N'billycocknetflix9@gmail.com', N'Bc9', 2)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (10, N'billycocknetflix10@gmail.com', N'Bc10', 1)
GO
SET IDENTITY_INSERT [dbo].[CUENTA] OFF
GO
SET IDENTITY_INSERT [dbo].[PLATAFORMA] ON 
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (1, N'Netflix', 5, 12, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (2, N'Amazon', 6, 8, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (3, N'Disney+', 7, 8, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (4, N'Hbo Max', 5, 10, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (5, N'Youtube Premium', 5, 10, 1)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [numeroMaximoUsuarios], [precio], [idEstado]) VALUES (6, N'Spotify Premium', 5, 10, 1)
GO
SET IDENTITY_INSERT [dbo].[PLATAFORMA] OFF
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-1', 0, N'23/8/2021', N'Underground-05', 1, 1)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-10', 0, N'17/8/2021', N'Happylife+65', 1, 10)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-2', 0, N'03/8/2021', N'Beautifullife-8', 1, 2)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-3', 0, N'28/8/2021', N'Whitedove+23', 1, 3)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-4', 0, N'10/8/2021', N'Butterfly+55', 1, 4)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-6', 0, N'26/8/2021', N'Admin+27', 1, 6)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-7', 0, N'24/9/2021', N'Bluebunny+95', 1, 7)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'1-8', 0, N'20/8/2021', N'Uglyduckling-4', 1, 8)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'2-10', 0, N'23/8/2021', N'Blackkitten+15', 2, 10)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'2-7', 0, N'29/8/2021', N'Bluepearl-29', 2, 7)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'3-1', 0, N'24/8/2021', N'Redrose-89', 3, 1)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'3-2', 0, N'28/8/2021', N'Lotusflower+45', 3, 2)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'3-3', 0, N'28/8/2021', N'Cottoncandy+27', 3, 3)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'3-4', 0, N'23/8/2021', N'Loveflower-25', 3, 4)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'3-6', 7, N'8/6/2021', NULL, 3, 6)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'4-1', 3, N'31/8/2021', N'Littledaisy+05', 4, 1)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'5-2', 2, N'07/8/2021', N'Nayjuw+29', 5, 2)
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataformaCuenta], [usuariosdisponibles], [fechaPago], [clave], [idPlataforma], [idCuenta]) VALUES (N'6-1', 3, N'28/8/2021', N'Bigdog+4', 6, 1)
GO
SET IDENTITY_INSERT [dbo].[ESTADO] ON 
GO
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (1, N'Activo')
GO
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (2, N'Inactivo')
GO
SET IDENTITY_INSERT [dbo].[ESTADO] OFF
GO
