------------------------------------
-- Setup Database PeopleSharp     --
--                                --
-- Run on (tested on):            --
-- Microsoft SQL Server 2019      --
------------------------------------

CREATE DATABASE PeopleSharp;
GO

USE PeopleSharp;
GO

CREATE TABLE Employee
(
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(64) NOT NULL,
    LastName NVARCHAR(64) NOT NULL,
    JobTitle NVARCHAR(256) NOT NULL,
    DateOfEmployment DATETIME2 NOT NULL,
    Department_Id BIGINT, -- Connection to the department in which this employee works (see FK_Department). An employee works only in one department.
    DirectManager_Id BIGINT, -- Connection to the direct manager of this employee (see FK_DirectManager).
    VacationDays INT NOT NULL CHECK (VacationDays >= 0)
);

CREATE TABLE Manager
(
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    Employee_Id BIGINT NOT NULL, -- In C# code Manager is inherited class from base class Employee. In this database inheritance is represented using Class Table Inheritance (aka Table Per Type Inheritance).
    --DepartmentHead is defined in the table Manager_Departments. A single manager can be a head of multiple departments.
);

CREATE TABLE Department
(
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    DepartmentName NVARCHAR(64) NOT NULL,
    HeadOfDepartment_Id BIGINT, -- Connection to a manager that is the head of this employee.
    ParentDepartment_Id BIGINT, -- Parent department is a bigger department, and this department is a part of the parent department -> this department is a subdepartment of parent department.
    -- EmployeesDirectlyInDepartment are defined in the table Employee - employees that work directly in this department, and not in any of subdepartments, have Id of this department in Department_Id.
);

-- Add foreign keys between table Employee and other tables, now that other tables have been defined.
ALTER TABLE Employee ADD CONSTRAINT FK_Employee_Department FOREIGN KEY (Department_Id) REFERENCES Department (Id);
ALTER TABLE Employee ADD CONSTRAINT FK_Employee_DirectManager FOREIGN KEY (DirectManager_Id) REFERENCES Manager (Id);

-- Connection between a manager and one-or-more department(s): which department(s) are under a certain manager.
CREATE TABLE Manager_Departments
(
	Manager_Id BIGINT NOT NULL,
	Department_Id BIGINT NOT NULL,
	CONSTRAINT FK_MngDepart_Manager FOREIGN KEY (Manager_Id) REFERENCES Manager (Id),
	CONSTRAINT FK_MngDepart_Department FOREIGN KEY (Department_Id) REFERENCES Department (Id)
);

-- Connection between department and its subdepartments.
CREATE TABLE Department_Subdepartment
(
	Department_Id BIGINT NOT NULL,
    Subdepartment_Id BIGINT NOT NULL,	
	CONSTRAINT FK_DepSubdep_Department FOREIGN KEY (Department_Id) REFERENCES Department (Id),
    CONSTRAINT FK_DepSubdep_Subdepartment FOREIGN KEY (Subdepartment_Id) REFERENCES Department (Id)
);
