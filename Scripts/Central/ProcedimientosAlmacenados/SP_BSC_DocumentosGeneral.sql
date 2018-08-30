USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosGeneral]    Script Date: 25/08/2018 12:53:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosGeneral')
DROP PROCEDURE SP_BSC_DocumentosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosGeneral] 
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

	begin transaction T1;
	begin try

		declare @Existe int
		select @Existe = count(DocumentosId) from Documentos a where (a.DocumentosId=@DocumentosId)

		if @Existe>0
			Exec dbo.SP_BSC_DocumentosUpdate @DocumentosId,
			@DocumentosNombre;
		else
			Exec dbo.SP_BSC_DocumentosInsert @DocumentosId,
			@DocumentosNombre;
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
