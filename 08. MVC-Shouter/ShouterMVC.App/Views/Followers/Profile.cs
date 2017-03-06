namespace ShouterMVC.App.Views.Followers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Profile : IRenderable<UserProfileViewModel>
    {
        public string Render()
        {
            string htmlContent = string.Empty;

            htmlContent = File.ReadAllText(Constants.ProfileFolderLocation);
            htmlContent = htmlContent.Replace("##username##", Helper.RetrieveUsernameHtml());
            htmlContent = htmlContent.Replace("##userProfile##", this.Model.Username);

            if (Helper.RetrieveCurrent() != this.Model.Username)
            {
                if (this.Model.IsFollowing)
                {
                    htmlContent = htmlContent.Replace("##statusButton##", $"<form action=\"/followers/profile?id={Helper.RetrieveUsernameId(this.Model.Username)}\" method=\"POST\">\r\n<div class=\"input-group\">\r\n<span class=\"input-group-btn\">\r\n\t\t\t" +
                                                                           $"<input type=\"hidden\" name=\"id\" value=\"{Helper.RetrieveUsernameId(this.Model.Username)}\" />" +
                                                                           $" <input class=\"btn btn-danger\" type=\"submit\" value=\"Unfollow\"></input> </span>\r\n</div>\r\n</form>");
                }
                else
                {
                    htmlContent = htmlContent.Replace("##statusButton##", $"<form action=\"/followers/profile?id={Helper.RetrieveUsernameId(this.Model.Username)}\" method=\"POST\">\r\n<div class=\"input-group\">\r\n<span class=\"input-group-btn\">\r\n\t\t\t" +
                                                                          $"<input type=\"hidden\" name=\"id\" value=\"{Helper.RetrieveUsernameId(this.Model.Username)}\" />" +
                                                                          $" <input class=\"btn btn-success\" type=\"submit\" value=\"Follow\"></input> </span>\r\n</div>\r\n</form>");
                }
            }
            else
            {
                htmlContent = htmlContent.Replace("##statusButton##", "");
            }


            StringBuilder shoutsHtml = new StringBuilder();
            foreach (ShoutViewModel shout in this.Model.Shouts)
            {
                string newShoutContent = Helper.RetrieveShoutContent(shout.Content);

                shoutsHtml.AppendLine("<div class=\"thumbnail\">\r\n\t\t\t<h4><strong>" +
                                      $"<a href=\"/followers/profile?id={Helper.RetrieveUsernameId(shout.Username)}\">{shout.Username}</a><strong> <small>{shout.RelativeTime}</small>" +
                                      $"</h4>\r\n\t\t\t<p>{newShoutContent}</p>\r\n\t\t</div>");
            }

            return htmlContent.Replace("##shouts##", shoutsHtml.ToString());
        }

        public UserProfileViewModel Model { get; set; }
    }
}
