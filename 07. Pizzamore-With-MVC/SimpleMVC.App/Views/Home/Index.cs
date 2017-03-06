namespace SimpleMVC.App.Views.Home
{
    using SimpleMVC.App.MVC.Interfaces;
    using System.Text;
    using Utillities;

    public class Index : IRenderable
    {
        public string Render()
        {
            string indexHtml = WebUtil.RetrieveFileContent(Constants.HomeEnFolderLocation);

            return indexHtml;
        }
    }
}
