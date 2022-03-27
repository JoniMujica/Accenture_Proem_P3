using Microsoft.EntityFrameworkCore;

namespace MVC_StarWars.Models
{
    public class StarwarsDb : DbContext
    {
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Mision> Misiones { get; set; }

        public StarwarsDb()
        {

        }
        public StarwarsDb(DbContextOptions<StarwarsDb> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Mision>().ToTable("TablaDeMision");
            //modelBuilder.Entity<Mision>().HasOne(x => x.Personaje);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // options.UseInMemoryDatabase("Startwars");
        }*/
    }
}
