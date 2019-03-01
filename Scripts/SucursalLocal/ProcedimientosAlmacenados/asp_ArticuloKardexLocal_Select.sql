IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_ArticuloKardexLocal_Select')
DROP PROCEDURE asp_ArticuloKardexLocal_Select
GO
CREATE PROCEDURE asp_ArticuloKardexLocal_Select

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from ArticuloKardex
	--where  CONVERT(date,FechaExistencia ,103)= convert(date, GETDATE(),103) 
	
	insert into ArticuloKardex (ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIVA,FechaExistencia,FechaInsert)
	SELECT  art.ArticuloCodigo,art.ArticuloCantidad, art.ArticuloUltimoCosto,(art.ArticuloUltimoCosto * Iva.IvaFactor) as iva, getdate() ,getdate()
	FROM            Articulo as art
	left join Familia as fam on fam.FamiliaId=art.FamiliaId
	left join Iva on Iva.IvaId=fam.IvaId
	WHERE  art.ArticuloCantidad>0
end
go


