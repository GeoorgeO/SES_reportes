USE [Central]
GO

/****** Object:  StoredProcedure [dbo].[SP_BSC_CatalogosCentral_Select]    Script Date: 26/08/2018 04:45:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
	order by 1
END

GO


