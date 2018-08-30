USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticulosGeneral]    Script Date: 25/08/2018 12:07:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_General')
DROP PROCEDURE SP_BSC_Articulo_General
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <23/08/2018>
-- Description:	<Validar si inserta o actualiza la tabla Articulo>
-- =============================================
Create PROCEDURE [dbo].[SP_BSC_Articulo_General]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
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
		select @Existe = count(ArticuloCodigo) from Articulo a where (a.ArticuloCodigo=@ArticuloCodigo)

		if @Existe>0
			Exec dbo.SP_BSC_Articulo_Update @ArticuloCodigo, @ArticuloDescripcion;
		else
			Exec dbo.SP_BSC_Articulo_Insert @ArticuloCodigo, @ArticuloDescripcion;
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
