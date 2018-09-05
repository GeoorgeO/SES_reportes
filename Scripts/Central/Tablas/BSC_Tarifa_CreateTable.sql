IF OBJECT_ID('Tarifa') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Tarifa](
			[TarifaId] [decimal](11, 0) NOT NULL,
			[TarifaNombre] [char](60) NOT NULL,
			[TarifaFecha] [datetime] NOT NULL,
			[TarifaActivo] [char](1) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Tarifa__E81AC2FB190833D5] PRIMARY KEY CLUSTERED 
		(
			[TarifaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end