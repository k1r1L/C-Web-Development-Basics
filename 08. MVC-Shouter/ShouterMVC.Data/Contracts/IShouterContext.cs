using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouterMVC.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IShouterContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Login> Logins { get; }

        IDbSet<Shout> Shouts { get; }

        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;

        void Detach<T>(T entry)
            where T : class;
    }
}
