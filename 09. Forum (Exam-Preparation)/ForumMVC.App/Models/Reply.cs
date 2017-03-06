namespace ForumMVC.App.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual Topic Topic { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public virtual User Author { get; set; }
    }
}
