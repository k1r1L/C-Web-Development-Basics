namespace SimpleMVC.App.Views.Users
{
    using SimpleMVC.App.MVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            string redirectHome = "<a href=/home/index>Home</a></br>";
            string html = @"<h3>Login</h3>
        <form action=""login"" method=""POST"">
        <label for=""Username"">Username:</label>
        <input type=""text"" name=""LoginUsername""/></br>
        <label for=""Password"">Password:</label>
        <input type=""password"" name=""LoginPassword""/></br>
        <input type=""submit"" value=""Log In""/>
    </form>";

            return redirectHome + html;
        }
    }
}
