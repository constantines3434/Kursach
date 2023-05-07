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
CREATE PROCEDURE [Insert_Speciality]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Speciality', N'U') IS NOT NULL
BEGIN
INSERT INTO Speciality (code_speciality, name_of_speciality)
VALUES ('09.02.06', 'Сетевое и системной администрирование'),
('09.02.07', 'Информационные системы и программирование'),
('10.02.05', 'Обеспечение информационной безопасности автоматизированных систем'),
('21.02.19', 'Землеустройство'),
('42.02.01', 'Реклама');
END
END
