-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_VentaAcumulada_Insert')
DROP PROCEDURE SP_BSC_VentaAcumulada_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_VentaAcumulada_Insert
	-- Add the parameters for the stored procedure here
	@Tventa_Actual numeric(18,2),
	@NTickets_Actual numeric(18,2),
	@Pventa_Actual numeric(18,2),
	@PArticulosXticket_Actual numeric(18,2),
	@Tventa_Anterior numeric(18,2),
	@NTickets_Anterior numeric(18,2),
	@Pventa_Anterior numeric(18,2),
	@PArticulosXticket_Anterior numeric(18,2),
	@Porcentaje numeric(18,2),
	@Fecha_Actual datetime,
	@Fecha_Anterior datetime,
	@Sucursal varchar(50),
	@Fechaahora datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into RPT_VentaAcumulada ([Tventa_Actual] ,
			[NTickets_Actual] ,
			[Pventa_Actual],
			[PArticulosXticket_Actual],
			[Tventa_Anterior],
			[NTickets_Anterior] ,
			[Pventa_Anterior],
			[PArticulosXticket_Anterior],
			[Porcentaje],
			[Fecha_Actual],
			[Fecha_Anterior],
			[Sucursal],
			[FechaInsert])  
	values
	(@Tventa_Actual,
	@NTickets_Actual,
	@Pventa_Actual,
	@PArticulosXticket_Actual,
	@Tventa_Anterior,
	@NTickets_Anterior,
	@Pventa_Anterior,
	@PArticulosXticket_Anterior,
	@Porcentaje,
	@Fecha_Actual,
	@Fecha_Anterior,
	@Sucursal,
	@Fechaahora)
END
GO
