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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_RecibosRemisiones_General')
DROP PROCEDURE SP_BSC_RecibosRemisiones_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_RecibosRemisiones_General
	-- Add the parameters for the stored procedure here
	@RecibosId bigint ,
	@TicketId decimal(11, 0) ,
	@CajaId decimal(11, 0) ,
	@RecibosTotal decimal(18, 2) ,
	@ReciboTotalLetra varchar(max) ,
	@ReciboFecha datetime ,
	@ClienteId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@DocumentosId bigint ,
	@ReciboConcepto varchar(100) ,
	@CortesZRecibosId bigint NULL,
	@FormasdePagoCobranzaId bigint ,
	@RecibosAsignado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(RecibosId) from RecibosRemisiones a where (a.RecibosId=@RecibosId )
	if @Existe>0
			select 0;
		else
			INSERT INTO RecibosRemisiones
                         (RecibosId, TicketId, CajaId, RecibosTotal, ReciboTotalLetra, ReciboFecha, ClienteId, UsuariosId, DocumentosId, ReciboConcepto, CortesZRecibosId, FormasdePagoCobranzaId, RecibosAsignado, FechaInsert)
VALUES        (@RecibosId,@TicketId,@CajaId,@RecibosTotal,@ReciboTotalLetra,@ReciboFecha,@ClienteId,@UsuariosId,@DocumentosId,@ReciboConcepto,@CortesZRecibosId,@FormasdePagoCobranzaId,@RecibosAsignado,
                          GETDATE())
END
GO
