USE [SES_Sincroniza]
GO
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Centro_ActualizaTicketArticuloLocal_Select')
DROP PROCEDURE SP_BSC_Centro_ActualizaTicketArticuloLocal_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Centro_ActualizaTicketArticuloLocal_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TicArt.TicketId
      ,TicArt.CajaId
      ,TicArt.TicketArticuloUltimoIde
      ,TicArt.ArticuloCodigo
      ,TicArt.TarifaId
      ,TicArt.MedidasId
      ,TicArt.TicketArticuloCosto
      ,TicArt.TicketArticuloPrecio
      ,TicArt.TicketArticuloCantidad
      ,TicArt.TicketArticuloCantidadDevolucion
      ,TicArt.TicketArticuloCantidadCancelada
      ,TicArt.TicketArticuloSubtotal
      ,TicArt.TicketArticuloIva
      ,TicArt.TicketArticuloTotalLinea
      ,TicArt.TicketArticuloDescuento
      ,TicArt.TicketArticuloPrecioDescuento
      ,TicArt.TicketArticuloIvaDescuento
      ,TicArt.TicketArticuloTotal
	from SES_AdministradorV1.dbo.TicketArticulo as TicArt
	inner join SES_AdministradorV1.dbo.Ticket as Tic
		on TicArt.TicketId=Tic.TicketId
			and TicArt.CajaId=Tic.CajaId
	where TicketFecha between @FechaInicio and @FechaFin
END
GO
