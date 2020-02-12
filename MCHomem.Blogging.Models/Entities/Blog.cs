using System.Collections.Generic;

namespace MCHomem.Blogging.Models.Entities
{
    public class Blog
    {
        #region Properties

        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();

        #endregion
    }
}
