/****** Object:  Table [dbo].[ArticuloKardex]    Script Date: 24/09/2018 11:52:09 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF OBJECT_ID('ArticuloKardex') IS NOT NULL
	begin
		select 0;
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[ArticuloKardex](
		[ArticuloCodigo] [char](40) NOT NULL,
		[Existencia] [int] NULL,
		[ArticuloCosto] [money] NULL,
		[ArticuloIVA] [money] NULL,
		[FechaExistencia] [datetime] NOT NULL,
		[FechaInsert] [datetime] NULL,
	 CONSTRAINT [PK_ArticuloKardex] PRIMARY KEY CLUSTERED 
	(
		[ArticuloCodigo] ASC,
		[FechaExistencia] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end



GO

SET ANSI_PADDING OFF
GO


