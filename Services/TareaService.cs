using System.Threading;
using WebApiTarea.Dtos;
using WebApiTarea.modelo;

namespace WebApiTarea.Services
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();
        private int contadorId = 1;

        // Crear una nueva tarea
        public TareaDto CrearTarea(creacionTareaDto creacionTareaDto)
        {
            var nuevaTarea = new Tarea
            {
                Id = contadorId++,
                tarea = creacionTareaDto.tarea,
                Estado = "Pendiente"
            };
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
            List<TareaDto> listaTareaDtos = new List<TareaDto>();  
            
            foreach (var item in tareas)
            {
                listaTareaDtos.Add(new TareaDto
                {
                    Id = item.Id,
                    tarea = item.tarea,
                    Estado = item.Estado
                });
                
            }

            return listaTareaDtos;
            
        }


        // Eliminar una tarea por ID
        public bool EliminarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
                return true;
            }
            return false;
        }


        // Obtener tareas pendientes
        public List<TareaDto> ObtenerTareasPendientes()
        {

            return tareas.Where(t => t.Estado == "Pendiente")
                         .Select(t => ConvertirATareaDto(t))
                         .ToList();
        }


        // Completar una tarea por ID
        public TareaDto? CompletarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Estado = "Completada";
                return ConvertirATareaDto(tarea);
            }
            return null;
        }

        // Completar una tarea por ID
        public TareaDto? TareaEspecifica(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            { 
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
