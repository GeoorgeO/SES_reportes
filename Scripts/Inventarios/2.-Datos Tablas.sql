GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(1 AS Decimal(11, 0)), N'Inventario Ciego')
GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(2 AS Decimal(11, 0)), N'Revision Contraloria')
GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(3 AS Decimal(11, 0)), N'Config Articulos Diarios')
GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(4 AS Decimal(11, 0)), N'Config Email')
GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(5 AS Decimal(11, 0)), N'Entradas')
GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(6 AS Decimal(11, 0)), N'Salidas')
GO
INSERT [dbo].[InventarioPantalla] ([InventarioPantallaId], [InventarioPantallaNombre]) VALUES (CAST(7 AS Decimal(11, 0)), N'Usuarios Pantallas')
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(1 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(2 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(3 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(4 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(5 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(6 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioPantallaUsuario] ([UsuariosId], [InventarioPantallaId]) VALUES (CAST(2 AS Decimal(11, 0)), CAST(7 AS Decimal(11, 0)))
GO
INSERT [dbo].[InventarioCiegoConfig] ([InventarioCiegoRotacion], [InventarioCiegoPeriodo], [InventarioCiegoActivos], [InventarioCiegoArticulosDias], [InventarioCiegoFoliosEnviados], [InventarioCiegoCodigosAleatorios], [InventarioCiegoGeneraFolios], [InventarioRutaArchivosPDF]) VALUES (6, 2, 35827, 196, 3, 15, 0, N'C:\InventarioCiego')
GO
