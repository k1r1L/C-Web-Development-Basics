namespace ForumMVC.App.Views.Topics
{
    using System.Collections.Generic;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class New : IRenderable<List<string>>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();

            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());
            StringBuilder allCategoriesHtml = new StringBuilder();
            foreach (string modelCategory in this.Model)
            {
                allCategoriesHtml.AppendLine($"<option>{modelCategory}</option>");
            }

            htmlContent.AppendLine(string.Format(Reader.RetrieveContent(Constants.TopicsNewFolderLocation), allCategoriesHtml));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public List<string> Model { get; set; }
    }
}
