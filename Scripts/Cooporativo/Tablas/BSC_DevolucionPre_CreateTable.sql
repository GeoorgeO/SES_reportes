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
