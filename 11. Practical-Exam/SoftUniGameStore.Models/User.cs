using System.Collections.Generic;

namespace SoftUniGameStore.Models
{
    public class User
    {

        public User()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
