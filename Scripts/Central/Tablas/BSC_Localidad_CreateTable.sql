IF OBJECT_ID('Localidad') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Localidad](
			[LocalidadId] [decimal](11, 0)  NOT NULL,
			[LocalidadNombre] [char](60) NOT NULL,
			[LocalidadCP] [char](5) NOT NULL,
			[MunicipioId] [decimal](11, 0) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Localida__6E2890A2FE57D04A] PRIMARY KEY CLUSTERED 
		(
			[LocalidadId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end