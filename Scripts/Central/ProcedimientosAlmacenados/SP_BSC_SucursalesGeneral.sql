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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SucursalesGeneral')
DROP PROCEDURE SP_BSC_SucursalesGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SucursalesGeneral 
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

	begin transaction T1;
	begin try

		declare @Existe int
		select @Existe = count(SucursalesId) from Sucursales a where (a.SucursalesId=@SucursalesId)

		if @Existe>0
			Exec dbo.SP_BSC_SucursalesUpdate @SucursalesId,
				@SucursalesNombre,
				@SucursalesFecha,
				@SucursalesActivo,
				@SucursalesCalle,
				@SucursalesNInterior,
				@SucursalesnNExterior,
				@SucursalesColonia,
				@LocalidadId;
		else
			Exec dbo.SP_BSC_SucursalesInsert @SucursalesId,
				@SucursalesNombre,
				@SucursalesFecha,
				@SucursalesActivo,
				@SucursalesCalle,
				@SucursalesNInterior,
				@SucursalesnNExterior,
				@SucursalesColonia,
				@LocalidadId;
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO
