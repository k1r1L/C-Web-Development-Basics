namespace ShouterMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Attributes;

    public class User
    {
        public User()
        {
            this.Shouts = new HashSet<Shout>();
            this.Following = new HashSet<User>();
            this.Followers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Username, Required]
        public string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Password, Required]
        public string Password { get; set; }

        [Birthdate, Required]
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Shout> Shouts { get; set; }

        public virtual ICollection<User> Following { get; set; }

        public virtual ICollection<User> Followers { get; set; }
    }
}
