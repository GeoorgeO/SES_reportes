
GO
/****** Object:  Table [dbo].[InventarioCiego]    Script Date: 13/08/2019 09:15:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventarioCiego](
	[InventarioCiegoFolio] [bigint] NOT NULL,
	[InventarioCiegoFecha] [datetime] NULL,
	[InventarioCiegoEstatus] [varchar](50) NULL,
	[SucursalesId] [decimal](11, 0) NULL,
	[InventarioCiegoFinalizacion] [datetime] NULL,
 CONSTRAINT [PK_InventarioCiego] PRIMARY KEY CLUSTERED 
(
	[InventarioCiegoFolio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventarioCiegoConfig]    Script Date: 13/08/2019 09:15:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventarioCiegoConfig](
	[InventarioCiegoRotacion] [int] NULL,
	[InventarioCiegoPeriodo] [int] NULL,
	[InventarioCiegoActivos] [bigint] NULL,
	[InventarioCiegoArticulosDias] [bigint] NULL,
	[InventarioCiegoFoliosEnviados] [int] NULL,
	[InventarioCiegoCodigosAleatorios] [int] NULL,
	[InventarioCiegoGeneraFolios] [bit] NULL,
	[InventarioRutaArchivosPDF] [varchar](250) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventarioCiegoDetalles]    Script Date: 13/08/2019 09:15:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventarioCiegoDetalles](
	[InventarioCiegoFolio] [bigint] NOT NULL,
	[InventarioCiegoCodigo] [char](40) NOT NULL,
	[InventarioCiegoCantidad] [int] NOT NULL,
	[InventarioCiegoFechaPrimerConteo] [datetime] NOT NULL,
	[InventarioCiegoCantidadPrimerConteo] [int] NOT NULL,
	[InventarioCiegoFechaSegundoConteo] [datetime] NOT NULL,
	[InventarioCiegoCantidadSegundoConteo] [int] NOT NULL,
	[InventarioCiegoFechaContraloria] [datetime] NOT NULL,
	[InventarioCiegoCantidadSistema] [int] NOT NULL,
	[InventarioCiegoCantidadContraloria] [int] NOT NULL,
	[InventarioCiegoEntrada] [int] NULL,
	[InventarioCiegoSalida] [int] NULL,
	[InventarioCiegoAleatorio] [bit] NULL,
 CONSTRAINT [PK_InventarioCiegoDetalles] PRIMARY KEY CLUSTERED 
(
	[InventarioCiegoFolio] ASC,
	[InventarioCiegoCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventarioPantalla]    Script Date: 13/08/2019 09:15:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventarioPantalla](
	[InventarioPantallaId] [decimal](11, 0) NOT NULL,
	[InventarioPantallaNombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_InventarioPantalla_1] PRIMARY KEY CLUSTERED 
(
	[InventarioPantallaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventarioPantallaUsuario]    Script Date: 13/08/2019 09:15:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventarioPantallaUsuario](
	[UsuariosId] [decimal](11, 0) NOT NULL,
	[InventarioPantallaId] [decimal](11, 0) NOT NULL,
 CONSTRAINT [PK_InventarioPantallaUsuario] PRIMARY KEY CLUSTERED 
(
	[UsuariosId] ASC,
	[InventarioPantallaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[InventarioCiegoDetalles]  WITH CHECK ADD  CONSTRAINT [FK_InventarioCiegoDetalles_InventarioCiego] FOREIGN KEY([InventarioCiegoFolio])
REFERENCES [dbo].[InventarioCiego] ([InventarioCiegoFolio])
GO
ALTER TABLE [dbo].[InventarioCiegoDetalles] CHECK CONSTRAINT [FK_InventarioCiegoDetalles_InventarioCiego]
GO
ALTER TABLE [dbo].[InventarioPantallaUsuario]  WITH CHECK ADD  CONSTRAINT [FK_InventarioPantallaUsuario_InventarioPantalla] FOREIGN KEY([InventarioPantallaId])
REFERENCES [dbo].[InventarioPantalla] ([InventarioPantallaId])
GO
ALTER TABLE [dbo].[InventarioPantallaUsuario] CHECK CONSTRAINT [FK_InventarioPantallaUsuario_InventarioPantalla]
GO
ALTER TABLE [dbo].[InventarioPantallaUsuario]  WITH CHECK ADD  CONSTRAINT [FK_InventarioPantallaUsuarios_Usuarios] FOREIGN KEY([UsuariosId])
REFERENCES [dbo].[Usuarios] ([UsuariosId])
GO
ALTER TABLE [dbo].[InventarioPantallaUsuario] CHECK CONSTRAINT [FK_InventarioPantallaUsuarios_Usuarios]
GO
