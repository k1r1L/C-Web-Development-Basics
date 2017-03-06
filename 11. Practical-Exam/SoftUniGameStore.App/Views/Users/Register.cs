namespace SoftUniGameStore.App.Views.Users
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    using Utillities;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavNotLoggedFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.RegisterFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
