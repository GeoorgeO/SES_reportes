USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Central'))
BEGIN
	create Database Central
END
