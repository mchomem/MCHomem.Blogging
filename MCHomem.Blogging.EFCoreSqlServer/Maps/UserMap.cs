using MCHomem.Blogging.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCHomem.Blogging.EFCoreSqlServer.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        #region Method using Fluent API

        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder
                .ToTable("User");

            modelBuilder
                .HasKey(x => x.UserId);

            modelBuilder
                .Property(x => x.UserId)
                .HasColumnName("UserID")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder
                .Property(x => x.Login)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
                .HasIndex(x => x.Login)
                .IsUnique();

            modelBuilder
                .Property(x => x.Password)
                .HasMaxLength(300)
                .IsRequired();
        }

        #endregion
    }
}
