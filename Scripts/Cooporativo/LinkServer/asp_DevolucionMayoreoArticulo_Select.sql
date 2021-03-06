USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_DevolucionMayoreoArticulo_Select]    Script Date: 18/02/2019 05:01:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_DevolucionMayoreoArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dmArt.DevolucionId, dmArt.CajaId, dmArt.DevolucionArticuloUltimoIde, dmArt.ArticuloCodigo, 
                         dmArt.DevolucionArticuloPrecio, dmArt.DevolucionArticuloCantidad, dmArt.DevolucionArticuloSubtotal, dmArt.DevolucionArticuloIva, 
                         dmArt.DevolucionArticuloTotalLinea
	FROM            DevolucionMayoreoArticulo as dmArt INNER JOIN
                         DevolucionMayoreo as dm ON dmArt.DevolucionId = dm.DevolucionId AND dmArt.CajaId = dm.CajaId
	where dm.DevolucionFecha between @FechaInicio and @FechaFin
	and rtrim(dmArt.DevolucionId)+rtrim(dmArt.CajaId)+rtrim(dmArt.DevolucionArticuloUltimoIde) not in (
	SELECT rtrim(dmArtS.DevolucionId)+rtrim(dmArtS.CajaId)+rtrim(dmArtS.DevolucionArticuloUltimoIde)
	FROM  [SERVER-SON].[Server_Apatzingan].[dbo].[DevolucionMayoreoArticulo]    as dmArtS INNER JOIN
          [SERVER-SON].[Server_Apatzingan].[dbo].[DevolucionMayoreo]       as dmS ON dmArtS.DevolucionId = dmS.DevolucionId AND dmArtS.CajaId = dmS.CajaId
	where dmS.DevolucionFecha between @FechaInicio and @FechaFin and dmArtS.CajaId=dmArt.CajaId and dmArt.DevolucionArticuloUltimoIde=dmArtS.DevolucionArticuloUltimoIde)

END
