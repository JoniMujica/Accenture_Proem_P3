using Microsoft.EntityFrameworkCore;

namespace MVC_ABM.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set;}
        public MyDBContext()
        {

        }
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }
    }
}
