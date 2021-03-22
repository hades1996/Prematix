namespace prematix.Web.Data
{
    using Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Pediatras.Any())
            {
                this.AddPediatra("Ramiro Guzman", "123");
                this.AddPediatra("Sergio Perez", "456");
                this.AddPediatra("Cristian castillo", "789");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddPediatra(string name, string entidad)
        {
            this.context.Pediatras.Add(new Pediatra
            {
                Name = name,
                Cedula = this.random.Next(1000),
                Entidad = entidad,
                Telefono = this.random.Next(100000)
            });
        }
    }
}