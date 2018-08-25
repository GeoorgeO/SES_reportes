USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Insert]    Script Date: 25/08/2018 12:17:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosInsert')
DROP PROCEDURE SP_BSC_ArticulosInsert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Insert')
DROP PROCEDURE SP_BSC_Articulo_Insert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloInsert')
DROP PROCEDURE SP_BSC_ArticuloInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Inserta Articulos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Insert]
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Articulo
                         (ArticuloCodigo, ArticuloDescripcion, FechaInsert)
		VALUES        (@ArticuloCodigo,@ArticuloDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado

    -- Insert statements for procedure here

END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Update]    Script Date: 25/08/2018 12:20:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloUpdate')
DROP PROCEDURE SP_BSC_ArticuloUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosUpdate')
DROP PROCEDURE SP_BSC_ArticulosUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Update')
DROP PROCEDURE SP_BSC_Articulo_Update
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualizar tabla Articulo>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Update]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Articulo
		SET                ArticuloDescripcion = @ArticuloDescripcion, FechaUpdate = GETDATE()
		WHERE        (ArticuloCodigo = @ArticuloCodigo)
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Insert]    Script Date: 25/08/2018 12:17:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosInsert')
DROP PROCEDURE SP_BSC_ArticulosInsert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Insert')
DROP PROCEDURE SP_BSC_Articulo_Insert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloInsert')
DROP PROCEDURE SP_BSC_ArticuloInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Inserta Articulos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Insert]
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Articulo
                         (ArticuloCodigo, ArticuloDescripcion, FechaInsert)
		VALUES        (@ArticuloCodigo,@ArticuloDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado

    -- Insert statements for procedure here

END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Update]    Script Date: 25/08/2018 12:20:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloUpdate')
DROP PROCEDURE SP_BSC_ArticuloUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosUpdate')
DROP PROCEDURE SP_BSC_ArticulosUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Update')
DROP PROCEDURE SP_BSC_Articulo_Update
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualizar tabla Articulo>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Update]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Articulo
		SET                ArticuloDescripcion = @ArticuloDescripcion, FechaUpdate = GETDATE()
		WHERE        (ArticuloCodigo = @ArticuloCodigo)
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticulosGeneral]    Script Date: 25/08/2018 12:07:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_General')
DROP PROCEDURE SP_BSC_Articulo_General
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <23/08/2018>
-- Description:	<Validar si inserta o actualiza la tabla Articulo>
-- =============================================
Create PROCEDURE [dbo].[SP_BSC_Articulo_General]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ArticuloCodigo) from Articulo a where (a.ArticuloCodigo=@ArticuloCodigo and a.ArticuloDescripcion=@ArticuloDescripcion)

		if @Existe>0
			Exec dbo.SP_BSC_ArticulosUpdate @ArticuloCodigo, @ArticuloDescripcion;
		else
			Exec dbo.SP_BSC_ArticulosInsert @ArticuloCodigo, @ArticuloDescripcion;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasInsert]    Script Date: 25/08/2018 12:26:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasInsert')
DROP PROCEDURE SP_BSC_ArticuloMedidasInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <24/08/2018>
-- Description:	<Inserta ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasInsert]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40),
	@MedidasId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO ArticuloMedidas
                         (ArticuloCodigo, MedidasId, FechaInsert)
		VALUES        (@ArticuloCodigo,@MedidasId, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasUpdate]    Script Date: 25/08/2018 12:27:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasUpdate')
DROP PROCEDURE SP_BSC_ArticuloMedidasUpdate
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualizar tabla ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasUpdate]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40),
	@MedidasId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       ArticuloMedidas
		SET                MedidasId = @MedidasId, FechaUltimaActualizacion = GETDATE()
		WHERE        (ArticuloCodigo = @ArticuloCodigo)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasGeneral]    Script Date: 25/08/2018 12:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasGeneral')
DROP PROCEDURE SP_BSC_ArticuloMedidasGeneral
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <24/08/2018>
-- Description:	<Validar si inserta o actualiza la tabla ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasGeneral]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40),
	@MedidasId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ArticuloCodigo) from ArticuloMedidas a where (a.ArticuloCodigo=@ArticuloCodigo and a.MedidasId=@MedidasId)

		if @Existe>0
			Exec dbo.SP_BSC_ArticuloMedidasUpdate @ArticuloCodigo, @MedidasId;
		else
			Exec dbo.SP_BSC_ArticuloMedidasInsert @ArticuloCodigo, @MedidasId;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CajaInsert]    Script Date: 25/08/2018 12:29:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CajaInsert')
DROP PROCEDURE SP_BSC_CajaInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CajaInsert] 
	-- Add the parameters for the stored procedure here
	@CajaId decimal(11, 0),
	@SucursalesId decimal(11, 0),
	@CajaNumero int,
	@CajaDescripcion varchar(50),
	@CajaReciboInicial int,
	@CajaFondo money,
	@CajaMontoEfectivo money,
	@CajaMontoTarjeta money,
	@CajaMontoVale money,
	@CajaFecha datetime,
	@CajaUltimoTicket decimal(18, 0),
	@CajaUltimaDevolucion decimal(18, 0),
	@CajaUltimaCancelacion decimal(18, 0),
	@CajaUltimoCorte decimal(18, 0),
	@CajaUltimoRetiro decimal(18, 0),
	@CajaUltimoTicketMayoreo decimal(18, 0),
	@CajaUltimoDevolucionMayoreo decimal(18, 0),
	@CajaImpresoraTicket varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Caja
                         (CajaId, SucursalesId, CajaNumero, CajaDescripcion, CajaReciboInicial, CajaFondo, CajaMontoEfectivo, CajaMontoTarjeta, CajaMontoVale, CajaFecha, CajaUltimoTicket, CajaUltimaDevolucion, 
                         CajaUltimaCancelacion, CajaUltimoCorte, CajaUltimoRetiro, CajaUltimoTicketMayoreo, CajaUltimoDevolucionMayoreo, CajaImpresoraTicket, FechaInsert)
		VALUES        (@CajaId,@SucursalesId,@CajaNumero,@CajaDescripcion,@CajaReciboInicial,@CajaFondo,@CajaMontoEfectivo,@CajaMontoTarjeta,@CajaMontoVale,@CajaFecha,@CajaUltimoTicket,@CajaUltimaDevolucion,@CajaUltimaCancelacion,@CajaUltimoCorte,@CajaUltimoRetiro,@CajaUltimoTicketMayoreo,@CajaUltimoDevolucionMayoreo,@CajaImpresoraTicket,
                          GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CajaUpdate]    Script Date: 25/08/2018 12:34:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CajaUpdate')
DROP PROCEDURE SP_BSC_CajaUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CajaUpdate] 
	-- Add the parameters for the stored procedure here
	@CajaId decimal(11, 0),
	@SucursalesId decimal(11, 0),
	@CajaNumero int,
	@CajaDescripcion varchar(50),
	@CajaReciboInicial int,
	@CajaFondo money,
	@CajaMontoEfectivo money,
	@CajaMontoTarjeta money,
	@CajaMontoVale money,
	@CajaFecha datetime,
	@CajaUltimoTicket decimal(18, 0),
	@CajaUltimaDevolucion decimal(18, 0),
	@CajaUltimaCancelacion decimal(18, 0),
	@CajaUltimoCorte decimal(18, 0),
	@CajaUltimoRetiro decimal(18, 0),
	@CajaUltimoTicketMayoreo decimal(18, 0),
	@CajaUltimoDevolucionMayoreo decimal(18, 0),
	@CajaImpresoraTicket varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Caja
		SET                SucursalesId = @SucursalesId, CajaNumero = @CajaNumero, CajaDescripcion = @CajaDescripcion, CajaReciboInicial = @CajaReciboInicial, CajaFondo = @CajaFondo, CajaMontoEfectivo = @CajaMontoEfectivo, 
                         CajaMontoTarjeta = @CajaMontoTarjeta, CajaMontoVale = @CajaMontoVale, CajaFecha = @CajaFecha, CajaUltimoTicket = @CajaUltimoTicket, CajaUltimaDevolucion = @CajaUltimaDevolucion, 
                         CajaUltimaCancelacion = @CajaUltimaCancelacion, CajaUltimoCorte = @CajaUltimoCorte, CajaUltimoRetiro = @CajaUltimoRetiro, CajaUltimoTicketMayoreo = @CajaUltimoTicketMayoreo, 
                         CajaUltimoDevolucionMayoreo = @CajaUltimoDevolucionMayoreo, CajaImpresoraTicket = @CajaImpresoraTicket, FechaUpdate = GETDATE()
		WHERE        (CajaId = @CajaId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CajaGeneral]    Script Date: 25/08/2018 12:35:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CajaGeneral')
DROP PROCEDURE SP_BSC_CajaGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CajaGeneral]
	-- Add the parameters for the stored procedure here
	@CajaId decimal(11, 0),
	@SucursalesId decimal(11, 0),
	@CajaNumero int,
	@CajaDescripcion varchar(50),
	@CajaReciboInicial int,
	@CajaFondo money,
	@CajaMontoEfectivo money,
	@CajaMontoTarjeta money,
	@CajaMontoVale money,
	@CajaFecha datetime,
	@CajaUltimoTicket decimal(18, 0),
	@CajaUltimaDevolucion decimal(18, 0),
	@CajaUltimaCancelacion decimal(18, 0),
	@CajaUltimoCorte decimal(18, 0),
	@CajaUltimoRetiro decimal(18, 0),
	@CajaUltimoTicketMayoreo decimal(18, 0),
	@CajaUltimoDevolucionMayoreo decimal(18, 0),
	@CajaImpresoraTicket varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CajaId) from Caja a 
		where (a.CajaId=@CajaId)

		if @Existe>0
			Exec dbo.SP_BSC_CajaUpdate @CajaId,
				@SucursalesId,
				@CajaNumero,
				@CajaDescripcion,
				@CajaReciboInicial,
				@CajaFondo,
				@CajaMontoEfectivo,
				@CajaMontoTarjeta,
				@CajaMontoVale,
				@CajaFecha,
				@CajaUltimoTicket,
				@CajaUltimaDevolucion,
				@CajaUltimaCancelacion,
				@CajaUltimoCorte,
				@CajaUltimoRetiro,
				@CajaUltimoTicketMayoreo,
				@CajaUltimoDevolucionMayoreo,
				@CajaImpresoraTicket;
		else
			Exec dbo.SP_BSC_CajaInsert @CajaId,
				@SucursalesId,
				@CajaNumero,
				@CajaDescripcion,
				@CajaReciboInicial,
				@CajaFondo,
				@CajaMontoEfectivo,
				@CajaMontoTarjeta,
				@CajaMontoVale,
				@CajaFecha,
				@CajaUltimoTicket,
				@CajaUltimaDevolucion,
				@CajaUltimaCancelacion,
				@CajaUltimoCorte,
				@CajaUltimoRetiro,
				@CajaUltimoTicketMayoreo,
				@CajaUltimoDevolucionMayoreo,
				@CajaImpresoraTicket;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CClienteInsert]    Script Date: 25/08/2018 12:37:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CClienteInsert')
DROP PROCEDURE SP_BSC_CClienteInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CClienteInsert]
	-- Add the parameters for the stored procedure here
	@CClienteId decimal(11, 0),
	@CClienteNombre char(60),
	@CClienteFecha datetime,
	@CClienteActivo char(1),
	@CClientePadreId decimal(11, 0),
	@CClienteTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO CCliente
                         (CClienteId, CClienteNombre, CClienteFecha, CClienteActivo, CClientePadreId, CClienteTieneElementos, FechaInsert)
		VALUES        (@CClienteId,@CClienteNombre,@CClienteFecha,@CClienteActivo,@CClientePadreId,@CClienteTieneElementos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CClienteUpdate]    Script Date: 25/08/2018 12:38:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CClienteUpdate')
DROP PROCEDURE SP_BSC_CClienteUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CClienteUpdate]
	-- Add the parameters for the stored procedure here
	@CClienteId decimal(11, 0),
	@CClienteNombre char(60),
	@CClienteFecha datetime,
	@CClienteActivo char(1),
	@CClientePadreId decimal(11, 0),
	@CClienteTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       CCliente
		SET                CClienteNombre = @CClienteNombre, CClienteFecha = @CClienteFecha, CClienteActivo = @CClienteActivo, CClientePadreId = @CClientePadreId, CClienteTieneElementos = @CClienteTieneElementos, 
                         FechaUpdate = GETDATE()
		WHERE        (CClienteId = @CClienteId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CClienteGeneral]    Script Date: 25/08/2018 12:38:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CClienteGeneral')
DROP PROCEDURE SP_BSC_CClienteGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CClienteGeneral]
	-- Add the parameters for the stored procedure here
	@CClienteId decimal(11, 0),
	@CClienteNombre char(60),
	@CClienteFecha datetime,
	@CClienteActivo char(1),
	@CClientePadreId decimal(11, 0),
	@CClienteTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CClienteId) from CCliente a where (a.CClienteId=@CClienteId)

		if @Existe>0
			Exec dbo.SP_BSC_CClienteUpdate @CClienteId,
			@CClienteNombre,
			@CClienteFecha,
			@CClienteActivo,
			@CClientePadreId,
			@CClienteTieneElementos;
		else
			Exec dbo.SP_BSC_CClienteInsert @CClienteId,
			@CClienteNombre,
			@CClienteFecha,
			@CClienteActivo,
			@CClientePadreId,
			@CClienteTieneElementos;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteInsert]    Script Date: 25/08/2018 12:39:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ClienteInsert')
DROP PROCEDURE SP_BSC_ClienteInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ClienteInsert] 
	-- Add the parameters for the stored procedure here
	@ClienteId decimal(11, 0),
	@ClienteNombre char(200),
	@ClienteFecha datetime,
	@ClientePaterno char(60),
	@ClienteMaterno char(60),
	@ClienteRfc char(13),
	@ClienteCalle char(100),
	@ClienteNInterior char(40),
	@ClienteNExterior char(40),
	@ClienteColonia char(100),
	@LocalidadId decimal(11, 0),
	@ClienteFechaActualizacion datetime,
	@ClienteTelefono1 char(20),
	@ClienteTelefono2 char(20),
	@ClienteTelefono3 char(20),
	@ClienteEmail char(60),
	@ClienteEmailFiscal char(60),
	@ClienteTipoPersona char(1),
	@ClienteActivo char(1),
	@CClienteId decimal(11, 0),
	@ClienteImpresion bit,
	@ClienteLimiteCredito money,
	@ClienteSobregiro money,
	@VendedorId decimal(11, 0),
	@CondicionesPagosId decimal(11, 0),
	@ClienteTieneCredito bit,
	@ClienteDescuento smallmoney,
	@ClienteObservaciones char(255),
	@ClienteSaldoActual money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Cliente
                         (ClienteId, ClienteNombre, ClienteFecha, ClientePaterno, ClienteMaterno, ClienteRfc, ClienteCalle, ClienteNInterior, ClienteNExterior, ClienteColonia, LocalidadId, ClienteFechaActualizacion, ClienteTelefono1, 
                         ClienteTelefono2, ClienteTelefono3, ClienteEmail, ClienteEmailFiscal, ClienteTipoPersona, ClienteActivo, CClienteId, ClienteImpresion, ClienteLimiteCredito, ClienteSobregiro, VendedorId, CondicionesPagosId, 
                         ClienteTieneCredito, ClienteDescuento, ClienteObservaciones, ClienteSaldoActual, FechaInsert)
		VALUES        (@ClienteId,@ClienteNombre,@ClienteFecha,@ClientePaterno,@ClienteMaterno,@ClienteRfc,@ClienteCalle,@ClienteNInterior,@ClienteNExterior,@ClienteColonia,@LocalidadId,@ClienteFechaActualizacion,@ClienteTelefono1,@ClienteTelefono2,@ClienteTelefono3,@ClienteEmail,@ClienteEmailFiscal,@ClienteTipoPersona,@ClienteActivo,@CClienteId,@ClienteImpresion,@ClienteLimiteCredito,@ClienteSobregiro,@VendedorId,@CondicionesPagosId,@ClienteTieneCredito,@ClienteDescuento,@ClienteObservaciones,@ClienteSaldoActual,
                          GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteUpdate]    Script Date: 25/08/2018 12:39:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ClienteUpdate')
DROP PROCEDURE SP_BSC_ClienteUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ClienteUpdate] 
	-- Add the parameters for the stored procedure here
	@ClienteId decimal(11, 0),
	@ClienteNombre char(200),
	@ClienteFecha datetime,
	@ClientePaterno char(60),
	@ClienteMaterno char(60),
	@ClienteRfc char(13),
	@ClienteCalle char(100),
	@ClienteNInterior char(40),
	@ClienteNExterior char(40),
	@ClienteColonia char(100),
	@LocalidadId decimal(11, 0),
	@ClienteFechaActualizacion datetime,
	@ClienteTelefono1 char(20),
	@ClienteTelefono2 char(20),
	@ClienteTelefono3 char(20),
	@ClienteEmail char(60),
	@ClienteEmailFiscal char(60),
	@ClienteTipoPersona char(1),
	@ClienteActivo char(1),
	@CClienteId decimal(11, 0),
	@ClienteImpresion bit,
	@ClienteLimiteCredito money,
	@ClienteSobregiro money,
	@VendedorId decimal(11, 0),
	@CondicionesPagosId decimal(11, 0),
	@ClienteTieneCredito bit,
	@ClienteDescuento smallmoney,
	@ClienteObservaciones char(255),
	@ClienteSaldoActual money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Cliente
	SET                ClienteNombre = @ClienteNombre, ClienteFecha = @ClienteFecha, ClientePaterno = @ClientePaterno, ClienteMaterno = @ClienteMaterno, ClienteRfc = @ClienteRfc, ClienteCalle = @ClienteCalle, 
                         ClienteNInterior = @ClienteNInterior, ClienteNExterior = @ClienteNExterior, ClienteColonia = @ClienteColonia, LocalidadId = @LocalidadId, ClienteFechaActualizacion = @ClienteFechaActualizacion, 
                         ClienteTelefono1 = @ClienteTelefono1, ClienteTelefono2 = @ClienteTelefono2, ClienteTelefono3 = @ClienteTelefono3, ClienteEmail = @ClienteEmail, ClienteEmailFiscal = @ClienteEmailFiscal, 
                         ClienteTipoPersona = @ClienteTipoPersona, ClienteActivo = @ClienteActivo, CClienteId = @CClienteId, ClienteImpresion = @ClienteImpresion, ClienteLimiteCredito = @ClienteLimiteCredito, 
                         ClienteSobregiro = @ClienteSobregiro, VendedorId = @VendedorId, CondicionesPagosId = @CondicionesPagosId, ClienteTieneCredito = @ClienteTieneCredito, ClienteDescuento = @ClienteDescuento, 
                         ClienteObservaciones = @ClienteObservaciones, ClienteSaldoActual = @ClienteSaldoActual, FechaUpdate = GETDATE()
	WHERE        (ClienteId = @ClienteId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ClienteGeneral')
DROP PROCEDURE SP_BSC_ClienteGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ClienteGeneral] 
	-- Add the parameters for the stored procedure here
	@ClienteId decimal(11, 0),
	@ClienteNombre char(200),
	@ClienteFecha datetime,
	@ClientePaterno char(60),
	@ClienteMaterno char(60),
	@ClienteRfc char(13),
	@ClienteCalle char(100),
	@ClienteNInterior char(40),
	@ClienteNExterior char(40),
	@ClienteColonia char(100),
	@LocalidadId decimal(11, 0),
	@ClienteFechaActualizacion datetime,
	@ClienteTelefono1 char(20),
	@ClienteTelefono2 char(20),
	@ClienteTelefono3 char(20),
	@ClienteEmail char(60),
	@ClienteEmailFiscal char(60),
	@ClienteTipoPersona char(1),
	@ClienteActivo char(1),
	@CClienteId decimal(11, 0),
	@ClienteImpresion bit,
	@ClienteLimiteCredito money,
	@ClienteSobregiro money,
	@VendedorId decimal(11, 0),
	@CondicionesPagosId decimal(11, 0),
	@ClienteTieneCredito bit,
	@ClienteDescuento smallmoney,
	@ClienteObservaciones char(255),
	@ClienteSaldoActual money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ClienteId) from Cliente a where (a.ClienteId=@ClienteId)

		if @Existe>0
			Exec dbo.SP_BSC_ClienteUpdate @ClienteId,
	@ClienteNombre,
	@ClienteFecha,
	@ClientePaterno,
	@ClienteMaterno,
	@ClienteRfc,
	@ClienteCalle,
	@ClienteNInterior,
	@ClienteNExterior,
	@ClienteColonia,
	@LocalidadId,
	@ClienteFechaActualizacion,
	@ClienteTelefono1,
	@ClienteTelefono2,
	@ClienteTelefono3,
	@ClienteEmail,
	@ClienteEmailFiscal,
	@ClienteTipoPersona,
	@ClienteActivo,
	@CClienteId,
	@ClienteImpresion,
	@ClienteLimiteCredito,
	@ClienteSobregiro,
	@VendedorId,
	@CondicionesPagosId,
	@ClienteTieneCredito,
	@ClienteDescuento,
	@ClienteObservaciones,
	@ClienteSaldoActual;
		else
			Exec dbo.SP_BSC_ClienteInsert @ClienteId,
	@ClienteNombre,
	@ClienteFecha,
	@ClientePaterno,
	@ClienteMaterno,
	@ClienteRfc,
	@ClienteCalle,
	@ClienteNInterior,
	@ClienteNExterior,
	@ClienteColonia,
	@LocalidadId,
	@ClienteFechaActualizacion,
	@ClienteTelefono1,
	@ClienteTelefono2,
	@ClienteTelefono3,
	@ClienteEmail,
	@ClienteEmailFiscal,
	@ClienteTipoPersona,
	@ClienteActivo,
	@CClienteId,
	@ClienteImpresion,
	@ClienteLimiteCredito,
	@ClienteSobregiro,
	@VendedorId,
	@CondicionesPagosId,
	@ClienteTieneCredito,
	@ClienteDescuento,
	@ClienteObservaciones,
	@ClienteSaldoActual;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ComprasSugeridasInsert]    Script Date: 25/08/2018 12:41:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ComprasSugeridasInsert')
DROP PROCEDURE SP_BSC_ComprasSugeridasInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ComprasSugeridasInsert] 
	-- Add the parameters for the stored procedure here
	@Codigo char(40),
	@Descripcion char(200),
	@Centro int,
	@Morelos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO ComprasSugeridas
                         (Codigo, Descripcion, Centro, Morelos, FechaInsert)
		VALUES        (@Codigo,@Descripcion,@Centro,@Morelos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ComprasSugeridasUpdate]    Script Date: 25/08/2018 12:42:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ComprasSugeridasUpdate')
DROP PROCEDURE SP_BSC_ComprasSugeridasUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ComprasSugeridasUpdate] 
	-- Add the parameters for the stored procedure here
	@Codigo char(40),
	@Descripcion char(200),
	@Centro int,
	@Morelos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       ComprasSugeridas
		SET                Descripcion = @Descripcion, Centro = @Centro, Morelos = @Morelos, FechaUpdate = GETDATE()
		WHERE        (Codigo = @Codigo)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ComprasSugeridasGeneral]    Script Date: 25/08/2018 12:43:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ComprasSugeridasGeneral')
DROP PROCEDURE SP_BSC_ComprasSugeridasGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ComprasSugeridasGeneral]
	-- Add the parameters for the stored procedure here
	@Codigo char(40),
	@Descripcion char(200),
	@Centro int,
	@Morelos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(Codigo) from ComprasSugeridas a where (a.Codigo=@Codigo)

		if @Existe>0
			Exec dbo.SP_BSC_ComprasSugeridasUpdate @Codigo,
			@Descripcion,
			@Centro,
			@Morelos;
		else
			Exec dbo.SP_BSC_ComprasSugeridasInsert @Codigo,
			@Descripcion,
			@Centro,
			@Morelos;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CondicionesPagosInsert]    Script Date: 25/08/2018 12:47:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CondicionesPagosInsert')
DROP PROCEDURE SP_BSC_CondicionesPagosInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Inserta en tabla CondicionesPagos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CondicionesPagosInsert]
	-- Add the parameters for the stored procedure here
	@CondicionesPagosId decimal(11, 0),
	@CondicionesPagosNombre char(60),
	@CondicionesPagosCantidad int,
	@CondicionesPagosAfectacion bit,
	@CondicionesPagosFecha datetime,
	@CondicionesPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO CondicionesPagos
                         (CondicionesPagosId, CondicionesPagosNombre, CondicionesPagosCantidad, CondicionesPagosAfectacion, CondicionesPagosFecha, CondicionesPagosActivo, FechaInsert)
		VALUES        (@CondicionesPagosId,@CondicionesPagosNombre,@CondicionesPagosCantidad,@CondicionesPagosAfectacion,@CondicionesPagosFecha,@CondicionesPagosActivo, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CondicionesPagosUpdate]    Script Date: 25/08/2018 12:48:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CondicionesPagosUpdate')
DROP PROCEDURE SP_BSC_CondicionesPagosUpdate
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualiza la tabla CondicionesPagos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CondicionesPagosUpdate]
	-- Add the parameters for the stored procedure here
	@CondicionesPagosId decimal(11, 0),
	@CondicionesPagosNombre char(60),
	@CondicionesPagosCantidad int,
	@CondicionesPagosAfectacion bit,
	@CondicionesPagosFecha datetime,
	@CondicionesPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       CondicionesPagos
		SET                CondicionesPagosNombre = @CondicionesPagosNombre, CondicionesPagosCantidad = @CondicionesPagosCantidad, CondicionesPagosAfectacion = @CondicionesPagosAfectacion, 
                         CondicionesPagosFecha = @CondicionesPagosFecha, CondicionesPagosActivo = @CondicionesPagosActivo, FechaUpdate = GETDATE()
		WHERE        (CondicionesPagosId = @CondicionesPagosId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CondicionesPagosGeneral]    Script Date: 25/08/2018 12:48:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CondicionesPagosGeneral')
DROP PROCEDURE SP_BSC_CondicionesPagosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CondicionesPagosGeneral]
	-- Add the parameters for the stored procedure here
	@CondicionesPagosId decimal(11, 0),
	@CondicionesPagosNombre char(60),
	@CondicionesPagosCantidad int,
	@CondicionesPagosAfectacion bit,
	@CondicionesPagosFecha datetime,
	@CondicionesPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CondicionesPagosId) from CondicionesPagos a where (a.CondicionesPagosId=@CondicionesPagosId)

		if @Existe>0
			Exec dbo.SP_BSC_CondicionesPagosUpdate @CondicionesPagosId,
			@CondicionesPagosNombre,
			@CondicionesPagosCantidad,
			@CondicionesPagosAfectacion,
			@CondicionesPagosFecha,
			@CondicionesPagosActivo;
		else
			Exec dbo.SP_BSC_CondicionesPagosInsert @CondicionesPagosId,
			@CondicionesPagosNombre,
			@CondicionesPagosCantidad,
			@CondicionesPagosAfectacion,
			@CondicionesPagosFecha,
			@CondicionesPagosActivo;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorInsert]    Script Date: 25/08/2018 12:49:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorInsert')
DROP PROCEDURE SP_BSC_CProveedorInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorInsert] 
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO CProveedor
                         (CProveedorId, CProveedorNombre, CProveedorFecha, CProveedorActivo, CProveedorPadreId, CProveedorTieneElementos, FechaInsert)
		VALUES        (@CProveedorId,@CProveedorNombre,@CProveedorFecha,@CProveedorActivo,@CProveedorPadreId,@CProveedorTieneElementos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
	
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorUpdate]    Script Date: 25/08/2018 12:49:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorUpdate')
DROP PROCEDURE SP_BSC_CProveedorUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorUpdate] 
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       CProveedor
		SET                CProveedorNombre = @CProveedorNombre, CProveedorFecha = @CProveedorFecha, CProveedorActivo = @CProveedorActivo, CProveedorPadreId = @CProveedorPadreId, 
                         CProveedorTieneElementos = @CProveedorTieneElementos, FechaUpdate = GETDATE()
		WHERE        (CProveedorId = @CProveedorId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorGeneral]    Script Date: 25/08/2018 12:52:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorGeneral')
DROP PROCEDURE SP_BSC_CProveedorGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorGeneral]
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CProveedorId) from CProveedor a where (a.CProveedorId=@CProveedorId)

		if @Existe>0
			Exec dbo.SP_BSC_CProveedorUpdate @CProveedorId,
			@CProveedorNombre,
			@CProveedorFecha,
			@CProveedorActivo,
			@CProveedorPadreId,
			@CProveedorTieneElementos;
		else
			Exec dbo.SP_BSC_CProveedorInsert @CProveedorId,
			@CProveedorNombre,
			@CProveedorFecha,
			@CProveedorActivo,
			@CProveedorPadreId,
			@CProveedorTieneElementos;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosInsert]    Script Date: 25/08/2018 12:52:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosInsert')
DROP PROCEDURE SP_BSC_DocumentosInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosInsert] 
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Documentos
                         (DocumentosId, DocumentosNombre, FechaInsert)
		VALUES        (@DocumentosId,@DocumentosNombre, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosUpdate]    Script Date: 25/08/2018 12:53:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosUpdate')
DROP PROCEDURE SP_BSC_DocumentosUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosUpdate]
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Documentos
		SET                DocumentosNombre = @DocumentosNombre, FechaUpdate = GETDATE()
		WHERE        (DocumentosId = @DocumentosId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosGeneral]    Script Date: 25/08/2018 12:53:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosGeneral')
DROP PROCEDURE SP_BSC_DocumentosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosGeneral] 
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(DocumentosId) from Documentos a where (a.DocumentosId=@DocumentosId)

		if @Existe>0
			Exec dbo.SP_BSC_DocumentosUpdate @DocumentosId,
			@DocumentosNombre;
		else
			Exec dbo.SP_BSC_DocumentosInsert @DocumentosId,
			@DocumentosNombre;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoInsert]    Script Date: 25/08/2018 12:54:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoInsert')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<EntradaMercanciaTipo,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoInsert]  
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO EntradaMercanciaTipo
                         (EntradaMercanciaTipoId, EntradaMercanciaTipoDescripcion, FechaInsert)
		VALUES        (@EntradaMercanciaTipoId,@EntradaMercanciaTipoDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoUpdate]    Script Date: 25/08/2018 12:54:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoUpdate')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoUpdate] 
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       EntradaMercanciaTipo
		SET                EntradaMercanciaTipoDescripcion = @EntradaMercanciaTipoDescripcion, FechaUpdate = GETDATE()
		WHERE        (EntradaMercanciaTipoId = @EntradaMercanciaTipoId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoGeneral]    Script Date: 25/08/2018 12:55:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoGeneral')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoGeneral]
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(EntradaMercanciaTipoId) from EntradaMercanciaTipo a where (a.EntradaMercanciaTipoId=@EntradaMercanciaTipoId)

		if @Existe>0
			Exec dbo.SP_BSC_EntradaMercanciaTipoUpdate @EntradaMercanciaTipoId,
			@EntradaMercanciaTipoDescripcion;
		else
			Exec dbo.SP_BSC_EntradaMercanciaTipoInsert @EntradaMercanciaTipoId,
			@EntradaMercanciaTipoDescripcion;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FamiliaInsert]    Script Date: 25/08/2018 12:56:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FamiliaInsert')
DROP PROCEDURE SP_BSC_FamiliaInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FamiliaInsert]
	-- Add the parameters for the stored procedure here
	@FamiliaId decimal(11, 0),
	@FamiliaNombre char(60),
	@FamiliaFecha datetime,
	@FamiliaTipo char(1),
	@FamiliaActivo char(1),
	@FamiliaPadreId decimal(11, 0),
	@IvaId decimal(11, 0),
	@Espadre bit,
	@TieneArticulos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Familia
                         (FamiliaId, FamiliaNombre, FamiliaFecha, FamiliaTipo, FamiliaActivo, FamiliaPadreId, IvaId, Espadre, TieneArticulos, FechaInsert)
		VALUES        (@FamiliaId,@FamiliaNombre,@FamiliaFecha,@FamiliaTipo,@FamiliaActivo,@FamiliaPadreId,@IvaId,@Espadre,@TieneArticulos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FamiliaUpdate]    Script Date: 25/08/2018 12:57:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FamiliaUpdate')
DROP PROCEDURE SP_BSC_FamiliaUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FamiliaUpdate]
	-- Add the parameters for the stored procedure here
	@FamiliaId decimal(11, 0),
	@FamiliaNombre char(60),
	@FamiliaFecha datetime,
	@FamiliaTipo char(1),
	@FamiliaActivo char(1),
	@FamiliaPadreId decimal(11, 0),
	@IvaId decimal(11, 0),
	@Espadre bit,
	@TieneArticulos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Familia
		SET                FamiliaNombre = @FamiliaNombre, FamiliaFecha = @FamiliaFecha, FamiliaTipo = @FamiliaTipo, FamiliaActivo = @FamiliaActivo, FamiliaPadreId = @FamiliaPadreId, IvaId = @IvaId, Espadre = @Espadre, 
                         TieneArticulos = @TieneArticulos, FechaUpdate = GETDATE()
		WHERE        (FamiliaId = @FamiliaId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FamiliaGeneral]    Script Date: 25/08/2018 12:57:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FamiliaGeneral')
DROP PROCEDURE SP_BSC_FamiliaGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FamiliaGeneral] 
	-- Add the parameters for the stored procedure here
	@FamiliaId decimal(11, 0),
	@FamiliaNombre char(60),
	@FamiliaFecha datetime,
	@FamiliaTipo char(1),
	@FamiliaActivo char(1),
	@FamiliaPadreId decimal(11, 0),
	@IvaId decimal(11, 0),
	@Espadre bit,
	@TieneArticulos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(FamiliaId) from Familia a where (a.FamiliaId=@FamiliaId)

		if @Existe>0
			Exec dbo.SP_BSC_FamiliaUpdate @FamiliaId,
			@FamiliaNombre,
			@FamiliaFecha,
			@FamiliaTipo,
			@FamiliaActivo,
			@FamiliaPadreId,
			@IvaId,
			@Espadre,
			@TieneArticulos;
		else
			Exec dbo.SP_BSC_FamiliaInsert @FamiliaId,
			@FamiliaNombre,
			@FamiliaFecha,
			@FamiliaTipo,
			@FamiliaActivo,
			@FamiliaPadreId,
			@IvaId,
			@Espadre,
			@TieneArticulos;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FormasdePagoInsert]    Script Date: 25/08/2018 12:58:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FormasdePagoInsert')
DROP PROCEDURE SP_BSC_FormasdePagoInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FormasdePagoInsert]
	-- Add the parameters for the stored procedure here
	@FormasdePagoId bigint,
	@FormasdePagoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO FormasdePago
                         (FormasdePagoId, FormasdePagoDescripcion, FechaInsert)
	VALUES        (@FormasdePagoId,@FormasdePagoDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FormasdePagoUpdate]    Script Date: 25/08/2018 12:58:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FormasdePagoUpdate')
DROP PROCEDURE SP_BSC_FormasdePagoUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FormasdePagoUpdate] 
	-- Add the parameters for the stored procedure here
	@FormasdePagoId bigint,
	@FormasdePagoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       FormasdePago
		SET                FormasdePagoDescripcion = @FormasdePagoDescripcion, FechaUpdate = GETDATE()
		WHERE        (FormasdePagoId = @FormasdePagoId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FormasdePagoGeneral]    Script Date: 25/08/2018 12:59:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FormasdePagoGeneral')
DROP PROCEDURE SP_BSC_FormasdePagoGeneral
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <23/08/2013>
-- Description:	<Validador si inserta o actualiza registro en la tabla FormasdePago>
-- =============================================
create PROCEDURE  [dbo].[SP_BSC_FormasdePagoGeneral]
	-- Add the parameters for the stored procedure here
	@FormasdePagoId bigint,
	@FormasdePagoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(FormasdePagoId) from FormasdePago a where (a.FormasdePagoId=@FormasdePagoId)

		if @Existe>0
			Exec dbo.SP_BSC_FormasdePagoUpdate @FormasdePagoId,
			@FormasdePagoDescripcion;
		else
			Exec dbo.SP_BSC_FormasdePagoInsert @FormasdePagoId,
			@FormasdePagoDescripcion;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
