
GO

/****** Object:  StoredProcedure [dbo].[asp_FechaAñoAnterior_Select]    Script Date: 29/01/2019 05:33:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'asp_FechaAñoAnterior_Select')
DROP PROCEDURE asp_FechaAñoAnterior_Select
GO
CREATE PROCEDURE [dbo].[asp_FechaAñoAnterior_Select]
	@Fecha datetime,
	@Opcion int,
	@FechaAnterior datetime output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	set @FechaAnterior=case @opcion when 1 then  dateadd(
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
END

GO


