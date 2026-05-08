CREATE DATABASE EmployeeManagementDB;
GO

USE EmployeeManagementDB;
GO

CREATE TABLE Employees
(
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeCode VARCHAR(20) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Position NVARCHAR(50),
    Salary DECIMAL(18,2),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    IsDeleted BIT DEFAULT 0
);
GO;

CREATE TABLE Departments
(
    DepartmentId INT PRIMARY KEY IDENTITY(1,1),
    DepartmentCode VARCHAR(20) NOT NULL,
    DepartmentName NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    IsDeleted BIT DEFAULT 0
);
GO;

ALTER TABLE Employees
ADD DepartmentId INT;

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments
FOREIGN KEY (DepartmentId)
REFERENCES Departments(DepartmentId);

INSERT INTO Employees
(
    EmployeeCode,
    FullName,
    Email,
    Phone,
    Position,
    Salary
)
VALUES
('EMP001', N'Nguyen Van A', 'a@test.com', '0900000001', N'Developer', 1000),
('EMP002', N'Tran Van B', 'b@test.com', '0900000002', N'Tester', 900);

INSERT INTO Departments
(
    DepartmentCode,
    DepartmentName
)
VALUES
('IT', N'Information Technology'),
('HR', N'Human Resources'),
('ACC', N'Accounting');
UPDATE Employees
SET DepartmentId = 1
WHERE EmployeeId = 1;

UPDATE Employees
SET DepartmentId = 2
WHERE EmployeeId = 2;

SELECT
    e.EmployeeId,
    e.EmployeeCode,
    e.FullName,
    d.DepartmentName,
    e.Position,
    e.Salary
FROM Employees e
INNER JOIN Departments d
    ON e.DepartmentId = d.DepartmentId
WHERE e.IsDeleted = 0;

CREATE PROCEDURE sp_Employee_GetAll
AS
BEGIN

    SELECT
        e.EmployeeId,
        e.EmployeeCode,
        e.FullName,
        d.DepartmentName,
        e.Position,
        e.Salary
    FROM Employees e
    INNER JOIN Departments d
        ON e.DepartmentId = d.DepartmentId
    WHERE e.IsDeleted = 0

END

CREATE PROCEDURE sp_Department_GetAll
AS
BEGIN

    SELECT
        DepartmentId,
        DepartmentName
    FROM Departments
    WHERE IsDeleted = 0
    ORDER BY DepartmentName

END

 