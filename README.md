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

- **`Services/TareaService.cs`**: Contiene la lógica de negocio para la gestión de tareas (CRUD).
- **`Controllers/TareaController.cs`**: Controlador que expone las rutas para las operaciones CRUD de tareas.
- **`Dtos`**: Contiene los Data Transfer Objects (DTO) utilizados para intercambiar datos en la API.

## Instalación y Ejecución

### Requisitos
- .NET SDK 6.0 o superior
- Visual Studio Code o Visual Studio
- Postman o cualquier cliente para probar APIs

### Pasos

1. **Clonar el Repositorio**:
   ```bash
   git clone https://github.com/tu-repositorio/WebApiTarea.git
