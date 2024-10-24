using Microsoft.AspNetCore.Mvc;
using WebApiTarea.Dtos;
using WebApiTarea.Services;

namespace WebApiTarea.Controllers
{
    [Route("api/tareas")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaService _tareaService;

        // Constructor del controlador que recibe una instancia del servicio de tareas
        public TareaController(TareaService tareaService)
        {
            _tareaService = tareaService;
        }

        //Todos los Http.. son Endpint

        // Retorna todas las tareas
        [HttpGet]
        public ActionResult<List<TareaDto>> ListaTareas()
        {
            // Llama al método ListarTareas de TareaService y retorna el resultado en un 200 OK
            return Ok(_tareaService.ListarTareas());
        }

        // Crear una nueva tarea
        [HttpPost]
        public ActionResult<TareaDto> crear([FromBody] creacionTareaDto creacionTareaDto)
        {
            // Llama al método CrearTarea de TareaService y retorna la tarea creada
            var nuevaTarea = _tareaService.CrearTarea(creacionTareaDto);
            return Ok(nuevaTarea);
        }

        // Eliminar una tarea por ID
        [HttpDelete("{id}")]
        public IActionResult EliminarTarea(int id)
        {
            // Llama al método EliminarTarea de TareaService
            var eliminado = _tareaService.EliminarTarea(id);
            if (!eliminado)
            {
                // Si no se elimina, retorna 404 Not Found
                return NotFound();
            }
            return NoContent(); // Si se elimina, retorna 204 No Content
        }

        // Completa una tarea por ID
        [HttpPut("{id}")]
        public ActionResult<TareaDto> CompletarTarea(int id)
        {
            // Llama al método CompletarTarea de TareaService
            var tarea = _tareaService.CompletarTarea(id);
            if (tarea == null)
            {
                // Si no se encuentra la tarea, retorna 404 Not Found
                return NotFound();
            }
            return Ok(tarea); // Si se completa, retorna la tarea completada
        }

        // Obtener todas las tareas pendientes
        [HttpGet("pendientes")]
        public ActionResult<List<TareaDto>> ObtenerTareasPendientes()
        {
            // Llama al método ObtenerTareasPendientes de TareaService y retorna la lista
            return Ok(_tareaService.ObtenerTareasPendientes());
        }

        // Obtener una tarea específica por su ID
        [HttpGet("{id}")]
        public ActionResult<TareaDto> TareaPendiente(int id)
        {
            // Llama al método TareaEspecifica de TareaService  y retorna la tarea
            return Ok(_tareaService.TareaEspecifica(id));
        }
    }
}