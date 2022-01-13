using Indra.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Indra.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }

        public DatabaseContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = ConfigurationHelper.InitConfiguration();
                var connection = config.GetConnectionString("myDb");
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}
