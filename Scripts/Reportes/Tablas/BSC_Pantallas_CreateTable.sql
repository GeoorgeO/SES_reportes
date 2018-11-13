USE [SES_Reportes]
GO

/****** Object:  Table [dbo].[Pantallas]    Script Date: 13/11/2018 01:12:21 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF OBJECT_ID('Pantallas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin

CREATE TABLE [dbo].[Pantallas](
	[pantallasId] [int] NOT NULL,
	[pantallasnombre] [varchar](20) NOT NULL,
	[pantallaFechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_pantallas] PRIMARY KEY CLUSTERED 
(
	[pantallasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

end

GO

SET ANSI_PADDING OFF
GO


