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
	SELECT        art.ArticuloCodigo,art.ArticuloCantidad as Existencia, art.ArticuloUltimoCosto,(art.ArticuloUltimoCosto * Iva.IvaFactor) as iva,convert(varchar, GETDATE(),103) as FechaExistencia
FROM            Articulo as art
left join Familia as fam on fam.FamiliaId=art.FamiliaId
left join Iva on Iva.IvaId=fam.IvaId
WHERE art.ArticuloCantidad>0
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
	SELECT DevMayArt.DevolucionId
      ,DevMayArt.CajaId
      ,DevMayArt.DevolucionArticuloUltimoIde
      ,DevMayArt.ArticuloCodigo
      ,DevMayArt.DevolucionArticuloPrecio
      ,DevMayArt.DevolucionArticuloCantidad
      ,DevMayArt.DevolucionArticuloSubtotal
      ,DevMayArt.DevolucionArticuloIva
      ,DevMayArt.DevolucionArticuloTotalLinea
	from DevolucionMayoreoArticulo as DevMayArt
	inner join DevolucionMayoreo as DevMay
		on DevMayArt.DevolucionId=DevMay.DevolucionId
			and DevMayArt.CajaId=DevMay.CajaId
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
	select DevolucionId
      ,CajaId
      ,TicketId
      ,UsuariosId
      ,Clienteid
      ,DevolucionFecha
      ,DevolucionSubtotal0
      ,DevolucionSubtotal16
      ,DevolucionIva
      ,DevolucionDescuento
      ,DevolucionTotal
      ,TicketTotalLetra
      /*,DevolucionConcepto
      ,DevolucionAsignado
      ,CortesZRecibosId
      ,NC_Concepto*/
	from DevolucionMayoreo
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
      /*,UsuariosId
      ,DocumentosId
      ,ReciboConcepto
      ,CortesZRecibosId
      ,FormasdePagoCobranzaId
      ,RecibosAsignado*/
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
      /*,CortesZRecibosId
      ,FechaHora*/
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
