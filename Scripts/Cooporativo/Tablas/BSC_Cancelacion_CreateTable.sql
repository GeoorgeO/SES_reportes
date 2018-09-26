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
