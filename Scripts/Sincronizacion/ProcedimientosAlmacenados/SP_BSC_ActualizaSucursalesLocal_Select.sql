USE [SES_Sincroniza]
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizaSucursalesLocal_Select]    Script Date: 26/08/2018 08:13:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ActualizaSucursalesLocal_Select')
DROP PROCEDURE SP_BSC_ActualizaSucursalesLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ActualizaSucursalesLocal_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select SucursalesId,
      SucursalesNombre,
      SucursalesFecha,
      SucursalesActivo,
      SucursalesCalle,
      SucursalesNInterior,
      SucursalesnNExterior,
      SucursalesColonia,
      LocalidadId
	from SES_AdministradorV1.dbo.Sucursales
	where SucursalesFecha between @FechaInicio and @FechaFin
END
