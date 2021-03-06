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

	begin transaction T3;
	begin try
		UPDATE       FormasdePago
		SET                FormasdePagoDescripcion = @FormasdePagoDescripcion, FechaUpdate = GETDATE()
		WHERE        (FormasdePagoId = @FormasdePagoId)

		commit transaction T3;
		set @correcto=1
	end try
	begin catch
		rollback transaction T3;
		set @correcto=0
	end catch

	select @correcto resultado
END
