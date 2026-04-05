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
            modelBuilder.Entity<DirectoryEntity>(entity =>
            {
                entity.ToTable("directory");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Ignore).HasColumnName("ignore");
                entity.Property(e => e.Inactive).HasColumnName("inactive");

                // Define relationship to ensure DirectoryId is used as the Foreign Key
                entity.HasMany(d => d.Files)
                      .WithOne()
                      .HasForeignKey(f => f.DirectoryId)
                      .IsRequired();
            });

            modelBuilder.Entity<FileEntity>(entity =>
            {
                entity.ToTable("file");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Extension).HasColumnName("extension").IsRequired();
                entity.Property(e => e.DirectoryId).HasColumnName("directory_id");
                entity.Property(e => e.Ignore).HasColumnName("ignore");
                entity.Property(e => e.Inactive).HasColumnName("inactive");
            });

            // EF scans the assembly, finds classes implementing IEntityTypeConfiguration, 
            // and calls their .Configure() methods automatically.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
