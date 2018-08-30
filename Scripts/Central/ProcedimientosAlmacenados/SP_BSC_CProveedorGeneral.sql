USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorGeneral]    Script Date: 25/08/2018 12:52:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorGeneral')
DROP PROCEDURE SP_BSC_CProveedorGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorGeneral]
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

	begin transaction T1;
	begin try

		declare @Existe int
		select @Existe = count(CProveedorId) from CProveedor a where (a.CProveedorId=@CProveedorId)

		if @Existe>0
			Exec dbo.SP_BSC_CProveedorUpdate @CProveedorId,
			@CProveedorNombre,
			@CProveedorFecha,
			@CProveedorActivo,
			@CProveedorPadreId,
			@CProveedorTieneElementos;
		else
			Exec dbo.SP_BSC_CProveedorInsert @CProveedorId,
			@CProveedorNombre,
			@CProveedorFecha,
			@CProveedorActivo,
			@CProveedorPadreId,
			@CProveedorTieneElementos;
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
