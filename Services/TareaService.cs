using System.Threading;
using WebApiTarea.Dtos;
using WebApiTarea.modelo;

namespace WebApiTarea.Services
{
    public class TareaService
    {
        //Se crea una lista para guardar las tareas 
        private List<Tarea> tareas = new List<Tarea>();
        //Simula el id unico de cada Tarea 
        private int contadorId = 1;

        // Crear una nueva tarea
        public TareaDto CrearTarea(creacionTareaDto creacionTareaDto)
        {
            //Se instancia una Tarea y sus valores
            var nuevaTarea = new Tarea
            {
                Id = contadorId++, // Se incrementa el ID para cada tarea nueva
                tarea = creacionTareaDto.tarea, // Se asigna la descripción de la tarea
                Estado = "Pendiente" // Se asigna el estado inicial como "Pendiente"
            };

            //Se adiciona la tarea a la lista de tareas
            tareas.Add(nuevaTarea);

            //Esto es para poder devolver el tipo TareaDto
            TareaDto tarea = new TareaDto
            {
                Id = nuevaTarea.Id,
                tarea = nuevaTarea.tarea,
                Estado = nuevaTarea.Estado
            };

            return tarea;
        }


        // Listar todas las tareas
        public List<TareaDto> ListarTareas()
        {

            // Lista para almacenar los TareaDTOs que se devolverán
            List<TareaDto> listaTareaDtos = new List<TareaDto>();

            // Se recorren todas las tareas en la lista original y se convierten en DTO
            foreach (var item in tareas)
            {
                listaTareaDtos.Add(new TareaDto
                {
                    Id = item.Id,
                    tarea = item.tarea,
                    Estado = item.Estado
                });
                
            }

            //Devuelve la lista DTO
            return listaTareaDtos;
            
        }


        // Eliminar una tarea por ID
        public bool EliminarTarea(int id)
        {
            // Se busca la tarea por su ID en la lista
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                //Se elimina la tarea
                tareas.Remove(tarea);
                return true; 
            }

            return false;
        }


        // Obtener tareas pendientes
        public List<TareaDto> ObtenerTareasPendientes()
        {
            // Se filtran las tareas que están pendientes y se convierten a DTO 
            return tareas.Where(t => t.Estado == "Pendiente")
                         .Select(t => ConvertirATareaDto(t))
                         .ToList(); //y retorna la lista
        }


        // Completar una tarea por ID
        public TareaDto? CompletarTarea(int id)
        {
            // Se busca la tarea por su ID en la lista
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                // Si se encuentra, se cambia el estado a "Completada"
                tarea.Estado = "Completada";
                return ConvertirATareaDto(tarea); // Se devuelve la tarea convertida a DTO
            }

            return null;
        }

        // Completar una tarea por ID
        public TareaDto? TareaEspecifica(int id)
        {
            // Se busca la tarea por su ID en la lista
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                // Si se encuentra, se devuelve la tarea convertida a DTO
                return ConvertirATareaDto(tarea);
            }

            return null;
        }

        // Convertir Tarea a TareaDTO
        public TareaDto ConvertirATareaDto(Tarea tarea)
        {
            return new TareaDto
            {
                Id = tarea.Id,
                tarea = tarea.tarea,
                Estado = tarea.Estado
            };
        }


    }
}
