# WebApiTarea

Este proyecto es una API básica para la gestión de tareas, desarrollada en .NET Core usando ASP.NET. Permite crear, listar, eliminar, y completar tareas, así como obtener las tareas pendientes.

## Funcionalidades
- **Crear Tarea**: Permite agregar nuevas tareas con estado "Pendiente".
- **Listar Tareas**: Devuelve todas las tareas.
- **Eliminar Tarea**: Elimina una tarea específica por su ID.
- **Completar Tarea**: Cambia el estado de una tarea a "Completada".
- **Listar Tareas Pendientes**: Devuelve solo las tareas que están pendientes.
- **Obtener Tarea por ID**: Obtiene una tarea específica por su ID.

## Estructura del Proyecto

- **`Services/TareaService.cs`**: Contiene la lógica de negocio para la gestión de tareas, como las operaciones de creación, listado, actualización, y eliminación (CRUD). Aquí se manipulan las entidades de dominio y se utilizan DTOs para transportar la información entre la capa de negocio y la capa de presentación.
- **`Controllers/TareaController.cs`**: Define las rutas de la API para interactuar con la aplicación. Este controlador recibe las solicitudes HTTP (GET, POST, PUT, DELETE), delega la lógica a TareaService, y devuelve las respuestas a los clientes (usualmente en formato JSON).
- **`Dtos`**: Contiene los Data Transfer Objects (DTOs) que definen cómo se envían y reciben los datos a través de la API. Los DTOs son versiones simplificadas de los modelos, diseñadas para transportar datos de manera segura y eficiente entre el cliente y el servidor.
- **`Modelos`**: Este archivo define el Modelo Tarea, que representa la entidad principal del dominio. En el contexto de una base de datos, un modelo como Tarea se mapea a una tabla de la base de datos y refleja las propiedades de las columnas de dicha tabla (por ejemplo, Id, tarea, y Estado). Cuando se conecta una base de datos, este modelo se utiliza junto con Entity Framework o algún ORM similar para interactuar directamente con las tablas.

## Instalación y Ejecución

### Requisitos
- .NET SDK 6.0 o superior
- Visual Studio Code o Visual Studio
- Postman o cualquier cliente para probar APIs

### Pasos

1. **Clonar el Repositorio**:
   ```bash
   git clone https://github.com/tu-repositorio/WebApiTarea.git
