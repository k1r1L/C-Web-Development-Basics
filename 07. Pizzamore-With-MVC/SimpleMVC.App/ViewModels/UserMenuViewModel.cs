namespace SimpleMVC.App.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class UserMenuViewModel
    {
        public string Email { get; set; }

        public ICollection<Pizza> Suggestions { get; set; }
    }
}
