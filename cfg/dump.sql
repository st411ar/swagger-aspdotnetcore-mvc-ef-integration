-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

DROP DATABASE IF EXISTS paperlib;

CREATE DATABASE paperlib
    DEFAULT CHARACTER SET 'utf8' 
    DEFAULT COLLATE 'utf8_unicode_ci';

USE paperlib;

-- ---
-- Table 'roles'
-- Roles allow users to make different kind of operations
-- ---

DROP TABLE IF EXISTS roles;
    
CREATE TABLE roles (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(25) NOT NULL,
  PRIMARY KEY (id)
) ENGINE = INNODB;

-- ---
-- Table 'users'
-- Users may get paper books for a period
-- ---

DROP TABLE IF EXISTS users;
    
CREATE TABLE users (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(100) NOT NULL,
  password VARCHAR(64) NOT NULL,
  roleId INT NOT NULL DEFAULT 3,
  PRIMARY KEY (id),
  FOREIGN KEY (roleId) REFERENCES roles(id)
) ENGINE = INNODB;

-- ---
-- Table 'books'
-- Books may be owned and may be rented by the users
-- ---

DROP TABLE IF EXISTS books;
    
CREATE TABLE books (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(100) NOT NULL,
  ownerId INT NOT NULL,
  readerId INT,
  PRIMARY KEY (id),
  FOREIGN KEY (ownerId) REFERENCES users(id),
  FOREIGN KEY (readerId) REFERENCES users(id)
) ENGINE = INNODB;

-- ---
-- Test Data
-- ---

INSERT INTO roles (name) VALUES ('administrator');
INSERT INTO roles (name) VALUES ('moderator');
INSERT INTO roles (name) VALUES ('reader');
INSERT INTO roles (name) VALUES ('guest');

INSERT INTO users (name, password, roleId) VALUES ('Екатерина Басюк', 'userpass1', 2);
INSERT INTO users (name, password) VALUES ('Алексей Киселёв', 'userpass2');
INSERT INTO users (name, password, roleId) VALUES ('Виталий Киселёв', 'userpass3', 1);
INSERT INTO users (name, password) VALUES ('Татьяна Ковальчук', 'userpass4');
INSERT INTO users (name, password) VALUES ('Алексей Пташник', 'userpass5');
INSERT INTO users (name, password) VALUES ('Артём Терехович', 'userpass6');

INSERT INTO books (name, ownerId, readerId) VALUES ('Экстремальное программирование. TDD', 3, 1);
INSERT INTO books (name, ownerId, readerId) VALUES ('Совершенный код', 3, 4);
INSERT INTO books (name, ownerId) VALUES ('Структуры данных и алгоритмы java', 3);
INSERT INTO books (name, ownerId) VALUES ('Приёмы объектно-ориентированного проектирования', 3);
INSERT INTO books (name, ownerId, readerId) VALUES ('Философия JAVA', 2, 5);
INSERT INTO books (name, ownerId, readerId) VALUES ('Трудно быть Богом', 6, 3);
INSERT INTO books (name, ownerId, readerId) VALUES ('Основы data science', 6, 3);