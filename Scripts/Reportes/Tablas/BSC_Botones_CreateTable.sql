USE [SES_Reportes]
GO

/****** Object:  Table [dbo].[Botones]    Script Date: 13/11/2018 01:13:43 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF OBJECT_ID('Botones') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin

CREATE TABLE [dbo].[Botones](
	[botonesId] [int] NOT NULL,
	[botonesNombre] [varchar](20) NOT NULL,
	[pantallasId] [int] NOT NULL,
	[botonesFechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_botones] PRIMARY KEY CLUSTERED 
(
	[botonesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

end

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Botones]  WITH CHECK ADD  CONSTRAINT [FK_botones_pantallas] FOREIGN KEY([pantallasId])
REFERENCES [dbo].[Pantallas] ([pantallasId])
GO

ALTER TABLE [dbo].[Botones] CHECK CONSTRAINT [FK_botones_pantallas]
GO



