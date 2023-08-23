using System.Collections.Generic;
using System.Linq;
using Estudiantes.API.Data;
using Estudiantes.API.Models;

namespace Estudiantes.API.Services
{
    public class ProfesorService
    {
        private readonly ApplicationDbContext _context;

        public ProfesorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Profesor> GetAllProfesores()
        {
            return _context.Profesores.ToList();
        }

        public Profesor GetProfesorById(int id)
        {
            return _context.Profesores.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProfesor(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            _context.SaveChanges();
        }

        public void UpdateProfesor(Profesor profesor)
        {
            _context.Profesores.Update(profesor);
            _context.SaveChanges();
        }

        public void DeleteProfesor(int id)
        {
            var profesor = _context.Profesores.FirstOrDefault(p => p.Id == id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
                _context.SaveChanges();
            }
        }

    }
}
