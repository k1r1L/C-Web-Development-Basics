namespace ForumMVC.App.ViewModels
{
    using System;

    public class ReplyViewModel
    {
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
