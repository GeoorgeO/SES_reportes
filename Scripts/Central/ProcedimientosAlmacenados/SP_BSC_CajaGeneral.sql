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
	@CajaUltimoDevolucionMayoreo decimal(18, 0)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
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
				@CajaUltimoDevolucionMayoreo;
				
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
				@CajaUltimoDevolucionMayoreo;
				
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
