namespace SimpleMVC.App.Views.Home
{
    using MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Contacts : IRenderable
    {
        public string Render()
        {
            string htmlContent = File.ReadAllText("../../content/contacts.html");

            return htmlContent;
        }
    }
}
