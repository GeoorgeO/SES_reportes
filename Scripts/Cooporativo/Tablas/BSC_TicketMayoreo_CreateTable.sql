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
