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
CREATE PROCEDURE [Insert_Chairman_pck]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Chairman_pck', N'U') IS NOT NULL
BEGIN
INSERT INTO Chairman_pck (surname, name_, patronymic)
VALUES ('Котик', 'Владислава', 'Вадимович'),
('Ларионова', 'Елена', 'Анатольевна'),
('Мурашов', 'Анатолий', 'Алексеевич'),
('Глускер', 'Александр', 'Игоревич'),
('Ленин', 'Владимир', 'Ильич'),
('Керенский', 'Александр', 'Фёдорович'),
('Корнилов', 'Лавр', 'Георгиевич'),
('Деникин', 'Антон', 'Иванович'),
('Солонин', 'Марк', 'Семёнович'),
('Суворов', 'Виктор', 'Богданович');
END
END
