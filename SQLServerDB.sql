USE gestorevento;

CREATE TABLE [EstadosEventos] (
  [IdEstadoEvento] int IDENTITY(1,1) NOT NULL,
  [Descripcion] varchar(60) NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdEstadoEvento])
);

CREATE TABLE [Provincias] (
  [IdProvincia] int IDENTITY(1,1) NOT NULL,
  [Nombre] varchar(60) NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdProvincia]),
  UNIQUE ([Nombre])
);

CREATE TABLE [Servicios] (
  [idServicio] int IDENTITY(1,1) NOT NULL,
  [Descripcion] varchar(45) NOT NULL,
  [PrecioServicio] decimal(10,5) NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([idServicio]),
  UNIQUE ([Descripcion])
);

CREATE TABLE [TiposEventos] (
  [IdTipoEvento] int IDENTITY(1,1) NOT NULL,
  [Descripcion] varchar(45) NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdTipoEvento]),
  UNIQUE ([Descripcion])
);

CREATE TABLE [Usuarios] (
  [IdUsuario] int IDENTITY(1,1) NOT NULL,
  [GoogleIdentificador] varchar(60) NOT NULL,
  [NombreCompleto] varchar(120) DEFAULT NULL,
  [Nombre] varchar(45) DEFAULT NULL,
  [Apellido] varchar(45) DEFAULT NULL,
  [Email] varchar(60) NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdUsuario]),
  UNIQUE ([GoogleIdentificador]),
  UNIQUE ([Email])
);

CREATE TABLE [Localidades] (
  [IdLocalidad] int IDENTITY(1,1) NOT NULL,
  [IdProvincia] int NOT NULL,
  [Nombre] varchar(45) NOT NULL,
  [CodigoArea] varchar(45) NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdLocalidad]),
  FOREIGN KEY ([IdProvincia]) REFERENCES [Provincias] ([IdProvincia])
);

CREATE TABLE [Personas] (
  [IdPersona] int IDENTITY(1,1) NOT NULL,
  [IdLocalidad] int NOT NULL,
  [IdUsuario] int NOT NULL,
  [Nombre] varchar(45) NOT NULL,
  [Apellido] varchar(45) NOT NULL,
  [Telefono] varchar(45) NOT NULL,
  [Email] varchar(45) DEFAULT NULL,
  [DireccionCalle] varchar(45) NOT NULL,
  [DireccionNumero] int NOT NULL,
  [DireccionPiso] varchar(45) DEFAULT NULL,
  [DireccionDepartamento] varchar(45) DEFAULT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdPersona]),
  FOREIGN KEY ([IdLocalidad]) REFERENCES [Localidades] ([IdLocalidad]),
  FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario])
);

CREATE TABLE [Eventos] (
  [IdEvento] int IDENTITY(1,1) NOT NULL,
  [NombreEvento] varchar(45) NOT NULL,
  [FechaEvento] datetime NULL,
  [CantidadPersonas] int NOT NULL,
  [IdTipoEvento] int NOT NULL,
  [IdPersonaAgasajada] int NOT NULL,
  [IdUsuario] int NOT NULL,
  [IdEstadoEvento] int NOT NULL DEFAULT 1,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([IdEvento]),
  FOREIGN KEY ([IdTipoEvento]) REFERENCES [TiposEventos] ([IdTipoEvento]),
  FOREIGN KEY ([IdPersonaAgasajada]) REFERENCES [Personas] ([IdPersona]),
  FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios] ([IdUsuario]),
  FOREIGN KEY ([IdEstadoEvento]) REFERENCES [EstadosEventos] ([IdEstadoEvento])
);

CREATE TABLE [EventosServicios] (
  [idEventosServicios] int IDENTITY(1,1) NOT NULL,
  [IdEvento] int NOT NULL,
  [IdServicio] int NOT NULL,
  [Borrado] bit NOT NULL DEFAULT 0,
  PRIMARY KEY ([idEventosServicios]),
  FOREIGN KEY ([IdEvento]) REFERENCES [Eventos] ([IdEvento]),
  FOREIGN KEY ([IdServicio]) REFERENCES [Servicios] ([idServicio])
);

