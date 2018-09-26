IF OBJECT_ID('CortesZRecargas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecargas](
			[CortesZRecargasId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[CortesZRecargasFecha] [datetime] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[CortesZRecargasSub0] [money] NOT NULL,
			[CortesZRecargasSub16] [money] NOT NULL,
			[CortesZRecargasIva] [money] NOT NULL,
			[CortesZRecargasTotal] [money] NOT NULL,
			[FacturaGlobalFolio] [bigint] NULL,
			[CortesZRecargasFacturado] [bit] NULL,
			[CortesZRecargasTotalCosto] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZRecargas] PRIMARY KEY CLUSTERED 
		(
			[CortesZRecargasId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end



