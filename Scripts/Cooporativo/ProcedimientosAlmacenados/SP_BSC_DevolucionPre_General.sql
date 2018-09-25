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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionPre_General')
DROP PROCEDURE SP_BSC_DevolucionPre_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionPre_General
	-- Add the parameters for the stored procedure here
	@DevolucionPreId bigint ,
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@DevolucionPreFecha datetime ,
	@DevolucionPreTArticulos bigint ,
	@UsuarioId decimal(11, 0) ,
	@VendedorId decimal(11, 0) ,
	@DevolucionPreSub0 money ,
	@DevolucionPreSub16 money ,
	@DevolucionPreIva money ,
	@DevolucionPreTotal money ,
	@DevolucionPreProcesada bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionPreId) from DevolucionPre a where (a.DevolucionPreId=@DevolucionPreId )
	if @Existe>0
			select 0;
		else
			INSERT INTO DevolucionPre
                         (DevolucionPreId, TicketId, CajaId, DevolucionPreFecha, DevolucionPreTArticulos, UsuarioId, VendedorId, DevolucionPreSub0, DevolucionPreSub16, DevolucionPreIva, DevolucionPreTotal, 
                         DevolucionPreProcesada,FechaInsert)
			VALUES        (@DevolucionPreId,@TicketId,@CajaId,@DevolucionPreFecha,@DevolucionPreTArticulos,@UsuarioId,@VendedorId,@DevolucionPreSub0,@DevolucionPreSub16,@DevolucionPreIva,@DevolucionPreTotal,@DevolucionPreProcesada,getdate())
END
GO
