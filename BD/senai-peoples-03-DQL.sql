USE M_Peoples;

SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Funcionarios;

SELECT CONCAT (Nome ,' ', Sobrenome) AS NomeCompleto FROM Funcionarios;

SELECT * FROM Funcionarios ORDER BY Nome DESC;