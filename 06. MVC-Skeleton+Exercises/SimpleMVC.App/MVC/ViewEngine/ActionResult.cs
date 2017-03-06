namespace SimpleMVC.App.MVC.ViewEngine
{
    using System;
    using Interfaces;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName, string location = null)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(Type.GetType(viewFullQualifedName));
            this.Location = location;
        }

        public IRenderable Action { get; set; }

        public string Location { get; }

        public string Invoke()
        {
           return this.Action.Render();
        }
    }
}
