
GO
/****** Object:  StoredProcedure [dbo].[usp_UsuarioAccesosSelect]    Script Date: 17/09/2019 05:38:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[usp_UsuarioAccesosInventarioSelect]
	@c_codigo_usu varchar(20),
	@v_passwo_usu varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
SELECT        Usuarios.UsuariosId, RTRIM(Usuarios.UsuariosNombre) AS UsuariosNombre, RTRIM(Usuarios.UsuariosLogin) AS UsuariosLogin, RTRIM(Usuarios.UsuariosPassword) AS UsuariosPassword,UsuariosActivo, 
                         RTRIM(Roles.RolesNombre) AS RolesNombre
FROM            Usuarios INNER JOIN
                         Roles ON Usuarios.RolesId = Roles.RolesId
						 where UsuariosLogin=@c_codigo_usu and UsuariosPassword=@v_passwo_usu

END


