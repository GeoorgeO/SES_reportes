IF OBJECT_ID('CortesZRecibos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZRecibos](
			[CortesZRecibosId] [bigint] NOT NULL,
			[CortesZRecibosFecha] [datetime] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[CortesZRecibosTotal] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZRecibos] PRIMARY KEY CLUSTERED 
		(
			[CortesZRecibosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end