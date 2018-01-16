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
-- Table 'users'
-- Users may get paper books for a period
-- ---

DROP TABLE IF EXISTS users;
    
CREATE TABLE users (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(100) NOT NULL,
  PRIMARY KEY (id)
) ENGINE = INNODB;

-- ---
-- Table 'users'
-- Users may get paper books for a period
-- ---

DROP TABLE IF EXISTS books;
    
CREATE TABLE books (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(100) NOT NULL,
  ownerId INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (ownerId) REFERENCES users(id)
) ENGINE = INNODB;

-- ---
-- Test Data
-- ---

INSERT INTO users (name) VALUES ('Екатерина Басюк');
INSERT INTO users (name) VALUES ('Алексей Киселёв');
INSERT INTO users (name) VALUES ('Виталий Киселёв');
INSERT INTO users (name) VALUES ('Татьяна Ковальчук');
INSERT INTO users (name) VALUES ('Алексей Пташник');

INSERT INTO books (name, ownerId) VALUES ('Экстремальное программирование. TDD', 3);
INSERT INTO books (name, ownerId) VALUES ('Совершенный код', 3);
INSERT INTO books (name, ownerId) VALUES ('Философия JAVA', 2);