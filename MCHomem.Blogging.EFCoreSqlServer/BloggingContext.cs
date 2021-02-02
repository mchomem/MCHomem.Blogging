using MCHomem.Blogging.EFCoreSqlServer.Mappings;
using MCHomem.Blogging.Models;
using MCHomem.Blogging.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCHomem.Blogging.EFCoreSqlServer
{
    public class BloggingContext : DbContext
    {
        #region Properties

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Events

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(AppSettings.StringConnection);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        #endregion
    }
}
