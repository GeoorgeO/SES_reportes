USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Centro'))
BEGIN
	create Database Server_Centro
END
