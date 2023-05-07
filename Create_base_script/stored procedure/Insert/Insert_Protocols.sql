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
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Insert_Protocols]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Protocols', N'U') IS NOT NULL
BEGIN
INSERT INTO Protocols (date_protocol, id_cycle_commission)
VALUES ('02.02.2023', '1'),
('03.03.2023', '2'),
('04.04.2023', '3'),
('05.05.2023', '4'),
('06.06.2023', '5');
END
END
