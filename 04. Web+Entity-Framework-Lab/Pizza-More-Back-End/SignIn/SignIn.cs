namespace SignIn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Utility;
    using System.Data.Entity;
    public class SignIn
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header;

        public static void Main(string[] args)
        {
            RequestParameters = new Dictionary<string, string>();
            Header = new Header();
            

            if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                string email = RequestParameters["email"];
                string password = PasswordHasher.Hash(RequestParameters["password"]);

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    User existingUser = RetrieveUserFromDb(email, password);
                    if (existingUser != null)
                    {
                        using (PizzaMoreContext context = new PizzaMoreContext())
                        {

                            Session existingUserSession = new Session()
                            {
                                User = existingUser
                               // UserId = existingUser.Id
                            };

                            context.Entry(existingUser).State = EntityState.Unchanged;
                            context.Sessions.Add(existingUserSession);
                            context.SaveChanges();

                            Cookie sidCookie = new Cookie("sid", existingUserSession.Id.ToString());
                            Header.AddCookie(sidCookie);
                        }
                    }
                }

                ShowHome();
            }
            else
            {
                ShowSignIn();
            }

        }

        private static void ShowHome()
        {
            Header.Print();
            var cookies = WebUtil.GetCookies();
            if (cookies["lang"].Value == "EN")
            {
                WebUtil.PrintFileContent(Constants.HomeEnHtmlLocation);
            }
            else
            {
                WebUtil.PrintFileContent(Constants.HomeDeHtmlLocation);
            }
        }

        private static User RetrieveUserFromDb(string email, string password)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User existingUser = context.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
                return existingUser;
            }
        }

        private static void ShowSignIn()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SignInPageLocation);
        }
    }
}
