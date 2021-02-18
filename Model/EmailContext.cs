using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    internal class EmailContext : DbContext
    {
        public EmailContext() : base()
        {
                
        }

        public DbSet<Email> Emails { get; set; }
    }
}
