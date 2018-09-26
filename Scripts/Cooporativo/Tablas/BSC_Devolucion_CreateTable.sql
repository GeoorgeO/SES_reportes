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