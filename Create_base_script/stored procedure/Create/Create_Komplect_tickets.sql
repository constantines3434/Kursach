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
CREATE PROCEDURE [Create_Komplect_tickets]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Komplect_tickets', N'U') IS NULL
BEGIN
CREATE TABLE Komplect_tickets
(
    nom_komplect INT IDENTITY PRIMARY KEY,
    nom_kurs INT,
    nom_semester INT,
    nom_protocol INT,
	id_discipline nvarchar(100),
	FOREIGN KEY (nom_semester) REFERENCES Semesters (nom_semester) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (nom_kurs) REFERENCES Kurs (nom_kurs) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (nom_protocol) REFERENCES Protocols (nom_protocol) ON DELETE CASCADE ON UPDATE CASCADE
);
END
END
