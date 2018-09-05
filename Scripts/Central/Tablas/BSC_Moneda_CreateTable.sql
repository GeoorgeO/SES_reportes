IF OBJECT_ID('Moneda') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Moneda](
			[MonedaId] [decimal](11, 0)  NOT NULL,
			[MonedaNombre] [char](60) NOT NULL,
			[MonedaSimbolo] [char](3) NOT NULL,
			[MonedaActivo] [char](1) NOT NULL,
			[MonedaTipoCambio] [money] NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Moneda__CEEBACBE7D099DCC] PRIMARY KEY CLUSTERED 
		(
			[MonedaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end