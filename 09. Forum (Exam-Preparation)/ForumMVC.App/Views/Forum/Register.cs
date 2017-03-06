namespace ForumMVC.App.Views.Forum
{
    using System.Text;
    using SimpleMVC.Interfaces;
    using Utillities;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.NavbarNotLoggedFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.RegisterFolderLocation));
            htmlContent.AppendLine(Reader.RetrieveContent(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
