USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_EntradaMercancia_Select]    Script Date: 18/02/2019 12:25:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_EntradaMercancia_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select EM.EntradaMercanciaId
      ,EM.SucursalesId
      ,EM.UsuariosId
      ,EM.EntradaMercanciaTipoId
      ,EM.EntradaMercanciaFecha
      ,EM.EntradaMercanciaUnidades
      ,EM.EntradaMercanciaSub0
      ,EM.EntradaMercanciaSub16
      ,EM.EntradaMercanciaIva
      ,EM.EntradaMercanciaTotal
      ,EM.Observaciones
      ,EM.Referencias
	from EntradaMercancia as EM
	where EM.EntradaMercanciaFecha between @FechaInicio and @FechaFin
	and EM.EntradaMercanciaId not in (
	select EMS.EntradaMercanciaId
	from [SERVER-SON].[Server_Apatzingan].[dbo].[EntradaMercancia]  as EMS
	where EMS.EntradaMercanciaFecha between @FechaInicio and @FechaFin and EMS.SucursalesId=EM.SucursalesId)


END