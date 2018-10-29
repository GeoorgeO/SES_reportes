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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_ArticuloKardex_Select')
DROP PROCEDURE asp_ArticuloKardex_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_ArticuloKardex_Select

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        art.ArticuloCodigo,art.Existencia as Existencia, art.ArticuloCosto,(art.ArticuloIVA) as iva,Art.FechaExistencia
	FROM            ArticuloKardex as art
END
GO

GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_ArticuloKardexLocal_Select')
DROP PROCEDURE asp_ArticuloKardexLocal_Select
GO
CREATE PROCEDURE asp_ArticuloKardexLocal_Select

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from ArticuloKardex
	where  CONVERT(date,FechaExistencia ,103)= convert(date, GETDATE(),103) 
	
	insert into ArticuloKardex (ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIVA,FechaExistencia,FechaInsert)
	SELECT  art.ArticuloCodigo,art.ArticuloCantidad, art.ArticuloUltimoCosto,(art.ArticuloUltimoCosto * Iva.IvaFactor) as iva, getdate() ,getdate()
	FROM            Articulo as art
	left join Familia as fam on fam.FamiliaId=art.FamiliaId
	left join Iva on Iva.IvaId=fam.IvaId
	WHERE  art.ArticuloCantidad>0
end
go



GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_Cancelacion_Select')
DROP PROCEDURE asp_Cancelacion_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_Cancelacion_Select
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
	FROM Cancelacion
	where CancelacionFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_CancelacionArticulo_Select')
DROP PROCEDURE asp_CancelacionArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_CancelacionArticulo_Select
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
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_CortesZ_Select')
DROP PROCEDURE asp_CortesZ_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_CortesZ_Select
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
	from CortesZ
	where CortesZFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_CortesZRecargas_Select')
DROP PROCEDURE asp_CortesZRecargas_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_CortesZRecargas_Select
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
	FROM            CortesZRecargas
	WHERE        (CortesZRecargasFecha BETWEEN @FechaInicio AND @FechaFin)
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_CortesZRecargasTickets_Select')
DROP PROCEDURE asp_CortesZRecargasTickets_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_CortesZRecargasTickets_Select
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
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_CortesZRecibos_Select')
DROP PROCEDURE asp_CortesZRecibos_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_CortesZRecibos_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        CortesZRecibosId, CortesZRecibosFecha, UsuariosId, CortesZRecibosTotal
	FROM            CortesZRecibos
	WHERE        (CortesZRecibosFecha BETWEEN @FechaInicio AND @FechaFin)
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_CortesZRecibosDetalles_Select')
DROP PROCEDURE asp_CortesZRecibosDetalles_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_CortesZRecibosDetalles_Select
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
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_Devolucion_Select')
DROP PROCEDURE asp_Devolucion_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_Devolucion_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DevolucionId
      ,CajaId
      ,TicketId
      ,UsuariosId
      ,DevolucionFecha
      ,DevolucionSubtotal0
      ,DevolucionSubtotal16
      ,DevolucionIva
      ,DevolucionTotal
      ,DevolucionAsignadoCorte
      ,CorteZId
	from Devolucion
	where DevolucionFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_DevolucionArticulo_Select')
DROP PROCEDURE asp_DevolucionArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_DevolucionArticulo_Select
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
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_DevolucionMayoreo_Select')
DROP PROCEDURE asp_DevolucionMayoreo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_DevolucionMayoreo_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT        DevolucionId, CajaId, TicketId, UsuariosId, Clienteid, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionDescuento, DevolucionTotal, TicketTotalLetra, DevolucionConcepto, 
                         DevolucionAsignado, CortesZRecibosId, NC_Concepto
	FROM            DevolucionMayoreo AS DevMay
	where DevMay.DevolucionFecha between @FechaInicio and @FechaFin
	
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_DevolucionMayoreoArticulo_Select')
DROP PROCEDURE asp_DevolucionMayoreoArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_DevolucionMayoreoArticulo_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT        DevolucionMayoreoArticulo.DevolucionId, DevolucionMayoreoArticulo.CajaId, DevolucionMayoreoArticulo.DevolucionArticuloUltimoIde, DevolucionMayoreoArticulo.ArticuloCodigo, 
                         DevolucionMayoreoArticulo.DevolucionArticuloPrecio, DevolucionMayoreoArticulo.DevolucionArticuloCantidad, DevolucionMayoreoArticulo.DevolucionArticuloSubtotal, DevolucionMayoreoArticulo.DevolucionArticuloIva, 
                         DevolucionMayoreoArticulo.DevolucionArticuloTotalLinea
FROM            DevolucionMayoreoArticulo INNER JOIN
                         DevolucionMayoreo ON DevolucionMayoreoArticulo.DevolucionId = DevolucionMayoreo.DevolucionId AND DevolucionMayoreoArticulo.CajaId = DevolucionMayoreo.CajaId
	where DevolucionMayoreo.DevolucionFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_DevolucionPre_Select')
DROP PROCEDURE asp_DevolucionPre_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_DevolucionPre_Select 
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        DevolucionPreId, TicketId, CajaId, DevolucionPreFecha,DevolucionPreTArticulos, UsuarioId, VendedorId, DevolucionPreSub0, DevolucionPreSub16, DevolucionPreIva, DevolucionPreTotal, DevolucionPreProcesada
	FROM            DevolucionPre
	WHERE        (DevolucionPreFecha BETWEEN @FechaInicio AND @FechaFin)
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_DevolucionPreDetalles_Select')
DROP PROCEDURE asp_DevolucionPreDetalles_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_DevolucionPreDetalles_Select
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
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_EntradaMercancia_Select')
DROP PROCEDURE asp_EntradaMercancia_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_EntradaMercancia_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select EntradaMercanciaId
      ,SucursalesId
      ,UsuariosId
      ,EntradaMercanciaTipoId
      ,EntradaMercanciaFecha
      ,EntradaMercanciaUnidades
      ,EntradaMercanciaSub0
      ,EntradaMercanciaSub16
      ,EntradaMercanciaIva
      ,EntradaMercanciaTotal
      ,Observaciones
      ,Referencias
	from EntradaMercancia
	where EntradaMercanciaFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_EntradaMercanciaArticulo_Select')
DROP PROCEDURE asp_EntradaMercanciaArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_EntradaMercanciaArticulo_Select
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
	
	
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_RecibosRemisiones_Select')
DROP PROCEDURE asp_RecibosRemisiones_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_RecibosRemisiones_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select RecibosId
      ,TicketId
      ,CajaId
      ,RecibosTotal
      ,ReciboTotalLetra
      ,ReciboFecha
      ,ClienteId
      ,UsuariosId
      ,DocumentosId
      ,ReciboConcepto
      ,CortesZRecibosId
      ,FormasdePagoCobranzaId
      ,RecibosAsignado
	from RecibosRemisiones
	where ReciboFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_SalidaMercancia_Select')
DROP PROCEDURE asp_SalidaMercancia_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_SalidaMercancia_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SalidaMercanciaId
      ,SucursalesId
      ,UsuariosId
      ,SalidaMercanciaTipoId
      ,SalidaMercanciaFecha
      ,SalidaMercanciaUnidades
      ,SalidaMercanciaSub0
      ,SalidaMercanciaSub16
      ,SalidaMercanciaIva
      ,SalidaMercanciaTotal
      ,Observaciones
      ,Referencias
      ,ParaSucursal
	from SalidaMercancia
	where SalidaMercanciaFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_SalidaMercanciaArticulo_Select')
DROP PROCEDURE asp_SalidaMercanciaArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_SalidaMercanciaArticulo_Select
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
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_Ticket_Select')
DROP PROCEDURE asp_Ticket_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_Ticket_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TicketId
      ,CajaId
      ,UsuarioId
      ,TicketFecha
      /*,TicketHora*/
      ,TicketSubtotal0
      ,TicketSubtotal16
      ,TicketIva
      ,TicketTotal
      ,CorteZId
	from Ticket
	where TicketFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_TicketArticulo_Select')
DROP PROCEDURE asp_TicketArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_TicketArticulo_Select
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
	where TicketFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_TicketMayoreo_Select')
DROP PROCEDURE asp_TicketMayoreo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_TicketMayoreo_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TicketId
      ,CajaId
      ,UsuarioId
      ,TicketFecha
      ,TicketSubtotal0
      ,TicketSubtotal16
      ,TicketIva
      ,TicketTotal
      ,CortesZRecibosId
      /*,FechaHora*/
      ,ClienteId
	from TicketMayoreo
	where TicketFecha between @FechaInicio and @FechaFin
END
GO

GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_TicketMayoreoArticulo_Select')
DROP PROCEDURE asp_TicketMayoreoArticulo_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_TicketMayoreoArticulo_Select
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
END
GO

GO
/****** Object:  Table [dbo].[ArticuloKardex]    Script Date: 24/09/2018 11:52:09 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF OBJECT_ID('ArticuloKardex') IS NOT NULL
	begin
		select 0;
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[ArticuloKardex](
		[ArticuloCodigo] [char](40) NOT NULL,
		[Existencia] [int] NULL,
		[ArticuloCosto] [money] NULL,
		[ArticuloIVA] [money] NULL,
		[FechaExistencia] [datetime] NOT NULL,
		[FechaInsert] [datetime] NULL,
	 CONSTRAINT [PK_ArticuloKardex] PRIMARY KEY CLUSTERED 
	(
		[ArticuloCodigo] ASC,
		[FechaExistencia] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end



GO

SET ANSI_PADDING OFF
GO



GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloKardex_General')
DROP PROCEDURE SP_BSC_ArticuloKardex_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ArticuloKardex_General
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40) ,
	@Existencia int ,
	@ArticuloCosto money ,
	@ArticuloIVA money ,
	@FechaExistencia varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(ArticuloCodigo) from ArticuloKardex a where (a.ArticuloCodigo=@ArticuloCodigo and convert(datetime,FechaExistencia,103)=convert(datetime, @FechaExistencia,103))
	if @Existe>0
			select 0;
		else
			 INSERT INTO ArticuloKardex
									 (ArticuloCodigo, Existencia, ArticuloCosto, ArticuloIVA, FechaExistencia, FechaInsert)
			VALUES        (@ArticuloCodigo,@Existencia,@ArticuloCosto,@ArticuloIVA, convert(varchar, @FechaExistencia,103), GETDATE());
END
GO

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'TR' and name = 'ArticuloKardex_Insert')
DROP TRIGGER ArticuloKardex_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER ArticuloKardex_Insert
   ON  CortesZ
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	exec asp_ArticuloKardexLocal_Select
END
GO
ALTER TABLE CortesZ ENABLE TRIGGER ArticuloKardex_Insert
go

GO
