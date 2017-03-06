namespace SharpStore.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress, Required]
        public string Sender { get; set; }

        [Required]
        public string Subject { get; set; }

        public string MessageText { get; set; }
    }
}
