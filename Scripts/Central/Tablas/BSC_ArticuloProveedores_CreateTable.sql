IF OBJECT_ID('ArticuloProveedores') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		/****** Object:  Table [dbo].[ArticuloProveedores]    Script Date: 08/10/2018 06:14:04 p. m. ******/
		CREATE TABLE [dbo].[ArticuloProveedores](
			[ArticuloCodigo] [char](40) NOT NULL,
			[ArticuloProveedoresIde] [decimal](11, 0) NOT NULL,
			[ProveedorId] [decimal](11, 0) NOT NULL,
			[ArticuloProveedoresFechaUdp] [datetime] NULL,
			[FechaInsert] [datetime] null,
			[FechaUpdate] [datetime] null
		PRIMARY KEY CLUSTERED 
		(
			[ArticuloCodigo] ASC,
			[ArticuloProveedoresIde] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
end 




