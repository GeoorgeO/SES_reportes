use [SES_Reportes]
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Usuarios_insert')
DROP PROCEDURE SP_BSC_Usuarios_insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Usuarios_insert
	-- Add the parameters for the stored procedure here
	@UsuariosLogin varchar(60),
	@UsuariosNombre varchar(60),
	@UsuariosPassword varchar(50),
	@Usuariosclase char(1),
	@UsuariosActivo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	select  @Existe =count(UsuariosLogin) from usuarios where UsuariosLogin=@UsuariosLogin

	if @Existe>0
		UPDATE       usuarios
		SET                UsuariosNombre = @UsuariosNombre, UsuariosPassword = @UsuariosPassword, UsuariosActivo = @UsuariosActivo, Usuariosclase = @Usuariosclase, UsuariosFechaUpdate = GETDATE()
		WHERE        (UsuariosLogin = @UsuariosLogin)
	else
		INSERT INTO usuarios
							 (UsuariosNombre, UsuariosRegistroFecha, UsuariosLogin, UsuariosPassword, UsuariosActivo, Usuariosclase)
		VALUES        (@UsuariosNombre,getdate(),@UsuariosLogin,@UsuariosPassword,@UsuariosActivo,@Usuariosclase)
END
GO
