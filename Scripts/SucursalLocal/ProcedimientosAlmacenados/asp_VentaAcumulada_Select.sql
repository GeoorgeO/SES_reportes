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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_VentaAcumulada_Select')
DROP PROCEDURE asp_VentaAcumulada_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_VentaAcumulada_Select 
	@IdFolio int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  IdFolio, isnull(Tventa_Actual,0)as Tventa_Actual,
			isnull(NTickets_Actual,0)as NTickets_Actual,isnull(Pventa_Actual,0)as Pventa_Actual,
			isnull(PArticulosXticket_Actual,0) as PArticulosXticket_Actual, 
			isnull(Tventa_Anterior,0)as Tventa_Anterior, isnull(NTickets_Anterior,0) as NTickets_Anterior,
			isnull(Pventa_Anterior,0)as Pventa_Anterior, isnull(PArticulosXticket_Anterior,0)as PArticulosXticket_Anterior,
			isnull(Porcentaje,0)as Porcentaje, Fecha_Actual,
			Fecha_Anterior, rtrim(Sucursal)as Sucursal, FechaInsert
	FROM    RPT_VentaAcumulada
	WHERE   (IdFolio = @IdFolio)
END
GO
