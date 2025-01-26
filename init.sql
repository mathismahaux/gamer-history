DROP DATABASE gamer_history_db;

CREATE DATABASE gamer_history_db;

USE gamer_history_db;

CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    pseudo NVARCHAR(MAX),
    email NVARCHAR(MAX),
    password NVARCHAR(MAX),
    role NVARCHAR(MAX)
);

CREATE TABLE supports (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX)
);

CREATE TABLE games (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX),
    minutes_for_completion INT,
    supportId INT,
    CONSTRAINT FK_games_supports FOREIGN KEY (supportId) REFERENCES supports(id)
);

CREATE TABLE sessions (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    start_date DATETIME,
    CONSTRAINT FK_sessions_users FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE game_sessions (
    id INT IDENTITY(1,1) PRIMARY KEY,
    gametime_min INT,
    user_id INT,
    game_id INT,
    session_datetime DATETIME,
    CONSTRAINT FK_game_sessions_users FOREIGN KEY (user_id) REFERENCES users(id),
    CONSTRAINT FK_game_sessions_games FOREIGN KEY (game_id) REFERENCES games(id)
);

INSERT INTO users(pseudo, email, password, role)
VALUES
    ('user1', 'user1@gmail.com', 'user1Password', 'Admin'),
    ('user1', 'user1@gmail.com', 'user1Password', 'User');

INSERT INTO supports(name)
VALUES
    ('PC'),
    ('Nintendo Switch');

INSERT INTO games(name, minutes_for_completion, supportId) 
VALUES 
    ('Deep Rock Galactic', 3600000, 1),
    ('Super Smash Bros', 3600, 2);