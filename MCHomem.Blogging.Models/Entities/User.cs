using System;

namespace MCHomem.Blogging.Models.Entities
{
    public class User
    {
        #region Properties

        public Int32 UserId { get; set; }
        public String Name { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }

        #endregion
    }
}
