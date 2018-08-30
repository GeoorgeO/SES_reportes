IF OBJECT_ID('Articulo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Articulo](
		[ArticuloCodigo] [char](40) NOT NULL,
		[ArticuloDescripcion] [char](200) NOT NULL,
		[FechaInsert] [datetime] NOT NULL,
		[FechaUpdate] [datetime] NULL,
		CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
	(
		[ArticuloCodigo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end

GO
IF OBJECT_ID('ArticuloMedidas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[ArticuloMedidas](
		[ArticuloCodigo] [char](40) NOT NULL,
		[MedidasId] [decimal](11, 0) NOT NULL,
		[FechaUltimaActualizacion] [datetime] NULL,
		[FechaInsert] [datetime] NOT NULL,
	 CONSTRAINT [PK_ArticuloMedidas] PRIMARY KEY CLUSTERED 
	(
		[ArticuloCodigo] ASC,
		[MedidasId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Caja') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Caja](
			[CajaId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[SucursalesId] [decimal](11, 0) NOT NULL,
			[CajaNumero] [int] NOT NULL,
			[CajaDescripcion] [varchar](50) NOT NULL,
			[CajaReciboInicial] [int] NOT NULL,
			[CajaFondo] [money] NOT NULL,
			[CajaMontoEfectivo] [money] NOT NULL,
			[CajaMontoTarjeta] [money] NOT NULL,
			[CajaMontoVale] [money] NOT NULL,
			[CajaFecha] [datetime] NOT NULL,
			[CajaUltimoTicket] [decimal](18, 0) NOT NULL,
			[CajaUltimaDevolucion] [decimal](18, 0) NOT NULL,
			[CajaUltimaCancelacion] [decimal](18, 0) NOT NULL,
			[CajaUltimoCorte] [decimal](18, 0) NOT NULL,
			[CajaUltimoRetiro] [decimal](18, 0) NOT NULL,
			[CajaUltimoTicketMayoreo] [decimal](18, 0) NULL,
			[CajaUltimoDevolucionMayoreo] [decimal](18, 0) NULL,
			[CajaImpresoraTicket] [varchar](100) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Caja__A74F87074F87BD05] PRIMARY KEY CLUSTERED 
		(
			[CajaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('CCliente') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		
		CREATE TABLE [dbo].[CCliente](
			[CClienteId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[CClienteNombre] [char](60) NOT NULL,
			[CClienteFecha] [datetime] NOT NULL,
			[CClienteActivo] [char](1) NOT NULL,
			[CClientePadreId] [decimal](11, 0) NULL,
			[CClienteTieneElementos] [bit] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__CCliente__FBF9032228C9F4F9] PRIMARY KEY CLUSTERED 
		(
			[CClienteId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


	end

GO
IF OBJECT_ID('Cliente') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		
		CREATE TABLE [dbo].[Cliente](
			[ClienteId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[ClienteNombre] [char](200) NOT NULL,
			[ClienteFecha] [datetime] NOT NULL,
			[ClientePaterno] [char](60) NULL,
			[ClienteMaterno] [char](60) NULL,
			[ClienteRfc] [char](13) NOT NULL,
			[ClienteCalle] [char](100) NOT NULL,
			[ClienteNInterior] [char](40) NULL,
			[ClienteNExterior] [char](40) NULL,
			[ClienteColonia] [char](100) NULL,
			[LocalidadId] [decimal](11, 0) NULL,
			[ClienteFechaActualizacion] [datetime] NOT NULL,
			[ClienteTelefono1] [char](20) NULL,
			[ClienteTelefono2] [char](20) NULL,
			[ClienteTelefono3] [char](20) NULL,
			[ClienteEmail] [char](60) NULL,
			[ClienteEmailFiscal] [char](60) NULL,
			[ClienteTipoPersona] [char](1) NOT NULL,
			[ClienteActivo] [char](1) NOT NULL,
			[CClienteId] [decimal](11, 0) NOT NULL,
			[ClienteImpresion] [bit] NOT NULL,
			[ClienteLimiteCredito] [money] NULL,
			[ClienteSobregiro] [money] NULL,
			[VendedorId] [decimal](11, 0) NOT NULL,
			[CondicionesPagosId] [decimal](11, 0) NOT NULL,
			[ClienteTieneCredito] [bit] NULL,
			[ClienteDescuento] [smallmoney] NULL,
			[ClienteObservaciones] [char](255) NULL,
			[ClienteSaldoActual] [money] NULL,
			[FechaInsert] [datetime] NOT NULL CONSTRAINT [DF_Cliente_FechaInsert]  DEFAULT (getdate()),
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Cliente__71ABD08708012052] PRIMARY KEY CLUSTERED 
		(
			[ClienteId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


	end

GO
IF OBJECT_ID('ComprasSugeridas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[ComprasSugeridas](
			[Codigo] [char](40) NULL,
			[Descripcion] [char](200) NULL,
			[Centro] [int] NULL,
			[Morelos] [int] NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('CondicionesPagos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CondicionesPagos](
			[CondicionesPagosId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[CondicionesPagosNombre] [char](60) NOT NULL,
			[CondicionesPagosCantidad] [int] NOT NULL,
			[CondicionesPagosAfectacion] [bit] NOT NULL,
			[CondicionesPagosFecha] [datetime] NOT NULL,
			[CondicionesPagosActivo] [char](1) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Condicio__3220C69CC55B3AB8] PRIMARY KEY CLUSTERED 
		(
			[CondicionesPagosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


	end

GO
IF OBJECT_ID('CProveedor') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[CProveedor](
			[CProveedorId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[CProveedorNombre] [char](60) NOT NULL,
			[CProveedorFecha] [datetime] NOT NULL,
			[CProveedorActivo] [char](1) NOT NULL,
			[CProveedorPadreId] [decimal](11, 0) NULL,
			[CProveedorTieneElementos] [bit] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__CProveed__0B3436F600F43191] PRIMARY KEY CLUSTERED 
		(
			[CProveedorId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Documentos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Documentos](
			[DocumentosId] [bigint] NOT NULL,
			[DocumentosNombre] [varchar](100) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
		(
			[DocumentosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('EntradaMercanciaTipo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
			
		CREATE TABLE [dbo].[EntradaMercanciaTipo](
			[EntradaMercanciaTipoId] [bigint] NOT NULL,
			[EntradaMercanciaTipoDescripcion] [varchar](50) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_EntradaMercanciaTipo] PRIMARY KEY CLUSTERED 
		(
			[EntradaMercanciaTipoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Familia') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Familia](
			[FamiliaId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[FamiliaNombre] [char](60) NOT NULL,
			[FamiliaFecha] [datetime] NOT NULL,
			[FamiliaTipo] [char](1) NOT NULL,
			[FamiliaActivo] [char](1) NOT NULL,
			[FamiliaPadreId] [decimal](11, 0) NULL,
			[IvaId] [decimal](11, 0) NOT NULL,
			[Espadre] [bit] NULL,
			[TieneArticulos] [bit] NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Familia__42DFCCC4B145C40E] PRIMARY KEY CLUSTERED 
		(
			[FamiliaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('FormasdePago') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[FormasdePago](
			[FormasdePagoId] [bigint] NOT NULL,
			[FormasdePagoDescripcion] [varchar](50) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Formasde__408B09EC0E426C69] PRIMARY KEY CLUSTERED 
		(
			[FormasdePagoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Iva') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		
		CREATE TABLE [dbo].[Iva](
			[IvaId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[IvaNombre] [char](60) NOT NULL,
			[IvaFactor] [smallmoney] NOT NULL,
			[IvaPorcentaje] [smallint] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Iva__B75F993C9F738059] PRIMARY KEY CLUSTERED 
		(
			[IvaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Localidad') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Localidad](
			[LocalidadId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[LocalidadNombre] [char](60) NOT NULL,
			[LocalidadCP] [char](5) NOT NULL,
			[MunicipioId] [decimal](11, 0) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Localida__6E2890A2FE57D04A] PRIMARY KEY CLUSTERED 
		(
			[LocalidadId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Medidas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Medidas](
			[MedidasId] [decimal](11, 0) NOT NULL,
			[MedidasNombre] [char](60) NOT NULL,
			[MedidasAlias] [char](60) NOT NULL,
			[FechaInsert] [datetime] NULL,
			[FechaUpdate] [datetime] NULL,
		PRIMARY KEY CLUSTERED 
		(
			[MedidasId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('MetodoPagos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[MetodoPagos](
			[MetodoPagosId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[MetodoPagosNombre] [char](60) NOT NULL,
			[MetodoPagosFecha] [datetime] NOT NULL,
			[MetodoPagosActivo] [char](1) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__MetodoPa__E1A291550371755F] PRIMARY KEY CLUSTERED 
		(
			[MetodoPagosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Moneda') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Moneda](
			[MonedaId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[MonedaNombre] [char](60) NOT NULL,
			[MonedaSimbolo] [char](3) NOT NULL,
			[MonedaActivo] [char](1) NOT NULL,
			[MonedaTipoCambio] [money] NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Moneda__CEEBACBE7D099DCC] PRIMARY KEY CLUSTERED 
		(
			[MonedaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Proveedor') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Proveedor](
			[ProveedorId] [decimal](11, 0) NULL,
			[ProveedorNombre] [char](60) NULL,
			[ProveedorPaterno] [char](60) NULL,
			[ProveedorMaterno] [char](60) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Roles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Roles](
			[RolesId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[RolesNombre] [char](60) NOT NULL,
			[RolesActivo] [char](1) NOT NULL,
			[RolesFecha] [datetime] NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Roles__C4B27840CC38E4DE] PRIMARY KEY CLUSTERED 
		(
			[RolesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('SalidaMercanciaTipo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[SalidaMercanciaTipo](
			[SalidaMercanciaTipoId] [bigint] IDENTITY(1,1) NOT NULL,
			[SalidaMercanciaTipoDescripcion] [varchar](50) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_SalidaMercanciaTipo] PRIMARY KEY CLUSTERED 
		(
			[SalidaMercanciaTipoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Sucursales') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Sucursales](
			[SucursalesId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[SucursalesNombre] [char](60) NOT NULL,
			[SucursalesFecha] [datetime] NOT NULL,
			[SucursalesActivo] [char](1) NOT NULL,
			[SucursalesCalle] [char](100) NOT NULL,
			[SucursalesNInterior] [char](40) NOT NULL,
			[SucursalesnNExterior] [char](40) NULL,
			[SucursalesColonia] [char](100) NOT NULL,
			[LocalidadId] [decimal](11, 0) NOT NULL,
			[SucursalesCiudad] [char](100) NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Sucursal__5163C7016398CAD2] PRIMARY KEY CLUSTERED 
		(
			[SucursalesId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Tarifa') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Tarifa](
			[TarifaId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[TarifaNombre] [char](60) NOT NULL,
			[TarifaFecha] [datetime] NOT NULL,
			[TarifaActivo] [char](1) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Tarifa__E81AC2FB190833D5] PRIMARY KEY CLUSTERED 
		(
			[TarifaId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Usuarios') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Usuarios](
			[UsuariosId] [decimal](11, 0) IDENTITY(1,1) NOT NULL,
			[UsuariosNombre] [char](60) NOT NULL,
			[UsuariosRegistroFecha] [datetime] NOT NULL,
			[UsuariosLogin] [char](60) NOT NULL,
			[UsuariosPassword] [char](60) NOT NULL,
			[UsuariosActivo] [char](1) NOT NULL,
			[RolesId] [decimal](11, 0) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK__Usuarios__48BE79C911BF94B6] PRIMARY KEY CLUSTERED 
		(
			[UsuariosId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO
IF OBJECT_ID('Vendedor') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
		CREATE TABLE [dbo].[Vendedor](
			[VendedorId] [decimal](11, 0) NOT NULL,
			[VendedorNombre] [char](60) NOT NULL,
			[VendedorApellidos] [char](100) NOT NULL,
			[VendedorActivo] [char](1) NOT NULL,
			[VendedorNombreCompleto] [nvarchar](160) NOT NULL,
			[FechaInsert] [datetime] NOT NULL,
			[FechaUpdate] [datetime] NULL,
		 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
		(
			[VendedorId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

	end

GO

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

	


GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Insert]    Script Date: 25/08/2018 12:17:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosInsert')
DROP PROCEDURE SP_BSC_ArticulosInsert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Insert')
DROP PROCEDURE SP_BSC_Articulo_Insert
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloInsert')
DROP PROCEDURE SP_BSC_ArticuloInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Inserta Articulos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Insert]
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Articulo
                         (ArticuloCodigo, ArticuloDescripcion, FechaInsert)
		VALUES        (@ArticuloCodigo,@ArticuloDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado

    -- Insert statements for procedure here

END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_Articulo_Update]    Script Date: 25/08/2018 12:20:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloUpdate')
DROP PROCEDURE SP_BSC_ArticuloUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticulosUpdate')
DROP PROCEDURE SP_BSC_ArticulosUpdate
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_Update')
DROP PROCEDURE SP_BSC_Articulo_Update
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualizar tabla Articulo>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_Articulo_Update]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Articulo
		SET                ArticuloDescripcion = @ArticuloDescripcion, FechaUpdate = GETDATE()
		WHERE        (ArticuloCodigo = @ArticuloCodigo)
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticulosGeneral]    Script Date: 25/08/2018 12:07:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_Articulo_General')
DROP PROCEDURE SP_BSC_Articulo_General
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <23/08/2018>
-- Description:	<Validar si inserta o actualiza la tabla Articulo>
-- =============================================
Create PROCEDURE [dbo].[SP_BSC_Articulo_General]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo	char(40),
	@ArticuloDescripcion char(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ArticuloCodigo) from Articulo a where (a.ArticuloCodigo=@ArticuloCodigo and a.ArticuloDescripcion=@ArticuloDescripcion)

		if @Existe>0
			Exec dbo.SP_BSC_Articulo_Update @ArticuloCodigo, @ArticuloDescripcion;
		else
			Exec dbo.SP_BSC_Articulo_Insert @ArticuloCodigo, @ArticuloDescripcion;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasInsert]    Script Date: 25/08/2018 12:26:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasInsert')
DROP PROCEDURE SP_BSC_ArticuloMedidasInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <24/08/2018>
-- Description:	<Inserta ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasInsert]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40),
	@MedidasId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO ArticuloMedidas
                         (ArticuloCodigo, MedidasId, FechaInsert)
		VALUES        (@ArticuloCodigo,@MedidasId, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasUpdate]    Script Date: 25/08/2018 12:27:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasUpdate')
DROP PROCEDURE SP_BSC_ArticuloMedidasUpdate
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualizar tabla ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasUpdate]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40),
	@MedidasId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       ArticuloMedidas
		SET                MedidasId = @MedidasId, FechaUltimaActualizacion = GETDATE()
		WHERE        (ArticuloCodigo = @ArticuloCodigo)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ArticuloMedidasGeneral]    Script Date: 25/08/2018 12:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ArticuloMedidasGeneral')
DROP PROCEDURE SP_BSC_ArticuloMedidasGeneral
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <24/08/2018>
-- Description:	<Validar si inserta o actualiza la tabla ArticuloMedidas>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ArticuloMedidasGeneral]
	-- Add the parameters for the stored procedure here
	@ArticuloCodigo char(40),
	@MedidasId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ArticuloCodigo) from ArticuloMedidas a where (a.ArticuloCodigo=@ArticuloCodigo and a.MedidasId=@MedidasId)

		if @Existe>0
			Exec dbo.SP_BSC_ArticuloMedidasUpdate @ArticuloCodigo, @MedidasId;
		else
			Exec dbo.SP_BSC_ArticuloMedidasInsert @ArticuloCodigo, @MedidasId;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CajaInsert]    Script Date: 25/08/2018 12:29:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CajaInsert')
DROP PROCEDURE SP_BSC_CajaInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CajaInsert] 
	-- Add the parameters for the stored procedure here
	@CajaId decimal(11, 0),
	@SucursalesId decimal(11, 0),
	@CajaNumero int,
	@CajaDescripcion varchar(50),
	@CajaReciboInicial int,
	@CajaFondo money,
	@CajaMontoEfectivo money,
	@CajaMontoTarjeta money,
	@CajaMontoVale money,
	@CajaFecha datetime,
	@CajaUltimoTicket decimal(18, 0),
	@CajaUltimaDevolucion decimal(18, 0),
	@CajaUltimaCancelacion decimal(18, 0),
	@CajaUltimoCorte decimal(18, 0),
	@CajaUltimoRetiro decimal(18, 0),
	@CajaUltimoTicketMayoreo decimal(18, 0),
	@CajaUltimoDevolucionMayoreo decimal(18, 0),
	@CajaImpresoraTicket varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Caja
                         (CajaId, SucursalesId, CajaNumero, CajaDescripcion, CajaReciboInicial, CajaFondo, CajaMontoEfectivo, CajaMontoTarjeta, CajaMontoVale, CajaFecha, CajaUltimoTicket, CajaUltimaDevolucion, 
                         CajaUltimaCancelacion, CajaUltimoCorte, CajaUltimoRetiro, CajaUltimoTicketMayoreo, CajaUltimoDevolucionMayoreo, CajaImpresoraTicket, FechaInsert)
		VALUES        (@CajaId,@SucursalesId,@CajaNumero,@CajaDescripcion,@CajaReciboInicial,@CajaFondo,@CajaMontoEfectivo,@CajaMontoTarjeta,@CajaMontoVale,@CajaFecha,@CajaUltimoTicket,@CajaUltimaDevolucion,@CajaUltimaCancelacion,@CajaUltimoCorte,@CajaUltimoRetiro,@CajaUltimoTicketMayoreo,@CajaUltimoDevolucionMayoreo,@CajaImpresoraTicket,
                          GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CajaUpdate]    Script Date: 25/08/2018 12:34:21 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CajaUpdate')
DROP PROCEDURE SP_BSC_CajaUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CajaUpdate] 
	-- Add the parameters for the stored procedure here
	@CajaId decimal(11, 0),
	@SucursalesId decimal(11, 0),
	@CajaNumero int,
	@CajaDescripcion varchar(50),
	@CajaReciboInicial int,
	@CajaFondo money,
	@CajaMontoEfectivo money,
	@CajaMontoTarjeta money,
	@CajaMontoVale money,
	@CajaFecha datetime,
	@CajaUltimoTicket decimal(18, 0),
	@CajaUltimaDevolucion decimal(18, 0),
	@CajaUltimaCancelacion decimal(18, 0),
	@CajaUltimoCorte decimal(18, 0),
	@CajaUltimoRetiro decimal(18, 0),
	@CajaUltimoTicketMayoreo decimal(18, 0),
	@CajaUltimoDevolucionMayoreo decimal(18, 0),
	@CajaImpresoraTicket varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Caja
		SET                SucursalesId = @SucursalesId, CajaNumero = @CajaNumero, CajaDescripcion = @CajaDescripcion, CajaReciboInicial = @CajaReciboInicial, CajaFondo = @CajaFondo, CajaMontoEfectivo = @CajaMontoEfectivo, 
                         CajaMontoTarjeta = @CajaMontoTarjeta, CajaMontoVale = @CajaMontoVale, CajaFecha = @CajaFecha, CajaUltimoTicket = @CajaUltimoTicket, CajaUltimaDevolucion = @CajaUltimaDevolucion, 
                         CajaUltimaCancelacion = @CajaUltimaCancelacion, CajaUltimoCorte = @CajaUltimoCorte, CajaUltimoRetiro = @CajaUltimoRetiro, CajaUltimoTicketMayoreo = @CajaUltimoTicketMayoreo, 
                         CajaUltimoDevolucionMayoreo = @CajaUltimoDevolucionMayoreo, CajaImpresoraTicket = @CajaImpresoraTicket, FechaUpdate = GETDATE()
		WHERE        (CajaId = @CajaId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CajaGeneral]    Script Date: 25/08/2018 12:35:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CajaGeneral')
DROP PROCEDURE SP_BSC_CajaGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CajaGeneral]
	-- Add the parameters for the stored procedure here
	@CajaId decimal(11, 0),
	@SucursalesId decimal(11, 0),
	@CajaNumero int,
	@CajaDescripcion varchar(50),
	@CajaReciboInicial int,
	@CajaFondo money,
	@CajaMontoEfectivo money,
	@CajaMontoTarjeta money,
	@CajaMontoVale money,
	@CajaFecha datetime,
	@CajaUltimoTicket decimal(18, 0),
	@CajaUltimaDevolucion decimal(18, 0),
	@CajaUltimaCancelacion decimal(18, 0),
	@CajaUltimoCorte decimal(18, 0),
	@CajaUltimoRetiro decimal(18, 0),
	@CajaUltimoTicketMayoreo decimal(18, 0),
	@CajaUltimoDevolucionMayoreo decimal(18, 0),
	@CajaImpresoraTicket varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CajaId) from Caja a 
		where (a.CajaId=@CajaId)

		if @Existe>0
			Exec dbo.SP_BSC_CajaUpdate @CajaId,
				@SucursalesId,
				@CajaNumero,
				@CajaDescripcion,
				@CajaReciboInicial,
				@CajaFondo,
				@CajaMontoEfectivo,
				@CajaMontoTarjeta,
				@CajaMontoVale,
				@CajaFecha,
				@CajaUltimoTicket,
				@CajaUltimaDevolucion,
				@CajaUltimaCancelacion,
				@CajaUltimoCorte,
				@CajaUltimoRetiro,
				@CajaUltimoTicketMayoreo,
				@CajaUltimoDevolucionMayoreo,
				@CajaImpresoraTicket;
		else
			Exec dbo.SP_BSC_CajaInsert @CajaId,
				@SucursalesId,
				@CajaNumero,
				@CajaDescripcion,
				@CajaReciboInicial,
				@CajaFondo,
				@CajaMontoEfectivo,
				@CajaMontoTarjeta,
				@CajaMontoVale,
				@CajaFecha,
				@CajaUltimoTicket,
				@CajaUltimaDevolucion,
				@CajaUltimaCancelacion,
				@CajaUltimoCorte,
				@CajaUltimoRetiro,
				@CajaUltimoTicketMayoreo,
				@CajaUltimoDevolucionMayoreo,
				@CajaImpresoraTicket;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CClienteInsert]    Script Date: 25/08/2018 12:37:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CClienteInsert')
DROP PROCEDURE SP_BSC_CClienteInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CClienteInsert]
	-- Add the parameters for the stored procedure here
	@CClienteId decimal(11, 0),
	@CClienteNombre char(60),
	@CClienteFecha datetime,
	@CClienteActivo char(1),
	@CClientePadreId decimal(11, 0),
	@CClienteTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO CCliente
                         (CClienteId, CClienteNombre, CClienteFecha, CClienteActivo, CClientePadreId, CClienteTieneElementos, FechaInsert)
		VALUES        (@CClienteId,@CClienteNombre,@CClienteFecha,@CClienteActivo,@CClientePadreId,@CClienteTieneElementos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CClienteUpdate]    Script Date: 25/08/2018 12:38:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CClienteUpdate')
DROP PROCEDURE SP_BSC_CClienteUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CClienteUpdate]
	-- Add the parameters for the stored procedure here
	@CClienteId decimal(11, 0),
	@CClienteNombre char(60),
	@CClienteFecha datetime,
	@CClienteActivo char(1),
	@CClientePadreId decimal(11, 0),
	@CClienteTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       CCliente
		SET                CClienteNombre = @CClienteNombre, CClienteFecha = @CClienteFecha, CClienteActivo = @CClienteActivo, CClientePadreId = @CClientePadreId, CClienteTieneElementos = @CClienteTieneElementos, 
                         FechaUpdate = GETDATE()
		WHERE        (CClienteId = @CClienteId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CClienteGeneral]    Script Date: 25/08/2018 12:38:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CClienteGeneral')
DROP PROCEDURE SP_BSC_CClienteGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CClienteGeneral]
	-- Add the parameters for the stored procedure here
	@CClienteId decimal(11, 0),
	@CClienteNombre char(60),
	@CClienteFecha datetime,
	@CClienteActivo char(1),
	@CClientePadreId decimal(11, 0),
	@CClienteTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CClienteId) from CCliente a where (a.CClienteId=@CClienteId)

		if @Existe>0
			Exec dbo.SP_BSC_CClienteUpdate @CClienteId,
			@CClienteNombre,
			@CClienteFecha,
			@CClienteActivo,
			@CClientePadreId,
			@CClienteTieneElementos;
		else
			Exec dbo.SP_BSC_CClienteInsert @CClienteId,
			@CClienteNombre,
			@CClienteFecha,
			@CClienteActivo,
			@CClientePadreId,
			@CClienteTieneElementos;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteInsert]    Script Date: 25/08/2018 12:39:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ClienteInsert')
DROP PROCEDURE SP_BSC_ClienteInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ClienteInsert] 
	-- Add the parameters for the stored procedure here
	@ClienteId decimal(11, 0),
	@ClienteNombre char(200),
	@ClienteFecha datetime,
	@ClientePaterno char(60),
	@ClienteMaterno char(60),
	@ClienteRfc char(13),
	@ClienteCalle char(100),
	@ClienteNInterior char(40),
	@ClienteNExterior char(40),
	@ClienteColonia char(100),
	@LocalidadId decimal(11, 0),
	@ClienteFechaActualizacion datetime,
	@ClienteTelefono1 char(20),
	@ClienteTelefono2 char(20),
	@ClienteTelefono3 char(20),
	@ClienteEmail char(60),
	@ClienteEmailFiscal char(60),
	@ClienteTipoPersona char(1),
	@ClienteActivo char(1),
	@CClienteId decimal(11, 0),
	@ClienteImpresion bit,
	@ClienteLimiteCredito money,
	@ClienteSobregiro money,
	@VendedorId decimal(11, 0),
	@CondicionesPagosId decimal(11, 0),
	@ClienteTieneCredito bit,
	@ClienteDescuento smallmoney,
	@ClienteObservaciones char(255),
	@ClienteSaldoActual money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Cliente
                         (ClienteId, ClienteNombre, ClienteFecha, ClientePaterno, ClienteMaterno, ClienteRfc, ClienteCalle, ClienteNInterior, ClienteNExterior, ClienteColonia, LocalidadId, ClienteFechaActualizacion, ClienteTelefono1, 
                         ClienteTelefono2, ClienteTelefono3, ClienteEmail, ClienteEmailFiscal, ClienteTipoPersona, ClienteActivo, CClienteId, ClienteImpresion, ClienteLimiteCredito, ClienteSobregiro, VendedorId, CondicionesPagosId, 
                         ClienteTieneCredito, ClienteDescuento, ClienteObservaciones, ClienteSaldoActual, FechaInsert)
		VALUES        (@ClienteId,@ClienteNombre,@ClienteFecha,@ClientePaterno,@ClienteMaterno,@ClienteRfc,@ClienteCalle,@ClienteNInterior,@ClienteNExterior,@ClienteColonia,@LocalidadId,@ClienteFechaActualizacion,@ClienteTelefono1,@ClienteTelefono2,@ClienteTelefono3,@ClienteEmail,@ClienteEmailFiscal,@ClienteTipoPersona,@ClienteActivo,@CClienteId,@ClienteImpresion,@ClienteLimiteCredito,@ClienteSobregiro,@VendedorId,@CondicionesPagosId,@ClienteTieneCredito,@ClienteDescuento,@ClienteObservaciones,@ClienteSaldoActual,
                          GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteUpdate]    Script Date: 25/08/2018 12:39:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ClienteUpdate')
DROP PROCEDURE SP_BSC_ClienteUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ClienteUpdate] 
	-- Add the parameters for the stored procedure here
	@ClienteId decimal(11, 0),
	@ClienteNombre char(200),
	@ClienteFecha datetime,
	@ClientePaterno char(60),
	@ClienteMaterno char(60),
	@ClienteRfc char(13),
	@ClienteCalle char(100),
	@ClienteNInterior char(40),
	@ClienteNExterior char(40),
	@ClienteColonia char(100),
	@LocalidadId decimal(11, 0),
	@ClienteFechaActualizacion datetime,
	@ClienteTelefono1 char(20),
	@ClienteTelefono2 char(20),
	@ClienteTelefono3 char(20),
	@ClienteEmail char(60),
	@ClienteEmailFiscal char(60),
	@ClienteTipoPersona char(1),
	@ClienteActivo char(1),
	@CClienteId decimal(11, 0),
	@ClienteImpresion bit,
	@ClienteLimiteCredito money,
	@ClienteSobregiro money,
	@VendedorId decimal(11, 0),
	@CondicionesPagosId decimal(11, 0),
	@ClienteTieneCredito bit,
	@ClienteDescuento smallmoney,
	@ClienteObservaciones char(255),
	@ClienteSaldoActual money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Cliente
	SET                ClienteNombre = @ClienteNombre, ClienteFecha = @ClienteFecha, ClientePaterno = @ClientePaterno, ClienteMaterno = @ClienteMaterno, ClienteRfc = @ClienteRfc, ClienteCalle = @ClienteCalle, 
                         ClienteNInterior = @ClienteNInterior, ClienteNExterior = @ClienteNExterior, ClienteColonia = @ClienteColonia, LocalidadId = @LocalidadId, ClienteFechaActualizacion = @ClienteFechaActualizacion, 
                         ClienteTelefono1 = @ClienteTelefono1, ClienteTelefono2 = @ClienteTelefono2, ClienteTelefono3 = @ClienteTelefono3, ClienteEmail = @ClienteEmail, ClienteEmailFiscal = @ClienteEmailFiscal, 
                         ClienteTipoPersona = @ClienteTipoPersona, ClienteActivo = @ClienteActivo, CClienteId = @CClienteId, ClienteImpresion = @ClienteImpresion, ClienteLimiteCredito = @ClienteLimiteCredito, 
                         ClienteSobregiro = @ClienteSobregiro, VendedorId = @VendedorId, CondicionesPagosId = @CondicionesPagosId, ClienteTieneCredito = @ClienteTieneCredito, ClienteDescuento = @ClienteDescuento, 
                         ClienteObservaciones = @ClienteObservaciones, ClienteSaldoActual = @ClienteSaldoActual, FechaUpdate = GETDATE()
	WHERE        (ClienteId = @ClienteId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ClienteGeneral')
DROP PROCEDURE SP_BSC_ClienteGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ClienteGeneral] 
	-- Add the parameters for the stored procedure here
	@ClienteId decimal(11, 0),
	@ClienteNombre char(200),
	@ClienteFecha datetime,
	@ClientePaterno char(60),
	@ClienteMaterno char(60),
	@ClienteRfc char(13),
	@ClienteCalle char(100),
	@ClienteNInterior char(40),
	@ClienteNExterior char(40),
	@ClienteColonia char(100),
	@LocalidadId decimal(11, 0),
	@ClienteFechaActualizacion datetime,
	@ClienteTelefono1 char(20),
	@ClienteTelefono2 char(20),
	@ClienteTelefono3 char(20),
	@ClienteEmail char(60),
	@ClienteEmailFiscal char(60),
	@ClienteTipoPersona char(1),
	@ClienteActivo char(1),
	@CClienteId decimal(11, 0),
	@ClienteImpresion bit,
	@ClienteLimiteCredito money,
	@ClienteSobregiro money,
	@VendedorId decimal(11, 0),
	@CondicionesPagosId decimal(11, 0),
	@ClienteTieneCredito bit,
	@ClienteDescuento smallmoney,
	@ClienteObservaciones char(255),
	@ClienteSaldoActual money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ClienteId) from Cliente a where (a.ClienteId=@ClienteId)

		if @Existe>0
			Exec dbo.SP_BSC_ClienteUpdate @ClienteId,
	@ClienteNombre,
	@ClienteFecha,
	@ClientePaterno,
	@ClienteMaterno,
	@ClienteRfc,
	@ClienteCalle,
	@ClienteNInterior,
	@ClienteNExterior,
	@ClienteColonia,
	@LocalidadId,
	@ClienteFechaActualizacion,
	@ClienteTelefono1,
	@ClienteTelefono2,
	@ClienteTelefono3,
	@ClienteEmail,
	@ClienteEmailFiscal,
	@ClienteTipoPersona,
	@ClienteActivo,
	@CClienteId,
	@ClienteImpresion,
	@ClienteLimiteCredito,
	@ClienteSobregiro,
	@VendedorId,
	@CondicionesPagosId,
	@ClienteTieneCredito,
	@ClienteDescuento,
	@ClienteObservaciones,
	@ClienteSaldoActual;
		else
			Exec dbo.SP_BSC_ClienteInsert @ClienteId,
	@ClienteNombre,
	@ClienteFecha,
	@ClientePaterno,
	@ClienteMaterno,
	@ClienteRfc,
	@ClienteCalle,
	@ClienteNInterior,
	@ClienteNExterior,
	@ClienteColonia,
	@LocalidadId,
	@ClienteFechaActualizacion,
	@ClienteTelefono1,
	@ClienteTelefono2,
	@ClienteTelefono3,
	@ClienteEmail,
	@ClienteEmailFiscal,
	@ClienteTipoPersona,
	@ClienteActivo,
	@CClienteId,
	@ClienteImpresion,
	@ClienteLimiteCredito,
	@ClienteSobregiro,
	@VendedorId,
	@CondicionesPagosId,
	@ClienteTieneCredito,
	@ClienteDescuento,
	@ClienteObservaciones,
	@ClienteSaldoActual;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ComprasSugeridasInsert]    Script Date: 25/08/2018 12:41:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ComprasSugeridasInsert')
DROP PROCEDURE SP_BSC_ComprasSugeridasInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ComprasSugeridasInsert] 
	-- Add the parameters for the stored procedure here
	@Codigo char(40),
	@Descripcion char(200),
	@Centro int,
	@Morelos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO ComprasSugeridas
                         (Codigo, Descripcion, Centro, Morelos, FechaInsert)
		VALUES        (@Codigo,@Descripcion,@Centro,@Morelos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ComprasSugeridasUpdate]    Script Date: 25/08/2018 12:42:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ComprasSugeridasUpdate')
DROP PROCEDURE SP_BSC_ComprasSugeridasUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ComprasSugeridasUpdate] 
	-- Add the parameters for the stored procedure here
	@Codigo char(40),
	@Descripcion char(200),
	@Centro int,
	@Morelos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       ComprasSugeridas
		SET                Descripcion = @Descripcion, Centro = @Centro, Morelos = @Morelos, FechaUpdate = GETDATE()
		WHERE        (Codigo = @Codigo)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ComprasSugeridasGeneral]    Script Date: 25/08/2018 12:43:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ComprasSugeridasGeneral')
DROP PROCEDURE SP_BSC_ComprasSugeridasGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_ComprasSugeridasGeneral]
	-- Add the parameters for the stored procedure here
	@Codigo char(40),
	@Descripcion char(200),
	@Centro int,
	@Morelos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(Codigo) from ComprasSugeridas a where (a.Codigo=@Codigo)

		if @Existe>0
			Exec dbo.SP_BSC_ComprasSugeridasUpdate @Codigo,
			@Descripcion,
			@Centro,
			@Morelos;
		else
			Exec dbo.SP_BSC_ComprasSugeridasInsert @Codigo,
			@Descripcion,
			@Centro,
			@Morelos;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CondicionesPagosInsert]    Script Date: 25/08/2018 12:47:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CondicionesPagosInsert')
DROP PROCEDURE SP_BSC_CondicionesPagosInsert
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Inserta en tabla CondicionesPagos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CondicionesPagosInsert]
	-- Add the parameters for the stored procedure here
	@CondicionesPagosId decimal(11, 0),
	@CondicionesPagosNombre char(60),
	@CondicionesPagosCantidad int,
	@CondicionesPagosAfectacion bit,
	@CondicionesPagosFecha datetime,
	@CondicionesPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO CondicionesPagos
                         (CondicionesPagosId, CondicionesPagosNombre, CondicionesPagosCantidad, CondicionesPagosAfectacion, CondicionesPagosFecha, CondicionesPagosActivo, FechaInsert)
		VALUES        (@CondicionesPagosId,@CondicionesPagosNombre,@CondicionesPagosCantidad,@CondicionesPagosAfectacion,@CondicionesPagosFecha,@CondicionesPagosActivo, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CondicionesPagosUpdate]    Script Date: 25/08/2018 12:48:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CondicionesPagosUpdate')
DROP PROCEDURE SP_BSC_CondicionesPagosUpdate
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <22/08/2018>
-- Description:	<Actualiza la tabla CondicionesPagos>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CondicionesPagosUpdate]
	-- Add the parameters for the stored procedure here
	@CondicionesPagosId decimal(11, 0),
	@CondicionesPagosNombre char(60),
	@CondicionesPagosCantidad int,
	@CondicionesPagosAfectacion bit,
	@CondicionesPagosFecha datetime,
	@CondicionesPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       CondicionesPagos
		SET                CondicionesPagosNombre = @CondicionesPagosNombre, CondicionesPagosCantidad = @CondicionesPagosCantidad, CondicionesPagosAfectacion = @CondicionesPagosAfectacion, 
                         CondicionesPagosFecha = @CondicionesPagosFecha, CondicionesPagosActivo = @CondicionesPagosActivo, FechaUpdate = GETDATE()
		WHERE        (CondicionesPagosId = @CondicionesPagosId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CondicionesPagosGeneral]    Script Date: 25/08/2018 12:48:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CondicionesPagosGeneral')
DROP PROCEDURE SP_BSC_CondicionesPagosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CondicionesPagosGeneral]
	-- Add the parameters for the stored procedure here
	@CondicionesPagosId decimal(11, 0),
	@CondicionesPagosNombre char(60),
	@CondicionesPagosCantidad int,
	@CondicionesPagosAfectacion bit,
	@CondicionesPagosFecha datetime,
	@CondicionesPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CondicionesPagosId) from CondicionesPagos a where (a.CondicionesPagosId=@CondicionesPagosId)

		if @Existe>0
			Exec dbo.SP_BSC_CondicionesPagosUpdate @CondicionesPagosId,
			@CondicionesPagosNombre,
			@CondicionesPagosCantidad,
			@CondicionesPagosAfectacion,
			@CondicionesPagosFecha,
			@CondicionesPagosActivo;
		else
			Exec dbo.SP_BSC_CondicionesPagosInsert @CondicionesPagosId,
			@CondicionesPagosNombre,
			@CondicionesPagosCantidad,
			@CondicionesPagosAfectacion,
			@CondicionesPagosFecha,
			@CondicionesPagosActivo;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorInsert]    Script Date: 25/08/2018 12:49:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorInsert')
DROP PROCEDURE SP_BSC_CProveedorInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorInsert] 
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO CProveedor
                         (CProveedorId, CProveedorNombre, CProveedorFecha, CProveedorActivo, CProveedorPadreId, CProveedorTieneElementos, FechaInsert)
		VALUES        (@CProveedorId,@CProveedorNombre,@CProveedorFecha,@CProveedorActivo,@CProveedorPadreId,@CProveedorTieneElementos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
	
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorUpdate]    Script Date: 25/08/2018 12:49:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorUpdate')
DROP PROCEDURE SP_BSC_CProveedorUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorUpdate] 
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       CProveedor
		SET                CProveedorNombre = @CProveedorNombre, CProveedorFecha = @CProveedorFecha, CProveedorActivo = @CProveedorActivo, CProveedorPadreId = @CProveedorPadreId, 
                         CProveedorTieneElementos = @CProveedorTieneElementos, FechaUpdate = GETDATE()
		WHERE        (CProveedorId = @CProveedorId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_CProveedorGeneral]    Script Date: 25/08/2018 12:52:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CProveedorGeneral')
DROP PROCEDURE SP_BSC_CProveedorGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_CProveedorGeneral]
	-- Add the parameters for the stored procedure here
	@CProveedorId decimal(11, 0),
	@CProveedorNombre char(60),
	@CProveedorFecha datetime,
	@CProveedorActivo char(1),
	@CProveedorPadreId decimal(11, 0),
	@CProveedorTieneElementos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(CProveedorId) from CProveedor a where (a.CProveedorId=@CProveedorId)

		if @Existe>0
			Exec dbo.SP_BSC_CProveedorUpdate @CProveedorId,
			@CProveedorNombre,
			@CProveedorFecha,
			@CProveedorActivo,
			@CProveedorPadreId,
			@CProveedorTieneElementos;
		else
			Exec dbo.SP_BSC_CProveedorInsert @CProveedorId,
			@CProveedorNombre,
			@CProveedorFecha,
			@CProveedorActivo,
			@CProveedorPadreId,
			@CProveedorTieneElementos;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosInsert]    Script Date: 25/08/2018 12:52:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosInsert')
DROP PROCEDURE SP_BSC_DocumentosInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosInsert] 
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Documentos
                         (DocumentosId, DocumentosNombre, FechaInsert)
		VALUES        (@DocumentosId,@DocumentosNombre, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosUpdate]    Script Date: 25/08/2018 12:53:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosUpdate')
DROP PROCEDURE SP_BSC_DocumentosUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosUpdate]
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Documentos
		SET                DocumentosNombre = @DocumentosNombre, FechaUpdate = GETDATE()
		WHERE        (DocumentosId = @DocumentosId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_DocumentosGeneral]    Script Date: 25/08/2018 12:53:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_DocumentosGeneral')
DROP PROCEDURE SP_BSC_DocumentosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_DocumentosGeneral] 
	-- Add the parameters for the stored procedure here
	@DocumentosId bigint,
	@DocumentosNombre varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(DocumentosId) from Documentos a where (a.DocumentosId=@DocumentosId)

		if @Existe>0
			Exec dbo.SP_BSC_DocumentosUpdate @DocumentosId,
			@DocumentosNombre;
		else
			Exec dbo.SP_BSC_DocumentosInsert @DocumentosId,
			@DocumentosNombre;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoInsert]    Script Date: 25/08/2018 12:54:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoInsert')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<EntradaMercanciaTipo,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoInsert]  
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO EntradaMercanciaTipo
                         (EntradaMercanciaTipoId, EntradaMercanciaTipoDescripcion, FechaInsert)
		VALUES        (@EntradaMercanciaTipoId,@EntradaMercanciaTipoDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoUpdate]    Script Date: 25/08/2018 12:54:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoUpdate')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoUpdate] 
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       EntradaMercanciaTipo
		SET                EntradaMercanciaTipoDescripcion = @EntradaMercanciaTipoDescripcion, FechaUpdate = GETDATE()
		WHERE        (EntradaMercanciaTipoId = @EntradaMercanciaTipoId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_EntradaMercanciaTipoGeneral]    Script Date: 25/08/2018 12:55:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_EntradaMercanciaTipoGeneral')
DROP PROCEDURE SP_BSC_EntradaMercanciaTipoGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_EntradaMercanciaTipoGeneral]
	-- Add the parameters for the stored procedure here
	@EntradaMercanciaTipoId bigint,
	@EntradaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(EntradaMercanciaTipoId) from EntradaMercanciaTipo a where (a.EntradaMercanciaTipoId=@EntradaMercanciaTipoId)

		if @Existe>0
			Exec dbo.SP_BSC_EntradaMercanciaTipoUpdate @EntradaMercanciaTipoId,
			@EntradaMercanciaTipoDescripcion;
		else
			Exec dbo.SP_BSC_EntradaMercanciaTipoInsert @EntradaMercanciaTipoId,
			@EntradaMercanciaTipoDescripcion;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FamiliaInsert]    Script Date: 25/08/2018 12:56:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FamiliaInsert')
DROP PROCEDURE SP_BSC_FamiliaInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FamiliaInsert]
	-- Add the parameters for the stored procedure here
	@FamiliaId decimal(11, 0),
	@FamiliaNombre char(60),
	@FamiliaFecha datetime,
	@FamiliaTipo char(1),
	@FamiliaActivo char(1),
	@FamiliaPadreId decimal(11, 0),
	@IvaId decimal(11, 0),
	@Espadre bit,
	@TieneArticulos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Familia
                         (FamiliaId, FamiliaNombre, FamiliaFecha, FamiliaTipo, FamiliaActivo, FamiliaPadreId, IvaId, Espadre, TieneArticulos, FechaInsert)
		VALUES        (@FamiliaId,@FamiliaNombre,@FamiliaFecha,@FamiliaTipo,@FamiliaActivo,@FamiliaPadreId,@IvaId,@Espadre,@TieneArticulos, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FamiliaUpdate]    Script Date: 25/08/2018 12:57:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FamiliaUpdate')
DROP PROCEDURE SP_BSC_FamiliaUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FamiliaUpdate]
	-- Add the parameters for the stored procedure here
	@FamiliaId decimal(11, 0),
	@FamiliaNombre char(60),
	@FamiliaFecha datetime,
	@FamiliaTipo char(1),
	@FamiliaActivo char(1),
	@FamiliaPadreId decimal(11, 0),
	@IvaId decimal(11, 0),
	@Espadre bit,
	@TieneArticulos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Familia
		SET                FamiliaNombre = @FamiliaNombre, FamiliaFecha = @FamiliaFecha, FamiliaTipo = @FamiliaTipo, FamiliaActivo = @FamiliaActivo, FamiliaPadreId = @FamiliaPadreId, IvaId = @IvaId, Espadre = @Espadre, 
                         TieneArticulos = @TieneArticulos, FechaUpdate = GETDATE()
		WHERE        (FamiliaId = @FamiliaId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FamiliaGeneral]    Script Date: 25/08/2018 12:57:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FamiliaGeneral')
DROP PROCEDURE SP_BSC_FamiliaGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FamiliaGeneral] 
	-- Add the parameters for the stored procedure here
	@FamiliaId decimal(11, 0),
	@FamiliaNombre char(60),
	@FamiliaFecha datetime,
	@FamiliaTipo char(1),
	@FamiliaActivo char(1),
	@FamiliaPadreId decimal(11, 0),
	@IvaId decimal(11, 0),
	@Espadre bit,
	@TieneArticulos bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(FamiliaId) from Familia a where (a.FamiliaId=@FamiliaId)

		if @Existe>0
			Exec dbo.SP_BSC_FamiliaUpdate @FamiliaId,
			@FamiliaNombre,
			@FamiliaFecha,
			@FamiliaTipo,
			@FamiliaActivo,
			@FamiliaPadreId,
			@IvaId,
			@Espadre,
			@TieneArticulos;
		else
			Exec dbo.SP_BSC_FamiliaInsert @FamiliaId,
			@FamiliaNombre,
			@FamiliaFecha,
			@FamiliaTipo,
			@FamiliaActivo,
			@FamiliaPadreId,
			@IvaId,
			@Espadre,
			@TieneArticulos;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FormasdePagoInsert]    Script Date: 25/08/2018 12:58:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FormasdePagoInsert')
DROP PROCEDURE SP_BSC_FormasdePagoInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FormasdePagoInsert]
	-- Add the parameters for the stored procedure here
	@FormasdePagoId bigint,
	@FormasdePagoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO FormasdePago
                         (FormasdePagoId, FormasdePagoDescripcion, FechaInsert)
	VALUES        (@FormasdePagoId,@FormasdePagoDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FormasdePagoUpdate]    Script Date: 25/08/2018 12:58:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FormasdePagoUpdate')
DROP PROCEDURE SP_BSC_FormasdePagoUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_BSC_FormasdePagoUpdate] 
	-- Add the parameters for the stored procedure here
	@FormasdePagoId bigint,
	@FormasdePagoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       FormasdePago
		SET                FormasdePagoDescripcion = @FormasdePagoDescripcion, FechaUpdate = GETDATE()
		WHERE        (FormasdePagoId = @FormasdePagoId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE [Central]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_FormasdePagoGeneral]    Script Date: 25/08/2018 12:59:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_FormasdePagoGeneral')
DROP PROCEDURE SP_BSC_FormasdePagoGeneral
GO
-- =============================================
-- Author:		<Jorge Onofre>
-- Create date: <23/08/2013>
-- Description:	<Validador si inserta o actualiza registro en la tabla FormasdePago>
-- =============================================
create PROCEDURE  [dbo].[SP_BSC_FormasdePagoGeneral]
	-- Add the parameters for the stored procedure here
	@FormasdePagoId bigint,
	@FormasdePagoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(FormasdePagoId) from FormasdePago a where (a.FormasdePagoId=@FormasdePagoId)

		if @Existe>0
			Exec dbo.SP_BSC_FormasdePagoUpdate @FormasdePagoId,
			@FormasdePagoDescripcion;
		else
			Exec dbo.SP_BSC_FormasdePagoInsert @FormasdePagoId,
			@FormasdePagoDescripcion;
		
		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_LocalidadInsert')
DROP PROCEDURE SP_BSC_LocalidadInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_LocalidadInsert
	-- Add the parameters for the stored procedure here
	@LocalidadId decimal(11, 0),
	@LocalidadNombre char(60),
	@LocalidadCP char(5),
	@MunicipioId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Localidad
                         (LocalidadId, LocalidadNombre, LocalidadCP, MunicipioId, FechaInsert)
		VALUES        (@LocalidadId,@LocalidadNombre,@LocalidadCP,@MunicipioId, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_LocalidadUpdate')
DROP PROCEDURE SP_BSC_LocalidadUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_LocalidadUpdate 
	-- Add the parameters for the stored procedure here
	@LocalidadId decimal(11, 0),
	@LocalidadNombre char(60),
	@LocalidadCP char(5),
	@MunicipioId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Localidad
		SET                LocalidadNombre = @LocalidadNombre, LocalidadCP = @LocalidadCP, MunicipioId = @MunicipioId, FechaUpdate = GETDATE()
		WHERE        (LocalidadId = @LocalidadId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_LocalidadGeneral')
DROP PROCEDURE SP_BSC_LocalidadGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_LocalidadGeneral
	-- Add the parameters for the stored procedure here
	@LocalidadId decimal(11, 0),
	@LocalidadNombre char(60),
	@LocalidadCP char(5),
	@MunicipioId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(LocalidadId) from Localidad a 
		where (a.LocalidadId=@LocalidadId)

		if @Existe>0
			Exec dbo.SP_BSC_LocalidadUpdate @LocalidadId,
				@LocalidadNombre,
				@LocalidadCP,
				@MunicipioId;
		else
			Exec dbo.SP_BSC_LocalidadInsert @LocalidadId,
				@LocalidadNombre,
				@LocalidadCP,
				@MunicipioId;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MedidasInsert')
DROP PROCEDURE SP_BSC_MedidasInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MedidasInsert
	-- Add the parameters for the stored procedure here
	@MedidasId decimal(11, 0),
	@MedidasNombre char(60),
	@MedidasAlias char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Medidas
                         (MedidasId, MedidasNombre, MedidasAlias, FechaInsert)
		VALUES        (@MedidasId,@MedidasNombre,@MedidasAlias, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MedidasUpdate')
DROP PROCEDURE SP_BSC_MedidasUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MedidasUpdate
	-- Add the parameters for the stored procedure here
	@MedidasId decimal(11, 0),
	@MedidasNombre char(60),
	@MedidasAlias char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Medidas
		SET                MedidasNombre = @MedidasNombre, MedidasAlias = @MedidasAlias, FechaUpdate = GETDATE()
		WHERE        (MedidasId = @MedidasId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MedidasGeneral')
DROP PROCEDURE SP_BSC_MedidasGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MedidasGeneral
	-- Add the parameters for the stored procedure here
	@MedidasId decimal(11, 0),
	@MedidasNombre char(60),
	@MedidasAlias char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(MedidasId) from Medidas a where (a.MedidasId=@MedidasId)

		if @Existe>0
			Exec dbo.SP_BSC_MedidasUpdate @MedidasId,
				@MedidasNombre,
				@MedidasAlias;
		else
			Exec dbo.SP_BSC_MedidasInsert @MedidasId,
				@MedidasNombre,
				@MedidasAlias;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MetodoPagosInsert')
DROP PROCEDURE SP_BSC_MetodoPagosInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MetodoPagosInsert 
	-- Add the parameters for the stored procedure here
	@MetodoPagosId decimal(11, 0),
	@MetodoPagosNombre char(60),
	@MetodoPagosFecha datetime,
	@MetodoPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO MetodoPagos
								 (MetodoPagosId, MetodoPagosNombre, MetodoPagosFecha, MetodoPagosActivo, FechaInsert)
		VALUES        (@MetodoPagosId,@MetodoPagosNombre,@MetodoPagosFecha,@MetodoPagosActivo, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
use Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MetodoPagosUpdate')
DROP PROCEDURE SP_BSC_MetodoPagosUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MetodoPagosUpdate 
	-- Add the parameters for the stored procedure here
	@MetodoPagosId decimal(11, 0),
	@MetodoPagosNombre char(60),
	@MetodoPagosFecha datetime,
	@MetodoPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       MetodoPagos
		SET                MetodoPagosNombre = @MetodoPagosNombre, MetodoPagosFecha = @MetodoPagosFecha, MetodoPagosActivo = @MetodoPagosActivo, FechaUpdate = GETDATE()
		WHERE        (MetodoPagosId = @MetodoPagosId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
use Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MetodoPagosGeneral')
DROP PROCEDURE SP_BSC_MetodoPagosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MetodoPagosGeneral
	-- Add the parameters for the stored procedure here
	@MetodoPagosId decimal(11, 0),
	@MetodoPagosNombre char(60),
	@MetodoPagosFecha datetime,
	@MetodoPagosActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(MetodoPagosId) from MetodoPagos a where (a.MetodoPagosId=@MetodoPagosId)

		if @Existe>0
			Exec dbo.SP_BSC_MetodoPagosUpdate @MetodoPagosId,
				@MetodoPagosNombre,
				@MetodoPagosFecha,
				@MetodoPagosActivo;
		else
			Exec dbo.SP_BSC_MetodoPagosInsert @MetodoPagosId,
				@MetodoPagosNombre,
				@MetodoPagosFecha,
				@MetodoPagosActivo;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
use central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MonedaInsert')
DROP PROCEDURE SP_BSC_MonedaInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MonedaInsert
	-- Add the parameters for the stored procedure here
	@MonedaId decimal(11, 0),
	@MonedaNombre char(60),
	@MonedaSimbolo char(3),
	@MonedaActivo char(1),
	@MonedaTipoCambio money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Moneda
								 (MonedaId, MonedaNombre, MonedaSimbolo, MonedaActivo, MonedaTipoCambio, FechaInsert)
		VALUES        (@MonedaId,@MonedaNombre,@MonedaSimbolo,@MonedaActivo,@MonedaTipoCambio, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MonedaUpdate')
DROP PROCEDURE SP_BSC_MonedaUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MonedaUpdate
	-- Add the parameters for the stored procedure here
	@MonedaId decimal(11, 0),
	@MonedaNombre char(60),
	@MonedaSimbolo char(3),
	@MonedaActivo char(1),
	@MonedaTipoCambio money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Moneda
		SET                MonedaNombre = @MonedaNombre, MonedaSimbolo = @MonedaSimbolo, MonedaActivo = @MonedaActivo, MonedaTipoCambio = @MonedaTipoCambio, FechaUpdate = GETDATE()
		WHERE        (MonedaId = @MonedaId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_MonedaGeneral')
DROP PROCEDURE SP_BSC_MonedaGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_MonedaGeneral
	-- Add the parameters for the stored procedure here
	@MonedaId decimal(11, 0),
	@MonedaNombre char(60),
	@MonedaSimbolo char(3),
	@MonedaActivo char(1),
	@MonedaTipoCambio money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(MonedaId) from Moneda a where (a.MonedaId=@MonedaId)

		if @Existe>0
			Exec dbo.SP_BSC_MonedaUpdate @MonedaId,
				@MonedaNombre,
				@MonedaSimbolo,
				@MonedaActivo,
				@MonedaTipoCambio;
		else
			Exec dbo.SP_BSC_MonedaInsert @MonedaId,
				@MonedaNombre,
				@MonedaSimbolo,
				@MonedaActivo,
				@MonedaTipoCambio;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ProveedorInsert')
DROP PROCEDURE SP_BSC_ProveedorInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ProveedorInsert
	-- Add the parameters for the stored procedure here
	@ProveedorId decimal(11, 0),
	@ProveedorNombre char(60),
	@ProveedorPaterno char(60),
	@ProveedorMaterno char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Proveedor
								 (ProveedorId, ProveedorNombre, ProveedorPaterno, ProveedorMaterno, FechaInsert)
		VALUES        (@ProveedorId,@ProveedorNombre,@ProveedorPaterno,@ProveedorMaterno, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ProveedorUpdate')
DROP PROCEDURE SP_BSC_ProveedorUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ProveedorUpdate
	-- Add the parameters for the stored procedure here
	@ProveedorId decimal(11, 0),
	@ProveedorNombre char(60),
	@ProveedorPaterno char(60),
	@ProveedorMaterno char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Proveedor
		SET                ProveedorNombre = @ProveedorNombre, ProveedorPaterno = @ProveedorPaterno, ProveedorMaterno = @ProveedorMaterno, FechaUpdate = GETDATE()
		WHERE        (ProveedorId = @ProveedorId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_ProveedorGeneral')
DROP PROCEDURE SP_BSC_ProveedorGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_ProveedorGeneral
	-- Add the parameters for the stored procedure here
	@ProveedorId decimal(11, 0),
	@ProveedorNombre char(60),
	@ProveedorPaterno char(60),
	@ProveedorMaterno char(60)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(ProveedorId) from Proveedor a where (a.ProveedorId=@ProveedorId)

		if @Existe>0
			Exec dbo.SP_BSC_ProveedorUpdate @ProveedorId,
				@ProveedorNombre,
				@ProveedorPaterno,
				@ProveedorMaterno;
		else
			Exec dbo.SP_BSC_ProveedorInsert @ProveedorId,
				@ProveedorNombre,
				@ProveedorPaterno,
				@ProveedorMaterno;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_RolesInsert')
DROP PROCEDURE SP_BSC_RolesInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_RolesInsert
	-- Add the parameters for the stored procedure here
	@RolesId decimal(11, 0),
	@RolesNombre char(60),
	@RolesActivo char(1),
	@RolesFecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Roles
								 (RolesId, RolesNombre, RolesActivo, RolesFecha, FechaInsert)
		VALUES        (@RolesId,@RolesNombre,@RolesActivo,@RolesFecha, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_RolesUpdate')
DROP PROCEDURE SP_BSC_RolesUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_RolesUpdate 
	-- Add the parameters for the stored procedure here
	@RolesId decimal(11, 0),
	@RolesNombre char(60),
	@RolesActivo char(1),
	@RolesFecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Roles
		SET                RolesNombre = @RolesNombre, RolesActivo = @RolesActivo, RolesFecha = @RolesFecha, FechaUpdate = GETDATE()
		WHERE        (RolesId = @RolesId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_RolesGeneral')
DROP PROCEDURE SP_BSC_RolesGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_RolesGeneral
	-- Add the parameters for the stored procedure here
	@RolesId decimal(11, 0),
	@RolesNombre char(60),
	@RolesActivo char(1),
	@RolesFecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(RolesId) from Roles a where (a.RolesId=@RolesId)

		if @Existe>0
			Exec dbo.SP_BSC_RolesUpdate @RolesId,
				@RolesNombre,
				@RolesActivo,
				@RolesFecha;
		else
			Exec dbo.SP_BSC_RolesInsert @RolesId,
				@RolesNombre,
				@RolesActivo,
				@RolesFecha;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercanciaTipoInsert')
DROP PROCEDURE SP_BSC_SalidaMercanciaTipoInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercanciaTipoInsert
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaTipoId bigint,
	@SalidaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO SalidaMercanciaTipo
                         (SalidaMercanciaTipoId, SalidaMercanciaTipoDescripcion, FechaInsert)
		VALUES        (@SalidaMercanciaTipoId,@SalidaMercanciaTipoDescripcion, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercanciaTipoUpdate')
DROP PROCEDURE SP_BSC_SalidaMercanciaTipoUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercanciaTipoUpdate
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaTipoId bigint,
	@SalidaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       SalidaMercanciaTipo
		SET                SalidaMercanciaTipoDescripcion = @SalidaMercanciaTipoDescripcion, FechaUpdate = GETDATE()
		WHERE        (SalidaMercanciaTipoId = @SalidaMercanciaTipoId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SalidaMercanciaTipoGeneral')
DROP PROCEDURE SP_BSC_SalidaMercanciaTipoGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SalidaMercanciaTipoGeneral 
	-- Add the parameters for the stored procedure here
	@SalidaMercanciaTipoId bigint,
	@SalidaMercanciaTipoDescripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(SalidaMercanciaTipoId) from SalidaMercanciaTipo a where (a.SalidaMercanciaTipoId=@SalidaMercanciaTipoId)

		if @Existe>0
			Exec dbo.SP_BSC_SalidaMercanciaTipoUpdate @SalidaMercanciaTipoId,
				@SalidaMercanciaTipoDescripcion;
		else
			Exec dbo.SP_BSC_SalidaMercanciaTipoInsert @SalidaMercanciaTipoId,
				@SalidaMercanciaTipoDescripcion;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SucursalesInsert')
DROP PROCEDURE SP_BSC_SucursalesInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SucursalesInsert
	-- Add the parameters for the stored procedure here
	@SucursalesId decimal(11, 0),
	@SucursalesNombre char(60),
	@SucursalesFecha datetime,
	@SucursalesActivo char(1),
	@SucursalesCalle char(100),
	@SucursalesNInterior char(40),
	@SucursalesnNExterior char(40),
	@SucursalesColonia char(100),
	@LocalidadId decimal(11, 0),
	@SucursalesCiudad char(100) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Sucursales
                         (SucursalesId, SucursalesNombre, SucursalesFecha, SucursalesActivo, SucursalesCalle, SucursalesNInterior, SucursalesnNExterior, SucursalesColonia, LocalidadId, SucursalesCiudad, FechaInsert)
		VALUES        (@SucursalesId,@SucursalesNombre,@SucursalesFecha,@SucursalesActivo,@SucursalesCalle,@SucursalesNInterior,@SucursalesnNExterior,@SucursalesColonia,@LocalidadId,@SucursalesCiudad, 
								 GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SucursalesUpdate')
DROP PROCEDURE SP_BSC_SucursalesUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SucursalesUpdate
	-- Add the parameters for the stored procedure here
	@SucursalesId decimal(11, 0),
	@SucursalesNombre char(60),
	@SucursalesFecha datetime,
	@SucursalesActivo char(1),
	@SucursalesCalle char(100),
	@SucursalesNInterior char(40),
	@SucursalesnNExterior char(40),
	@SucursalesColonia char(100),
	@LocalidadId decimal(11, 0),
	@SucursalesCiudad char(100) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Sucursales
		SET                SucursalesNombre = @SucursalesNombre, SucursalesFecha = @SucursalesFecha, SucursalesActivo = @SucursalesActivo, SucursalesCalle = @SucursalesCalle, SucursalesNInterior = @SucursalesNInterior, 
								 SucursalesnNExterior = @SucursalesnNExterior, SucursalesColonia = @SucursalesColonia, LocalidadId = @LocalidadId, SucursalesCiudad = @SucursalesCiudad, FechaUpdate = GETDATE()
		WHERE        (SucursalesId = @SucursalesId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_SucursalesGeneral')
DROP PROCEDURE SP_BSC_SucursalesGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_SucursalesGeneral 
	-- Add the parameters for the stored procedure here
	@SucursalesId decimal(11, 0),
	@SucursalesNombre char(60),
	@SucursalesFecha datetime,
	@SucursalesActivo char(1),
	@SucursalesCalle char(100),
	@SucursalesNInterior char(40),
	@SucursalesnNExterior char(40),
	@SucursalesColonia char(100),
	@LocalidadId decimal(11, 0),
	@SucursalesCiudad char(100) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(SucursalesId) from Sucursales a where (a.SucursalesId=@SucursalesId)

		if @Existe>0
			Exec dbo.SP_BSC_SucursalesUpdate @SucursalesId,
				@SucursalesNombre,
				@SucursalesFecha,
				@SucursalesActivo,
				@SucursalesCalle,
				@SucursalesNInterior,
				@SucursalesnNExterior,
				@SucursalesColonia,
				@LocalidadId,
				@SucursalesCiudad;
		else
			Exec dbo.SP_BSC_SucursalesInsert @SucursalesId,
				@SucursalesNombre,
				@SucursalesFecha,
				@SucursalesActivo,
				@SucursalesCalle,
				@SucursalesNInterior,
				@SucursalesnNExterior,
				@SucursalesColonia,
				@LocalidadId,
				@SucursalesCiudad;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TarifaInsert')
DROP PROCEDURE SP_BSC_TarifaInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TarifaInsert
	-- Add the parameters for the stored procedure here
	@TarifaId decimal(11, 0),
	@TarifaNombre char(60),
	@TarifaFecha datetime,
	@TarifaActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Tarifa
                         (TarifaId, TarifaNombre, TarifaFecha, TarifaActivo, FechaInsert)
		VALUES        (@TarifaId,@TarifaNombre,@TarifaFecha,@TarifaActivo, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TarifaUpdate')
DROP PROCEDURE SP_BSC_TarifaUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TarifaUpdate
	-- Add the parameters for the stored procedure here
	@TarifaId decimal(11, 0),
	@TarifaNombre char(60),
	@TarifaFecha datetime,
	@TarifaActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Tarifa
		SET                TarifaNombre = @TarifaNombre, TarifaFecha = @TarifaFecha, TarifaActivo = @TarifaActivo, FechaUpdate = GETDATE()
		WHERE        (TarifaId = @TarifaId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_TarifaGeneral')
DROP PROCEDURE SP_BSC_TarifaGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_TarifaGeneral 
	-- Add the parameters for the stored procedure here
	@TarifaId decimal(11, 0),
	@TarifaNombre char(60),
	@TarifaFecha datetime,
	@TarifaActivo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(TarifaId) from Tarifa a where (a.TarifaId=@TarifaId)

		if @Existe>0
			Exec dbo.SP_BSC_TarifaUpdate @TarifaId,
				@TarifaNombre,
				@TarifaFecha,
				@TarifaActivo;
		else
			Exec dbo.SP_BSC_TarifaInsert @TarifaId,
				@TarifaNombre,
				@TarifaFecha,
				@TarifaActivo;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_UsuariosInsert')
DROP PROCEDURE SP_BSC_UsuariosInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_UsuariosInsert
	-- Add the parameters for the stored procedure here
	@UsuariosId decimal(11, 0),
	@UsuariosNombre char(60),
	@UsuariosRegistroFecha datetime,
	@UsuariosLogin char(60),
	@UsuariosPassword char(60),
	@UsuariosActivo char(1),
	@RolesId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Usuarios
                         (UsuariosId, UsuariosNombre, UsuariosRegistroFecha, UsuariosLogin, UsuariosPassword, UsuariosActivo, RolesId, FechaInsert)
		VALUES        (@UsuariosId,@UsuariosNombre,@UsuariosRegistroFecha,@UsuariosLogin,@UsuariosPassword,@UsuariosActivo,@RolesId, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_UsuariosUpdate')
DROP PROCEDURE SP_BSC_UsuariosUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_UsuariosUpdate
	-- Add the parameters for the stored procedure here
	@UsuariosId decimal(11, 0),
	@UsuariosNombre char(60),
	@UsuariosRegistroFecha datetime,
	@UsuariosLogin char(60),
	@UsuariosPassword char(60),
	@UsuariosActivo char(1),
	@RolesId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Usuarios
		SET                UsuariosNombre = @UsuariosNombre, UsuariosRegistroFecha = @UsuariosRegistroFecha, UsuariosLogin = @UsuariosLogin, UsuariosPassword = @UsuariosPassword, UsuariosActivo = @UsuariosActivo, 
								 RolesId = @RolesId, FechaUpdate = GETDATE()
		WHERE        (UsuariosId = @UsuariosId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_UsuariosGeneral')
DROP PROCEDURE SP_BSC_UsuariosGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_UsuariosGeneral
	-- Add the parameters for the stored procedure here
	@UsuariosId decimal(11, 0),
	@UsuariosNombre char(60),
	@UsuariosRegistroFecha datetime,
	@UsuariosLogin char(60),
	@UsuariosPassword char(60),
	@UsuariosActivo char(1),
	@RolesId decimal(11, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(UsuariosId) from Usuarios a where (a.UsuariosId=@UsuariosId)

		if @Existe>0
			Exec dbo.SP_BSC_UsuariosUpdate @UsuariosId,
				@UsuariosNombre,
				@UsuariosRegistroFecha,
				@UsuariosLogin,
				@UsuariosPassword,
				@UsuariosActivo,
				@RolesId;
		else
			Exec dbo.SP_BSC_UsuariosInsert @UsuariosId,
				@UsuariosNombre,
				@UsuariosRegistroFecha,
				@UsuariosLogin,
				@UsuariosPassword,
				@UsuariosActivo,
				@RolesId;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_VendedorInsert')
DROP PROCEDURE SP_BSC_VendedorInsert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_VendedorInsert
	-- Add the parameters for the stored procedure here
	@VendedorId decimal(11, 0),
	@VendedorNombre char(60),
	@VendedorApellidos char(100),
	@VendedorActivo char(1),
	@VendedorNombreCompleto nvarchar(160)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		INSERT INTO Vendedor
                         (VendedorId, VendedorNombre, VendedorApellidos, VendedorActivo, VendedorNombreCompleto, FechaInsert)
		VALUES        (@VendedorId,@VendedorNombre,@VendedorApellidos,@VendedorActivo,@VendedorNombreCompleto, GETDATE())

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_VendedorUpdate')
DROP PROCEDURE SP_BSC_VendedorUpdate
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_VendedorUpdate
	-- Add the parameters for the stored procedure here
	@VendedorId decimal(11, 0),
	@VendedorNombre char(60),
	@VendedorApellidos char(100),
	@VendedorActivo char(1),
	@VendedorNombreCompleto nvarchar(160)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try
		UPDATE       Vendedor
		SET                VendedorNombre = @VendedorNombre, VendedorApellidos = @VendedorApellidos, VendedorActivo = @VendedorActivo, VendedorNombreCompleto = @VendedorNombreCompleto, FechaUpdate = GETDATE()
		WHERE        (VendedorId = @VendedorId)

		commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE Central
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_VendedorGeneral')
DROP PROCEDURE SP_BSC_VendedorGeneral
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_BSC_VendedorGeneral
	-- Add the parameters for the stored procedure here
	@VendedorId decimal(11, 0),
	@VendedorNombre char(60),
	@VendedorApellidos char(100),
	@VendedorActivo char(1),
	@VendedorNombreCompleto nvarchar(160)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction;
	begin try

		declare @Existe int
		select @Existe = count(VendedorId) from Vendedor a where (a.VendedorId=@VendedorId)

		if @Existe>0
			Exec dbo.SP_BSC_VendedorUpdate @VendedorId,
				@VendedorNombre,
				@VendedorApellidos,
				@VendedorActivo,
				@VendedorNombreCompleto;
		else
			Exec dbo.SP_BSC_VendedorInsert @VendedorId,
				@VendedorNombre,
				@VendedorApellidos,
				@VendedorActivo,
				@VendedorNombreCompleto;
	commit;
		set @correcto=1
	end try
	begin catch
		rollback;
		set @correcto=0
	end catch

	select @correcto resultado
END
GO

GO
USE [Central]
GO

/****** Object:  StoredProcedure [dbo].[SP_BSC_CatalogosCentral_Select]    Script Date: 26/08/2018 04:45:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_BSC_CatalogosCentral_Select')
DROP PROCEDURE SP_BSC_CatalogosCentral_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_BSC_CatalogosCentral_Select]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TABLE_NAME
	FROM INFORMATION_SCHEMA.TABLES
	order by 1
END

GO

GO
