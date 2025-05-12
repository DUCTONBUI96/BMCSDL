-- =============================
-- DATABASE: PassportManagement
-- Generated on 2025-05-04 13:27:45
-- =============================

-- Drop database if exists (optional)
-- DROP DATABASE IF EXISTS PassportManagement;
CREATE DATABASE PassportManagement;
GO

USE PassportManagement;
GO

-- =====================
-- USERS & ROLES
-- =====================
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Salt NVARCHAR(255) NOT NULL,
    IsLocked BIT DEFAULT 0,
    FailedLoginAttempts INT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE UserRoles (
    UserID INT,
    RoleID INT,
    PRIMARY KEY (UserID, RoleID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- =====================
-- FORM REGISTRATION (PRE-STAGE)
-- =====================
CREATE TABLE ApplicationForms (
    FormID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Gender NVARCHAR(10),
    DateOfBirth DATE,
    CMND VARCHAR(20),
    Address NVARCHAR(255),
    Nationality NVARCHAR(50),
    PhoneNumber VARCHAR(20),
    Email NVARCHAR(100),
    SubmissionTime DATETIME DEFAULT GETDATE(),
    VerifiedBy INT,
    VerificationTime DATETIME,
    FOREIGN KEY (VerifiedBy) REFERENCES Users(UserID)
);

-- =====================
-- RESIDENT INFO
-- =====================
CREATE TABLE ResidentData (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Gender NVARCHAR(10),
    DateOfBirth DATE,
    CMND VARCHAR(20) UNIQUE,
    Address NVARCHAR(255),
    Nationality NVARCHAR(50),
    PhoneNumber VARCHAR(20),
    Email NVARCHAR(100)
);

-- =====================
-- APPLICATION PROCESSING
-- =====================
CREATE TABLE PassportApplications (
    ApplicationID INT PRIMARY KEY IDENTITY(1,1),
    ResidentID INT,
    SubmissionDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50),
    ReviewedBy INT,
    ApprovedBy INT,
    ReviewNotes NVARCHAR(500),
    ApprovalNotes NVARCHAR(500),
    XT_Status NVARCHAR(20),
    XD_Status NVARCHAR(20),
    LT_Status NVARCHAR(20),
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID),
    FOREIGN KEY (ReviewedBy) REFERENCES Users(UserID),
    FOREIGN KEY (ApprovedBy) REFERENCES Users(UserID)
);

CREATE TABLE ApplicationWorkflow (
    WorkflowID INT PRIMARY KEY IDENTITY(1,1),
    ApplicationID INT,
    Step NVARCHAR(50),
    Action NVARCHAR(50),
    ActionBy INT,
    ActionTime DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(500),
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID),
    FOREIGN KEY (ActionBy) REFERENCES Users(UserID)
);

CREATE TABLE ApplicationAttachments (
    AttachmentID INT PRIMARY KEY IDENTITY(1,1),
    ApplicationID INT,
    FileName NVARCHAR(255),
    FilePath NVARCHAR(500),
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID)
);

CREATE TABLE PassportData (
    PassportID INT PRIMARY KEY IDENTITY(1,1),
    ResidentID INT,
    ApplicationID INT,
    PassportNumber VARCHAR(20) UNIQUE,
    IssueDate DATE,
    ExpiryDate DATE,
    IssuedBy INT,
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID),
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID),
    FOREIGN KEY (IssuedBy) REFERENCES Users(UserID)
);

-- =====================
-- NOTIFICATIONS
-- =====================
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    ResidentID INT,
    ApplicationID INT,
    Message NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsRead BIT DEFAULT 0,
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID),
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID)
);

-- =====================
-- LOGGING & AUDIT
-- =====================
CREATE TABLE Logs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Action NVARCHAR(255),
    ActionTime DATETIME DEFAULT GETDATE(),
    IPAddress NVARCHAR(50),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE LoginHistory (
    LoginID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    LoginTime DATETIME DEFAULT GETDATE(),
    IsSuccess BIT,
    IPAddress NVARCHAR(50),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE AuditTrail (
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    TableName NVARCHAR(50),
    RecordID INT,
    Action NVARCHAR(20),
    ChangedBy INT,
    ChangeTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ChangedBy) REFERENCES Users(UserID)
);

-- =====================
-- ACCESS CONTROL
-- =====================
CREATE TABLE AccessControl (
    RoleID INT,
    ObjectName NVARCHAR(50),
    PermissionType NVARCHAR(20),
    ExpiryDate DATETIME NULL,
    PRIMARY KEY (RoleID, ObjectName, PermissionType),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- =====================
-- INITIAL ROLES & PERMISSIONS (OPTIONAL)
-- =====================
INSERT INTO Roles (RoleName) VALUES ('XT'), ('XD'), ('LT'), ('GS');

-- AccessControl sample setup would be configured later via app logic
INSERT INTO Users (
    Username,
    PasswordHash,
    Salt,
    IsLocked,
    FailedLoginAttempts,
    CreatedAt
)
VALUES (
    'Ton',
    123456,
    '2fae9c3a-2a0f-4db1-9cfc-d4e03f7b4c3f',
    0,
    0,
    '2025-05-11 14:30:00'
);
select * from Users

