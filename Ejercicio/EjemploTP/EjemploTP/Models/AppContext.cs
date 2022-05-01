using Microsoft.EntityFrameworkCore;

namespace EjemploTP.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Trago> Tragos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=EjTP;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
