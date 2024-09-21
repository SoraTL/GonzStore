Create database Gonz
go

USE GonZ
GO

CREATE TABLE Roles
(
	Id INT PRIMARY KEY,
	Name VARCHAR(50),
	CreateAt DateTime,
	UpdatedAt DateTime,
	Status Char(4)
);


CREATE TABLE Accounts
(
	Id INT PRIMARY KEY,
	Username Varchar(20),
	Password Varchar(20),
	Email Varchar(30),
	PhoneNumber Varchar(10),
	RoleId INT,
	Status Char(4),
	Foreign key (RoleId) References Roles(Id)
);

Create Table Customers
(
	Id Int Primary Key,
	FullName Varchar(20),
	Birthday Date,
	Avatar Varchar,
	Gender Char(4),
	AccountId Int,
	CreatedAt DateTime,
	UpdatedAt DateTime,
	CreatedBy Int,
	UpdatedBy Int,
	Status Char(4)
);

Create Table Employees
(
	Id Int Primary Key,
	Fullname Varchar(30),
	Birthdate Date,
	Avatar Varchar,
	Gender Char(4),
	CreatedAt DateTime,
	CreatedBy Int,
	UpdatedAt DateTime,
	UpdatedBy Int,
	Status VarChar(4),
)

Create Table Carts
(
	Id Int Primary Key,
	UserId Int,
	CreatedAt DateTime,
	UpdatedAt DateTime,
	Status Char(4),
	Foreign Key (UserId) References Customers(Id)
)

Create Table Favorites
(
	Id Int Primary Key,
	UserId Int,
	ProductDetailId Int,
	CreatedAt DateTime,
	Status Char(4),
	Foreign Key (UserId) References Customers(Id),

)

Create Table Rating
(
	Id Int Primary Key,
	UserId Int,
	BillDetailId Int,
	Content Varchar,
	StarRating Int,
	Rated Int,
	CreatedAt DateTime,
	UpdatedAt DateTime,
	Foreign Key (UserId) References Customers(Id),
	Foreign Key (BillDetailId) References 
)
