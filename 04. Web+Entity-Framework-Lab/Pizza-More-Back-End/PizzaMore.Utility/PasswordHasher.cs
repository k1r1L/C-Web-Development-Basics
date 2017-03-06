namespace PizzaMore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            string hashedPassword = Constants.HasherKeyword + password;

            return hashedPassword;
        }
    }
}
