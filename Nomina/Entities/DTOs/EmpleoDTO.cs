using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities.DTOs
{
    public class EmpleoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        public bool estado { get; set; } = true;

        public string Descripcion { get; set; }
    }
}
