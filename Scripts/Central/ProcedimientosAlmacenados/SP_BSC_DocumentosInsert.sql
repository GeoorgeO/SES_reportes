USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosInsert]    Script Date: 25/08/2018 12:52:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosInsert')
DROP PROCEDURE SP_BSC_DocumentosInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosInsert] 
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T2;
	begin try
		INSERT INTO Documentos
                         (DocumentosId, DocumentosNombre, FechaInsert)
		VALUES        (@DocumentosId,@DocumentosNombre, GETDATE())

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
