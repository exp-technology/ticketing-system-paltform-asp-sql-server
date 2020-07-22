GO
create database DBProject2

GO
use DBProject2

go



create table LoginTable
(
	LoginID int identity(1,1) primary key,
	Email varchar(30) not null unique,
    Password varchar(20) not null,
	Type int not null
)



create table Users
(
	UserID int primary key,
	Name varchar(30) not null,
	Phone char(11),
	Address varchar(40),
	BirthDate Date not null,
	Gender char(1) not null,
    Department varchar(30)

	foreign key(UserID) references LoginTable(LoginID)
)

create table Ticket(
    TicketID int identity(1,1) primary key,
    DateT Date not null,
    Name varchar(30) not null,
    Users varchar(30) not null,
    Descriptions varchar(1000),
    Asignee varchar(30),
    Category varchar(30) not null,
    StatusP varchar(15) not null
)
