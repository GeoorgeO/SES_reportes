USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasGeneral]    Script Date: 25/08/2018 12:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasGeneral')
DROP PROCEDURE SP_BSC_ArticuloMedidasGeneral
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <24/08/2018>
-- Description:	<Validar si inserta o actualiza la tabla ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasGeneral]
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

	begin transaction T1;
	begin try

		declare @Existe int
		select @Existe = count(ArticuloCodigo) from ArticuloMedidas a where (a.ArticuloCodigo=@ArticuloCodigo and a.MedidasId=@MedidasId)

		if @Existe>0
			Exec dbo.SP_BSC_ArticuloMedidasUpdate @ArticuloCodigo, @MedidasId;
		else
			Exec dbo.SP_BSC_ArticuloMedidasInsert @ArticuloCodigo, @MedidasId;
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
