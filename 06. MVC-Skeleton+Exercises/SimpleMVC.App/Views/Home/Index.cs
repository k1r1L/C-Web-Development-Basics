namespace SimpleMVC.App.Views.Home
{
    using SimpleMVC.App.MVC.Interfaces;
    using System.Text;
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>Notes App</h1></br>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a></br>");
            sb.AppendLine("<a href=\"/users/register\">Register Maafaka</a></br>");
            sb.Append("<form method=\"POST\">");
            sb.AppendLine("<input type=\"submit\" value=\"Log out\" />");
            sb.Append("</form>");
            return sb.ToString();
        }
    }
}
