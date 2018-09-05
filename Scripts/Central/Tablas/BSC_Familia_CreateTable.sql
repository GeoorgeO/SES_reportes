IF OBJECT_ID('Familia') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Familia](
			[FamiliaId] [decimal](11, 0)  NOT NULL,
			[FamiliaNombre] [char](60) NOT NULL,
			[FamiliaFecha] [datetime] NOT NULL,
			[FamiliaTipo] [char](1) NOT NULL,
			[FamiliaActivo] [char](1) NOT NULL,
			[FamiliaPadreId] [decimal](11, 0) NULL,
			[IvaId] [decimal](11, 0) NOT NULL,
			[Espadre] [bit] NULL,
			[TieneArticulos] [bit] NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Familia__42DFCCC4B145C40E] PRIMARY KEY CLUSTERED 
		(
			[FamiliaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end