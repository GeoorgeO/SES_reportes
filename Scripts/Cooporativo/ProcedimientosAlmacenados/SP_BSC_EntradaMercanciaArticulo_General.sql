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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaArticulo_General')
DROP PROCEDURE SP_BSC_EntradaMercanciaArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_EntradaMercanciaArticulo_General 
	-- Add the parameters for the stored procedure here
	@EntradasMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@EntradasMercanciaArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@EntradasMercanciaArticuloCantidad bigint ,
	@EntradasMercanciaArticuloSub0 decimal(18, 2) ,
	@EntradasMercanciaArticuloSub16 decimal(18, 2) ,
	@EntradasMercanciaArticuloIva decimal(18, 2) ,
	@EntradasMercanciaArticuloTotal decimal(18, 2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(EntradasMercanciaId) from EntradaMercanciaArticulo a where (a.EntradasMercanciaId=@EntradasMercanciaId and a.SucursalesId=@SucursalesId)
	if @Existe>0
			select 'Ya existe esta Entrada de Mercancia articulo '+@EntradasMercanciaId;
		else
			INSERT INTO EntradaMercanciaArticulo
                         (EntradasMercanciaId, SucursalesId, EntradasMercanciaArticuloUltimoIde, ArticuloCodigo, EntradasMercanciaArticuloCantidad, EntradasMercanciaArticuloSub0, EntradasMercanciaArticuloSub16, 
                         EntradasMercanciaArticuloIva, EntradasMercanciaArticuloTotal, FechaInsert)
VALUES        (@EntradasMercanciaId,@SucursalesId,@EntradasMercanciaArticuloUltimoIde,@ArticuloCodigo,@EntradasMercanciaArticuloCantidad,@EntradasMercanciaArticuloSub0,@EntradasMercanciaArticuloSub16,@EntradasMercanciaArticuloIva,@EntradasMercanciaArticuloTotal,
                          GETDATE())
END
GO
