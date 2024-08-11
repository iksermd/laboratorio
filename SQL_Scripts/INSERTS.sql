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