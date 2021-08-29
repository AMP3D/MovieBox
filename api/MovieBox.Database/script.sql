CREATE TABLE IF NOT EXISTS Movie(Id INTEGER PRIMARY KEY, ImageUrl TEXT, IsAvailable INTEGER, PurchasePrice REAL, Rating TEXT, RentalPrice REAL, Summary TEXT, Title TEXT, YearReleased INTEGER);
CREATE TABLE IF NOT EXISTS User(Id INTEGER PRIMARY KEY, UserName TEXT, Password TEXT);

INSERT OR REPLACE INTO Movie VALUES (1, 'https://en.wikipedia.org/wiki/The_Peanut_Butter_Falcon#/media/File:The_Peanut_Butter_Falcon_poster.jpeg', 1, 23.99, 'PG-13', 3.99, 'Good movie', 'Peanut Butter Falcon', '2019');
INSERT OR REPLACE INTO User VALUES (1, 'admin', 'admin');