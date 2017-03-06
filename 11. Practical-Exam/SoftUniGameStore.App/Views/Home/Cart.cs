namespace SoftUniGameStore.App.Views.Home
{
    using System.Text;
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Cart : IRenderable<CartViewModel>
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

            htmlContent.AppendLine(File.ReadAllText(Constants.CartFolderLocation));

            StringBuilder gamesHtml = new StringBuilder();
            foreach (var cartGameViewModel in this.Model.Games)
            {
                gamesHtml.AppendLine(cartGameViewModel.ToString());
            }

            htmlContent = htmlContent.Replace("##games##", gamesHtml.ToString());
            htmlContent = htmlContent.Replace("##totalPrice##", this.Model.TotalPrice.ToString("F2"));

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));


            return htmlContent.ToString();
        }

        public CartViewModel Model { get; set; }
    }
}
