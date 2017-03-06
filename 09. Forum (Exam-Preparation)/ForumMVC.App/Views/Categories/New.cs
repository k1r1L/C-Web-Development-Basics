using System.Text;

namespace ForumMVC.App.Views.Categories
{
    using SimpleMVC.Interfaces;
    using Utillities;

    public class New : IRenderable
    {

        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();

            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(NavbarGenerator.GenerateNavbar());
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.CategoryNewFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
