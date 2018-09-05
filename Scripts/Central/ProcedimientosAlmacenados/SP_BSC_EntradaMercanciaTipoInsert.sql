USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoInsert]    Script Date: 25/08/2018 12:54:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoInsert')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<EntradaMercanciaTipo,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoInsert]  
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T2;
	begin try
		INSERT INTO EntradaMercanciaTipo
                         (EntradaMercanciaTipoId, EntradaMercanciaTipoDescripcion, FechaInsert)
		VALUES        (@EntradaMercanciaTipoId,@EntradaMercanciaTipoDescripcion, GETDATE())

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
