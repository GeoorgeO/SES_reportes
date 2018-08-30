IF OBJECT_ID('Medidas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Medidas](
			[MedidasId] [decimal](11, 0) NOT NULL,
			[MedidasNombre] [char](60) NOT NULL,
			[MedidasAlias] [char](60) NOT NULL,
			[FechaInsert] [datetime] NULL,
			[FechaUpdate] [datetime] NULL,
		PRIMARY KEY CLUSTERED 
		(
			[MedidasId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end