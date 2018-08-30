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

	begin transaction T3;
	begin try
		UPDATE       ArticuloMedidas
		SET                MedidasId = @MedidasId, FechaUltimaActualizacion = GETDATE()
		WHERE        (ArticuloCodigo = @ArticuloCodigo)

		commit transaction T3;
		set @correcto=1
	end try
	begin catch
		rollback transaction T3;
		set @correcto=0
	end catch

	select @correcto resultado
END
