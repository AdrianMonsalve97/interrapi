using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Estudiantes.API.Models;
using Estudiantes.API.Services;

namespace Estudiantes.API.Controllers
{
   [Route("api/registros")] 
    [ApiController]
    public class RegistroCursoController : ControllerBase
    {
        private readonly RegistroCursoService _registroCursoService;
        private readonly EstudianteService _estudianteService;
        private readonly ProfesorService _profesorService;

        public RegistroCursoController(RegistroCursoService registroCursoService, EstudianteService estudianteService, ProfesorService profesorService)
        {
            _registroCursoService = registroCursoService;
            _estudianteService = estudianteService;
            _profesorService = profesorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RegistroCurso>> GetRegistrosCursos()
        {
            var registrosCursos = _registroCursoService.GetAllRegistrosCursos();
            return Ok(registrosCursos);
        }

        [HttpGet("{id}")]
        public ActionResult<RegistroCurso> GetRegistroCurso(int id)
        {
            var registroCurso = _registroCursoService.GetRegistroCursoById(id);
            if (registroCurso == null)
            {
                return NotFound();
            }
            return Ok(registroCurso);
        }

        [HttpPost]
        public ActionResult CreateRegistroCurso(RegistroCurso registroCurso)
        {
            var estudiante = registroCurso.Estudiante;
            if (estudiante != null && estudiante.RegistrosCursos.Count >= 3)
            {
                return BadRequest("El estudiante ya está registrado en 3 materias.");
            }

            var profesor = _profesorService.GetProfesorById(registroCurso.ProfesorId);
            if (estudiante != null && profesor != null && estudiante.RegistrosCursos.Any(r => r.ProfesorId == profesor.Id))
            {
                return BadRequest("El estudiante ya tiene un registro con el mismo profesor.");
            }

            var materiasDelEstudiante = estudiante.MateriasRegistradas.Select(m => m.Id);
            if (materiasDelEstudiante.Intersect(registroCurso.Materias.Select(m => m.Id)).Any())
            {
                return BadRequest("El estudiante ya está registrado en una o más de las materias seleccionadas.");
            }

            _registroCursoService.CreateRegistroCurso(registroCurso);
            return CreatedAtAction(nameof(GetRegistroCurso), new { id = registroCurso.Id }, registroCurso);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRegistroCurso(int id, RegistroCurso registroCurso)
        {
            if (id != registroCurso.Id)
            {
                return BadRequest();
            }

            _registroCursoService.UpdateRegistroCurso(registroCurso);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRegistroCurso(int id)
        {
            var registroCurso = _registroCursoService.GetRegistroCursoById(id);
            if (registroCurso == null)
            {
                return NotFound();
            }

            _registroCursoService.DeleteRegistroCurso(id);
            return NoContent();
        }
    }
}
