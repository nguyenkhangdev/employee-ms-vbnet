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

CREATE PROCEDURE sp_Employee_GetOneById
(
    @EmployeeId INT
)
AS
BEGIN
    SELECT
        e.EmployeeId,
        e.EmployeeCode,
        e.FullName, 
        e.Email,
        e.Phone,
        e.Position,
        e.Salary,
        e.DepartmentId
    FROM Employees e 
 
    Where e.EmployeeId = @EmployeeId and e.IsDeleted = 0
END
GO

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
GO


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
GO


 CREATE PROCEDURE sp_Employee_Insert
(
    @EmployeeCode VARCHAR(20),
    @FullName NVARCHAR(100),
    @Email VARCHAR(100),
    @Phone VARCHAR(20),
    @DepartmentId INT,
    @Position NVARCHAR(50),
    @Salary DECIMAL(18,2)
)
AS
BEGIN

    INSERT INTO Employees
    (
        EmployeeCode,
        FullName,
        Email,
        Phone,
        DepartmentId,
        Position,
        Salary
    )
    VALUES
    (
        @EmployeeCode,
        @FullName,
        @Email,
        @Phone,
        @DepartmentId,
        @Position,
        @Salary
    )

END

CREATE PROCEDURE sp_Employee_Update
(
    @EmployeeId INT,
    @EmployeeCode VARCHAR(20),
    @FullName NVARCHAR(100),
    @Email VARCHAR(100),
    @Phone VARCHAR(20),
    @DepartmentId INT,
    @Position NVARCHAR(50),
    @Salary DECIMAL(18,2)
)
AS
BEGIN

    UPDATE Employees
    SET
        EmployeeCode = @EmployeeCode,
        FullName = @FullName,
        Email = @Email,
        Phone = @Phone,
        DepartmentId = @DepartmentId,
        Position = @Position,
        Salary = @Salary,
        UpdatedAt = GETDATE()
    WHERE EmployeeId = @EmployeeId

END
GO

CREATE PROCEDURE sp_Employee_Delete
(
    @EmployeeId INT
)
AS
BEGIN

    UPDATE Employees
    SET
        IsDeleted = 1,
        UpdatedAt = GETDATE()
    WHERE EmployeeId = @EmployeeId

END
GO

CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY(1,1),

    Username VARCHAR(50) NOT NULL UNIQUE,

    PasswordHash VARCHAR(255) NOT NULL,

    FullName NVARCHAR(100),

    RoleId INT,

    IsActive BIT DEFAULT 1,

    CreatedAt DATETIME DEFAULT GETDATE(),

    UpdatedAt DATETIME NULL,

    IsDeleted BIT DEFAULT 0
);

CREATE TABLE Roles
(
    RoleId INT PRIMARY KEY IDENTITY(1,1),

    RoleName VARCHAR(50) NOT NULL,

    CreatedAt DATETIME DEFAULT GETDATE()
);

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Roles
FOREIGN KEY (RoleId)
REFERENCES Roles(RoleId);

INSERT INTO Roles(RoleName)
VALUES
('Admin'),
('HR'),
('Manager'),
('Staff');

CREATE PROCEDURE sp_User_Login
(
    @Username VARCHAR(50),
    @PasswordHash VARCHAR(255)
)
AS
BEGIN

    SELECT
        u.UserId,
        u.Username,
        u.FullName,
        r.RoleName
    FROM Users u
    INNER JOIN Roles r
        ON u.RoleId = r.RoleId
    WHERE
        u.Username = @Username
        AND u.PasswordHash = @PasswordHash
        AND u.IsDeleted = 0
        AND u.IsActive = 1

END

INSERT INTO Users
(
    Username,
    PasswordHash,
    FullName,
    RoleId
)
VALUES
(
    'admin',
    'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=',
    N'System Administrator',
    1
);

CREATE TABLE Permissions
(
    PermissionId INT PRIMARY KEY IDENTITY(1,1),

    PermissionCode VARCHAR(50) NOT NULL,

    PermissionName NVARCHAR(100) NOT NULL
);

CREATE TABLE RolePermissions
(
    RoleId INT NOT NULL,

    PermissionId INT NOT NULL,

    PRIMARY KEY(RoleId, PermissionId),

    CONSTRAINT FK_RolePermissions_Roles
    FOREIGN KEY(RoleId)
    REFERENCES Roles(RoleId),

    CONSTRAINT FK_RolePermissions_Permissions
    FOREIGN KEY(PermissionId)
    REFERENCES Permissions(PermissionId)
);

INSERT INTO Permissions
(
    PermissionCode,
    PermissionName
)
VALUES
('EMPLOYEE_VIEW', N'View Employee'),
('EMPLOYEE_ADD', N'Add Employee'),
('EMPLOYEE_UPDATE', N'Update Employee'),
('EMPLOYEE_DELETE', N'Delete Employee');

INSERT INTO RolePermissions
(RoleId, PermissionId)
VALUES
(1,1),
(1,2),
(1,3),
(1,4);

INSERT INTO RolePermissions
(RoleId, PermissionId)
VALUES
(2,1),
(2,2),
(2,3);

INSERT INTO RolePermissions
(RoleId, PermissionId)
VALUES
(3,1);

CREATE PROCEDURE sp_Permission_GetByUser
(
    @UserId INT
)
AS
BEGIN

    SELECT
        p.PermissionCode
    FROM Users u
    INNER JOIN Roles r
        ON u.RoleId = r.RoleId
    INNER JOIN RolePermissions rp
        ON r.RoleId = rp.RoleId
    INNER JOIN Permissions p
        ON rp.PermissionId = p.PermissionId
    WHERE
        u.UserId = @UserId

END

INSERT INTO Users (Username, PasswordHash, FullName, RoleId)
VALUES
('hr01',   'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=',     N'HR Staff 01',  2),
('mgr01',  'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=',    N'Manager 01',   3),
('staff01',   'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=',     N'Staff 01',  4);
 