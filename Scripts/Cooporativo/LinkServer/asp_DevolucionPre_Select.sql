USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_DevolucionPre_Select]    Script Date: 18/02/2019 11:05:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_DevolucionPre_Select] 
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        Dp.DevolucionPreId, Dp.TicketId, Dp.CajaId, Dp.DevolucionPreFecha,Dp.DevolucionPreTArticulos, Dp.UsuarioId, Dp.VendedorId, Dp.DevolucionPreSub0, Dp.DevolucionPreSub16, Dp.DevolucionPreIva, Dp.DevolucionPreTotal, Dp.DevolucionPreProcesada
	FROM            DevolucionPre as Dp
	WHERE        (Dp.DevolucionPreFecha BETWEEN @FechaInicio AND @FechaFin)
	and Dp.DevolucionPreId not in (
	SELECT        DpS.DevolucionPreId
	FROM          [SERVER-SON].[Server_Apatzingan].[dbo].[DevolucionPre] as DpS
	WHERE        (DpS.DevolucionPreFecha BETWEEN @FechaInicio AND @FechaFin and DpS.CajaId=Dp.CajaId))
END
