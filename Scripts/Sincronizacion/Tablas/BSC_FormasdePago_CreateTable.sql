IF OBJECT_ID('FormasdePago') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[FormasdePago](
			[FormasdePagoId] [bigint] NOT NULL,
			[FormasdePagoDescripcion] [varchar](50) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Formasde__408B09EC0E426C69] PRIMARY KEY CLUSTERED 
		(
			[FormasdePagoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end