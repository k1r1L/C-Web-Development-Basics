namespace ForumMVC.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SessionId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
