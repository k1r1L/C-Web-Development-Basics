namespace SimpleMVC.App.Security
{
    using Data;
    using Models;
    using SimpleHttpServer.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignInManager
    {
        private PizzaMoreContext dbContext;

        public SignInManager(PizzaMoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.dbContext.Logins
                .Any(login => login.SessionId == session.Id && login.IsActive);

            return isAuthenticated;
        }

        public void Logout(HttpSession session)
        {
            Login login = this.dbContext.Logins
                 .FirstOrDefault(l => l.SessionId == session.Id);

            if (login != null)
            {
                login.IsActive = false;
                try
                {
                    this.dbContext.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validErrors in ex.EntityValidationErrors)
                    {
                        foreach (var error in validErrors.ValidationErrors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                    throw;
                }
                session.Id = new Random().Next().ToString();
            }
        }
    }
}
