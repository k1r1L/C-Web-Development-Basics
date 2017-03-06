namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using System;
    using SimpleMVC.App.MVC.Interfaces.Generic;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model, string location = null)
        {
            this.Action = (IRenderable<T>)Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));
            this.Action.Model = model;
            this.Location = location;
        }

        public IRenderable<T> Action { get; set; }

        public string Location { get; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
