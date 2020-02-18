using MCHomem.Blogging.EFCoreSqlServer.Repositories;
using MCHomem.Blogging.Models.Entities;
using System.Collections.Generic;

namespace MCHomem.Blogging.Controllers
{
    public class UserController : IController<User>
    {
        public void Add(User user)
        {
            new UserRepository().Create(user);
        }

        public void Refresh(User user)
        {
            new UserRepository().Update(user);
        }

        public void Remove(User user)
        {
            new UserRepository().Delete(user);
        }

        public User Get(User user)
        {
            return new UserRepository().Details(user);
        }

        public List<User> GetAll(User user = null)
        {
            return new UserRepository().Retreave(user);
        }

        public User CheckUserLogin(User user = null)
        {
            return new UserRepository().Authenticate(user);
        }

        public void InitializeUser()
        {
            List<User> users = GetAll();

            if (users.Count.Equals(0))
            {
                User user = new User();
                user.Name = "Administrator";
                user.Login = "admin";
                user.Password = "admin";

                new UserRepository().Create(user);
            }
        }
    }
}
