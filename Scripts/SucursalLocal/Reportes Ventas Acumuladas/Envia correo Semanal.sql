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

set @FechaInicio = convert(nvarchar(4), datepart(year,getdate()) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,getdate()) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,getdate()) , 0),2)+' 08:00:00' 
set @FechaFin = convert(nvarchar(4), datepart(year,getdate()) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,getdate()) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,getdate()) , 0),2)+' 08:59:59'


IF EXISTS(
Select * from SES_Reportes.dbo.RPT_VentaAcumuladaSemanal
where FechaInsert between @FechaInicio and @FechaFin
) 
 Begin
 
DECLARE @tableHTML  NVARCHAR(MAX) ;
SET NOCOUNT ON
SET @tableHTML =
    N'<H1>Ventas Acumuladas</H1>' +
	N'<H3>Cualquier respuesta a este correo no sera leida</H3>' +
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
where FechaInsert between @FechaInicio and @FechaFin and Sucursal='Centro'
) as A
order by NumeroFila

 FOR XML PATH('tr'), TYPE 
    ) AS NVARCHAR(MAX) ) +
    N'</table>' ;

	  SET NOCOUNT ON
Declare @CadenaCorreos varchar(max)
set @CadenaCorreos= (
 select 
 STUFF(
    (SELECT '; ' + CorreoNombre
    FROM SES_Reportes.dbo.CorreosDestino
    FOR XML PATH('')),
    1, 1, '') As CorreosDestino)

EXEC msdb.dbo.sp_send_dbmail 
@profile_name = 'Soneli Reportes'
,@recipients ='sistemas@grupoalegro.com'
,@Copy_recipients=@CadenaCorreos
,@subject = 'Ventas Acumuladas'
,@body = @tableHTML
,@body_format = 'HTML'
,@importance='High'
,@sensitivity='Private'

END