namespace ForumMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class ProfileViewModel
    {
        public string Username { get; set; }

        public  List<TopicViewModel> UserTopics { get; set; }

        public bool IsMine { get; set; }
    }
}
