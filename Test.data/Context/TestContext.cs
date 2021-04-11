using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using Test.data.Mapping;
using Test.data.Models;

namespace Test.data
{
    public partial class TestContext : DbContext
    {
        public static string ConnectionString { get; set; }
        public static string CurrentURL { get; set; }
        public static string SecretKey { get; set; }
        public static string AppURL { get; set; }
        public static string TokenExpireMinute { get; set; }
        public IConfigurationRoot Configuration { get; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            Database.SetCommandTimeout(150000);
        }
        public TestContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<GlobalConfiguration> GlobalConfiguration { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap(modelBuilder.Entity<Users>());
        }
    }
}