IF OBJECT_ID('CondicionesPagos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CondicionesPagos](
			[CondicionesPagosId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[CondicionesPagosNombre] [char](60) NOT NULL,
			[CondicionesPagosCantidad] [int] NOT NULL,
			[CondicionesPagosAfectacion] [bit] NOT NULL,
			[CondicionesPagosFecha] [datetime] NOT NULL,
			[CondicionesPagosActivo] [char](1) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Condicio__3220C69CC55B3AB8] PRIMARY KEY CLUSTERED 
		(
			[CondicionesPagosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


	end