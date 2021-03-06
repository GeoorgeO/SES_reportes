USE [SES_ApatzinganV5]
GO
/****** Object:  StoredProcedure [dbo].[asp_CortesZRecibos_Select]    Script Date: 18/02/2019 10:30:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[asp_CortesZRecibos_Select]
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        czr.CortesZRecibosId, czr.CortesZRecibosFecha, czr.UsuariosId, czr.CortesZRecibosTotal
	FROM            CortesZRecibos as czr
	WHERE        (czr.CortesZRecibosFecha BETWEEN @FechaInicio AND @FechaFin)
	and czr.CortesZRecibosId not in
	(SELECT czrS.CortesZRecibosId
	FROM          [SERVER-SON].[Server_Apatzingan].[dbo].[CortesZRecibos] as czrS
	WHERE        (czrS.CortesZRecibosFecha BETWEEN @FechaInicio AND @FechaFin))
END
