/*Create Database*/

create Database pruebaDB;

/* salario base */
create table Salario_base(
  id int IDENTITY(1,1) PRIMARY KEY,
  salario FLOAT NOT NULL
)

/* empleados cursos */
create table Empleados_cursos(
  IdEmpleado int,
  IdCurso int,
  fecha date,

  CONSTRAINT FK_Empleados_Cursos_IdEmpleado FOREIGN KEY (IdEmpleado) REFERENCES Empleados(Id),
  CONSTRAINT FK_Empleados_Cursos_IdCurso FOREIGN KEY (IdCurso) REFERENCES Cursos(Id)
)

/* departamentos */
create table Departamentos(
  id int IDENTITY(1,1),
  NombreDepartamento Varchar(45)
)

/* cursos */
create table Cursos(
  id int IDENTITY(1,1) PRIMARY KEY,
  NombreCurso Varchar(45),
  Puntos int
)

/* empleados */
create table Empleados(
  id int IDENTITY(1,1) PRIMARY KEY,
  NombreEmpleado varchar(45) not NULL,
  PorcAdicional int,
  PagoPorPunto int,
  IdPuesto int not null,
  IdDepartamento int not NULL,

  CONSTRAINT FK_Empleado_IdPuesto FOREIGN KEY (IdPuesto) REFERENCES Puestos(Id),
  CONSTRAINT FK_Empleado_IdDepartamento FOREIGN KEY (IdDepartamento) REFERENCES Departamentos(Id)
)

/* puestos */
create table Puestos(
  Id int IDENTITY(1,1) PRIMARY KEY,
  NombrePuesto Varchar(45),
  IdSalario int

  CONSTRAINT FK_Puesto_IdSalario FOREIGN KEY (IdSalario) REFERENCES Salario_base(id)
)
