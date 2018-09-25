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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercancia_General')
DROP PROCEDURE SP_BSC_EntradaMercancia_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_EntradaMercancia_General 
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@EntradaMercanciaTipoId bigint ,
	@EntradaMercanciaFecha date ,
	@EntradaMercanciaUnidades bigint ,
	@EntradaMercanciaSub0 decimal(18, 2) ,
	@EntradaMercanciaSub16 decimal(18, 2) ,
	@EntradaMercanciaIva decimal(18, 2) ,
	@EntradaMercanciaTotal decimal(18, 2) ,
	@Observaciones nvarchar(max) ,
	@Referencias nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(EntradaMercanciaId) from EntradaMercancia a where (a.EntradaMercanciaId=@EntradaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 0;
		else
			INSERT INTO EntradaMercancia
                         (EntradaMercanciaId, SucursalesId, UsuariosId, EntradaMercanciaTipoId, EntradaMercanciaFecha, EntradaMercanciaUnidades, EntradaMercanciaSub0, EntradaMercanciaSub16, EntradaMercanciaIva, 
                         EntradaMercanciaTotal, Observaciones, Referencias, FechaInsert)
VALUES        (@EntradaMercanciaId,@SucursalesId,@UsuariosId,@EntradaMercanciaTipoId,@EntradaMercanciaFecha,@EntradaMercanciaUnidades,@EntradaMercanciaSub0,@EntradaMercanciaSub16,@EntradaMercanciaIva,@EntradaMercanciaTotal,@Observaciones,@Referencias,
                          GETDATE())
END
GO
