namespace prematix.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using prematix.Web.Data.Entities;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Pediatra> Pediatras { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
