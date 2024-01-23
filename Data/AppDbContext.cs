using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace UniversityEvents.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbSet<Event> Events { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
