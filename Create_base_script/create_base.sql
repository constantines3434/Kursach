
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
VALUES ('Смирнов', 'Константин', 'Вадимович'),
('Ларионова', 'Елена', 'Анатольевна'),
('Мурашов', 'Анатолий', 'Алексеевич'),
('Глускер', 'Александр', 'Игоревич'),
('Александров', 'Роман', 'Викторович');

--DROP TABLE Chairman_pck;
INSERT INTO Chairman_pck (surname, name_, patronymic)
VALUES ('Няшный', 'Константин', 'Вадимович'),
('Ларионова', 'Елена', 'Анатольевна'),
('Мурашов', 'Анатолий', 'Алексеевич'),
('Глускер', 'Александр', 'Игоревич'),
('Александров', 'Роман', 'Викторович');

--DELETE FROM Speciality;
INSERT INTO Speciality (code_speciality, name_of_speciality)
VALUES ('09.02.06', 'Сетевое и системной администрирование'),
('09.02.07', 'Информационные системы и программирование'),
('10.02.05', 'Обеспечение информационной безопасности автоматизированных систем'),
('21.02.19', 'Землеустройство'),
('42.02.01', 'Реклама');

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
VALUES ('ОП.01.', 'Операционные системы'),
('ОП.10.', 'Математическое моделирование'),
('МДК.02.01.', 'Инфокоммуникационные системы и сети'),
('МДК.02.02.', 'Технология разработки и защиты баз данных'),
('ОГСЭ.03.', 'Иностранный язык');

--DELETE FROM Kurs;
INSERT INTO Kurs (nom_kurs)
VALUES ('1'),
('2'),
('3'),
('4'),
('5');

--DELETE FROM Komplect_tickets;
INSERT INTO Komplect_tickets (nom_kurs, nom_semester, nom_protocol, id_discipline)
VALUES ('1', '1', '1', 'МДК.02.01.'),
('2', '2', '2', 'МДК.02.02.'),
('3', '3', '3', 'ОГСЭ.03.'),
('4', '4', '4', 'ОП.01.'),
('5', '5', '5', 'ОП.10.');

--DELETE FROM Questions;
INSERT INTO Questions (id_discipline, question, type_question, cheking)
VALUES ('МДК.02.01.', 'Как зовут Льва Толстого', 'Теоретический', 0),
('МДК.02.02.', 'Сколько яблок в коробке с 4 яблоками', 'Теоретический', 0),
('ОГСЭ.03.', 'Докажите существование бога', 'Практический', 0),
('ОП.01.', 'Создайте сайт', 'Практический', 0),
('ОП.10.', 'Решите пример: 2+2', 'Практический', 0);

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