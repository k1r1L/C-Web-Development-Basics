namespace SimpleMVC.App.Data
{
    using Models;
    using MVC.Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MvcAppContext : DbContext, IDbIdentityContext
    {
        public MvcAppContext()
            : base("name=MvcAppContext")
        {
        }

        public IDbSet<Login> Logins { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Note> Notes { get; set; }

        void IDbIdentityContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}