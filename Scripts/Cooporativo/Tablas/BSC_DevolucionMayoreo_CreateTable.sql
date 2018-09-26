IF OBJECT_ID('DevolucionMayoreo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionMayoreo](
			[DevolucionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[TicketId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[Clienteid] [decimal](11, 0) NOT NULL,
			[DevolucionFecha] [datetime] NOT NULL,
			[DevolucionSubtotal0] [money] NOT NULL,
			[DevolucionSubtotal16] [money] NOT NULL,
			[DevolucionIva] [money] NOT NULL,
			[DevolucionDescuento] [money] NOT NULL,
			[DevolucionTotal] [money] NOT NULL,
			[TicketTotalLetra] [varchar](max) NOT NULL,
			[DevolucionConcepto] [varchar](50) NOT NULL,
			[DevolucionAsignado] [bit] NOT NULL,
			[CortesZRecibosId] [bigint] NULL,
			[NC_Concepto] [varchar](max) NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_DevolucionMayoreo_1] PRIMARY KEY CLUSTERED 
		(
			[DevolucionId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		
		

	end
