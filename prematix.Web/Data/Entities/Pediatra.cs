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

		public string Name { get; set; }

		public string Cedula { get; set; }

		public string Entidad { get; set; }

		public string Telefono { get; set; }

		[Display(Name = "Image")]
		public string ImageUrl { get; set; }

	}
}
