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