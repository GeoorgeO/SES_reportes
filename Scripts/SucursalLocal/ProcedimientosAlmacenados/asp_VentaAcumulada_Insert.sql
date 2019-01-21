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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_VentaAcumulada_Insert')
DROP PROCEDURE asp_VentaAcumulada_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE asp_VentaAcumulada_Insert 
	-- Add the parameters for the stored procedure here
	@fecha datetime,
	@opcion numeric(1,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		declare @fechaAnt datetime
		--set @fecha='2016-02-29 00:00:00.000'
		--set @fecha=getdate()
		--set @fecha='2019-04-30 00:00:00.000'
		
		select @fechaAnt=case @opcion when 1 then  dateadd(
			day,
			( case when datepart(dw,@fecha) - datepart(dw,
		
					case  when convert(nvarchar(MAX), datepart(month,@fecha) , 0)='2' and convert(nvarchar(MAX), datepart(day,@fecha) , 0)='29' then
						cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) -1, 0)+' 00:00:00.000' as datetime)
					else
						cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) , 0)+' 00:00:00.000' as datetime)
					end
			
		
				)  <-3 then datepart(dw,@fecha)
					else
					datepart(dw,@fecha) - datepart(dw,
		
					case  when convert(nvarchar(MAX), datepart(month,@fecha) , 0)='2' and convert(nvarchar(MAX), datepart(day,@fecha) , 0)='29' then
						cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) -1, 0)+' 00:00:00.000' as datetime)
					else
						cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) , 0)+' 00:00:00.000' as datetime)
					end
			
		
				)
					end 

			),
	
			case  when convert(nvarchar(MAX), datepart(month,@fecha) , 0)='2' and convert(nvarchar(MAX), datepart(day,@fecha) , 0)='29' then
			cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha)-1 , 0)+' 00:00:00.000' as datetime)--,datepart(dw,@fecha)  --,datepart(dw,cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) , 0)+' 00:00:00.000' as datetime))  
			else
			cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) , 0)+' 00:00:00.000' as datetime)--,datepart(dw,@fecha)  --,datepart(dw,cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) , 0)+' 00:00:00.000' as datetime))  
			end 
		)
		when 2 then
			cast(convert(nvarchar(MAX), datepart(year,@fecha)-1 , 0)+'-'+convert(nvarchar(MAX), datepart(month,@fecha) , 0)+'-'+convert(nvarchar(MAX), datepart(day,@fecha) , 0)+' 00:00:00.000' as datetime)
		end 
		declare @IdFolio int
		select @IdFolio=isnull(max(IdFolio),0)+1  from RPT_VentaAcumulada
		
		insert into RPT_VentaAcumulada ([IdFolio],[Tventa_Actual] ,
			[NTickets_Actual] ,
			[Pventa_Actual],
			[PArticulosXticket_Actual],
			[Tventa_Anterior],
			[NTickets_Anterior] ,
			[Pventa_Anterior],
			[PArticulosXticket_Anterior],
			[Porcentaje],
			[Fecha_Actual],
			[Fecha_Anterior],
			[Sucursal],
			[FechaInsert])  

		(select @IdFolio
		,isnull(Tventa_Actual,0) as Tventa_Actual
		,isnull(NTickets_Actual,0) as NTickets_Actual
		,isnull(Pventa_Actual,0) as Pventa_Actual
		,isnull(PArticulosXticket_Actual,0) as PArticulosXticket_Actual
		,isnull(Tventa_Anterior,0) as Tventa_Anterior
		,isnull(NTickets_Anterior,0) as NTickets_Anterior
		,isnull(Pventa_Anterior,0) as Pventa_Anterior
		,isnull(PArticulosXticket_Anterior,0) as PArticulosXticket_Anterior
		,isnull((Tventa_Actual*100)/Tventa_Anterior,0) as Porcentaje
		,@fecha as Fecha_Actual
		,@fechaAnt as Fecha_Anterior
		,Sucursal
		,getdate()
		from

		(select 
			(select sum(t.TicketTotal)
			from Ticket as t
			where t.TicketFecha=@fecha) as Tventa_Actual,
			(select count(TicketId) from Ticket as t
			where t.TicketFecha=@fecha ) as NTickets_Actual,
			(select avg(t.TicketTotal)  
			from Ticket as t
			where t.TicketFecha=@fecha) as Pventa_Actual,
			 (
			select avg(g.CantidadArt) from (select isnull(sum(isnull(td.TicketArticuloCantidad,0)),0) as CantidadArt
			from Ticket as t
				inner join TicketArticulo as td on t.TicketId=td.TicketId and t.CajaId=td.CajaId
			where t.TicketFecha=@fecha
			group by t.TicketId) as g)  as PArticulosXticket_Actual
			,
			(select sum(t.TicketTotal)  
			from Ticket as t
			where t.TicketFecha=@fechaAnt) as Tventa_Anterior,
			(select count(TicketId) from Ticket as t
			where t.TicketFecha=@fechaAnt ) as NTickets_Anterior,
			(select avg(t.TicketTotal)  
			from Ticket as t
			where t.TicketFecha=@fechaAnt) as Pventa_Anterior,
			 (
			select avg(g.CantidadArt) from (select isnull(sum(isnull(td.TicketArticuloCantidad,0)),0) as CantidadArt
			from Ticket as t
				inner join TicketArticulo as td on t.TicketId=td.TicketId and t.CajaId=td.CajaId
			where t.TicketFecha=@fechaAnt
			group by t.TicketId) as g)  as PArticulosXticket_Anterior,
			(select top 1 SucursalesNombre from Ticket as t inner join caja as c on c.CajaId=t.cajaId inner join sucursales as s on s.SucursalesId=c.SucursalesId ) as Sucursal
			) as TG
		)

		Select @IdFolio as IdFolio
END
GO