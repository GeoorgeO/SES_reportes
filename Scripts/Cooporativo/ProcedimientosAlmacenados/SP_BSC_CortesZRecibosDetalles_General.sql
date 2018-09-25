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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZRecibosDetalles_General')
DROP PROCEDURE SP_BSC_CortesZRecibosDetalles_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZRecibosDetalles_General
	-- Add the parameters for the stored procedure here
	@CortesZRecibosId bigint ,
	@CortesZRecibosInicio bigint ,
	@CortesZRecibosFin bigint ,
	@CortesZNCreditoInicio bigint ,
	@CortesZNCreditoFin bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CortesZRecibosId) from CortesZRecibosDetalles a where (a.CortesZRecibosId=@CortesZRecibosId )
	if @Existe>0
			select 0;
		else
			INSERT INTO CortesZRecibosDetalles
                         (CortesZRecibosId, CortesZRecibosInicio, CortesZRecibosFin, CortesZNCreditoInicio, CortesZNCreditoFin, FechaInsert)
			VALUES        (@CortesZRecibosId,@CortesZRecibosInicio,@CortesZRecibosFin,@CortesZNCreditoInicio,@CortesZNCreditoFin, GETDATE())
END
GO
