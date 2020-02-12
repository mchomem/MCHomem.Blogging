using MCHomem.Blogging.EFCoreSqlServer.Repositories;
using MCHomem.Blogging.Models.Entities;
using System.Collections.Generic;

namespace MCHomem.Blogging.Controllers
{
    public class PostController
    {
        public void Add(Post post)
        {
            new PostRepository().Create(post);
        }

        public void Refresh(Post post)
        {
            new PostRepository().Update(post);
        }

        public void Remove(Post post)
        {
            new PostRepository().Delete(post);
        }

        public Post Get(Post post)
        {
            return new PostRepository().Details(post);
        }

        public List<Post> GetAll(Post post = null)
        {
            return new PostRepository().Retreave(post);
        }
    }
}
