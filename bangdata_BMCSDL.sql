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

-- Tạo bảng Users (Thêm các cột cho OTP)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Salt NVARCHAR(255) NOT NULL,
    RoleID INT NOT NULL,
    OTPSecret VARBINARY(MAX) NULL, -- Khóa bí mật cho TOTP (mã hóa)
    OTPCode VARBINARY(MAX) NULL, -- Mã OTP hiện tại (nếu gửi qua email/SMS)
    OTPExpiry DATETIME NULL, -- Thời gian hết hạn OTP
    ContactMethod NVARCHAR(20) NULL, -- Phương thức gửi OTP (Email/Phone)
    ContactInfo VARBINARY(MAX) NULL, -- Email hoặc số điện thoại
    LastLoginTime DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
GO


-- Tạo bảng OTPLogs (Lưu lịch sử OTP)
CREATE TABLE OTPLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    OTPCode NVARCHAR(10) NOT NULL, -- Mã OTP đã gửi
    SentAt DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL, -- Sent, Verified, Expired, Failed
    IPAddress NVARCHAR(50) NULL, -- IP của thiết bị yêu cầu OTP
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- Tạo bảng ResidentData
CREATE TABLE ResidentData (
    ResidentID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    EncryptedCMND VARCHAR(256) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Nationality NVARCHAR(50) NOT NULL DEFAULT N'Việt Nam',
    PhoneNumber VARCHAR(20),
    Email NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Tạo bảng PassportRegistration
CREATE TABLE PassportRegistration (
    RegistrationID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    EncryptedCMND VARCHAR(256) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(20),
    Email NVARCHAR(100),
    SubmissionDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL DEFAULT N'Chờ xác thực'
);
GO

-- Tạo bảng PassportApplications
CREATE TABLE PassportApplications (
    ApplicationID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    RegistrationID UNIQUEIDENTIFIER NOT NULL,
    ResidentID UNIQUEIDENTIFIER NOT NULL,
    SubmissionDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL DEFAULT N'Chờ xét duyệt',
    ReviewedBy INT NULL,
    ReviewDate DATETIME NULL,
    ReviewNotes NVARCHAR(255) NULL,
    FOREIGN KEY (RegistrationID) REFERENCES PassportRegistration(RegistrationID),
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID),
    FOREIGN KEY (ReviewedBy) REFERENCES Users(UserID)
);
GO

-- Tạo bảng PassportRecords
CREATE TABLE PassportRecords (
    PassportID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ApplicationID UNIQUEIDENTIFIER NOT NULL UNIQUE,
    PassportNumber VARCHAR(20) UNIQUE NOT NULL,
    IssueDate DATE NOT NULL,
    ExpiryDate DATE NOT NULL,
    IssuedAt DATETIME DEFAULT GETDATE(),
    ApprovalStatus NVARCHAR(20) NOT NULL,
    FOREIGN KEY (ApplicationID) REFERENCES PassportApplications(ApplicationID)
);
GO

-- Tạo bảng SystemLogs
CREATE TABLE SystemLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ActionType NVARCHAR(50) NOT NULL,
    EntityType NVARCHAR(50) NOT NULL,
    EntityID NVARCHAR(36) NULL,
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
    RegistrationID UNIQUEIDENTIFIER NOT NULL,
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (RegistrationID) REFERENCES PassportRegistration(RegistrationID)
);
GO

-- Tạo bảng AuditTrails
CREATE TABLE AuditTrails (
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    TableName NVARCHAR(50) NOT NULL,
    RecordID NVARCHAR(36) NOT NULL,
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
    ResidentID UNIQUEIDENTIFIER NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    SentAt DATETIME DEFAULT GETDATE(),
    SentStatus NVARCHAR(50) NOT NULL DEFAULT N'Pending',
    FOREIGN KEY (ResidentID) REFERENCES ResidentData(ResidentID)
);
GO




