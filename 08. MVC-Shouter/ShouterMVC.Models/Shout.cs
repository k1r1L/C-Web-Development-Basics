namespace ShouterMVC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Shout
    {
        public int Id { get; set; }

        [StringLength(160), Required]
        public string Content { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        public virtual User Shouter { get; set; }

        public TimeSpan CalculateLifespan()
        {
            TimeSpan lifetime = DateTime.Now - this.PostedOn;

            return lifetime;
        }
    }
}
