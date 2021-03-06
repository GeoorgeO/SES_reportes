USE [SES_LombardiaV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_EntradaMercanciaArticulo_Select]    Script Date: 18/02/2019 02:09:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_EntradaMercanciaArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EntMerArt.EntradasMercanciaId
      ,EntMerArt.SucursalesId
      ,EntMerArt.EntradasMercanciaArticuloUltimoIde
      ,EntMerArt.ArticuloCodigo
      ,EntMerArt.EntradasMercanciaArticuloCantidad
      ,EntMerArt.EntradasMercanciaArticuloSub0
      ,EntMerArt.EntradasMercanciaArticuloSub16
      ,EntMerArt.EntradasMercanciaArticuloIva
      ,EntMerArt.EntradasMercanciaArticuloTotal
	from EntradaMercanciaArticulo as EntMerArt
	inner join EntradaMercancia as EntMer
		on EntMerArt.EntradasMercanciaId=EntMer.EntradaMercanciaId
			and EntMerArt.SucursalesId=EntMer.SucursalesId
	where EntMer.EntradaMercanciaFecha between @FechaInicio and @FechaFin
	and rtrim(EntMerArt.EntradasMercanciaId)+Rtrim(EntMerArt.SucursalesId)+rtrim(EntMerArt.EntradasMercanciaArticuloUltimoIde) not in (
	SELECT rtrim(EntMerArtS.EntradasMercanciaId)+Rtrim(EntMerArtS.SucursalesId)+rtrim(EntMerArtS.EntradasMercanciaArticuloUltimoIde)
	from [SERVER-SON].[Server_Lombardia].[dbo].EntradaMercanciaArticulo as EntMerArtS
	inner join [SERVER-SON].[Server_Lombardia].[dbo].EntradaMercancia as EntMerS
		on EntMerArtS.EntradasMercanciaId=EntMerS.EntradaMercanciaId
			and EntMerArtS.SucursalesId=EntMerS.SucursalesId
	where EntMerS.EntradaMercanciaFecha between @FechaInicio and @FechaFin and EntMerArt.SucursalesId=EntMerArtS.SucursalesId and EntMerArt.EntradasMercanciaArticuloUltimoIde=EntMerArtS.EntradasMercanciaArticuloUltimoIde)
	
	
END
