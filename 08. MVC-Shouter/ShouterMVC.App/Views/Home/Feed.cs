namespace ShouterMVC.App.Views.Home
{
    using ShouterMVC.App.Utillities;
    using SimpleMVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Models;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Feed : IRenderable<MainFeedViewModel>
    {
        public string Render()
        {
            string htmlContent = string.Empty;
            if (this.Model.IsLogged)
            {
                htmlContent = File.ReadAllText(Constants.FeedSignedFolderLocation);
                htmlContent = htmlContent.Replace("##username##", Helper.RetrieveUsernameHtml());
            }
            else
            {
                htmlContent = File.ReadAllText(Constants.FeedFolderLocation);
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

        public MainFeedViewModel Model { get; set; }
    }
}
