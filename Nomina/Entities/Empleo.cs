using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities
{
    public class Empleo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }

        public bool estado { get; set; } = true;

        public string descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
