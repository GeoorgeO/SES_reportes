IF OBJECT_ID('CProveedor') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CProveedor](
			[CProveedorId] [decimal](11, 0)  NOT NULL,
			[CProveedorNombre] [char](60) NOT NULL,
			[CProveedorFecha] [datetime] NOT NULL,
			[CProveedorActivo] [char](1) NOT NULL,
			[CProveedorPadreId] [decimal](11, 0) NULL,
			[CProveedorTieneElementos] [bit] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__CProveed__0B3436F600F43191] PRIMARY KEY CLUSTERED 
		(
			[CProveedorId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end