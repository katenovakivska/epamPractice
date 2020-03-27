
use Company;

GO
drop table Projects;
create table Projects(
ProjectID int primary key identity(1, 1),
ProjectName varchar(max) not null,
StartDate date not null,
FinishDate date,
Status varchar(max) check (Status = 'opened' or Status = 'closed')
);

GO
drop table Employees;
create table Employees(
EmployeeID int primary key identity(1, 1),
EmployeeName varchar(max) not null,
EmployeeSurname varchar(max) not null,
EmployeePatronimic varchar(max) not null,
BirthDate date not null
);

GO
drop table Positions;
create table Positions(
PositionID int primary key identity(1, 1),
PositionName varchar(max) not null
);

GO 
drop table ProjectPositions;
create table ProjectPositions(
ProjectPositionID int primary key identity(1, 1),
EmployeeID int not null,
ProjectID int not null,
PositionID int not null,
foreign key (ProjectID) references Projects(ProjectID) on delete cascade on update cascade,
foreign key (EmployeeID) references Employees(EmployeeID) on delete cascade on update cascade,
foreign key (PositionID) references Positions(PositionID) on delete cascade on update cascade
);

GO
drop table Tasks;
create table Tasks(
TaskID int primary key identity(1, 1),
Task varchar(max) not null,
TaskDate date not null,
Term date not null,
EmployeeID int not null,
foreign key (EmployeeID) references Employees(EmployeeID) on delete cascade on update cascade,
);
alter table Tasks add ProjectID int, 
foreign key(ProjectID) references Projects(ProjectID) on delete no action on update no action;

GO
drop table Statuses;
create table Statuses(
Status int primary key identity(1, 1),
TaskID int not null,
StatusDate date not null,
EmployeeID int not null,
StatusName varchar(max) check (StatusName = 'closed' or StatusName = 'done' or StatusName = 'need refinement' or StatusName = 'opened') not null,
foreign key (TaskID) references Tasks(TaskID) on delete no action on update no action,
foreign key (EmployeeID) references Employees(EmployeeID) on delete no action on update no action,
);


insert into Projects values('System for University', '2018-01-19', '2019-05-11', 'closed');
insert into Projects values('Medical System', '2019-09-23', null, 'opened');
insert into Projects values('Supermarket managment System', '2019-07-05', null, 'opened');
insert into Projects values('Fora club System', '2019-11-15', null, 'opened');
insert into Projects values('Silpo buyers System', '2019-12-09', null, 'opened');
insert into Projects values('Alpha bank System', '2019-07-27', null, 'opened');
insert into Projects values('Privat24 System', '2016-09-15', '2017-02-11', 'closed');
insert into Projects values('KredoBank System', '2017-01-10', '2018-11-11', 'closed');
insert into Projects values('Monobank System', '2018-12-19', '2019-01-03', 'closed');
insert into Projects values('Monobank System', '2018-12-19', '2019-01-03', 'closed');

insert into Employees values('Oleksandr', 'Kravchenko', 'Igorovich', '1995-01-10');
insert into Employees values('Ludmyla', 'Moiseenko', 'Oleksandrivna', '1990-06-18');
insert into Employees values('Muhailo', 'Ivanchuk', 'Borisovich', '1988-09-11');
insert into Employees values('Oleksandra', 'Shults', 'Vasilivna', '1991-12-03');
insert into Employees values('Oleg', 'Smolenko', 'Dmytrovich', '1993-07-09');
insert into Employees values('Yuriy', 'Dmytrenko', 'Olegovich', '1986-02-15');
insert into Employees values('Taras', 'Homenko', 'Andrievich', '1993-12-10');
insert into Employees values('Taras', 'Homenko', 'Andrievich', '1993-12-10');

insert into Positions values('Software application developer');
insert into Positions values('Web developer');
insert into Positions values('Computer systems engineer');
insert into Positions values('Database administrator');
insert into Positions values('Software quality assurance (QA) engineer');
insert into Positions values('Business intelligence analyst');
insert into Positions values('Computer programmer');
insert into Positions values('Network system administrator');
insert into Positions values('Computer systems analyst');
insert into Positions values('UI Designer');
insert into Positions values('Project Manager');

insert into ProjectPositions values(1, 7, 1);
insert into ProjectPositions values(1, 4, 2);
insert into ProjectPositions values(1, 5, 3);
insert into ProjectPositions values(2, 5, 4);
insert into ProjectPositions values(2, 1, 5);
insert into ProjectPositions values(2, 2, 6);
insert into ProjectPositions values(3, 8, 7);
insert into ProjectPositions values(3, 3, 8);
insert into ProjectPositions values(4, 4, 2);
insert into ProjectPositions values(4, 6, 4);
insert into ProjectPositions values(4, 8, 2);
insert into ProjectPositions values(5, 2, 6);
insert into ProjectPositions values(5, 8, 2);
insert into ProjectPositions values(6, 4, 2);
insert into ProjectPositions values(6, 5, 3);
insert into ProjectPositions values(7, 9, 9);
insert into ProjectPositions values(7, 3, 5);
insert into ProjectPositions values(7, 6, 8);
insert into ProjectPositions values(8, 10, 3); 


insert into Tasks values('make project', '2016-09-15', '2016-09-18', 1, 7);
insert into Tasks values('make web', '2019-11-15', '2019-11-19', 1, 4);
insert into Tasks values('download visual studio', '2019-12-09', '2019-12-25',1,5);
insert into Tasks values('create database', '2020-01-10', '2020-01-15', 2,5);
insert into Tasks values('make backend', '2018-01-19', '2018-01-27', 2,1);
insert into Tasks values('make analys', '2019-09-23', '2019-09-30', 2,2);
insert into Tasks values('make frontend', '2018-12-19', '2018-12-28', 3,8);
insert into Tasks values('set network', '2019-07-05', '2019-07-28', 3,3);
insert into Tasks values('make web', '2019-11-15', '2020-03-19', 4,4);
insert into Tasks values('create database', '2019-07-27', '2019-08-27',4,6);
insert into Tasks values('make web', '2018-12-19', '2019-01-03', 4, 8);
insert into Tasks values('make analys', '2020-02-02', '2020-03-30',5,2);
insert into Tasks values('make frontend', '2018-12-19', '2018-12-28',5,8);
insert into Tasks values('make web', '2019-11-15', '2020-02-15',  6,4);
insert into Tasks values('check work', '2020-02-09', '2020-03-30',  6,5);
insert into Tasks values('make analys', '2018-12-19', '2019-02-19',  7, 9);
insert into Tasks values('make tests', '2020-01-05', '2019-02-19',  7, 3);
insert into Tasks values('set network', '2019-08-05', '2019-09-28',  7, 6);
insert into Tasks values('download visual studio', '2019-12-09', '2019-12-25',1,5);
insert into Tasks values('check work', '2020-02-09', '2020-03-30',  6,5);
insert into Tasks values('check work', '2020-02-09', '2020-03-30',  8, 10);


insert into Statuses values (1, '2016-09-18',2, 'closed');
insert into Statuses values (2, '2019-11-19',2, 'done');
insert into Statuses values (3, '2019-12-27',2, 'done');
insert into Statuses values (4, '2020-01-15',5, 'need refinement');
insert into Statuses values (5, '2018-01-27', 2,'closed');
insert into Statuses values (6, '2019-09-30',2, 'done');
insert into Statuses values (7, '2016-09-18',5, 'closed');
insert into Statuses values (8, '2019-11-25', 5,'done');
insert into Statuses values (9, '2019-12-27',5, 'done');
insert into Statuses values (10, '2020-01-17',5, 'need refinement');
insert into Statuses values (11, '2018-01-27',2, 'closed');
insert into Statuses values (12, '2019-09-30',5, 'done');
insert into Statuses values (13, '2018-01-27', 2,'opened');
insert into Statuses values (14, '2019-09-30',2, 'opened');
insert into Statuses values (17, '2019-09-30',2, 'closed');
insert into Statuses values (16, '2019-09-30',2, 'closed');
insert into Statuses values (18, '2019-09-30',2, 'closed');
insert into Statuses values (21, '2019-09-30',2, 'closed');



