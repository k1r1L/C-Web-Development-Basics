using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouterMVC.Data.Repositories
{
    using Contracts;
    using Models;

    public class LoginRepository : GenericRepository<Login>
    {
        public LoginRepository(IShouterContext dbContext)
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

        public bool IsLogged()
        {
            return this.entityTable.Any(l => l.IsActive);
        }
    }
}
