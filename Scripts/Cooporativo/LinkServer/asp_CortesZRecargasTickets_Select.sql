USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZRecargasTickets_Select]    Script Date: 18/02/2019 09:52:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZRecargasTickets_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        CRdet.CortesZRecargasId, CRdet.CajaId, CRdet.CortesZRecargasTicketsInicio, CRdet.CortesZRecargasTicketsFin
	FROM            CortesZRecargasTickets as CRdet
	left join CortesZRecargas as CR on CR.CajaId=CRdet.CajaId and CR.CortesZRecargasId=CRdet.CortesZRecargasId
	where CR.CortesZRecargasFecha between @FechaInicio and @FechaFin
	and CRdet.CortesZRecargasId not in (
	SELECT CRdetS.CortesZRecargasId
	FROM [SERVER-SON].[Server_Apatzingan].[dbo].[CortesZRecargasTickets] as CRdetS
	left join [SERVER-SON].[Server_Apatzingan].[dbo].[CortesZRecargas] as CRS on CRS.CajaId=CRdetS.CajaId and CRS.CortesZRecargasId=CRdetS.CortesZRecargasId
	where CRS.CortesZRecargasFecha between @FechaInicio and @FechaFin and CRS.CajaId=CRdet.CajaId)
END
