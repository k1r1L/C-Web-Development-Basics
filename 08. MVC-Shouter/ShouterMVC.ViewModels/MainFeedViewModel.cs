namespace ShouterMVC.ViewModels
{
    using System.Collections.Generic;

    public class MainFeedViewModel
    {
        public MainFeedViewModel()
        {
            this.Shouts = new List<ShoutViewModel>();
        }

        public bool IsLogged { get; set; }

        public ICollection<ShoutViewModel> Shouts { get; set; }
    }
}
