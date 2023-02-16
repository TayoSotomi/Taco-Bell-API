--CREATE DATABASE TacoBellDB;
--USE TacoBellDb;

--CREATE TABLE Taco(
--	ID int Identity(1,1) NOT NULL Primary Key,
--	Name NVARCHAR(255),
--	Cost REAL,
--	SoftShell BIT,
--	Dorito BIT
--);

--CREATE TABLE Burrito(
--	ID int Identity(1,1) NOT NULL Primary Key,
--	Name NVARCHAR(255),
--	Cost REAL,
--	Bean BIT
--);

--CREATE TABLE Drink(
--	ID int Identity(1,1) NOT NULL Primary Key,
--	Name NVARCHAR(255),
--	Cost REAL,
--	Slushie BIT
--);

--INSERT INTO Taco(Name, Cost, SoftShell, Dorito)
--VALUES ('Crispy Melt Taco', 2.49, 0, 0),
--('Soft Taco', 1.69, 1, 0),
--('Spicy Potato Taco', 1.00, 1,0),
--('Nacho Cheese Doritos Locos Tacos',2.39,0,1),
--('Spicy Chicken Taco', 3.49, 1,0);

--INSERT INTO Burrito(Name, Cost, Bean)
--VALUES ('Bean Burrito', 1.69,1),
--('Beefy 5 Layer', 3.39,0),
--('Fiesta Veggie Burrito',2.00,1);

--INSERT INTO Drink(Name, Cost, Slushie)
--VALUES ('Baja Blast', 1.00, 0),
--('Mtn Dew', 1.00, 0),
--('Baja Blast Freeze', 1.00, 1),
--('Blue Raspberry Electric Strawberry Freeze', 1.00,1),
--('Water', 0, 0);

--SELECT * FROM Taco;
--SELECT * FROM Burrito;
--SELECT * FROM Drink;
