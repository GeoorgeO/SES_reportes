IF OBJECT_ID('Usuarios') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Usuarios](
			[UsuariosId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[UsuariosNombre] [char](60) NOT NULL,
			[UsuariosRegistroFecha] [datetime] NOT NULL,
			[UsuariosLogin] [char](60) NOT NULL,
			[UsuariosPassword] [char](60) NOT NULL,
			[UsuariosActivo] [char](1) NOT NULL,
			[RolesId] [decimal](11, 0) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Usuarios__48BE79C911BF94B6] PRIMARY KEY CLUSTERED 
		(
			[UsuariosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end