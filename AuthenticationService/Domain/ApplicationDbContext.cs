using ChatServerApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ChatServerApi.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<IdentificationEntity> Identification { get; set; }


        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}