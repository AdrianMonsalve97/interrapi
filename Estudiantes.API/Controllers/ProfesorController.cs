using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Estudiantes.API.Models;
using Estudiantes.API.Services;

namespace Estudiantes.API.Controllers
{
    [Route("api/profesores")] 
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ProfesorService _profesorService;

        public ProfesorController(ProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Profesor>> GetProfesores()
        {
            var profesores = _profesorService.GetAllProfesores();
            return Ok(profesores);
        }

        [HttpGet("{id}")]
        public ActionResult<Profesor> GetProfesor(int id)
        {
            var profesor = _profesorService.GetProfesorById(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return Ok(profesor);
        }

        [HttpPost]
        public ActionResult CreateProfesor(Profesor profesor)
        {
            _profesorService.CreateProfesor(profesor);
            return CreatedAtAction(nameof(GetProfesor), new { id = profesor.Id }, profesor);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProfesor(int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            _profesorService.UpdateProfesor(profesor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProfesor(int id)
        {
            var profesor = _profesorService.GetProfesorById(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _profesorService.DeleteProfesor(id);
            return NoContent();
        }

    }
}
