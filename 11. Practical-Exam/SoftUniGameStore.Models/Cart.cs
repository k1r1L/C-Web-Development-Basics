namespace SoftUniGameStore.Models
{
    using System.Collections.Generic;

    public class Cart
    {
        public Cart()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string SessionId { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
