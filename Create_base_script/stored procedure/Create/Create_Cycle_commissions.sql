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
CREATE PROCEDURE [Create_Cycle_commissions]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID(N'dbo.Cycle_commissions', N'U') IS NULL
BEGIN
CREATE TABLE Cycle_commissions
(
	id_cycle_commission INT IDENTITY PRIMARY KEY,
    id_chairman_pck int,
    id_teacher int,
    code_speciality nvarchar(100),
	FOREIGN KEY (code_speciality) REFERENCES Speciality (code_speciality) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (id_chairman_pck) REFERENCES Chairman_Pck (id_chairman_pck) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (id_teacher) REFERENCES Teacher (id_teacher) ON DELETE CASCADE ON UPDATE CASCADE

);
END
END
