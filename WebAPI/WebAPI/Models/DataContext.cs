using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Configuration;

namespace WebAPI.Models
{
    public class DataContext :DbContext
    {
        public DbSet<Articulo> Articulos { get; set;}
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        /*
        //esto es para cambiar el nombre de la tabla de la db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulo>().ToTable("LosArticulos");
            modelBuilder.Entity<Articulo>().Property(p => p.Nombre).HasMaxLength(60);
            modelBuilder.Entity<Articulo>().HasIndex(p => p.Nombre);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //con esto resumo y aplico al config de la instancia de ArticuloConfiguration
            //sirve para aplicar en el contexto de la app
            modelBuilder.ApplyConfiguration(new ArticuloConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
