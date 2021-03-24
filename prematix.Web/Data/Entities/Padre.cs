namespace prematix.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Padre : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "este campo no debe tener mas de 50 caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Nombre y Apellido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public int Telefono { get; set; }

        public User User { get; set; }
    }
}
