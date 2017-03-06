namespace SimpleMVC.App.Views.Users
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Register : IRenderable
    {
        public string Render()
        {
            string redirectHome = "<a href=/home/index>Home</a></br>";
            string html = @"<h3>Register new user</h3>
        <form action=""register"" method=""POST"">
        <label for=""Username"">Username:</label>
        <input type=""text"" name=""Username""/></br>
        <label for=""Password"">Password:</label>
        <input type=""password"" name=""Password""/></br>
        <input type=""submit"" value=""Register""/>
    </form>";

            html += @"</br><a href=""/users/all"">[Go to all]</a>";
            return redirectHome + html;
        }
    }
}
