USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ActualizaIvaLocal_Select]    Script Date: 27/08/2018 07:10:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaIvaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaIvaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaIvaLocal_Select] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select IvaId,
      IvaNombre,
      IvaFactor,
      IvaPorcentaje
	from SES_AdministradorV1.dbo.Iva
END
