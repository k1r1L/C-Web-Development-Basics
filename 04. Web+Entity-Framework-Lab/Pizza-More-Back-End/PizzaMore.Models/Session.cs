namespace PizzaMore.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Session
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{this.Id}\t{this.UserId}";
        }
    }
}
