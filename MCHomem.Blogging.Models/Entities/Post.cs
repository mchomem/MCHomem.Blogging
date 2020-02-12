namespace MCHomem.Blogging.Models.Entities
{
    public class Post
    {
        #region Properties

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        #endregion
    }
}
