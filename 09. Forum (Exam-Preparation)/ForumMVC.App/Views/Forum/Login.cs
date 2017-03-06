using System.Text;

namespace ForumMVC.App.Views.Forum
{
    using SimpleMVC.Interfaces;
    using Utillities;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.NavbarNotLoggedFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.LoginFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
