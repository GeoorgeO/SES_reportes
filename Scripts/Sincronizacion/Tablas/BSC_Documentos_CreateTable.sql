IF OBJECT_ID('Documentos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Documentos](
			[DocumentosId] [bigint] NOT NULL,
			[DocumentosNombre] [varchar](100) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
		(
			[DocumentosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end