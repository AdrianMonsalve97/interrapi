using System.ComponentModel.DataAnnotations;

namespace Estudiantes.API.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; 
    }
}
