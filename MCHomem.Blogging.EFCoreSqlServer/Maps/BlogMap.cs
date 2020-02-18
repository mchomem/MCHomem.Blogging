using MCHomem.Blogging.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCHomem.Blogging.EFCoreSqlServer.Maps
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        #region Method using Fluent API

        public void Configure(EntityTypeBuilder<Blog> modelBuilder)
        {
            modelBuilder
                .ToTable("Blog");

            modelBuilder
                .HasKey(x => x.BlogId);

            modelBuilder
                .Property(x => x.BlogId)
                .HasColumnName("BlogID")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(x => x.Url)
                .HasColumnName("Url")
                .HasMaxLength(1000)
                .IsRequired();

            modelBuilder
                .HasIndex(x => x.Url)
                .IsUnique();
        }

        #endregion
    }
}
