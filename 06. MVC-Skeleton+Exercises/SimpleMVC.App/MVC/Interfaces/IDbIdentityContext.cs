namespace SimpleMVC.App.MVC.Interfaces
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDbIdentityContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Login> Logins { get; set; }

        void SaveChanges();
    }
}
