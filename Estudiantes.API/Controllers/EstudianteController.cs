using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Estudiantes.API.Models;
using Estudiantes.API.Services;

namespace Estudiantes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly EstudianteService _estudianteService;

        public EstudiantesController(EstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiantes()
        {
            var estudiantes = _estudianteService.GetAllEstudiantes();
            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetEstudiante(int id)
        {
            var estudiante = _estudianteService.GetEstudianteById(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return Ok(estudiante);
        }

        [HttpPost]
        public ActionResult CreateEstudiante(Estudiante estudiante)
        {
            _estudianteService.CreateEstudiante(estudiante);
            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, estudiante);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return BadRequest();
            }

            _estudianteService.UpdateEstudiante(estudiante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEstudiante(int id)
        {
            var estudiante = _estudianteService.GetEstudianteById(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _estudianteService.DeleteEstudiante(id);
            return NoContent();
        }
    }
}
