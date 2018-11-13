USE [SES_Reportes]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 13/11/2018 01:10:31 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF OBJECT_ID('Usuarios') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin

CREATE TABLE [dbo].[Usuarios](
	[UsuariosNombre] [varchar](60) NULL,
	[UsuariosRegistroFecha] [datetime] NOT NULL,
	[UsuariosLogin] [varchar](60) NOT NULL,
	[UsuariosPassword] [varchar](50) NOT NULL,
	[UsuariosActivo] [bit] NOT NULL,
	[Usuariosclase] [char](1) NOT NULL,
	[UsuariosFechaUpdate] [datetime] NULL,
 CONSTRAINT [PK_ctr_usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuariosLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

end

GO

SET ANSI_PADDING OFF
GO


