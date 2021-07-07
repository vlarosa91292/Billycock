SET IDENTITY_INSERT [dbo].[ESTADO] ON 
GO
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (1, N'Activo')
GO
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (2, N'Inactivo')
GO
SET IDENTITY_INSERT [dbo].[ESTADO] OFF
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
