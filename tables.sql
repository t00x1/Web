Create database Pinterest
use Pinterest
DROP TABLE IF EXISTS Notifications;
DROP TABLE IF EXISTS Search_history;
DROP TABLE IF EXISTS Posts_tags;
DROP TABLE IF EXISTS Albums_tags;
DROP TABLE IF EXISTS Tags;
DROP TABLE IF EXISTS Album_Container;
DROP TABLE IF EXISTS Added_Albums;
DROP TABLE IF EXISTS Album;
DROP TABLE IF EXISTS Relationship;
DROP TABLE IF EXISTS Friend_Request;
DROP TABLE IF EXISTS Config;
DROP TABLE IF EXISTS Sessions;
DROP TABLE IF EXISTS Finger_printing;
DROP TABLE IF EXISTS Recomendations_ALS_RATING;
DROP TABLE IF EXISTS Reports;
DROP TABLE IF EXISTS Relation;
DROP TABLE IF EXISTS Comment;
DROP TABLE IF EXISTS Posts;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Images;
CREATE TABLE Images (
    Id_of_image BIGINT IDENTITY(1,1) PRIMARY KEY,
    Directory VARCHAR(255) NOT NULL
);

-- Создание таблицы Users
CREATE TABLE Users (
    ID_of_user BIGINT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(255) NOT NULL UNIQUE,
    Name VARCHAR(255) NOT NULL,
    Surname VARCHAR(255) NOT NULL,
    Patronymic VARCHAR(255) NULL,
    Password VARCHAR(255) NOT NULL,
    Bio VARCHAR(255) NULL,
    Admin BIT NOT NULL DEFAULT 0,
    Avatar BIGINT NULL,
    BirthDate DATETIME NOT NULL,
    Phone VARCHAR(20) NULL,
    Location VARCHAR(255) NULL,
    Male BIT NOT NULL,
    Updated_at DATETIME NOT NULL DEFAULT GETDATE(),
    Deleted_at DATETIME NULL,
    FOREIGN KEY (Avatar) REFERENCES Images(Id_of_image)
);

CREATE TABLE Posts (
    ID_of_post BIGINT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Content TEXT NOT NULL, -- Изменено на TEXT для совместимости
    Author_id BIGINT NOT NULL,
    Private BIT NOT NULL DEFAULT 1,
    Created_at DATETIME NOT NULL DEFAULT GETDATE(),
    Updated_at DATETIME NOT NULL DEFAULT GETDATE(),
    Deleted_at DATETIME NULL,
    FOREIGN KEY (Author_id) REFERENCES Users(ID_of_user)
);

CREATE TABLE Relation (
    ID_of_post BIGINT NOT NULL,
    ID_of_user BIGINT NOT NULL,
    Watched DATETIME NULL,
    User_score SMALLINT NOT NULL,
    Access BIT DEFAULT 1,
    PRIMARY KEY (ID_of_post, ID_of_user),
    FOREIGN KEY (ID_of_post) REFERENCES Posts(ID_of_post),
    FOREIGN KEY (ID_of_user) REFERENCES Users(ID_of_user)
);

CREATE TABLE Reports (
    ID_of_post BIGINT NOT NULL,
    ID_of_reporter BIGINT NOT NULL,
    Title VARCHAR(150) NOT NULL,
    Body TEXT NOT NULL, -- Изменено на TEXT для совместимости
    Status SMALLINT NOT NULL,
    Updated_At DATETIME NOT NULL,
    Created_AT DATETIME NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY (ID_of_post, ID_of_reporter),
    FOREIGN KEY (ID_of_post) REFERENCES Posts(ID_of_post),
    FOREIGN KEY (ID_of_reporter) REFERENCES Users(ID_of_user)
);

CREATE TABLE Recomendations_ALS_RATING (
    ID_of_post BIGINT NOT NULL,
    ID_of_user BIGINT NOT NULL,
    ExpectedScore SMALLINT NOT NULL,
    PRIMARY KEY (ID_of_post, ID_of_user),
    FOREIGN KEY (ID_of_post) REFERENCES Posts(ID_of_post),
    FOREIGN KEY (ID_of_user) REFERENCES Users(ID_of_user)
);

CREATE TABLE Finger_printing (
    ID BIGINT IDENTITY(1,1) PRIMARY KEY,
    UserAgent VARCHAR(50) NULL,
    ScreenWidth INT NULL,
    ScreenHeight INT NULL,
    Timezone INT NULL,
    JavaScriptEnabled BIT NULL,
    Plugins TEXT NULL,
    OS VARCHAR(255) NULL,
    DeviceType VARCHAR(255) NULL,
    Language VARCHAR(255) NULL,
    IPAddress VARCHAR(45) NULL,  
    CreatedAt DATETIME NULL DEFAULT GETDATE()
);

CREATE TABLE Sessions (
    ID_of_session BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ID_of_device BIGINT NOT NULL,
    Updated_at DATETIME NOT NULL DEFAULT GETDATE(),
    Token TEXT NOT NULL,
    FOREIGN KEY (ID_of_device) REFERENCES Finger_printing(ID)
);

CREATE TABLE Config (
    ID_of_user BIGINT NOT NULL PRIMARY KEY,
    Notifications BIT NOT NULL,
    Save_History BIT NOT NULL,
    Everyone_see_posts BIT NOT NULL,
    Dark_theme BIT NOT NULL,
    FOREIGN KEY (ID_of_user) REFERENCES Users(ID_of_user)
);

CREATE TABLE Friend_Request (
    Id_of_Friend_Request BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Id_of_sender BIGINT NOT NULL,
    Id_of_receiver BIGINT NOT NULL,
    Status SMALLINT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    Updated_at DATETIME NOT NULL DEFAULT GETDATE(), -- Исправлено
    FOREIGN KEY (Id_of_sender) REFERENCES Users(ID_of_user),
    FOREIGN KEY (Id_of_receiver) REFERENCES Users(ID_of_user)
);

CREATE TABLE Relationship (
    Id_of_sender BIGINT NOT NULL,
    Id_of_receiver BIGINT NOT NULL,
    Status SMALLINT NOT NULL,
    Created_at DATETIME NOT NULL DEFAULT GETDATE(),
    Updated_at DATETIME NOT NULL,
    PRIMARY KEY (Id_of_sender, Id_of_receiver),
    FOREIGN KEY (Id_of_sender) REFERENCES Users(ID_of_user),
    FOREIGN KEY (Id_of_receiver) REFERENCES Users(ID_of_user)
);

CREATE TABLE Album (
    Id_Of_Album BIGINT NOT NULL PRIMARY KEY,
    Author_id BIGINT NOT NULL,
    Name_of_Album VARCHAR(50) NOT NULL,
    Deleted_at DATETIME NULL,
    FOREIGN KEY (Author_id) REFERENCES Users(ID_of_user)
);

CREATE TABLE Added_Albums (
    Id_Of_Album BIGINT NOT NULL,
    Id_of_User BIGINT NOT NULL,
    PRIMARY KEY (Id_Of_Album, Id_of_User),
    FOREIGN KEY (Id_of_User) REFERENCES Users(ID_of_user),
    FOREIGN KEY (Id_Of_Album) REFERENCES Album(Id_Of_Album)
);

CREATE TABLE Album_Container (
    Id_Of_Album BIGINT NOT NULL,
    Id_of_image BIGINT NOT NULL,
    PRIMARY KEY (Id_Of_Album, Id_of_image),
    FOREIGN KEY (Id_Of_Album) REFERENCES Album(Id_Of_Album),
    FOREIGN KEY (Id_of_image) REFERENCES Images(Id_of_image)
);

CREATE TABLE Tags (
    Id_of_tag BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Content VARCHAR(50) NOT NULL -- Исправлено имя столбца
);

CREATE TABLE Albums_tags (
    Id_of_tag BIGINT NOT NULL,
    Id_Of_Album BIGINT NOT NULL,
    PRIMARY KEY (Id_of_tag, Id_Of_Album),
    FOREIGN KEY (Id_of_tag) REFERENCES Tags(Id_of_tag),
    FOREIGN KEY (Id_Of_Album) REFERENCES Album(Id_Of_Album)
);

CREATE TABLE Posts_tags (
    Id_of_tag BIGINT NOT NULL,
    ID_of_post BIGINT NOT NULL,
    PRIMARY KEY (Id_of_tag, ID_of_post),
    FOREIGN KEY (Id_of_tag) REFERENCES Tags(Id_of_tag),
    FOREIGN KEY (ID_of_post) REFERENCES Posts(ID_of_post)
);

CREATE TABLE Search_history (
    Id_of_query BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Created_at DATETIME NOT NULL DEFAULT GETDATE(),
    ID_of_user BIGINT NOT NULL,
    FOREIGN KEY (ID_of_user) REFERENCES Users(ID_of_user)
);

CREATE TABLE Comment (
    DateOfComment DATETIME NOT NULL DEFAULT GETDATE(),
    ID_of_user BIGINT NOT NULL,
    Id_Of_Album BIGINT NOT NULL,
    PRIMARY KEY (ID_of_user, Id_Of_Album, DateOfComment),
    FOREIGN KEY (ID_of_user) REFERENCES Users(ID_of_user),
    FOREIGN KEY (Id_Of_Album) REFERENCES Album(Id_Of_Album)
);

CREATE TABLE Notifications (
    ID_of_notification BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ID_of_user BIGINT NULL,
    ID_of_session BIGINT NULL,
    Id_of_Friend_Request BIGINT NULL,
    FOREIGN KEY (ID_of_user) REFERENCES Users(ID_of_user),
    FOREIGN KEY (ID_of_session) REFERENCES Sessions(ID_of_session),
    FOREIGN KEY (Id_of_Friend_Request) REFERENCES Friend_Request(Id_of_Friend_Request)
);