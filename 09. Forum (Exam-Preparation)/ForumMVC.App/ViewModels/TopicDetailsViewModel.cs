namespace ForumMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class TopicDetailsViewModel
    {
        public TopicViewModel Topic { get; set; }

        public List<ReplyViewModel> ReplyViewModels { get; set; }
    }
}
