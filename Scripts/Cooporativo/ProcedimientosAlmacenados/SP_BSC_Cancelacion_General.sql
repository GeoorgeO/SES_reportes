
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Cancelacion_General')
DROP PROCEDURE SP_BSC_Cancelacion_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Cancelacion_General
	-- Add the parameters for the stored procedure here
	@CancelacionId bigint,
	@CajaId decimal(11, 0),
	@TicketId bigint,
	@UsuarioId decimal(11, 0),
	@CancelacionFecha datetime,
	@CancelacionSubtotal0 money,
	@CancelacionSubtotal16 money,
	@CancelacionIva money,
	@CancelacionTotal money,
	@CancelacionAsignadoCorte bit,
	@CorteZId bigint,
	@CancelacionesTotal bit,
	@TicketMayoreoId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CancelacionId) from Cancelacion a where (a.CancelacionId=@CancelacionId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			 INSERT INTO Cancelacion
                         (CancelacionId, CajaId, TicketId, UsuarioId, CancelacionFecha, CancelacionSubtotal0, CancelacionSubtotal16, CancelacionIva, CancelacionTotal, CancelacionAsignadoCorte, CorteZId, CancelacionesTotal, TicketMayoreoId, 
                         FechaInsert)
			VALUES        (@CancelacionId,@CajaId,@TicketId,@UsuarioId,@CancelacionFecha,@CancelacionSubtotal0,@CancelacionSubtotal16,@CancelacionIva,@CancelacionTotal,@CancelacionAsignadoCorte,@CorteZId,@CancelacionesTotal,@TicketMayoreoId,
									  GETDATE());
END
GO
