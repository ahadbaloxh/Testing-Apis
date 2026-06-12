using Microsoft.EntityFrameworkCore;
using Testing.Api.Models.Domains;

namespace Testing.Api.Data
{
    public class TestingDBContext : DbContext
    {
        public TestingDBContext(DbContextOptions<TestingDBContext> options)
            : base(options)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        // Most likely this should be:
        public DbSet<Walk> Walks { get; set; }
    }
}