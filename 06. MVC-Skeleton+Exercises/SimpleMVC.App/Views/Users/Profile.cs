namespace SimpleMVC.App.Views.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using SimpleMVC.App.ViewModels;

    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h3>User: {this.Model.Username}</h3>");

            sb.AppendLine($"<form action=\"profile\" method=\"POST\">");
            sb.AppendLine("Title: <input type=\"text\" name=\"Title\" /></br>");
            sb.AppendLine("Content: <input type=\"text\" name=\"Content\" /></br>");
            sb.AppendLine($"<input type=\"hidden\" name=\"UserId\" value=\"{this.Model.UserId}\"/>");
            sb.AppendLine("<input type=\"submit\" value=\"Add Notes\" />");
            sb.AppendLine("</form>");
            sb.AppendLine("<h5>List of notes</h5>");
            sb.AppendLine("<ul>");
            foreach (NoteViewModel note in this.Model.Notes)
            {
                sb.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li></h5>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}
