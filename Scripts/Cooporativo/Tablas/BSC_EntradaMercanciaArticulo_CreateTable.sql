IF OBJECT_ID('EntradaMercanciaArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[EntradaMercanciaArticulo](
			[EntradasMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[EntradasMercanciaArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NULL,
			[EntradasMercanciaArticuloCantidad] [bigint] NULL,
			[EntradasMercanciaArticuloSub0] [decimal](18, 2) NULL,
			[EntradasMercanciaArticuloSub16] [decimal](18, 2) NULL,
			[EntradasMercanciaArticuloIva] [decimal](18, 2) NULL,
			[EntradasMercanciaArticuloTotal] [decimal](18, 2) NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_EntradaMercanciaArticulo] PRIMARY KEY CLUSTERED 
		(
			[EntradasMercanciaId] ASC,
			[SucursalesId] ASC,
			[EntradasMercanciaArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end