using MCHomem.Blogging.EFCoreSqlServer.Mappings;
using MCHomem.Blogging.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCHomem.Blogging.EFCoreSqlServer
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost\SQL2017;Database=EFCoreBlogging;User Id=sa;Password=sa@2012;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
