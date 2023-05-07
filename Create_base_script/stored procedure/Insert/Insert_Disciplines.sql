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
CREATE PROCEDURE [Insert_Disciplines]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Disciplines', N'U') IS NOT NULL
BEGIN
INSERT INTO Disciplines (name_discipline)
VALUES ('ОП.01. Операционные системы'),
('ОП.10. Математическое моделирование'),
('МДК.02.01. Инфокоммуникационные системы и сети'),
('МДК.02.02. Технология разработки и защиты баз данных'),
('ОГСЭ.03. Иностранный язык');
END
END
