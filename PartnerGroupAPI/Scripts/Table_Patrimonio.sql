USE [PartnerGroup]
GO

/****** Object:  Table [dbo].[Patrimonio]    Script Date: 04/09/2019 21:07:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patrimonio](
	[PatrimonioID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[MarcaID] [uniqueidentifier] NOT NULL,
	[Descricao] [varchar](200) NULL,
	[NTombo] [int] NULL,
 CONSTRAINT [PK_Patrimonio] PRIMARY KEY CLUSTERED 
(
	[PatrimonioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Patrimonio] ADD  CONSTRAINT [DF_Patrimonio_PatrimonioID]  DEFAULT (newid()) FOR [PatrimonioID]
GO

ALTER TABLE [dbo].[Patrimonio]  WITH CHECK ADD  CONSTRAINT [FK_Patrimonio_Marca] FOREIGN KEY([MarcaID])
REFERENCES [dbo].[Marca] ([MarcaID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Patrimonio] CHECK CONSTRAINT [FK_Patrimonio_Marca]
GO


