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
CREATE PROCEDURE [Insert_Cycle_commissions]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Cycle_commissions', N'U') IS NOT NULL
BEGIN
INSERT INTO Cycle_commissions (id_chairman_pck, id_teacher, code_speciality)
VALUES ('1', '1', '09.02.06'),
('2', '2', '09.02.07'),
('3', '3', '10.02.05'),
('4', '4', '21.02.19'),
('5', '5', '42.02.01');
END
END
