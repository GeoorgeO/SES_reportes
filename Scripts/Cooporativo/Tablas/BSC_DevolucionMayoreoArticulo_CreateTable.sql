IF OBJECT_ID('DevolucionMayoreoArticulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionMayoreoArticulo](
			[DevolucionId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[DevolucionArticuloUltimoIde] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[DevolucionArticuloPrecio] [money] NOT NULL,
			[DevolucionArticuloCantidad] [bigint] NOT NULL,
			[DevolucionArticuloSubtotal] [money] NOT NULL,
			[DevolucionArticuloIva] [money] NOT NULL,
			[DevolucionArticuloTotalLinea] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_DevolucionMayoreoArticulo] PRIMARY KEY CLUSTERED 
		(
			[DevolucionId] ASC,
			[CajaId] ASC,
			[DevolucionArticuloUltimoIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
		

	end