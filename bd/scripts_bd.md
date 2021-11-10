-- Database: db_banco
-- DROP DATABASE db_banco;
Script criação do banco

CREATE DATABASE db_banco
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
	--------
	
-- Table: public.tbusuario

-- DROP TABLE public.tbusuario;
Script criação das tarefas
CREATE TABLE IF NOT EXISTS public.tbusuario
(
    id serial,
    nome text,
    agencia text,
    conta text,
    saldo double precision,
    cpf TEXT,
    senha TEXT,
    banco TEXT,
    PRIMARY KEY (id),
    UNIQUE (agencia, conta, senha),
    UNIQUE (agencia, conta, senha, cpf),
    UNIQUE (agencia, conta, senha, cpf, banco),
    UNIQUE (agencia, conta, cpf)
);

ALTER TABLE public.tbusuario
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.tbtransacoes (
	id serial,
	usuario_id int,
	tipo text,
	destinatario_id int,
	valor double precision,
	PRIMARY KEY (id),
    FOREIGN KEY (usuario_id)
    REFERENCES tbusuario (id),
    FOREIGN KEY (destinatario_id)
    REFERENCES tbusuario (id)

); 

ALTER TABLE public.tbtransacoes
    OWNER to postgres;


CREATE TABLE IF NOT EXISTS public.tbcartoes (
	id serial,
	usuario_id int,
	tipo text,
	senha text,
    numero text,
    nome text,
    validade text,
    cvv text,
	limite double precision,
	PRIMARY KEY (id),
    FOREIGN KEY (usuario_id)
    REFERENCES tbusuario (id),
    UNIQUE (senha, numero, cvv)
); 

ALTER TABLE public.tbcartoes
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.tblogin (
	id serial,
	usuario_id int,
	data timestamp,
	PRIMARY KEY (id),
    FOREIGN KEY (usuario_id)
    REFERENCES tbusuario (id)
); 

ALTER TABLE public.tblogin
    OWNER to postgres;




Script inserção de dados

INSERT INTO TBUSUARIO
(ID, NOME, AGENCIA, CONTA, SALDO, BANCO, SENHA, CPF)
VALUES
('1','SAMIR','0661','0123-1','1000', 'bancogenerico1', '123', '000.000.000-01'),
('2','RAFAEL','0662','0123-2','1500', 'bancogenerico1', '1234', '000.000.000-02'),
('3','FELIPE','0663','0123-3','2000.52', 'bancogenerico2', '1235', '000.000.000-03');


