SET IDENTITY_INSERT [dbo].[CUENTA] ON 
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (1, N'billycocknetflix1@gmail.com', N'Bc1',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (2, N'billycocknetflix2@gmail.com', N'Bc2',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (3, N'billycocknetflix3@gmail.com', N'Bc3',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (4, N'billycocknetflix4@gmail.com', N'Bc4',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (5, N'billycocknetflix5@gmail.com', N'Bc5',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (6, N'billycocknetflix6@gmail.com', N'Bc6',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (7, N'billycocknetflix7@gmail.com', N'Bc7',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (8, N'billycocknetflix8@gmail.com', N'Bc8',1)
GO
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (9, N'billycocknetflix9@gmail.com', N'Bc9',1)
GO														 
INSERT [dbo].[CUENTA] ([idCuenta], [correo], [diminutivo], [idEstado]) VALUES (10, N'billycocknetflix10@gmail.com', N'Bc10',1)
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