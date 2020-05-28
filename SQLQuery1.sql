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

CREATE PROCEDURE sp_Empleado_ConsultarTodo
AS
BEGIN
	SELECT * FROM Empleado
END;
go

CREATE PROCEDURE sp_Empleado_Insertar
	@IdEmpleado int,
	@Nombre nvarchar(100),
	@Direccion nvarchar(100)
AS
BEGIN
	INSERT INTO Empleado (IdEmpleado,Nombre,Direccion)
	VALUES (@IdEmpleado,@Nombre,@Direccion)
END;
print('--Script Finalizado--')
go

CREATE PROCEDURE sp_Empleado_ConsultarPorID
@IdEmpleado int
AS
BEGIN
	SELECT * FROM Empleado
	WHERE IdEmpleado = @IdEmpleado
END;
go
GO
CREATE PROCEDURE sp_Empleado_Eliminar
	@IdEmpleado int
AS
BEGIN
	DELETE FROM Empleado
	WHERE IdEmpleado = @IdEmpleado
END;
go
GO
CREATE PROCEDURE sp_Empleado_Actualizar
	@IdEmpleado int,
	@Nombre nvarchar(100),
	@Direccion nvarchar(100)
AS
BEGIN
	UPDATE Empleado SET Nombre=@Nombre, Direccion=@Direccion
	WHERE IdEmpleado = @IdEmpleado
END;
print('--Script Finalizado--')
go



CREATE PROCEDURE sp_Curso_ConsultarTodo
AS
BEGIN
	SELECT * FROM Curso
END;
go

CREATE PROCEDURE sp_Curso_ConsultarPorID
@IdCurso int
AS
BEGIN
	SELECT * FROM Curso
	WHERE IdCurso = @IdCurso
END;
go
GO

CREATE PROCEDURE sp_Curso_Insertar
	@IdCurso int,
	@Descripcion nvarchar(200),
	@IdEmpleado nvarchar(100)
AS
BEGIN
	INSERT INTO Curso (IdCurso,Descripcion,IdEmpleado)
	VALUES (@IdCurso,@Descripcion,@IdEmpleado)
END;
print('--Script Finalizado--')
go
CREATE PROCEDURE sp_Curso_Eliminar
	@IdCurso int
AS
BEGIN
	DELETE FROM Curso
	WHERE IdCurso = @IdCurso
END;
go
GO
CREATE PROCEDURE sp_Curso_Actualizar
	@IdCurso int,
	@Descripcion nvarchar(200),
	@IdEmpleado nvarchar(100)
AS
BEGIN
	UPDATE Curso SET Descripcion=@Descripcion, IdEmpleado=@IdEmpleado
	WHERE IdCurso= @IdCurso
END;
print('--Script Finalizado--')
go

--STORED PROCEDURES VIDEO--
CREATE PROCEDURE sp_Video_Insertar
	@Nombre nvarchar(200),
	@Url nvarchar(100),
	@FechaPublicacion datetime
AS
BEGIN
	INSERT INTO Video(Nombre,Url,FechaPublicacion)
	VALUES(@Nombre,@Url,@FechaPublicacion)
END;
GO
CREATE PROCEDURE sp_Video_ConsultarTodo
AS
BEGIN
	SELECT * FROM VIDEO
END;
go

CREATE PROCEDURE sp_Video_ConsultarPorID
@IdVideo int
AS
BEGIN
	SELECT * FROM VIDEO
	WHERE IdVideo = @idVideo
END;
go
GO
CREATE PROCEDURE sp_Video_Eliminar
	@IdVideo int
AS
BEGIN
	DELETE FROM VIDEO
	WHERE IdVideo = @idVideo
END;
go
GO
CREATE PROCEDURE sp_Video_Actualizar
	@IdVideo int,
	@Nombre nvarchar(200),
	@Url nvarchar(100),
	@FechaPublicacion datetime
AS
BEGIN
	UPDATE Video SET Nombre=@Nombre,Url=@Url,FechaPublicacion=@FechaPublicacion
	WHERE IdVideo = @IdVideo
END;
print('--Script Finalizado--')