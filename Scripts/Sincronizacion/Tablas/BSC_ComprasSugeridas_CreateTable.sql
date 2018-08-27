IF OBJECT_ID('ComprasSugeridas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[ComprasSugeridas](
			[Codigo] [char](40) NULL,
			[Descripcion] [char](200) NULL,
			[Centro] [int] NULL,
			[Morelos] [int] NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL
		) ON [PRIMARY]

	end