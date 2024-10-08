CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(MAX) NOT NULL,
    Contrasena NVARCHAR(100) NOT NULL
);

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(15) NOT NULL
);

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Precio DECIMAL(18,2) NOT NULL,
    ISV DECIMAL(18,2) NOT NULL
);

CREATE TABLE Direcciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Calle NVARCHAR(200) NOT NULL,
    Ciudad NVARCHAR(100) NOT NULL,
    Departamento NVARCHAR(100) NOT NULL,
    ClienteId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id) ON DELETE CASCADE
);

CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Creacion DATETIME2 NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    ClienteId INT NOT NULL,
    DireccionId INT NOT NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id) ON DELETE CASCADE,
    FOREIGN KEY (DireccionId) REFERENCES Direcciones(Id) ON DELETE RESTRICT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE TABLE PedidoDetalles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT NOT NULL,
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);
