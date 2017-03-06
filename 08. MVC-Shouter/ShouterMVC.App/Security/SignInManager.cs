namespace ShouterMVC.App.Security
{
    using SimpleHttpServer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Data.Contracts;

    public class SignInManager
    {
        private IShouterContext dbContext;

        public SignInManager(IShouterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.dbContext
                .Logins.Any(login => login.SessionId == session.Id && login.IsActive);

            return isAuthenticated;
        }
    }
}
