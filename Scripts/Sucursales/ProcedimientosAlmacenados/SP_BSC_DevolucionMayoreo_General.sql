USE [Server_Centro]
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DevolucionMayoreo_General')
DROP PROCEDURE SP_BSC_DevolucionMayoreo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_DevolucionMayoreo_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@TicketId decimal(11, 0) ,
	@UsuariosId decimal(11, 0) ,
	@Clienteid decimal(11, 0) ,
	@DevolucionFecha datetime ,
	@DevolucionSubtotal0 money ,
	@DevolucionSubtotal16 money ,
	@DevolucionIva money ,
	@DevolucionDescuento money ,
	@DevolucionTotal money ,
	@TicketTotalLetra varchar(max) ,
	@DevolucionConcepto varchar(50) ,
	@DevolucionAsignado bit ,
	@CortesZRecibosId bigint ,
	@NC_Concepto varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from DevolucionMayoreo a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta Devolucion '+@DevolucionId;
		else
			INSERT INTO DevolucionMayoreo
                         (DevolucionId, CajaId, TicketId, UsuariosId, Clienteid, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionDescuento, DevolucionTotal, TicketTotalLetra, DevolucionConcepto,
                          DevolucionAsignado, CortesZRecibosId, NC_Concepto, FechaInsert)
VALUES        (@DevolucionId,@CajaId,@TicketId,@UsuariosId,@Clienteid,@DevolucionFecha,@DevolucionSubtotal0,@DevolucionSubtotal16,@DevolucionIva,@DevolucionDescuento,@DevolucionTotal,@TicketTotalLetra,@DevolucionConcepto,@DevolucionAsignado,@CortesZRecibosId,@NC_Concepto,
                          GETDATE())
END
GO
