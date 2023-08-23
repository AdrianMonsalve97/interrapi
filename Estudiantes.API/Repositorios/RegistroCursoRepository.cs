using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estudiantes.API.Data;
using Estudiantes.API.Models;

namespace Estudiantes.API.Repositories
{
    public class RegistroCursoRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistroCursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistroCurso>> GetAllAsync() => await _context.RegistrosCursos
                .Include(registro => registro.Estudiante)
                .Include(registro => registro.Curso)
                .ToListAsync();

        public async Task<RegistroCurso> GetByIdAsync(int id)
        {
            return await _context.RegistrosCursos.FindAsync(id);
        }

        public async Task CreateAsync(RegistroCurso registroCurso)
        {
            _context.RegistrosCursos.Add(registroCurso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RegistroCurso registroCurso)
        {
            _context.Entry(registroCurso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registroCurso = await _context.RegistrosCursos.FindAsync(id);
            if (registroCurso != null)
            {
                _context.RegistrosCursos.Remove(registroCurso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
