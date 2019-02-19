GO
/****** Object:  StoredProcedure [dbo].[asp_CancelacionArticulo_Select]    Script Date: 18/02/2019 04:57:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CancelacionArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CanArt.CancelacionId
      ,CanArt.CajaId
      ,CanArt.CancelacionArticuloUltimoIde
      ,CanArt.TicketId
      ,CanArt.ArticuloCodigo
      ,CanArt.CancelacionArticuloPrecio
      ,CanArt.CancelacionArticuloCantidad
      ,CanArt.CancelacionArticuloSubtotal
      ,CanArt.CancelacionArticuloIva
      ,CanArt.CancelacionArticuloTotalLinea
	from CancelacionArticulo as CanArt
	inner join Cancelacion as Can
		on CanArt.CancelacionId=Can.CancelacionId
			and CanArt.CajaId=Can.CajaId
	where Can.CancelacionFecha between @FechaInicio and @FechaFin
	and rtrim(CanArt.CancelacionId)+rtrim(CanArt.CajaId)+rtrim(CanArt.CancelacionArticuloUltimoIde) not in(SELECT rtrim(CanArtS.CancelacionId)+rtrim(CanArtS.CajaId)+rtrim(CanArtS.CancelacionArticuloUltimoIde) FROM [SERVER-SON].[Server_Lombardia].[dbo].[CancelacionArticulo] as CanArtS
	inner join [SERVER-SON].[Server_Lombardia].[dbo].[Cancelacion] as CanS
		on CanArtS.CancelacionId=CanS.CancelacionId
			and CanArtS.CajaId=CanS.CajaId
    where CanS.CancelacionFecha between @FechaInicio and @FechaFin and CanS.CajaId=CanArt.CajaId and CanArt.CancelacionArticuloUltimoIde=CanArtS.CancelacionArticuloUltimoIde)
END



GO
/****** Object:  StoredProcedure [dbo].[asp_Cancelacion_Select]    Script Date: 18/02/2019 09:11:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_Cancelacion_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
    
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CancelacionId, 
		CajaId, 
		TicketId, 
		UsuarioId, 
		CancelacionFecha, 
		CancelacionSubtotal0, 
		CancelacionSubtotal16, 
		CancelacionIva, 
		CancelacionTotal, 
		CancelacionAsignadoCorte, 
		CorteZId, 
		CancelacionesTotal, 
		TicketMayoreoId
	FROM Cancelacion as can
	where CancelacionFecha between @FechaInicio and @FechaFin
	and CancelacionId not in(SELECT CancelacionId FROM [SERVER-SON].[Server_Lombardia].[dbo].[Cancelacion]
    where CancelacionFecha between @FechaInicio and @FechaFin and CajaId=can.CajaId)

END


GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZRecargasTickets_Select]    Script Date: 18/02/2019 09:52:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZRecargasTickets_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        CRdet.CortesZRecargasId, CRdet.CajaId, CRdet.CortesZRecargasTicketsInicio, CRdet.CortesZRecargasTicketsFin
	FROM            CortesZRecargasTickets as CRdet
	left join CortesZRecargas as CR on CR.CajaId=CRdet.CajaId and CR.CortesZRecargasId=CRdet.CortesZRecargasId
	where CR.CortesZRecargasFecha between @FechaInicio and @FechaFin
	and CRdet.CortesZRecargasId not in (
	SELECT CRdetS.CortesZRecargasId
	FROM [SERVER-SON].[Server_Lombardia].[dbo].[CortesZRecargasTickets] as CRdetS
	left join [SERVER-SON].[Server_Lombardia].[dbo].[CortesZRecargas] as CRS on CRS.CajaId=CRdetS.CajaId and CRS.CortesZRecargasId=CRdetS.CortesZRecargasId
	where CRS.CortesZRecargasFecha between @FechaInicio and @FechaFin and CRS.CajaId=CRdet.CajaId)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZRecargas_Select]    Script Date: 18/02/2019 09:22:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZRecargas_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        CortesZRecargasId, CajaId,CortesZRecargasFecha, UsuariosId, CortesZRecargasSub0, CortesZRecargasSub16, CortesZRecargasIva, CortesZRecargasTotal, FacturaGlobalFolio, CortesZRecargasFacturado, 
							 CortesZRecargasTotalCosto
	FROM            CortesZRecargas as czr
	WHERE        (CortesZRecargasFecha BETWEEN @FechaInicio AND @FechaFin)
	and czr.CortesZRecargasId not in(SELECT czrS.CortesZRecargasId FROM [SERVER-SON].[Server_Lombardia].[dbo].[CortesZRecargas] as czrS
    where czrS.CortesZRecargasFecha between @FechaInicio and @FechaFin and czrS.CajaId=czr.CajaId)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZRecibosDetalles_Select]    Script Date: 18/02/2019 10:34:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZRecibosDetalles_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        CRdet.CortesZRecibosId, CRdet.CortesZRecibosInicio, CRdet.CortesZRecibosFin, CRdet.CortesZNCreditoInicio, CRdet.CortesZNCreditoFin
	FROM            CortesZRecibosDetalles as CRdet
	left join CortesZRecibos as CR on CR.CortesZRecibosId=CRdet.CortesZRecibosId
	where CR.CortesZRecibosFecha between @FechaInicio and @FechaFin
	and CRdet.CortesZRecibosId not in (
	SELECT        CRdetS.CortesZRecibosId
	FROM  [SERVER-SON].[Server_Lombardia].[dbo].[CortesZRecibosDetalles] as CRdetS
	left join [SERVER-SON].[Server_Lombardia].[dbo].[CortesZRecibos] as CRS on CRS.CortesZRecibosId=CRdetS.CortesZRecibosId
	where CRS.CortesZRecibosFecha between @FechaInicio and @FechaFin)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZRecibos_Select]    Script Date: 18/02/2019 10:30:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZRecibos_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        czr.CortesZRecibosId, czr.CortesZRecibosFecha, czr.UsuariosId, czr.CortesZRecibosTotal
	FROM            CortesZRecibos as czr
	WHERE        (czr.CortesZRecibosFecha BETWEEN @FechaInicio AND @FechaFin)
	and czr.CortesZRecibosId not in
	(SELECT czrS.CortesZRecibosId
	FROM          [SERVER-SON].[Server_Lombardia].[dbo].[CortesZRecibos] as czrS
	WHERE        (czrS.CortesZRecibosFecha BETWEEN @FechaInicio AND @FechaFin))
END


GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZ_Select]    Script Date: 18/02/2019 08:44:54 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZ_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select CortesZId
      ,CajaId
      ,CortesZFecha
      ,UsuariosId
      ,CortesZSub0
      ,CortesZSub16
      ,CortesZIva
      ,CortesZTotal
	from CortesZ as cz
	where CortesZFecha between @FechaInicio and @FechaFin 
	and CortesZId not in(SELECT czS.CortesZId FROM [SERVER-SON].[Server_Lombardia].[dbo].[CortesZ] as czS
    where czS.CortesZFecha between @FechaInicio and @FechaFin and czS.CajaId=cz.CajaId)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_DevolucionArticulo_Select]    Script Date: 18/02/2019 04:59:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_DevolucionArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DevArt.DevolucionId
      ,DevArt.CajaId
      ,DevArt.DevolucionArticuloUltimoIde
      ,DevArt.ArticuloCodigo
      ,DevArt.DevolucionArticuloPrecio
      ,DevArt.DevolucionArticuloCantidad
      ,DevArt.DevolucionArticuloSubtotal
      ,DevArt.DevolucionArticuloIva
      ,DevArt.DevolucionArticuloTotalLinea
	from DevolucionArticulo as DevArt
	inner join Devolucion as Dev
		on DevArt.DevolucionId=Dev.DevolucionId
			and DevArt.CajaId=Dev.CajaId
	where Dev.DevolucionFecha between @FechaInicio and @FechaFin
	and rtrim(DevArt.DevolucionId)+rtrim(DevArt.CajaId)+rtrim(DevArt.DevolucionArticuloUltimoIde) not in (
	SELECT rtrim(DevArtS.DevolucionId)+rtrim(DevArtS.CajaId)+rtrim(DevArtS.DevolucionArticuloUltimoIde)
 	from [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionArticulo] as DevArtS
	inner join [SERVER-SON].[Server_Lombardia].[dbo].[Devolucion] as DevS
		on DevArtS.DevolucionId=DevS.DevolucionId
			and DevArtS.CajaId=DevS.CajaId
	where DevS.DevolucionFecha between @FechaInicio and @FechaFin and DevArt.CajaId=DevArtS.CajaId and DevArt.DevolucionArticuloUltimoIde=DevArtS.DevolucionArticuloUltimoIde)
END


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
	FROM  [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionMayoreoArticulo]    as dmArtS INNER JOIN
          [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionMayoreo]       as dmS ON dmArtS.DevolucionId = dmS.DevolucionId AND dmArtS.CajaId = dmS.CajaId
	where dmS.DevolucionFecha between @FechaInicio and @FechaFin and dmArtS.CajaId=dmArt.CajaId and dmArt.DevolucionArticuloUltimoIde=dmArtS.DevolucionArticuloUltimoIde)

END


GO
/****** Object:  StoredProcedure [dbo].[asp_DevolucionMayoreo_Select]    Script Date: 18/02/2019 10:48:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_DevolucionMayoreo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        DevMay.DevolucionId
	, DevMay.CajaId
	, DevMay.TicketId
	, DevMay.UsuariosId
	, DevMay.Clienteid
	, DevMay.DevolucionFecha
	, DevMay.DevolucionSubtotal0
	, DevMay.DevolucionSubtotal16
	, DevMay.DevolucionIva
	, DevMay.DevolucionDescuento
	, DevMay.DevolucionTotal
	, DevMay.TicketTotalLetra
	, DevMay.DevolucionConcepto
	, DevMay.DevolucionAsignado
	, DevMay.CortesZRecibosId
	, DevMay.NC_Concepto
	FROM            DevolucionMayoreo AS DevMay
	where DevMay.DevolucionFecha between @FechaInicio and @FechaFin
	and DevMay.DevolucionId not in (
	SELECT        DevMayS.DevolucionId
	FROM  [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionMayoreo] AS DevMayS
	where DevMayS.DevolucionFecha between @FechaInicio and @FechaFin and DevMayS.CajaId=DevMay.CajaId)
	
END


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
	FROM [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionPreDetalles] as DPdetS
	left join [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionPre] as DPS on DPS.DevolucionPreId=DPdetS.DevolucionPreId
	where DPS.DevolucionPreFecha between @FechaInicio and @FechaFin)
END


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
	FROM          [SERVER-SON].[Server_Lombardia].[dbo].[DevolucionPre] as DpS
	WHERE        (DpS.DevolucionPreFecha BETWEEN @FechaInicio AND @FechaFin and DpS.CajaId=Dp.CajaId))
END


GO
/****** Object:  StoredProcedure [dbo].[asp_Devolucion_Select]    Script Date: 18/02/2019 10:40:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_Devolucion_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dev.DevolucionId
      ,dev.CajaId
      ,dev.TicketId
      ,dev.UsuariosId
      ,dev.DevolucionFecha
      ,dev.DevolucionSubtotal0
      ,dev.DevolucionSubtotal16
      ,dev.DevolucionIva
      ,dev.DevolucionTotal
      ,dev.DevolucionAsignadoCorte
      ,dev.CorteZId
	from Devolucion as dev
	where DevolucionFecha between @FechaInicio and @FechaFin
	and dev.DevolucionId not in (
	SELECT devS.DevolucionId
	from [SERVER-SON].[Server_Lombardia].[dbo].[Devolucion] as devS
	where devS.DevolucionFecha between @FechaInicio and @FechaFin and devS.CajaId=dev.CajaId)
END


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
	from [SERVER-SON].[Server_Lombardia].[dbo].[EntradaMercancia]  as EMS
	where EMS.EntradaMercanciaFecha between @FechaInicio and @FechaFin and EMS.SucursalesId=EM.SucursalesId)


END

GO
/****** Object:  StoredProcedure [dbo].[asp_RecibosRemisiones_Select]    Script Date: 18/02/2019 12:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_RecibosRemisiones_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select RR.RecibosId
      ,RR.TicketId
      ,RR.CajaId
      ,RR.RecibosTotal
      ,RR.ReciboTotalLetra
      ,RR.ReciboFecha
      ,RR.ClienteId
      ,RR.UsuariosId
      ,RR.DocumentosId
      ,RR.ReciboConcepto
      ,RR.CortesZRecibosId
      ,RR.FormasdePagoCobranzaId
      ,RR.RecibosAsignado
	from RecibosRemisiones as RR
	where RR.ReciboFecha between @FechaInicio and @FechaFin
	and RR.RecibosId not in (
	select RRS.RecibosId
	from [SERVER-SON].[Server_Lombardia].[dbo].RecibosRemisiones as RRS
	where RRS.ReciboFecha between @FechaInicio and @FechaFin
	)
END


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
     
	from [SERVER-SON].[Server_Lombardia].[dbo].SalidaMercanciaArticulo as SalMerArtS
	inner join [SERVER-SON].[Server_Lombardia].[dbo].SalidaMercancia as SalMerS
		on SalMerArtS.SalidaMercanciaId=SalMerS.SalidaMercanciaId
			and SalMerArtS.SucursalesId=SalMerS.SucursalesId
	where SalMerS.SalidaMercanciaFecha between @FechaInicio and @FechaFin
	and SalMerArt.SucursalesId=SalMerArtS.SucursalesId
	and SalMerArt.SalidaMercanciaArticuloUltimoIde=SalMerArtS.SalidaMercanciaArticuloUltimoIde
	)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_SalidaMercancia_Select]    Script Date: 18/02/2019 12:48:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_SalidaMercancia_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.SalidaMercanciaId
      ,s.SucursalesId
      ,s.UsuariosId
      ,s.SalidaMercanciaTipoId
      ,s.SalidaMercanciaFecha
      ,s.SalidaMercanciaUnidades
      ,s.SalidaMercanciaSub0
      ,s.SalidaMercanciaSub16
      ,s.SalidaMercanciaIva
      ,s.SalidaMercanciaTotal
      ,s.Observaciones
      ,s.Referencias
      ,s.ParaSucursal
	from SalidaMercancia as s
	where SalidaMercanciaFecha between @FechaInicio and @FechaFin
	and s.SalidaMercanciaId not in (
	select sS.SalidaMercanciaId
	from [SERVER-SON].[Server_Lombardia].[dbo].SalidaMercancia as sS
	where sS.SalidaMercanciaFecha between @FechaInicio and @FechaFin
	and s.SucursalesId=sS.SucursalesId
	)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_TicketArticulo_Select]    Script Date: 18/02/2019 05:06:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_TicketArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TicArt.TicketId
      ,TicArt.CajaId
      ,TicArt.TicketArticuloUltimoIde
      ,TicArt.ArticuloCodigo
      ,TicArt.TarifaId
      ,TicArt.MedidasId
      ,TicArt.TicketArticuloCosto
      ,TicArt.TicketArticuloPrecio
      ,TicArt.TicketArticuloCantidad
      ,TicArt.TicketArticuloCantidadDevolucion
      ,TicArt.TicketArticuloCantidadCancelada
      ,TicArt.TicketArticuloSubtotal
      ,TicArt.TicketArticuloIva
      ,TicArt.TicketArticuloTotalLinea
      ,TicArt.TicketArticuloDescuento
      ,TicArt.TicketArticuloPrecioDescuento
      ,TicArt.TicketArticuloIvaDescuento
      ,TicArt.TicketArticuloTotal
	from TicketArticulo as TicArt
	inner join Ticket as Tic
		on TicArt.TicketId=Tic.TicketId
			and TicArt.CajaId=Tic.CajaId
	where Tic.TicketFecha between @FechaInicio and @FechaFin
	and rtrim(TicArt.TicketId)+rtrim(TicArt.CajaId)+rtrim(TicArt.TicketArticuloUltimoIde) not in (
	SELECT rtrim(TicArtS.TicketId)+rtrim(TicArtS.CajaId)+rtrim(TicArtS.TicketArticuloUltimoIde)
      
	from [SERVER-SON].[Server_Lombardia].[dbo].TicketArticulo as TicArtS
	inner join [SERVER-SON].[Server_Lombardia].[dbo].Ticket as TicS
		on TicArtS.TicketId=TicS.TicketId
			and TicArtS.CajaId=TicS.CajaId
	where TicS.TicketFecha between @FechaInicio and @FechaFin
	and TicArt.CajaId=TicArtS.CajaId
	and TicArt.TicketArticuloUltimoIde=TicArtS.TicketArticuloUltimoIde
	)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_TicketMayoreoArticulo_Select]    Script Date: 18/02/2019 05:08:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_TicketMayoreoArticulo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TicMayArt.TicketId
      ,TicMayArt.CajaId
      ,TicMayArt.TicketArticuloUltimoIde
      ,TicMayArt.ArticuloCodigo
      ,TicMayArt.TarifaId
      ,TicMayArt.MedidasId
      ,TicMayArt.TicketArticuloCosto
      ,TicMayArt.TicketArticuloPrecio
      ,TicMayArt.TicketArticuloCantidad
      ,TicMayArt.TicketArticuloCantidadDevolucion
      ,TicMayArt.TicketArticuloCantidadCancelada
      ,TicMayArt.TicketArticuloSubtotal
      ,TicMayArt.TicketArticuloIva
      ,TicMayArt.TicketArticuloTotalLinea
      ,TicMayArt.TicketArticuloDescuento
      ,TicMayArt.TicketArticuloPrecioDescuento
      ,TicMayArt.TicketArticuloIvaDescuento
      ,TicMayArt.TicketArticuloTotal
	from TicketMayoreoArticulo as TicMayArt
	inner join TicketMayoreo as TicMay
		on TicMayArt.TicketId=TicMay.TicketId
			and TicMayArt.CajaId=TicMay.CajaId
	where TicMay.TicketFecha between @FechaInicio and @FechaFin
	and rtrim(TicMayArt.TicketId)+rtrim(TicMayArt.CajaId)+rtrim(TicMayArt.TicketArticuloUltimoIde) not in (
	SELECT rtrim(TicMayArtS.TicketId)+rtrim(TicMayArtS.CajaId)+rtrim(TicMayArtS.TicketArticuloUltimoIde)
      
	from [SERVER-SON].[Server_Lombardia].[dbo].TicketMayoreoArticulo as TicMayArtS
	inner join [SERVER-SON].[Server_Lombardia].[dbo].TicketMayoreo as TicMayS
		on TicMayArtS.TicketId=TicMayS.TicketId
			and TicMayArtS.CajaId=TicMayS.CajaId
	where TicMayS.TicketFecha between @FechaInicio and @FechaFin
	and TicMayArt.CajaId=TicMayArtS.CajaId
	and TicMayArt.TicketArticuloUltimoIde=TicMayArtS.TicketArticuloUltimoIde
	)
END


GO
/****** Object:  StoredProcedure [dbo].[asp_TicketMayoreo_Select]    Script Date: 18/02/2019 01:55:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_TicketMayoreo_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT tm.TicketId
      ,tm.CajaId
      ,tm.UsuarioId
      ,tm.TicketFecha
      ,tm.TicketSubtotal0
      ,tm.TicketSubtotal16
      ,tm.TicketIva
      ,tm.TicketTotal
      ,tm.CortesZRecibosId
      /*,FechaHora*/
      ,tm.ClienteId
	from TicketMayoreo as tm
	where tm.TicketFecha between @FechaInicio and @FechaFin
	and tm.TicketId not in (
	select tmS.TicketId
	from [SERVER-SON].[Server_Lombardia].[dbo].TicketMayoreo as tmS
	where tmS.TicketFecha between @FechaInicio and @FechaFin
	and tm.CajaId=tmS.CajaId
	)
END

GO
/****** Object:  StoredProcedure [dbo].[asp_Ticket_Select]    Script Date: 18/02/2019 01:44:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_Ticket_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.TicketId
      ,t.CajaId
      ,t.UsuarioId
      ,t.TicketFecha
      /*,TicketHora*/
      ,t.TicketSubtotal0
      ,t.TicketSubtotal16
      ,t.TicketIva
      ,t.TicketTotal
      ,t.CorteZId
	from Ticket as t
	where t.TicketFecha between @FechaInicio and @FechaFin
	and t.TicketId not in (
	SELECT tS.TicketId
	from [SERVER-SON].[Server_Lombardia].[dbo].Ticket as tS
	where tS.TicketFecha between @FechaInicio and @FechaFin
	and tS.CajaId=t.CajaId
	)
END

GO
