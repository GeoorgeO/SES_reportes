IF OBJECT_ID('SalidaMercancia') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[SalidaMercancia](
			[SalidaMercanciaId] [bigint] NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[UsuariosId] [decimal](11, 0) NULL,
			[SalidaMercanciaTipoId] [bigint] NULL,
			[SalidaMercanciaFecha] [date] NULL,
			[SalidaMercanciaUnidades] [bigint] NULL,
			[SalidaMercanciaSub0] [decimal](18, 2) NULL,
			[SalidaMercanciaSub16] [decimal](18, 2) NULL,
			[SalidaMercanciaIva] [decimal](18, 2) NULL,
			[SalidaMercanciaTotal] [decimal](18, 2) NULL,
			[Observaciones] [nvarchar](max) NULL,
			[Referencias] [nvarchar](max) NULL,
			[ParaSucursal] [char](60) NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_SalidaMercancia] PRIMARY KEY CLUSTERED 
		(
			[SalidaMercanciaId] ASC,
			[SucursalesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		

	end