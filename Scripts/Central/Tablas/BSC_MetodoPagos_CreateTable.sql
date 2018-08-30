IF OBJECT_ID('MetodoPagos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[MetodoPagos](
			[MetodoPagosId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[MetodoPagosNombre] [char](60) NOT NULL,
			[MetodoPagosFecha] [datetime] NOT NULL,
			[MetodoPagosActivo] [char](1) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__MetodoPa__E1A291550371755F] PRIMARY KEY CLUSTERED 
		(
			[MetodoPagosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end