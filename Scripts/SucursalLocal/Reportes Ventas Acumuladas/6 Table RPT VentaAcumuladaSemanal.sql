
GO

/****** Object:  Table [dbo].[RPT_VentaAcumuladaSemanal]    Script Date: 27/01/2019 09:47:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RPT_VentaAcumuladaSemanal](
	[IdFolio] [int] NULL,
	[Sucursal] [varchar](100) NULL,
	[NumeroFila] [int] NULL,
	[NombreFila] [varchar](100) NULL,
	[Lunes] [money] NULL,
	[Martes] [money] NULL,
	[Miercoles] [money] NULL,
	[Jueves] [money] NULL,
	[Viernes] [money] NULL,
	[Sabado] [money] NULL,
	[Domingo] [money] NULL,
	[Total] [money] NULL,
	[FechaSemana] [varchar](100) NULL,
	[FechaInsert] [datetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


