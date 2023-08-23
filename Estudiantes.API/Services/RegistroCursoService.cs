using System.Collections.Generic;
using System.Linq;
using Estudiantes.API.Data;
using Estudiantes.API.Models;

namespace Estudiantes.API.Services
{
    public class RegistroCursoService
    {
        private readonly ApplicationDbContext _context;

        public RegistroCursoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RegistroCurso> GetAllRegistrosCursos()
        {
            return _context.RegistrosCursos.ToList();
        }

        public RegistroCurso GetRegistroCursoById(int id)
        {
            return _context.RegistrosCursos.FirstOrDefault(rc => rc.Id == id);
        }

        public void CreateRegistroCurso(RegistroCurso registroCurso)
        {
            _context.RegistrosCursos.Add(registroCurso);
            _context.SaveChanges();
        }

        public void UpdateRegistroCurso(RegistroCurso registroCurso)
        {
            _context.RegistrosCursos.Update(registroCurso);
            _context.SaveChanges();
        }

        public void DeleteRegistroCurso(int id)
        {
            var registroCurso = _context.RegistrosCursos.FirstOrDefault(rc => rc.Id == id);
            if (registroCurso != null)
            {
                _context.RegistrosCursos.Remove(registroCurso);
                _context.SaveChanges();
            }
        }

    }
}
