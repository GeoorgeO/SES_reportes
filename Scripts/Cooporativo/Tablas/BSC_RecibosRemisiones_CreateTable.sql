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