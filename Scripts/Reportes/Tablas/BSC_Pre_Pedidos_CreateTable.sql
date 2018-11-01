USE [SES_Reportes]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
		GO

IF OBJECT_ID('Pre_Pedidos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin

	CREATE TABLE [dbo].[Pre_Pedidos](
		[PrePedidosId] [int] NULL,
		[ProveedorId] [int] NULL,
		[ProveedorNombre] [varchar](200) NULL,
		[FechaInicio] [datetime] NULL,
		[FechaFin] [datetime] NULL
	) ON [PRIMARY]

end


GO

SET ANSI_PADDING OFF
GO

