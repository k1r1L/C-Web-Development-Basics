using System.Text;

namespace ForumMVC.App.Views.Home
{
    using System.Collections.Generic;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;
    public class Categories : IRenderable<List<string>>
    {
        public string Render()
        {

            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());

            htmlContent.AppendLine("<div class=\"container\">");
            htmlContent.AppendLine("<ul class=\"col-lg-offset-1\">");
            foreach (string category in this.Model)
            {
                htmlContent.AppendLine($"<li><a href=\"/home/category?categoryName={category}\">{category}</li>");
            }
            htmlContent.AppendLine("</ul>");
            htmlContent.AppendLine("</div>");
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public List<string> Model { get; set; }
    }
}
