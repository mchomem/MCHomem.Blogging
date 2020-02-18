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
                .HasKey(x => x.PostId);

            modelBuilder
                .Property(x => x.PostId)
                .HasColumnName("PostID")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(x => x.Title)
                .HasColumnName("Title")
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder
                .Property(x => x.Content)
                .HasColumnName("Content")
                .HasMaxLength(3000)
                .IsRequired();
        }

        #endregion
    }
}
