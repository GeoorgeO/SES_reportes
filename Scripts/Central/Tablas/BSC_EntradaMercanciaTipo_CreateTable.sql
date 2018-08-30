IF OBJECT_ID('EntradaMercanciaTipo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
			
		CREATE TABLE [dbo].[EntradaMercanciaTipo](
			[EntradaMercanciaTipoId] [bigint] NOT NULL,
			[EntradaMercanciaTipoDescripcion] [varchar](50) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_EntradaMercanciaTipo] PRIMARY KEY CLUSTERED 
		(
			[EntradaMercanciaTipoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end