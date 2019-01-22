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
	N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">Sucursal</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Hora</th>'+
    N'<th bgcolor= "#1D66A9" style="color:#FFFFFF">T. Venta Actual</th><th bgcolor= "#1D66A9" style="color:#FFFFFF"># Ticket Actual</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Prom. Venta Actual</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Prom. Art. Ticket Actual</th>
	  <th bgcolor= "#1D66A9" style="color:#FFFFFF">T. Venta Anterior</th><th bgcolor= "#1D66A9" style="color:#FFFFFF"># Ticket Anterior</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Prom. Venta Actual</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Prom. Art. Ticket Anterior</th>
	  <th bgcolor= "#1D66A9" style="color:#FFFFFF">Porc. Cumplido</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Fecha Actual</th><th bgcolor= "#1D66A9" style="color:#FFFFFF">Fecha Anterior</th></tr>' +
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
SELECT   '$ '+CONVERT(varchar, convert(money, Tventa_Actual), 1)as Tventa_Actual,CONVERT(varchar, convert(int, NTickets_Actual), 1)as NTickets_Actual,'$ '+CONVERT(varchar, convert(money, Pventa_Actual), 1)as Pventa_Actual ,CONVERT(varchar, convert(int, PArticulosXticket_Actual), 1)as PArticulosXticket_Actual,
		 '$ '+CONVERT(varchar, convert(money, Tventa_Anterior), 1)as Tventa_Anterior,CONVERT(varchar, convert(int, NTickets_Anterior), 1)as NTickets_Anterior,'$ '+CONVERT(varchar, convert(money, Pventa_Anterior), 1)as Pventa_Anterior,CONVERT(varchar, convert(int, PArticulosXticket_Anterior), 1)as PArticulosXticket_Anterior,
		 CONVERT(varchar, convert(money, Porcentaje), 1)+ ' %' as Porcentaje,
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
,@recipients ='sistemas@grupoalegro.com'
--,@Copy_recipients=@CadenaCorreos
,@subject = 'Ventas Acumuladas'
,@body = @tableHTML
,@body_format = 'HTML'
,@importance='High'
,@sensitivity='Private'

END