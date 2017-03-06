namespace SoftUniGameStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public double Size  { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
