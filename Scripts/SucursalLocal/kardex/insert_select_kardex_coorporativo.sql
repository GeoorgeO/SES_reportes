INSERT INTO [SERVER-SON].Server_Calzada.dbo.ArticuloKardex
		(ArticuloCodigo, Existencia, ArticuloCosto, ArticuloIVA, FechaExistencia, FechaInsert)
(select ArticuloCodigo,Existencia, ArticuloCosto, ArticuloIVA, FechaExistencia,convert(date,getdate())
from ArticuloKardex 
where FechaExistencia between '20180101' and '20190131'
and rtrim(ltrim(ArticuloCodigo))+convert(varchar(50),convert(date,FechaExistencia)) not in (select rtrim(ltrim(ArticuloCodigo))+convert(varchar(50),convert(date,FechaExistencia)) from [SERVER-SON].Server_Calzada.dbo.ArticuloKardex where FechaExistencia between '20180101' and '20190131'))