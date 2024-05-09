-- Create database
CREATE DATABASE IF NOT EXISTS rznappsmicro;

-- Select the database
USE rznappsmicro;

-- Create the table User
CREATE TABLE IF NOT EXISTS User (
    Id              CHAR(36) PRIMARY KEY,
    FullName        VARCHAR(100) NOT NULL,
    DateBirth       DATE NOT NULL,
    Active          BOOLEAN NOT NULL,
    Gender          TINYINT CHECK (Gender IN (0, 1, 2)),
    AvatarUrl       VARCHAR(255),
    AvatarKeyName   VARCHAR(100)
);

-- Create the table Address
CREATE TABLE IF NOT EXISTS Address (
    Id                      CHAR(36) PRIMARY KEY,
    IdUser                  CHAR(36) NOT NULL,
    ZipCode                 VARCHAR(10) NOT NULL,
    Street                  VARCHAR(255) NOT NULL,
    Number                  INT NOT NULL,
    AdditionalInformation   VARCHAR(255),
    TypeOfAddress           TINYINT CHECK (TypeOfAddress IN (0, 1, 2)),
    FOREIGN KEY (IdUser) REFERENCES User(Id)
);