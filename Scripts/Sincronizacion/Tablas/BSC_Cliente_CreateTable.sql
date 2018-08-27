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