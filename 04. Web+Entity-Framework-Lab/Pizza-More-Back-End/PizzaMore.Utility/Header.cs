namespace PizzaMore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Header
    {
        public Header()
        {
            this.Type = "Content-type: text/html";
            this.CookieCollection = new CookieCollection();
        }

        public string Type { get; set; }

        public string Location { get; set; }

        public ICookieCollection CookieCollection { get; private set; }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            this.CookieCollection.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Type);

            if (this.CookieCollection.Count != 0)
            {
                foreach (var cookie in this.CookieCollection)
                {
                    sb.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }
            }

            if (this.Location != null)
            {
                sb.AppendLine(this.Location);
            }

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
