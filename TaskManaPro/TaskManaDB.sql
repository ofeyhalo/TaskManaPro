-- Step 1: Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TaskManaDB')
BEGIN
    CREATE DATABASE TaskManaDB;
END
GO

-- Step 2: Switch to the TaskManaDB context
USE TaskManaDB;
GO

-- Step 3: Create the tables inside TaskManaDB
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Fullname NVARCHAR(50) NOT NULL,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Boards (
    BoardId INT PRIMARY KEY IDENTITY(1,1),
    BoardName NVARCHAR(100) NOT NULL,
    UserId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

CREATE TABLE Lists (
    ListId INT PRIMARY KEY IDENTITY(1,1),
    ListTitle NVARCHAR(100) NOT NULL,
    BoardId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BoardId) REFERENCES Boards(BoardId)
);
GO

CREATE TABLE Tasks (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    TaskTitle NVARCHAR(255) NOT NULL,
    TaskDescription TEXT,
    DueDate DATETIME,
    ListId INT NOT NULL,
    FOREIGN KEY (ListId) REFERENCES Lists(ListId)
);
GO

CREATE TABLE Labels (
    LabelId INT PRIMARY KEY IDENTITY(1,1),
    LabelName NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE TaskLabels (
    TaskId INT NOT NULL,
    LabelId INT NOT NULL,
    PRIMARY KEY (TaskId, LabelId),
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY (LabelId) REFERENCES Labels(LabelId)
);
GO

CREATE TABLE Checklists (
    ChecklistId INT PRIMARY KEY IDENTITY(1,1),
    TaskId INT NOT NULL,
    ChecklistItem NVARCHAR(255) NOT NULL,
    IsCompleted BIT DEFAULT 0,
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId)
);
GO
