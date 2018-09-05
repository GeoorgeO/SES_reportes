USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'SES_Sincroniza')) 
BEGIN
	create Database SES_Sincroniza
END


