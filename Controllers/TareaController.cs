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

        public TareaController(TareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public ActionResult<List<TareaDto>> ListaTareas()
        {
            return Ok(_tareaService.ListarTareas());
        }

        [HttpPost]
        public ActionResult<TareaDto> crear([FromBody] creacionTareaDto creacionTareaDto)
        {
            var nuevaTarea = _tareaService.CrearTarea(creacionTareaDto);
            return Ok(nuevaTarea);  
        }

        //Elimina la tarea por in indice
        [HttpDelete("{id}")]
        public IActionResult EliminarTarea(int id)
        {
            var eliminado = _tareaService.EliminarTarea(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }



    }
}
