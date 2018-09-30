IF OBJECT_ID('CortesZRecibosDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecibosDetalles](
			[CortesZRecibosId] [bigint] NOT NULL,
			[CortesZRecibosInicio] [bigint] NOT NULL,
			[CortesZRecibosFin] [bigint] NOT NULL,
			[CortesZNCreditoInicio] [bigint] NOT NULL,
			[CortesZNCreditoFin] [bigint] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZRecibosDetalles] PRIMARY KEY CLUSTERED 
		(
			[CortesZRecibosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end