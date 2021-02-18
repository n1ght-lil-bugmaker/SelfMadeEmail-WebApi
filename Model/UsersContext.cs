using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
