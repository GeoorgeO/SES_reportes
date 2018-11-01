USE [SES_Reportes]
GO

SET ANSI_NULLS ON
		GO

		SET QUOTED_IDENTIFIER ON
		GO

		SET ANSI_PADDING ON
		GO

IF OBJECT_ID('Pre_PedidosDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin

		/****** Object:  Table [dbo].[Pre_PedidosDetalles]    Script Date: 01/11/2018 10:54:44 a. m. ******/
		

		CREATE TABLE [dbo].[Pre_PedidosDetalles](
			[ArticuloCodigo] [char](40) NOT NULL,
			[ArticuloDescripcion] [char](200) NULL,
			[ArticuloCostoReposicion] [decimal](10, 4) NULL,
			[FamiliaNombre] [char](60) NULL,
			[VAlmacen] [decimal](10, 4) NULL,
			[EAlmacen] [decimal](10, 4) NULL,
			[VApatzingan] [decimal](10, 4) NULL,
			[EApatzingan] [decimal](10, 4) NULL,
			[VCalzada] [decimal](10, 4) NULL,
			[ECalzada] [decimal](10, 4) NULL,
			[VCentro] [decimal](10, 4) NULL,
			[ECentro] [decimal](10, 4) NULL,
			[VCostaRica] [decimal](10, 4) NULL,
			[ECostaRica] [decimal](10, 4) NULL,
			[VEstocolmo] [decimal](10, 4) NULL,
			[EEstocolmo] [decimal](10, 4) NULL,
			[VFCoVilla] [decimal](10, 4) NULL,
			[EFcoVilla] [decimal](10, 4) NULL,
			[VLombardia] [decimal](10, 4) NULL,
			[ELombardia] [decimal](10, 4) NULL,
			[VReyes] [decimal](10, 4) NULL,
			[EReyes] [decimal](10, 4) NULL,
			[VMorelos] [decimal](10, 4) NULL,
			[EMorelos] [decimal](10, 4) NULL,
			[VNvaItalia] [decimal](10, 4) NULL,
			[ENvaItalia] [decimal](10, 4) NULL,
			[VPaseo] [decimal](10, 4) NULL,
			[EPaseo] [decimal](10, 4) NULL,
			[VSarabiaI] [decimal](10, 4) NULL,
			[ESarabiaI] [decimal](10, 4) NULL,
			[VSarabiaII] [decimal](10, 4) NULL,
			[ESarabiaII] [decimal](10, 4) NULL,
			[Total] [decimal](10, 4) NULL,
			[PSugerido] [decimal](10, 4) NULL,
			[Pedido] [decimal](10, 4) NULL,
		 CONSTRAINT [PK_Pre_Pedidos] PRIMARY KEY CLUSTERED 
		(
			[ArticuloCodigo] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	

end


GO

SET ANSI_PADDING OFF
GO