global using Microsoft.EntityFrameworkCore;

namespace PhoneBookTestApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PhoneBookdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<Person> Persons {get; set;}
    }
}
