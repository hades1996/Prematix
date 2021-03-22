namespace prematix.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Pediatra
    {
		public int Id { get; set; }

		[MaxLength(50, ErrorMessage ="este campo no debe tener mas de 50 caracteres")]
		[Required(ErrorMessage ="El Campo {0} es obligatorio")]
		[Display(Name = "Nombre y Apellido")]
		public string Name { get; set; }

		[Required(ErrorMessage = "El Campo {0} es obligatorio")]
		public string Cedula { get; set; }

		[Required(ErrorMessage = "El Campo {0} es obligatorio")]
		public string Entidad { get; set; }

		[Required(ErrorMessage = "El Campo {0} es obligatorio")]
		public string Telefono { get; set; }

		[Display(Name = "Image")]
		[Required(ErrorMessage = "El Campo {0} es obligatorio")]
		public string ImageUrl { get; set; }

	}
}
