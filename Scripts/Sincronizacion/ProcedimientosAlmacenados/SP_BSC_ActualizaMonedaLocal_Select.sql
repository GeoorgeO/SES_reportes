GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaMonedaLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaMonedaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaMonedaLocal_Select]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select MonedaId,
      MonedaNombre,
      MonedaSimbolo,
      MonedaActivo,
      MonedaTipoCambio
	from SES_AdministradorV1.dbo.Moneda
END