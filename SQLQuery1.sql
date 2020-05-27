CREATE TABLE Empleado(
	IdEmpleado int primary key IDENTITY(1,1),
	Nombre nvarchar(100),
	Direccion nvarchar(100))

CREATE TABLE Tema(
	IdTema int primary key IDENTITY(1,1),
	Nombre nvarchar(100))

CREATE TABLE Video(
	IdVideo int  primary key IDENTITY(1,1),
	Nombre nvarchar(200),
	Url nvarchar(100),
	FechaPublicacion datetime)

CREATE TABLE Curso(
	IdCurso int primary key IDENTITY(1,1),
	Descripcion nvarchar(200),
	IdEmpleado int,
	constraint fk_idEmp FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado)
)

CREATE TABLE Curso_Tema(
	IdCT int  primary key IDENTITY(1,1),
	IdCurso int,
	IdTema int,
	constraint fk_idCurso FOREIGN KEY(IdCurso) REFERENCES Curso(IdCurso),
	constraint fk_idTema FOREIGN KEY(IdTema) REFERENCES Tema(IdTema),
)

CREATE TABLE Curso_Tema_Video(
	IdCTV int primary key IDENTITY(1,1),
	IdCT int,
	IdVideo int,
	constraint fk_idCT FOREIGN KEY(IdCT) REFERENCES Curso_Tema(IdCT),
	constraint fk_idVideo FOREIGN KEY(IdVideo) REFERENCES Video(IdVideo),
)


----Store Procedure: insertar
go
CREATE PROCEDURE SP_TEMA_INSERTAR
	@Nombre nvarchar(100)
	AS
	BEGIN
	INSERT INTO Tema(Nombre)
	VALUES(@Nombre)
END;
GO
---Stored procedure: Actualizar
GO
CREATE PROCEDURE sp_Tema_Actualizar
	@IdTema int,
	@Nombre nvarchar(200)
AS
BEGIN
	UPDATE Tema SET Nombre=@Nombre
	WHERE IdTema = @IdTema
END;
go
-- Stored procedure: Eliminar
GO
CREATE PROCEDURE sp_Tema_Eliminar
	@IdTema int
AS
BEGIN
	DELETE FROM Tema
	WHERE IdTema = @IdTema
END;
go
--Stored Procedure: Ver todos
GO
CREATE PROCEDURE sp_Tema_ConsultarTodo
AS
BEGIN
	SELECT * FROM Tema
END;
go
--Stored Procedure: Ver uno
Go
CREATE PROCEDURE sp_Tema_ConsultarPorID
@IdTema int
AS
BEGIN
	SELECT * FROM Tema
	WHERE IdTema = @IdTema
END;
go