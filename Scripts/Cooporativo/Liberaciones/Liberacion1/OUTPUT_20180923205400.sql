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
	@ArticuloIVA money 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(ArticuloCodigo) from ArticuloKardex a where (a.ArticuloCodigo=@ArticuloCodigo and convert(varchar,FechaExistencia,103)=convert(varchar, GETDATE(),103))
	if @Existe>0
			select 0;
		else
			 INSERT INTO ArticuloKardex
									 (ArticuloCodigo, Existencia, ArticuloCosto, ArticuloIVA, FechaExistencia, FechaInsert)
			VALUES        (@ArticuloCodigo,@Existencia,@ArticuloCosto,@ArticuloIVA, convert(varchar, GETDATE(),103), GETDATE());
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Cancelacion_General')
DROP PROCEDURE SP_BSC_Cancelacion_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Cancelacion_General
	-- Add the parameters for the stored procedure here
	@CancelacionId bigint,
	@CajaId decimal(11, 0),
	@TicketId bigint,
	@UsuarioId decimal(11, 0),
	@CancelacionFecha datetime,
	@CancelacionSubtotal0 money,
	@CancelacionSubtotal16 money,
	@CancelacionIva money,
	@CancelacionTotal money,
	@CancelacionAsignadoCorte bit,
	@CorteZId bigint,
	@CancelacionesTotal bit,
	@TicketMayoreoId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CancelacionId) from Cancelacion a where (a.CancelacionId=@CancelacionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta cancelancion '+@CancelacionId;
		else
			 INSERT INTO Cancelacion
                         (CancelacionId, CajaId, TicketId, UsuarioId, CancelacionFecha, CancelacionSubtotal0, CancelacionSubtotal16, CancelacionIva, CancelacionTotal, CancelacionAsignadoCorte, CorteZId, CancelacionesTotal, TicketMayoreoId, 
                         FechaInsert)
			VALUES        (@CancelacionId,@CajaId,@TicketId,@UsuarioId,@CancelacionFecha,@CancelacionSubtotal0,@CancelacionSubtotal16,@CancelacionIva,@CancelacionTotal,@CancelacionAsignadoCorte,@CorteZId,@CancelacionesTotal,@TicketMayoreoId,
									  GETDATE());
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CancelacionArticulo_General')
DROP PROCEDURE SP_BSC_CancelacionArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CancelacionArticulo_General
	-- Add the parameters for the stored procedure here
	@CancelacionId bigint,
	@CajaId decimal(11, 0),
	@CancelacionArticuloUltimoIde bigint,
	@TicketId bigint,
	@ArticuloCodigo char(40),
	@CancelacionArticuloPrecio money,
	@CancelacionArticuloCantidad bigint,
	@CancelacionArticuloSubtotal money,
	@CancelacionArticuloIva money,
	@CancelacionArticuloTotalLinea money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CancelacionId) from CancelacionArticulo a where (a.CancelacionId=@CancelacionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta CancelacionArticulo '+@CancelacionId;
		else
			 INSERT INTO CancelacionArticulo
                         (CancelacionId, CajaId, CancelacionArticuloUltimoIde, TicketId, ArticuloCodigo, CancelacionArticuloPrecio, CancelacionArticuloCantidad, CancelacionArticuloSubtotal, CancelacionArticuloIva, CancelacionArticuloTotalLinea, 
                         FechaInsert)
				VALUES        (@CancelacionId,@CajaId,@CancelacionArticuloUltimoIde,@TicketId,@ArticuloCodigo,@CancelacionArticuloPrecio,@CancelacionArticuloCantidad,@CancelacionArticuloSubtotal,@CancelacionArticuloIva,@CancelacionArticuloTotalLinea,
										  GETDATE());
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Devolucion_General')
DROP PROCEDURE SP_BSC_Devolucion_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Devolucion_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@TicketId bigint ,
	@UsuariosId decimal(11, 0) ,
	@DevolucionFecha datetime ,
	@DevolucionSubtotal0 money ,
	@DevolucionSubtotal16 money ,
	@DevolucionIva money ,
	@DevolucionTotal money ,
	@DevolucionAsignadoCorte bit ,
	@CorteZId bigint 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from Devolucion a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta Devolucion '+@DevolucionId;
		else
			INSERT INTO Devolucion
                         (DevolucionId, CajaId, TicketId, UsuariosId, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionTotal, DevolucionAsignadoCorte, CorteZId,FechaInsert)
VALUES        (@DevolucionId,@CajaId,@TicketId,@UsuariosId,@DevolucionFecha,@DevolucionSubtotal0,@DevolucionSubtotal16,@DevolucionIva,@DevolucionTotal,@DevolucionAsignadoCorte,@CorteZId,GETDATE()) 
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionArticulo_General')
DROP PROCEDURE SP_BSC_DevolucionArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionArticulo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@DevolucionArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@DevolucionArticuloPrecio money ,
	@DevolucionArticuloCantidad bigint ,
	@DevolucionArticuloSubtotal money ,
	@DevolucionArticuloIva money ,
	@DevolucionArticuloTotalLinea money 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionArticulo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta Devolucion '+@DevolucionId;
		else
			INSERT INTO DevolucionArticulo
                         (DevolucionId, CajaId, DevolucionArticuloUltimoIde, ArticuloCodigo, DevolucionArticuloPrecio, DevolucionArticuloCantidad, DevolucionArticuloSubtotal, DevolucionArticuloIva, DevolucionArticuloTotalLinea, 
                         FechaInsert)
VALUES        (@DevolucionId,@CajaId,@DevolucionArticuloUltimoIde,@ArticuloCodigo,@DevolucionArticuloPrecio,@DevolucionArticuloCantidad,@DevolucionArticuloSubtotal,@DevolucionArticuloIva,@DevolucionArticuloTotalLinea,
                          GETDATE())
	
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionMayoreo_General')
DROP PROCEDURE SP_BSC_DevolucionMayoreo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionMayoreo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@TicketId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@Clienteid decimal(11, 0) ,
	@DevolucionFecha datetime ,
	@DevolucionSubtotal0 money ,
	@DevolucionSubtotal16 money ,
	@DevolucionIva money ,
	@DevolucionDescuento money ,
	@DevolucionTotal money ,
	@TicketTotalLetra varchar(max) ,
	@DevolucionConcepto varchar(50) ,
	@DevolucionAsignado bit ,
	@CortesZRecibosId bigint ,
	@NC_Concepto varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionMayoreo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta Devolucion '+@DevolucionId;
		else
			INSERT INTO DevolucionMayoreo
                         (DevolucionId, CajaId, TicketId, UsuariosId, Clienteid, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionDescuento, DevolucionTotal, TicketTotalLetra, DevolucionConcepto,
                          DevolucionAsignado, CortesZRecibosId, NC_Concepto, FechaInsert)
VALUES        (@DevolucionId,@CajaId,@TicketId,@UsuariosId,@Clienteid,@DevolucionFecha,@DevolucionSubtotal0,@DevolucionSubtotal16,@DevolucionIva,@DevolucionDescuento,@DevolucionTotal,@TicketTotalLetra,@DevolucionConcepto,@DevolucionAsignado,@CortesZRecibosId,@NC_Concepto,
                          GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionMayoreoArticulo_General')
DROP PROCEDURE SP_BSC_DevolucionMayoreoArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionMayoreoArticulo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@DevolucionArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@DevolucionArticuloPrecio money ,
	@DevolucionArticuloCantidad bigint ,
	@DevolucionArticuloSubtotal money ,
	@DevolucionArticuloIva money ,
	@DevolucionArticuloTotalLinea money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionMayoreoArticulo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta Devolucion Mayoreo Articulo '+@DevolucionId;
		else
		INSERT INTO DevolucionMayoreoArticulo
                         (DevolucionId, CajaId, DevolucionArticuloUltimoIde, ArticuloCodigo, DevolucionArticuloPrecio, DevolucionArticuloCantidad, DevolucionArticuloSubtotal, DevolucionArticuloIva, DevolucionArticuloTotalLinea, 
                         FechaInsert)
VALUES        (@DevolucionId,@CajaId,@DevolucionArticuloUltimoIde,@ArticuloCodigo,@DevolucionArticuloPrecio,@DevolucionArticuloCantidad,@DevolucionArticuloSubtotal,@DevolucionArticuloIva,@DevolucionArticuloTotalLinea,
                          GETDATE())	
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercancia_General')
DROP PROCEDURE SP_BSC_EntradaMercancia_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_EntradaMercancia_General 
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@EntradaMercanciaTipoId bigint ,
	@EntradaMercanciaFecha date ,
	@EntradaMercanciaUnidades bigint ,
	@EntradaMercanciaSub0 decimal(18, 2) ,
	@EntradaMercanciaSub16 decimal(18, 2) ,
	@EntradaMercanciaIva decimal(18, 2) ,
	@EntradaMercanciaTotal decimal(18, 2) ,
	@Observaciones nvarchar(max) ,
	@Referencias nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(EntradaMercanciaId) from EntradaMercancia a where (a.EntradaMercanciaId=@EntradaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 'Ya existe esta Entrada de Mercancia '+@EntradaMercanciaId;
		else
			INSERT INTO EntradaMercancia
                         (EntradaMercanciaId, SucursalesId, UsuariosId, EntradaMercanciaTipoId, EntradaMercanciaFecha, EntradaMercanciaUnidades, EntradaMercanciaSub0, EntradaMercanciaSub16, EntradaMercanciaIva, 
                         EntradaMercanciaTotal, Observaciones, Referencias, FechaInsert)
VALUES        (@EntradaMercanciaId,@SucursalesId,@UsuariosId,@EntradaMercanciaTipoId,@EntradaMercanciaFecha,@EntradaMercanciaUnidades,@EntradaMercanciaSub0,@EntradaMercanciaSub16,@EntradaMercanciaIva,@EntradaMercanciaTotal,@Observaciones,@Referencias,
                          GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaArticulo_General')
DROP PROCEDURE SP_BSC_EntradaMercanciaArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_EntradaMercanciaArticulo_General 
	-- Add the parameters for the stored procedure here
	@EntradasMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@EntradasMercanciaArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@EntradasMercanciaArticuloCantidad bigint ,
	@EntradasMercanciaArticuloSub0 decimal(18, 2) ,
	@EntradasMercanciaArticuloSub16 decimal(18, 2) ,
	@EntradasMercanciaArticuloIva decimal(18, 2) ,
	@EntradasMercanciaArticuloTotal decimal(18, 2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(EntradasMercanciaId) from EntradaMercanciaArticulo a where (a.EntradasMercanciaId=@EntradasMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 'Ya existe esta Entrada de Mercancia articulo '+@EntradasMercanciaId;
		else
			INSERT INTO EntradaMercanciaArticulo
                         (EntradasMercanciaId, SucursalesId, EntradasMercanciaArticuloUltimoIde, ArticuloCodigo, EntradasMercanciaArticuloCantidad, EntradasMercanciaArticuloSub0, EntradasMercanciaArticuloSub16, 
                         EntradasMercanciaArticuloIva, EntradasMercanciaArticuloTotal, FechaInsert)
VALUES        (@EntradasMercanciaId,@SucursalesId,@EntradasMercanciaArticuloUltimoIde,@ArticuloCodigo,@EntradasMercanciaArticuloCantidad,@EntradasMercanciaArticuloSub0,@EntradasMercanciaArticuloSub16,@EntradasMercanciaArticuloIva,@EntradasMercanciaArticuloTotal,
                          GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercancia_General')
DROP PROCEDURE SP_BSC_SalidaMercancia_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercancia_General
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@SalidaMercanciaTipoId bigint ,
	@SalidaMercanciaFecha date ,
	@SalidaMercanciaUnidades bigint ,
	@SalidaMercanciaSub0 decimal(18, 2) ,
	@SalidaMercanciaSub16 decimal(18, 2) ,
	@SalidaMercanciaIva decimal(18, 2) ,
	@SalidaMercanciaTotal decimal(18, 2) ,
	@Observaciones nvarchar(max) ,
	@Referencias nvarchar(max) ,
	@ParaSucursal char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(SalidaMercanciaId) from SalidaMercancia a where (a.SalidaMercanciaId=@SalidaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 'Ya existe esta Salida de Mercancia '+@SalidaMercanciaId;
		else
			INSERT INTO SalidaMercancia
                         (SalidaMercanciaId, SucursalesId, UsuariosId, SalidaMercanciaTipoId, SalidaMercanciaFecha, SalidaMercanciaUnidades, SalidaMercanciaSub0, SalidaMercanciaSub16, SalidaMercanciaIva, 
                         SalidaMercanciaTotal, Observaciones, Referencias, ParaSucursal, FechaInsert)
VALUES        (@SalidaMercanciaId,@SucursalesId,@UsuariosId,@SalidaMercanciaTipoId,@SalidaMercanciaFecha,@SalidaMercanciaUnidades,@SalidaMercanciaSub0,@SalidaMercanciaSub16,@SalidaMercanciaIva,@SalidaMercanciaTotal,@Observaciones,@Referencias,@ParaSucursal,
                          GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercanciaArticulo_General')
DROP PROCEDURE SP_BSC_SalidaMercanciaArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercanciaArticulo_General
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@SalidaMercanciaArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@SalidaMercanciaArticuloCantidad bigint ,
	@SalidaMercanciaArticuloSub0 decimal(18, 2) ,
	@SalidaMercanciaArticuloSub16 decimal(18, 2) ,
	@SalidaMercanciaArticuloIva decimal(18, 2) ,
	@SalidaMercanciaArticuloTotal decimal(18, 2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(SalidaMercanciaId) from SalidaMercanciaArticulo a where (a.SalidaMercanciaId=@SalidaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 'Ya existe esta Salida de Mercancia '+@SalidaMercanciaId;
		else
			INSERT INTO SalidaMercanciaArticulo
                         (SalidaMercanciaId, SucursalesId, SalidaMercanciaArticuloUltimoIde, ArticuloCodigo, SalidaMercanciaArticuloCantidad, SalidaMercanciaArticuloSub0, SalidaMercanciaArticuloSub16, SalidaMercanciaArticuloIva, 
                         SalidaMercanciaArticuloTotal, FechaInsert)
VALUES        (@SalidaMercanciaId,@SucursalesId,@SalidaMercanciaArticuloUltimoIde,@ArticuloCodigo,@SalidaMercanciaArticuloCantidad,@SalidaMercanciaArticuloSub0,@SalidaMercanciaArticuloSub16,@SalidaMercanciaArticuloIva,@SalidaMercanciaArticuloTotal,
                          GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Ticket_General')
DROP PROCEDURE SP_BSC_Ticket_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Ticket_General 
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@UsuarioId decimal(11, 0) ,
	@TicketFecha datetime ,
	@TicketHora datetime ,
	@TicketSubtotal0 money ,
	@TicketSubtotal16 money ,
	@TicketIva money ,
	@TicketTotal money ,
	@CorteZId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from Ticket a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe este ticket '+@TicketId;
		else
			INSERT INTO Ticket
                         (TicketId, CajaId, UsuarioId, TicketFecha, TicketHora, TicketSubtotal0, TicketSubtotal16, TicketIva, TicketTotal, CorteZId, FechaInsert)
VALUES        (@TicketId,@CajaId,@UsuarioId,@TicketFecha,@TicketHora,@TicketSubtotal0,@TicketSubtotal16,@TicketIva,@TicketTotal,@CorteZId, GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TicketArticulo_General')
DROP PROCEDURE SP_BSC_TicketArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  SP_BSC_TicketArticulo_General
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@TicketArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@TarifaId decimal(11, 0) ,
	@MedidasId decimal(11, 0) ,
	@TicketArticuloCosto money ,
	@TicketArticuloPrecio money ,
	@TicketArticuloCantidad int ,
	@TicketArticuloCantidadDevolucion bigint ,
	@TicketArticuloCantidadCancelada bigint ,
	@TicketArticuloSubtotal money ,
	@TicketArticuloIva money ,
	@TicketArticuloTotalLinea money ,
	@TicketArticuloDescuento money ,
	@TicketArticuloPrecioDescuento money ,
	@TicketArticuloIvaDescuento money ,
	@TicketArticuloTotal money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from TicketArticulo a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe este Ticket Articulo '+@TicketId;
		else
			INSERT INTO TicketArticulo
                         (TicketId, CajaId, TicketArticuloUltimoIde, ArticuloCodigo, TarifaId, MedidasId, TicketArticuloCosto, TicketArticuloPrecio, TicketArticuloCantidad, TicketArticuloCantidadDevolucion, TicketArticuloCantidadCancelada, 
                         TicketArticuloSubtotal, TicketArticuloIva, TicketArticuloTotalLinea, TicketArticuloDescuento, TicketArticuloPrecioDescuento, TicketArticuloIvaDescuento, TicketArticuloTotal, FechaInsert)
VALUES        (@TicketId,@CajaId,@TicketArticuloUltimoIde,@ArticuloCodigo,@TarifaId,@MedidasId,@TicketArticuloCosto,@TicketArticuloPrecio,@TicketArticuloCantidad,@TicketArticuloCantidadDevolucion,@TicketArticuloCantidadCancelada,@TicketArticuloSubtotal,@TicketArticuloIva,@TicketArticuloTotalLinea,@TicketArticuloDescuento,@TicketArticuloPrecioDescuento,@TicketArticuloIvaDescuento,@TicketArticuloTotal,
                          GETDATE())
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TicketMayoreo_General')
DROP PROCEDURE SP_BSC_TicketMayoreo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TicketMayoreo_General
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@UsuarioId decimal(11, 0) ,
	@TicketFecha datetime ,
	@TicketSubtotal0 money ,
	@TicketSubtotal16 money ,
	@TicketIva money ,
	@TicketTotal money ,
	@CortesZRecibosId bigint NULL,
	@FechaHora datetime NULL,
	@ClienteId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from TicketMayoreo a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe este ticket de mayoreo '+@TicketId;
		else
		INSERT INTO TicketMayoreo
                         (TicketId, CajaId, UsuarioId, TicketFecha, TicketSubtotal0, TicketSubtotal16, TicketIva, TicketTotal, CortesZRecibosId, FechaHora, ClienteId, FechaInsert)
VALUES        (@TicketId,@CajaId,@UsuarioId,@TicketFecha,@TicketSubtotal0,@TicketSubtotal16,@TicketIva,@TicketTotal,@CortesZRecibosId,@FechaHora,@ClienteId, GETDATE())	
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TicketMayoreoArticulo_General')
DROP PROCEDURE SP_BSC_TicketMayoreoArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TicketMayoreoArticulo_General
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@TicketArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@TarifaId decimal(11, 0) ,
	@MedidasId decimal(11, 0) ,
	@TicketArticuloCosto money ,
	@TicketArticuloPrecio money ,
	@TicketArticuloCantidad int ,
	@TicketArticuloCantidadDevolucion bigint ,
	@TicketArticuloCantidadCancelada bigint ,
	@TicketArticuloSubtotal money ,
	@TicketArticuloIva money ,
	@TicketArticuloTotalLinea money ,
	@TicketArticuloDescuento money ,
	@TicketArticuloPrecioDescuento money ,
	@TicketArticuloIvaDescuento money ,
	@TicketArticuloTotal money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from TicketMayoreoArticulo a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe este ticket de mayoreo articulo '+@TicketId;
		else
			INSERT INTO TicketMayoreoArticulo
                         (TicketId, CajaId, TicketArticuloUltimoIde, ArticuloCodigo, TarifaId, MedidasId, TicketArticuloCosto, TicketArticuloPrecio, TicketArticuloCantidad, TicketArticuloCantidadDevolucion, TicketArticuloCantidadCancelada, 
                         TicketArticuloSubtotal, TicketArticuloIva, TicketArticuloTotalLinea, TicketArticuloDescuento, TicketArticuloPrecioDescuento, TicketArticuloIvaDescuento, TicketArticuloTotal, FechaInsert)
VALUES        (@TicketId,@CajaId,@TicketArticuloUltimoIde,@ArticuloCodigo,@TarifaId,@MedidasId,@TicketArticuloCosto,@TicketArticuloPrecio,@TicketArticuloCantidad,@TicketArticuloCantidadDevolucion,@TicketArticuloCantidadCancelada,@TicketArticuloSubtotal,@TicketArticuloIva,@TicketArticuloTotalLinea,@TicketArticuloDescuento,@TicketArticuloPrecioDescuento,@TicketArticuloIvaDescuento,@TicketArticuloTotal,
                          GETDATE())
END
GO

GO
