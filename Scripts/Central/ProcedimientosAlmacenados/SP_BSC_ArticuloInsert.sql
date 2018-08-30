USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Insert]    Script Date: 25/08/2018 12:17:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosInsert')
DROP PROCEDURE SP_BSC_ArticulosInsert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Insert')
DROP PROCEDURE SP_BSC_Articulo_Insert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloInsert')
DROP PROCEDURE SP_BSC_ArticuloInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Inserta Articulos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Insert]
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @correcto bit

	begin transaction T2;
	begin try
		INSERT INTO Articulo
                         (ArticuloCodigo, ArticuloDescripcion, FechaInsert)
		VALUES        (@ArticuloCodigo,@ArticuloDescripcion, GETDATE())

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado

    -- Insert statements for procedure here

END
