
--DECLARE @dbname nvarchar(128)
--SET @dbname = N'Base'

--IF (EXISTS (SELECT name 
--FROM master.dbo.sysdatabases 
--WHERE ('[' + name + ']' = @dbname 
--OR name = @dbname)))
---- code mine :)
--PRINT 'db exist';

--CREATE DATABASE Base;

-- код на создание таблиц в бд

USE Base;

Exec Create_Teacher;

Exec Create_Chairman_pck;

Exec Create_Speciality;

Exec Create_Cycle_commissions;

Exec Create_Protocols;

Exec Create_Semesters;

Exec Create_Disciplines;

Exec Create_Kurs;

Exec Create_Komplect_tickets;

Exec Create_Questions;

Exec Create_Tickets;

Exec Create_Users;

Exec Insert_Teacher;

Exec Insert_Chairman_pck;

Exec Insert_Speciality;

Exec Insert_Cycle_commissions;

Exec Insert_Protocols;

Exec Insert_Semesters;

Exec Insert_Disciplines;

Exec Insert_Kurs;

Exec Insert_Komplect_tickets;

Exec Insert_Questions;

Exec Insert_Tickets;

Exec Insert_Users;
