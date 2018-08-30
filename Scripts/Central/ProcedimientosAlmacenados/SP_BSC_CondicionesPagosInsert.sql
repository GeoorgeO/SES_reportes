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

	begin transaction T2;
	begin try
		INSERT INTO CondicionesPagos
                         (CondicionesPagosId, CondicionesPagosNombre, CondicionesPagosCantidad, CondicionesPagosAfectacion, CondicionesPagosFecha, CondicionesPagosActivo, FechaInsert)
		VALUES        (@CondicionesPagosId,@CondicionesPagosNombre,@CondicionesPagosCantidad,@CondicionesPagosAfectacion,@CondicionesPagosFecha,@CondicionesPagosActivo, GETDATE())

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
