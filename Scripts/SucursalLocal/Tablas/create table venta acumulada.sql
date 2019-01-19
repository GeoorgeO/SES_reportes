GO

/****** Object:  Table [dbo].[SES_rpt_ventaacumulada]    Script Date: 17/01/2019 04:58:28 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RPT_VentaAcumulada](
	[IdFolio] [int] NOT NULL,
	[Tventa_Actual] [numeric](18, 2) NULL,
	[NTickets_Actual] [numeric](18, 2) NULL,
	[Pventa_Actual] [numeric](18, 2) NULL,
	[PArticulosXticket_Actual] [numeric](18, 2) NULL,
	[Tventa_Anterior] [numeric](18, 2) NULL,
	[NTickets_Anterior] [numeric](18, 2) NULL,
	[Pventa_Anterior] [numeric](18, 2) NULL,
	[PArticulosXticket_Anterior] [numeric](18, 2) NULL,
	[Porcentaje] [numeric](18, 2) NULL,
	[Fecha_Actual] [datetime] NULL,
	[Fecha_Anterior] [datetime] NULL,
	[Sucursal] [varchar](50) NULL,
	[FechaInsert] [datetime] NULL,
 CONSTRAINT [PK_RPT_VentaAcumulada] PRIMARY KEY CLUSTERED 
(
	[IdFolio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

SET ANSI_PADDING OFF
GO


