namespace SoftUniGameStore.App.Views.Users
{
    using System.Text;
    using System.IO;
    using SimpleMVC.Interfaces;
    using Utillities;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavNotLoggedFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.LoginFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
