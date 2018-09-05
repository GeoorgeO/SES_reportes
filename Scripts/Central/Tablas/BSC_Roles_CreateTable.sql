IF OBJECT_ID('Roles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Roles](
			[RolesId] [decimal](11, 0)  NOT NULL,
			[RolesNombre] [char](60) NOT NULL,
			[RolesActivo] [char](1) NOT NULL,
			[RolesFecha] [datetime] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Roles__C4B27840CC38E4DE] PRIMARY KEY CLUSTERED 
		(
			[RolesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end