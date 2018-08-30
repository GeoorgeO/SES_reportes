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

	begin transaction T1;
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
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
