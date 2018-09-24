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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CortesZRecargas_General')
DROP PROCEDURE SP_BSC_CortesZRecargas_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_CortesZRecargas_General
	-- Add the parameters for the stored procedure here
	@CortesZRecargasId bigint ,
	@CajaId decimal(11, 0) ,
	@CortesZRecargasFecha datetime ,
	@UsuariosId decimal(11, 0) ,
	@CortesZRecargasSub0 money ,
	@CortesZRecargasSub16 money ,
	@CortesZRecargasIva money ,
	@CortesZRecargasTotal money ,
	@FacturaGlobalFolio bigint ,
	@CortesZRecargasFacturado bit ,
	@CortesZRecargasTotalCosto money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(CortesZRecargasId) from CortesZRecargas a where (a.CortesZRecargasId=@CortesZRecargasId and a.CajaId=@CajaId)
	if @Existe>0
			select 0;
		else
			 INSERT INTO CortesZRecargas
                         (CortesZRecargasId, CajaId, CortesZRecargasFecha, UsuariosId, CortesZRecargasSub0, CortesZRecargasSub16, CortesZRecargasIva, CortesZRecargasTotal, FacturaGlobalFolio, CortesZRecargasFacturado, 
                         CortesZRecargasTotalCosto, FechaInsert)
VALUES        (@CortesZRecargasId,@CajaId,@CortesZRecargasFecha,@UsuariosId,@CortesZRecargasSub0,@CortesZRecargasSub16,@CortesZRecargasIva,@CortesZRecargasTotal,@FacturaGlobalFolio,@CortesZRecargasFacturado,@CortesZRecargasTotalCosto,
                          GETDATE());
END
GO
