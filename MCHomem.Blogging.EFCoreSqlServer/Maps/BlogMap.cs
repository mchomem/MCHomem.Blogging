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
                .HasKey(b => b.BlogId);

            modelBuilder
                .Property(b => b.BlogId)
                .HasColumnName("BlogID")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(b => b.Url)
                .HasColumnName("Url")
                .HasMaxLength(1000)
                .IsRequired();
        }

        #endregion
    }
}
