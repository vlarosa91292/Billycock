INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210310000548_Billycock', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210311115958_Billycock2', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210311164540_Billycock3', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210311180552_Billycock4', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210311221516_Billycock1', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210311224750_Billycock2', N'5.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210317123742_Bc1', N'5.0.3')
GO
SET IDENTITY_INSERT [dbo].[CUENTA] ON 
GO
INSERT [dbo].[CUENTA] ([idCuenta], [nombre], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [descripcion], [password], [idEstado]) VALUES (1, N'Billycock1', N'BC1', 1, 1, 1, 1, 1, 0, N'billycocknetflix1@gmail.com', N'Nayjuw+29', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [nombre], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [descripcion], [password], [idEstado]) VALUES (2, N'Billycock2', N'BC2', 1, 1, 1, 1, 0, 0, N'billycocknetflix2@gmail.com', N'Nayjuw+29', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [nombre], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [descripcion], [password], [idEstado]) VALUES (3, N'Billycock3', N'BC3', 1, 1, 1, 0, 0, 1, N'billycocknetflix3@gmail.com', N'Nayjuw+29', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [nombre], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [descripcion], [password], [idEstado]) VALUES (4, N'Billycock4', N'BC4', 1, 0, 0, 0, 0, 0, N'billycocknetflix4@gmail.com', N'Nayjuw+29', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [nombre], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [descripcion], [password], [idEstado]) VALUES (5, N'Billycock5', N'BC5', 0, 0, 0, 0, 0, 0, N'billycocknetflix5@gmail.com', N'Nayjuw+29', 1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [nombre], [diminutivo], [netflix], [amazon], [disney], [hbo], [youtube], [spotify], [descripcion], [password], [idEstado]) VALUES (6, N'Billycock6', N'BC6', 1, 0, 1, 0, 0, 0, N'billycocknetflix6@gmail.com', N'Nayjuw+29', 1)
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
SET IDENTITY_INSERT [dbo].[HISTORY] ON 
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (2, N'{"idUsuario":0,"descripcion":"PRUEBITA","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1},{"idUsuario":0,"idPlataforma":2,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-11T18:07:30.0671145' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (3, N'{"idUsuario":0,"descripcion":"Milagros Barrera","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-11T18:16:51.1609848' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (10, N'{"idUsuario":0,"descripcion":"JJ","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1},{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-11T18:34:20.8343751' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (11, N'{"idUsuario":0,"descripcion":"Lesly Rivas","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1},{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-11T18:39:44.7799778' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (12, N'{"idUsuario":0,"descripcion":"Daniel Pimentel","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-11T18:40:03.1878280' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (13, N'{"idUsuario":0,"descripcion":"Kevin Ramírez","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":6,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":2}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-12T03:50:22.9970962' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (14, N'{"idUsuario":0,"descripcion":"William Huamancaja","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-12T09:03:34.3416347' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (15, N'{"idUsuario":0,"descripcion":"Milagros Barrera","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-12T18:08:48.5752462' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (16, N'{"idUsuario":0,"descripcion":"Carlos Villazanpa","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":20.0,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-12T18:11:50.9438662' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (17, N'{"idUsuario":0,"descripcion":"Samir","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":2}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-15T17:44:08.6963487' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (18, N'{"idUsuario":0,"descripcion":"Juan Martin","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-15T18:06:13.5719076' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (19, N'{"idUsuario":0,"descripcion":"Johanna Salas","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":3,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1},{"idUsuario":0,"idPlataforma":6,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-15T20:37:35.6012345' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (20, N'{"idUsuario":0,"descripcion":"Alex Chang","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-16T09:41:26.6674509' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (21, N'{"idUsuario":0,"descripcion":"Pedro Delgado","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":4,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-16T23:22:06.3174845' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (22, N'{"idUsuario":0,"descripcion":"Luis Jojojo","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":2}]}', N'Unable to cast object of type ''System.Double'' to type ''System.Int32''.', CAST(N'2021-03-17T07:17:40.2088822' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (23, N'{"idUsuario":0,"descripcion":"Luis Jojo","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":2}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-17T07:41:33.0873654' AS DateTime2))
GO
INSERT [dbo].[HISTORY] ([idHistory], [Request], [Response], [fecha]) VALUES (24, N'{"idUsuario":0,"descripcion":"JJ ","fechaInscripcion":null,"idEstado":null,"descEstado":null,"facturacion":null,"pago":null,"plataformasxusuario":[{"idUsuario":0,"idPlataforma":1,"descPlataforma":null,"idCuenta":0,"credencial":null,"cantidad":1}]}', N'CREACION DE USUARIO EXITOSA', CAST(N'2021-03-17T07:59:28.5515378' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[HISTORY] OFF
GO
SET IDENTITY_INSERT [dbo].[PLATAFORMA] ON 
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [idEstado], [numeroMaximoUsuarios], [precio]) VALUES (1, N'Netflix', 1, 4, 12)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [idEstado], [numeroMaximoUsuarios], [precio]) VALUES (2, N'Amazon', 1, 4, 12)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [idEstado], [numeroMaximoUsuarios], [precio]) VALUES (3, N'Disney+', 1, 4, 12)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [idEstado], [numeroMaximoUsuarios], [precio]) VALUES (4, N'Hbo GO', 1, 4, 10)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [idEstado], [numeroMaximoUsuarios], [precio]) VALUES (5, N'Youtube Premium', 1, 5, 10)
GO
INSERT [dbo].[PLATAFORMA] ([idPlataforma], [descripcion], [idEstado], [numeroMaximoUsuarios], [precio]) VALUES (6, N'Spotify Premium', 1, 5, 10)
GO
SET IDENTITY_INSERT [dbo].[PLATAFORMA] OFF
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (1, 1, 0, N'24/03/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (2, 1, 0, N'04/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (3, 1, 0, N'24/03/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (4, 1, 1, N'04/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (5, 1, 3, N'02/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (1, 2, 0, N'25/03/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (2, 2, 1, N'04/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (3, 2, 3, N'25/03/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (4, 2, 4, N'10/04/2021
')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (5, 2, 1, N'15/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (1, 3, 0, N'04/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (2, 3, 5, N'09/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (3, 3, 3, N'02/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (6, 3, 1, N'09/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (1, 4, 0, N'04/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (1, 6, 1, N'05/04/2021')
GO
INSERT [dbo].[PLATAFORMACUENTA] ([idPlataforma], [idCuenta], [usuariosdisponibles], [fechaPago]) VALUES (3, 6, 4, N'10/04/2021')
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (1, N'Liz Andyy Yslache', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (2, N'Michelle Huaman', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 28)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (3, N'Josselin Antuane', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 15)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (4, N'Lizeth Huaman', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (5, N'Anthony Tolentino', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 23)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (6, N'Piero Fajardo', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 16)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (7, N'Manuel Cotrina Cerna', CAST(N'2021-03-09T15:24:58.6033333' AS DateTime2), 1, N'Fin de Mes', 23)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (8, N'Pedro Jara', CAST(N'2021-03-09T15:25:26.0800000' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (9, N'Andry Tolentino', CAST(N'2021-03-09T15:26:06.2200000' AS DateTime2), 1, N'Fin de Mes', 18)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (10, N'Enrique Qs', CAST(N'2021-03-09T15:26:24.7900000' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (11, N'Maylin Ventura', CAST(N'2021-03-09T15:26:38.8400000' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (12, N'Max Vasquez', CAST(N'2021-03-09T15:27:37.6333333' AS DateTime2), 1, N'Fin de Mes', 15)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (13, N'Luisinho Fernando', CAST(N'2021-03-09T15:27:58.8766667' AS DateTime2), 1, N'Fin de Mes', 8)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (14, N'Bebeto Neciosup', CAST(N'2021-03-09T15:28:22.8166667' AS DateTime2), 1, N'Fin de Mes', 23)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (15, N'Karen Maldonado', CAST(N'2021-03-09T15:28:40.2533333' AS DateTime2), 1, N'Fin de Mes', 18)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (16, N'Gloria Qs', CAST(N'2021-03-09T15:28:52.5366667' AS DateTime2), 1, N'Quincena', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (17, N'Lizeth Reyes', CAST(N'2021-03-09T15:29:11.7400000' AS DateTime2), 1, N'Quincena', 17)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (18, N'Marleny La Rosa', CAST(N'2021-03-09T15:29:35.3000000' AS DateTime2), 1, N'Fin de Mes', 12)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (19, N'Joshua', CAST(N'2021-03-09T15:45:13.4100000' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (20, N'Oscar Lopez Arriz', CAST(N'2021-03-09T15:45:25.9100000' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (21, N'Jenifer Saavedra', CAST(N'2021-03-09T15:46:12.3833333' AS DateTime2), 1, N'Fin de Mes', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (22, N'Alue Reynoso', CAST(N'2021-03-09T15:46:38.6800000' AS DateTime2), 1, N'Quincena', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (23, N'Carlos Flores', CAST(N'2021-03-09T15:46:57.6766667' AS DateTime2), 1, N'Quincena', 18)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (24, N'Estrella Valencia', CAST(N'2021-03-09T15:47:07.1966667' AS DateTime2), 1, N'Quincena', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (25, N'Ladi Leon', CAST(N'2021-03-09T15:48:50.5133333' AS DateTime2), 1, N'Fin de Mes', 18)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (42, N'Lesly Rivas', CAST(N'2021-03-11T18:39:44.7304524' AS DateTime2), 1, N'Quincena', 20)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (43, N'Daniel Pimentel', CAST(N'2021-03-11T18:40:03.1775614' AS DateTime2), 1, N'Quincena', 12)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (44, N'Kevin Ramírez', CAST(N'2021-03-12T03:50:22.9652855' AS DateTime2), 1, N'Quincena', 14)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (45, N'William Huamancaja', CAST(N'2021-03-12T09:03:34.1157910' AS DateTime2), 1, N'Quincena', 12)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (46, N'Milagros Barrera', CAST(N'2021-03-12T18:08:48.5529636' AS DateTime2), 1, N'Quincena', 12)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (47, N'Carlos Villazanpa', CAST(N'2021-03-12T18:11:50.8895439' AS DateTime2), 1, N'Quincena', 12)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (49, N'Samir', CAST(N'2021-03-15T17:44:08.1407755' AS DateTime2), 1, N'Quincena', 20)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (50, N'Juan Martin', CAST(N'2021-03-15T18:06:13.4942947' AS DateTime2), 1, N'Quincena', 10)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (51, N'Johanna Salas', CAST(N'2021-03-15T20:37:35.5621598' AS DateTime2), 1, N'Quincena', 18)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (52, N'Alex Chang', CAST(N'2021-03-16T00:00:00.0000000' AS DateTime2), 1, N'Fin de Mes', 12)
GO
INSERT [dbo].[USUARIO] ([idUsuario], [descripcion], [fechaInscripcion], [idEstado], [facturacion], [pago]) VALUES (56, N'Pedro Delgado', CAST(N'2021-03-16T00:00:00.0000000' AS DateTime2), 1, N'Fin de Mes', 12)
GO
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (2, 1, 1, 4)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (3, 2, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (3, 3, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (4, 2, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (5, 1, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (5, 2, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (5, 3, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (6, 1, 4, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (6, 2, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (7, 2, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (7, 3, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (7, 4, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (8, 3, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (9, 1, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (9, 3, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (10, 4, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (11, 2, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (12, 5, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (13, 6, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (14, 1, 4, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (14, 2, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (14, 3, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (15, 2, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (15, 4, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (16, 4, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (17, 1, 4, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (17, 6, 1, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (18, 2, 2, 2)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (19, 1, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (20, 1, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (21, 1, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (22, 1, 3, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (23, 1, 3, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (23, 2, 4, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (24, 1, 3, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (25, 1, 4, 2)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (42, 1, 6, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (42, 3, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (43, 1, 6, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (44, 6, 3, 2)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (45, 3, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (46, 3, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (47, 1, 6, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (48, 3, 2, 2)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (49, 1, 6, 2)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (50, 3, 2, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (51, 3, 3, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (51, 6, 3, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (52, 1, 6, 1)
GO
INSERT [dbo].[USUARIOPLATAFORMA] ([idUsuario], [idPlataforma], [idCuenta], [cantidad]) VALUES (53, 4, 1, 1)
GO
