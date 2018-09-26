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






