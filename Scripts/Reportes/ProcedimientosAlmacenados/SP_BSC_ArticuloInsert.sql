USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticulosInsert]    Script Date: 23/08/2018 12:41:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosInsert')
DROP PROCEDURE SP_BSC_ArticulosInsert
Go
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SP_BSC_ArticulosInsert]
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Articulo
                         (ArticuloCodigo, ArticuloDescripcion, FechaInsert)
	VALUES        (@ArticuloCodigo,@ArticuloDescripcion, GETDATE())
END
