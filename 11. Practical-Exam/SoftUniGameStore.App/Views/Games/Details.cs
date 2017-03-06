namespace SoftUniGameStore.App.Views.Games
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Details : IRenderable<GameDetailsViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            if (this.Model.IsLogged && this.Model.IsAdmin)
            {
                htmlContent.AppendLine(File.ReadAllText(Constants.NavAdminFolderLocation));
            }
            else if (this.Model.IsLogged)
            {
                htmlContent.AppendLine(File.ReadAllText(Constants.NavRegularFolderLocation));
            }
            else
            {
                htmlContent.AppendLine(File.ReadAllText(Constants.NavNotLoggedFolderLocation));
            }

            htmlContent.AppendLine(this.Model.ToString());
            if (this.Model.IsAdmin)
            {
                htmlContent = htmlContent.Replace("##admin##",
                    $"<a class=\"btn btn-warning\" name=\"edit\" href=\"/games/edit?id={this.Model.Id}\">Edit</a><a class=\"btn btn-danger\"name=\"delete\" href=\"/games/delete?id={this.Model.Id}\">Delete</a>");
            }
            else
            {
                htmlContent = htmlContent.Replace("##admin##", string.Empty);
            }

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));
            return string.Format(htmlContent.ToString(), this.Model.Trailer);
        }

        public GameDetailsViewModel Model { get; set; }
    }
}
