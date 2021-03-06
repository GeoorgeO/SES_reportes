
USE [Central]
GO

declare @registros numeric(5,0)
declare @correcto bit

select @registros=count(DocumentosId) from Central.dbo.Documentos
if @registros=0 
begin

	begin transaction;
	begin try

		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (1, N'Ticket', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (2, N'Devolucion', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (3, N'Cancelacion', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (4, N'Remision', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (5, N'Entrada', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (6, N'Salida', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (7, N'N Credito x Devolucion', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (8, N'Entrada Forzada', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (9, N'Pago', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (10, N'Abono', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		INSERT [dbo].[Documentos] ([DocumentosId], [DocumentosNombre], [FechaInsert], [FechaUpdate]) VALUES (11, N'N Credito x Concepto', CAST(N'2018-08-22 10:15:46.670' AS DateTime), NULL)
		
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
end
else
begin
	select 0
end

	

