namespace ShouterMVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            this.Shouts = new List<ShoutViewModel>();
        }

        public string Username { get; set; }

        public bool IsFollowing { get; set; }

        public ICollection<ShoutViewModel> Shouts { get; set; }
    }
}
