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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercanciaArticulo_General')
DROP PROCEDURE SP_BSC_SalidaMercanciaArticulo_General
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercanciaArticulo_General
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaId bigint ,
	@SucursalesId decimal(11, 0) ,
	@SalidaMercanciaArticuloUltimoIde bigint ,
	@ArticuloCodigo char(40) ,
	@SalidaMercanciaArticuloCantidad bigint ,
	@SalidaMercanciaArticuloSub0 decimal(18, 2) ,
	@SalidaMercanciaArticuloSub16 decimal(18, 2) ,
	@SalidaMercanciaArticuloIva decimal(18, 2) ,
	@SalidaMercanciaArticuloTotal decimal(18, 2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Existe int
	declare @mensaje varchar(50)
	
	select @Existe = count(SalidaMercanciaId) from SalidaMercanciaArticulo a where (a.SalidaMercanciaId=@SalidaMercanciaId and a.SucursalesId=@SucursalesId and a.SalidaMercanciaArticuloUltimoIde=@SalidaMercanciaArticuloUltimoIde)
	if @Existe>0
			select 0;
		else
			INSERT INTO SalidaMercanciaArticulo
                         (SalidaMercanciaId, SucursalesId, SalidaMercanciaArticuloUltimoIde, ArticuloCodigo, SalidaMercanciaArticuloCantidad, SalidaMercanciaArticuloSub0, SalidaMercanciaArticuloSub16, SalidaMercanciaArticuloIva, 
                         SalidaMercanciaArticuloTotal, FechaInsert)
VALUES        (@SalidaMercanciaId,@SucursalesId,@SalidaMercanciaArticuloUltimoIde,@ArticuloCodigo,@SalidaMercanciaArticuloCantidad,@SalidaMercanciaArticuloSub0,@SalidaMercanciaArticuloSub16,@SalidaMercanciaArticuloIva,@SalidaMercanciaArticuloTotal,
                          GETDATE())
END
GO
