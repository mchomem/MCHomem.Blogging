using MCHomem.Blogging.EFCoreSqlServer.Repositories;
using MCHomem.Blogging.Models.Entities;
using System.Collections.Generic;

namespace MCHomem.Blogging.Controllers
{
    public class BlogController : IController<Blog>
    {
        public void Add(Blog blog)
        {
            new BlogRepository().Create(blog);
        }

        public void Refresh(Blog blog)
        {
            new BlogRepository().Update(blog);
        }

        public void Remove(Blog blog)
        {
            new BlogRepository().Delete(blog);
        }

        public Blog Get(Blog blog)
        {
            return new BlogRepository().Details(blog);
        }

        public List<Blog> GetAll(Blog blog = null)
        {
            return new BlogRepository().Retreave(blog);
        }
    }
}
