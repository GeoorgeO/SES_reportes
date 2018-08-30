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

	begin transaction T1;
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
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
