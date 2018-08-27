IF OBJECT_ID('Vendedor') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Vendedor](
			[VendedorId] [decimal](11, 0) NOT NULL,
			[VendedorNombre] [char](60) NOT NULL,
			[VendedorApellidos] [char](100) NOT NULL,
			[VendedorActivo] [char](1) NOT NULL,
			[VendedorNombreCompleto] [nvarchar](160) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
		(
			[VendedorId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end