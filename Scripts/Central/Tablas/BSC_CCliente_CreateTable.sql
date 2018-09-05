IF OBJECT_ID('CCliente') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		
		CREATE TABLE [dbo].[CCliente](
			[CClienteId] [decimal](11, 0)  NOT NULL,
			[CClienteNombre] [char](60) NOT NULL,
			[CClienteFecha] [datetime] NOT NULL,
			[CClienteActivo] [char](1) NOT NULL,
			[CClientePadreId] [decimal](11, 0) NULL,
			[CClienteTieneElementos] [bit] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__CCliente__FBF9032228C9F4F9] PRIMARY KEY CLUSTERED 
		(
			[CClienteId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


	end