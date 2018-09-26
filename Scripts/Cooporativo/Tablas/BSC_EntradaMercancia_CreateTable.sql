IF OBJECT_ID('EntradaMercancia') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[EntradaMercancia](
			[EntradaMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NULL,
			[EntradaMercanciaTipoId] [bigint] NULL,
			[EntradaMercanciaFecha] [date] NULL,
			[EntradaMercanciaUnidades] [bigint] NULL,
			[EntradaMercanciaSub0] [decimal](18, 2) NULL,
			[EntradaMercanciaSub16] [decimal](18, 2) NULL,
			[EntradaMercanciaIva] [decimal](18, 2) NULL,
			[EntradaMercanciaTotal] [decimal](18, 2) NULL,
			[Observaciones] [nvarchar](max) NULL,
			[Referencias] [nvarchar](max) NULL,
			[FechaInsert] [datetime] NOT NULL,
		 CONSTRAINT [PK_EntradaMercancia] PRIMARY KEY CLUSTERED 
		(
			[EntradaMercanciaId] ASC,
			[SucursalesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		

	end
