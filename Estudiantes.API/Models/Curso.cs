using System.ComponentModel.DataAnnotations;

namespace Estudiantes.API.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}