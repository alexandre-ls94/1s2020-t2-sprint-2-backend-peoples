USE M_Peoples;

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),
		('Comum')

INSERT INTO Usuario (Nome, Email, Senha, IdTipo)
VALUES ('Catarina','adm@adm.com','123', 1),
		('Tadeu','tadeu@email.com','123', 2)

INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento)
VALUES	('Catarina','Strada','20-01-2000'),
		('Tadeu','Vitelli','19-02-2000')