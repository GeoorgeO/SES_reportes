IF OBJECT_ID('DevolucionPreDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[DevolucionPreDetalles](
			[DevolucionPreId] [bigint] NOT NULL,
			[ArticuloCodigo] [char](40) NOT NULL,
			[DevolucionPreCantidad] [bigint] NOT NULL,
			[DevolucionPrePUnitarioSimp] [money] NOT NULL,
			[DevolucionPrePUnitarioCImp] [money] NOT NULL,
			[DevolucionPreTLinea] [money] NOT NULL,
			[FechaInsert] [datetime] NULL
		) ON [PRIMARY]
		

	end