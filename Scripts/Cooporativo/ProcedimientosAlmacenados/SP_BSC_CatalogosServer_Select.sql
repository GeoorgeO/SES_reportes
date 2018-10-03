GO

/****** Object:  StoredProcedure [dbo].[SP_BSC_CatalogosServer_Select]    Script Date: 20/09/2018 07:42:37 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CatalogosServer_Select')
DROP PROCEDURE SP_BSC_CatalogosServer_Select
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_BSC_CatalogosServer_Select]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TABLE_NAME
	FROM INFORMATION_SCHEMA.TABLES
	--where TABLE_NAME not in ('DevolucionMayoreo','DevolucionMayoreoArticulo','TicketMayoreo','TicketMayoreoArticulo')
	order by 1
END

GO


