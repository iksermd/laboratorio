INSERT INTO Productos (Nombre, Descripcion, Precio, ISV) VALUES 
('Pizza peperoni', 'Queso y peperoni', 200.00, 15.00),
('Pizza Hawaiana', 'Queso, jamón y piña', 250.00, 15.00),
('Pizza 4 estaciones', '4 ingredientes de su elección', 300.00, 15.00),
('Refresco de botella', '', 25.00, 15.00),
('Refresco natural', 'Fresa, piña o limonada', 30.00, 0.00);


INSERT INTO Clientes (Nombre, Telefono) VALUES 
( 'Cliente 1', '123456789'),
( 'Cliente 2', '987654321'),
( 'Cliente 3', '555524555');

INSERT INTO Direcciones (Calle, Ciudad, Departamento, ClienteId) VALUES 
('Calle 1', 'Tegucigalpa', 'Fco. Morazán', 1),
('Calle 2', 'La Esperanza', 'Intibucá', 2),
('Calle 3', 'San Pedro Sula', 'Cortés', 3);


INSERT INTO Usuarios (Nombre, Correo, Contrasena) VALUES
('Usuario','usuario@correo.com','$2a$11$qIDJdaRPEg6vHa.4iAJJnebT2M.lnryqCn2RTMC6bO1oEbiC0AwDK')

INSERT INTO Pedidos (Fecha_Creacion, Total, ClienteId, UsuarioId, DireccionId) VALUES 
('2024-10-10 00:00:00.0000000', 200, 1, 1, 1),
('2024-10-11 00:00:00.0000000', 450, 2, 1, 2),
('2024-10-09 00:00:00.0000000', 600, 3, 1, 1),
('2024-10-10 00:00:00.0000000', 200, 1, 1, 2);
