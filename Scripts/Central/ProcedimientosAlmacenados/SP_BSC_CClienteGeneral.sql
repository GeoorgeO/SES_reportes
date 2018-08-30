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

	begin transaction T1;
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
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
