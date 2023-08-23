using System.ComponentModel.DataAnnotations;

namespace Estudiantes.API.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public ICollection<RegistroCurso> RegistrosCursos { get; set; }
        public ICollection<Materia> MateriasRegistradas { get; set; }


    }
}
