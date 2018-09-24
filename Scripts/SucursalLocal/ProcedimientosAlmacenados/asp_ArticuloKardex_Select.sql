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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_ArticuloKardex_Select')
DROP PROCEDURE asp_ArticuloKardex_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_ArticuloKardex_Select

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        art.ArticuloCodigo,art.ArticuloCantidad as Existencia, art.ArticuloUltimoCosto,(art.ArticuloUltimoCosto * Iva.IvaFactor) as iva,convert(varchar, GETDATE(),103) as FechaExistencia
FROM            Articulo as art
left join Familia as fam on fam.FamiliaId=art.FamiliaId
left join Iva on Iva.IvaId=fam.IvaId
WHERE art.ArticuloCantidad>0
END
GO
