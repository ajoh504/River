using Microsoft.EntityFrameworkCore;
using River.Infrastructure.DataAccessLayer.Entities;

namespace River.Infrastructure.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DirectoryEntity> Directories => Set<DirectoryEntity>();
        public DbSet<FileEntity> Files => Set<FileEntity>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // EF scans the assembly, finds classes implementing IEntityTypeConfiguration, 
            // and calls their .Configure() methods automatically.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
