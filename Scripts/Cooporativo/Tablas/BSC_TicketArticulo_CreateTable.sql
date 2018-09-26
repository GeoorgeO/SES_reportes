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
