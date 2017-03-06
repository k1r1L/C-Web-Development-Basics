namespace ForumMVC.App.Views.Home
{
    using System.Collections.Generic;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Category : IRenderable<List<TopicViewModel>>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());

            htmlContent.AppendLine("<div class=\"container\">");
            foreach (TopicViewModel topic in this.Model)
            {
                htmlContent.AppendLine($"<div class=\"thumbnail\" col-lg-offset-1>\r\n\t<h4><strong><a href=\"/topics/details?id={topic.Id}\">{topic.Title}</a>" +
                                       $"<strong> <small><a href=\"/home/categories?categoryName={topic.Category}\">{topic.Category}</a></small></h4>\r\n\t<p>" +
                                       $"<a href=\"#\">{topic.Author}</a> | Replies: {topic.Replies} | {topic.PostedOn:dd:MMM:yyyy}</p>\r\n</div>");
            }
            htmlContent.AppendLine("</div>");
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public List<TopicViewModel> Model { get; set; }
    }
}
