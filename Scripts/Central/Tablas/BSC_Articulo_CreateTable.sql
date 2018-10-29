USE [Central]
GO
IF OBJECT_ID('Articulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Articulo](
		[ArticuloCodigo] [char](40) NOT NULL,
		[ArticuloDescripcion] [char](200) NOT NULL,
		[ArticuloCostoReposicion] [decimal](10,4) null,
		[FamiliaId]	[decimal](11, 0) null,
		[FechaInsert] [datetime] NOT NULL,
		[FechaUpdate] [datetime] NULL,
		CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
	(
		[ArticuloCodigo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end