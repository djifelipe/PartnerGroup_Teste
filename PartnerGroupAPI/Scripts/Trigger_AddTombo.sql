USE [PartnerGroup]
GO

/****** Object:  Trigger [dbo].[AddTombo]    Script Date: 04/09/2019 21:08:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[AddTombo]
   ON  [dbo].[Patrimonio]
   AFTER INSERT
AS 
BEGIN
	
	DECLARE @UltimoTombo AS INT;
	DECLARE @PATRIMONIOID AS UNIQUEIDENTIFIER;
	
	SET NOCOUNT ON;
	
	SELECT @UltimoTombo = COUNT(NTOMBO) FROM Patrimonio;
	SELECT @PATRIMONIOID = PatrimonioID FROM inserted;

	UPDATE Patrimonio SET NTombo = (@UltimoTombo + 1) WHERE PatrimonioID = @PATRIMONIOID;
    
END
GO

ALTER TABLE [dbo].[Patrimonio] ENABLE TRIGGER [AddTombo]
GO


