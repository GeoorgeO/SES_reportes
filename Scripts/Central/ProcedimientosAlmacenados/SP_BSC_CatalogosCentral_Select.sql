USE [Central]
GO

/****** Object:  StoredProcedure [dbo].[SP_BSC_CatalogosCentral_Select]    Script Date: 26/08/2018 04:45:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CatalogosCentral_Select')
DROP PROCEDURE SP_BSC_CatalogosCentral_Select
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <27/08/2018,>
-- Description:	<Select para mostrar los catalogos a actualizar>
-- =============================================
CREATE PROCEDURE [dbo].[SP_BSC_CatalogosCentral_Select]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TABLE_NAME
	FROM INFORMATION_SCHEMA.TABLES
	where TABLE_NAME not in ('Caja')
	order by 1
END

GO
