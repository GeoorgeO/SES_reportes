USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_TicketArticulo_Select]    Script Date: 18/02/2019 05:06:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_TicketArticulo_Select]
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
	from TicketArticulo as TicArt
	inner join Ticket as Tic
		on TicArt.TicketId=Tic.TicketId
			and TicArt.CajaId=Tic.CajaId
	where Tic.TicketFecha between @FechaInicio and @FechaFin
	and rtrim(TicArt.TicketId)+rtrim(TicArt.CajaId)+rtrim(TicArt.TicketArticuloUltimoIde) not in (
	SELECT rtrim(TicArtS.TicketId)+rtrim(TicArtS.CajaId)+rtrim(TicArtS.TicketArticuloUltimoIde)
      
	from [SERVER-SON].[Server_Apatzingan].[dbo].TicketArticulo as TicArtS
	inner join [SERVER-SON].[Server_Apatzingan].[dbo].Ticket as TicS
		on TicArtS.TicketId=TicS.TicketId
			and TicArtS.CajaId=TicS.CajaId
	where TicS.TicketFecha between @FechaInicio and @FechaFin
	and TicArt.CajaId=TicArtS.CajaId
	and TicArt.TicketArticuloUltimoIde=TicArtS.TicketArticuloUltimoIde
	)
END
