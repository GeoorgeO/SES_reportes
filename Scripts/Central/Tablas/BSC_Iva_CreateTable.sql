IF OBJECT_ID('Iva') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		
		CREATE TABLE [dbo].[Iva](
			[IvaId] [decimal](11, 0)  NOT NULL,
			[IvaNombre] [char](60) NOT NULL,
			[IvaFactor] [smallmoney] NOT NULL,
			[IvaPorcentaje] [smallint] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Iva__B75F993C9F738059] PRIMARY KEY CLUSTERED 
		(
			[IvaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end