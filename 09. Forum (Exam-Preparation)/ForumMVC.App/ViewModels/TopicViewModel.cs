namespace ForumMVC.App.ViewModels
{
    using System;

    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int AuthorId { get; set; }

        public int Replies { get; set; }

        public DateTime PostedOn { get; set; }

        public override string ToString()
        {
            return $"<div class=\"thumbnail\">\r\n\t<h4><strong><a href=\"#\">{this.Title}</a><strong>" +
                   $" <small><a href =\"/home/category?categoryName={this.Category}\">{this.Category}</a></small>" +
                   $"</h4><p><a href=\"/forum/profile?id={this.AuthorId}\">{this.Author}</a> {this.PostedOn:dd:MMM:yyyy}</p>\r\n\t" +
                   $"<p>{this.Content}</p>\r\n</div>";
        }
    }
}
