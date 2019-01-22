declare @FechaInicio varchar(20)
declare @FechaFin varchar(20)

set @FechaInicio = convert(nvarchar(4), datepart(year,getdate()) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,getdate()) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,getdate()) , 0),2)+' 00:00:00' 
set @FechaFin = convert(nvarchar(4), datepart(year,getdate()) , 0)+''+right('0'+convert(nvarchar(2), datepart(month,getdate()) , 0),2)+''+right('0'+convert(nvarchar(2), datepart(day,getdate()) , 0),2)+' 23:59:59'

IF EXISTS(
Select * from SES_Reportes.dbo.RPT_VentaAcumulada
where FechaInsert between @FechaInicio and @FechaFin
) 
 Begin
 
DECLARE @tableHTML  NVARCHAR(MAX) ;
SET NOCOUNT ON
SET @tableHTML =
    N'<H1>Ventas Acumuladas</H1>' +
	N'<H3>Cualquier respuesta a este correo no sera leida</H3>' +
    N'<table border="5">' +
	N'<th>Sucursal</th><th>Hora</th>'+
    N'<th>T. Venta Actual</th><th># Ticket Actual</th><th>Prom. Venta Actual</th><th>Prom. Art. Ticket Actual</th>
	  <th>T. Venta Anterior</th><th># Ticket Anterior</th><th>Prom. Venta Actual</th><th>Prom. Art. Ticket Anterior</th>
	  <th>Porc. Cumplido</th><th>Fecha Actual</th><th>Fecha Anterior</th></tr>' +
    CAST ( (   Select 
	td = Sucursal, '',
    td= Hora, '',
    td =Tventa_Actual, '',
	td =NTickets_Actual, '',
	td =Pventa_Actual,'',
	td =PArticulosXticket_Actual,'',
	td =Tventa_Anterior, '',
	td =NTickets_Anterior, '',
	td =Pventa_Anterior,'',
	td =PArticulosXticket_Anterior,'',
	td =Porcentaje ,'',
	td =Fecha_Actual ,'',
	td =Fecha_Anterior ,''
	

from (
SELECT   Tventa_Actual, NTickets_Actual, Pventa_Actual , PArticulosXticket_Actual,
		 Tventa_Anterior, NTickets_Anterior, Pventa_Anterior, PArticulosXticket_Anterior,
		 Porcentaje,
		 CONVERT(VARCHAR(10),Fecha_Actual, 103) as Fecha_Actual,
		 CONVERT(VARCHAR(10),Fecha_Anterior, 103) as Fecha_Anterior, Sucursal,
		 CONVERT(VARCHAR(10),FechaInsert, 108)  as Hora
FROM     SES_Reportes.dbo.RPT_VentaAcumulada
where FechaInsert between @FechaInicio and @FechaFin
) as A
order by Sucursal,Hora

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
,@recipients ='soporte@grupoalegro.com'
,@Copy_recipients=@CadenaCorreos
,@subject = 'Ventas Acumuladas'
,@body = @tableHTML
,@body_format = 'HTML'
,@importance='High'
,@sensitivity='Private'

END