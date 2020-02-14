using MCHomem.Blogging.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCHomem.Blogging.EFCoreSqlServer.Maps
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        #region Method using Fluent API

        public void Configure(EntityTypeBuilder<Post> modelBuilder)
        {
            modelBuilder
                .ToTable("Post");

            modelBuilder
                .HasKey(p => p.PostId);

            modelBuilder
                .Property(p => p.PostId)
                .HasColumnName("PostID")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(p => p.Title)
                .HasColumnName("Title")
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder
                .Property(p => p.Content)
                .HasColumnName("Content")
                .HasMaxLength(3000)
                .IsRequired();
        }

        #endregion
    }
}
