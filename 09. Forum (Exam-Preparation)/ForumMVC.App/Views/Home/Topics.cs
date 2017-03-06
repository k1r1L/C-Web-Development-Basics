namespace ForumMVC.App.Views.Home
{
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Topics : IRenderable<TopTenTopicsViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            if (this.Model.IsLogged)
            {
                htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());
                htmlContent.AppendLine("<div class=\"container\">");
                htmlContent.AppendLine("<a href=\"/topics/new\" class=\"btn btn-success\">New Topic</a>\r\n</br></br>");
            }
            else
            {
                htmlContent.AppendLine("<div class=\"container\">");
                htmlContent.AppendLine(Reader.RetrieveContent(Constants.NavbarNotLoggedFolderLocation));
            }

            foreach (TopicViewModel topic in this.Model.Topics)
            {
                htmlContent.AppendLine($"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"/topics/details?id={topic.Id}\">{topic.Title}</a>" +
                                       $"<strong> <small><a href=\"/home/category?categoryName={topic.Category}\">{topic.Category}</a></small></h4>\r\n\t<p>" +
                                       $"<a href=\"/forum/profile?id={topic.AuthorId}\">{topic.Author}</a> | Replies: {topic.Replies} | {topic.PostedOn:dd:MMM:yyyy}</p>\r\n</div>");
            }

            htmlContent.AppendLine("</div>");
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public TopTenTopicsViewModel Model { get; set; }
    }
}
