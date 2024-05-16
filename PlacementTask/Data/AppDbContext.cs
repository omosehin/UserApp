using Microsoft.EntityFrameworkCore;
using PlacementTask.Model;

namespace PlacementTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProgramTemplate> Programs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseModel>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
