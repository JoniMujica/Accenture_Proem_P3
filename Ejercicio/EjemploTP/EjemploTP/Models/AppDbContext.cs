using Microsoft.EntityFrameworkCore;

namespace EjemploTP.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trago> Tragos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set;}
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Factura> Factura { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=EjTP;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
