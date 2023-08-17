use [master];
go

if db_id('VegetablesAndFruits') is not null
begin
	drop database VegetablesAndFruits;
end
go

create database VegetablesAndFruits;
go

use VegetablesAndFruits;
go

-- Vegetables And Fruits
CREATE TABLE VegetablesAndFruits
(
 ID int NOT NULL Primary Key Identity(1, 1), 
 Name nvarchar(100) NOT NULL check( Name != ' '),
 Type nvarchar(100) NOT NULL check( Type != ' '),
 Color nvarchar(100) NOT NULL check( Color != ' '),
 Calories int NOT NULL check (Calories > 0)
)
go

INSERT INTO VegetablesAndFruits
values('Яблоко', 'Фрукт', 'Красный', 20),
('Груша', 'Фрукт', 'Желтый', 19),
('Картофель', 'Овощи', 'Коричневый', 23),
('Помидоры', 'Овощи', 'Красный', 11),
('Капуста', 'Овощи', 'Зеленый', 9)
