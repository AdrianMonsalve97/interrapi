using System.ComponentModel.DataAnnotations;

namespace Estudiantes.API.Models
{
  public class RegistroCurso
{
    public int Id { get; set; }
    
    public Estudiante Estudiante { get; set; }
    
    public ICollection<Materia> Materias { get; set; }
    
    public int ProfesorId { get; set; }
     public Curso Curso { get; set; }
}
}
