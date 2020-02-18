using MCHomem.Blogging.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MCHomem.Blogging.EFCoreSqlServer.Repositories
{
    public class UserRepository : ICrud<User>
    {
        public void Create(User entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Users.Attach(entity);
                db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                db.Users.Attach(entity);
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public User Details(User entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                User user = db.Users
                    .Where(x => x.UserId.Equals(entity.UserId))
                        .FirstOrDefault();

                return user;
            }
        }

        public List<User> Retreave(User entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                return db.Users.ToList();
            }
        }

        public User Authenticate(User entity)
        {
            using (BloggingContext db = new BloggingContext())
            {
                User user = db.Users
                    .Where(x => x.Login.Equals(entity.Login)
                           && x.Password.Equals(entity.Password))
                        .FirstOrDefault();

                return user;
            }
        }
    }
}
