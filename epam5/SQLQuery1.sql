create database ProductCatalog;
use ProductCatalog;
create table Categories
(
 CategoryID int primary key  identity(1,1),
 CategoryName nvarchar(max),
 CategoryCharacteristic nvarchar(max)
);

create table Suppliers
(
SupplierID int primary key  identity(1,1),
CompanyName nvarchar(max)
);
drop table Products;
create table Products
(
ProductID int primary key  identity(1,1),
ProductName nvarchar(max),
CategoryID int,
SupplierID int,
Price int,
foreign key (CategoryID) references Categories(CategoryID),
foreign key (SupplierID) references Suppliers(SupplierID) 
);

insert into Categories values('desert food', 'Desert is a course that concludes a meal');
insert into  Categories values('vegetables','Vegetables are parts of plants that are consumed by humans or other animals as food');
insert into  Categories values('fruits','fruit is the seed-bearing structure in flowering plants');
insert into  Categories values('water','For drinking');

select * from Categories;

insert into Suppliers values('Dolce');
insert into Suppliers values('Bonakva');
insert into Suppliers values('Sandora');
insert into Suppliers values('WestFood');
insert into Suppliers values('Roshen');
insert into Suppliers values('SpanishProduct');

select * from Suppliers;

insert into Products values ('Banana', 3, 1, 38.00);
insert into Products values ('Avocado', 2, 4 , 18.50);
insert into Products values ('Apple Juice', 4, 3, 31.60);
insert into Products values ('Mango Juice', 4, 3, 40.00);
insert into Products values ('Apple', 3, 1,14.00);
insert into Products values ('Pine Apple', 3, 1,56.40);
insert into Products values ('Egg Sweets', 1, 5,218.00);
insert into Products values ('Mineral Water', 4, 2,11.20);
insert into Products values ('Avocado', 2, 6,23.45 );
insert into Products values ('Tomato', 2, 6,45.40 );
insert into Products values ('Onion', 2, 6 ,10.00);
insert into Products values ('MAngo', 3, 6 ,19.65);

select * from Products;
select * from Products p join Categories c on c.CategoryID = p.CategoryID join Suppliers s on s.SupplierID = p.SupplierID
