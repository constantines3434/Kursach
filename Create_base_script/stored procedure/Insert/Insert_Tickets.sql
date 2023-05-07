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
CREATE PROCEDURE [Insert_Tickets]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Tickets', N'U') IS NOT NULL
BEGIN
INSERT INTO Tickets (nom_quetion_in_ticket, id_question, nom_komplect)
VALUES ('1', '1', '1'),
('2', '2', '2'),
('3', '3', '3'),
('4', '4', '4'),
('5', '5', '5');
END
END
