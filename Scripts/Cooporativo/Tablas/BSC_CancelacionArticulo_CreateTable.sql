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




