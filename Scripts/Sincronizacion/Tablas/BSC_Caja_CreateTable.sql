IF OBJECT_ID('Caja') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Caja](
			[CajaId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[CajaNumero] [int] NOT NULL,
			[CajaDescripcion] [varchar](50) NOT NULL,
			[CajaReciboInicial] [int] NOT NULL,
			[CajaFondo] [money] NOT NULL,
			[CajaMontoEfectivo] [money] NOT NULL,
			[CajaMontoTarjeta] [money] NOT NULL,
			[CajaMontoVale] [money] NOT NULL,
			[CajaFecha] [datetime] NOT NULL,
			[CajaUltimoTicket] [decimal](18, 0) NOT NULL,
			[CajaUltimaDevolucion] [decimal](18, 0) NOT NULL,
			[CajaUltimaCancelacion] [decimal](18, 0) NOT NULL,
			[CajaUltimoCorte] [decimal](18, 0) NOT NULL,
			[CajaUltimoRetiro] [decimal](18, 0) NOT NULL,
			[CajaUltimoTicketMayoreo] [decimal](18, 0) NULL,
			[CajaUltimoDevolucionMayoreo] [decimal](18, 0) NULL,
			[CajaImpresoraTicket] [varchar](100) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Caja__A74F87074F87BD05] PRIMARY KEY CLUSTERED 
		(
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end