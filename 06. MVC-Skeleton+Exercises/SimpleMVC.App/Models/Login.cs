namespace SimpleMVC.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Login
    {
        [Key]
        public string SessionId { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
