create DATABASE escola
create table Alunos(
id int primary key identity(1,1),
Nome varchar(50) not null,
Curso varchar(50) not null,
Email varchar(50)not null,
Idade int not null,
Ativo bit not null,
)

insert into Alunos values('Edjalma', 'TDS', 'edjalma@senai',65, 1);
insert into Alunos values('Vinícius', 'Mecatrônica', 'vinicius@senai',40, 1);
insert into Alunos values('André', 'Eletrica', 'andre@senai',40, 1);

select * from Alunos

UPDATE Alunos SET Ativo=1 WHERE id=2

create table Materias(
id int primary key identity(1,1),
Nome varchar(50) not null,
Professor varchar(50) not null,
Descricao varchar(50)not null,
CargaHoraria int not null,
Ativo bit not null,
)

insert into Materias values('Desenvolvimento de Sistema', 'Algeu', 'Nam lobortis lectus ac ex eleifend malesuada.',100, 1);
insert into Materias values('IOT', 'Edjalma', 'Nam lobortis lectus ac ex eleifend malesuada.',70, 1);
insert into Materias values('Banco de Dados', 'Vinicius', 'Nam lobortis lectus ac ex eleifend malesuada.',80, 1);

UPDATE Materias SET Ativo=1 WHERE id=1

create table Livros(
id int primary key identity(1,1),
Nome varchar(50) not null,
Preco decimal(10,2) not null,
QtdPag int not null,
Ativo bit not null,
)

insert into Livros values('Algoritmos e Estruturas de Dados', 109.90 , 298, 1);
insert into Livros values('Use a Cabeça! C#',89.92 ,283, 1);
insert into Livros values('C# Para Iniciantes', 112.00, 305, 1);

create table Ligacao(
id int primary key identity(1,1),
NomeAluno varchar(50) not null,
Telefone varchar(15) not null,
Assunto varchar(500) not null,
Ativo bit not null,
)

insert into Ligacao values('Edjalma', '1234-5678', 'Financeiro', 1);
insert into Ligacao values('Vinícius','9999-9876','Matricula', 1);
insert into Ligacao values('André', '9876-5432', 'Outro',1);

select * from Ligacao