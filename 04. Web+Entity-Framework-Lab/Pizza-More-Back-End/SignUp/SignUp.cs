namespace SignUp
{
    using PizzaMore.Data;
    using PizzaMore.Models;
    using PizzaMore.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignUp
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
                    User newUser = new User()
                    {
                        Email = email,
                        Password = password
                    };


                    using (PizzaMoreContext context = new PizzaMoreContext())
                    {
                        if (!context.Users.Any(u => u.Email == newUser.Email))
                        {
                            context.Users.Add(newUser);
                            context.SaveChanges();
                        }
                    }
                }
            }

            ShowPage();
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SignUpPageLocation);
        }
    }
}
