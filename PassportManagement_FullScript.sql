-- Tạo database
CREATE DATABASE PassportManagement;
GO

-- Sử dụng database
USE PassportManagement;
GO

-- Tạo bảng Roles
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255) NULL
);
GO

-- Tạo bảng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Salt NVARCHAR(255) NOT NULL,
    OTPCode NVARCHAR(10) NULL, -- Thêm cho 2FA
    OTPExpiry DATETIME NULL, -- Thời gian hết hạn OTP
    IsLocked BIT DEFAULT 0,
    FailedLoginAttempts INT DEFAULT 0,
    RoleID INT NOT NULL,
    LastLoginTime DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    ExpiryDate DATETIME NULL,
    IsActive BIT DEFAULT 1,
    LockedUntil DATETIME NULL,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO

-- Tạo bảng ResidentData
CREATE TABLE ResidentData (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    DateOfBirth DATE NOT NULL,
    CMND VARCHAR(20) UNIQUE NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Nationality NVARCHAR(50) NOT NULL DEFAULT N'Việt Nam',
    PhoneNumber VARCHAR(20),
    Email NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    SensitivityLevel INT DEFAULT 1,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);
GO

-- 1. Xóa ràng buộc khóa ngoại
ALTER TABLE ResidentData
DROP CONSTRAINT FK__ResidentD__Creat__45F365D3;  -- thay bằng tên đúng nếu khác

-- 2. Xóa cột
ALTER TABLE ResidentData
DROP COLUMN CreatedBy;

-- Xóa toàn bộ dữ liệu
DELETE FROM ResidentData;

-- Reset lại cột IDENTITY (ResidentID) về 1
DBCC CHECKIDENT ('ResidentData', RESEED, 0);

select * from ResidentData


-- Tạo bảng PassportApplications
CREATE TABLE PassportApplications (
    ApplicationID INT PRIMARY KEY IDENTITY(1,1),
    ResidentID INT NOT NULL,
    SubmissionDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL DEFAULT N'Chờ xét duyệt',
    ReviewedBy INT NULL,
    ReviewDate DATETIME NULL,
    ReviewNotes NVARCHAR(255) NULL,
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID),
    FOREIGN KEY (ReviewedBy) REFERENCES Users(UserID)
);
GO
select * from PassportApplications;

--Trigger tự động thêm dữ liệu vào PA 
create trigger InsertInto_PassportApplications
On ResidentData
After Insert
As 
Begin
    Set NOCOUNT ON;

	Insert Into PassportApplications(ResidentID)
	Select ResidentID
	From inserted;
End;
select * from ResidentData;
SELECT ResidentID
FROM PassportApplications;


-- Tạo bảng PassportData
CREATE TABLE PassportData (
    PassportID INT PRIMARY KEY IDENTITY(1,1),
    ApplicationID INT NOT NULL UNIQUE,
    ResidentID INT NOT NULL,
    PassportNumber VARCHAR(20) UNIQUE NOT NULL,
    IssueDate DATE NOT NULL,
    ExpiryDate DATE NOT NULL,
    IssuedBy INT NOT NULL,
    IssuedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID),
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID),
    FOREIGN KEY (IssuedBy) REFERENCES Users(UserID)
);
GO

-- Tạo bảng SystemLogs
CREATE TABLE SystemLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ActionType NVARCHAR(50) NOT NULL,
    EntityType NVARCHAR(50) NOT NULL,
    EntityID INT NULL,
    Description NVARCHAR(MAX) NULL,
    IPAddress NVARCHAR(50) NULL,
    ActionTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- Tạo bảng RolePermissions
CREATE TABLE RolePermissions (
    RoleID INT NOT NULL,
    ObjectName NVARCHAR(50) NOT NULL,
    CanView BIT NOT NULL DEFAULT 0,
    CanCreate BIT NOT NULL DEFAULT 0,
    CanUpdate BIT NOT NULL DEFAULT 0,
    CanDelete BIT NOT NULL DEFAULT 0,
    PRIMARY KEY (RoleID, ObjectName),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO

-- Tạo bảng Attachments 
CREATE TABLE Attachments (
    AttachmentID INT PRIMARY KEY IDENTITY(1,1),
    ApplicationID INT NOT NULL,
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID)
);
GO

-- Tạo bảng AuditTrails 
CREATE TABLE AuditTrails (
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    TableName NVARCHAR(50) NOT NULL,
    RecordID INT NOT NULL,
    ActionType NVARCHAR(50) NOT NULL,
    OldValue NVARCHAR(MAX) NULL,
    NewValue NVARCHAR(MAX) NULL,
    UserID INT NOT NULL,
    ActionTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- Tạo bảng Notifications 
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    ResidentID INT NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    SentAt DATETIME DEFAULT GETDATE(),
    SentStatus NVARCHAR(50) NOT NULL DEFAULT N'Pending',
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID)
);
GO

-- Tạo bảng SecurityAlerts 
CREATE TABLE SecurityAlerts (
    AlertID INT PRIMARY KEY IDENTITY(1,1),
    AlertType NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    UserID INT NULL,
    AlertTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO



ALTER TABLE SystemLogs ADD AlertType NVARCHAR(50) NULL;
GO

INSERT INTO SystemLogs (UserID, ActionType, EntityType, EntityID, Description, ActionTime, AlertType)
SELECT UserID, 'SECURITY_ALERT', 'USER', UserID, Description, AlertTime, AlertType
FROM SecurityAlerts;
GO


DROP TABLE SecurityAlerts;
GO
DROP TABLE Configurations;
GO

INSERT INTO Users (
    Username, PasswordHash, Salt, OTPCode, OTPExpiry, 
    IsLocked, FailedLoginAttempts, RoleID, LastLoginTime, 
    CreatedAt, ExpiryDate, IsActive, LockedUntil
)
VALUES
-- User 1
('ton', '123456', 'salt1', '654321', '2025-05-16 23:59:59',
 0, 0, 2, '2025-05-15 08:00:00',
 '2025-01-01 10:00:00', '2026-01-01 10:00:00', 1, NULL);
select * from RolePermissions