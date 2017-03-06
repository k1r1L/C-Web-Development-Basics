namespace ForumMVC.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Topic
    {
        public Topic()
        {
            this.Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(500)]
        public string Content { get; set; }

        public virtual User Author { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
