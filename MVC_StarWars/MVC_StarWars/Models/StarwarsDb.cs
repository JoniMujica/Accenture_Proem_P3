using Microsoft.EntityFrameworkCore;

namespace MVC_StarWars.Models
{
    public class StarwarsDb : DbContext
    {
        public DbSet<Personaje> Personajes { get; set; }

        public StarwarsDb()
        {

        }
        public StarwarsDb(DbContextOptions<StarwarsDb> options):base(options)
        {

        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // options.UseInMemoryDatabase("Startwars");
        }*/
    }
}
