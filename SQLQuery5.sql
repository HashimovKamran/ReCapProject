DROP TABLE Cars;
DROP TABLE Brands;
DROP TABLE Colors;
CREATE TABLE Cars
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Description varchar(100)
);

CREATE TABLE Brands
(
	BrandId int IDENTITY(1,1) PRIMARY KEY,
	BrandName varchar(20),
);

CREATE TABLE Colors
(
	ColorId int IDENTITY(1,1) PRIMARY KEY,
	ColorName varchar(20),
);

INSERT INTO Cars(BrandId, ColorId, ModelYear, DailyPrice, Description)
VALUES
	('1', '1', '2020', '900', 'S'),
	('2', '3', '2019', '700', 'A8'),
	('3', '5', '2017', '500', 'E-Class'),
	('4', '7', '2015', '350', '535i Sedan')

INSERT INTO Brands(BrandName)
VALUES
	('Tesla'),
	('Audi'),
	('Mercedes'),
	('BMW')

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Gri'),
	('Mavi')