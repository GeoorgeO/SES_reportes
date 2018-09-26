IF OBJECT_ID('CortesZ') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CortesZ](
			[CortesZId] [bigint] NOT NULL,
			[CajaId] [decimal](11, 0) NOT NULL,
			[CortesZFecha] [datetime] NOT NULL,
			[UsuariosId] [decimal](11, 0) NOT NULL,
			[CortesZSub0] [money] NOT NULL,
			[CortesZSub16] [money] NOT NULL,
			[CortesZIva] [money] NOT NULL,
			[CortesZTotal] [money] NOT NULL,
			[FechaInsert] [datetime] NULL,
		 CONSTRAINT [PK_CortesZ] PRIMARY KEY CLUSTERED 
		(
			[CortesZId] ASC,
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end
