declare @FechaInicio varchar(20)
declare @FechaFin varchar(40)
declare @Hora varchar(10)

if right('0'+convert(nvarchar(2), datepart(hour,getdate()) , 0),2)<21 
	begin
		set @Hora=right('0'+convert(nvarchar(2), datepart(hour,getdate()) , 0),2)
	end
else
	begin
		set @Hora='20'
	end

set @FechaInicio = convert(nvarchar(4), datepart(year,getdate()) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,getdate()) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,getdate()) , 0),2)+' 00:00:00' 
set @FechaFin = convert(nvarchar(4), datepart(year,getdate()) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,getdate()) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,getdate()) , 0),2)+' 23:59:59'


IF EXISTS(
Select * from SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin

) 
 Begin
 
DECLARE @tableHTML  NVARCHAR(MAX) ;
DECLARE @tableHTMLcen  NVARCHAR(MAX) ;
DECLARE @tableHTMLmor  NVARCHAR(MAX) ;
DECLARE @tableHTMLcos  NVARCHAR(MAX) ;
DECLARE @tableHTMLest  NVARCHAR(MAX) ;
DECLARE @tableHTMLsar  NVARCHAR(MAX) ;
DECLARE @tableHTMLnva  NVARCHAR(MAX) ;
DECLARE @tableHTMLalm  NVARCHAR(MAX) ;
DECLARE @tableHTMLpas  NVARCHAR(MAX) ;
DECLARE @tableHTMLfco  NVARCHAR(MAX) ;
DECLARE @tableHTMLsarII  NVARCHAR(MAX) ;
DECLARE @tableHTMLlom  NVARCHAR(MAX) ;
DECLARE @tableHTMLlaz  NVARCHAR(MAX) ;
DECLARE @tableHTMLrey  NVARCHAR(MAX) ;
DECLARE @tableHTMLcal  NVARCHAR(MAX) ;


SET NOCOUNT ON
--Sucursal Apatzingan
SET @tableHTML =
    N'<H1>Ventas Acumuladas</H1>' +
	N'<H3>Cualquier respuesta a este correo no sera leida</H3>' +
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">APATZINGAN</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='APATZINGAN'
) as A
order by NumeroFila

 FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal Morelos
   set @tableHTMLrey= 
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">LOS REYES</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='LOS REYES'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal CALZADA B
  
 set @tableHTMLcal=
 N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">CALZADA B</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='CALZADA B'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal CALZADA B
  
 set @tableHTMLcen=
N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">CENTRO</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='CENTRO'
) as A
order by NumeroFila

 FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal Morelos
  set @tableHTMLmor=
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">MORELOS</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='MORELOS'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 

	--Sucursal FcoVilla
 set @tableHTMLfco=
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">FCO VILLA</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='FCO VILLA'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal COSTA RICA
  set @tableHTMLcos=
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">COSTA RICA</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='COSTA RICA'
) as A
order by NumeroFila


FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal ESTOCOLMO
   set @tableHTMLest=
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">ESTOCOLMO</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='ESTOCOLMO'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal SARABIA
 set @tableHTMLsar=
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">SARABIA</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='SARABIA'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal NUEVA ITALIA
  set @tableHTMLnva=  
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">NUEVA ITALIA</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='NUEVA ITALIA'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal ALMACEN
 set @tableHTMLalm= 
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">ALMACEN</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='ALMACEN'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal PASEO
 set @tableHTMLpas=    
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">PASEO</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='PASEO'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal SARABIA II
  set @tableHTMLsarII=  
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">SARABIA II</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='SARABIA II'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal LOMBARDIA
  set @tableHTMLlom= 
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">LOMBARDIA</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='LOMBARDIA'
) as A
order by NumeroFila

FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>' 
--Sucursal LAZARO
   set @tableHTMLlaz= 
    N'<table border="5">' +
	N'<caption bgcolor= "#1D66A9" style="color:#FFFFFF">LAZARO</caption>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF"></th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Periodo</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Lunes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Martes</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Miercoles</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Jueves</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Viernes</th>' +
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sabado</th>'+
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Domingo</th>'+
	N'<th scope="row" bgcolor= "#1D66A9" style="color:#FFFFFF">Total</th></tr>'+

    CAST ( (   Select 
	th =NombreFila,'',
	th =FechaSemana,'',
    td =Lunes,'',
	td =Martes,'',
	td =Miercoles,'',
	td =Jueves,'',
	td =Viernes,'',
	td =Sabado,'',
	td =Domingo,'',
	th =Total,''

from (
SELECT   '$ '+CONVERT(varchar, convert(money, Lunes), 1)as Lunes
		,'$ '+CONVERT(varchar, convert(money, Martes), 1)as Martes
		,'$ '+CONVERT(varchar, convert(money, Miercoles), 1)as Miercoles
		,'$ '+CONVERT(varchar, convert(money, Jueves), 1)as Jueves
		,'$ '+CONVERT(varchar, convert(money, Viernes), 1)as Viernes
		,'$ '+CONVERT(varchar, convert(money, Sabado), 1)as Sabado
		,'$ '+CONVERT(varchar, convert(money, Domingo), 1)as Domingo
		,'$ '+CONVERT(varchar, convert(money, Total), 1)as Total
		,NombreFila
		,FechaSemana
		,NumeroFila
		,FechaInsert
FROM     SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='LAZARO'
) as A
order by NumeroFila






 FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' +
	N'<br><br>'
	;


SET NOCOUNT ON
Declare @CadenaCorreos varchar(max)
set @CadenaCorreos= (
 select 
 STUFF(
    (SELECT '; ' + CorreoNombre
    FROM SES_Reportes.dbo.CorreosDestino
    FOR XML PATH('')),
    1, 1, '') As CorreosDestino)

declare @tbody varchar(max);

if len( @tableHTML)>0 set @tbody=@tableHTML
if len( @tableHTMLcen)>0 set @tbody=@tbody + @tableHTMLcen
if len( @tableHTMLcal)>0 set @tbody=@tbody + @tableHTMLcal
if len( @tableHTMLmor)>0 set @tbody=@tbody + @tableHTMLmor
if len( @tableHTMLcos)>0 set @tbody=@tbody + @tableHTMLcos
if len( @tableHTMLest)>0 set @tbody=@tbody + @tableHTMLest
if len( @tableHTMLsar)>0 set @tbody=@tbody + @tableHTMLsar
if len( @tableHTMLnva)>0 set @tbody=@tbody + @tableHTMLnva
if len( @tableHTMLalm)>0 set @tbody=@tbody + @tableHTMLalm
if len( @tableHTMLpas)>0 set @tbody=@tbody + @tableHTMLpas
if len( @tableHTMLfco)>0 set @tbody=@tbody + @tableHTMLfco
if len( @tableHTMLsarII)>0 set @tbody=@tbody + @tableHTMLsarII
if len( @tableHTMLlom)>0 set @tbody=@tbody + @tableHTMLlom
if len( @tableHTMLlaz)>0 set @tbody=@tbody + @tableHTMLlaz
if len( @tableHTMLrey)>0 set @tbody=@tbody + @tableHTMLrey



EXEC msdb.dbo.sp_send_dbmail 
@profile_name = 'Soneli Reportes'
,@recipients ='geoorge191@hotmail.com'
--,@Copy_recipients=@CadenaCorreos
,@subject = 'Ventas Acumuladas'
,@body =  @tbody 
,@body_format = 'HTML'
,@importance='High'
,@sensitivity='Private'

END