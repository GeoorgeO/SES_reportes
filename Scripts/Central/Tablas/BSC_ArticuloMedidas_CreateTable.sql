IF OBJECT_ID('ArticuloMedidas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[ArticuloMedidas](
		[ArticuloCodigo] [char](40) NOT NULL,
		[MedidasId] [decimal](11, 0) NOT NULL,
		[FechaUltimaActualizacion] [datetime] NULL,
		[FechaInsert] [datetime] NOT NULL,
	 CONSTRAINT [PK_ArticuloMedidas] PRIMARY KEY CLUSTERED 
	(
		[ArticuloCodigo] ASC,
		[MedidasId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end