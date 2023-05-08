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
CREATE PROCEDURE [Create_Tickets]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Tickets', N'U') IS NULL
BEGIN
CREATE TABLE Tickets
(
    id_ticket INT IDENTITY,
    nom_quetion_in_ticket INT,
    id_question INT,
    nom_komplect INT,
	PRIMARY KEY(id_ticket, nom_quetion_in_ticket),
	FOREIGN KEY (id_question) REFERENCES Questions (id_question) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (nom_komplect) REFERENCES Komplect_tickets (nom_komplect) ON DELETE CASCADE ON UPDATE CASCADE	
);
END
END