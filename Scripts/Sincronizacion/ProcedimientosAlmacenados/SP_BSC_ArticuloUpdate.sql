USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloUpdate]    Script Date: 23/08/2018 12:43:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloUpdate')
DROP PROCEDURE SP_BSC_ArticuloUpdate
Go
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloUpdate]
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE       Articulo
	SET                ArticuloDescripcion = @ArticuloDescripcion, FechaInsert = GETDATE()
	WHERE        (ArticuloCodigo = @ArticuloCodigo)
END
