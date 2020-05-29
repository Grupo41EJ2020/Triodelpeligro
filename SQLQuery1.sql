CREATE TABLE Empleado(
	IdEmpleado int primary key IDENTITY(1,1),
	Nombre nvarchar(100),
	Direccion nvarchar(100))

INSERT INTO Empleado(Nombre, Direccion)
VALUES('Juan Carlos', 'Santa Julia 902')

CREATE TABLE Tema(
	IdTema int primary key IDENTITY(1,1),
	Nombre nvarchar(100))

INSERT INTO Tema(Nombre)
VALUES('C#')

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

SELECT * FROM Empleado

INSERT INTO Curso(Descripcion, IdEmpleado)
VALUES('Aprenda a programar', 10)

CREATE TABLE Curso_Tema(
	IdCT int  primary key IDENTITY(1,1),
	IdCurso int,
	IdTema int,
	constraint fk_idCurso FOREIGN KEY(IdCurso) REFERENCES Curso(IdCurso),
	constraint fk_idTema FOREIGN KEY(IdTema) REFERENCES Tema(IdTema),
)

SELECT * FROM Curso_Tema

CREATE TABLE Curso_Tema_Video(
	IdCTV int primary key IDENTITY(1,1),
	IdCT int,
	IdVideo int,
	constraint fk_idCT FOREIGN KEY(IdCT) REFERENCES Curso_Tema(IdCT),
	constraint fk_idVideo FOREIGN KEY(IdVideo) REFERENCES Video(IdVideo),
)

SELECT * FROM Curso_Tema_Video

SELECT * FROM Video

INSERT INTO Curso_Tema_Video(IdCT, IdVideo)
VALUES(14, 2)


----Store Procedure: insertar
go
CREATE PROCEDURE sp_Tema_Insertar
	@Nombre nvarchar(200)
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

	@Nombre nvarchar(100),
	@Direccion nvarchar(100)
AS
BEGIN
	INSERT INTO Empleado (Nombre,Direccion)
	VALUES (@Nombre,@Direccion)
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
	@Descripcion nvarchar(200),
	@IdEmpleado nvarchar(100)
AS
BEGIN
	INSERT INTO Curso (Descripcion,IdEmpleado)
	VALUES (@Descripcion,@IdEmpleado)
END;
print('--Script Finalizado--')
go
drop procedure sp_Curso_Insertar

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

--inserts video--
insert into Video(Nombre,url,FechaPublicacion)
values('Build a Brain Computer App with React Native (Part 7) - Live Coding with Jesse','https://www.youtube.com/embed/W6BzxdHBBHM',CONVERT(datetime, '19/04/2020 19:36:40', 103) )
go
insert into Video(Nombre,url,FechaPublicacion)
values('Data Analysis with Python - Full Course for Beginners (Numpy, Pandas, Matplotlib, Seaborn)','https://www.youtube.com/embed/r-uOLxNrNk8',CONVERT(datetime, '19/04/2020 19:36:40', 103) )

--Stored Procedure: Insertar
go
CREATE PROCEDURE sp_CursoTema_Insertar
	@IdCurso int,
	@IdTema int
AS
BEGIN
	INSERT INTO Curso_Tema(IdCurso,IdTema)
	VALUES(@IdCurso,@IdTema)
END;
GO


---Stored procedure: Actualizar
GO
CREATE PROCEDURE sp_CursoTema_Actualizar
	@IdCT int,
	@IdCurso int,
	@IdTema int
AS
BEGIN
	UPDATE Curso_Tema SET IdCurso = @IdCurso, IdTema = @IdTema 
	WHERE IdCT = @IdCT
END;
go

-- Stored procedure: Eliminar
GO
CREATE PROCEDURE sp_CursoTema_Eliminar
	@IdCT int
AS
BEGIN
	DELETE FROM Curso_Tema
	WHERE IdCT = @IdCT
END;
go


--Stored Procedure: Ver todos
GO
CREATE PROCEDURE sp_CursoTema_ConsultarTodo
AS
BEGIN
	SELECT * FROM Curso_Tema
END;
go


--Stored Procedure: Ver uno
Go
CREATE PROCEDURE sp_CursoTema_ConsultarPorID
@IdCT int
AS
BEGIN
	SELECT * FROM Curso_Tema
	WHERE IdCT = @IdCT
END;
go
=======
GO
--STOREDS PROCEDURES CURSO_TEMA_VIDEO--
CREATE PROCEDURE SP_CURSO_TEMA_VIDEO_INSERTAR
@IdCT int,
@IdVideo int
AS
BEGIN
INSERT INTO Curso_Tema_Video(IdCT, IdVideo)
VALUES(@IdCT, @IdVideo)
END;

GO

CREATE PROCEDURE SP_CURSO_TEMA_VIDEO_EDITAR
@IdCTV int,
@IdCT int,
@IdVideo INT
AS
BEGIN
UPDATE Curso_Tema_Video SET IdCT = @IdCT, IdVideo = @IdVideo WHERE IdCTV = @IdCTV
END;

GO

CREATE PROCEDURE SP_CURSO_TEMA_VIDEO_BORRAR
@IdCTV INT
AS
BEGIN
DELETE FROM Curso_Tema_Video WHERE IdCTV = @IdCTV
END;

GO

CREATE PROCEDURE SP_CURSO_TEMA_VIDEO_CONSULTAR_TODO
AS
BEGIN
SELECT * FROM Curso_Tema_Video
END;

GO

CREATE PROCEDURE SP_CURSO_TEMA_VIDEO_CONSULTAR_POR_ID
@IdCTV INT
AS
BEGIN
SELECT * FROM Curso_Tema_Video WHERE IdCTV = @IdCTV
END;
