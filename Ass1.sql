create database Ass1_Prn221_Bl5
go
use master
go
use Ass1_Prn221_Bl5
go
create table Member 
(
	MemberId int identity(1,1) primary key,
	Email varchar(100) not null,
	CompanyName varchar(40) not null,
	City varchar(15) not null,
	Country varchar(15) not null,
	[Password] varchar(30) not null,
);
create table Category
(
	CategoryId int identity(1,1) Primary key,
	CategoryName varchar(100) not null,
);
create table Product
(
	ProductId int identity(1,1) Primary key,
	CategoryId int foreign key references Category(CategoryId),
	ProductName varchar(40) not null,
	[Weight] varchar(20) not null,
	UnitPrice money not null,
	UnitInStock int not null,

);
create table [Order]
(
	OrderId int identity(1,1) primary key,
	MemberId int foreign key references Member(MemberId),
	OrderDate datetime not null,
	RequiredDate datetime,
	ShippedDate datetime,
	Freight money
);
Create table OrderDetail
(
	OrderId int foreign key references [Order](OrderId),
	ProductId int foreign key references Product(ProductId),
	UnitPrice money not null,
	Quantity int not null,
	Discount float not null,
	PRIMARY KEY (OrderId, ProductId),
);

-- Inserting into Member table
INSERT INTO Member (Email, CompanyName, City, Country, [Password])
VALUES 
('john@example.com', 'ABC Company', 'New York', 'USA', 'password1'),
('sarah@example.com', 'XYZ Corp', 'London', 'UK', 'password2'),
('mike@example.com', 'PQR Ltd', 'Sydney', 'Australia', 'password3'),
('emily@example.com', 'LMN Inc', 'Paris', 'France', 'password4'),
('david@example.com', 'GHI Enterprises', 'Tokyo', 'Japan', 'password5');

-- Inserting into Category table
INSERT INTO Category (CategoryName)
VALUES 
('Electronics'),
('Clothing'),
('Books'),
('Home Appliances'),
('Sports Equipment');

-- Inserting into Product table
INSERT INTO Product (CategoryId, ProductName, [Weight], UnitPrice, UnitInStock)
VALUES 
(1, 'Laptop', '2.5 kg', 1200.00, 50),
(2, 'T-shirt', '0.2 kg', 25.00, 200),
(3, 'Harry Potter Book', '0.8 kg', 15.00, 100),
(4, 'Microwave Oven', '15 kg', 300.00, 30),
(5, 'Soccer Ball', '0.4 kg', 20.00, 50);

-- Inserting into Order table
INSERT INTO [Order] (MemberId, OrderDate, RequiredDate, ShippedDate, Freight)
VALUES 
(1, '2024-04-01 10:00:00', '2024-04-05 10:00:00', '2024-04-04 09:00:00', 15.00),
(2, '2024-04-02 11:00:00', '2024-04-06 11:00:00', NULL, 10.00),
(3, '2024-04-03 12:00:00', '2024-04-07 12:00:00', '2024-04-06 10:00:00', 20.00),
(4, '2024-04-04 13:00:00', '2024-04-08 13:00:00', '2024-04-07 12:00:00', 25.00),
(5, '2024-04-05 14:00:00', '2024-04-09 14:00:00', NULL, 30.00);

-- Inserting into OrderDetail table
INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES 
(1, 1, 1200.00, 2, 0.05),
(1, 2, 25.00, 5, 0.1),
(2, 3, 15.00, 3, 0.0),
(3, 4, 300.00, 1, 0.15),
(4, 5, 20.00, 4, 0.05);