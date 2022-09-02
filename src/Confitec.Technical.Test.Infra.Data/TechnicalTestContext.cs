using Confitec.Technical.Test.Domain.UserModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Confitec.Technical.Test.Infra.Data
{
    public class TechnicalTestContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TechnicalTestContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TechnicalTest"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<User> Users { get; set; }
    }
}
