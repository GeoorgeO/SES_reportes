USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Apatzingan'))
BEGIN
	create Database Server_Apatzingan
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Calzada'))
BEGIN
	create Database Server_Calzada
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Centro'))
BEGIN
	create Database Server_Centro
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_CostaRica'))
BEGIN
	create Database Server_CostaRica
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Estocolmo'))
BEGIN
	create Database Server_Estocolmo
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_FcoVilla'))
BEGIN
	create Database Server_FcoVilla
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Lombardia'))
BEGIN
	create Database Server_Lombardia
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_LosReyes'))
BEGIN
	create Database Server_LosReyes
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Morelos'))
BEGIN
	create Database Server_Morelos
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_NvaItalia'))
BEGIN
	create Database Server_NvaItalia
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Almacen'))
BEGIN
	create Database Server_Almacen
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Paseo'))
BEGIN
	create Database Server_Paseo
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_SarabiaI'))
BEGIN
	create Database Server_SarabiaI
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_SarabiaII'))
BEGIN
	create Database Server_SarabiaII
END

GO
IF OBJECT_ID('ArticuloKardex') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[ArticuloKardex](
			[ArticuloCodigo] [char](40) NOT NULL,
			[Existencia] [int] NULL,
			[ArticuloCosto] [money] NULL,
			[ArticuloIVA] [money] NULL,
			[FechaExistencia] [datetime] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_ArticuloKardex] PRIMARY KEY CLUSTERED 
		(
			[ArticuloCodigo] ASC,
			[FechaExistencia] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end





GO
IF OBJECT_ID('Cancelacion') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Cancelacion](
			[CancelacionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[TicketId] [bigint] NULL,
			[UsuarioId] [decimal](11, 0) NOT NULL,
			[CancelacionFecha] [datetime] NOT NULL,
			[CancelacionSubtotal0] [money] NOT NULL,
			[CancelacionSubtotal16] [money] NOT NULL,
			[CancelacionIva] [money] NOT NULL,
			[CancelacionTotal] [money] NOT NULL,
			[CancelacionAsignadoCorte] [bit] NOT NULL,
			[CorteZId] [bigint] NULL,
			[CancelacionesTotal] [bit] NOT NULL,
			[TicketMayoreoId] [bigint] NULL,
			[FechaInsert] [datetime] NULL
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('CancelacionArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CancelacionArticulo](
			[CancelacionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[CancelacionArticuloUltimoIde] [bigint] NOT NULL,
			[TicketId] [bigint] NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[CancelacionArticuloPrecio] [money] NOT NULL,
			[CancelacionArticuloCantidad] [bigint] NOT NULL,
			[CancelacionArticuloSubtotal] [money] NOT NULL,
			[CancelacionArticuloIva] [money] NOT NULL,
			[CancelacionArticuloTotalLinea] [money] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_CancelacionArticulo] PRIMARY KEY CLUSTERED 
		(
			[CancelacionId] ASC,
			[CajaId] ASC,
			[CancelacionArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end





GO
IF OBJECT_ID('CortesZ') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZ](
			[CortesZId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[CortesZFecha] [datetime] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[CortesZSub0] [money] NOT NULL,
			[CortesZSub16] [money] NOT NULL,
			[CortesZIva] [money] NOT NULL,
			[CortesZTotal] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZ] PRIMARY KEY CLUSTERED 
		(
			[CortesZId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('CortesZRecargas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecargas](
			[CortesZRecargasId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[CortesZRecargasFecha] [datetime] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[CortesZRecargasSub0] [money] NOT NULL,
			[CortesZRecargasSub16] [money] NOT NULL,
			[CortesZRecargasIva] [money] NOT NULL,
			[CortesZRecargasTotal] [money] NOT NULL,
			[FacturaGlobalFolio] [bigint] NULL,
			[CortesZRecargasFacturado] [bit] NULL,
			[CortesZRecargasTotalCosto] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZRecargas] PRIMARY KEY CLUSTERED 
		(
			[CortesZRecargasId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end




GO
IF OBJECT_ID('CortesZRecargasTickets') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecargasTickets](
			[CortesZRecargasId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[CortesZRecargasTicketsInicio] [bigint] NOT NULL,
			[CortesZRecargasTicketsFin] [bigint] NOT NULL,
			[FechaInsert] [datetime] NULL
		) ON [PRIMARY]

		

		ALTER TABLE [dbo].[CortesZRecargasTickets]  WITH CHECK ADD  CONSTRAINT [FK_CortesZRecargasTickets_CortesZRecargas] FOREIGN KEY([CortesZRecargasId], [CajaId])
		REFERENCES [dbo].[CortesZRecargas] ([CortesZRecargasId], [CajaId])
		

		ALTER TABLE [dbo].[CortesZRecargasTickets] CHECK CONSTRAINT [FK_CortesZRecargasTickets_CortesZRecargas]
		

	end







GO
IF OBJECT_ID('CortesZRecibos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecibos](
			[CortesZRecibosId] [bigint] NOT NULL,
			[CortesZRecibosFecha] [datetime] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[CortesZRecibosTotal] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZRecibos] PRIMARY KEY CLUSTERED 
		(
			[CortesZRecibosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('CortesZRecibosDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecibosDetalles](
			[CortesZRecibosId] [bigint] NOT NULL,
			[CortesZRecibosInicio] [bigint] NOT NULL,
			[CortesZRecibosFin] [bigint] NOT NULL,
			[CortesZNCreditoInicio] [bigint] NOT NULL,
			[CortesZNCreditoFin] [bigint] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZRecibosDetalles] PRIMARY KEY CLUSTERED 
		(
			[CortesZRecibosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end

GO
IF OBJECT_ID('Devolucion') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Devolucion](
			[DevolucionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[TicketId] [bigint] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[DevolucionFecha] [datetime] NOT NULL,
			[DevolucionSubtotal0] [money] NOT NULL,
			[DevolucionSubtotal16] [money] NOT NULL,
			[DevolucionIva] [money] NOT NULL,
			[DevolucionTotal] [money] NOT NULL,
			[DevolucionAsignadoCorte] [bit] NOT NULL,
			[CorteZId] [bigint] NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
		(
			[DevolucionId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		
		

	end

GO
IF OBJECT_ID('DevolucionArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionArticulo](
			[DevolucionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[DevolucionArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[DevolucionArticuloPrecio] [money] NOT NULL,
			[DevolucionArticuloCantidad] [bigint] NOT NULL,
			[DevolucionArticuloSubtotal] [money] NOT NULL,
			[DevolucionArticuloIva] [money] NOT NULL,
			[DevolucionArticuloTotalLinea] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_DevolucionArticulo_1] PRIMARY KEY CLUSTERED 
		(
			[DevolucionId] ASC,
			[CajaId] ASC,
			[DevolucionArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		
		

	end

GO
IF OBJECT_ID('DevolucionMayoreo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionMayoreo](
			[DevolucionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[TicketId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[Clienteid] [decimal](11, 0) NOT NULL,
			[DevolucionFecha] [datetime] NOT NULL,
			[DevolucionSubtotal0] [money] NOT NULL,
			[DevolucionSubtotal16] [money] NOT NULL,
			[DevolucionIva] [money] NOT NULL,
			[DevolucionDescuento] [money] NOT NULL,
			[DevolucionTotal] [money] NOT NULL,
			[TicketTotalLetra] [varchar](max) NOT NULL,
			[DevolucionConcepto] [varchar](50) NOT NULL,
			[DevolucionAsignado] [bit] NOT NULL,
			[CortesZRecibosId] [bigint] NULL,
			[NC_Concepto] [varchar](max) NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_DevolucionMayoreo_1] PRIMARY KEY CLUSTERED 
		(
			[DevolucionId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		
		

	end

GO
IF OBJECT_ID('DevolucionMayoreoArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionMayoreoArticulo](
			[DevolucionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[DevolucionArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[DevolucionArticuloPrecio] [money] NOT NULL,
			[DevolucionArticuloCantidad] [bigint] NOT NULL,
			[DevolucionArticuloSubtotal] [money] NOT NULL,
			[DevolucionArticuloIva] [money] NOT NULL,
			[DevolucionArticuloTotalLinea] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_DevolucionMayoreoArticulo] PRIMARY KEY CLUSTERED 
		(
			[DevolucionId] ASC,
			[CajaId] ASC,
			[DevolucionArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('DevolucionPre') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionPre](
			[DevolucionPreId] [bigint] NOT NULL,
			[TicketId] [decimal](11, 0) NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[DevolucionPreFecha] [datetime] NOT NULL,
			[DevolucionPreTArticulos] [bigint] NOT NULL,
			[UsuarioId] [decimal](11, 0) NOT NULL,
			[VendedorId] [decimal](11, 0) NOT NULL,
			[DevolucionPreSub0] [money] NOT NULL,
			[DevolucionPreSub16] [money] NOT NULL,
			[DevolucionPreIva] [money] NOT NULL,
			[DevolucionPreTotal] [money] NOT NULL,
			[DevolucionPreProcesada] [bit] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_DevolucionPre] PRIMARY KEY CLUSTERED 
		(
			[DevolucionPreId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('DevolucionPreDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionPreDetalles](
			[DevolucionPreId] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[DevolucionPreCantidad] [bigint] NOT NULL,
			[DevolucionPrePUnitarioSimp] [money] NOT NULL,
			[DevolucionPrePUnitarioCImp] [money] NOT NULL,
			[DevolucionPreTLinea] [money] NOT NULL,
			[FechaInsert] [datetime] NULL
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('EntradaMercancia') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[EntradaMercancia](
			[EntradaMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NULL,
			[EntradaMercanciaTipoId] [bigint] NULL,
			[EntradaMercanciaFecha] [date] NULL,
			[EntradaMercanciaUnidades] [bigint] NULL,
			[EntradaMercanciaSub0] [decimal](18, 2) NULL,
			[EntradaMercanciaSub16] [decimal](18, 2) NULL,
			[EntradaMercanciaIva] [decimal](18, 2) NULL,
			[EntradaMercanciaTotal] [decimal](18, 2) NULL,
			[Observaciones] [nvarchar](max) NULL,
			[Referencias] [nvarchar](max) NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_EntradaMercancia] PRIMARY KEY CLUSTERED 
		(
			[EntradaMercanciaId] ASC,
			[SucursalesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('EntradaMercanciaArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[EntradaMercanciaArticulo](
			[EntradasMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[EntradasMercanciaArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NULL,
			[EntradasMercanciaArticuloCantidad] [bigint] NULL,
			[EntradasMercanciaArticuloSub0] [decimal](18, 2) NULL,
			[EntradasMercanciaArticuloSub16] [decimal](18, 2) NULL,
			[EntradasMercanciaArticuloIva] [decimal](18, 2) NULL,
			[EntradasMercanciaArticuloTotal] [decimal](18, 2) NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_EntradaMercanciaArticulo] PRIMARY KEY CLUSTERED 
		(
			[EntradasMercanciaId] ASC,
			[SucursalesId] ASC,
			[EntradasMercanciaArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('RecibosRemisiones') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[RecibosRemisiones](
			[RecibosId] [bigint] NOT NULL,
			[TicketId] [decimal](11, 0) NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[RecibosTotal] [decimal](18, 2) NOT NULL,
			[ReciboTotalLetra] [varchar](max) NOT NULL,
			[ReciboFecha] [datetime] NOT NULL,
			[ClienteId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[DocumentosId] [bigint] NOT NULL,
			[ReciboConcepto] [varchar](100) NOT NULL,
			[CortesZRecibosId] [bigint] NULL,
			[FormasdePagoCobranzaId] [bigint] NOT NULL,
			[RecibosAsignado] [bit] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_RecibosRemisiones] PRIMARY KEY CLUSTERED 
		(
			[RecibosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('SalidaMercancia') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[SalidaMercancia](
			[SalidaMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NULL,
			[SalidaMercanciaTipoId] [bigint] NULL,
			[SalidaMercanciaFecha] [date] NULL,
			[SalidaMercanciaUnidades] [bigint] NULL,
			[SalidaMercanciaSub0] [decimal](18, 2) NULL,
			[SalidaMercanciaSub16] [decimal](18, 2) NULL,
			[SalidaMercanciaIva] [decimal](18, 2) NULL,
			[SalidaMercanciaTotal] [decimal](18, 2) NULL,
			[Observaciones] [nvarchar](max) NULL,
			[Referencias] [nvarchar](max) NULL,
			[ParaSucursal] [char](60) NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_SalidaMercancia] PRIMARY KEY CLUSTERED 
		(
			[SalidaMercanciaId] ASC,
			[SucursalesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('SalidaMercanciaArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[SalidaMercanciaArticulo](
			[SalidaMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[SalidaMercanciaArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NULL,
			[SalidaMercanciaArticuloCantidad] [bigint] NULL,
			[SalidaMercanciaArticuloSub0] [decimal](18, 2) NULL,
			[SalidaMercanciaArticuloSub16] [decimal](18, 2) NULL,
			[SalidaMercanciaArticuloIva] [decimal](18, 2) NULL,
			[SalidaMercanciaArticuloTotal] [decimal](18, 2) NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_SalidaMercanciaArticulo] PRIMARY KEY CLUSTERED 
		(
			[SalidaMercanciaId] ASC,
			[SucursalesId] ASC,
			[SalidaMercanciaArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('Ticket') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Ticket](
			[TicketId] [decimal](11, 0) NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[UsuarioId] [decimal](11, 0) NOT NULL,
			[TicketFecha] [datetime] NOT NULL,
			[TicketHora] [datetime] NULL,
			[TicketSubtotal0] [money] NOT NULL,
			[TicketSubtotal16] [money] NOT NULL,
			[TicketIva] [money] NOT NULL,
			[TicketTotal] [money] NOT NULL,
			[CorteZId] [bigint] NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
		(
			[TicketId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('TicketArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[TicketArticulo](
			[TicketId] [decimal](11, 0) NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[TicketArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[TarifaId] [decimal](11, 0) NOT NULL,
			[MedidasId] [decimal](11, 0) NOT NULL,
			[TicketArticuloCosto] [money] NOT NULL,
			[TicketArticuloPrecio] [money] NOT NULL,
			[TicketArticuloCantidad] [int] NOT NULL,
			[TicketArticuloCantidadDevolucion] [bigint] NOT NULL,
			[TicketArticuloCantidadCancelada] [bigint] NOT NULL,
			[TicketArticuloSubtotal] [money] NOT NULL,
			[TicketArticuloIva] [money] NOT NULL,
			[TicketArticuloTotalLinea] [money] NOT NULL,
			[TicketArticuloDescuento] [money] NOT NULL,
			[TicketArticuloPrecioDescuento] [money] NOT NULL,
			[TicketArticuloIvaDescuento] [money] NOT NULL,
			[TicketArticuloTotal] [money] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_TicketArticulo] PRIMARY KEY CLUSTERED 
		(
			[TicketId] ASC,
			[CajaId] ASC,
			[TicketArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('TicketMayoreo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[TicketMayoreo](
			[TicketId] [decimal](11, 0) NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[UsuarioId] [decimal](11, 0) NOT NULL,
			[TicketFecha] [datetime] NOT NULL,
			[TicketSubtotal0] [money] NOT NULL,
			[TicketSubtotal16] [money] NOT NULL,
			[TicketIva] [money] NOT NULL,
			[TicketTotal] [money] NOT NULL,
			[CortesZRecibosId] [bigint] NULL,
			[FechaHora] [datetime] NULL,
			[ClienteId] [decimal](11, 0) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_TicketMayoreo] PRIMARY KEY CLUSTERED 
		(
			[TicketId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
IF OBJECT_ID('TicketMayoreoArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[TicketMayoreoArticulo](
			[TicketId] [decimal](11, 0) NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[TicketArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[TarifaId] [decimal](11, 0) NOT NULL,
			[MedidasId] [decimal](11, 0) NOT NULL,
			[TicketArticuloCosto] [money] NOT NULL,
			[TicketArticuloPrecio] [money] NULL,
			[TicketArticuloCantidad] [int] NOT NULL,
			[TicketArticuloCantidadDevolucion] [bigint] NOT NULL,
			[TicketArticuloCantidadCancelada] [bigint] NOT NULL,
			[TicketArticuloSubtotal] [money] NULL,
			[TicketArticuloIva] [money] NULL,
			[TicketArticuloTotalLinea] [money] NULL,
			[TicketArticuloDescuento] [money] NOT NULL,
			[TicketArticuloPrecioDescuento] [money] NOT NULL,
			[TicketArticuloIvaDescuento] [money] NOT NULL,
			[TicketArticuloTotal] [money] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_TicketMayoreoArticulo] PRIMARY KEY CLUSTERED 
		(
			[TicketId] ASC,
			[CajaId] ASC,
			[TicketArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloKardex_General')
DROP PROCEDURE SP_BSC_ArticuloKardex_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ArticuloKardex_General
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40) ,
	@Existencia int ,
	@ArticuloCosto money ,
	@ArticuloIVA money ,
	@FechaExistencia varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(ArticuloCodigo) from ArticuloKardex a where (a.ArticuloCodigo=@ArticuloCodigo and convert(datetime,FechaExistencia,103)=convert(datetime, @FechaExistencia,103))
	if @Existe>0
		select 0;
	else
		INSERT INTO ArticuloKardex
		(ArticuloCodigo, Existencia, ArticuloCosto, ArticuloIVA, FechaExistencia, FechaInsert)
		VALUES 
		(@ArticuloCodigo,@Existencia,@ArticuloCosto,@ArticuloIVA, convert(varchar, @FechaExistencia,103), GETDATE());
END
GO

GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Cancelacion_General')
DROP PROCEDURE SP_BSC_Cancelacion_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Cancelacion_General
	-- Add the parameters for the stored procedure here
	@CancelacionId bigint,
	@CajaId decimal(11, 0),
	@TicketId bigint,
	@UsuarioId decimal(11, 0),
	@CancelacionFecha datetime,
	@CancelacionSubtotal0 money,
	@CancelacionSubtotal16 money,
	@CancelacionIva money,
	@CancelacionTotal money,
	@CancelacionAsignadoCorte bit,
	@CorteZId bigint,
	@CancelacionesTotal bit,
	@TicketMayoreoId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CancelacionId) from Cancelacion a where (a.CancelacionId=@CancelacionId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			 INSERT INTO Cancelacion
                         (CancelacionId, CajaId, TicketId, UsuarioId, CancelacionFecha, CancelacionSubtotal0, CancelacionSubtotal16, CancelacionIva, CancelacionTotal, CancelacionAsignadoCorte, CorteZId, CancelacionesTotal, TicketMayoreoId, 
                         FechaInsert)
			VALUES        (@CancelacionId,@CajaId,@TicketId,@UsuarioId,@CancelacionFecha,@CancelacionSubtotal0,@CancelacionSubtotal16,@CancelacionIva,@CancelacionTotal,@CancelacionAsignadoCorte,@CorteZId,@CancelacionesTotal,@TicketMayoreoId,
									  GETDATE());
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CancelacionArticulo_General')
DROP PROCEDURE SP_BSC_CancelacionArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CancelacionArticulo_General
	-- Add the parameters for the stored procedure here
	@CancelacionId bigint,
	@CajaId decimal(11, 0),
	@CancelacionArticuloUltimoIde bigint,
	@TicketId bigint,
	@ArticuloCodigo char(40),
	@CancelacionArticuloPrecio money,
	@CancelacionArticuloCantidad bigint,
	@CancelacionArticuloSubtotal money,
	@CancelacionArticuloIva money,
	@CancelacionArticuloTotalLinea money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CancelacionId) from CancelacionArticulo a where (a.CancelacionId=@CancelacionId and a.CajaId=@CajaId and a.CancelacionArticuloUltimoIde=@CancelacionArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			 INSERT INTO CancelacionArticulo
                         (CancelacionId, CajaId, CancelacionArticuloUltimoIde, TicketId, ArticuloCodigo, CancelacionArticuloPrecio, CancelacionArticuloCantidad, CancelacionArticuloSubtotal, CancelacionArticuloIva, CancelacionArticuloTotalLinea, 
                         FechaInsert)
				VALUES        (@CancelacionId,@CajaId,@CancelacionArticuloUltimoIde,@TicketId,@ArticuloCodigo,@CancelacionArticuloPrecio,@CancelacionArticuloCantidad,@CancelacionArticuloSubtotal,@CancelacionArticuloIva,@CancelacionArticuloTotalLinea,
										  GETDATE());
END
GO

GO
GO

/****** Object:  StoredProcedure [dbo].[SP_BSC_CatalogosServer_Select]    Script Date: 20/09/2018 07:42:37 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CatalogosServer_Select')
DROP PROCEDURE SP_BSC_CatalogosServer_Select
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_BSC_CatalogosServer_Select]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TABLE_NAME
	FROM INFORMATION_SCHEMA.TABLES
	where TABLE_NAME not in ('DevolucionMayoreo','DevolucionMayoreoArticulo','TicketMayoreo','TicketMayoreoArticulo')
	order by 1
END

GO



GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZ_General')
DROP PROCEDURE SP_BSC_CortesZ_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZ_General
	-- Add the parameters for the stored procedure here
	@CortesZId bigint ,
	@CajaId decimal(11, 0) ,
	@CortesZFecha datetime ,
	@UsuariosId decimal(11, 0) ,
	@CortesZSub0 money ,
	@CortesZSub16 money ,
	@CortesZIva money ,
	@CortesZTotal money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CortesZId) from CortesZ a where (a.CortesZId=@CortesZId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			 INSERT INTO CortesZ
                         (CortesZId, CajaId, CortesZFecha, UsuariosId, CortesZSub0, CortesZSub16, CortesZIva, CortesZTotal, FechaInsert)
			VALUES        (@CortesZId,@CajaId,@CortesZFecha,@UsuariosId,@CortesZSub0,@CortesZSub16,@CortesZIva,@CortesZTotal, GETDATE());
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZRecargas_General')
DROP PROCEDURE SP_BSC_CortesZRecargas_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZRecargas_General
	-- Add the parameters for the stored procedure here
	@CortesZRecargasId bigint ,
	@CajaId decimal(11, 0) ,
	@CortesZRecargasFecha datetime ,
	@UsuariosId decimal(11, 0) ,
	@CortesZRecargasSub0 money ,
	@CortesZRecargasSub16 money ,
	@CortesZRecargasIva money ,
	@CortesZRecargasTotal money ,
	@FacturaGlobalFolio bigint ,
	@CortesZRecargasFacturado bit ,
	@CortesZRecargasTotalCosto money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CortesZRecargasId) from CortesZRecargas a where (a.CortesZRecargasId=@CortesZRecargasId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			 INSERT INTO CortesZRecargas
                         (CortesZRecargasId, CajaId, CortesZRecargasFecha, UsuariosId, CortesZRecargasSub0, CortesZRecargasSub16, CortesZRecargasIva, CortesZRecargasTotal, FacturaGlobalFolio, CortesZRecargasFacturado, 
                         CortesZRecargasTotalCosto, FechaInsert)
VALUES        (@CortesZRecargasId,@CajaId,@CortesZRecargasFecha,@UsuariosId,@CortesZRecargasSub0,@CortesZRecargasSub16,@CortesZRecargasIva,@CortesZRecargasTotal,@FacturaGlobalFolio,@CortesZRecargasFacturado,@CortesZRecargasTotalCosto,
                          GETDATE());
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZRecargasTickets_General')
DROP PROCEDURE SP_BSC_CortesZRecargasTickets_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZRecargasTickets_General
	-- Add the parameters for the stored procedure here
	@CortesZRecargasId bigint ,
	@CajaId decimal(11, 0) ,
	@CortesZRecargasTicketsInicio bigint ,
	@CortesZRecargasTicketsFin bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(a.CortesZRecargasId) from CortesZRecargasTickets a where (a.CortesZRecargasId=@CortesZRecargasId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			INSERT INTO CortesZRecargasTickets
                         (CortesZRecargasId, CajaId, CortesZRecargasTicketsInicio, CortesZRecargasTicketsFin, FechaInsert)
VALUES        (@CortesZRecargasId,@CajaId,@CortesZRecargasTicketsInicio,@CortesZRecargasTicketsFin, GETDATE()); 
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZRecibos_General')
DROP PROCEDURE SP_BSC_CortesZRecibos_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZRecibos_General
	-- Add the parameters for the stored procedure here
	@CortesZRecibosId bigint ,
	@CortesZRecibosFecha datetime ,
	@UsuariosId decimal(11, 0) ,
	@CortesZRecibosTotal money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CortesZRecibosId) from CortesZRecibos a where (a.CortesZRecibosId=@CortesZRecibosId )
	if @Existe>0
			select 0;
		else
			INSERT INTO CortesZRecibos
                         (CortesZRecibosId, CortesZRecibosFecha, UsuariosId, CortesZRecibosTotal, FechaInsert)
			VALUES        (@CortesZRecibosId,@CortesZRecibosFecha,@UsuariosId,@CortesZRecibosTotal, GETDATE());
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZRecibosDetalles_General')
DROP PROCEDURE SP_BSC_CortesZRecibosDetalles_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZRecibosDetalles_General
	-- Add the parameters for the stored procedure here
	@CortesZRecibosId bigint ,
	@CortesZRecibosInicio bigint ,
	@CortesZRecibosFin bigint ,
	@CortesZNCreditoInicio bigint ,
	@CortesZNCreditoFin bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CortesZRecibosId) from CortesZRecibosDetalles a where (a.CortesZRecibosId=@CortesZRecibosId )
	if @Existe>0
			select 0;
		else
			INSERT INTO CortesZRecibosDetalles
                         (CortesZRecibosId, CortesZRecibosInicio, CortesZRecibosFin, CortesZNCreditoInicio, CortesZNCreditoFin, FechaInsert)
			VALUES        (@CortesZRecibosId,@CortesZRecibosInicio,@CortesZRecibosFin,@CortesZNCreditoInicio,@CortesZNCreditoFin, GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Devolucion_General')
DROP PROCEDURE SP_BSC_Devolucion_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Devolucion_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@TicketId bigint ,
	@UsuariosId decimal(11, 0) ,
	@DevolucionFecha datetime ,
	@DevolucionSubtotal0 money ,
	@DevolucionSubtotal16 money ,
	@DevolucionIva money ,
	@DevolucionTotal money ,
	@DevolucionAsignadoCorte bit ,
	@CorteZId bigint 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from Devolucion a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			INSERT INTO Devolucion
                         (DevolucionId, CajaId, TicketId, UsuariosId, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionTotal, DevolucionAsignadoCorte, CorteZId,FechaInsert)
VALUES        (@DevolucionId,@CajaId,@TicketId,@UsuariosId,@DevolucionFecha,@DevolucionSubtotal0,@DevolucionSubtotal16,@DevolucionIva,@DevolucionTotal,@DevolucionAsignadoCorte,@CorteZId,GETDATE()) 
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionArticulo_General')
DROP PROCEDURE SP_BSC_DevolucionArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionArticulo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@DevolucionArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@DevolucionArticuloPrecio money ,
	@DevolucionArticuloCantidad bigint ,
	@DevolucionArticuloSubtotal money ,
	@DevolucionArticuloIva money ,
	@DevolucionArticuloTotalLinea money 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionArticulo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId and a.DevolucionArticuloUltimoIde=@DevolucionArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			INSERT INTO DevolucionArticulo
                         (DevolucionId, CajaId, DevolucionArticuloUltimoIde, ArticuloCodigo, DevolucionArticuloPrecio, DevolucionArticuloCantidad, DevolucionArticuloSubtotal, DevolucionArticuloIva, DevolucionArticuloTotalLinea, 
                         FechaInsert)
VALUES        (@DevolucionId,@CajaId,@DevolucionArticuloUltimoIde,@ArticuloCodigo,@DevolucionArticuloPrecio,@DevolucionArticuloCantidad,@DevolucionArticuloSubtotal,@DevolucionArticuloIva,@DevolucionArticuloTotalLinea,
                          GETDATE())
	
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionMayoreo_General')
DROP PROCEDURE SP_BSC_DevolucionMayoreo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionMayoreo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@TicketId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@Clienteid decimal(11, 0) ,
	@DevolucionFecha datetime ,
	@DevolucionSubtotal0 money ,
	@DevolucionSubtotal16 money ,
	@DevolucionIva money ,
	@DevolucionDescuento money ,
	@DevolucionTotal money ,
	@TicketTotalLetra varchar(max) ,
	@DevolucionConcepto varchar(50) ,
	@DevolucionAsignado bit ,
	@CortesZRecibosId bigint ,
	@NC_Concepto varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionMayoreo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			INSERT INTO DevolucionMayoreo
                         (DevolucionId, CajaId, TicketId, UsuariosId, Clienteid, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionDescuento, DevolucionTotal, TicketTotalLetra, DevolucionConcepto,
                          DevolucionAsignado, CortesZRecibosId, NC_Concepto, FechaInsert)
VALUES        (@DevolucionId,@CajaId,@TicketId,@UsuariosId,@Clienteid,@DevolucionFecha,@DevolucionSubtotal0,@DevolucionSubtotal16,@DevolucionIva,@DevolucionDescuento,@DevolucionTotal,@TicketTotalLetra,@DevolucionConcepto,@DevolucionAsignado,@CortesZRecibosId,@NC_Concepto,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionMayoreoArticulo_General')
DROP PROCEDURE SP_BSC_DevolucionMayoreoArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionMayoreoArticulo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@DevolucionArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@DevolucionArticuloPrecio money ,
	@DevolucionArticuloCantidad bigint ,
	@DevolucionArticuloSubtotal money ,
	@DevolucionArticuloIva money ,
	@DevolucionArticuloTotalLinea money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionMayoreoArticulo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId and a.DevolucionArticuloUltimoIde=@DevolucionArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
		INSERT INTO DevolucionMayoreoArticulo
                         (DevolucionId, CajaId, DevolucionArticuloUltimoIde, ArticuloCodigo, DevolucionArticuloPrecio, DevolucionArticuloCantidad, DevolucionArticuloSubtotal, DevolucionArticuloIva, DevolucionArticuloTotalLinea, 
                         FechaInsert)
VALUES        (@DevolucionId,@CajaId,@DevolucionArticuloUltimoIde,@ArticuloCodigo,@DevolucionArticuloPrecio,@DevolucionArticuloCantidad,@DevolucionArticuloSubtotal,@DevolucionArticuloIva,@DevolucionArticuloTotalLinea,
                          GETDATE())	
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionPre_General')
DROP PROCEDURE SP_BSC_DevolucionPre_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionPre_General
	-- Add the parameters for the stored procedure here
	@DevolucionPreId bigint ,
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@DevolucionPreFecha datetime ,
	@DevolucionPreTArticulos bigint ,
	@UsuarioId decimal(11, 0) ,
	@VendedorId decimal(11, 0) ,
	@DevolucionPreSub0 money ,
	@DevolucionPreSub16 money ,
	@DevolucionPreIva money ,
	@DevolucionPreTotal money ,
	@DevolucionPreProcesada bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionPreId) from DevolucionPre a where (a.DevolucionPreId=@DevolucionPreId )
	if @Existe>0
			select 0;
		else
			INSERT INTO DevolucionPre
                         (DevolucionPreId, TicketId, CajaId, DevolucionPreFecha, DevolucionPreTArticulos, UsuarioId, VendedorId, DevolucionPreSub0, DevolucionPreSub16, DevolucionPreIva, DevolucionPreTotal, 
                         DevolucionPreProcesada,FechaInsert)
			VALUES        (@DevolucionPreId,@TicketId,@CajaId,@DevolucionPreFecha,@DevolucionPreTArticulos,@UsuarioId,@VendedorId,@DevolucionPreSub0,@DevolucionPreSub16,@DevolucionPreIva,@DevolucionPreTotal,@DevolucionPreProcesada,getdate())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionPreDetalles_General')
DROP PROCEDURE SP_BSC_DevolucionPreDetalles_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionPreDetalles_General
	-- Add the parameters for the stored procedure here
	@DevolucionPreId bigint ,
	@ArticuloCodigo char(40) ,
	@DevolucionPreCantidad bigint ,
	@DevolucionPrePUnitarioSimp money ,
	@DevolucionPrePUnitarioCImp money ,
	@DevolucionPreTLinea money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionPreId) from DevolucionPreDetalles a where (a.DevolucionPreId=@DevolucionPreId and  a.ArticuloCodigo=@ArticuloCodigo)
	if @Existe>0
			select 0;
		else
			INSERT INTO DevolucionPreDetalles
                         (DevolucionPreId, ArticuloCodigo, DevolucionPreCantidad, DevolucionPrePUnitarioSimp, DevolucionPrePUnitarioCImp, DevolucionPreTLinea, FechaInsert)
VALUES        (@DevolucionPreId,@ArticuloCodigo,@DevolucionPreCantidad,@DevolucionPrePUnitarioSimp,@DevolucionPrePUnitarioCImp,@DevolucionPreTLinea, GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercancia_General')
DROP PROCEDURE SP_BSC_EntradaMercancia_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_EntradaMercancia_General 
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@EntradaMercanciaTipoId bigint ,
	@EntradaMercanciaFecha date ,
	@EntradaMercanciaUnidades bigint ,
	@EntradaMercanciaSub0 decimal(18, 2) ,
	@EntradaMercanciaSub16 decimal(18, 2) ,
	@EntradaMercanciaIva decimal(18, 2) ,
	@EntradaMercanciaTotal decimal(18, 2) ,
	@Observaciones nvarchar(max) ,
	@Referencias nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(EntradaMercanciaId) from EntradaMercancia a where (a.EntradaMercanciaId=@EntradaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 0;
		else
			INSERT INTO EntradaMercancia
                         (EntradaMercanciaId, SucursalesId, UsuariosId, EntradaMercanciaTipoId, EntradaMercanciaFecha, EntradaMercanciaUnidades, EntradaMercanciaSub0, EntradaMercanciaSub16, EntradaMercanciaIva, 
                         EntradaMercanciaTotal, Observaciones, Referencias, FechaInsert)
VALUES        (@EntradaMercanciaId,@SucursalesId,@UsuariosId,@EntradaMercanciaTipoId,@EntradaMercanciaFecha,@EntradaMercanciaUnidades,@EntradaMercanciaSub0,@EntradaMercanciaSub16,@EntradaMercanciaIva,@EntradaMercanciaTotal,@Observaciones,@Referencias,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaArticulo_General')
DROP PROCEDURE SP_BSC_EntradaMercanciaArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_EntradaMercanciaArticulo_General 
	-- Add the parameters for the stored procedure here
	@EntradasMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@EntradasMercanciaArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@EntradasMercanciaArticuloCantidad bigint ,
	@EntradasMercanciaArticuloSub0 decimal(18, 2) ,
	@EntradasMercanciaArticuloSub16 decimal(18, 2) ,
	@EntradasMercanciaArticuloIva decimal(18, 2) ,
	@EntradasMercanciaArticuloTotal decimal(18, 2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(EntradasMercanciaId) from EntradaMercanciaArticulo a where (a.EntradasMercanciaId=@EntradasMercanciaId and a.SucursalesId=@SucursalesId and a.EntradasMercanciaArticuloUltimoIde=@EntradasMercanciaArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			INSERT INTO EntradaMercanciaArticulo
                         (EntradasMercanciaId, SucursalesId, EntradasMercanciaArticuloUltimoIde, ArticuloCodigo, EntradasMercanciaArticuloCantidad, EntradasMercanciaArticuloSub0, EntradasMercanciaArticuloSub16, 
                         EntradasMercanciaArticuloIva, EntradasMercanciaArticuloTotal, FechaInsert)
VALUES        (@EntradasMercanciaId,@SucursalesId,@EntradasMercanciaArticuloUltimoIde,@ArticuloCodigo,@EntradasMercanciaArticuloCantidad,@EntradasMercanciaArticuloSub0,@EntradasMercanciaArticuloSub16,@EntradasMercanciaArticuloIva,@EntradasMercanciaArticuloTotal,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_RecibosRemisiones_General')
DROP PROCEDURE SP_BSC_RecibosRemisiones_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_RecibosRemisiones_General
	-- Add the parameters for the stored procedure here
	@RecibosId bigint ,
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@RecibosTotal decimal(18, 2) ,
	@ReciboTotalLetra varchar(max) ,
	@ReciboFecha datetime ,
	@ClienteId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@DocumentosId bigint ,
	@ReciboConcepto varchar(100) ,
	@CortesZRecibosId bigint NULL,
	@FormasdePagoCobranzaId bigint ,
	@RecibosAsignado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(RecibosId) from RecibosRemisiones a where (a.RecibosId=@RecibosId )
	if @Existe>0
			select 0;
		else
			INSERT INTO RecibosRemisiones
                         (RecibosId, TicketId, CajaId, RecibosTotal, ReciboTotalLetra, ReciboFecha, ClienteId, UsuariosId, DocumentosId, ReciboConcepto, CortesZRecibosId, FormasdePagoCobranzaId, RecibosAsignado, FechaInsert)
VALUES        (@RecibosId,@TicketId,@CajaId,@RecibosTotal,@ReciboTotalLetra,@ReciboFecha,@ClienteId,@UsuariosId,@DocumentosId,@ReciboConcepto,@CortesZRecibosId,@FormasdePagoCobranzaId,@RecibosAsignado,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercancia_General')
DROP PROCEDURE SP_BSC_SalidaMercancia_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercancia_General
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@SalidaMercanciaTipoId bigint ,
	@SalidaMercanciaFecha date ,
	@SalidaMercanciaUnidades bigint ,
	@SalidaMercanciaSub0 decimal(18, 2) ,
	@SalidaMercanciaSub16 decimal(18, 2) ,
	@SalidaMercanciaIva decimal(18, 2) ,
	@SalidaMercanciaTotal decimal(18, 2) ,
	@Observaciones nvarchar(max) ,
	@Referencias nvarchar(max) ,
	@ParaSucursal char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(SalidaMercanciaId) from SalidaMercancia a where (a.SalidaMercanciaId=@SalidaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 0;
		else
			INSERT INTO SalidaMercancia
                         (SalidaMercanciaId, SucursalesId, UsuariosId, SalidaMercanciaTipoId, SalidaMercanciaFecha, SalidaMercanciaUnidades, SalidaMercanciaSub0, SalidaMercanciaSub16, SalidaMercanciaIva, 
                         SalidaMercanciaTotal, Observaciones, Referencias, ParaSucursal, FechaInsert)
VALUES        (@SalidaMercanciaId,@SucursalesId,@UsuariosId,@SalidaMercanciaTipoId,@SalidaMercanciaFecha,@SalidaMercanciaUnidades,@SalidaMercanciaSub0,@SalidaMercanciaSub16,@SalidaMercanciaIva,@SalidaMercanciaTotal,@Observaciones,@Referencias,@ParaSucursal,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercanciaArticulo_General')
DROP PROCEDURE SP_BSC_SalidaMercanciaArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercanciaArticulo_General
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@SalidaMercanciaArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@SalidaMercanciaArticuloCantidad bigint ,
	@SalidaMercanciaArticuloSub0 decimal(18, 2) ,
	@SalidaMercanciaArticuloSub16 decimal(18, 2) ,
	@SalidaMercanciaArticuloIva decimal(18, 2) ,
	@SalidaMercanciaArticuloTotal decimal(18, 2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(SalidaMercanciaId) from SalidaMercanciaArticulo a where (a.SalidaMercanciaId=@SalidaMercanciaId and a.SucursalesId=@SucursalesId and a.SalidaMercanciaArticuloUltimoIde=@SalidaMercanciaArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			INSERT INTO SalidaMercanciaArticulo
                         (SalidaMercanciaId, SucursalesId, SalidaMercanciaArticuloUltimoIde, ArticuloCodigo, SalidaMercanciaArticuloCantidad, SalidaMercanciaArticuloSub0, SalidaMercanciaArticuloSub16, SalidaMercanciaArticuloIva, 
                         SalidaMercanciaArticuloTotal, FechaInsert)
VALUES        (@SalidaMercanciaId,@SucursalesId,@SalidaMercanciaArticuloUltimoIde,@ArticuloCodigo,@SalidaMercanciaArticuloCantidad,@SalidaMercanciaArticuloSub0,@SalidaMercanciaArticuloSub16,@SalidaMercanciaArticuloIva,@SalidaMercanciaArticuloTotal,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Ticket_General')
DROP PROCEDURE SP_BSC_Ticket_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Ticket_General 
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@UsuarioId decimal(11, 0) ,
	@TicketFecha datetime ,
	/*@TicketHora datetime ,*/
	@TicketSubtotal0 money ,
	@TicketSubtotal16 money ,
	@TicketIva money ,
	@TicketTotal money ,
	@CorteZId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from Ticket a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			INSERT INTO Ticket
                         (TicketId, CajaId, UsuarioId, TicketFecha, /*TicketHora,*/ TicketSubtotal0, TicketSubtotal16, TicketIva, TicketTotal, CorteZId, FechaInsert)
VALUES        (@TicketId,@CajaId,@UsuarioId,@TicketFecha,/*@TicketHora,*/@TicketSubtotal0,@TicketSubtotal16,@TicketIva,@TicketTotal,@CorteZId, GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TicketArticulo_General')
DROP PROCEDURE SP_BSC_TicketArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  SP_BSC_TicketArticulo_General
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@TicketArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@TarifaId decimal(11, 0) ,
	@MedidasId decimal(11, 0) ,
	@TicketArticuloCosto money ,
	@TicketArticuloPrecio money ,
	@TicketArticuloCantidad int ,
	@TicketArticuloCantidadDevolucion bigint ,
	@TicketArticuloCantidadCancelada bigint ,
	@TicketArticuloSubtotal money ,
	@TicketArticuloIva money ,
	@TicketArticuloTotalLinea money ,
	@TicketArticuloDescuento money ,
	@TicketArticuloPrecioDescuento money ,
	@TicketArticuloIvaDescuento money ,
	@TicketArticuloTotal money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from TicketArticulo a where (a.TicketId=@TicketId and a.CajaId=@CajaId and a.TicketArticuloUltimoIde=@TicketArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			INSERT INTO TicketArticulo
                         (TicketId, CajaId, TicketArticuloUltimoIde, ArticuloCodigo, TarifaId, MedidasId, TicketArticuloCosto, TicketArticuloPrecio, TicketArticuloCantidad, TicketArticuloCantidadDevolucion, TicketArticuloCantidadCancelada, 
                         TicketArticuloSubtotal, TicketArticuloIva, TicketArticuloTotalLinea, TicketArticuloDescuento, TicketArticuloPrecioDescuento, TicketArticuloIvaDescuento, TicketArticuloTotal, FechaInsert)
VALUES        (@TicketId,@CajaId,@TicketArticuloUltimoIde,@ArticuloCodigo,@TarifaId,@MedidasId,@TicketArticuloCosto,@TicketArticuloPrecio,@TicketArticuloCantidad,@TicketArticuloCantidadDevolucion,@TicketArticuloCantidadCancelada,@TicketArticuloSubtotal,@TicketArticuloIva,@TicketArticuloTotalLinea,@TicketArticuloDescuento,@TicketArticuloPrecioDescuento,@TicketArticuloIvaDescuento,@TicketArticuloTotal,
                          GETDATE())
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TicketMayoreo_General')
DROP PROCEDURE SP_BSC_TicketMayoreo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TicketMayoreo_General
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@UsuarioId decimal(11, 0) ,
	@TicketFecha datetime ,
	@TicketSubtotal0 money ,
	@TicketSubtotal16 money ,
	@TicketIva money ,
	@TicketTotal money ,
	@CortesZRecibosId bigint NULL,
	/*@FechaHora datetime NULL,*/
	@ClienteId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from TicketMayoreo a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
		INSERT INTO TicketMayoreo
                         (TicketId, CajaId, UsuarioId, TicketFecha, TicketSubtotal0, TicketSubtotal16, TicketIva, TicketTotal, CortesZRecibosId, /*FechaHora,*/ ClienteId, FechaInsert)
VALUES        (@TicketId,@CajaId,@UsuarioId,@TicketFecha,@TicketSubtotal0,@TicketSubtotal16,@TicketIva,@TicketTotal,@CortesZRecibosId,/*@FechaHora,*/@ClienteId, GETDATE())	
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TicketMayoreoArticulo_General')
DROP PROCEDURE SP_BSC_TicketMayoreoArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TicketMayoreoArticulo_General
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@TicketArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@TarifaId decimal(11, 0) ,
	@MedidasId decimal(11, 0) ,
	@TicketArticuloCosto money ,
	@TicketArticuloPrecio money ,
	@TicketArticuloCantidad int ,
	@TicketArticuloCantidadDevolucion bigint ,
	@TicketArticuloCantidadCancelada bigint ,
	@TicketArticuloSubtotal money ,
	@TicketArticuloIva money ,
	@TicketArticuloTotalLinea money ,
	@TicketArticuloDescuento money ,
	@TicketArticuloPrecioDescuento money ,
	@TicketArticuloIvaDescuento money ,
	@TicketArticuloTotal money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from TicketMayoreoArticulo a where (a.TicketId=@TicketId and a.CajaId=@CajaId and a.TicketArticuloUltimoIde=@TicketArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			INSERT INTO TicketMayoreoArticulo
                         (TicketId, CajaId, TicketArticuloUltimoIde, ArticuloCodigo, TarifaId, MedidasId, TicketArticuloCosto, TicketArticuloPrecio, TicketArticuloCantidad, TicketArticuloCantidadDevolucion, TicketArticuloCantidadCancelada, 
                         TicketArticuloSubtotal, TicketArticuloIva, TicketArticuloTotalLinea, TicketArticuloDescuento, TicketArticuloPrecioDescuento, TicketArticuloIvaDescuento, TicketArticuloTotal, FechaInsert)
VALUES        (@TicketId,@CajaId,@TicketArticuloUltimoIde,@ArticuloCodigo,@TarifaId,@MedidasId,@TicketArticuloCosto,@TicketArticuloPrecio,@TicketArticuloCantidad,@TicketArticuloCantidadDevolucion,@TicketArticuloCantidadCancelada,@TicketArticuloSubtotal,@TicketArticuloIva,@TicketArticuloTotalLinea,@TicketArticuloDescuento,@TicketArticuloPrecioDescuento,@TicketArticuloIvaDescuento,@TicketArticuloTotal,
                          GETDATE())
END
GO

GO
