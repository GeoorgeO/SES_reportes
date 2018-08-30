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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ProveedorUpdate')
DROP PROCEDURE SP_BSC_ProveedorUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ProveedorUpdate
	-- Add the parameters for the stored procedure here
	@ProveedorId decimal(11, 0),
	@ProveedorNombre char(60),
	@ProveedorPaterno char(60),
	@ProveedorMaterno char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Proveedor
		SET                ProveedorNombre = @ProveedorNombre, ProveedorPaterno = @ProveedorPaterno, ProveedorMaterno = @ProveedorMaterno, FechaUpdate = GETDATE()
		WHERE        (ProveedorId = @ProveedorId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO