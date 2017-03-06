namespace ShouterMVC.Data.Repositories
{
    using System.Linq;
    using BindingModels.BindingModels;
    using Contracts;
    using Models;

    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(IShouterContext dbContext)
            : base(dbContext)
        {
        }


        public bool ExistsUser(RegisterUserBindingModel rubm)
        {
            bool userExists = this.entityTable.Any(
                user => user.Email == rubm.Email || user.Username == rubm.Username);

            return userExists;
        }
    }
}
