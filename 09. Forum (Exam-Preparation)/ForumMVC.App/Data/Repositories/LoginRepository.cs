namespace ForumMVC.App.Data.Repositories
{
    using System.Linq;
    using Contracts;
    using Models;
    public class LoginRepository : GenericRepository<Login>
    {
        public LoginRepository(IForumContext dbContext)
            : base(dbContext)
        {
        }

        public User RetrieveCurrentlyLogged()
        {
            Login lastLogin = this.entityTable.FirstOrDefault(l => l.IsActive);

            if (lastLogin != null)
            {
                return lastLogin.User;
            }

            return null;
        }
    }
}
