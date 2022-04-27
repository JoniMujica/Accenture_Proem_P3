using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class DataContext :DbContext
    {
        public DbSet<Articulo> Articulos { get; set;}
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
