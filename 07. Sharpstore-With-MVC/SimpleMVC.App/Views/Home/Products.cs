namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Products : IRenderable
    {
        public string Render()
        {
            string htmlContent = File.ReadAllText("../../content/products.html");

            return htmlContent;
        }
    }
}
