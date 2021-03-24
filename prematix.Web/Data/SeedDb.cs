namespace prematix.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using prematix.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("cristiancastillo.1996@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Cristian",
                    LastName = "Castillo",
                    Email = "cristiancastillo.1996@gmail.com",
                    UserName = "cristiancastillo.1996@gmail.com",
                    PhoneNumber = "3215800771",
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Pediatras.Any())
            {
                this.AddPediatra("Ramiro Guzman", "123", user);
                this.AddPediatra("Sergio Perez", "456", user);
                this.AddPediatra("Cristian castillo", "789", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddPediatra(string name, string entidad, User user)
        {
            this.context.Pediatras.Add(new Pediatra
            {
                Name = name,
                Cedula = this.random.Next(1000),
                Entidad = entidad,
                Telefono = this.random.Next(100000),
                User = user
            });
        }
    }
}