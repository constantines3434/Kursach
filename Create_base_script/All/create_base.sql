
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
	id_discipline int IDENTITY PRIMARY KEY,
    name_discipline nvarchar(500)
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
    id_discipline int,
    question nvarchar(500),
    type_question nvarchar(100),
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
('�����������', '�����', '����������'),
('�������', '����', '����������'),
('�����������', '������', '����������'),
('������', '�����', '�������������'),
('�������', '���', '���������'),
('���������', '����', '����������');

--DROP TABLE Chairman_pck;
INSERT INTO Chairman_pck (surname, name_, patronymic)
VALUES ('�����', '����������', '���������'),
('���������', '�����', '�����������'),
('�������', '��������', '����������'),
('�������', '���������', '��������'),
('�����', '��������', '�����'),
('���������', '���������', 'Ը�������'),
('��������', '����', '����������'),
('�������', '�����', '��������'),
('�������', '����', '��������'),
('�������', '������', '����������');

--DELETE FROM Speciality;
INSERT INTO Speciality (code_speciality, name_of_speciality)
VALUES ('09.02.06', '������� � ��������� �����������������'),
('09.02.07', '�������������� ������� � ����������������'),
('10.02.05', '����������� �������������� ������������ ������������������ ������'),
('21.02.19', '���������������'),
('42.02.01', '�������');

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
INSERT INTO Disciplines (name_discipline)
VALUES ('��.01. ������������ �������'),
('��.10. �������������� �������������'),
('���.02.01. �������������������� ������� � ����'),
('���.02.02. ���������� ���������� � ������ ��� ������'),
('����.03. ����������� ����');

--DELETE FROM Kurs;
INSERT INTO Kurs (nom_kurs)
VALUES ('1'),
('2'),
('3'),
('4'),
('5');

--DELETE FROM Komplect_tickets;
INSERT INTO Komplect_tickets (nom_kurs, nom_semester, nom_protocol, id_discipline)
VALUES ('1', '1', '1', '1'),
('2', '2', '2', '2'),
('3', '3', '3', '3'),
('4', '4', '4', '4'),
('5', '5', '5', '5');

--DELETE FROM Questions;
INSERT INTO Questions (id_discipline, question, type_question)
VALUES 
--��.01. ������������ ������� ������������ �������
('1', '������� �������� ������������ �������.
���������� ����������� �������� ������������ �������.', '������������'),
('1', '��������� ������������������ ������������ ������', '������������'),
('1', '�������� ����������� ��', '������������'),
('1', '��������� ���������� ������� ����� ������������', '������������'),
('1', '������ � ������������� �������', '������������'),
--==================
('1', '�������� � �������������� ������ � ��������� Edit', '������������'),
('1', '���������� ���������������� ����������
���������. ������������� ��������', '������������'),
('1', '������������ ����������� �����
�������������� � �������� ������� ������� �������� ������', '������������'),
('1', '���������� �������� �������� �������������', '������������'),
('1', '���������� ����������� �������. ������������� ���������� ������', '������������'),
('1', '������ � ������ ��������', '������������'),
('1', '������������ ��������� ����������� ������ � �� Windows', '������������'),
('1', '������������ ��������� ����������� ������ � Linux Ubuntu
('1', '������ � ������ �������� �������
('1', '������ � ������������ �������� � ������,
���������� �� �������������� �������� ��', '������������'),
('1', '�������� ��������� �������� �������. ���������� ������� � ��������� ���������
('1', '��������� ���������������� �������� �������
����������� � ��������� ������ ', '������������'),
('1', '����������������� � ������������ ������� Windows
('1', '���������� ����������� �������� � ��������� ����', '������������'),
('1', ' ������������ � �������� ������� ����������
������ �� �����, ����������� ��� �� �����������', '������������'),
('1', '�������� ������� ���������� � �� Unix
��������� ������� ���������� � �� Unix', '������������'),
('1', '������ � ����������� ��������� ������', '������������'),
('1', '�������� �� ������� ���������� �����', '������������'),
('1', '������������� ������������ ��������', '������������'),
('1', '������������� ������ ��� ������ � �������', '������������'),
('1', '������������ ������� MS-DOS ', '������������'),
('1', '������������ ������� Free-DOS ', '������������'),
('1', '������� ������������ ���������. ��������
NC ', '������������'),
('1', '����������� ����������������
������������ �������', '������������'),
('1', '������������� ���� � ������ ������������', '������������'),
('1', '���������� (� %) ������ ��������� ������� �����, ���� �������������� (�����������)
������ ������� �� ���� ���������� �������� �������� 30% � 20 %. ��������� ���������
DiskDirectSuite. �������� ���� �� ��������� �������.', '������������'),
('1', '���������� ��������� DiskDirectSuite. ���������� ���������� �������� ������� ������
���, ���� ����� �� ������ ����� 2880 ��������, ��������� ������� �������� 33 �������, �
������ FAT � 18 ��������.', '������������'),
('1', '���������� ��������� DiskDirectSuite. ������ ������� �������� ����� ����� 2048 �����.
������� �������� ����� ��������� ������? �������� ������ ������ ������� � ��������
�������� fat.', '������������'),
('1', '��������� ������� ��������� �����, ���� ��� ����� 3410 ����, ������ �������� � 2 �������, �
��� ��� ������ ���� �������� ������ �������� 5, 7, 10, 13, 14, 18.', '������������'),
('1', '��������� ������� KSysGuard. ������ �������� ����������� �������? �����������
��������� ��������. ��������������� �������������� �������� � ��������������� 1:
���������, ���������, ������ ����������� � ���������� ������, ���������� ���������,
������������ �������, ��� ������������, ������������ �������. �������� ��� ���������.
��� ��������� ���������� ������ �� �������� ������ ��������?', '������������'),
('1', '��������� ������� ��������� �����, ���� ��� ����� 2,3 ��, ������ �������� � 1 ������, � ���
��� ������ ���� �������� ������ �������� 2, 4, 8, 10, 14, 23.', '������������'),
('1', '��������� �������� ������� regedit. ������� ����� �������
HKEY_CURRENT_USER\ControlPanel\Desktop\WindowsMetrics � ������������� �� � �������
����� ������. �������� �������� IconSpasing �� 25. ������������� ������ � ����������
���������. ������������ ����������� ����� ���� � ������. ��� ���� ����������
����������� ������� � ������ ������ �������?', '������������'),
('1', '��������� �������� ������� regedit. ������� ����� ������� HKEY_USERS � ������������� ��
� ������� ����� ������. ������������ ����������� ����� ���� � ������.', '������������'),
('1', '��������� ������� KSysGuard. ������ �������� ����������� �������? �����������
��������� ��������. ��������������� �������������� �������� � ��������������� 10:
���������, ���������, ������ ����������� � ���������� ������, ���������� ���������,
������������ �������, ��� ������������, ������������ �������. ', '������������'),
('1', '��������� ������� KSysGuard. ������ �������� ����������� �������? ��������� �����
���������������� �������. ������� �������� ������ ��������? ��� ��� �������� �� ������
��������? ������� �������� ������ SIGCONT. ��� ��������� � ���������? ���������
������ ��������.', '������������'),
('1', '����������� �������� �������� � ������������������ �� �������� KSysInfo. ���������
������� KSysGuard. ������ �������� ����������� �������? ��������������� ���
�������� �������� ����������.
('1', '���������� �� ����������� ������ ������������ ������� Windows XP', '������������'),
('1', '���������� �� ����������� ������ ������������ ������� Linux.', '������������'),
('1', '����� ��������� ������������ Windows �� ������? ������ �� ����������? ���������
������� ����� � ������ ������������ ������ ������� �: ', '������������'),
('1', '�������� ������� ������ ��� ������������ user. ���������� ����� �� �������������
��������� ������������ � ����� ������ �������������� ��� ���������� ������������', '������������'),
('1', '�������� ������ news. �������� ������� ������ monthly. �������� ����������� � ������.
�������� ��� ������ � monthly �� weekly. ', '������������'),
('1', '�������� � Windows ������� ������ ������������� student � teacher. ���������� �����
������� � ������:
� ����� Otvet ������ ������������ � ��������� ����� ������� ������������ student;
� ����� Zadanie ������������ student ����� ������ ������ �����, � ������������ teacher
����� ��������� � �������� �����.', '������������'),
('1', '�������� ������ news. � ������ �������� ������� ������ tabl� � monthly. ��������� ������
� ������� �������. �������� ����� WORK. ��������� ����� ������ � ���� �����.', '������������'),
('1', '�������� ������� ������ /etc/passwd � /etc/group. ����� ����������� �� �����������', '������������'),
('1', '��������� ������� ��������� ��� ��������� ����� Prog.rar �������� 4 ��, ���� ��������,
��������� �������� ���������� � 15 � �������� 17, 19 ���������������, � 20 �������
�����������. ��� ��� ������ �������� 1024 ����. �������� �� ��������� ������ ��������
��� ������� �����? ���� �� ������ ����� �� ��?', '������������'),
('1', '��������� ������� ��������� �����, ���� ��� ����� 2000 ����, ������ �������� � 1 ������, �
��� ��� ������ ���� �������� ������ �������� 5, 7, 10, 13.', '������������'),
('1', '��������� �������� ������� regedit. ������� ����� �������
HKEY_CURRENT_USER\ControlPanel\Desktop\WindowsMetrics � ������������� �� � �������
����� ������. �������� �������� IconSpasing �� 25. ������������� ������ � ����������
���������. ������������ ����������� ����� ���� � ������. ��� ���� ����������
����������� ������� � ������ ������ �������?', '������������'),
('1', '���������� (� %) ������ ��������� ������� �����, ���� �������������� (�����������)
������ ������� �� ���� ���������� �������� �������� 20% � 15 %. ��������� ���������
DiskDirectSuite. �������� ���� �� ��������� �������.', '������������'),
--��.01. ������������ ������� ������������ �������
('1', '��� ����� ������������ �������, ������������ �����,
������������ ��������?', '�������������'),
('1', '���������� � ������� ������������ �������.', '�������������'),
('1', '������� ������������ ����������, ��� ����������. ���� �����������', '�������������'),
('1', '��������� ���������. ���� ����������.', '�������������'),
('1', 'WIMP-���������. SILK-���������.���� ����������.', '�������������'),
--==================
('1', '����������� � ������� ������������ ������. �������� ��', '�������������'),
('1', '����������� ��: ���� � ��������������� ������, ������ ������ ����������:
����������������� � ����������������, ������ ���� � ����������������� ������', '�������������'),
('1', '�������� ������� Linux: ��������� ��������� �������� �������. �������� �������� Linux', '�������������'),
('1', '��������� ������������ �����������', '�������������'),
('1', '��������� ������� �� ������ ������ �� ����������.�������� ������������ ���������
���������� �� �����������', '�������������'),
('1', '��������� ������� �� ������ ������ �� ����������.�������� ������������ ���������
���������� �� ������������� �����������', '�������������'),
('1', '��������� ������� �� ������ ������ �� ����������.�������� ������������ ���������
���������� �� ���������� �����������', '�������������'),
('1', '���������� � ���� ����������', '�������������'),
('1', '���� ������� (����������, �����������, ����������). ������������� �������
������������� ����������� ������', '�������������'),
('1', '������� ����������� ������.������������� ������ �������������� ���������', '�������������'),
('1', '������� ����������� ������.������������� ������ ������������� ��������� (���������
���������� ��������)', '�������������'),
('1', '������� ����������� ������. ������������� ������ ������������� ���������', '�������������'),
('1', '. ������� ����������� ������. ���������� �������������.', '�������������'),
('1', '������� ����������� ������. ���������� �������������.
('1', '������� ����������� ������. ��������� - ���������� �������������.', '�������������'),
('1', '������ ������������� ����������� ������ ��� ������������� ��������� ������������.
('1', '������ ������������� ����������� ������ � �������������� ��������� ������������.', '�������������'),
('1', '�������, ��� ������� ������ ����������� ������', '�������������'),
('1', '���� � ������ �������� �������. ���� ������. ���������� ������. �������� ������.', '�������������'),
('1', '���������� ����������� ���������� �����: �������, �������, ��������, �������, �������,
������� ��������� ����� �� �������.', '�������������'),
('1', '�������� ������� FAT. ���������� ������� ������� FAT', '�������������'),
('1', '�������� ������� NTFS. ���������� ������� ������� NTFS.', '�������������'),
('1', '������� ������� �� Linux', '�������������'),
('1', '������� ���-������. ������� �������� ���-������', '�������������'),
('1', '������� ������� MS DOS.', '�������������'),
('1', '������ Windows: �������� �������, �����, ������� ��������������. ', '�������������'),
('1', '��������� ������ ���� ��.
('1', '��������������, ������, �����������, �����', '�������������'),
('1', '����������������� ������� ������� � ����� � �� Windows XP.
('1', '����������������� ������� ������� � ����� � �� Linux.
--��.10. �������������� ������������� ������������� �������
('2', '������� ������, �������������.
����������, ���������� � �������������� ������.
����� ����� ������ ������������� ������� ������.', '�������������'),
('2', '����� ��������������� �������������.
������������� �������.
����������� ���������� ����������������� �������������� ������.', '�������������'),
('2', '���������� ������������ ������ �� ����������� ������ ������.
����� ������ ������������� ���������� ������������ ������ ���� ������� ���� � ������� ������������
� ������� ���������� ����������� �������.', '�������������'),
('2', '�������� ������������.
������������ ������ ������������.
������ ���������� ����������������� ���������� ��������
� ������������������� ����������������� ����������.', '�������������'),
('2', '����������� ��������.
���������������� ��������� � ����� �������.
������������ � �������� ������.
���������� ������.
������ �� ���������� ��������� ��������.', '�������������'),
('2', '������������� �������.', '�������������'),
('2', '�������� ����� ��������������� �������������.', '�������������'),
('2', '�������������� ������ ������������ ������.', '�������������'),
('2', '�������������� ������ ������ � ������� ���������.', '�������������'),
('2', '�������������� ������ ������ � �����.', '�������������'),
('2', '��������� �������� � �� �������������.', '�������������'),
('2', '�������������� ������ ������ � �����������.', '�������������'),
('2', '�������, ������ � �������� ������� ���������������
����������������.', '�������������'),
('2', '������������� ����� ��������������� ����������������.', '�������������'),
('2', '������ ��������� ���������������� � �� ����� �����.', '�������������'),
('2', '���������� ������ ��������� ���������������� � ������������
�����.', '�������������'),
('2', '�������������� ������������� ������ ��������� ����������������.', '�������������'),
('2', '��������� ��������� ������� ������ ���������
����������������.', '�������������'),
('2', '����� �������������� �������� � ������.', '�������������'),
('2', '���������� ��������� �������� � �������.', '�������������'),
('2', '�������� ������������� ����� ������ ��������� ����������������.', '�������������'),
('2', '����� ���������� ������ ����� � ������ �������� � ������.', '�������������'),
('2', '��������������� ������.', '�������������'),
('2', '������ ������������ ������ � ����� �������.', '�������������'),
('2', '������������ ������������ ������.', '�������������'),
('2', '����� ������-��������� ����.', '�������������'),
('2', '����� �������������� ������ �����������.', '�������������'),
('2', '�������� ����� ������������ ������ �� �������������.', '�������������'),
('2', '���������� ������ ����� � ������ �����������.', '�������������'),
('2', '�������, ������� ���������� � �������� ������� ������ ������.', '�������������'),
('2', '������� � ������� ���������� ������� �������� ������������ �
����������.', '�������������'),
('2', '������� ������ � ��� ��������.', '�������������'),
('2', '��������� ������� � �����.', '�������������'),
('2', '�������� ������� ���������� �������� �������.', '�������������'),
('2', '����������� ���� � ��� �������������� �����.', '�������������'),
('2', '���������� ������ � ���������� ��������.', '�������������'),
('2', '���������� ������ � ������������ ������.', '�������������'),
('2', '������ � ��� ���������� �����������.', '�������������'),
('2', '������� ����� � ����������.', '�������������'),
('2', '����������� ������ ������ � ������.', '�������������'),
('2', '���������� ������ ������������.', '�������������'),
('2', '�������� ���������� ������� �������� � ������ ������������.', '�������������'),
('2', '�������� ������� ��������� ��������� �� �����.', '�������������'),
('2', '�������� ����������� � ������.', '�������������'),
('2', '������� ������� � ��� ��������.', '�������������'),
--��.10. �������������� ������������� ������������ �������
('2', '���������� ���������� �������������� �������.', '������������'),
('2', '������� ���������� ����������������� �����', '������������'),
('2', '������ ���� ��� ��������� ����������������', '������������'),
('2', '������� ����� ��������� ����������������
���������������', '������������'),
('2', '���������� ���������� ������� ������������
������. ������� ������������ ������ ������� �����������', '������������'),
('2', '�������� ��������� ������.', '������������'),
('2', '���� ������� ����� ��������� ����������������.', '������������'),
('2', '���� ������ ����������� ����.', '������������'),
('2', '���� ������ � ���������� ����������� ����.', '������������'),
('2', '�������� ������ ����������� ������������� ������.', '������������'),
('2', '�������� ������ ����� � ������� ������������� �������������,
�������� � ����������� ������� ��������� ������������.', '������������'),
('2', '������������� ������� ���������� ��������.', '������������'),
('2', '�������� ������� � ������������� ����������� �������.', '������������'),
('2', '�������� ������� � ��������������� ����������� �������.', '������������'),
('2', '����������� � ���������� ������� � ������������� �����������
�������.', '������������'),
('2', '����������� � ���������� ������� � ��������������� �����������
�������.', '������������'),
('2', '�������� ������� ������������ ������� ���������� ������ ��
������ � ������������� �������.', '������������'),
('2', '���� ������������� ������ ���������� ��������.', '������������'),
('2', '������� ����������� ������������ ������� ������ �� �������������
������ � �������� ����������� ��� ������������ ������������ �������.', '������������'),
('2', '����������� ������������� ������������� ������ ����������
��������.', '������������'),
('2', '���������� ������ ���������� �������� � ������ ������� ��
������������������ ������.', '������������'),
('2', '������� ����������� ������������ ������ ������ � ������ �������
�� ������������������ ������.', '������������'),
('2', '����������� ������� ������ ������������� � �� ������� ��
������������� ��������� ������������ �������.', '������������'),
('2', '����������� �������� ��������� ������� ������: �������, ������,
���� � �� ��������������.', '������������'),
('2', '�������� ����� ������� �������.', '������������'),
('2', '����������� � ���������� ���� ������� �������.', '������������'),
('2', '������������������ ���������� �������� ������� �������������
������������� ����������.', '������������'),
('2', '����������� ������� ������������ ����� � ������������ ���� ��
������� ������.', '������������'),
('2', '����������� ������������� �����, ����� � ��� �� ��������������.', '������������'),
('2', '������� ������������� ������� ������� �� �����������������.', '������������'),
('2', '����������� ��� ������� ����������� ���������� ����� �� ��������
������� � �������� �����.', '������������'),
('2', '��� ���������� ��������� ������ ������� �� ������� �������, ����
����������� �������������� ���������� ������������� ������, � ��������� ����
��������� ����� �� ������� ��������.', '������������'),
('2', '����������� ������� ����������� ������������� �����������.', '������������'),
('2', '�������������� ���� � �������������� ������ � ������ �������������
����������.', '������������'),
('2', '������������������ ��������� �������������� ������ � ������
������������� ����������.', '������������'),
('2', '���� ��������������� ������� � �������������� �������������
���������� � �������� �����������.', '������������'),
('2', '���� ��������������� �� ������ ��������������� �������.', '������������'),
('2', '�������� ��������������� �������� ��������.', '������������'),
('2', '�������� ������������� ��������������� ������.', '������������'),
('2', '���� �������� �������� �������� � ������� ���������� ������ ��
������ �������� �������.', '������������'),
('2', '���� ����������� �������������� ������. ����� ������
��������������� ����������� ����������.', '������������'),
('2', '�������� ������ ��������� ����������� ������� � �����������
������� ��������� ����������������.', '������������'),
('2', '������� ����� � �������� �������, �������� � �����������
������� ��������� ����������������.', '������������'),
('2', '������������� ������ � ������������� �������.', '������������'),
('2', '������������� ��������������� ��������� � ���� �������������.', '������������'),
('2', '������������������ ������� ������ ��������� ��������.', '������������'),
--���.02.01. �������������������� ������� � ���� ������������� �������
('3', '�������������� ����������� �������� ����������� ������� � ��������� ������������ ����������.
����������� ����������� ����������� �������� ����������� �������.
���� ������ � ������ ����������� ������ ����������� ����������� ��������.', '�������������'),
('3', '�������������� ����������� �������� ������������.
���� ������ � ������ ����������� ���������� �����.
����������� �������� ���������� ����.', '�������������'),
('3', '���� ����������� ���������� ������.
����������� �� ������� �������� �������,
��������, �����������.
����������� ������� ���������� �������� � ������������ ������.', '�������������'),
('3', '�������������� �������� �������� ���������� ����.
���� ����������� �������������� ����������� ��������� �� ���������� �����.
���� ����������� ������������� ������ ����������� ���������
�� ���������� �����.', '�������������'),
('3', '���� ����������� 1 ���������� �����.
���� ����������� 2 ���������� �����.
���� ����������� 3 ���������� �����.', '�������������'),
('3', '���������� �������������� �����.', '�������������'),
('3', '������������� �������������� ����� �� �������.', '�������������'),
('3', '������������� �������������� ����� �� ���� ���������.', '�������������'),
('3', '������������� �������������� ����� �� ���� ���������������
��������������.', '�������������'),
('3', '������������� �������������� ����� �� ���� ����������, ����� � ��������
��������.', '�������������'),
('3', '��������� ������ ����. �������� � ���� ����������.', '�������������'),
('3', '��������� ������ ����. ��������� ������ OSI.', '�������������'),
('3', '��������� ������ ����. ��������� ������ TCP/IP.', '�������������'),
('3', '��������� ������ ����. ��������� ��������� ������.', '�������������'),
('3', '������� ���������� � ������� ��������. ��������� ������� ����������.', '�������������'),
('3', '������� ���������� � ������� ��������. �������� ������� ����������.', '�������������'),
('3', '����� � ������ �����. ���� �������. ��������� � ��������� ����.', '�������������'),
('3', '��������� ����� �����. ����� ����.', '�������������'),
('3', '��������� ����� �����. ������������ ������.', '�������������'),
('3', '��������� ����� �����. �������������� ������.', '�������������'),
('3', '������������ ����� �����. ����������. ����������� �����.', '�������������'),
('3', '������� ������� ����������. ����� ������� CSMA/CD � ��������� ������.', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������ ����� Ethernet.', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������������ Ethernet
10Base-5.', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������������ Ethernet
10Base-2.', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������������ Ethernet
10Base-T � Ethernet 10Base-FL.', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������������ Fast Ethernet.', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������������ Gigabit
Ethernet..', '�������������'),
('3', '������� ������� ����������. ���������� Ethernet. ������������ 10Gigabit
Ethernet.', '�������������'),
('3', '������� ������� ����������. ���������� Token Ring � FDDI.', '�������������'),
('3', '������������ ����������. Bluetooth. ����������� Bluetooth.', '�������������'),
('3', '������������ ����������. Bluetooth. �������� ������ � Bluetooth.', '�������������'),
('3', '������������ ����������. Bluetooth. ������� Bluetooth.', '�������������'),
('3', '������������ ����������. Bluetooth. ������������ Bluetooth.', '�������������'),
('3', '������������ ����������. Wi-Fi. ����������� Wi-Fi.', '�������������'),
('3', '������������ ����������. Wi-Fi. ��������� Wi-Fi.', '�������������'),
('3', '������������ ����������. Wi-Fi. ����� ������� CSMA/CA � ��������
�������� ����.', '�������������'),
('3', '��������� � �������������� �����. MAC-�����.', '�������������'),
('3', '��������� � �������������� �����. IP-�����. ��������� ���������..', '�������������'),
('3', '��������� � �������������� �����. IP-�����. ������������ ���������.', '�������������'),
('3', '����������� IP-������. ��������� � ������� ������.', '�������������'),
('3', '����������� IP-������. ����������������� ������.', '�������������'),
('3', '����������� IP-������. ��������� ������.', '�������������'),
('3', '����������� IP-������. ����� �������� �����.', '�������������'),
('3', '����������� IP-������. ������ IPv4, ������������ � IPv6.', '�������������'),
('3', '������ IP-������. ��������� ������ IPv4.', '�������������'),
('3', '������ IP-������. ��������� ������ IPv6.', '�������������'),
('3', '��������� � �������������� �����. ������� �������� ����.', '�������������'),
('3', '��������� � �������������� �����. IP-�����. ��������� ���������.', '�������������'),
('3', '��������� � �������������� �����. IP-�����. ������������ ���������.', '�������������'),
('3', '����������� IP-������. ��������� � ������� ������.', '�������������'),
('3', '����������� IP-������. ����������������� ������.', '�������������'),
('3', '����������� IP-������. ��������� ������.', '�������������'),
('3', '����������� IP-������. ����� �������� �����.', '�������������'),
('3', '����������� IP-������. ������ IPv4, ������������ � IPv6.', '�������������'),
('3', '������ IP-������. ��������� ������ IPv4.', '�������������'),
('3', '������ IP-������. ��������� ������ IPv6.', '�������������'),
('3', '��������� � �������������� �����. ������� �������� ����.', '�������������'),
('3', '���� ������ DNS. ������ SOA.', '�������������'),
('3', '���� ������ DNS. ������ A � PTR.', '�������������'),
--���.02.01. �������������������� ������� � ���� ������������ �������
('3', '������ ��������� ���� ���������� Ethernet', '������������'),
('3', '������������ ����������� ������� ����� ����', '������������'),
('3', '��������� ���� �� �������', '������������'),
('3', '����������� ��������� ���������� ������ � ����', '������������'),
('3', '����������� ������������, ���������������� ����������� ���������', '������������'),
('3', '�������� DNS. ��������� � ����� ������ � ��������� DNS-������', '������������'),
('3', '�������� DHCP. ������ IP-������', '������������'),
('3', '�������� ARP. ����������� MAC-������ ��� ��������� IP-������', '������������'),
('3', '�������� ICMP. ���-���������', '������������'),
('3', '�������� ICMP. �������������� ���� ����������', '������������'),
('3', '�������� ICMP. ����������� MAC-������ ��� ��������� ������ IPv6', '������������'),
('3', '����������� ����� � ������� ������. ���������� �������� ����������', '������������'),
('3', '����� � �����, ������������ � ������� ������', '������������'),
('3', '�������� ���������� ������', '������������'),
('3', '����������� ����� � ������� ���������������. ��������� �������������', '������������'),
('3', '��������� �������������. �������� RIPv1', '������������'),
('3', '��������� �������������. �������� RIPv2', '������������'),
('3', '��������� �������������. �������� RIPng.', '������������'),
('3', '��������� �������������. �������� OSPF', '������������'),
('3', '��������� �������������. ������� �������� ���������', '������������'),
('3', '�������������� ������� �������. �������������� ���������� �������', '������������'),
('3', '�������������� ������� �������. ���������� ���������� �������', '������������'),
('3', '�������������� ������� �������. �������������� ��� ���������� �������', '������������'),
('3', '������������ ��������� TCP/IP. �����.', '������������'),
('3', '������������ ��������� TCP/IP. UDP-�����������.', '������������'),
('3', '������������ ��������� TCP/IP. ������������ � ���������� TCP-����������.', '������������'),
('3', '������������ ��������� TCP/IP. ��������� TCP-����������.
('3', '���������� ��������� TCP/IP. �������� FTP.', '������������'),
('3', '���������� ��������� TCP/IP. �������� HTTP.', '������������'),
('3', '���������� ��������� TCP/IP. �������� SMTP.', '������������'),
('3', '���������� ��������� TCP/IP. �������� POP3.', '������������'),
('3', '���������� ��������� TCP/IP. �������� TELNET', '������������'),
('3', '����������������� �������������� �����. ������ ������ ���������� ������.', '������������'),
--���.02.02. ���������� ���������� � ������ ��� ������ ������������� �������
('4', '���� ����������� ����.
����������� � ������ ���������������� �������� ������� ����.
����������� �������� �������� ������� ����������� ����.', '�������������'),
('4', '�������� ������� ����������� ����.
����������� � ���������������� �������� ������� ����������� ����.
����������� �������� �������� ������� ����������� ����.', '�������������'),
('4', '����������� �������� ������ ������.
���������������� ����������� � ���������� ������ ������.
�������������� ������������ ����������� ������.', '�������������'),
('4', '�������������� ����������� � ���������� ����������� ������ ������.
���� ����������� ���������.
����������� � ������ ���������������� ��������������� �������� ���������.', '�������������'),
('4', '���� ����������� ���������.
����������� � ������ ���������������� ��������������� �������� ���������.
���� ����������� ��������� ���������:
��������� ����, ������, �������, ����� ���������, ������� ����.', '�������������'),
--���.02.02. ���������� ���������� � ������ ��� ������ ������������ �������
('4', '�������������� ����������� ����� ����
������ � ����� ����.', '������������'),
('4', '�������� ���� ������ � �����
����������', '������������'),
('4', '���������� ���������� �����������', '������������'),
('4', '��������������� ���� ������ ��
��������� �����', '������������'),
('4', '��������� �����������', '������������'),
--����.03. ����������� ���� ������������� �������
('5', 'Present Continuous � �������������� � ������������� �����', '�������������'),
('5', '���� ��������', '�������������'),
('5', 'Present Simple : �����������, ������������.', '�������������'), 
('5', 'Present Continuous : �����������, ������������.', '�������������'), 
('5', '������� ��������� �������� � ���������', '�������������'),
--����.03. ����������� ���� ������������ �������
('5', '������� ���� � ������� �����������.', '������������'),
('5', '��������� ������ � ������', '������������'),
('5', '������� ����������� � there is, there are.', '������������'),
('5', '������������� �������', '������������'),
('5', '��������������� ������� � ���������� �����', '������������');
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