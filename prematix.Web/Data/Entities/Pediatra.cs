namespace prematix.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Pediatra
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "este campo no debe tener mas de 50 caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Nombre y Apellido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public string Entidad { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public int Telefono { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public User User { get; set; }
    }
}
