namespace SimpleMVC.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}
