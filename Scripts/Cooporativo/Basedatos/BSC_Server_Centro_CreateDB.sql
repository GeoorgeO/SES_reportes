USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Apatzingan'))
BEGIN
	create Database Server_Apatzingan
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Calzada'))
BEGIN
	create Database Server_Calzada
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Centro'))
BEGIN
	create Database Server_Centro
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_CostaRica'))
BEGIN
	create Database Server_CostaRica
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Estocolmo'))
BEGIN
	create Database Server_Estocolmo
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_FcoVilla'))
BEGIN
	create Database Server_FcoVilla
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Lombardia'))
BEGIN
	create Database Server_Lombardia
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_LosReyes'))
BEGIN
	create Database Server_LosReyes
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Morelos'))
BEGIN
	create Database Server_Morelos
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_NvaItalia'))
BEGIN
	create Database Server_NvaItalia
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Almacen'))
BEGIN
	create Database Server_Almacen
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_Paseo'))
BEGIN
	create Database Server_Paseo
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_SarabiaI'))
BEGIN
	create Database Server_SarabiaI
END

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'Server_SarabiaII'))
BEGIN
	create Database Server_SarabiaII
END