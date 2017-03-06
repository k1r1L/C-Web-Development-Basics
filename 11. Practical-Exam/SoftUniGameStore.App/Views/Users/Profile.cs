using System.Text;

namespace SoftUniGameStore.App.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;
    public class Profile : IRenderable<ProfileViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            if (this.Model.IsAdmin)
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

            htmlContent.AppendLine(File.ReadAllText(Constants.ProfileFolderLocation));
            int counter = 0;
            StringBuilder gamesHtml = new StringBuilder();
            gamesHtml.AppendLine("<div class=\"card-group\">");
            for (int index = 0; index < this.Model.Games.Count; index++, counter++)
            {
                if (counter % 3 == 0)
                {
                    gamesHtml.AppendLine("</div>");
                    gamesHtml.AppendLine("<div class=\"card-group\">");
                }

                gamesHtml.AppendLine(this.Model.Games[index].ToString());
            }
            gamesHtml.AppendLine("</div>");
            htmlContent = htmlContent.Replace("##games#", gamesHtml.ToString());

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));


            return htmlContent.ToString();
        }

        public ProfileViewModel Model { get; set; }
    }
}
