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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Devolucion_General')
DROP PROCEDURE SP_BSC_Devolucion_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_Devolucion_General
	-- Add the parameters for the stored procedure here
	@DevolucionId bigint ,
	@CajaId decimal(11, 0) ,
	@TicketId bigint ,
	@UsuariosId decimal(11, 0) ,
	@DevolucionFecha datetime ,
	@DevolucionSubtotal0 money ,
	@DevolucionSubtotal16 money ,
	@DevolucionIva money ,
	@DevolucionTotal money ,
	@DevolucionAsignadoCorte bit ,
	@CorteZId bigint 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(DevolucionId) from Devolucion a where (a.DevolucionId=@DevolucionId and a.CajaId=@CajaId)
	if @Existe>0
			select 'Ya existe esta Devolucion '+@DevolucionId;
		else
			INSERT INTO Devolucion
                         (DevolucionId, CajaId, TicketId, UsuariosId, DevolucionFecha, DevolucionSubtotal0, DevolucionSubtotal16, DevolucionIva, DevolucionTotal, DevolucionAsignadoCorte, CorteZId,FechaInsert)
VALUES        (@DevolucionId,@CajaId,@TicketId,@UsuariosId,@DevolucionFecha,@DevolucionSubtotal0,@DevolucionSubtotal16,@DevolucionIva,@DevolucionTotal,@DevolucionAsignadoCorte,@CorteZId,GETDATE()) 
END
GO
