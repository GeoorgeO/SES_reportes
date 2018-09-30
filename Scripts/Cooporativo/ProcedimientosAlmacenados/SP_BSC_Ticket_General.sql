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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Ticket_General')
DROP PROCEDURE SP_BSC_Ticket_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Ticket_General 
	-- Add the parameters for the stored procedure here
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@UsuarioId decimal(11, 0) ,
	@TicketFecha datetime ,
	/*@TicketHora datetime ,*/
	@TicketSubtotal0 money ,
	@TicketSubtotal16 money ,
	@TicketIva money ,
	@TicketTotal money ,
	@CorteZId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(TicketId) from Ticket a where (a.TicketId=@TicketId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			INSERT INTO Ticket
                         (TicketId, CajaId, UsuarioId, TicketFecha, /*TicketHora,*/ TicketSubtotal0, TicketSubtotal16, TicketIva, TicketTotal, CorteZId, FechaInsert)
VALUES        (@TicketId,@CajaId,@UsuarioId,@TicketFecha,/*@TicketHora,*/@TicketSubtotal0,@TicketSubtotal16,@TicketIva,@TicketTotal,@CorteZId, GETDATE())
END
GO
