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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercancia_General')
DROP PROCEDURE SP_BSC_SalidaMercancia_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercancia_General
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@SalidaMercanciaTipoId bigint ,
	@SalidaMercanciaFecha date ,
	@SalidaMercanciaUnidades bigint ,
	@SalidaMercanciaSub0 decimal(18, 2) ,
	@SalidaMercanciaSub16 decimal(18, 2) ,
	@SalidaMercanciaIva decimal(18, 2) ,
	@SalidaMercanciaTotal decimal(18, 2) ,
	@Observaciones nvarchar(max) ,
	@Referencias nvarchar(max) ,
	@ParaSucursal char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(SalidaMercanciaId) from SalidaMercancia a where (a.SalidaMercanciaId=@SalidaMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 0;
		else
			INSERT INTO SalidaMercancia
                         (SalidaMercanciaId, SucursalesId, UsuariosId, SalidaMercanciaTipoId, SalidaMercanciaFecha, SalidaMercanciaUnidades, SalidaMercanciaSub0, SalidaMercanciaSub16, SalidaMercanciaIva, 
                         SalidaMercanciaTotal, Observaciones, Referencias, ParaSucursal, FechaInsert)
VALUES        (@SalidaMercanciaId,@SucursalesId,@UsuariosId,@SalidaMercanciaTipoId,@SalidaMercanciaFecha,@SalidaMercanciaUnidades,@SalidaMercanciaSub0,@SalidaMercanciaSub16,@SalidaMercanciaIva,@SalidaMercanciaTotal,@Observaciones,@Referencias,@ParaSucursal,
                          GETDATE())
END
GO
