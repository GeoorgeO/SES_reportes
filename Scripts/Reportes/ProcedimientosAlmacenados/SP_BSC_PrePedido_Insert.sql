USE [SES_Reportes]
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_PrePedido_Insert')
DROP PROCEDURE SP_BSC_PrePedido_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_PrePedido_Insert
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion	char(200),
	@ArticuloCostoReposicion	decimal(10, 4),
	@FamiliaNombre	char(60),
	@VAlmacen	decimal(10, 4),
	@EAlmacen	decimal(10, 4),
	@VApatzingan	decimal(10, 4),
	@EApatzingan	decimal(10, 4),
	@VCalzada	decimal(10, 4),
	@ECalzada	decimal(10, 4),
	@VCentro	decimal(10, 4),
	@ECentro	decimal(10, 4),
	@VCostaRica	decimal(10, 4),
	@ECostaRica	decimal(10, 4),
	@VEstocolmo	decimal(10, 4),
	@EEstocolmo	decimal(10, 4),
	@VFCoVilla	decimal(10, 4),
	@EFcoVilla	decimal(10, 4),
	@VLombardia	decimal(10, 4),
	@ELombardia	decimal(10, 4),
	@VReyes	decimal(10, 4),
	@EReyes	decimal(10, 4),
	@VMorelos	decimal(10, 4),
	@EMorelos	decimal(10, 4),
	@VNvaItalia	decimal(10, 4),
	@ENvaItalia	decimal(10, 4),
	@VPaseo	decimal(10, 4),
	@EPaseo	decimal(10, 4),
	@VSarabiaI	decimal(10, 4),
	@ESarabiaI	decimal(10, 4),
	@VSarabiaII	decimal(10, 4),
	@ESarabiaII	decimal(10, 4),
	@Total	decimal(10, 4),
	@PSugerido	decimal(10, 4),
	@Pedido	decimal(10, 4)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	delete from Pre_Pedidos

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Pre_Pedidos
                         (ArticuloCodigo, ArticuloDescripcion, ArticuloCostoReposicion, FamiliaNombre, VAlmacen, EAlmacen, VApatzingan, EApatzingan, VCalzada, ECalzada, VCentro, ECentro, VCostaRica, ECostaRica, VEstocolmo, 
                         EEstocolmo, VFCoVilla, EFcoVilla, VLombardia, ELombardia, VReyes, EReyes, VMorelos, EMorelos, VNvaItalia, ENvaItalia, VPaseo, EPaseo, VSarabiaI, ESarabiaI, VSarabiaII, ESarabiaII, Total, PSugerido, Pedido)
	VALUES        (@ArticuloCodigo,@ArticuloDescripcion,@ArticuloCostoReposicion,@FamiliaNombre,@VAlmacen,@EAlmacen,@VApatzingan,@EApatzingan,@VCalzada,@ECalzada,@VCentro,@ECentro,@VCostaRica,@ECostaRica,@VEstocolmo,@EEstocolmo,@VFCoVilla,@EFcoVilla,@VLombardia,@ELombardia,@VReyes,@EReyes,@VMorelos,@EMorelos,@VNvaItalia,@ENvaItalia,@VPaseo,@EPaseo,@VSarabiaI,@ESarabiaI,@VSarabiaII,@ESarabiaII,@Total,@PSugerido,@Pedido)
END
GO
