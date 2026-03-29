using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using River.Infrastructure.DataAccessLayer.Entities;

namespace River.Infrastructure.DataAccessLayer.Configuration
{
    internal class FileEntityConfiguration : IEntityTypeConfiguration<FileEntity>
    {
        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder.ToTable("file");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Path)
                   .HasColumnName("path")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(x => x.Extension)
                   .HasColumnName("extension")
                   .IsRequired();
        }
    }
}
