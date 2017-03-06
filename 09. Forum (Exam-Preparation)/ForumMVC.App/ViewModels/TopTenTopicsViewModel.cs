namespace ForumMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class TopTenTopicsViewModel
    {
        public bool IsLogged { get; set; }

        public ICollection<TopicViewModel> Topics { get; set; }
    }
}
