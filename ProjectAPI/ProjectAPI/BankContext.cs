using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class BankContext : DbContext
    {
        public DbSet<projectAPI.Person> Person { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public BankContext()
        {

        }
        public BankContext(DbContextOptions<BankContext> options ): base(options)
        {

        }
    }
}
