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

	begin transaction T2;
	begin try
		INSERT INTO ArticuloMedidas
                         (ArticuloCodigo, MedidasId, FechaInsert)
		VALUES        (@ArticuloCodigo,@MedidasId, GETDATE())

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
