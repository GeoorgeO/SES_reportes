USE [master]
GO

/****** Object:  LinkedServer [SERVER-SON]    Script Date: 26/01/2019 10:17:14 a. m. ******/
EXEC master.dbo.sp_addlinkedserver @server = N'SERVER-SON', @srvproduct=N'SQL', @provider=N'SQLNCLI', @datasrc=N'25.57.171.249\Central', @catalog=N'SES_Reportes'
 /* For security reasons the linked server remote logins password is changed with ######## */
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'SERVER-SON',@useself=N'False',@locallogin=NULL,@rmtuser=N'sa',@rmtpassword='Soneli2018+-'

GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'collation compatible', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'data access', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'dist', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'pub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'rpc', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'rpc out', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'sub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'connect timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'collation name', @optvalue=null
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'lazy schema validation', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'query timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'use remote collation', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'SERVER-SON', @optname=N'remote proc transaction promotion', @optvalue=N'true'
GO


