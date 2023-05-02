
--DECLARE @dbname nvarchar(128)
--SET @dbname = N'Base'

--IF (EXISTS (SELECT name 
--FROM master.dbo.sysdatabases 
--WHERE ('[' + name + ']' = @dbname 
--OR name = @dbname)))
---- code mine :)
--PRINT 'db exist';

--CREATE DATABASE Base;

-- ��� �� �������� ������ � ��

USE Base;

CREATE TABLE Teacher
(
	id_teacher INT IDENTITY PRIMARY KEY,
    surname nvarchar(100),
	name_ nvarchar(100),
    patronymic nvarchar(100)
);

CREATE TABLE Chairman_pck
(
	id_chairman_pck INT IDENTITY PRIMARY KEY,
    name_ nvarchar(20),
    surname nvarchar(20),
    patronymic nvarchar(20)
);

CREATE TABLE Speciality
(
	code_speciality nvarchar(100) PRIMARY KEY,
    name_of_speciality nvarchar(100),
);

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

CREATE TABLE Protocols
(
	nom_protocol INT IDENTITY PRIMARY KEY,
    date_protocol date,
    id_cycle_commission INT,
	FOREIGN KEY (id_cycle_commission) REFERENCES Cycle_commissions (id_cycle_commission) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Semesters
(
	nom_semester INT IDENTITY PRIMARY KEY,
    academic_year DATE
);


CREATE TABLE Disciplines
(
	id_discipline nvarchar(100) PRIMARY KEY,
    name_discipline nvarchar(100)
);

CREATE TABLE Kurs
(
    nom_kurs INT PRIMARY KEY
);

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

CREATE TABLE Questions
(
	id_question INT IDENTITY,
    id_discipline nvarchar(100),
    question nvarchar(100),
    type_question nvarchar(100),
	cheking bit,
	--PRIMARY KEY(id_question, id_discipline),
	PRIMARY KEY(id_question),
	FOREIGN KEY (id_discipline) REFERENCES Disciplines (id_discipline) ON DELETE CASCADE ON UPDATE CASCADE	
);

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

CREATE TABLE Users
(
	nom_user INT IDENTITY PRIMARY KEY,
    login_ nvarchar(50),
    password_ nvarchar(50),
	role_ nvarchar(5)
);

--DELETE FROM Teacher;
INSERT INTO Teacher (surname, name_, patronymic)
VALUES ('�������', '����������', '���������'),
('���������', '�����', '�����������'),
('�������', '��������', '����������'),
('�������', '���������', '��������'),
('�����������', '�����', '����������');

--DROP TABLE Chairman_pck;
INSERT INTO Chairman_pck (surname, name_, patronymic)
VALUES ('������', '����������', '���������'),
('���������', '�����', '�����������'),
('�������', '��������', '����������'),
('�������', '���������', '��������'),
('�����������', '�����', '����������');

--DELETE FROM Speciality;
INSERT INTO Speciality (code_speciality, name_of_speciality)
VALUES ('09.02.06', '������� � ��������� �����������������'),
('09.02.07', '�������������� ������� � ����������������'),
('10.02.05', '����������� �������������� ������������ ������������������ ������'),
('21.02.19', '���������������'),
('42.02.01', '�������');

--DELETE FROM Cycle_commissions;

	--id_cycle_commission INT IDENTITY PRIMARY KEY,
 --   id_chairman_pck int,
 --   id_teacher int,
 --   code_speciality nvarchar(100),
INSERT INTO Cycle_commissions (id_chairman_pck, id_teacher, code_speciality)
VALUES ('1', '1', '09.02.06'),
('2', '2', '09.02.07'),
('3', '3', '10.02.05'),
('4', '4', '21.02.19'),
('5', '5', '42.02.01');

--DELETE FROM Protocols;
INSERT INTO Protocols (date_protocol, id_cycle_commission)
VALUES ('02.02.2023', '1'),
('03.03.2023', '2'),
('04.04.2023', '3'),
('05.05.2023', '4'),
('06.06.2023', '5');

--DELETE FROM Semesters;
INSERT INTO Semesters (academic_year)
VALUES ('01.01.2020'),
('05.05.2020'),
('01.01.2021'),
('05.05.2021'),
('01.01.2022');

--DELETE FROM Disciplines;
INSERT INTO Disciplines (id_discipline, name_discipline)
VALUES ('��.01.', '������������ �������'),
('��.10.', '�������������� �������������'),
('���.02.01.', '�������������������� ������� � ����'),
('���.02.02.', '���������� ���������� � ������ ��� ������'),
('����.03.', '����������� ����');

--DELETE FROM Kurs;
INSERT INTO Kurs (nom_kurs)
VALUES ('1'),
('2'),
('3'),
('4'),
('5');

--DELETE FROM Komplect_tickets;
INSERT INTO Komplect_tickets (nom_kurs, nom_semester, nom_protocol, id_discipline)
VALUES ('1', '1', '1', '���.02.01.'),
('2', '2', '2', '���.02.02.'),
('3', '3', '3', '����.03.'),
('4', '4', '4', '��.01.'),
('5', '5', '5', '��.10.');

--DELETE FROM Questions;
INSERT INTO Questions (id_discipline, question, type_question, cheking)
VALUES ('���.02.01.', '��� ����� ���� ��������', '�������������', 0),
('���.02.02.', '������� ����� � ������� � 4 ��������', '�������������', 0),
('����.03.', '�������� ������������� ����', '������������', 0),
('��.01.', '�������� ����', '������������', 0),
('��.10.', '������ ������: 2+2', '������������', 0);

--DELETE FROM Tickets;
INSERT INTO Tickets (nom_quetion_in_ticket, id_question, nom_komplect)
VALUES ('1', '1', '1'),
('2', '2', '2'),
('3', '3', '3'),
('4', '4', '4'),
('5', '5', '5');

--DELETE FROM Users;
INSERT INTO Users (login_, password_, role_)
VALUES ('Consta', '34', 'User'),
('Nohcha', '11','User'),
('Alex', '12','Admin'),
('Elena', '13','Admin'),
('Parampampam', '14','User');