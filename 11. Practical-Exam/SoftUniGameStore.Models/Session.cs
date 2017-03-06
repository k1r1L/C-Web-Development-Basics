namespace SoftUniGameStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Session
    {
        public int Id { get; set; }

        [Required]
        public string SessionId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}
