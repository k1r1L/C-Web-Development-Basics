namespace SoftUniGameStore.App.Views.Games
{
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class All : IRenderable<List<AdminGameViewModel>>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavAdminFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.AdminGamesFolderLocation));

            StringBuilder gamesHtml = new StringBuilder();
            foreach (var adminGameViewModel in this.Model)
            {
                gamesHtml.AppendLine(adminGameViewModel.ToString());
            }

            htmlContent = htmlContent.Replace("##games##", gamesHtml.ToString());
            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));


            return htmlContent.ToString();
        }

        public List<AdminGameViewModel> Model { get; set; }
    }
}
