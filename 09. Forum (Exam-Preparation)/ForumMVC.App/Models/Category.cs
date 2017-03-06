namespace ForumMVC.App.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
