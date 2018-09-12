USE [SES_Sincroniza]
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Centro_ActualizaEntradaMercanciaLocal_Select')
DROP PROCEDURE SP_BSC_Centro_ActualizaEntradaMercanciaLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Centro_ActualizaEntradaMercanciaLocal_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select EntradaMercanciaId
      ,SucursalesId
      ,UsuariosId
      ,EntradaMercanciaTipoId
      ,EntradaMercanciaFecha
      ,EntradaMercanciaUnidades
      ,EntradaMercanciaSub0
      ,EntradaMercanciaSub16
      ,EntradaMercanciaIva
      ,EntradaMercanciaTotal
      ,Observaciones
      ,Referencias
	from SES_AdministradorV1.dbo.EntradaMercancia
	where EntradaMercanciaFecha between @FechaInicio and @FechaFin
END
GO
