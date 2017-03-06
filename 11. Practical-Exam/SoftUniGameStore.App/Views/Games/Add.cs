using System.Text;

namespace SoftUniGameStore.App.Views.Games
{
    using System.IO;
    using SimpleMVC.Interfaces;
    using Utillities;

    public class Add : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavAdminFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.AddGameFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));


            return htmlContent.ToString();
        }
    }
}
