namespace ShouterMVC.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Login
    {
        [Key]
        public string SessionId { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
