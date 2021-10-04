CREATE TABLE [dbo].[Cargos]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    Cargo varchar(60)
)

CREATE TABLE [dbo].[Empleados]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	Codigo varchar(60) unique,
	Nombre varchar(30),
	Apellido varchar(30),
	Telefono varchar(10),
	Departamento_Id int foreign key references Departamentos(Id),
	Cargo_Id int foreign key references Cargos(Id),
	Fecha_Ingreso date,
	Salario decimal(10,2),
	Estatus varchar(8)
)

CREATE TABLE [dbo].[Nominas]
(
Id int identity(1,1), 
Fecha date,
Monto_Total money	

)

CREATE TABLE [dbo].[Salidas]
(
Id_Empleado int foreign key references Empleados(Id),
Tipo varchar(10),
Motivo varchar(50),
Fecha date
)


CREATE TABLE [dbo].[Vacaciones]
(
Id_Empleado int foreign key references Empleados(Id),
Desde date,
Hasta date,
Año_Correspondiente int,
Comentarios varchar(50) null
)

CREATE TABLE [dbo].[Permisos]
(
Id_Empleado int foreign key references Empleados(Id),
Desde date,
Hasta date,
Comentarios varchar(50) null
)

CREATE TABLE [dbo].[Licencias]
(
Id_Empleado int foreign key references Empleados(Id),
Desde date,
Hasta date,
Motivo varchar(50),
Comentarios varchar(50) null
)



