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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CancelacionArticulo_General')
DROP PROCEDURE SP_BSC_CancelacionArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CancelacionArticulo_General
	-- Add the parameters for the stored procedure here
	@CancelacionId bigint,
	@CajaId decimal(11, 0),
	@CancelacionArticuloUltimoIde bigint,
	@TicketId bigint,
	@ArticuloCodigo char(40),
	@CancelacionArticuloPrecio money,
	@CancelacionArticuloCantidad bigint,
	@CancelacionArticuloSubtotal money,
	@CancelacionArticuloIva money,
	@CancelacionArticuloTotalLinea money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CancelacionId) from CancelacionArticulo a where (a.CancelacionId=@CancelacionId and a.CajaId=@CajaId and a.CancelacionArticuloUltimoIde=@CancelacionArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			 INSERT INTO CancelacionArticulo
                         (CancelacionId, CajaId, CancelacionArticuloUltimoIde, TicketId, ArticuloCodigo, CancelacionArticuloPrecio, CancelacionArticuloCantidad, CancelacionArticuloSubtotal, CancelacionArticuloIva, CancelacionArticuloTotalLinea, 
                         FechaInsert)
				VALUES        (@CancelacionId,@CajaId,@CancelacionArticuloUltimoIde,@TicketId,@ArticuloCodigo,@CancelacionArticuloPrecio,@CancelacionArticuloCantidad,@CancelacionArticuloSubtotal,@CancelacionArticuloIva,@CancelacionArticuloTotalLinea,
										  GETDATE());
END
GO
