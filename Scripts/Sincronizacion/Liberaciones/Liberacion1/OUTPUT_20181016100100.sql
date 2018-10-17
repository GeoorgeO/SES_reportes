USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'SES_Sincroniza')) 
BEGIN
	create Database SES_Sincroniza
END



GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaArticuloLocal_Select]    Script Date: 26/08/2018 07:32:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaArticuloLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaArticuloLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaArticuloLocal_Select]
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ArticuloCodigo,ArticuloDescripcion from SES_AdministradorV1.dbo.Articulo
	where ArticuloFechaUdp between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaArticuloMedidasLocal_Select]    Script Date: 26/08/2018 07:38:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaArticuloMedidasLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaArticuloMedidasLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaArticuloMedidasLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ArticuloCodigo,MedidasId from SES_AdministradorV1.dbo.ArticuloMedidas
	where  ArticuloMedidasFechaUdp between @FechaInicio and @FechaFin
END

GO
use SES_Sincroniza
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaArticuloProveedoresLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaArticuloProveedoresLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ActualizaArticuloProveedoresLocal_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        ArticuloCodigo, ArticuloProveedoresIde, ProveedorId, ArticuloProveedoresFechaUdp
	FROM            SES_AdministradorV1.dbo.ArticuloProveedores
	WHERE        (ArticuloProveedoresFechaUdp BETWEEN @FechaInicio AND @FechaFin)
END
GO

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaCajaLocal_Select]    Script Date: 26/08/2018 07:40:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaCajaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaCajaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaCajaLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	select CajaId,
		SucursalesId,
		CajaNumero,
		CajaDescripcion,
		CajaReciboInicial,
		CajaFondo,
		CajaMontoEfectivo,
		CajaMontoTarjeta,
		CajaMontoVale,
		CajaFecha,
		CajaUltimoTicket,
		CajaUltimaDevolucion,
		CajaUltimaCancelacion,
		CajaUltimoCorte,
		CajaUltimoRetiro,
		CajaUltimoTicketMayoreo,
		CajaUltimoDevolucionMayoreo
	from SES_AdministradorV1.dbo.Caja
	where CajaFecha between @FechaInicio and @FechaFin

	
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaCClienteLocal_Select]    Script Date: 26/08/2018 07:42:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaCClienteLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaCClienteLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaCClienteLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select CClienteId,
		CClienteNombre,
		CClienteFecha,
		CClienteActivo,
		CClientePadreId,
		CClienteTieneElementos
	from SES_AdministradorV1.dbo.CCliente
	where CClienteFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaClienteLocal_Select]    Script Date: 26/08/2018 07:45:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaClienteLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaClienteLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaClienteLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ClienteId,
      ClienteNombre,
      ClienteFecha,
      ClientePaterno,
      ClienteMaterno,
      ClienteRfc,
      ClienteCalle,
      ClienteNInterior,
      ClienteNExterior,
      ClienteColonia,
      LocalidadId,
      ClienteFechaActualizacion,
      ClienteTelefono1,
      ClienteTelefono2,
      ClienteTelefono3,
      ClienteEmail,
      ClienteEmailFiscal,
      ClienteTipoPersona,
      ClienteActivo,
      CClienteId,
      ClienteImpresion,
      ClienteLimiteCredito,
      ClienteSobregiro,
      VendedorId,
      CondicionesPagosId,
      ClienteTieneCredito,
      ClienteDescuento,
      ClienteObservaciones,
      ClienteSaldoActual
	from SES_AdministradorV1.dbo.Cliente
	where ClienteFechaActualizacion between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaCondicionesPagosLocal_Select]    Script Date: 26/08/2018 07:47:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaCondicionesPagosLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaCondicionesPagosLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaCondicionesPagosLocal_Select] 
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select CondicionesPagosId,
      CondicionesPagosNombre,
      CondicionesPagosCantidad,
      CondicionesPagosAfectacion,
      CondicionesPagosFecha,
      CondicionesPagosActivo
	 from SES_AdministradorV1.dbo.CondicionesPagos
	 where CondicionesPagosFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaCProveedorLocal_Select]    Script Date: 26/08/2018 07:54:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaCProveedorLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaCProveedorLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaCProveedorLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select CProveedorId,
      CProveedorNombre,
      CProveedorFecha,
      CProveedorActivo,
      CProveedorPadreId,
      CProveedorTieneElementos
	from SES_AdministradorV1.dbo.CProveedor
	where CProveedorFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ActualizaEntradaMercanciaTipoLocal_Select]    Script Date: 27/08/2018 07:07:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaEntradaMercanciaTipoLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaEntradaMercanciaTipoLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaEntradaMercanciaTipoLocal_Select]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select EntradaMercanciaTipoId,
      EntradaMercanciaTipoDescripcion
	from SES_AdministradorV1.dbo.EntradaMercanciaTipo
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaFamiliaLocal_Select]    Script Date: 26/08/2018 07:55:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaFamiliaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaFamiliaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaFamiliaLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select FamiliaId,
      FamiliaNombre,
      FamiliaFecha,
      FamiliaTipo,
      FamiliaActivo,
      FamiliaPadreId,
      IvaId,
      Espadre,
      TieneArticulos
	from SES_AdministradorV1.dbo.Familia
	where FamiliaFechaUdp between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ActualizaFormasdePagoLocal_Select]    Script Date: 27/08/2018 07:10:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaFormasdePagoLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaFormasdePagoLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaFormasdePagoLocal_Select] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT FormasdePagoId,
      FormasdePagoDescripcion
	from SES_AdministradorV1.dbo.FormasdePago
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ActualizaIvaLocal_Select]    Script Date: 27/08/2018 07:10:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaIvaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaIvaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaIvaLocal_Select] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select IvaId,
      IvaNombre,
      IvaFactor,
      IvaPorcentaje
	from SES_AdministradorV1.dbo.Iva
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ActualizaLocalidadLocal_Select]    Script Date: 27/08/2018 07:11:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaLocalidadLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaLocalidadLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaLocalidadLocal_Select] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select LocalidadId,
      LocalidadNombre,
      LocalidadCP,
      MunicipioId
	from SES_AdministradorV1.dbo.Localidad
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaMedidasLocal_Select]    Script Date: 26/08/2018 07:57:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaMedidasLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaMedidasLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaMedidasLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select MedidasId,
      MedidasNombre,
      MedidasAlias
	from SES_AdministradorV1.dbo.Medidas
	where MedidasFechaUdp between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaMetodoPagosLocal_Select]    Script Date: 26/08/2018 07:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaMetodoPagosLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaMetodoPagosLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaMetodoPagosLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select MetodoPagosId,
      MetodoPagosNombre,
      MetodoPagosFecha,
      MetodoPagosActivo
	from SES_AdministradorV1.dbo.MetodoPagos
	where MetodoPagosFecha between @FechaInicio and @FechaFin
END

GO
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaMonedaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaMonedaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaMonedaLocal_Select]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select MonedaId,
      MonedaNombre,
      MonedaSimbolo,
      MonedaActivo,
      MonedaTipoCambio
	from SES_AdministradorV1.dbo.Moneda
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaProveedorLocal_Select]    Script Date: 26/08/2018 08:07:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaProveedorLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaProveedorLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaProveedorLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select ProveedorId,
      ProveedorNombre,
      ProveedorPaterno,
      ProveedorMaterno
	from SES_AdministradorV1.dbo.Proveedor
	where ProveedorFechaActualizacion between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaRolesLocal_Select]    Script Date: 26/08/2018 08:12:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaRolesLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaRolesLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaRolesLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT RolesId,
      RolesNombre,
      RolesActivo,
	  RolesFecha
	from SES_AdministradorV1.dbo.Roles
	where RolesFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ActualizaSalidaMercanciaTipoLocal_Select]    Script Date: 27/08/2018 07:12:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaSalidaMercanciaTipoLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaSalidaMercanciaTipoLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaSalidaMercanciaTipoLocal_Select]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select SalidaMercanciaTipoId,
      SalidaMercanciaTipoDescripcion
	from SES_AdministradorV1.dbo.SalidaMercanciaTipo
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaSucursalesLocal_Select]    Script Date: 26/08/2018 08:13:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaSucursalesLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaSucursalesLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaSucursalesLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select SucursalesId,
      SucursalesNombre,
      SucursalesFecha,
      SucursalesActivo,
      SucursalesCalle,
      SucursalesNInterior,
      SucursalesnNExterior,
      SucursalesColonia,
      LocalidadId
	from SES_AdministradorV1.dbo.Sucursales
	where SucursalesFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaTarifaLocal_Select]    Script Date: 26/08/2018 08:16:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaTarifaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaTarifaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaTarifaLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TarifaId,
      TarifaNombre,
      TarifaFecha,
      TarifaActivo
	from SES_AdministradorV1.dbo.Tarifa
	where TarifaFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaUsuariosLocal_Select]    Script Date: 26/08/2018 08:41:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaUsuariosLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaUsuariosLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaUsuariosLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UsuariosId,
      UsuariosNombre,
      UsuariosRegistroFecha,
      UsuariosLogin,
      UsuariosPassword,
      UsuariosActivo,
      RolesId
	from SES_AdministradorV1.dbo.Usuarios
	where UsuariosRegistroFecha between @FechaInicio and @FechaFin
END

GO
USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaVendedorLocal_Select]    Script Date: 26/08/2018 08:48:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaVendedorLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaVendedorLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaVendedorLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VendedorId,
      VendedorNombre,
      VendedorApellidos,
      VendedorActivo,
      VendedorNombreCompleto
	from SES_AdministradorV1.dbo.Vendedor
	where VendedorFecha between @FechaInicio and @FechaFin
END

GO
