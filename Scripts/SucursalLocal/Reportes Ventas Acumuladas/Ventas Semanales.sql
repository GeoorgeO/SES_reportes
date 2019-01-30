declare @FechaDomingoActual datetime
declare @FechaSabadoActual datetime
declare @FechaViernesActual datetime
declare @FechaJuevesActual datetime
declare @FechaMiercolesActual datetime
declare @FechaMartesActual datetime
declare @FechaLunesActual datetime

set @FechaDomingoActual = DATEADD(day,-1, GETDATE())
set @FechaSabadoActual = DATEADD(day,-2, GETDATE())
set @FechaViernesActual = DATEADD(day,-3, GETDATE())
set @FechaJuevesActual = DATEADD(day,-4, GETDATE())
set @FechaMiercolesActual = DATEADD(day,-5, GETDATE())
set @FechaMartesActual = DATEADD(day,-6, GETDATE())
set @FechaLunesActual = DATEADD(day,-7, GETDATE())

set @FechaDomingoActual=convert(nvarchar(4), datepart(year,@FechaDomingoActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaDomingoActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaDomingoActual) , 0),2)+ ' 00:00:00'
set @FechaSabadoActual=convert(nvarchar(4), datepart(year,@FechaSabadoActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaSabadoActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaSabadoActual) , 0),2)+ ' 00:00:00'
set @FechaViernesActual=convert(nvarchar(4), datepart(year,@FechaViernesActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaViernesActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaViernesActual) , 0),2)+ ' 00:00:00'
set @FechaJuevesActual=convert(nvarchar(4), datepart(year,@FechaJuevesActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaJuevesActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaJuevesActual) , 0),2)+ ' 00:00:00'
set @FechaMiercolesActual=convert(nvarchar(4), datepart(year,@FechaMiercolesActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaMiercolesActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaMiercolesActual) , 0),2)+ ' 00:00:00'
set @FechaMartesActual=convert(nvarchar(4), datepart(year,@FechaMartesActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaMartesActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaMartesActual) , 0),2)+ ' 00:00:00'
set @FechaLunesActual=convert(nvarchar(4), datepart(year,@FechaLunesActual) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,@FechaLunesActual) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,@FechaLunesActual) , 0),2)+ ' 00:00:00'

select @FechaDomingoActual
,@FechaSabadoActual
,@FechaViernesActual
,@FechaJuevesActual
,@FechaMiercolesActual
,@FechaMartesActual
,@FechaLunesActual

declare @FechaDomingoAnterior datetime
declare @FechaSabadoAnterior datetime
declare @FechaViernesAnterior datetime
declare @FechaJuevesAnterior datetime
declare @FechaMiercolesAnterior datetime
declare @FechaMartesAnterior datetime
declare @FechaLunesAnterior datetime

exec asp_FechaAñoAnterior_Select @FechaDomingoActual , 1 , @FechaDomingoAnterior output
exec asp_FechaAñoAnterior_Select @FechaSabadoActual , 1 , @FechaSabadoAnterior output
exec asp_FechaAñoAnterior_Select @FechaViernesActual , 1 , @FechaViernesAnterior output
exec asp_FechaAñoAnterior_Select @FechaJuevesActual , 1 , @FechaJuevesAnterior output
exec asp_FechaAñoAnterior_Select @FechaMiercolesActual , 1 , @FechaMiercolesAnterior output
exec asp_FechaAñoAnterior_Select @FechaMartesActual , 1 , @FechaMartesAnterior output
exec asp_FechaAñoAnterior_Select @FechaLunesActual ,  1 , @FechaLunesAnterior output

select @FechaDomingoAnterior
,@FechaSabadoAnterior
,@FechaViernesAnterior
,@FechaJuevesAnterior
,@FechaMiercolesAnterior
,@FechaMartesAnterior
,@FechaLunesAnterior

select  isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaDomingoActual 

declare @IdFolio int
select @IdFolio=isnull(max(IdFolio),0)+1 from RPT_VentaAcumuladaSemanal

declare @Sucursal varchar(100)
select top 1 @Sucursal= SucursalesNombre from Ticket as t inner join caja as c on c.CajaId=t.cajaId inner join sucursales as s on s.SucursalesId=c.SucursalesId order by TicketId desc 

declare @VentaMetaLunes money
select @VentaMetaLunes= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaLunesAnterior 
declare @VentaMetaMartes money
select @VentaMetaMartes= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaMartesAnterior 
declare @VentaMetaMiercoles money
select @VentaMetaMiercoles= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaMiercolesAnterior 
declare @VentaMetaJueves money
select @VentaMetaJueves= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaJuevesAnterior 
declare @VentaMetaViernes money
select @VentaMetaViernes= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaViernesAnterior 
declare @VentaMetaSabado money
select @VentaMetaSabado= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaSabadoAnterior 
declare @VentaMetaDomingo money
select @VentaMetaDomingo= isnull(Sum(isnull(CortesZTotal,0)),0)*(Select (1+(ValorParametro/100)) from RPT_VentaAcumuladaIncremento where IdParametro=1) from CortesZ
where CortesZFecha = @FechaDomingoAnterior 

Declare @Total money 
Set @Total=@VentaMetaLunes+@VentaMetaMartes+@VentaMetaMiercoles+@VentaMetaJueves+@VentaMetaViernes+@VentaMetaSabado+@VentaMetaDomingo

Declare @FechaPeriodo varchar(100)
set @FechaPeriodo = 'De '+ Convert(Varchar(10),@FechaLunesAnterior,103) +' al '+ Convert(Varchar(10),@FechaDomingoAnterior,103) 

INSERT INTO RPT_VentaAcumuladaSemanal
                         (IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert)
VALUES        (@IdFolio,@Sucursal,1,'Meta',@VentaMetaLunes,@VentaMetaMartes,@VentaMetaMiercoles,@VentaMetaJueves,@VentaMetaViernes,@VentaMetaSabado,@VentaMetaDomingo,@Total,@FechaPeriodo,getdate())

declare @VentaAnteriorLunes money
select @VentaAnteriorLunes= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaLunesAnterior 
declare @VentaAnteriorMartes money
select @VentaAnteriorMartes= isnull(Sum(isnull(CortesZTotal,0)),0)from CortesZ
where CortesZFecha = @FechaMartesAnterior 
declare @VentaAnteriorMiercoles money
select @VentaAnteriorMiercoles= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaMiercolesAnterior 
declare @VentaAnteriorJueves money
select @VentaAnteriorJueves= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaJuevesAnterior 
declare @VentaAnteriorViernes money
select @VentaAnteriorViernes= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaViernesAnterior 
declare @VentaAnteriorSabado money
select @VentaAnteriorSabado= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaSabadoAnterior 
declare @VentaAnteriorDomingo money
select @VentaAnteriorDomingo= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaDomingoAnterior 

Set @Total=@VentaAnteriorLunes+@VentaAnteriorMartes+@VentaAnteriorMiercoles+@VentaAnteriorJueves+@VentaAnteriorViernes+@VentaAnteriorSabado+@VentaAnteriorDomingo

INSERT INTO RPT_VentaAcumuladaSemanal
                         (IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert)
VALUES        (@IdFolio,@Sucursal,2,DATEPART(year,@FechaLunesAnterior),@VentaAnteriorLunes,@VentaAnteriorMartes,@VentaAnteriorMiercoles,@VentaAnteriorJueves,@VentaAnteriorViernes,@VentaAnteriorSabado,@VentaAnteriorDomingo,@Total,@FechaPeriodo,getdate())

declare @VentaActualLunes money
select @VentaActualLunes=isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaLunesActual 
declare @VentaActualMartes money
select @VentaActualMartes= isnull(Sum(isnull(CortesZTotal,0)),0)from CortesZ
where CortesZFecha = @FechaMartesActual 
declare @VentaActualMiercoles money
select @VentaActualMiercoles= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaMiercolesActual 
declare @VentaActualJueves money
select @VentaActualJueves= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaJuevesActual 
declare @VentaActualViernes money
select @VentaActualViernes= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaViernesActual 
declare @VentaActualSabado money
select @VentaActualSabado= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaSabadoActual 
declare @VentaActualDomingo money
select @VentaActualDomingo= isnull(Sum(isnull(CortesZTotal,0)),0) from CortesZ
where CortesZFecha = @FechaDomingoActual 

set @FechaPeriodo = 'De '+ Convert(Varchar(10),@FechaLunesActual,103) +' al '+ Convert(Varchar(10),@FechaDomingoActual,103) 
Set @Total=@VentaActualLunes+@VentaActualMartes+@VentaActualMiercoles+@VentaActualJueves+@VentaActualViernes+@VentaActualSabado+@VentaActualDomingo

INSERT INTO RPT_VentaAcumuladaSemanal
                         (IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert)
VALUES        (@IdFolio,@Sucursal,3,DATEPART(year,@FechaLunesActual),@VentaActualLunes,@VentaActualMartes,@VentaActualMiercoles,@VentaActualJueves,@VentaActualViernes,@VentaActualSabado,@VentaActualDomingo,@Total,@FechaPeriodo,getdate())

declare @VentaDiferenciaLunes money
declare @VentaDiferenciaMartes money
declare @VentaDiferenciaMiercoles money
declare @VentaDiferenciaJueves money
declare @VentaDiferenciaViernes money
declare @VentaDiferenciaSabado money
declare @VentaDiferenciaDomingo money

set @VentaDiferenciaLunes =@VentaActualLunes - @VentaAnteriorLunes
set @VentaDiferenciaMartes =@VentaActualMartes - @VentaAnteriorMartes
set @VentaDiferenciaMiercoles =@VentaActualMiercoles - @VentaAnteriorMiercoles
set @VentaDiferenciaJueves =@VentaActualJueves - @VentaAnteriorJueves
set @VentaDiferenciaViernes =@VentaActualViernes - @VentaAnteriorViernes
set @VentaDiferenciaSabado =@VentaActualSabado - @VentaAnteriorSabado
set @VentaDiferenciaDomingo =@VentaActualDomingo - @VentaAnteriorDomingo

Set @Total=@VentaDiferenciaLunes+@VentaDiferenciaMartes+@VentaDiferenciaMiercoles+@VentaDiferenciaJueves+@VentaDiferenciaViernes+@VentaDiferenciaSabado+@VentaDiferenciaDomingo

INSERT INTO RPT_VentaAcumuladaSemanal
                         (IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert)
VALUES        (@IdFolio,@Sucursal,4,'VS AA',@VentaDiferenciaLunes,@VentaDiferenciaMartes,@VentaDiferenciaMiercoles,@VentaDiferenciaJueves,@VentaDiferenciaViernes,@VentaDiferenciaSabado,@VentaDiferenciaDomingo,@Total,'Diferencia VS AA',getdate())


set @VentaDiferenciaLunes =@VentaActualLunes - @VentaMetaLunes
set @VentaDiferenciaMartes =@VentaActualMartes - @VentaMetaMartes
set @VentaDiferenciaMiercoles =@VentaActualMiercoles - @VentaMetaMiercoles
set @VentaDiferenciaJueves =@VentaActualJueves - @VentaMetaJueves
set @VentaDiferenciaViernes =@VentaActualViernes - @VentaMetaViernes
set @VentaDiferenciaSabado =@VentaActualSabado - @VentaMetaSabado
set @VentaDiferenciaDomingo =@VentaActualDomingo - @VentaMetaDomingo

Set @Total=@VentaDiferenciaLunes+@VentaDiferenciaMartes+@VentaDiferenciaMiercoles+@VentaDiferenciaJueves+@VentaDiferenciaViernes+@VentaDiferenciaSabado+@VentaDiferenciaDomingo

INSERT INTO RPT_VentaAcumuladaSemanal
                         (IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert)
VALUES        (@IdFolio,@Sucursal,5,'VS Meta',@VentaDiferenciaLunes,@VentaDiferenciaMartes,@VentaDiferenciaMiercoles,@VentaDiferenciaJueves,@VentaDiferenciaViernes,@VentaDiferenciaSabado,@VentaDiferenciaDomingo,@Total,'Diferencia VS Meta',getdate())


insert into [SERVER-SON].SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
(IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert)
(Select IdFolio, Sucursal, NumeroFila, NombreFila, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, FechaSemana, FechaInsert
from RPT_VentaAcumuladaSemanal
where IdFolio=@IdFolio)