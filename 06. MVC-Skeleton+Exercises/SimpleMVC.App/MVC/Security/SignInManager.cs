namespace SimpleMVC.App.MVC.Security
{
    using Interfaces;
    using Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.dbContext.Logins
                .Any(login => login.SessionId == session.Id && login.IsActive);

            return isAuthenticated;
        }

        public void LogoutUser(HttpSession session)
        {
            Login login = this.dbContext.Logins
                .FirstOrDefault(l => l.SessionId == session.Id);

            if (login != null)
            {
                this.dbContext.Logins.Remove(login);
                session.Id = new Random().Next().ToString();
                this.dbContext.SaveChanges();
            }
        }
    }
}
