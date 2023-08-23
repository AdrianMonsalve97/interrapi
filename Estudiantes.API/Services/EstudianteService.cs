using System.Collections.Generic;
using System.Linq;
using Estudiantes.API.Data;
using Estudiantes.API.Models;

namespace Estudiantes.API.Services
{
    public class EstudianteService
    {
        private readonly ApplicationDbContext _context;

        public EstudianteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Estudiante> GetAllEstudiantes()
        {
            return _context.Estudiantes.ToList();
        }

        public Estudiante GetEstudianteById(int id)
        {
            return _context.Estudiantes.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
        }

        public void UpdateEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            _context.SaveChanges();
        }

        public void DeleteEstudiante(int id)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
            }
        }

    }
}
