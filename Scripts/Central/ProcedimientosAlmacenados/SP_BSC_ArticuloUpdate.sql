USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Update]    Script Date: 25/08/2018 12:20:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloUpdate')
DROP PROCEDURE SP_BSC_ArticuloUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosUpdate')
DROP PROCEDURE SP_BSC_ArticulosUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Update')
DROP PROCEDURE SP_BSC_Articulo_Update
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualizar tabla Articulo>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Update]
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

	begin transaction T3;
	begin try
		UPDATE       Articulo
		SET                ArticuloDescripcion = @ArticuloDescripcion, FechaUpdate = GETDATE()
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
