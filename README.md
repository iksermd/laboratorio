# PizzaPOS

PizzaPOS es un sistema de punto de venta para pizzerías, desarrollado con .NET Core 8, Entity Framework y Windows Forms, utilizando una arquitectura de capas.

## Características
- Registro de usuarios
- Gestión de pedidos
- Gestión de productos
- Gestión de clientes

## Requisitos

- .NET Core 8 SDK
- SQL Server
- Visual Studio 2022 o superior



## Ejecutar localmente

1. Clonar el proyecto

```bash
  git clone https://github.com/iksermd/laboratorio.git
```

2. Ir a la raíz de la solución

```bash
  cd laboratorio
```

3. Configurar variables de entorno para back-end en archivo WebApi/appsettings.json

4. Ejecutar migraciones o en su defecto aplicar script de creación de tablas en /SQL_Scripts

```bash
  dotnet ef database update --project DAL --startup-project WebApi
```

5. Aplicar script de insersión INSERTS.sql

3. Configurar variables de entorno para front-end en archivo PizzaPOS/appsettings.json
