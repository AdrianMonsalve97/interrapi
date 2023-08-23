using System.Collections.Generic;
using System.Linq;
using Estudiantes.API.Data;
using Estudiantes.API.Models;

namespace Estudiantes.API.Services
{
    public class MateriaService
    {
        private readonly ApplicationDbContext _context;

        public MateriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Materia> GetAllMaterias()
        {
            return _context.Materias.ToList();
        }

        public Materia GetMateriaById(int id)
        {
            return _context.Materias.FirstOrDefault(m => m.Id == id);
        }

        public void CreateMateria(Materia materia)
        {
            _context.Materias.Add(materia);
            _context.SaveChanges();
        }

        public void UpdateMateria(Materia materia)
        {
            _context.Materias.Update(materia);
            _context.SaveChanges();
        }

        public void DeleteMateria(int id)
        {
            var materia = _context.Materias.FirstOrDefault(m => m.Id == id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
                _context.SaveChanges();
            }
        }

    }
}
