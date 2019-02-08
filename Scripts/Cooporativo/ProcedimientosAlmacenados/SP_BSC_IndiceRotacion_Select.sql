GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_IndiceRotacion_Select]    Script Date: 08/02/2019 07:52:56 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_IndiceRotacion_Select]
	@FechaInicio varchar(20),
	@FechaFin varchar(20),
	@ProveedorId int,
	@EFamilia varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @x INT = 0
	DECLARE @firstcomma INT = 0
	DECLARE @nextcomma INT = 0
	/*Separa los elementos de los id de Familia*/
	DECLARE @TFamilia TABLE (id VARCHAR(50))
	SET @x = LEN(@EFamilia) - LEN(REPLACE(@EFamilia, ',', '')) + 1 

	WHILE @x > 0
    BEGIN
        SET @nextcomma = CASE WHEN CHARINDEX(',', @EFamilia, @firstcomma + 1) = 0
                              THEN LEN(@EFamilia) + 1
                              ELSE CHARINDEX(',', @EFamilia, @firstcomma + 1)
                         END
        INSERT  INTO @TFamilia
        VALUES  ( SUBSTRING(@EFamilia, @firstcomma + 1, (@nextcomma - @firstcomma) - 1) )
        SET @firstcomma = CHARINDEX(',', @EFamilia, @firstcomma + 1)
        SET @x = @x - 1
    END

select Art.ArticuloCodigo,
	ArticuloDescripcion,
	Fam.FamiliaNombre,
	ArtPro.ProveedorId,
	isnull(ArtKar.Existencia,0) as Existencia,
	convert(money,isnull(TV.Venta,0)) as Venta,
	convert(money,isnull(TC.Costo,0)) as Costo,
	(convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))) as SI,
	(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))) as SF,
	case when (((convert(money,isnull(Si.Venta,0))-convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)=0 then 0 
		else (convert(money,isnull(TV.Venta,0))/(((convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)) 
		end as IRP,
	case when (((convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)=0 then 0 
		else (convert(money,isnull(TC.Costo,0))/(((convert(money,isnull(Si.Venta,0))+convert(money,isnull(ArtKar.Existencia,0)))+(convert(money,isnull(Sf.Venta,0))+convert(money,isnull(ArtKar.Existencia,0))))/2)) 
		end as IRC
from Central.dbo.Articulo as Art
inner join Central.dbo.Familia as fam on fam.FamiliaId=art.FamiliaId
inner join Central.dbo.ArticuloProveedores as ArtPro on ArtPro.ArticuloCodigo=Art.ArticuloCodigo
left join (
	select existencia,ArticuloCodigo,FechaExistencia
	from ArticuloKardex 
	where ArticuloCodigo+convert(varchar(15),FechaExistencia) in(
		select ArticuloCodigo+convert(varchar(15),max(FechaExistencia)) 
		from ArticuloKardex  
		group by ArticuloCodigo)) as ArtKar on Art.ArticuloCodigo=ArtKar.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCantidad) as Venta 
	from TicketArticulo as TicArt 
		inner join Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between @FechaInicio and @Fechafin group by TicArt.ArticuloCodigo) as TV on TV.ArticuloCodigo=Art.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCantidad) as Venta 
	from TicketArticulo as TicArt 
		inner join Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between @FechaInicio and CONVERT (date, GETDATE()) group by TicArt.ArticuloCodigo) as Si on Si.ArticuloCodigo=Art.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCantidad) as Venta 
	from TicketArticulo as TicArt 
		inner join Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between @Fechafin and CONVERT (date, GETDATE()) group by TicArt.ArticuloCodigo) as Sf on Sf.ArticuloCodigo=Art.ArticuloCodigo
left join (select TicArt.ArticuloCodigo,sum(TicArt.TicketArticuloCosto*TicketArticuloCantidad) as Costo 
	from TicketArticulo as TicArt 
		inner join Ticket as Tic on Tic.TicketId=TicArt.TicketId and Tic.CajaId=TicArt.CajaId 
		where Tic.TicketFecha between @FechaInicio and @Fechafin group by TicArt.ArticuloCodigo) as TC on TC.ArticuloCodigo=Art.ArticuloCodigo
where (fam.FamiliaId in (SELECT * FROM @TFamilia) or len(@EFamilia)=0)
  and (ArtPro.ProveedorId=@ProveedorId or @ProveedorId=0)
order by 2 desc
END
