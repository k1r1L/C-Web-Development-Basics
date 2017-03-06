namespace ForumMVC.App.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public class User
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        [Required, Username]
        public string Username { get; set; }

        [Required, Email]
        public string Email { get; set; }

        [Required, Password]
        public string Password { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
