CREATE DATABASE SENAI_HROADS_MANHA;
USE SENAI_HROADS_MANHA;

CREATE TABLE Classe(
	IdClasse	INT	PRIMARY KEY	IDENTITY,
	Nome		VARCHAR(200) NOT NULL,
);

CREATE TABLE Personagem(
	IdPersonagem			INT PRIMARY KEY IDENTITY,
	IdClasse				INT FOREIGN KEY REFERENCES Classe(IdClasse),
	Nome					VARCHAR(200) NOT NULL,
	CapacicadeMaximaVida	VARCHAR(200) NOT NULL,
	CapacicadeMaximaMana	VARCHAR(200) NOT NULL,
	DataAtualizacao			DATE NOT NULL,
	DataCriacao				VARCHAR(200) NOT NULL,
);

CREATE TABLE TipoHabilidade(
	IdTipoHabilidade	INT	PRIMARY KEY	IDENTITY,
	Nome				VARCHAR(200) NOT NULL,
);

CREATE TABLE Habilidade(
	IdHabilidade		INT	PRIMARY KEY	IDENTITY,
	IdTipoHabilidade	INT FOREIGN KEY REFERENCES TipoHabilidade(IdTipoHabilidade),
	Nome				VARCHAR(200) NOT NULL,
);

CREATE TABLE ClasseHabilidade(
	IdClasseHabilidade  INT	PRIMARY KEY	IDENTITY,
	IdClasse		    INT FOREIGN KEY REFERENCES Classe(IdClasse),
	IdHabilidade		INT FOREIGN KEY REFERENCES Habilidade(IdHabilidade),
);