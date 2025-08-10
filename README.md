# SIMS
# Create database to use 
# edit file appsetting.json to your server

-- Tạo mới database
DROP DATABASE IF EXISTS [SIMS_ASM_FINAL];
CREATE DATABASE [SIMS_ASM_FINAL];
GO
USE [SIMS_ASM_FINAL];
GO

-- Users table
CREATE TABLE [dbo].[Users](
    [UserID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL CHECK ([Role] IN ('Student', 'Teacher', 'Admin')),
    [CreatedAt] DATETIME DEFAULT GETDATE()
);

-- Type table
CREATE TABLE [dbo].[Type](
    [TypeID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [TypeName] NVARCHAR(100),
    [Description] NVARCHAR(255),
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE()
);

-- Admin table
CREATE TABLE [dbo].[Admin](
    [AdminID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100),
    [Email] NVARCHAR(100),
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UserID] INT UNIQUE NULL,
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users]([UserID]) ON DELETE CASCADE
);

-- Class table
CREATE TABLE [dbo].[Class](
    [ClassID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ClassName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255),
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE(),
    [TypeID] INT NULL DEFAULT 1,
    FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type]([TypeID]) ON DELETE SET DEFAULT
);

-- Course table
CREATE TABLE [dbo].[Course](
    [CourseID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [NameCourse] NVARCHAR(100) NOT NULL,
    [DescriptionCourse] NVARCHAR(255),
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE(),
    [TypeID] INT NULL DEFAULT 1,
    FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type]([TypeID]) ON DELETE SET DEFAULT
);

-- Semester table
CREATE TABLE [dbo].[Semester](
    [SemesterID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255),
    [StartDate] DATE,
    [EndDate] DATE,
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE(),
    [TypeID] INT NULL DEFAULT 1,
    FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type]([TypeID]) ON DELETE SET DEFAULT
);

-- Student table
CREATE TABLE [dbo].[Student](
    [StudentID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100),
    [DoB] DATE,
    [Email] NVARCHAR(100),
    [Address] NVARCHAR(200),
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE(),
    [TypeID] INT NULL DEFAULT 1,
    [ClassID] INT NULL,
    [UserID] INT UNIQUE NULL,
    FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type]([TypeID]) ON DELETE SET DEFAULT,
    FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class]([ClassID]) ON DELETE SET NULL,
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users]([UserID])ON DELETE CASCADE
);

-- Teacher table
CREATE TABLE [dbo].[Teacher](
    [TeacherID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100),
    [Email] NVARCHAR(100),
[CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE(),
    [TypeID] INT NULL DEFAULT 1,
    [UserID] INT UNIQUE NULL,
    FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type]([TypeID]) ON DELETE SET DEFAULT,
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users]([UserID])ON DELETE CASCADE
);

-- TeachingAssignment table
CREATE TABLE [dbo].[TeachingAssignment](
    [AssignmentID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ClassID] INT NULL,
    [CourseID] INT NULL,
    [TeacherID] INT NULL,
    [SemesterID] INT NULL,
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [UpdatedAt] DATETIME DEFAULT GETDATE(),
    FOREIGN KEY ([ClassID]) REFERENCES [dbo].[Class]([ClassID]) ON DELETE SET NULL,
    FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course]([CourseID]) ON DELETE SET NULL,
    FOREIGN KEY ([TeacherID]) REFERENCES [dbo].[Teacher]([TeacherID]) ON DELETE SET NULL,
    FOREIGN KEY ([SemesterID]) REFERENCES [dbo].[Semester]([SemesterID]) ON DELETE SET NULL
);
INSERT INTO [dbo].[Users] (Username, PasswordHash, Role)
VALUES (N'admin', N'123456', N'Admin');

DECLARE @NewUserID INT;
SET @NewUserID = SCOPE_IDENTITY();

-- 3. Thêm thông tin admin vào bảng Admin
INSERT INTO [dbo].[Admin] (Name, Email, UserID)
VALUES (N'Nguyễn Văn Quản Trị', N'admin@sims.com', @NewUserID);
insert TeachingAssignment (ClassID, TeacherID, CourseID, SemesterID) values (5, 1, 2, 2)
insert TeachingAssignment (ClassID, TeacherID, CourseID, SemesterID) values (5, 1, 3, 2)
insert TeachingAssignment (ClassID, TeacherID, CourseID, SemesterID) values (5, 6, 4, 2)
