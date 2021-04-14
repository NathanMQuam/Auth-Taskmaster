-- CREATE TABLE profiles (
--    id VARCHAR(255) NOT NULL PRIMARY KEY,
--    name VARCHAR(255),
--    email VARCHAR(255) NOT NULL UNIQUE,
--    picture VARCHAR(255)
-- );
DROP TABLE todos;

-- DROP TABLE boards;
-- CREATE TABLE boards (
--    id INT NOT NULL AUTO_INCREMENT,
--    creatorId VARCHAR(255) NOT NULL,
--    openToPublicView TINYINT NOT NULL,
--    name VARCHAR(255),
--    description VARCHAR(255),
--    PRIMARY KEY (id)
-- );
CREATE TABLE todos (
   id INT NOT NULL AUTO_INCREMENT,
   creatorId VARCHAR(255) NOT NULL,
   boardId INT NOT NULL,
   name VARCHAR(255),
   description VARCHAR(255),
   completed TINYINT,
   PRIMARY KEY(id),
   FOREIGN KEY (boardId) REFERENCES boards(id) ON DELETE CASCADE
);

-- INSERT INTO
--    boards (creatorId, openToPublicView, name, description)
-- VALUES
--    (
--       "nathan",
--       0,
--       "Nathan's test board",
--       "Nathan's test board's description"
--    );
-- SELECT
--    *
-- FROM
--    boards;
INSERT INTO
   todos (creatorId, boardId, name, description, completed)
VALUES
   ("nathan", 1, "Todo #1", "The first test Todo", 0);

SELECT
   *
FROM
   todos;