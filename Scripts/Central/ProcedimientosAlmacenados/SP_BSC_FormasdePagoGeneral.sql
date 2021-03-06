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

	begin transaction T1;
	begin try

		declare @Existe int
		select @Existe = count(FormasdePagoId) from FormasdePago a where (a.FormasdePagoId=@FormasdePagoId)

		if @Existe>0
			Exec dbo.SP_BSC_FormasdePagoUpdate @FormasdePagoId,
			@FormasdePagoDescripcion;
		else
			Exec dbo.SP_BSC_FormasdePagoInsert @FormasdePagoId,
			@FormasdePagoDescripcion;
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
