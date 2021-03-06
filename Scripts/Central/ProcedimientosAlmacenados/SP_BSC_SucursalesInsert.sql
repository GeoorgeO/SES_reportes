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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SucursalesInsert')
DROP PROCEDURE SP_BSC_SucursalesInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SucursalesInsert
	-- Add the parameters for the stored procedure here
	@SucursalesId decimal(11, 0),
	@SucursalesNombre char(60),
	@SucursalesFecha datetime,
	@SucursalesActivo char(1),
	@SucursalesCalle char(100),
	@SucursalesNInterior char(40),
	@SucursalesnNExterior char(40),
	@SucursalesColonia char(100),
	@LocalidadId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T2;
	begin try
		INSERT INTO Sucursales
                         (SucursalesId, SucursalesNombre, SucursalesFecha, SucursalesActivo, SucursalesCalle, SucursalesNInterior, SucursalesnNExterior, SucursalesColonia, LocalidadId, FechaInsert)
		VALUES        (@SucursalesId,@SucursalesNombre,@SucursalesFecha,@SucursalesActivo,@SucursalesCalle,@SucursalesNInterior,@SucursalesnNExterior,@SucursalesColonia,@LocalidadId, 
								 GETDATE())

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO
