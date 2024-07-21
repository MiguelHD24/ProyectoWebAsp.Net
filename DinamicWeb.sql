USE master
CREATE DATABASE DinamicWeb
GO
USE DinamicWeb
GO
CREATE TABLE Roles(
IdRol INT PRIMARY KEY IDENTITY (1,1),
Rol VARCHAR(50) NOT NULL,
Activo BIT DEFAULT(1),
IdUsuarioRegistra INT NOT NULL,
FechaRegistro DATETIME NOT NULL,
IdUsuarioActualiza INT NULL,
FechaActualizacion DATETIME NULL
)
GO
CREATE TABLE Usuarios
(
IdUsuario INT PRIMARY KEY IDENTITY (1,1),
NombreCompleto VARCHAR(200) NOT NULL,
Correo VARCHAR(200) NOT NULL,
UserName VARCHAR(50) NOT NULL,
Password VARBINARY(MAX) NOT NULL,
Bloqueado BIT NOT NULL,
IntentosFallidos SMALLINT NOT NULL DEFAULT(0),
IdRol INT FOREIGN KEY REFERENCES Roles(IdRol),
Activo BIT DEFAULT(1),
IdUsuarioRegistra INT NOT NULL,
FechaRegistro DATETIME NOT NULL,
IdUsuarioActualiza INT NULL,
FechaActualizacion DATETIME NULL
)
GO
CREATE TABLE Formularios(
IdFormulario INT PRIMARY KEY IDENTITY(1,1),
Formulario VARCHAR(50) NOT NULL,
Activo BIT DEFAULT(1),
IdUsuarioRegistra INT NOT NULL,
FechaRegistro DATETIME NOT NULL,
IdUsuarioActualiza INT NULL,
FechaActualizacion DATETIME NULL
)
GO
CREATE TABLE Permisos(
IdPermiso INT PRIMARY KEY IDENTITY(1,1),
Permiso VARCHAR(50) NOT NULL,
Activo BIT DEFAULT(1),
IdUsuarioRegistra INT NOT NULL,
FechaRegistro DATETIME NOT NULL,
IdUsuarioActualiza INT NULL,
FechaActualizacion DATETIME NULL
)
CREATE TABLE RolFormularios
(
IdRolFormulario INT PRIMARY KEY IDENTITY(1,1),
IdRol INT FOREIGN KEY REFERENCES Roles(IdRol),
IdFormulario INT FOREIGN KEY REFERENCES Formularios(IdFormulario),
Activo BIT DEFAULT(1),
IdUsuarioRegistra INT NOT NULL,
FechaRegistro DATETIME NOT NULL,
IdUsuarioActualiza INT NULL,
FechaActualizacion DATETIME NULL
)
GO
CREATE TABLE RolPermisos
(
IdRolPermiso INT PRIMARY KEY IDENTITY (1,1),
IdRol INT FOREIGN KEY REFERENCES Roles(IdRol),
IdPermiso INT FOREIGN KEY REFERENCES Permisos(IdPermiso),
Activo BIT DEFAULT(1),
IdUsuarioRegistra INT NOT NULL,
FechaRegistro DATETIME NOT NULL,
IdUsuarioActualiza INT NULL,
FechaActualizacion DATETIME NULL
)