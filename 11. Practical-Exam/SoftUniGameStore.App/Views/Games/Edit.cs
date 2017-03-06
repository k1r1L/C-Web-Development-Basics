using System.Text;

namespace SoftUniGameStore.App.Views.Games
{
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Edit : IRenderable<EditGameViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavAdminFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.EditGameFolderLocation));

            htmlContent = htmlContent.Replace("##name##", this.Model.Title);
            htmlContent = htmlContent.Replace("##description##", this.Model.Description);
            htmlContent = htmlContent.Replace("##imageUrl##", this.Model.ImageThumbnail);
            htmlContent = htmlContent.Replace("##price##", this.Model.Price.ToString("F2"));
            htmlContent = htmlContent.Replace("##size##", this.Model.Price.ToString("F1"));
            htmlContent = htmlContent.Replace("##trailer##", this.Model.Trailer);
            htmlContent = htmlContent.Replace("##date##", this.Model.ReleaseDate);


            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));


            return htmlContent.ToString();
        }

        public EditGameViewModel Model { get; set; }
    }
}
