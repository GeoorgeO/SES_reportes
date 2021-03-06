USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_DevolucionPreDetalles_Select]    Script Date: 18/02/2019 05:10:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_DevolucionPreDetalles_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        DPdet.DevolucionPreId, DPdet.ArticuloCodigo, DPdet.DevolucionPreCantidad, DPdet.DevolucionPrePUnitarioSimp, DPdet.DevolucionPrePUnitarioCImp, DPdet.DevolucionPreTLinea
	FROM            DevolucionPreDetalles as DPdet
	left join DevolucionPre as DP on DP.DevolucionPreId=DPdet.DevolucionPreId
	where DP.DevolucionPreFecha between @FechaInicio and @FechaFin
	and rtrim(DPdet.DevolucionPreId)+rtrim(DPdet.ArticuloCodigo) not in (
	SELECT rtrim(DPdetS.DevolucionPreId)+rtrim(DPdetS.ArticuloCodigo)
	FROM [SERVER-SON].[Server_Apatzingan].[dbo].[DevolucionPreDetalles] as DPdetS
	left join [SERVER-SON].[Server_Apatzingan].[dbo].[DevolucionPre] as DPS on DPS.DevolucionPreId=DPdetS.DevolucionPreId
	where DPS.DevolucionPreFecha between @FechaInicio and @FechaFin)
END
