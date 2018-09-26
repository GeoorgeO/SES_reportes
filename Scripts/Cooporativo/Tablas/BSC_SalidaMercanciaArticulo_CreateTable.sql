IF OBJECT_ID('SalidaMercanciaArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[SalidaMercanciaArticulo](
			[SalidaMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[SalidaMercanciaArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NULL,
			[SalidaMercanciaArticuloCantidad] [bigint] NULL,
			[SalidaMercanciaArticuloSub0] [decimal](18, 2) NULL,
			[SalidaMercanciaArticuloSub16] [decimal](18, 2) NULL,
			[SalidaMercanciaArticuloIva] [decimal](18, 2) NULL,
			[SalidaMercanciaArticuloTotal] [decimal](18, 2) NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_SalidaMercanciaArticulo] PRIMARY KEY CLUSTERED 
		(
			[SalidaMercanciaId] ASC,
			[SucursalesId] ASC,
			[SalidaMercanciaArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end