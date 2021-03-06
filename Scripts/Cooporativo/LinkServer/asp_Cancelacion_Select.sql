USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_Cancelacion_Select]    Script Date: 18/02/2019 09:11:43 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_Cancelacion_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
    
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CancelacionId, 
		CajaId, 
		TicketId, 
		UsuarioId, 
		CancelacionFecha, 
		CancelacionSubtotal0, 
		CancelacionSubtotal16, 
		CancelacionIva, 
		CancelacionTotal, 
		CancelacionAsignadoCorte, 
		CorteZId, 
		CancelacionesTotal, 
		TicketMayoreoId
	FROM Cancelacion as can
	where CancelacionFecha between @FechaInicio and @FechaFin
	and CancelacionId not in(SELECT CancelacionId FROM [SERVER-SON].[Server_Apatzingan].[dbo].[Cancelacion]
    where CancelacionFecha between @FechaInicio and @FechaFin and CajaId=can.CajaId)

END
