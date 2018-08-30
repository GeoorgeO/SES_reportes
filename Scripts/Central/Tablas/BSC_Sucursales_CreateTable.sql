IF OBJECT_ID('Sucursales') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Sucursales](
			[SucursalesId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[SucursalesNombre] [char](60) NOT NULL,
			[SucursalesFecha] [datetime] NOT NULL,
			[SucursalesActivo] [char](1) NOT NULL,
			[SucursalesCalle] [char](100) NOT NULL,
			[SucursalesNInterior] [char](40) NOT NULL,
			[SucursalesnNExterior] [char](40) NULL,
			[SucursalesColonia] [char](100) NOT NULL,
			[LocalidadId] [decimal](11, 0) NOT NULL,
			[SucursalesCiudad] [char](100) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Sucursal__5163C7016398CAD2] PRIMARY KEY CLUSTERED 
		(
			[SucursalesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end