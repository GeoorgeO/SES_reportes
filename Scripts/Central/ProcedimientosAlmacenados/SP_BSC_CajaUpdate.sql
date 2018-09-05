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
	@CajaUltimoDevolucionMayoreo decimal(18, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T3;
	begin try
		UPDATE       Caja
		SET                SucursalesId = @SucursalesId, CajaNumero = @CajaNumero, CajaDescripcion = @CajaDescripcion, CajaReciboInicial = @CajaReciboInicial, CajaFondo = @CajaFondo, CajaMontoEfectivo = @CajaMontoEfectivo, 
                         CajaMontoTarjeta = @CajaMontoTarjeta, CajaMontoVale = @CajaMontoVale, CajaFecha = @CajaFecha, CajaUltimoTicket = @CajaUltimoTicket, CajaUltimaDevolucion = @CajaUltimaDevolucion, 
                         CajaUltimaCancelacion = @CajaUltimaCancelacion, CajaUltimoCorte = @CajaUltimoCorte, CajaUltimoRetiro = @CajaUltimoRetiro, CajaUltimoTicketMayoreo = @CajaUltimoTicketMayoreo, 
                         CajaUltimoDevolucionMayoreo = @CajaUltimoDevolucionMayoreo,  FechaUpdate = GETDATE()
		WHERE        (CajaId = @CajaId)

		commit transaction T3;
		set @correcto=1
	end try
	begin catch
		rollback transaction T3;
		set @correcto=0
	end catch

	select @correcto resultado
END
