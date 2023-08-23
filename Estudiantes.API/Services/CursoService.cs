using System.Collections.Generic;
using System.Linq;
using Estudiantes.API.Data;
using Estudiantes.API.Models;

namespace Estudiantes.API.Services
{
    public class CursoService
    {
        private readonly ApplicationDbContext _context;

        public CursoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Curso> GetAllCursos()
        {
            return _context.Cursos.ToList();
        }

        public Curso GetCursoById(int id)
        {
            return _context.Cursos.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }

        public void UpdateCurso(Curso curso)
        {
            _context.Cursos.Update(curso);
            _context.SaveChanges();
        }

        public void DeleteCurso(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                _context.SaveChanges();
            }
        }

    }
}
