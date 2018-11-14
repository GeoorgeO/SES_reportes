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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_UsuariosPass_Update')
DROP PROCEDURE SP_BSC_UsuariosPass_Update
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_UsuariosPass_Update
	-- Add the parameters for the stored procedure here
	@usuariosLogin varchar(60),
	@usuariosoldpass varchar(50),
	@usuariosPassword varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	select  @Existe =count(UsuariosLogin) from usuarios where UsuariosLogin=@UsuariosLogin and usuariosPassword=@usuariosoldpass
	if @Existe>0
		update usuarios set usuariosPassword=@usuariosPassword where usuariosLogin=@usuariosLogin
	else
		select -1
END
GO
