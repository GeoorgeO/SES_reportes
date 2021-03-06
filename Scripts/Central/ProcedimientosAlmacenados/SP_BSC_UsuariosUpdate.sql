USE Central
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_UsuariosUpdate')
DROP PROCEDURE SP_BSC_UsuariosUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_UsuariosUpdate
	-- Add the parameters for the stored procedure here
	@UsuariosId decimal(11, 0),
	@UsuariosNombre char(60),
	@UsuariosRegistroFecha datetime,
	@UsuariosLogin char(60),
	@UsuariosPassword char(60),
	@UsuariosActivo char(1),
	@RolesId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T3;
	begin try
		UPDATE       Usuarios
		SET                UsuariosNombre = @UsuariosNombre, UsuariosRegistroFecha = @UsuariosRegistroFecha, UsuariosLogin = @UsuariosLogin, UsuariosPassword = @UsuariosPassword, UsuariosActivo = @UsuariosActivo, 
								 RolesId = @RolesId, FechaUpdate = GETDATE()
		WHERE        (UsuariosId = @UsuariosId)

		commit transaction T3;
		set @correcto=1
	end try
	begin catch
		rollback transaction T3;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO
