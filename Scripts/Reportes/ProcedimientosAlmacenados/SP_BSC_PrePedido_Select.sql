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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_PrePedido_Select')
DROP PROCEDURE SP_BSC_PrePedido_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_PrePedido_Select
	-- Add the parameters for the stored procedure here
	@FechaInicio varchar(20),
	@FechaFin varchar(20),
	@ProveedorId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
select Art.ArticuloCodigo,
    Art.ArticuloDescripcion,Art.ArticuloCostoReposicion,Fam.FamiliaNombre,
	( isnull(ticalm.nticket,0) + isnull(ticmayalm.nticket,0) ) -  ( isnull(devalm.ndev,0) + isnull(devmayalm.ndev,0) )  as TVentasAlmacen,
	isnull(ExiAlm.Existencia,0) as ExisAlmacen,
	( isnull(ticApa.nticket,0) + isnull(ticmayApa.nticket,0) ) -  ( isnull(devApa.ndev,0) + isnull(devmayApa.ndev,0) )  as TVentasApatzingan,
	isnull(ExiApa.Existencia,0) as ExisApatzingan,
	( isnull(ticCal.nticket,0) + isnull(ticmayCal.nticket,0) ) -  ( isnull(devCal.ndev,0) + isnull(devmayCal.ndev,0) )  as TVentasCalzada,
	isnull(ExiCal.Existencia,0) as ExisCalzada,
	( isnull(ticCentro.nticket,0) + isnull(ticmayCentro.nticket,0) ) -  ( isnull(devCentro.ndev,0) + isnull(devmayCentro.ndev,0) )  as TVentasCentro,
	isnull(ExiCen.Existencia,0) as ExisCentro,
	( isnull(ticCos.nticket,0) + isnull(ticmayCos.nticket,0) ) -  ( isnull(devCos.ndev,0) + isnull(devmayCos.ndev,0) )  as TVentasCostaRica,
	isnull(ExiCos.Existencia,0) as ExisCostaRica,
	( isnull(ticest.nticket,0) + isnull(ticmayest.nticket,0) ) -  ( isnull(devest.ndev,0) + isnull(devmayest.ndev,0) )  as TVentasEstocolmo,
	isnull(ExiEst.Existencia,0) as ExisEstocolmo,
    ( isnull(tic.nticket,0) + isnull(ticmay.nticket,0) ) -  ( isnull(dev.ndev,0) + isnull(devmay.ndev,0) )  as TVentasFcoVilla,
	isnull(ExiFcoV.Existencia,0) as ExisFcoVilla,
    ( isnull(ticLom.nticket,0) + isnull(ticmayLom.nticket,0) ) -  ( isnull(devLom.ndev,0) + isnull(devmayLom.ndev,0) )  as TVentasLombardia,
	isnull(ExiLom.Existencia,0) as ExisLombardia,
	( isnull(ticRey.nticket,0) + isnull(ticmayRey.nticket,0) ) -  ( isnull(devRey.ndev,0) + isnull(devmayRey.ndev,0) )  as TVentasLosReyes,
	isnull(ExiRey.Existencia,0) as ExisLosReyes,
	( isnull(ticMor.nticket,0) + isnull(ticmayMor.nticket,0) ) -  ( isnull(devMor.ndev,0) + isnull(devmayMor.ndev,0) )  as TVentasMorelos,
	isnull(ExiMor.Existencia,0) as ExisMorelos,
	( isnull(ticNva.nticket,0) + isnull(ticmayNva.nticket,0) ) -  ( isnull(devNva.ndev,0) + isnull(devmayNva.ndev,0) )  as TVentasNvaItalia,
	isnull(ExiNva.Existencia,0) as ExisNvaItalia,
	( isnull(ticPas.nticket,0) + isnull(ticmayPas.nticket,0) ) -  ( isnull(devPas.ndev,0) + isnull(devmayPas.ndev,0) )  as TVentasPaseo,
	isnull(ExiPas.Existencia,0) as ExisPaseo,
	( isnull(ticSa1.nticket,0) + isnull(ticmaySa1.nticket,0) ) -  ( isnull(devSa1.ndev,0) + isnull(devmaySa1.ndev,0) )  as TVentasSarabiaI,
	isnull(ExiSar1.Existencia,0) as ExisSarabiaI,
	( isnull(ticSa2.nticket,0) + isnull(ticmaySa2.nticket,0) ) -  ( isnull(devSa2.ndev,0) + isnull(devmaySa2.ndev,0) )  as TVentasSarabiaII,
	isnull(ExiSar2.Existencia,0) as ExisSarabiaII
from central.dbo.Articulo as Art
    inner join central.dbo.ArticuloProveedores as artPrv on artPrv.ArticuloCodigo=Art.ArticuloCodigo
	inner join central.dbo.Familia as fam on fam.FamiliaId= Art.FamiliaId
	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Almacen.dbo.ticket as t
        inner join Server_Almacen.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticalm
        on ticalm.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Almacen.dbo.devolucion as d
        inner join Server_Almacen.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Almacen.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devalm on devalm.ArticuloCodigo=ticalm.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Almacen.dbo.TicketMayoreo as t
        inner join Server_Almacen.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayalm on ticmayalm.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Almacen.dbo.DevolucionMayoreo as d
        inner join Server_Almacen.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Almacen.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayalm on devmayalm.ArticuloCodigo=ticmayalm.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Almacen.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Almacen.dbo.Articulokardex)) as ExiAlm
	on Art.ArticuloCodigo=ExiAlm.ArticuloCodigo

    left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_FcoVilla.dbo.ticket as t
        inner join Server_FcoVilla.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as tic
        on tic.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_FcoVilla.dbo.devolucion as d
        inner join Server_FcoVilla.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_FcoVilla.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as dev on dev.ArticuloCodigo=tic.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_FcoVilla.dbo.TicketMayoreo as t
        inner join Server_FcoVilla.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmay on ticmay.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_FcoVilla.dbo.DevolucionMayoreo as d
        inner join Server_FcoVilla.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_FcoVilla.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmay on devmay.ArticuloCodigo=ticmay.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_FcoVilla.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_FcoVilla.dbo.Articulokardex)) as ExiFcoV
	on Art.ArticuloCodigo=ExiFcoV.ArticuloCodigo

    left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Centro.dbo.ticket as t
        inner join Server_Centro.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticCentro
        on ticCentro.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Centro.dbo.devolucion as d
        inner join Server_Centro.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Centro.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devCentro on devCentro.ArticuloCodigo=ticCentro.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Centro.dbo.TicketMayoreo as t
        inner join Server_Centro.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayCentro on ticmayCentro.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Centro.dbo.DevolucionMayoreo as d
        inner join Server_Centro.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Centro.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayCentro on devmayCentro.ArticuloCodigo=ticmayCentro.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Centro.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Centro.dbo.Articulokardex)) as ExiCen
	on Art.ArticuloCodigo=ExiCen.ArticuloCodigo

    left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Apatzingan.dbo.ticket as t
        inner join Server_Apatzingan.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticApa
        on ticApa.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Apatzingan.dbo.devolucion as d
        inner join Server_Apatzingan.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Apatzingan.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devApa on devApa.ArticuloCodigo=ticApa.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Apatzingan.dbo.TicketMayoreo as t
        inner join Server_Apatzingan.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayApa on ticmayApa.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Apatzingan.dbo.DevolucionMayoreo as d
        inner join Server_Apatzingan.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Apatzingan.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayApa on devmayApa.ArticuloCodigo=ticmayApa.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from server_Apatzingan.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from server_Apatzingan.dbo.Articulokardex)) as ExiApa
	on Art.ArticuloCodigo=ExiApa.ArticuloCodigo

    left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Calzada.dbo.ticket as t
        inner join Server_Calzada.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticCal
        on ticCal.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Calzada.dbo.devolucion as d
        inner join Server_Calzada.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Calzada.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devCal on devCal.ArticuloCodigo=ticCal.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Calzada.dbo.TicketMayoreo as t
        inner join Server_Calzada.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayCal on ticmayCal.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Calzada.dbo.DevolucionMayoreo as d
        inner join Server_Calzada.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Calzada.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayCal on devmayCal.ArticuloCodigo=ticmayCal.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Calzada.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Calzada.dbo.Articulokardex)) as ExiCal
	on Art.ArticuloCodigo=ExiCal.ArticuloCodigo

    left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_CostaRica.dbo.ticket as t
        inner join Server_CostaRica.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticCos
        on ticCos.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_CostaRica.dbo.devolucion as d
        inner join Server_CostaRica.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_CostaRica.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devCos on devCos.ArticuloCodigo=ticCos.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_CostaRica.dbo.TicketMayoreo as t
        inner join Server_CostaRica.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayCos on ticmayCos.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_CostaRica.dbo.DevolucionMayoreo as d
        inner join Server_CostaRica.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_CostaRica.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayCos on devmayCos.ArticuloCodigo=ticmayCos.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_CostaRica.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_CostaRica.dbo.Articulokardex)) as ExiCos
	on Art.ArticuloCodigo=ExiCos.ArticuloCodigo

    left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Lombardia.dbo.ticket as t
        inner join Server_Lombardia.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticLom
        on ticLom.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Lombardia.dbo.devolucion as d
        inner join Server_Lombardia.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Lombardia.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devLom on devLom.ArticuloCodigo=ticLom.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Lombardia.dbo.TicketMayoreo as t
        inner join Server_Lombardia.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayLom on ticmayLom.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Lombardia.dbo.DevolucionMayoreo as d
        inner join Server_Lombardia.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Lombardia.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayLom on devmayLom.ArticuloCodigo=ticmayLom.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Lombardia.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Lombardia.dbo.Articulokardex)) as ExiLom
	on Art.ArticuloCodigo=ExiLom.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Estocolmo.dbo.ticket as t
        inner join Server_Estocolmo.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticest
        on ticest.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Estocolmo.dbo.devolucion as d
        inner join Server_Estocolmo.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Estocolmo.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devest on dev.ArticuloCodigo=ticest.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Estocolmo.dbo.TicketMayoreo as t
        inner join Server_Estocolmo.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayest on ticmayest.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Estocolmo.dbo.DevolucionMayoreo as d
        inner join Server_Estocolmo.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Estocolmo.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayest on devmayest.ArticuloCodigo=ticmayest.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Estocolmo.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Estocolmo.dbo.Articulokardex)) as ExiEst
	on Art.ArticuloCodigo=ExiEst.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_LosReyes.dbo.ticket as t
        inner join Server_LosReyes.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticRey
        on ticRey.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_LosReyes.dbo.devolucion as d
        inner join Server_LosReyes.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_LosReyes.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devRey on devRey.ArticuloCodigo=ticRey.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_LosReyes.dbo.TicketMayoreo as t
        inner join Server_LosReyes.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayRey on ticmayRey.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_LosReyes.dbo.DevolucionMayoreo as d
        inner join Server_LosReyes.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_LosReyes.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayRey on devmayRey.ArticuloCodigo=ticmayRey.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_LosReyes.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_LosReyes.dbo.Articulokardex)) as ExiRey
	on Art.ArticuloCodigo=ExiRey.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Morelos.dbo.ticket as t
        inner join Server_Morelos.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticMor
        on ticMor.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Morelos.dbo.devolucion as d
        inner join Server_Morelos.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Morelos.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devMor on devMor.ArticuloCodigo=ticMor.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Morelos.dbo.TicketMayoreo as t
        inner join Server_Morelos.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayMor on ticmayMor.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Morelos.dbo.DevolucionMayoreo as d
        inner join Server_Morelos.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Morelos.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayMor on devmayMor.ArticuloCodigo=ticmayMor.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Morelos.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Morelos.dbo.Articulokardex)) as ExiMor
	on Art.ArticuloCodigo=ExiMor.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_NvaItalia.dbo.ticket as t
        inner join Server_NvaItalia.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticNva
        on ticNva.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_NvaItalia.dbo.devolucion as d
        inner join Server_NvaItalia.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_NvaItalia.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devNva on devNva.ArticuloCodigo=ticNva.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_NvaItalia.dbo.TicketMayoreo as t
        inner join Server_NvaItalia.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayNva on ticmayNva.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_NvaItalia.dbo.DevolucionMayoreo as d
        inner join Server_NvaItalia.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_NvaItalia.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayNva on devmayNva.ArticuloCodigo=ticmayNva.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_NvaItalia.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_NvaItalia.dbo.Articulokardex)) as ExiNva
		on Art.ArticuloCodigo=ExiNva.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Paseo.dbo.ticket as t
        inner join Server_Paseo.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticPas
        on ticPas.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Paseo.dbo.devolucion as d
        inner join Server_Paseo.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Paseo.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devPas on devPas.ArticuloCodigo=ticPas.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_Paseo.dbo.TicketMayoreo as t
        inner join Server_Paseo.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmayPas on ticmayPas.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_Paseo.dbo.DevolucionMayoreo as d
        inner join Server_Paseo.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_Paseo.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmayPas on devmayPas.ArticuloCodigo=ticmayPas.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_Paseo.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_Paseo.dbo.Articulokardex)) as ExiPas
		on Art.ArticuloCodigo=ExiPas.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_SarabiaI.dbo.ticket as t
        inner join Server_SarabiaI.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticSa1
        on ticSa1.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_SarabiaI.dbo.devolucion as d
        inner join Server_SarabiaI.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_SarabiaI.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devSa1 on devSa1.ArticuloCodigo=ticSa1.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_SarabiaI.dbo.TicketMayoreo as t
        inner join Server_SarabiaI.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmaySa1 on ticmaySa1.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_SarabiaI.dbo.DevolucionMayoreo as d
        inner join Server_SarabiaI.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_SarabiaI.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmaySa1 on devmaySa1.ArticuloCodigo=ticmaySa1.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_SarabiaI.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_SarabiaI.dbo.Articulokardex)) as ExiSar1
		on Art.ArticuloCodigo=ExiSar1.ArticuloCodigo

	left join 
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_SarabiaII.dbo.ticket as t
        inner join Server_SarabiaII.dbo.ticketarticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo ) as ticSa2
        on ticSa2.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_SarabiaII.dbo.devolucion as d
        inner join Server_SarabiaII.dbo.ticket as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_SarabiaII.dbo.DevolucionArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devSa2 on devSa2.ArticuloCodigo=ticSa2.ArticuloCodigo
    left join
        (select count(ta.TicketId) as nticket,ArticuloCodigo
        from Server_SarabiaII.dbo.TicketMayoreo as t
        inner join Server_SarabiaII.dbo.TicketMayoreoArticulo as ta on t.TicketId=ta.TicketId and t.CajaId=ta.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by ta.ArticuloCodigo) 
        as ticmaySa2 on ticmaySa2.ArticuloCodigo=Art.ArticuloCodigo
    left join
        (select count(d.DevolucionId) as ndev,da.ArticuloCodigo
        from Server_SarabiaII.dbo.DevolucionMayoreo as d
        inner join Server_SarabiaII.dbo.TicketMayoreo as t on t.TicketId=d.TicketId and t.CajaId=d.CajaId
        inner join Server_SarabiaII.dbo.DevolucionMayoreoArticulo as da on da.DevolucionId=d.DevolucionId and da.CajaId=d.CajaId
        where t.ticketFecha between @FechaInicio and @FechaFin
        group by da.ArticuloCodigo
        )
        as devmaySa2 on devmaySa2.ArticuloCodigo=ticmaySa2.ArticuloCodigo
	left join (select ArticuloCodigo,Existencia,ArticuloCosto,ArticuloIva from Server_SarabiaII.dbo.Articulokardex where FechaExistencia= (select max(FechaExistencia) from Server_SarabiaII.dbo.Articulokardex)) as ExiSar2
		on Art.ArticuloCodigo=ExiSar2.ArticuloCodigo
		
where artPrv.ProveedorId=@ProveedorId


END
GO
