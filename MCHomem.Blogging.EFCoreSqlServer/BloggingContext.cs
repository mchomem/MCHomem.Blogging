using MCHomem.Blogging.EFCoreSqlServer.Maps;
using MCHomem.Blogging.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MCHomem.Blogging.EFCoreSqlServer
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost\SQL2017;Database=EFCoreBlogging;User Id=sa;Password=sa@2012;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}
