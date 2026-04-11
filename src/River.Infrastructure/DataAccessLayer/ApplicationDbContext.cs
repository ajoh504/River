using Microsoft.EntityFrameworkCore;
using River.Infrastructure.DataAccessLayer.Entities;

namespace River.Infrastructure.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TrackedDirectoryEntity> Directories => Set<TrackedDirectoryEntity>();
        public DbSet<TrackedFileEntity> Files => Set<TrackedFileEntity>();
        public DbSet<TrackedFileEntity> SingleFiles => Set<TrackedFileEntity>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackedDirectoryEntity>(entity =>
            {
                entity.ToTable("tracked_directory");
                entity.ToTable(t => t.HasComment("Represents a trackable directory. Changes to the directory, or any of its children files, are also trackable."));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Inactive).HasColumnName("inactive");

                // Define relationship to ensure DirectoryId is used as the Foreign Key
                entity.HasMany(d => d.Files)
                      .WithOne()
                      .HasForeignKey(f => f.DirectoryId)
                      .IsRequired();
            });

            modelBuilder.Entity<TrackedFileEntity>(entity =>
            {
                entity.ToTable("tracked_file");
                entity.ToTable(t => t.HasComment("Represents a trackable file with a parent directory reference. Changes to the parent are also trackable."));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Extension).HasColumnName("extension").IsRequired();
                entity.Property(e => e.DirectoryId).HasColumnName("directory_id");
                entity.Property(e => e.Inactive).HasColumnName("inactive");
            });

            modelBuilder.Entity<TrackedSoloFileEntity>(entity =>
            {
                entity.ToTable("tracked_solo_file");
                entity.ToTable(t => t.HasComment("Represents a trackable file with no parent directory reference."));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Extension).HasColumnName("extension").IsRequired();
                entity.Property(e => e.Inactive).HasColumnName("inactive");
            });

            modelBuilder.Entity<IgnoredDirectoryEntity>(entity =>
            {
                entity.ToTable("ignored_directory");
                entity.ToTable(t => t.HasComment("Represents an ignorable directory. All children files are considered ignorable."));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Inactive).HasColumnName("inactive");
            });

            modelBuilder.Entity<IgnoredFileEntity>(entity =>
            {
                entity.ToTable("ignored_file");
                entity.ToTable(t => t.HasComment("Represents an ignoreable file."));

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.Path).HasColumnName("path").IsRequired();
                entity.Property(e => e.Extension).HasColumnName("extension").IsRequired();
                entity.Property(e => e.Inactive).HasColumnName("inactive");
            });

            // EF scans the assembly, finds classes implementing IEntityTypeConfiguration, 
            // and calls their .Configure() methods automatically.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
