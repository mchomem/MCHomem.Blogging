using MCHomem.Blogging.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MCHomem.Blogging.EFCoreSqlServer.Repositories
{
    public class PostRepository : ICrud<Post>
    {
        #region Methods
        public void Create(Post entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Posts.Add(entity);
                db.Blogs.Attach(entity.Blog);
                db.Entry(entity.Blog).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                db.SaveChanges();
            }
        }

        public void Update(Post entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Blogs.Attach(entity.Blog);
                entity.BlogId = entity.Blog.BlogId;
                db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Post entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Posts.Attach(entity);
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public Post Details(Post entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                Post post = db.Posts
                    .Where(p => p.PostId.Equals(entity.PostId))
                        .FirstOrDefault();

                if (post != null)
                {
                    post.Blog = new BlogRepository().Details(new Blog() { BlogId = post.BlogId });
                }

                return post;
            }
        }

        public List<Post> Retreave(Post entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                List<Post> posts = db.Posts.ToList();

                foreach (Post p in posts)
                {
                    p.Blog = new BlogRepository().Details(new Blog() { BlogId = p.BlogId });
                }

                return posts;
            }
        }

        #endregion
    }
}
