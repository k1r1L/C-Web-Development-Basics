namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">Home</a></br>");
            sb.AppendLine("<h3> All users</h3>");
            sb.AppendLine("<ul>");
            foreach (var usernameAndId in this.Model.UsernameIdForUsers)
            {
                sb.AppendLine($"<a href=\"/users/profile?id={usernameAndId.UserId}\"><li>{usernameAndId.Username}</li></a>");
            }
            sb.AppendLine("</ul>");

            sb.AppendLine(@"<a href=""/users/register"">[Go to register]</a>");
            return sb.ToString();
        }
    }
}
