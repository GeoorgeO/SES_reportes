USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_SalidaMercanciaArticulo_Select]    Script Date: 18/02/2019 05:04:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_SalidaMercanciaArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select SalMerArt.SalidaMercanciaId
      ,SalMerArt.SucursalesId
      ,SalMerArt.SalidaMercanciaArticuloUltimoIde
      ,SalMerArt.ArticuloCodigo
      ,SalMerArt.SalidaMercanciaArticuloCantidad
      ,SalMerArt.SalidaMercanciaArticuloSub0
      ,SalMerArt.SalidaMercanciaArticuloSub16
      ,SalMerArt.SalidaMercanciaArticuloIva
      ,SalMerArt.SalidaMercanciaArticuloTotal
	from SalidaMercanciaArticulo as SalMerArt
	inner join SalidaMercancia as SalMer
		on SalMerArt.SalidaMercanciaId=SalMer.SalidaMercanciaId
			and SalMerArt.SucursalesId=SalMer.SucursalesId
	where SalMer.SalidaMercanciaFecha between @FechaInicio and @FechaFin
	and rtrim(SalMerArt.SalidaMercanciaId)+rtrim(SalMerArt.SucursalesId)+rtrim(SalMerArt.SalidaMercanciaArticuloUltimoIde) not in (
	select rtrim(SalMerArtS.SalidaMercanciaId)+rtrim(SalMerArtS.SucursalesId)+rtrim(SalMerArtS.SalidaMercanciaArticuloUltimoIde)
     
	from [SERVER-SON].[Server_Apatzingan].[dbo].SalidaMercanciaArticulo as SalMerArtS
	inner join [SERVER-SON].[Server_Apatzingan].[dbo].SalidaMercancia as SalMerS
		on SalMerArtS.SalidaMercanciaId=SalMerS.SalidaMercanciaId
			and SalMerArtS.SucursalesId=SalMerS.SucursalesId
	where SalMerS.SalidaMercanciaFecha between @FechaInicio and @FechaFin
	and SalMerArt.SucursalesId=SalMerArtS.SucursalesId
	and SalMerArt.SalidaMercanciaArticuloUltimoIde=SalMerArtS.SalidaMercanciaArticuloUltimoIde
	)
END
