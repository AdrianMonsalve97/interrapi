using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Estudiantes.API.Models;
using Estudiantes.API.Services;

namespace Estudiantes.API.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;
        private readonly ApplicationDbContext _context; 

        public CursoController(CursoService cursoService, ApplicationDbContext context)
        {
            _cursoService = cursoService;
            _context = context; 
        }
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> GetCursos()
        {
            var cursos = _cursoService.GetAllCursos();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> GetCurso(int id)
        {
            var curso = _cursoService.GetCursoById(id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpPost]
        public ActionResult CreateCurso(string nombre)
        {
            var curso = new Curso { Nombre = nombre };
            _cursoService.CreateCurso(curso);
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }
        [HttpPut("{id}")]
        public void UpdateCurso(Curso curso)
        {
            _context.Cursos.Update(curso);
            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCurso(int id)
        {
            var curso = _cursoService.GetCursoById(id);
            if (curso == null)
            {
                return NotFound();
            }

            _cursoService.DeleteCurso(id);
            return NoContent();
        }

    }
}
