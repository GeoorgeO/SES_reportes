IF OBJECT_ID('Proveedor') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Proveedor](
			[ProveedorId] [decimal](11, 0) NULL,
			[ProveedorNombre] [char](60) NULL,
			[ProveedorPaterno] [char](60) NULL,
			[ProveedorMaterno] [char](60) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL
		) ON [PRIMARY]

	end