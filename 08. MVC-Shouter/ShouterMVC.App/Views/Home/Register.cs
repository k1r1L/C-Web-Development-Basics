using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouterMVC.App.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;
    using Utillities;

    public class Register : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.RegisterFolderLocation);
        }
    }
}
