using System.Text;

namespace SoftUniGameStore.App.Views.Games
{
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;

    public class Delete : IRenderable<int>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavAdminFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.DeleteGameFolderLocation));
            htmlContent = htmlContent.Replace("##id##", this.Model.ToString());
            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));


            return htmlContent.ToString();
        }

        public int Model { get; set; }
    }
}
