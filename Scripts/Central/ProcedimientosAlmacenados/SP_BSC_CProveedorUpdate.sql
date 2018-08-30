USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorUpdate]    Script Date: 25/08/2018 12:49:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorUpdate')
DROP PROCEDURE SP_BSC_CProveedorUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorUpdate] 
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T3;
	begin try
		UPDATE       CProveedor
		SET                CProveedorNombre = @CProveedorNombre, CProveedorFecha = @CProveedorFecha, CProveedorActivo = @CProveedorActivo, CProveedorPadreId = @CProveedorPadreId, 
                         CProveedorTieneElementos = @CProveedorTieneElementos, FechaUpdate = GETDATE()
		WHERE        (CProveedorId = @CProveedorId)

		commit transaction T3;
		set @correcto=1
	end try
	begin catch
		rollback transaction T3;
		set @correcto=0
	end catch

	select @correcto resultado
END
