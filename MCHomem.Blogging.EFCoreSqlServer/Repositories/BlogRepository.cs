using MCHomem.Blogging.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MCHomem.Blogging.EFCoreSqlServer.Repositories
{
    public class BlogRepository : ICrud<Blog>
    {
        #region Methods

        public void Create(Blog entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Blog entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Blogs.Attach(entity);
                db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Blog entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Blogs.Attach(entity);
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public Blog Details(Blog entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                Blog blog = db.Blogs
                    .Where(b => b.BlogId.Equals(entity.BlogId))
                        .FirstOrDefault();

                return blog;
            }
        }

        public List<Blog> Retreave(Blog entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }

        #endregion
    }
}
