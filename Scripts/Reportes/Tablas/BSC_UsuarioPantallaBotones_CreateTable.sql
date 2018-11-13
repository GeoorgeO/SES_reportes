USE [SES_Reportes]
GO

/****** Object:  Table [dbo].[UsuarioPantallaBotones]    Script Date: 13/11/2018 01:15:28 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF OBJECT_ID('UsuarioPantallaBotones') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin

CREATE TABLE [dbo].[UsuarioPantallaBotones](
	[UsuariosLogin] [varchar](60) NULL,
	[pantallasId] [int] NULL,
	[botonesId] [int] NULL
) ON [PRIMARY]

end

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UsuarioPantallaBotones]  WITH CHECK ADD  CONSTRAINT [FK_usuarioPantallaBotones_botones] FOREIGN KEY([botonesId])
REFERENCES [dbo].[Botones] ([botonesId])
GO

ALTER TABLE [dbo].[UsuarioPantallaBotones] CHECK CONSTRAINT [FK_usuarioPantallaBotones_botones]
GO

ALTER TABLE [dbo].[UsuarioPantallaBotones]  WITH CHECK ADD  CONSTRAINT [FK_usuarioPantallaBotones_pantallas] FOREIGN KEY([pantallasId])
REFERENCES [dbo].[Pantallas] ([pantallasId])
GO

ALTER TABLE [dbo].[UsuarioPantallaBotones] CHECK CONSTRAINT [FK_usuarioPantallaBotones_pantallas]
GO

ALTER TABLE [dbo].[UsuarioPantallaBotones]  WITH CHECK ADD  CONSTRAINT [FK_usuarioPantallaBotones_usuarios] FOREIGN KEY([UsuariosLogin])
REFERENCES [dbo].[Usuarios] ([UsuariosLogin])
GO

ALTER TABLE [dbo].[UsuarioPantallaBotones] CHECK CONSTRAINT [FK_usuarioPantallaBotones_usuarios]
GO


