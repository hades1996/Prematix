namespace prematix.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using prematix.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataContext : DbContext
    {
        public DbSet<Pediatra> Pediatras { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
