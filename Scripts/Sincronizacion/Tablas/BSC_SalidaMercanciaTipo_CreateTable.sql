IF OBJECT_ID('SalidaMercanciaTipo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[SalidaMercanciaTipo](
			[SalidaMercanciaTipoId] [bigint] IDENTITY(1,1) NOT NULL,
			[SalidaMercanciaTipoDescripcion] [varchar](50) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_SalidaMercanciaTipo] PRIMARY KEY CLUSTERED 
		(
			[SalidaMercanciaTipoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end