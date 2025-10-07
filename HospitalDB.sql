CREATE DATABASE HospitalDB
go
use HospitalDB
go

CREATE TABLE Patients(
		ID					INT PRIMARY KEY ,
		[Name]				NVARCHAR(25) NOT NULL,
		Condition			NVARCHAR(max) NOT NULL,
);
go
CREATE TABLE Appointments (
    Id					INT PRIMARY KEY IDENTITY(1,1),
    Pat_ID				INT REFERENCES Patients(ID),
    [DateTime]			DATETIME NOT NULL
);

go
INSERT INTO Patients VALUES 
(1,'Ahmed', 'Flu'),
(2,'Mido', 'Diabetes'),
(3,'Amir', 'High Blood Pressure'),
(4,'Laila', 'Asthma');
go
INSERT INTO Appointments VALUES (1, '2025-10-07 09:30:00'),
       (2, '2025-10-08 11:00:00'),
       (3, '2025-10-09 14:15:00'),
       (1, '2025-10-09 14:15:00'),
       (4, '2025-10-09 14:15:00');

go
select * from Patients
SELECT * FROM Appointments;
