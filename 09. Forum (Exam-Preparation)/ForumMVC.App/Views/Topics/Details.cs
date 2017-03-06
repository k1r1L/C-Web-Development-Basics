using System.Text;

namespace ForumMVC.App.Views.Topics
{
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;
    public class Details : IRenderable<TopicDetailsViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();

            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());
            htmlContent.AppendLine("<div class=\"container\"><div class=\"row\">");
            htmlContent.AppendLine(this.Model.Topic.ToString());
            foreach (ReplyViewModel replyViewModel in this.Model.ReplyViewModels)
            {
                if (replyViewModel.ImageUrl != string.Empty)
                {
                    htmlContent.AppendLine(
                        $"<div class=\"thumbnail reply col-lg-offset-1\">\r\n\t<h5><strong><a href=\"/forum/profile?id={replyViewModel.AuthorId}\">{replyViewModel.Author}</a>" +
                        $"<strong> {replyViewModel.PostedOn:dd:MMM:yyyy}</h5>\r\n\t<p>" +
                        $"{replyViewModel.Text}</p>\r\n\t" +
                        $"<img src=\"{replyViewModel.ImageUrl}\" width=\"350\" height=\"150\" />\r\n</div>\t\t");
                }
                else
                {
                    htmlContent.AppendLine(
                        $"<div class=\"thumbnail reply col-lg-offset-1\">\r\n\t<h5><strong><a href=\"/forum/profile?id={replyViewModel.AuthorId}\">{replyViewModel.Author}</a>" +
                        $"<strong> {replyViewModel.PostedOn}</h5>\r\n\t<p>{replyViewModel.Text}</p>\r\n</div>\t\t");
                }
            }

            htmlContent.AppendLine(Reader.RetrieveContent(Constants.ReplyNewFolderLocation));
            htmlContent.AppendLine("</div></div>");
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return string.Format(htmlContent.ToString(), $"action=\"/topics/details?id={this.Model.Topic.Id}\"");
        }

        public TopicDetailsViewModel Model { get; set; }
    }
}
