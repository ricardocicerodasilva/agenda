create database agenda;
use agenda;

create table tbcontato(
codcontato int (4) not null primary key auto_increment,
nome varchar (100),
telefone char (14),
celular char(15),
email varchar(100)
);
insert into tbcontato(nome,telefone,celular,email) values ('Samara Ferreira','(11)5555-4444','(11)97777-8888','samara.ferreira27@gmsail.com');

select*from tbcontato;
