select top 1000 Art.ArticuloCodigo,
	ArticuloDescripcion,
	isnull(ArtKar.Existencia,0) as Existencia,
	convert(money,isnull(TV.Venta,0)) as Venta,
	convert(money,isnull(TC.Costo,0)) as Costo,
	(convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))) as SI,
	(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))) as SF,
	case when (((convert(money,isnull(Si.Venta,0))-convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)=0 then 0 
		else (convert(money,isnull(TV.Venta,0))/(((convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)) 
		end as IR,--,(TV.Venta/(((Si.Venta-ArtKar.Existencia)+(Sf.Venta-ArtKar.Existencia))/2)) as IR
	case when (((convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)=0 then 0 
		else (convert(money,isnull(TC.Costo,0))/(((convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)) 
		end as IC
from Central.dbo.Articulo as Art
left join (
	select existencia,ArticuloCodigo,FechaExistencia
	from Server_Centro.dbo.ArticuloKardex 
	where ArticuloCodigo+convert(varchar(15),FechaExistencia) in(
		select ArticuloCodigo+convert(varchar(15),max(FechaExistencia)) 
		from Server_Centro.dbo.ArticuloKardex  
		group by ArticuloCodigo)) as ArtKar on Art.ArticuloCodigo=ArtKar.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCantidad) as Venta 
	from Server_Centro.dbo.TicketArticulo as TicArt 
		inner join Server_Centro.dbo.Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between '20180101' and '20180531' group by TicArt.ArticuloCodigo) as TV on TV.ArticuloCodigo=Art.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCantidad) as Venta 
	from Server_Centro.dbo.TicketArticulo as TicArt 
		inner join Server_Centro.dbo.Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between '20180101' and CONVERT (date, GETDATE()) group by TicArt.ArticuloCodigo) as Si on Si.ArticuloCodigo=Art.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCantidad) as Venta 
	from Server_Centro.dbo.TicketArticulo as TicArt 
		inner join Server_Centro.dbo.Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between '20180531' and CONVERT (date, GETDATE()) group by TicArt.ArticuloCodigo) as Sf on Sf.ArticuloCodigo=Art.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCosto*TicketArticuloCantidad) as Costo 
	from Server_Centro.dbo.TicketArticulo as TicArt 
		inner join Server_Centro.dbo.Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between '20180101' and '20180531' group by TicArt.ArticuloCodigo) as TC on TC.ArticuloCodigo=Art.ArticuloCodigo
order by IR desc




/*
select top 1000 * from Server_Centro.dbo.TicketArticulo

select top 1000 * from Server_Centro.dbo.ArticuloKardex

select max(FechaExistencia) from Server_Centro.dbo.ArticuloKardex where ArticuloCodigo='0156237'
*/