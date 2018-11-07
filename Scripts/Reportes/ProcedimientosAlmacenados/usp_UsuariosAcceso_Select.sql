USE [SES_Reportes]
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'usp_UsuariosAcceso_Select')
DROP PROCEDURE usp_UsuariosAcceso_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_UsuariosAcceso_Select
	-- Add the parameters for the stored procedure here
	@c_codigo_usu varchar(60),
	@v_passwo_usu varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	select UsuariosLogin,UsuariosClase,UsuariosActivo from usuarios where UsuariosLogin=@c_codigo_usu and UsuariosPassword=@v_passwo_usu
END
GO
